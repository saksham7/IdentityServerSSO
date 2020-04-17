using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IdentityModel.Client;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WebApp1.Controllers
{
    [ApiController]
    [Route("Account")]
    public class AccountController: ControllerBase
    {
        [HttpGet]
        [Route("GetToken")]
        public async Task<IActionResult> GetToken()
        {
            var client = new HttpClient();
            var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "http://localhost:5000/connect/token",
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });
            return Ok(response.AccessToken);
        }
    }
}