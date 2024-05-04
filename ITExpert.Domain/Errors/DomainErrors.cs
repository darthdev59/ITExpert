using ITExpert.Domain.Shared;

namespace ITExpert.Domain.Errors;

public static class DomainErrors
{
    public static class Value
    {
        public static readonly Error ValueEmpty = new(
            "Value.Empty",
            "Value is empty");

        public static readonly Error CodeEmpty = new(
            "Code.Empty",
            "Code is empty");
    }

}