using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Engine
{
    public class DataContext : DbContext
    {
        #region Entities representing Database Objects
        public DbSet<DOC_TYPE> DOC_TYPE { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseSqlite(@"Filename=C:\SOA_Sample.db"); //TODO: Make the path relative - adjust it according to your download location
        }
    }
}
