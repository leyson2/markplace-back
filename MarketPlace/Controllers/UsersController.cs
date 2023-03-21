using DTOs;
using MarketPlace.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IConfiguration _configuration;
        readonly IUserRepository _user;
        private IEnumerable<UserDTOView> datos;
        public UsersController(IUserRepository user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;


        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
    
            try
            {
                this.datos = _user.GetAll();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(datos);
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserLoginDTO userLogin)
        {
            userLogin.Password = Encrypt.GetSHA256(userLogin.Password);

           bool respuesta = _user.login(userLogin);
            if (!respuesta)
            {
                return BadRequest();
            }

           var token = CreateToken.GenerateToken(userLogin.UserName, _configuration);
       
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken((SecurityToken)token)}) ;
        }




        [HttpPost]
        [Route("Registro")]
        public async Task<ActionResult> Registrar(RegisterDTOCreate register)
        {

            try { 
            register.Password = Encrypt.GetSHA256(register.Password);
             _user.Register(register);
            }
            catch(Exception e)
            {

                return BadRequest(e);
            }
            return Ok(new { men = "creado con exito" });
        }


        [HttpGet("{username}")]
 
        public async Task<ActionResult<UserDTOView>> GetUser([FromRoute] string username)
        {

            try
            {
                var data = await _user.GetUserName(username);

                return Ok(data);

            }
            catch (Exception e)
            {
                return BadRequest(e);

            }


        }


    }
}
