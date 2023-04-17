using MediatR;
using System.Collections.Generic;

namespace TaskManager.Application.Tasks.Queries.GetUserTaskList
{
    public class UserTaskListViewModel
    {
        public IList<UserTaskListDto> Tasks { get; set; }
    }
}
