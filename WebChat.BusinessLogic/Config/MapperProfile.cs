using WebChat.Entities.Entities;
using WebChat.ViewModels.User;

namespace WebChat.BusinessLogic.Config
{
	public class MapperProfile : AutoMapper.Profile
	{
		public MapperProfile()
		{
			CreateMap<User, RequestSignUpAccount>().ReverseMap();

		}
	}
}
