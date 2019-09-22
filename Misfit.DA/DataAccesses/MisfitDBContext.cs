using Microsoft.EntityFrameworkCore;
using Misfit.CORE.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misfit.DA.DataAccesses
{
    public class MisfitDBContext : DbContext
    {
        public MisfitDBContext()
        {
        }
        public MisfitDBContext(DbContextOptions<MisfitDBContext> options)
       : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Calculation> Calculations { get; set; }
    }
}
