using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaggedWorldLibrary;
using WebApiTaggedWorld.Classes;
using WebApiTaggedWorld.Data.DTOs;
using WebApiTaggedWorld.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApiTaggedWorld.Controllers
{
    /// <summary>
    /// Kontroler za rad sa pripadnosti korisnika grupama.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly DataContext db;

        /// <summary>ctor</summary>
        public MembersController(DataContext db)
        {
            this.db = db;
        }

        /// <summary>Dohvatanje clanova grupe.</summary>
        [HttpGet, Authorize]
        public async Task<ActionResult<List<UserDto>>> GetGroupMembers(int groupId)
        {
            var members = await db.Member.Where(it => it.GroupId == groupId).Select(it => it.UserId)
                .ToListAsync();
            var users = await db.Users.Where(it => it.IsActive && members.Contains(it.UserId))
                .ToListAsync();
            var pubUsers = users.Select(it => new UserDto
            {
                UserId = it.UserId,
                Username = it.Username,
                Email = it.Email,
                FullName = it.FullName,
            });
            return Ok(pubUsers);
        }

        /// <summary>Dodavanje clana u grupu korisnika.</summary>
        [HttpPost, Authorize]
        public async Task<IActionResult> AddMember(int groupId, int userId)
        {
            try
            {
                var member = new Member
                {
                    GroupId = groupId,
                    UserId = userId,
                    IsAdministrator = false,
                };
                db.Member.Add(member);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }

        /// <summary>Brisanje clana iz grupe korisnika.</summary>
        [HttpDelete, Authorize]
        public async Task<IActionResult> DeleteMember(int groupId, int userId)
        {
            try
            {
                var member = await db.Member.FirstOrDefaultAsync(it => it.GroupId == groupId && it.UserId == userId);
                if (member == null)
                    return NotFound("Member not found.");
                db.Member.Remove(member);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }
    }
}
