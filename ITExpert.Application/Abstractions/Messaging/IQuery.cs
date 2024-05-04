using ITExpert.Domain.Shared;
using MediatR;

namespace ITExpert.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}