using ITExpert.Domain.Shared;
using MediatR;

namespace ITExpert.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
