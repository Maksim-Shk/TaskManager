using AutoMapper;
using EnumsNET;
using System;
using System.ComponentModel;
using System.Reflection;
using TaskManager.Application.Common.Mappings;
using TaskManager.Domain;

namespace TaskManager.Application.Tasks.Queries.GetTaskList
{
    public class TaskListDto : IMapWith<Task>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastChangeDate { get; set; }
        public string? SenderName { get; set; }
        public int SenderId { get; set; }
        public string? ReceiverName { get; set; }
        public int ReceiverId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task, TaskListDto>()
                   .ForMember(task => task.Id,
                   opt => opt.MapFrom(dto => dto.TaskId))
                   .ForMember(task => task.Name,
                   opt => opt.MapFrom(task => task.Name))
                     .ForMember(task => task.Description,
                   opt => opt.MapFrom(dto => dto.Description))
                     .ForMember(task => task.Status,
                   opt => opt.MapFrom(dto => ((TaskStatusEnum)dto.Status).AsString(EnumFormat.Description)))
                     .ForMember(task => task.CreatedDate,
                   opt => opt.MapFrom(dto => dto.CreationDate))
                     .ForMember(task => task.LastChangeDate,
                   opt => opt.MapFrom(dto => dto.LastChangeDate))
                      .ForMember(task => task.SenderId,
                   opt => opt.MapFrom(dto => dto.SenderId))
                       .ForMember(task => task.ReceiverId,
                   opt => opt.MapFrom(dto => dto.ReceiverId));
        }
    }
}
