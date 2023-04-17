using AutoMapper;
using System;
using TaskManager.Application.Common.Mappings;

namespace TaskManager.Application.Tasks.Commands.UpdateTaskCommand
{
    public class UpdateTaskDto : IMapWith<UpdateTaskCommand>
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int ReceiverId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTaskDto, UpdateTaskCommand>()
                     .ForMember(task => task.TaskId,
                   opt => opt.MapFrom(task => task.TaskId))
                     .ForMember(task => task.Name,
                   opt => opt.MapFrom(task => task.Name))
                     .ForMember(task => task.Description,
                   opt => opt.MapFrom(dto => dto.Description))
                     .ForMember(task => task.CreationDate,
                   opt => opt.MapFrom(dto => dto.CreationDate))
                     .ForMember(task => task.ReceiverId,
                   opt => opt.MapFrom(dto => dto.ReceiverId));
        }
    }
}
