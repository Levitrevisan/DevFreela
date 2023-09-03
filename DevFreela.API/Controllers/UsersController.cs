using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userService) { 
            _userServices = userService;
        }

        // api/users/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userServices.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }

        // api/users
        [HttpPost]
        public IActionResult Post([FromBody] NewUserInputModel newUser)
        {
            if (newUser.Fullname.Length > 50)
            {
                return BadRequest("Tamanho maior do que o permitido");
            }

            var id = _userServices.CreateUser(newUser);

            return CreatedAtAction(nameof(GetById), new { id = id }, newUser);
        }

        // api/users/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            // user login

            return NoContent();
        }

    }
}
