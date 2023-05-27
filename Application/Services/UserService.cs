using Application.Abstractions;
using Application.RequestApiModel;
using Application.ResponseApiModel;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.Entity;
using Microsoft.AspNet.Identity;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserAccessor _userAccessor;

    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider,
        IUnitOfWork unitOfWork, IUserAccessor userAccessor)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
        _unitOfWork = unitOfWork;
        _userAccessor = userAccessor;
    }

    public async Task<Result<string>> Login(LoginRequestApiModel loginRequest, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(loginRequest.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<string>(DomainErrors.User.InvalidCredentials);
        }

        if (_passwordHasher.VerifyHashedPassword(user.Password, loginRequest.Password) ==
            PasswordVerificationResult.Failed)
        {
            return Result.Failure<string>(DomainErrors.User.InvalidCredentials);
        }

        var token = _jwtProvider.Generate(user);

        return token;
    }

    public async Task<Result<string>> Register(RegisterRequestApiModel registerRequest,
        CancellationToken cancellationToken)
    {
        if (!await _userRepository.IsEmailUniqueAsync(registerRequest.Email, cancellationToken))
        {
            return Result.Failure<string>(DomainErrors.User.EmailAlreadyInUse);
        }

        var hashedPassword = _passwordHasher.HashPassword(registerRequest.Password);

        var user = new User(registerRequest.Email, hashedPassword, registerRequest.Name, registerRequest.Phone,
            registerRequest.Skills);

        await _userRepository.Add(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var jwtToken = _jwtProvider.Generate(user);

        return jwtToken;
    }

    public async Task<Result<UserResponseApiModel>> GetUser(CancellationToken cancellationToken)
    {
        var userId = _userAccessor.GetCurrentUserId();

        var userFromDb = await _userRepository.FindByIdAsync(userId, cancellationToken);

        return userFromDb == null
            ? Result.Failure<UserResponseApiModel>(DomainErrors.User.InvalidId)
            : new UserResponseApiModel(userFromDb.Email, userFromDb.Name, userFromDb.Phone, userFromDb.Skills,
                userFromDb.DateCreated, userFromDb.Rating, userFromDb.NumberOfEventsTookPart,
                userFromDb.NumberOfEventsCreated);
    }
}