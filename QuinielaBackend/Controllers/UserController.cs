using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace QuinielaBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {

            this.httpClientFactory = httpClientFactory;
        }
        //public IActionResult Get()
        //{
           

        //    //var d = await httpClient;
        //}
    }
}
