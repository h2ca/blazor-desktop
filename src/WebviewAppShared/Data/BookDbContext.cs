using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BibliBookDesktop.Data
{
    public class BookDbContext : DbContext
    {
        #region Contructor
        public BookDbContext(DbContextOptions<BookDbContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        #region Public properties
        public DbSet<Livre> Livres { get; set; }

        #endregion

        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livre>().HasData(GetLivres());
            base.OnModelCreating(modelBuilder);
        }
        #endregion


        #region Private methods
        private List<Livre> GetLivres()
        {
            return new List<Livre>
            {
            };
        }
        #endregion
    }
}
