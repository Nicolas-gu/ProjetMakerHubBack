using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.Application.Utils;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Services
{
    public class TagService(AppDbContext _db)
    {
        public async Task<List<TagListItemDto>> GetAllAsync()
        {
            return await _db.Tags
                .AsNoTracking()
                .OrderBy(t => t.Name)
                .Select(t => new TagListItemDto
                {
                    Name = t.Name,
                    Id = t.Id
                }).ToListAsync();
        }

        public async Task<Tag> CreateAsync(TagCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Tag name is required.");
            }

            var normalizedName = NormalizeName.Normalize(dto.Name);
            var existing = await _db.Tags
                .FirstOrDefaultAsync(i => i.SearchName == normalizedName);

            if (existing != null)
            {
                throw new InvalidOperationException("Tag already exists.");
            }

            var tag = new Tag
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                SearchName = normalizedName,
            };

            _db.Tags.Add(tag);
            await _db.SaveChangesAsync();

            return tag;
        }

        public async Task DeleteAsync(Guid tagId)
        {
            Tag? toDelete = _db.Tags
                .Find(tagId);
            if (toDelete == null)
            {
                throw new KeyNotFoundException("Tag does not exist.");
            }

            _db.Tags.Remove(toDelete);
            await _db.SaveChangesAsync();
        }

    }
}
