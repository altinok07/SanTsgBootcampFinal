using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using BootcampFinal.Domain.Users;

namespace BootcampFinal.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> GetUsersByActive(string city);
    }
}
