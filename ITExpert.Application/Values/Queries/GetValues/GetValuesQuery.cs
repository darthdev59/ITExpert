using ITExpert.Application.Abstractions.Messaging;

namespace ITExpert.Application.Values.Queries.GetValues
{
    public sealed record GetValuesQuery : IQuery<List<ValuesResponse>>
    {

    }
}
