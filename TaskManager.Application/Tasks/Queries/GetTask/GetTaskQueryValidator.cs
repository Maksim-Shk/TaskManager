using FluentValidation;

namespace TaskManager.Application.Tasks.Queries.GetTask
{
    public class GetTaskQueryValidator :AbstractValidator<GetTaskQuery>
    {
        public GetTaskQueryValidator()
        {
            RuleFor(query=>query.TaskId).GreaterThanOrEqualTo(1);
        }
    }
}
