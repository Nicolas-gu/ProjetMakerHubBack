using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.Application.Utils;
using ProjetMakerHubBack.Domain.Entities;
using ProjetMakerHubBack.Domain.Enums;
using static ProjetMakerHubBack.API.Dto.ShoppingListItemsDto;

namespace ProjetMakerHubBack.API.Services
{
    public class ShoppingListService(AppDbContext _db)
    {
        public async Task<ShoppingListDto?> GetAsync(Guid userId, DateOnly weekStart)
        {
            weekStart = weekStart.ToWeekStartMonday();

            var list = await _db.ShoppingLists
                .AsNoTracking()
                .Where(sl => sl.UserId == userId && sl.WeekStart == weekStart)
                .Select(sl => new ShoppingListDto
                {
                    Id = sl.Id,
                    WeekStart = sl.WeekStart,
                    Items = sl.ShoppingListItems
                        .OrderBy(i => i.Ingredient.Name)
                        .Select(i => new ShoppingListItemDto
                        {
                            Id = i.Id,
                            IngredientId = i.IngredientId,
                            IngredientName = i.Ingredient.Name,
                            Quantity = i.Quantity ?? 0m,
                            QuantityText = i.QuantityText,
                            Unit = i.Unit,
                            IsChecked = i.IsChecked
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
            return list;
        }

        public async Task GenerateAsync(Guid userId, DateOnly weekStart)
        {
            // pour selectionner le lundi de la semaine
            weekStart = weekStart.ToWeekStartMonday();

            // recup le planning
            var plan = await _db.Plans
                .Include(p => p.Slots)
                .ThenInclude(s => s.Recipe)
                .ThenInclude(r => r.RecipeIngredients)
                .FirstOrDefaultAsync(p =>
                    p.UserId == userId &&
                    p.WeekStartDate == weekStart);

            if (plan == null)
            {
                throw new KeyNotFoundException("Plan not found.");
            }

            // calcul quantité ingredient dans les slot de la semaine
            var needs = new Dictionary<(Guid IngredientId, Unit Unit), decimal>();

            foreach (var slot in plan.Slots)
            {
                var recipe = slot.Recipe!;

                foreach (var ri in recipe.RecipeIngredients)
                {
                    if (ri.BaseQuantity == null)
                        continue;

                    var ratio = (decimal)slot.Portion / recipe.BasePortion;
                    var qty = ri.BaseQuantity.Value * ratio;
                    var unit = ri.Unit ?? Unit.Unknown;
                    var key = (ri.IngredientId, unit);

                    if (!needs.ContainsKey(key))
                        needs[key] = 0m;

                    needs[key] += qty;
                }
            }

            // decompte stock maison
            var pantry = await _db.PantryItems
                .Where(p => p.UserId == userId)
                .ToListAsync();

            foreach (var p in pantry)
            {
                var key = (p.IngredientId,p.Unit);

                if (needs.ContainsKey(key))
                {
                    needs[key] -= p.Quantity;
                }
            }

            // recup uniquement les ingredient manquant
            var missing = needs
                .Where(kv => kv.Value > 0)
                .ToList();

            // supprime ancienne liste 
            var existingList = await _db.ShoppingLists
                .Include(sl => sl.ShoppingListItems)
                .FirstOrDefaultAsync(sl =>
                    sl.UserId == userId &&
                    sl.WeekStart == weekStart);

            if (existingList != null)
            {
                _db.ShoppingListItems.RemoveRange(existingList.ShoppingListItems);
                _db.ShoppingLists.Remove(existingList);
            }

            // crée nouvelle liste
            var newList = new ShoppingList
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                WeekStart = weekStart,
                CreatedAt = DateTime.UtcNow,
                ShoppingListItems = new List<ShoppingListItem>()
            };

            foreach (var m in missing)
            {
                newList.ShoppingListItems.Add(new ShoppingListItem
                {
                    Id = Guid.NewGuid(),
                    IngredientId = m.Key.IngredientId,
                    Quantity = m.Value,
                    Unit = m.Key.Unit,
                    IsChecked = false
                });
            }

            _db.ShoppingLists.Add(newList);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(Guid userId, Guid itemId, ShoppingListItemUpdateDto dto)
        {
            var item = await _db.ShoppingListItems
                .Include(i => i.ShoppingList)
                .FirstOrDefaultAsync(i => i.Id == itemId && i.ShoppingList.UserId == userId);

            if(item == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            if (dto.IsChecked.HasValue)
            {
                item.IsChecked = dto.IsChecked.Value;
            }

            if (dto.Quantity.HasValue)
            {
                if (dto.Quantity.Value < 0)
                {
                    throw new ArgumentException("Quantity must be >= 0.");
                }
                item.Quantity = dto.Quantity.Value;
            }

            if (dto.Unit.HasValue)
            {
                item.Unit = dto.Unit.Value;
            }

            if(dto.QuantityText != null)
            {
                item.QuantityText = dto.QuantityText;
            }

            await _db.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(Guid userId, Guid itemId)
        {
            var item = await _db.ShoppingListItems
                .Include(i => i.ShoppingList)
                .FirstOrDefaultAsync(i => i.Id == itemId && i.ShoppingList.UserId == userId);

            if (item == null)
            {
                throw new KeyNotFoundException("Item not found.");
            }

            _db.ShoppingListItems.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<ShoppingListItemDto> AddAsync(Guid userId, DateOnly weekStart, ShoppingListItemCreateDto dto)
        {
            weekStart = weekStart.ToWeekStartMonday();

            // recup la liste
            var list = await _db.ShoppingLists
                .FirstOrDefaultAsync(sl => sl.UserId == userId && sl.WeekStart == weekStart);

            if (list == null)
            {
                list = new ShoppingList
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    WeekStart = weekStart,
                    CreatedAt = DateTime.UtcNow,
                    ShoppingListItems = new List<ShoppingListItem>()
                };
                _db.ShoppingLists.Add(list);
                await _db.SaveChangesAsync();
            }

            // 
            Ingredient? ingredient;

            if (dto.IngredientId.HasValue && dto.IngredientId.Value != Guid.Empty)
            {
                ingredient = await _db.Ingredients
                    .FirstOrDefaultAsync(i => i.Id == dto.IngredientId.Value);
                if( ingredient == null)
                {
                    throw new KeyNotFoundException("Ingredient not found.");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(dto.IngredientName))
                    throw new ArgumentException("IngredientId or IngredientName is required.");

                var name = dto.IngredientName.Trim();
                var search = name.Replace(" ", "").ToLower();

                var existingIngr = await _db.Ingredients.FirstOrDefaultAsync(i => i.SearchName == search);

                if (existingIngr == null)
                {
                    existingIngr = new Ingredient
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        SearchName = search,
                        CreatedAt = DateTime.UtcNow
                    };
                    _db.Ingredients.Add(existingIngr);
                    await _db.SaveChangesAsync();
                }
                ingredient = existingIngr;
            }

            // 3️⃣ préparer données
            var unit = dto.Unit ?? Unit.Unknown;

            // 4️⃣ vérifier si item déjà présent
            var existingItem = await _db.ShoppingListItems
                .FirstOrDefaultAsync(i => i.ShoppingListId == list.Id
                    && i.IngredientId == ingredient.Id
                    && i.Unit == unit);

            ShoppingListItem item;

            if (existingItem != null)
            {
                // ➕ addition
                if (dto.Quantity.HasValue)
                    existingItem.Quantity = (existingItem.Quantity ?? 0m) + dto.Quantity.Value;

                if (dto.QuantityText != null)
                    existingItem.QuantityText = dto.QuantityText;

                existingItem.IsChecked = false;
                item = existingItem;
            }
            else
            {
                item = new ShoppingListItem
                {
                    Id = Guid.NewGuid(),
                    ShoppingListId = list.Id,
                    IngredientId = ingredient.Id,
                    Quantity = dto.Quantity,
                    Unit = unit,
                    QuantityText = dto.QuantityText,
                    IsChecked = false
                };

                _db.ShoppingListItems.Add(item);
            }

            await _db.SaveChangesAsync();

            // 5️⃣ retour DTO
            return new ShoppingListItemDto
            {
                Id = item.Id,
                IngredientId = ingredient.Id,
                IngredientName = ingredient.Name,
                Quantity = item.Quantity,
                Unit = item.Unit,
                QuantityText = item.QuantityText,
                IsChecked = item.IsChecked
            };
        }
    }
}
