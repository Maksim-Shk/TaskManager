using MediatR;

namespace TaskManager.Application.Tasks.Queries.GetTask
{
    public class GetTaskQuery : IRequest<GetTaskDto>
    {
        public int TaskId { get; set; }
    }
}
