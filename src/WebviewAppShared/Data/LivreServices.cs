using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliBookDesktop.Data
{
    public class LivreServices
    {
        #region Private members
        private BookDbContext dbContext;
        #endregion

        #region Constructor
        public LivreServices(BookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// This method returns the list of books
        /// </summary>
        /// <returns></returns>
        public async Task<List<Livre>> GetLivreAsync()
        {
            bool hasData = dbContext.Livres.Any();
            if (hasData)
            {
                // entity exists in database
                var livres = await dbContext.Livres.AsNoTracking().ToListAsync();
                return livres;
            }
            else
            {
                // nope, not exists in database
                return null;
            }
        }

        /// <summary>
        /// This method returns the book
        /// </summary>
        /// <returns></returns>
        public async Task<Livre> GetLivreByIdAsync(long id)
        {
            if (!dbContext.Livres.Any())
            {
                return null;
            }

            bool hasData = dbContext.Livres.Any(s => s.Id == id);
            if (hasData)
            {
                // entity exists in database
                var livres = await dbContext.Livres.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();
                return livres;
            }
            else
            {
                // nope, not exists in database
                return null;
            }

        }

        /// <summary>
        /// This method add a new livre to the DbContext and saves it
        /// </summary>
        /// <param name="livre"></param>
        /// <returns></returns>
        public async Task<Livre> AddLivreAsync(Livre livre)
        {
            try
            {
                var lastLivre = dbContext.Livres
                                       .AsNoTracking()
                                       .OrderByDescending(p => p.Id)
                                       .FirstOrDefault();

                if (lastLivre != null && lastLivre.Id > 0)
                {
                    livre.Id = lastLivre.Id + 1;
                }
                else
                {
                    livre.Id = 10000001;
                }

                dbContext.Livres.Add(livre);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return livre;
        }

        /// <summary>
        /// This method update and existing livre and saves the changes
        /// </summary>
        /// <param name="livre"></param>
        /// <returns></returns>
        public async Task<Livre> UpdateLivreAsync(Livre livre)
        {
            try
            {
                var livreExist = dbContext.Livres.AsNoTracking().FirstOrDefault(p => p.Id == livre.Id);
                if (livreExist != null)
                {
                    dbContext.Livres.Update(livre);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception Ex)
            {
                throw;
            }
            return livre;
        }

        /// <summary>
        /// This method removes and existing livre from the DbContext and saves it
        /// </summary>
        /// <param name="livre"></param>
        /// <returns></returns>
        public async Task DeleteLivreAsync(Livre livre)
        {
            try
            {
                dbContext.Livres.Remove(livre);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
