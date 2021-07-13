namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.ExchangeRefreshToken
{
    public class ExchangeRefreshTokenResponse
    {
        public ExchangeRefreshTokenResponse(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }

        public string Token { get; }
        public string RefreshToken { get; }
    }
}