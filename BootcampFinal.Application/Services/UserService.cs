using BootcampFinal.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampFinal.Application.Interfaces;
using BootcampFinal.Domain.Users;

namespace BootcampFinal.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void CreateUser(User user)
        {
           _unitOfWork.Users.Add(user);
           _unitOfWork.Complete();
        }

        public List<User> GetAllUser()
        {
            return _unitOfWork.Users.GetAll().ToList();

        }
    }
}
