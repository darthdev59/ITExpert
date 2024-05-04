using ITExpert.Domain.Entities;
using ITExpert.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITExpert.Persistence.Repository
{
    public class ValueRepository(AppDbContext dbContext) : IValueRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public async Task AddRange(IEnumerable<ValueEntity> entities)
        {
            dbContext.Values.RemoveRange(dbContext.Values);

            var data = entities
                .OrderBy(x => x.Code)
                .Select((x, count) => x.SetRow(count++))
                .ToList();

            await dbContext.Values.AddRangeAsync(data);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ValueEntity>> GetAll()
        {
            return [.. await dbContext.Values.AsNoTracking().ToListAsync()];
        }
    }
}
