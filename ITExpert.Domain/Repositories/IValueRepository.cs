using ITExpert.Domain.Entities;

namespace ITExpert.Domain.Repositories
{
    // Не стал использовать Generic, так как:
    // 1. Описана единственная сущность
    // 2. По тз нам необходим контракт только с двумя методами
    public interface IValueRepository
    {
        Task<IEnumerable<ValueEntity>> GetAll();
        Task AddRange(IEnumerable<ValueEntity> entities);
    }
}
