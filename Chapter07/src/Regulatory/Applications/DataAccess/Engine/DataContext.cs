using Applications.Model;
using Microsoft.EntityFrameworkCore;

namespace Applications.DataAccess.Engine
{
    /// <summary>
    /// Primary Data Container
    /// </summary>
    public class DataContext : DbContext
    {
        #region Entities representing Database Objects
        public DbSet<DocumentValidity> DOCUMENT_VALIDITY { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseSqlite(@"Filename=C:\SOA_Sample.db"); //TODO: Make the path relative - adjust it according to your download location
        }
    }
}
