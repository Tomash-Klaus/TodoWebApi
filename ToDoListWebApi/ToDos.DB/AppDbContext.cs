using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ToDos.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

    }


}
