using MediatR;

namespace TaskManager.Application.Users.Queries.GetUserInfo
{
    public class GetUserInfoQuery : IRequest<UserInfoDto>
    {
        public int UserId { get; set; }
    }
}
