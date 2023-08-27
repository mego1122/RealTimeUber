using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RealTimeUber.DTO;
using RealTimeUber.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;

namespace RealTimeUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto registration)
        {
            var user = new ApplicationUser()
            {
               
                UserName = registration.UserName,
                Email = registration.Email,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                MobileNumber = registration.MobileNumber
            };
           // user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, registration.Password);
            var result = await _userManager.CreateAsync(user, registration.Password);

            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto req)
        {
            var user = await _userManager.FindByEmailAsync(req.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, req.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return Ok(new AuthenticatedResponse());
            
            }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(LoginDto login)
        //{

        //        var result = await _signInManager.PasswordSignInAsync(
        //        login.Email , login.Password, false, false);

        //    if (result.Succeeded)
        //    {
        //        // Return token
        //        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
        //        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        //        var tokeOptions = new JwtSecurityToken(
        //            issuer: "https://localhost:5001",
        //            audience: "https://localhost:5001",
        //            claims: new List<Claim>(),
        //            expires: DateTime.Now.AddMinutes(5),
        //            signingCredentials: signinCredentials
        //        );
        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        //        return Ok(new AuthenticatedResponse { Token = tokenString });


        //    }
        //    return Unauthorized();
        //}



        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdatePlayer(string id, [FromBody] UpdatePlayerDto dto)
        //{
        //    var user = await _userManager.FindByIdAsync(id);

        //    user.FirstName = dto.FirstName;
        //    user.LastName = dto.LastName;
        //    user.MobileNumber = dto.MobileNumber;

        //    var result = await _userManager.UpdateAsync(user);

        //    return Ok(result);



        //}



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var result = await _userManager.DeleteAsync(user);
            return Ok(result);
        }
    }
}
