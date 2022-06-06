using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BootcampFinal.Data.Repositories.Interfaces;
using BootcampFinal.Domain.Users;

namespace BootcampFinal.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BootcampFinalDbContext context) : base(context)
        {
        }

        public List<User> GetUsersByActive(string city)
        {
            return _context.Users.Where(user => user.IsActive == true).ToList();
        }
    }
}
