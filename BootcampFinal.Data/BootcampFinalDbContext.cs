using System;
using System.Collections.Generic;
using System.Text;
using BootcampFinal.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace BootcampFinal.Data
{
    public class BootcampFinalDbContext : DbContext
    {
        public BootcampFinalDbContext(DbContextOptions<BootcampFinalDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
