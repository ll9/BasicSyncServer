using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BasicSyncServer.Models
{
    public class BasicSyncServerContext : DbContext
    {
        public BasicSyncServerContext (DbContextOptions<BasicSyncServerContext> options)
            : base(options)
        {
        }

        public DbSet<BasicSyncServer.Models.BasicEntity> BasicEntity { get; set; }
    }
}
