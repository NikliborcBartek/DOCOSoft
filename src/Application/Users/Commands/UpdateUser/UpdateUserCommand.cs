using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entieties;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.GetUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IDbContext _context;

        public UpdateUserCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundEntryException(nameof(User), request.Id);
            }

            entity.UpdatePersonalInfo(request.Name, request.Surname, request.Age);
            _context.Users.Add(entity);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}