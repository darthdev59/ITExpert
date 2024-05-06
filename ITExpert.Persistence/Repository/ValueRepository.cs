using ITExpert.Application.Values.Queries.GetValues;
using ITExpert.Domain.Entities;
using ITExpert.Domain.Repositories;
using ITExpert.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ITExpert.Persistence.Repository
{
    public class ValueRepository(AppDbContext dbContext) : IValueRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task AddRange(IEnumerable<ValueEntity> entities)
        {
            _dbContext.Values.RemoveRange(_dbContext.Values);

            var data = entities
                .OrderBy(x => x.Code)
                .Select((x, count) => x.SetRow(count++))
                .ToList();

            await _dbContext.Values.AddRangeAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ValueEntity>> GetAll()
        {
            return [.. await _dbContext.Values.AsNoTracking().ToListAsync()];
        }

        private IQueryable<ValueEntity> ApplySpecification(
            Specification<ValueEntity> specification)
        {
            return SpecificationEvaluator.GetQuery(
                _dbContext.Set<ValueEntity>(),
                specification);
        }

    }
}
