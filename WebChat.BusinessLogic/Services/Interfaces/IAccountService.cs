using System.Threading.Tasks;
using WebChat.ViewModels.User;

namespace WebChat.BusinessLogic.Services.Interfaces
{
	public interface IAccountService
	{
		Task SignUp(RequestSignUpAccount view);

		Task<ResponseUserTokenView> LogIn(RequestLogInAccount view);

	}
}
