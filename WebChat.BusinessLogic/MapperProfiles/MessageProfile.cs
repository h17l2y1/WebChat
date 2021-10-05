using AutoMapper;
using WebChat.Entities.Entities;
using WebChat.ViewModels;

namespace WebChat.BusinessLogic.MapperProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageModel>().ReverseMap();
            
            // CreateMap<SignUpAccountView, User>()
            //     .ForMember(from => from.UserName, to => to.MapFrom(source => source.Login))
            //     .ForMember(from => from.Password, to => to.MapFrom(source => source.Password));

        }
    }
}