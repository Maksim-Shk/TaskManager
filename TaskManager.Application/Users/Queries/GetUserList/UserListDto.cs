using AutoMapper;
using EnumsNET;
using System;
using System.ComponentModel;
using System.Reflection;
using TaskManager.Application.Common.Mappings;
using TaskManager.Domain;

namespace TaskManager.Application.Users.Queries.GetUserList
{
    public class UserListDto : IMapWith<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastChangeDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserListDto>()
                   .ForMember(task => task.Id,
                   opt => opt.MapFrom(dto => dto.UserId))
                   .ForMember(task => task.Name,
                   opt => opt.MapFrom(task => task.Name))
                     .ForMember(task => task.Surname,
                   opt => opt.MapFrom(dto => dto.Surname))
                     .ForMember(task => task.Status,
                   opt => opt.MapFrom(dto => ((UserStatusEnum)dto.Status).AsString(EnumFormat.Description)))
                     .ForMember(task => task.CreatedDate,
                   opt => opt.MapFrom(dto => dto.CreationDate))
                     .ForMember(task => task.LastChangeDate,
                   opt => opt.MapFrom(dto => dto.LastChangeDate));
        }
    }
}
