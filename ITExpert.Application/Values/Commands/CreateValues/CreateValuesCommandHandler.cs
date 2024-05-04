using ITExpert.Application.Abstractions.Messaging;
using ITExpert.Domain.Entities;
using ITExpert.Domain.Repositories;
using ITExpert.Domain.Shared;


namespace ITExpert.Application.Values.Commands.CreateValues
{
    public class CreateValuesCommandHandler : ICommandHandler<CreateValueCommand>
    {
        private readonly IValueRepository repository;

        public CreateValuesCommandHandler(IValueRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Result> Handle(CreateValueCommand command, CancellationToken cancellationToken)
        {
            var data = command
                    .Values
                    .Select(
                        (x, count) =>
                            ValueEntity.Create(x.Code, x.Value)
                        );

            if (!data.Any())
            {
                return Result.Failure(new Error("Empty", "Collection is empty"));
            }

            await repository.AddRange(data);
            return Result.Success();
        }
    }
}
