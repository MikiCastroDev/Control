using Control.Core.Domain.OutPorts;
using Control.Infrastructure.Domain.Models.DTOs;
using Control.Infrastructure.Domain.Models.Mappers;
using Control.Infrastructure.Repo.DBContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Control.Core.Repo.Adapters
{
    public class UsersAdapter : IUsersAdapter
    {
        private readonly IDbContextFactory<ControlContext> _context;

        public UsersAdapter(IDbContextFactory<ControlContext> context)
        {
            _context = context;
        }
        public UserDTO? GetUser(string email, string password)
        {
            using ControlContext context = _context.CreateDbContext();

            User? user = context.Users.Find(email);
            if (user != null)
                return Mapper.MapFromEF(user);

            return null;
        }
    }
}
