using MediatR;
using System.Collections.Generic;

namespace TaskManager.Application.Tasks.Queries.GetTaskList
{
    public class TaskListViewModel
    {
        public IList<TaskListDto> Tasks { get; set; }
    }
}
