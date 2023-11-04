using BLL.DTOs;
using BLL.Services;
using DAL.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json.Nodes;

namespace Employee_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthSevice _eservice;
        private readonly IConfiguration _configuration;
        public AuthController(AuthSevice ndb, IConfiguration configuration)
        {
            this._eservice = ndb;
            this._configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Register (UserDto user)
        {
            CreatePasswordHash(user.Password!, out byte[] passwordHash, out byte[] passwordSalt);

            _eservice.CreateAuthSevice(user, passwordHash, passwordSalt);

            return Ok();
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(UserDto user)
        {
            var registerDetails = _eservice.getDetails(user);
            var verify = VerifyPassword(user.Password!, registerDetails.PasswordHash!, registerDetails.PasswordSalt!);
            
            if(registerDetails.UserName == user.UserName && verify)
            {
                string res = CreateToken(user);
                dynamic token = JsonConvert.SerializeObject(res) ;
                return Ok(token);
            }
            
            return BadRequest("UserName or the password does not match");
        }

        private string CreateToken(UserDto user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                //new Claim(ClaimTypes.Role, "Admin")
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims:claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac =  new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash,byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =  hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes (password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
