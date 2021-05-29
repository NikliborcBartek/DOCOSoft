using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entieties;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.GetUser
{
    public class GetUserQuery : IRequest<UserVm>
    {
        public long Id { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserVm> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundEntryException(nameof(User), request.Id);
            }
            return _mapper.Map<User, UserVm>(entity); 
        }
    }
}