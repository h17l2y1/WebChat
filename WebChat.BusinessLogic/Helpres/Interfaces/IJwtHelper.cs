using WebChat.Entities.Entities;

namespace WebChat.BusinessLogic.Helpres.Interfaces
{
	public interface IJwtHelper
	{
		string GetToken(User user);
	}
}
