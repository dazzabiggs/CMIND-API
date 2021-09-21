using KB.AUTH.Middleware.Entities;
using KB.AUTH.Middleware.Helpers;
using KB.CMIND.API.Incidents.DBContexts;
using KB.CMIND.API.Incidents.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KB.CMIND.API.Incidents.Services
{
    public interface IAuthService
    {
        Client Authenticate(string clientID, string clientSecret);
    }
    public class AuthService : IAuthService
    {
        private readonly AppSettings _appSettings;
        private readonly AuthRepository _authRepository;

        public AuthService(IOptions<AppSettings> appSettings, IncidentsContext context)
        {
            _appSettings = appSettings.Value;
            _authRepository = new AuthRepository(context);
        }

        public Client Authenticate(string clientID, string clientSecret)
        {
            var client = _authRepository.GetAuthBySecrets(clientID, clientSecret);

            // return null if user not found
            if (client == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, client.ID.ToString()),
                    new Claim(ClaimTypes.Role, client.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            client.Token = tokenHandler.WriteToken(token);

            return client.WithoutSecrets();
        }
    }
}
