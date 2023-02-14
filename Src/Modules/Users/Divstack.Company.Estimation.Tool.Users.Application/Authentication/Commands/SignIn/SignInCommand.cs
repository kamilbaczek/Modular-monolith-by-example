namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.SignIn;

using System.Threading;
using System.Threading.Tasks;
using Contracts;
using MediatR;

public sealed class SignInCommand : ICommand<SignInCommandResponse>
{
    public SignInCommand(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public string UserName { get; }
    public string Password { get; }

    internal sealed class Handler : IRequestHandler<SignInCommand, SignInCommandResponse>
    {
        private readonly IJwtTokenManagementService _jwtTokenManagementService;
        private readonly IRefreshTokenGenerationService _refreshTokenGenerationService;
        private readonly ISignInManagementService _signInManagementService;
        private readonly IUserManagementService _userManagementService;

        public Handler(ISignInManagementService signInManagementService,
            IJwtTokenManagementService jwtTokenManagementService,
            IUserManagementService userManagementService,
            IRefreshTokenGenerationService refreshTokenGenerationService)
        {
            _signInManagementService = signInManagementService;
            _jwtTokenManagementService = jwtTokenManagementService;
            _userManagementService = userManagementService;
            _refreshTokenGenerationService = refreshTokenGenerationService;
        }

        public async Task<SignInCommandResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var signInRequest = new SignInRequest(request.UserName, request.Password);
            var signInResultStatus = await _signInManagementService.SignInAsync(signInRequest, cancellationToken);

            if (signInResultStatus != SignInResultStatus.Positive)
            {
                await _signInManagementService.SaveLogForFailedLoginAttemptAsync(request.UserName,
                    cancellationToken);
                var signInFailedCommandResponse =
                    SignInCommandResponse.CreateFailed(signInResultStatus, request.UserName);
                
                return signInFailedCommandResponse;
            }

            var userRole = await _userManagementService.GetUserRolesAsync(request.UserName);

            var userDetails = await _userManagementService.GetUserDetailsAsync(request.UserName);
            var jwtToken = _jwtTokenManagementService.GenerateJwtToken(userDetails, userRole);
            var refreshToken = await _refreshTokenGenerationService.GenerateRefreshTokenAsync(userDetails.PublicId);
            var signInCommandResponse = SignInCommandResponse.CreateSuccess(jwtToken, refreshToken);
            
            return signInCommandResponse;
        }
    }
}
