using AutoMapper;
using System;
using System.ComponentModel;
using TaskManager.Application.Common.Mappings;
using TaskManager.Application.Tasks.Commands.ChangeTaskStatus;
using TaskManager.Domain;

namespace TaskManager.Application.Tasks.Commands.ChangeTaskStatus
{
    public class ChangeTaskStatusDto : IMapWith<ChangeTaskStatusCommand>
    {
        public int TaskId { get; set; }
        public string? Status { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChangeTaskStatusDto, ChangeTaskStatusCommand>()
                     .ForMember(task => task.TaskId,
                   opt => opt.MapFrom(task => task.TaskId))
                     .ForMember(task => task.Status,
                   opt => opt.MapFrom(dto => EnumExtension.GetValueFromDescription<TaskStatusEnum>(dto.Status)));
        }
    }
}
