using FluentValidation;
using TaskManager.Application.Tasks.Queries.GetTaskList;

namespace TaskManager.Application.Tasks.Queries.GetTask
{
    public class GetTaskListQueryValidator : AbstractValidator<GetTaskListQuery>
    {
        public GetTaskListQueryValidator()
        {
        }
    }
}
