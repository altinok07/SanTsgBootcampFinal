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
        User GetById(int id);
        void Delete(User user);
        void Update(User user);
        User GetByEmail(string email);
        void Add(User user);
        void UpdateIsActive(User user);

    }
}
