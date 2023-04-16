using AutoMapper;
using TaskManager.Application.Common.Mappings;
using TaskManager.Domain;

namespace TaskManager.Application.Users.Commands.CreateUserCommand
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                   .ForMember(task => task.Name,
                   opt => opt.MapFrom(task => task.Name))
                     .ForMember(task => task.Surname,
                   opt => opt.MapFrom(dto => dto.Surname));
        }
    }
}
