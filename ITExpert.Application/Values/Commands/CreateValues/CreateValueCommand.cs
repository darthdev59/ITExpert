using ITExpert.Application.Abstractions.Messaging;

namespace ITExpert.Application.Values.Commands.CreateValues
{
    public class CreateValueCommand : ICommand
    {
        public List<CreateValueRequest> Values { get; set; } = [];
    }
}
