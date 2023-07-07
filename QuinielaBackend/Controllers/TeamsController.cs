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
    public class TeamsController : ControllerBase
    {
        #region DI
        private DbContextQuiniela _DbContext;

        public TeamsController(DbContextQuiniela dbContext)
        {
            _DbContext= dbContext;
        }
        #endregion


        // GET: api/<GameController>
        [HttpPost]
        public async Task<bool> AddNewTeam(CreateNewTeam model)
                    {
            Teams teamsData = new CreateNewTeam().CreateNewTeamVM(model);
            bool succes=  await new TeamsManager(_DbContext).AddNewTeam(teamsData);
            
            return succes;
        }



        // POST api/<GameController>
        [HttpGet]
        public async Task<IEnumerable<Teams>> GetTeams()
        {
            IEnumerable<Teams> teams = await new TeamsManager(_DbContext).GetTeams();
            return teams;
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
