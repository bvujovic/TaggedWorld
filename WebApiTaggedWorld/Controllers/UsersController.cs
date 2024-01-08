using TaggedWorldLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using WebApiTaggedWorld.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using WebApiTaggedWorld.Classes;
using TaggedWorldLibrary.DTOs;

namespace WebApiTaggedWorld.Controllers
{
    /// <summary>Kontroler za rad sa korisničkim podacima.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext db;

        /// <summary>ctor</summary>
        public UsersController(DataContext db)
        {
            ControllerExtension.Db = this.db = db;
        }

        /// <summary>Registracija: kreiranje novog korisnika.</summary>
        [HttpPost("register")]
        public IActionResult CreateUser(UserRegistrationReq userReq)
        {
            try
            {
                var u = db.Users.FirstOrDefault(it => it.Username == userReq.Username);
                if (u != null)
                    return BadRequest("username already exists");

                CreatePasswordHash(userReq.Password, out var passHash, out var passSalt);
                var newUser = new User
                {
                    Username = userReq.Username,
                    PasswordHash = passHash,
                    PasswordSalt = passSalt,
                    Email = userReq.Email,
                    FullName = userReq.FullName,
                    IsActive = true,
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }

        /// <summary>Prijava na sistem za korisnike.</summary>
        /// <param name="userReq">username i password</param>
        /// <returns>JWT. Ref. token se postavlja kao cookie.</returns>
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginReq userReq)
        {
            var user = await db.Users.FirstOrDefaultAsync(it => it.Username == userReq.Username);
            if (user == null)
                return BadRequest("User not found.");
            if (!VerifyPasswordHash(userReq.Password, user.PasswordHash, user.PasswordSalt))
                return BadRequest("Wrong password.");

            var refToken = CreateRefreshToken();
            user.RefreshToken = refToken.Token;
            user.RefreshTokenExpires = refToken.Expires;
            await db.SaveChangesAsync();
            SetRefreshToken(user, refToken);
            var jwt = CreateJWT(user);
            return Ok(jwt);
        }

        /// <summary>Dohvatanje osnovnih podataka o ulogovanom korisniku.</summary>
        [HttpGet("userDto"), Authorize]
        public async Task<ActionResult<UserDto>> UserDto()
        {
            var user = await this.GetUser();
            var dto = new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
            };
            return Ok(dto);
        }

        private void SetRefreshToken(User user, RefreshToken refToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refToken.Expires
            };
            Response.Cookies.Append("refreshToken", refToken.Token, cookieOptions);
            user.RefreshToken = refToken.Token;
            //B user.TokenCreated = newRefreshToken.Created;
            user.RefreshTokenExpires = refToken.Expires;
        }

        private static RefreshToken CreateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddHours(2),
            };
            return refreshToken;
        }

        //todo [ValidateAntiForgeryToken]
        /// <summary>Uzimanje novog JWT-a ako je stari istekao, ali refresh token nije.</summary>
        [HttpPost("getJWT")]
        public async Task<ActionResult<string>> GetNewJWT([FromBody] string username)
        {
            var user = await db.Users.FirstOrDefaultAsync(it => it.Username == username);
            if (user != null)
            {
                var refreshToken = Request.Cookies["refreshToken"];
                if (user.RefreshTokenExpires.HasValue && DateTime.Now < user.RefreshTokenExpires
                    && user.RefreshToken == refreshToken)
                    return Ok(CreateJWT(user));
            }
            return Unauthorized("Refresh token not accepted.");
        }

        private static string CreateJWT(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimType.Id, user.UserId.ToString()),
                //B
                //new Claim(ClaimTypes.NameIdentifier, user.Username),
                //new Claim(ClaimTypes.Name, user.FullName),
                //new Claim(ClaimTypes.Email, user.Email),
                //new Claim(ClaimTypes.Role, "User"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JwtKeySomethingWeirdReally123"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                issuer: "JwtIssuer",
                audience: "JwtAudience",
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        /// <summary>Odjava korisnika sa sistema.</summary>
        [HttpPost("logout"), Authorize]
        public async Task<IActionResult> Logout()
        {
            var user = await this.GetUser();
            user.RefreshTokenExpires = null;
            user.RefreshToken = null;
            await db.SaveChangesAsync();
            return Ok();
        }

        /// <summary>Izmena podataka o korisniku.</summary>
        [HttpPut("update"), Authorize]
        public async Task<IActionResult> UpdateUser(UserDto user)
        {
            try
            {
                var u = await this.GetUser();
                //u.Username = user.Username;
                //u.Email = user.Email;
                //* za sada moze da se izmeni samo FullName, dok Username i Email prave problem jer su UNIQUE
                u.FullName = user.FullName;
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }
    }
}
