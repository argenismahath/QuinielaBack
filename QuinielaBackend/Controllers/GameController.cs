using Microsoft.AspNetCore.Mvc;
using QuinielaBackend.ViewModels;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuinielaBackend.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        #region DI
        private DbContextQuiniela _DbContext;

        public GameController(DbContextQuiniela dbContext)
        {
            _DbContext= dbContext;
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


            return weekTableEnumerable;
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GameController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
