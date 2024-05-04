using ITExpert.Application.Abstractions.Messaging;
using ITExpert.Domain.Repositories;
using ITExpert.Domain.Shared;

namespace ITExpert.Application.Values.Queries.GetValues
{
    public class GetValuesQueryHandler(IValueRepository valueRepository) : IQueryHandler<GetValuesQuery, List<ValuesResponse>>
    {
        private readonly IValueRepository valueRepository = valueRepository;

        public async Task<Result<List<ValuesResponse>>> Handle(GetValuesQuery request, CancellationToken cancellationToken)
        {
            var data = await valueRepository.GetAll();

            return Result.Success(
                data
                .Select(x => new ValuesResponse(x.Row, x.Code, x.Value))
                .ToList());
        }
    }
}
