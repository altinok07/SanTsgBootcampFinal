using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BootcampFinal.Domain.Users;

namespace BootcampFinal.Application.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> GetAllUser();
    }
}
