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
    public class AccountController: ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetToken()
        {
            var discoveryClient = await DiscoveryClient.GetAsync("http://localhost:5000");
            if (discoveryClient.IsError)
            {
                // Console.WriteLine(discoveryClient.Error);
                return Ok(discoveryClient.Error);
            }
 
            // request the token from the Auth server
            var tokenClient = new TokenClient(discoveryClient.TokenEndpoint, "client", "secret");
            var response = await tokenClient.RequestClientCredentialsAsync("api1");
            
            if (response.IsError)
            {
                // Console.WriteLine(response.Error);
                return Ok(response.Error);
            }
            
            // Console.WriteLine(response.Json);
            return Ok(response.Json);
        }
    }
}