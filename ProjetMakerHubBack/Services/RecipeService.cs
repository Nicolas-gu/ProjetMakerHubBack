using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.API.Validators;
using ProjetMakerHubBack.Domain.Entities;
using ProjetMakerHubBack.Domain.Enums;
using System.Security.Claims;

namespace ProjetMakerHubBack.API.Services
{
    public class RecipeService(AppDbContext _db, IWebHostEnvironment _env)
    {
        /// <summary>
        /// Search recipes by searchbar, favorite, isPublic or tag
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<RecipeSearchResponseDto>> SearchAsync(RecipeSearchRequestDto dto, Guid userId)
        {
            var page = dto.Page < 1 ? 1 : dto.Page;
            var pageSize = dto.PageSize < 1 ? 10 : dto.PageSize;
            if(pageSize > 50)
                pageSize = 50;

            var query = _db.Recipes.AsNoTracking().Where(r => r.IsPublic || r.CreatedByUserId == userId);
            // recherche par nom via input
            if(!string.IsNullOrWhiteSpace(dto.Q))
            {
                var q = dto.Q.Trim();
                query = query.Where(r =>
                    EF.Functions.Like(
                        EF.Functions.Collate(r.Title, "Latin1_General_CI_AI"),
                        $"%{q}%"));
            }

            // recherche par tag
            if(dto.TagIds != null && dto.TagIds.Count > 0)
                query = query.Where(r => r.Tags.Any(t => dto.TagIds.Contains(t.Id)));

            // recherche par favoris
            if (dto.Favorite)
                query = query.Where(r => r.UserRecipes.Any(ur => ur.UserId == userId && ur.IsFavorite));

            // recherche par perso
            if (dto.Mine)
                query = query.Where(r => r.CreatedByUserId == userId);

            var total = await query.CountAsync();
            var items = await query
                .OrderByDescending(r => r.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(r => new RecipeSearchResponseDto
                {
                    Id = r.Id,
                    Title = r.Title,
                    CookTime = r.CookTime,
                    PrepTime = r.PrepTime,
                    IsPublic = r.IsPublic,
                    IsFavorite = r.UserRecipes.Any(ur => ur.UserId == userId && ur.IsFavorite),
                    BasePortion = r.BasePortion
                }).ToListAsync();

            return new PagedResultDto<RecipeSearchResponseDto>
            {
                Page = page,
                PageSize = pageSize,
                Total = total,
                Items = items
            };
        }

        /// <summary>
        /// Create a recipe + ingredients, steps and tags
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// 
        public async Task<Recipe> CreateAsync(RecipeCreateDto dto, Guid userId)
        {
            // Validations
            RecipeValidator.ValidateForCreate(dto);

            // creation d la recette
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                BasePortion = dto.BasePortion,
                PrepTime = dto.PrepTime,
                CookTime = dto.CookTime,
                IsPublic = dto.IsPublic,
                CreatedAt = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            for (int i = 0; i < dto.Steps.Count; i++)
            {
                var steptext = dto.Steps[i];
                recipe.RecipeSteps.Add(new RecipeStep
                {
                    Id = Guid.NewGuid(),
                    StepNumber = i + 1,
                    StepInstruction = steptext,
                    RecipeId = recipe.Id
                });
            }

            foreach (var i in dto.Ingredients)
            {
                Guid? ingId;
                var normalized = i.Name.Trim().Replace(" ", "").ToLower();
                Ingredient? ingredient = _db.Ingredients.FirstOrDefault(ing => ing.SearchName == normalized);
                ingId = ingredient?.Id;
                if (ingredient == null)
                {
                    ingId = Guid.NewGuid();
                    _db.Ingredients.Add(new Ingredient { Id = ingId.Value, Name = i.Name, SearchName = normalized });
                }

                recipe.RecipeIngredients.Add(new RecipeIngredient
                {
                    RecipeId = recipe.Id,
                    IngredientId = ingId!.Value,
                    BaseQuantity = i.BaseQuantity,
                    Unit = i.Unit,
                    QuantityText = i.QuantityText
                });
            }

            if(dto.TagIds.Count > 0)
            {
                // tag recup tt les tags de la db dont l'id est ds le dto 
                var tag = await _db.Tags.Where(t => dto.TagIds.Contains(t.Id)).ToListAsync();
                foreach (var t in tag)
                {
                    recipe.Tags.Add(t);
                }
            }

            _db.Recipes.Add(recipe);
            await _db.SaveChangesAsync();

            return recipe;
        }

        /// <summary>
        /// Get recipe detail by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<RecipeDetailResponseDto?> GetByIdAsync(Guid id, Guid userId)
        {
            var recipe = await _db.Recipes
                .AsNoTracking()
                .Where(r => r.Id == id && (r.IsPublic || r.CreatedByUserId == userId))
                .Select(r => new RecipeDetailResponseDto
                {
                    // donnée de la recette
                    Title = r.Title,
                    Description = r.Description,
                    BasePortion = r.BasePortion,
                    PrepTime = r.PrepTime,
                    CookTime = r.CookTime,
                    IsPublic = r.IsPublic,
                    ImageUrl = r.ImageUrl,
                    IsFavorite = r.UserRecipes
                        .Any(ur => ur.UserId == userId && ur.IsFavorite),
                    // etape depuis recipestep
                    Steps = r.RecipeSteps
                        .OrderBy(rs => rs.StepNumber)
                        .Select(re => re.StepInstruction)
                        .ToList(),
                    // ingrdient depuis recipeingredient
                    Ingredients = r.RecipeIngredients
                        .Select(ri => new IngredientDetailDto
                        {
                            Name = ri.Ingredient.Name,
                            Quantity = ri.BaseQuantity,
                            QuantityText = ri.QuantityText,
                            Unit = (int)ri.Unit
                        })
                        .ToList(),
                    // tag depuis recipetag
                    Tags = r.Tags
                        .Select(t => t.Name)
                        .ToList(),
                    TagIds = r.Tags
                        .Select(t => t.Id)
                        .ToList(),
                })
                .FirstOrDefaultAsync();


            return recipe;
        }

        /// <summary>
        /// Update a recipe + ingredients, steps and tags
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task UpdateAsync(Guid recipeId, RecipeUpdateDto dto, Guid userId, string? role)
        {
            RecipeValidator.ValidateForUpdate(dto);

            //recup recette + collections
            var recipe = await _db.Recipes
                .Include(r => r.RecipeIngredients)
                .Include(r => r.Tags)
                .Include(r => r.RecipeSteps)
                .FirstOrDefaultAsync(r => r.Id == recipeId);

            if (recipe == null)
            {
                throw new KeyNotFoundException("Recipe not found.");
            }

            // verifie si admin ou recette perso
            bool isOwner = recipe.CreatedByUserId == userId;
            bool isAdmin = role == "Admin";

            if (!isOwner && !isAdmin)
            {
                throw new UnauthorizedAccessException("You cannot update this recipe.");
            }
                
            // maj des champ de la recette
            recipe.Title = dto.Title;
            recipe.Description = dto.Description;
            recipe.BasePortion = dto.BasePortion;
            recipe.PrepTime = dto.PrepTime;
            recipe.CookTime = dto.CookTime;
            recipe.IsPublic = dto.IsPublic;

            recipe.RecipeSteps.Clear();
            recipe.RecipeIngredients.Clear();
            recipe.Tags.Clear();
            await _db.SaveChangesAsync();


            //maj des steps
            for (int i = 0; i < dto.Steps.Count; i++)
            {
                var steptext = dto.Steps[i];
                _db.RecipeSteps.Add(new RecipeStep
                {
                    Id = Guid.NewGuid(),
                    StepNumber = i + 1,
                    StepInstruction = steptext,
                    RecipeId = recipe.Id
                });
            }

            // maj des ingredient
            foreach (var i in dto.Ingredients)
            {
                Guid? ingId;
                var normalized = i.Name.Trim().Replace(" ", "").ToLower();
                Ingredient? ingredient = _db.Ingredients.FirstOrDefault(ing => ing.SearchName == normalized);
                ingId = ingredient?.Id;
                if (ingredient == null)
                {
                    ingId = Guid.NewGuid();
                    _db.Ingredients.Add(new Ingredient { Id = ingId.Value, Name = i.Name, SearchName = normalized });
                }

                recipe.RecipeIngredients.Add(new RecipeIngredient
                {
                    RecipeId = recipe.Id,
                    IngredientId = ingId!.Value,
                    BaseQuantity = i.Quantity,
                    Unit = i.Unit,
                    QuantityText = i.QuantityText
                });
            }

            // maj des tag

            var requested = dto.TagsIds ?? new List<Guid>();

            var tags = await _db.Tags
                .Where(t => requested.Contains(t.Id))
                .ToListAsync();
            if (requested.Count > 0 && tags.Count == 0)
                throw new InvalidOperationException("Aucun tag trouvé pour les TagIds reçus (IDs invalides ?)");
            recipe.Tags.Clear();
            foreach (var t in tags)
            {
                recipe.Tags.Add(t);
            }
            

            await _db.SaveChangesAsync();

        }

        /// <summary>
        /// Delete a recipe by id
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(Guid recipeId, Guid userId, string role)
        {
            // check si recette existe
            var recipe = await _db.Recipes
                .FirstOrDefaultAsync(r => r.Id == recipeId);
            if (recipe == null)
            {
                throw new KeyNotFoundException("Recipe not found.");
            }

            // check si admin ou recette perso
            bool isOwner = recipe.CreatedByUserId == userId;
            bool isAdmin = role == "Admin";
            if (!isOwner && !isAdmin)
            {
                throw new UnauthorizedAccessException("Not allowed.");
            }

            // check si utilisé dans un planning
            var isUsedInPlan = await _db.PlanSlots.AnyAsync(s => s.RecipeId == recipeId);
            if (isUsedInPlan)
            {
                throw new InvalidOperationException("Recipe is used in a plan. Remove it from planning first.");
            }

            // supprime de la liste et save en DB
            _db.Recipes.Remove(recipe);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Add an image to recipe by id and IformFile
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task<string> UploadImgAsync(Guid recipeId, Guid userId, string role, IFormFile file)
        {
            // recup la recette
            var recipe = await _db.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
            if(recipe == null)
            {
                throw new KeyNotFoundException("Recipe not found");
            }

            // check si admin ou recette perso
            bool isOwner = recipe.CreatedByUserId == userId;
            bool isAdmin = role == "Admin";
            if (!isOwner && !isAdmin)
            {
                throw new UnauthorizedAccessException("Not allowed.");
            }

            // recupérer l'extension du fichier
            var ext = Path.GetExtension(file.FileName).ToLower();
            // si pas ext = .jpg
            if (string.IsNullOrWhiteSpace(ext))
            {
                ext = ".jpg";
            }

            // creer un nom de fichier unique
            var fileName = $"{recipeId}_{Guid.NewGuid():N}{ext}";
            // construit le chemin 
            var relativePath = Path.Combine("images", "recipes", fileName);
            var absolutePath = Path.Combine(_env.WebRootPath, relativePath);
            // et crée le dossier si nécessaire
            Directory.CreateDirectory(Path.GetDirectoryName(absolutePath)!);

            // supprime ancienne image si existe
            if (!string.IsNullOrWhiteSpace(recipe.ImageUrl))
            {
                // modifie le chemin
                var old = Path.Combine(
                    _env.WebRootPath,
                    recipe.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar)
                );

                if (File.Exists(old))
                {
                    File.Delete(old);
                }
            }

            // crée le fichier et copie le contenu
            using var stream = new FileStream(absolutePath, FileMode.Create);
            await file.CopyToAsync(stream);
            // remodifie le chemin et save
            recipe.ImageUrl = "/" + relativePath.Replace("\\", "/");
            await _db.SaveChangesAsync();

            return recipe.ImageUrl;
        }

        /// <summary>
        /// Add or remove recipe to favorite by id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="recipeId"></param>
        /// <param name="isFavorite"></param>
        /// <returns></returns>
        public async Task SetFavoriteAsync(Guid userId, Guid recipeId, bool isFavorite)
        {
            // cherche un userRecipe correspondant aux 2 ids
            var link = await _db.UserRecipes.FindAsync(userId, recipeId);

            // si null on crée un userRecipe et isFavorite = true + add
            if(link == null)
            {
                link = new UserRecipe
                {
                    UserId = userId,
                    RecipeId = recipeId,
                    AddedAt = DateTime.UtcNow,
                    IsFavorite = isFavorite
                };
                _db.UserRecipes.Add(link);
            }
            // si existe (donc deja favoris) isFavorite = false + remove
            else
            {
                link.IsFavorite = isFavorite;
                _db.UserRecipes.Remove(link);

            }

            await _db.SaveChangesAsync();
        }

    }
}


