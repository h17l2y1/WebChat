using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebChat.BusinessLogic.Config;
using WebChat.BusinessLogic.Providers.Interfaces;
using WebChat.Entities.Entities;

namespace WebChat.BusinessLogic.Providers
{
	public class JwtTokenProvider : IJwtTokenProvider
	{
		private readonly AuthOptions _authOptions;

		public JwtTokenProvider(IOptions<AuthOptions> authOptions)
		{
			_authOptions = authOptions.Value;
		}

		public string GetToken(User user)
		{
			ClaimsIdentity userClaims = GetIdentity(user);
			JwtSecurityToken jwt = GetToken(userClaims);
			string stringToken = new JwtSecurityTokenHandler().WriteToken(jwt);
			return stringToken;
		}

		private JwtSecurityToken GetToken(ClaimsIdentity identity)
		{
			var key = Encoding.ASCII.GetBytes(_authOptions.Key);
			var jwt = new JwtSecurityToken(
				issuer: _authOptions.Issuer,
				audience: _authOptions.Audience,
				claims: identity.Claims,
				expires: DateTime.UtcNow.AddDays(_authOptions.LifeTime),
				signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
				);
			return jwt;
		}

		private ClaimsIdentity GetIdentity(User user)
		{
			var claimsList = new List<Claim>
				{
					new Claim("UserName", user.UserName),
					new Claim("UserId",user.Id.ToString()),
				};
			ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimsList, "Token");
			return claimsIdentity;
		}
	}
}
