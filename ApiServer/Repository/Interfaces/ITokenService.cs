using System.Security.Claims;
using ApiServer.Models.DTO;

namespace ApiServer.Repository.Interfaces;

    public interface ITokenService
    {
        TokenResponse GetToken(IEnumerable<Claim> claim);
        string GetRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
