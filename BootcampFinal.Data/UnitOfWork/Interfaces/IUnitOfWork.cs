using System;
using System.Collections.Generic;
using System.Text;
using BootcampFinal.Data.Repositories.Interfaces;

namespace BootcampFinal.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }
        void Complete();
    }
}
