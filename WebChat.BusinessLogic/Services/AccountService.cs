using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebChat.BusinessLogic.Providers.Interfaces;
using WebChat.BusinessLogic.Services.Interfaces;
using WebChat.DataAccess.Repository.Interfaces;
using WebChat.Entities.Entities;
using WebChat.ViewModels.User;

namespace WebChat.BusinessLogic.Services
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IUserRepository _userRepository;
		private readonly IJwtTokenProvider _jwtTokenProvider;
		private readonly IMapper _mapper;


		public AccountService(UserManager<User> userManager,
								SignInManager<User> signInManager,
								IMapper mapper,
								IJwtTokenProvider jwtTokenProvider
		)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_mapper = mapper;
			_jwtTokenProvider = jwtTokenProvider;
		}

		public async Task SignUp(RequestSignUpAccount view)
		{
			User user = _mapper.Map<User>(view);

			await _userManager.CreateAsync(user);
		}

		//public async Task<TokenAccountView> LogIn(string userName)
		//{
		//	User user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
		//	if (user == null)
		//	{
		//		await SignUp(userName);
		//		user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
		//	}
		//	var token = new TokenAccountView
		//	{
		//		Token = _jwtTokenProvider.GetTokenString(user)
		//	};
		//	return token;
		//}

	}
}
