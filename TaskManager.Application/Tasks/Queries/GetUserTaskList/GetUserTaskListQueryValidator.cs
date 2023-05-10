using FluentValidation;
using TaskManager.Application.Tasks.Queries.GetUserTaskList;

namespace TaskManager.Application.Tasks.Queries.GetTask
{
    public class GetUserTaskListQueryValidator : AbstractValidator<GetUserTaskListQuery>
    {
        public GetUserTaskListQueryValidator()
        {
            RuleFor(query => query.UserId).GreaterThanOrEqualTo(1);
        }
    }
}
