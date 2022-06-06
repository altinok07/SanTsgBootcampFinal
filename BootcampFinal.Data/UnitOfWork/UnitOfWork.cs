using System;
using System.Collections.Generic;
using System.Text;
using BootcampFinal.Data.Repositories;
using BootcampFinal.Data.Repositories.Interfaces;
using BootcampFinal.Data.UnitOfWork.Interfaces;

namespace BootcampFinal.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly BootcampFinalDbContext _context;


        public IUserRepository Users { get; private set; }

        public UnitOfWork(BootcampFinalDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
