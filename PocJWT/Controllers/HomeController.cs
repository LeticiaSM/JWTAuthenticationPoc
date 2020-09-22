using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocJWT.Model;
using PocJWT.Repositories;
using PocJWT.Repositories.Interfaces;
using PocJWT.Services;

namespace PocJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //api/home/authenticated 
        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Authenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anonymous";

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User userInput)
        {
            var userModel = _userRepository.Get(userInput.UserName, userInput.Password);

            if (userModel == null)
                return NotFound(new { message = "Usuário/senha inválidos" });

            var token = TokenService.GenerateToken(userModel);

            userModel.Password = "";
            return new
            {
                user = userModel,
                token = token
            };
        }

    }
}
