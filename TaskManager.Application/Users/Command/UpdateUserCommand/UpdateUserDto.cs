using AutoMapper;
using System;
using TaskManager.Application.Common.Mappings;

namespace TaskManager.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                     .ForMember(task => task.UserId,
                   opt => opt.MapFrom(task => task.UserId))
                     .ForMember(task => task.Name,
                   opt => opt.MapFrom(task => task.Name))
                     .ForMember(task => task.Surname,
                   opt => opt.MapFrom(dto => dto.Surname))
                     .ForMember(task => task.CreationDate,
                   opt => opt.MapFrom(dto => dto.CreationDate));

        }
    }
}
