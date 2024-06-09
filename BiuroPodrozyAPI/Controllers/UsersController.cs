using BiuroPodrozyApi.DTOs;
using BiuroPodrozyApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BiuroPodrozyAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BiuroPodrozyContext _context;

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UsersController(BiuroPodrozyContext context, UserManager<User> userManager,
            IConfiguration configuration, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public async Task<ActionResult<Boolean>> RegisterUser(RegisterModelDTO user)
        {
            var newUser = new User
            {
                UserName = user.UserName,
                Email = user.Email
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                return Ok(true);
            }
            return Ok(false);
        }


        [AllowAnonymous]
        [HttpPost("AuthenticateUser")]
        public async Task<ActionResult<LoginResponse>> AuthenticateUser(LoginModelDTO user)
        {
            var foundUser = await _userManager.FindByEmailAsync(user.Email) ?? null;
            if (foundUser == null) return Unauthorized();

            if (await _userManager.CheckPasswordAsync(foundUser, user.Password))
            {
                string accessToken = GenerateAccessToken(foundUser);
                foundUser.RefreshToken = GenerateRefreshToken();
                await _userManager.UpdateAsync(foundUser);
                return Ok(new LoginResponse { AccessToken = accessToken, RefreshToken = foundUser.RefreshToken });
            }
            else
            {
                return Ok(new LoginResponse { AccessToken = null, RefreshToken = null });
            }
        }

        private string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var keyDetail = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"],
                Expires = DateTime.UtcNow.AddMinutes(30),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyDetail), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

    }
}
