using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaggedWorldLibrary;
using WebApiTaggedWorld.Classes;
using WebApiTaggedWorld.Data;
using Microsoft.EntityFrameworkCore;
using TaggedWorldLibrary.DTOs;

namespace WebApiTaggedWorld.Controllers
{
    /// <summary>
    /// Kontroler za rad sa daljenjem targeta u grupama.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SharingsController : ControllerBase
    {
        private readonly DataContext db;

        /// <summary>ctor</summary>
        public SharingsController(DataContext db)
        {
            this.db = db;
        }

        /// <summary>Dohvatanje deljenih targeta u grupi.</summary>
        [HttpGet, Authorize]
        public async Task<ActionResult<List<TargetDto>>> GetGroupSharedTargets(int groupId)
        {
            // provera: da li grupa postoji i TODO: da li je ulogovani korisnik clan grupe
            var g = await db.Group.FindAsync(groupId);
            if (g == null)
                return NotFound($"Group id:{groupId} not found.");
            if (HttpContext.User?.Identity is not ClaimsIdentity ident)
                return Unauthorized("ClaimsIdentity not found.");
            var ownerId = ident.GetId();
            var targetIDs = await db.Sharing.Where(it => it.GroupId == groupId).Select(it => it.TargetId).ToListAsync();
            var targets = await db.Targets.Where(it => targetIDs.Contains(it.TargetId))
                .Select(it => new TargetDto
                {
                    TargetId = it.TargetId,
                    Title = it.Title,
                    Type = it.Type,
                    Content = it.Content,
                    StrTags = it.StrTags,
                    CreatedDate = it.CreatedDate,
                    OwnerId = it.UserOwnerId,
                }).ToListAsync();
            return Ok(targets);
        }

        /// <summary>Kreiranje novog deljenja.</summary>
        [HttpPost, Authorize]
        public async Task<IActionResult> Create([FromBody] SharingDto sharing)
        {
            try
            {
                // provera: da li deljenje vec postoji
                var sh = await db.Sharing.FindAsync(sharing.GroupId, sharing.TargetId);
                if (sh != null)
                    return BadRequest($"Sharing group id:'{sharing.GroupId}' - target id:{sharing.TargetId} already exists.");
                if (HttpContext.User?.Identity is not ClaimsIdentity ident)
                    return Unauthorized("ClaimsIdentity not found.");
                var userId = ident.GetId();
                var cnt = await db.Member.CountAsync(it => it.GroupId == sharing.GroupId && it.UserId == userId);
                if (cnt == 0)
                    return BadRequest($"User cannot share in group id:{sharing.GroupId}.");

                // kreiranje deljenja
                sh = new Sharing
                {
                    GroupId = sharing.GroupId,
                    TargetId = sharing.TargetId,
                    UserId = userId,
                    SharedDate = DateTime.Now,
                };
                db.Sharing.Add(sh);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE constraint"))
                    return BadRequest("Target is already shared in the group.");
                if (ex.Message.Contains("'Sharing.TargetId' is unknown"))
                    return NotFound($"Target id:{sharing.TargetId} is not found.");
                return this.Bad(ex);
            }
        }

        /// <summary>Brisanje deljenja.</summary>
        [HttpDelete, Authorize]
        public async Task<IActionResult> Delete([FromBody] SharingDto sharing)
        {
            try
            {
                // provera: 
                if (HttpContext.User?.Identity is not ClaimsIdentity ident)
                    return Unauthorized("ClaimsIdentity not found.");
                var userId = ident.GetId();
                var sh = await db.Sharing.FirstOrDefaultAsync
                    (it => it.GroupId == sharing.GroupId && it.TargetId == sharing.TargetId && it.UserId == userId);
                if (sh == null)
                    return BadRequest("User cannot delete this sharing.");

                db.Sharing.Remove(sh);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }
    }
}
