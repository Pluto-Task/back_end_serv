using Application.RequestApiModel;
using Application.ResponseApiModel;
using Domain.Shared;

namespace Application.Abstractions;

public interface IUserService
{
    Task<Result<string>> Login(LoginRequestApiModel loginRequest, CancellationToken cancellationToken);

    Task<Result<string>> Register(RegisterRequestApiModel registerRequest, CancellationToken cancellationToken);

    Task<Result<UserResponseApiModel>> GetUser(CancellationToken cancellationToken);
}