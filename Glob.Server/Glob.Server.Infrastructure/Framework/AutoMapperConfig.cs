using AutoMapper;
using Glob.Server.Core.Domain;
using Glob.Server.Infrastructure.Dto;

namespace Glob.Server.Infrastructure.Framework
{
    public class AutoMapperConfig
    {
        public static IMapper InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<User, ContactDto>();
                cfg.CreateMap<Message, MessageDto>()
                    .ForMember(dst => dst.Sender, src => src.MapFrom(x => x.Sender.Login))
                    .ForMember(dst => dst.Receiver, src => src.MapFrom(x => x.Receiver.Login));
                cfg.CreateMap<AwaitedUser, AwaitedContactDto>()
                    .ForMember(dst => dst.ContactName, src => src.MapFrom(x => x.User.Login));
            });

            return config.CreateMapper();
        }
    }
}
