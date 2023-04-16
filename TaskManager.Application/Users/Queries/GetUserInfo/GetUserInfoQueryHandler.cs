using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManager.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace TaskManager.Application.Users.Queries.GetUserInfo
{
    public class GetUserInfoQueryHandler
  : IRequestHandler<GetUserInfoQuery, UserInfoDto>
    {
        private readonly ITaskManagerContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserInfoQueryHandler(ITaskManagerContext dbContext,
           IMapper mapper) =>
           (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserInfoDto> Handle(GetUserInfoQuery request,
           CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .ProjectTo<UserInfoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(u => u.Id == request.UserId);

            if (user != null)
                return user;
            else
            {
                throw new System.Exception();
            }
        }
    }
}