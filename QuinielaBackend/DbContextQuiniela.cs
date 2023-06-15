using Microsoft.EntityFrameworkCore;
using QuinielaBackend.Models;

namespace QuinielaBackend
{
    public class DbContextQuiniela: DbContext
    {
        public DbContextQuiniela(DbContextOptions<DbContextQuiniela> options)
            : base(options)
        {

        }

        public DbSet<Games> Games { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<RecordTable> RecordTables { get; set; }

    }
}
