using TaggedWorldLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTaggedWorld.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
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
        private readonly DataContext ctx;

        /// <summary>ctor</summary>
        public UsersController(DataContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>Vraća sve korisnike. Dostupno samo ulogovanim korisnicima.</summary>
        [HttpGet, Authorize]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await ctx.Users
                //.Include(it => it.OwnedTargets)
                .Include(it => it.MemberOf).ThenInclude(it => it.Group).ToListAsync();
            return Ok(users);
        }

        /// <summary>Registracija: kreiranje novog korisnika.</summary>
        [HttpPost("register")]
        public IActionResult CreateUser(UserRegistrationReq userReq)
        {
            try
            {
                var u = ctx.Users.FirstOrDefault(it => it.Username == userReq.Username);
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
                ctx.Users.Add(newUser);
                ctx.SaveChanges();
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
            var user = await ctx.Users.FirstOrDefaultAsync(it => it.Username == userReq.Username);
            if (user == null)
                return BadRequest("User not found.");
            if (!VerifyPasswordHash(userReq.Password, user.PasswordHash, user.PasswordSalt))
                return BadRequest("Wrong password.");

            var refToken = CreateRefreshToken();
            user.RefreshToken = refToken.Token;
            user.RefreshTokenExpires = refToken.Expires;
            await ctx.SaveChangesAsync();
            SetRefreshToken(user, refToken);
            var jwt = CreateJWT(user);
            return Ok(jwt);
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
                //B Created = DateTime.Now
            };
            return refreshToken;
        }

        //todo [ValidateAntiForgeryToken]
        /// <summary>Uzimanje novog JWT-a ako je stari istekao, ali refresh token nije.</summary>
        [HttpPost("getJWT")]
        public async Task<ActionResult<string>> GetNewJWT([FromBody] string username)
        {
            var user = await ctx.Users.FirstOrDefaultAsync(it => it.Username == username);
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
            if (HttpContext.User?.Identity is not ClaimsIdentity ident)
                return Unauthorized("ClaimsIdentity not found.");

            //B
            //var claimId = ident.Claims.FirstOrDefault(it => it.Type == ClaimTypes.NameIdentifier);
            //var user = await ctx.Users.FirstOrDefaultAsync(it => claimId != null && it.Username == claimId.Value);
            var user = await ctx.Users.FirstOrDefaultAsync(it => it.UserId == ident.GetId());
            if (user == null)
                return BadRequest();

            user.RefreshTokenExpires = null;
            user.RefreshToken = null;
            await ctx.SaveChangesAsync();
            return Ok();
        }

        /// <summary>Izmena podataka o korisniku.</summary>
        [HttpPut("update")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                var u = ctx.Users.Find(user.UserId);
                if (u == null)
                    return BadRequest($"No user with Id: {user.UserId}.");
                u.Username = user.Username;
                // u.Password = user.Password;
                u.FullName = user.FullName;
                u.Email = user.Email;
                ctx.SaveChanges();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }
    }
}
