using WebChat.Entities.Entities;

namespace WebChat.BusinessLogic.Providers.Interfaces
{
	public interface IJwtTokenProvider
	{
		string GetToken(User user);
	}
}
