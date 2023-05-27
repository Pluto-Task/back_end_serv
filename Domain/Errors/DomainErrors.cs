using Domain.Shared;

namespace Domain.Errors;

public static class DomainErrors
{
    public static class User
    {
        public static readonly Error InvalidCredentials = new(
            "User.InvalidCredentials",
            "The provided credentials are invalid");

        public static readonly Error EmailAlreadyInUse = new(
            "User.EmailAlreadyInUse",
            "The specified email is already in use");

        public static readonly Error InvalidId = new(
            "User.InvalidId",
            "The user was not found by provided identificator"
        );
    }
}