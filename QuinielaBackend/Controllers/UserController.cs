using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuinielaBackend.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using QuinielaBackend.Managers;
using System.Web.Http.Cors;
using QuinielaBackend.Models;

namespace QuinielaBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region DI
        private DbContextQuiniela _DbContext;

        public UserController(DbContextQuiniela dbContext)
        {
            _DbContext = dbContext;
        }
        #endregion

        [HttpPost]
        public async Task<Users> Get(String username)
        {
            var data = await new UserManager(_DbContext).GetUserByUserName(username);
            //var d = await httpClient;
            return data;
        }


        [HttpPost]
        public async Task<bool> LoginUser(String userName, String password)
        {
            bool record= await new UserManager(_DbContext).UserRecord(userName, password);
            return record;
        }

        [HttpPost]
        public async Task<bool> AddNewUser(CreateNewUser model)
        {
            if (ModelState.IsValid)
            {
                var userManager = new UserManager(_DbContext);
                await userManager.AddNueUser(model);
            }
            return true;
        }

    }
}