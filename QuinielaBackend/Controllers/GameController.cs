using Microsoft.AspNetCore.Mvc;
using QuinielaBackend.Managers;
using QuinielaBackend.Models;
using QuinielaBackend.ViewModels;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuinielaBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        #region DI
        private DbContextQuiniela _DbContext;

        public GameController(DbContextQuiniela dbContext)
        {
            _DbContext = dbContext;
        }
        #endregion


        // GET: api/<GameController>
        [HttpGet]
        public IEnumerable<WeekTable> GetWeekTable()
        {
            IEnumerable<WeekTable> weekTableEnumerable = new List<WeekTable>
                {
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 1", Points = 10 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 2", Points = 5 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 3", Points = 8 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 4", Points = 12 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 5", Points = 7 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 6", Points = 9 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 7", Points = 6 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 8", Points = 11 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 9", Points = 4 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 10", Points = 8 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 11", Points = 14 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 12", Points = 3 },
                    new WeekTable { Id = Guid.NewGuid(), Name = "Registro 13", Points = 7 }
                };


            return weekTableEnumerable.OrderByDescending(wt => wt.Points); ;
        }

        // GET api/<GameController>/5
        [HttpGet]
        public IEnumerable<JourneyTable> GetJourneys()
        {
            IEnumerable<JourneyTable> JourneyTableEnumerable = new List<JourneyTable>
            {
                    new JourneyTable { Id = Guid.NewGuid(), Name = "Registro 1", number = 1 },
                    new JourneyTable { Id = Guid.NewGuid(), Name = "Registro 2", number = 2 },
                    new JourneyTable { Id = Guid.NewGuid(), Name = "Registro 3", number = 3 },
            };

            return JourneyTableEnumerable.OrderByDescending(Jt => Jt.number);

        }

        // POST api/<GameController>
        [HttpPost]
        public async Task<bool> AddnewGame(CreateNewGame model)
        {
            var gameData = new CreateNewGame().CreateNewGameVM(model);
            var succes = await new GamesManager(_DbContext).AddNewGame(gameData);
            return succes;
        }

        [HttpGet]
        public async Task<IEnumerable<GetGameVM>> GetGamesByJorneys(int id, int userId)
        {
            IEnumerable<GetGameVM> games = await new GamesManager(_DbContext).GetGamesByJorneys(id, userId);
            return games;
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
