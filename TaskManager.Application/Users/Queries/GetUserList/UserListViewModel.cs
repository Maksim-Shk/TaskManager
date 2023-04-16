using MediatR;
using System.Collections.Generic;

namespace TaskManager.Application.Users.Queries.GetUserList
{
    public class UserListViewModel
    {
        public IList<UserListDto> Users { get; set; }
    }
}
