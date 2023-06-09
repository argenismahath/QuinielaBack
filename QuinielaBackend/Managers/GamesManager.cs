﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuinielaBackend.Models;
using QuinielaBackend.ViewModels;

namespace QuinielaBackend.Managers
{
    public class GamesManager
    {
        #region DI
        private DbContextQuiniela _DbContext;

        public GamesManager(DbContextQuiniela dbContext)
        {
            _DbContext = dbContext;
        }
        #endregion

        public async Task<bool> AddNewGame(Games model)
        {
            await _DbContext.Games.AddAsync(model);
            await _DbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GetGameVM>> GetGamesByJorneys(int id, int userId)
        {
            IEnumerable<Games> dataGames = await _DbContext.Games
                .Where(g => g.JourneyNumber == id)
                .ToListAsync();

            IEnumerable<GetGameVM> getGameVMs = new List<GetGameVM>();

            foreach (var game in dataGames)
            {
                var img1 = await _DbContext.Teams
                        .Where(r => r.Id == game.TeamId1)
                        .Select(r => new { r.Img, r.Name })
                        .FirstOrDefaultAsync();

                var img2 = await _DbContext.Teams
                    .Where(r => r.Id == game.TeamId2)
                    .Select(r => new { r.Img, r.Name } )
                    .FirstOrDefaultAsync();

                var query = (from Users in _DbContext.Users
                             join RecordTables in _DbContext.RecordTables on Users.Id equals RecordTables.Id
                             where Users.Id == userId && RecordTables.Games.Id == game.Id
                             select new
                             {
                                 Propiedad1 = RecordTables.PublicKey,
                                 Propiedad2 = Users.Id,
                                 propiedad3 = RecordTables.PredictTeam1,
                             }).FirstOrDefault();

                GetGameVM gameVM = new GetGameVM();
                if (game != null)
                {
                    gameVM.GameTitle = game.GameTitle;
                    gameVM.StartHour = game.StartHour;
                    gameVM.Lock = game.Lock;
                    gameVM.TeamId1 = game.TeamId1;
                    gameVM.TeamId2 = game.TeamId2;
                    gameVM.Points= query?.propiedad3 ?? 0;
                    gameVM.img1 = img1.Img;
                    gameVM.img2 = img2.Img;
                    gameVM.ScoreTeam1 = game.ScoreTeam1;
                    gameVM.ScoreTeam2 = game.ScoreTeam2;
                    gameVM.Points = 0;
                    gameVM.Link = game.Link;
                    gameVM.Name1 = img1.Name;
                    gameVM.Name2 = img2.Name;
                }
                // Aquí debes proporcionar el código específico para asignar los valores adecuados
                getGameVMs = getGameVMs.Append(gameVM);
            };

            return getGameVMs;
        }

        public async Task<IEnumerable<Games>> GetLinkJorney()
        {
            var registrosSeleccionados = _DbContext.Games
                .Where(g=>g.Link!=null)
                  .GroupBy(r=> r.Link) // Agrupamos por el campo JorneyNumber
                  .Select(grupo=>grupo.FirstOrDefault());
            return registrosSeleccionados;
        }
    }
}
