using System.Linq.Expressions;

namespace ITExpert.Persistence.Specifications
{
    public abstract class Specification<TEntity>
        where TEntity : class //в идеале ограничиваем базовым типом сущности
    {
        protected Specification(Expression<Func<TEntity, bool>>? criteria) =>
            Criteria = criteria;

        public Expression<Func<TEntity, bool>>? Criteria { get; }

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) =>
            IncludeExpressions.Add(includeExpression);
    }
}
