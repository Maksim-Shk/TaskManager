using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManager.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace TaskManager.Application.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler
  : IRequestHandler<GetUserListQuery, UserListViewModel>
    {
        private readonly ITaskManagerContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(ITaskManagerContext dbContext,
           IMapper mapper) =>
           (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserListViewModel> Handle(GetUserListQuery request,
           CancellationToken cancellationToken)
        {
            var userList = await _dbContext.Users
                .ProjectTo<UserListDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new UserListViewModel { Users = userList };
        }
    }
}