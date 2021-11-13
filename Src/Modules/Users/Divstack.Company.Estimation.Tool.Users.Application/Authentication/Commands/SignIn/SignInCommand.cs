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
        private readonly IJwtTokenManagementService jwtTokenManagementService;
        private readonly IRefreshTokenGenerationService refreshTokenGenerationService;
        private readonly ISignInManagementService signInManagementService;
        private readonly IUserManagementService userManagementService;

        public Handler(ISignInManagementService signInManagementService,
            IJwtTokenManagementService jwtTokenManagementService,
            IUserManagementService userManagementService,
            IRefreshTokenGenerationService refreshTokenGenerationService)
        {
            this.signInManagementService = signInManagementService;
            this.jwtTokenManagementService = jwtTokenManagementService;
            this.userManagementService = userManagementService;
            this.refreshTokenGenerationService = refreshTokenGenerationService;
        }

        public async Task<SignInCommandResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var signInResultStatus = await signInManagementService.SignInAsync(request.UserName, request.Password);

            if (signInResultStatus != SignInResultStatus.Positive)
            {
                await signInManagementService.SaveLogForFailedLoginAttemptAsync(request.UserName,
                    cancellationToken);
                var signInFailedCommandResponse =
                    SignInCommandResponse.CreateFailed(signInResultStatus, request.UserName);
                return signInFailedCommandResponse;
            }

            var userRole = await userManagementService.GetUserRolesAsync(request.UserName);

            var userDetails = await userManagementService.GetUserDetailsAsync(request.UserName);
            var jwtToken = jwtTokenManagementService.GenerateJwtToken(userDetails, userRole);
            var refreshToken = await refreshTokenGenerationService.GenerateRefreshTokenAsync(userDetails.PublicId);

            var signInCommandResponse = SignInCommandResponse.CreateSuccess(jwtToken, refreshToken);
            return signInCommandResponse;
        }
    }
}
