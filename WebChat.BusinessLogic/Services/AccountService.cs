using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using WebChat.BusinessLogic.Helpres.Interfaces;
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
		private readonly IJwtHelper _jwtHelper;
		private readonly IMapper _mapper;

		public AccountService(UserManager<User> userManager,
								SignInManager<User> signInManager,
								IMapper mapper,
								IJwtHelper jwtHelper
		)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_mapper = mapper;
			_jwtHelper = jwtHelper;
		}

		public async Task SignUp(RequestSignUpAccount view)
		{
			User user = _mapper.Map<User>(view);
			await _userManager.CreateAsync(user);
		}

		public async Task<ResponseUserTokenView> LogIn(RequestLogInAccount model)
		{
			User user = _userManager.Users.FirstOrDefault(x => x.UserName == model.Login && x.Password == model.Password);
			string token = _jwtHelper.GetToken(user);
			var view = new ResponseUserTokenView(token);
			return view;
		}

	}
}
