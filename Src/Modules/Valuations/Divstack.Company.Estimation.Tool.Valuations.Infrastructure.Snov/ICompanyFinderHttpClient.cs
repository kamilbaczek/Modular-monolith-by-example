using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.HttpClient.Dtos.ClientProfile;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.HttpClient
{
    public interface ISnovHttpClient
    {
        Task<AuthResponse> GetClientProfile(string email);
    }

    public class AuthResponse
    {
        public AuthResponse(
            string accessToken,
            string tokenType,
            int expiresIn
        )
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresIn = expiresIn;
        }

        public string AccessToken { get; }
        public string TokenType { get; }
        public int ExpiresIn { get; }
    }
}


