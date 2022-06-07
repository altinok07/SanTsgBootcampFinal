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

        public User GetById(int id)
        {
            return _unitOfWork.Users.Get(user => user.Id == id);
        }

        public void Delete(User user)
        {
            _unitOfWork.Users.Delete(user);
            _unitOfWork.Complete();
        }

        public void Update(User user)
        {
            _unitOfWork.Users.Update(user);
            _unitOfWork.Complete();
        }

        public User GetByEmail(string email)
        {
            return _unitOfWork.Users.Get(user => user.Email == email);
        }

        public void Add(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();
        }

        public void UpdateIsActive(User user)
        {
            if (user.IsActive == true)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }
            _unitOfWork.Complete();
        }

    }
}
