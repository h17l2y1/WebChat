using WebChat.Entities.Entities;
using WebChat.ViewModels.User;

namespace WebChat.BusinessLogic.Config
{
	public class MapperProfile : AutoMapper.Profile
	{
		public MapperProfile()
		{
			//CreateMap<User, RequestSignUpAccount>().ReverseMap();


			CreateMap<User, RequestSignUpAccount>().ReverseMap()
				  .ForMember(x => x.UserName, x => x.MapFrom(m => m.Login));

		}
	}
}
