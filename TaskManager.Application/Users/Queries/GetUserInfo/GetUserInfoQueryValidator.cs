using FluentValidation;

namespace TaskManager.Application.Users.Queries.GetUserInfo
{
    public class GetUserInfoQueryValidator : AbstractValidator<GetUserInfoQuery>
    {
        public GetUserInfoQueryValidator()
        {
            RuleFor(query => query.UserId).GreaterThanOrEqualTo(1);
        }
    }
}
