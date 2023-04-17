using AutoMapper;
using System;
using TaskManager.Application.Common.Mappings;

namespace TaskManager.Application.Tasks.Commands.ChangeTaskReceiver
{
    public class ChangeTaskReceiverDto : IMapWith<ChangeTaskReceiverCommand>
    {
        public int TaskId { get; set; }
        public int ReceiverId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChangeTaskReceiverDto, ChangeTaskReceiverCommand>()
                     .ForMember(task => task.TaskId,
                   opt => opt.MapFrom(task => task.TaskId))
                     .ForMember(task => task.ReceiverId,
                   opt => opt.MapFrom(dto => dto.ReceiverId));
        }
    }
}
