using MediatR;

namespace TaskManager.Application.Tasks.Queries.GetUserTaskList
{
    public class GetUserTaskListQuery : IRequest<UserTaskListViewModel>
    {
        public int UserId { get; set; }
    }
}
