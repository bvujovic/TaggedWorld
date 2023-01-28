using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            ControllerExtension.Db = this.db = db;
        }

        /// <summary>Dohvatanje deljenih targeta u grupi.</summary>
        [HttpGet, Authorize]
        public async Task<ActionResult<List<TargetDto>>> GetGroupSharedTargets(int groupId)
        {
            // provera: da li grupa postoji i TODO: da li je ulogovani korisnik clan grupe
            var g = await db.Group.FindAsync(groupId);
            if (g == null)
                return NotFound($"Group id:{groupId} not found.");
            var userId = this.GetUserId();
            var targetIDs = await db.Sharing.Where(it => it.GroupId == groupId && it.UserId != userId)
                .Select(it => it.TargetId).ToListAsync();
            var targets = await db.Targets.Where(it => targetIDs.Contains(it.TargetId))
                .Select(it => new TargetDto
                {
                    TargetId = it.TargetId,
                    Content = it.Content,
                    StrTags = it.StrTags,
                    CreatedDate = it.CreatedDate,
                    OwnerId = it.UserOwnerId,
                }).ToListAsync();

            //B
            //var res = await db.Targets.Include(t => t.Sharings.Where(s => s.GroupId== groupId)).ToListAsync();
            //var r2 = await db.Sharing.Where(sh => sh.GroupId == groupId)
            //    .Join(db.Targets, sh => sh.TargetId, t => t.TargetId, (sh, t) => t.Content).ToListAsync();

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
                var userId = this.GetUserId();
                var cnt = await db.Member.CountAsync(it => it.GroupId == sharing.GroupId && it.UserId == userId);
                if (cnt == 0)
                    return BadRequest($"User cannot share in group id:{sharing.GroupId}.");

                // kreiranje deljenja
                sh = new TaggedWorldLibrary.Model.Sharing
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
                var sh = await db.Sharing.FirstOrDefaultAsync
                    (it => it.GroupId == sharing.GroupId && it.TargetId == sharing.TargetId && it.UserId == this.GetUserId());
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
