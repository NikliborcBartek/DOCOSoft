using Application.Common.Interfaces;
using Domain.Entieties;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IDbContext _context;

        public CreateUserCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User(request.Name, request.Surname, request.Age);

            _context.Users.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}