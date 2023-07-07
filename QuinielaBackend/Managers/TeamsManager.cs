using Microsoft.EntityFrameworkCore;
using QuinielaBackend.Models;
using QuinielaBackend.ViewModels;

namespace QuinielaBackend.Managers
{
    public class TeamsManager
    {
        #region DI
        private DbContextQuiniela _DbContext;

        public TeamsManager(DbContextQuiniela dbContext)
        {
            _DbContext = dbContext;
        }
        #endregion

        public async Task<bool> AddNewTeam(Teams model)
        {
            await _DbContext.Teams.AddAsync(model);
            await _DbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Teams>> GetTeams()
        {
            IEnumerable<Teams> teams= await _DbContext.Teams
                .Where(t=>t.Lock==false)
                .ToListAsync();

            return teams;
        }
    }
}
