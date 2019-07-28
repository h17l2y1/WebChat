using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebChat.BusinessLogic.Config;
using WebChat.BusinessLogic.Helpres.Interfaces;
using WebChat.Entities.Entities;

namespace WebChat.BusinessLogic.Helpres
{
	public class JwtHelper : IJwtHelper
	{
		private readonly AuthOptions _authOptions;

		public JwtHelper(IOptions<AuthOptions> authOptions)
		{
			_authOptions = authOptions.Value;
		}

		public string GetToken(User user)
		{
			ClaimsIdentity userClaims = GetClaims(user);
			JwtSecurityToken token = GetToken(userClaims);
			string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
			return tokenString;
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

		private ClaimsIdentity GetClaims(User user)
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
