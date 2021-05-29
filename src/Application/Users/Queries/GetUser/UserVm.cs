using AutoMapper;
using Domain.Entieties;

namespace Application.Users.Commands.GetUser
{
    public class UserVm
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
    }

    public class UserVmProfile : Profile
    {
        public UserVmProfile()
        {
            CreateMap<User, UserVm>(); 
        }
    }
}
