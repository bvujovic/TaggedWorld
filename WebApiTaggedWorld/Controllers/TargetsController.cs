using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaggedWorldLibrary.Model;
using TaggedWorldLibrary.DTOs;
using WebApiTaggedWorld.Classes;
using WebApiTaggedWorld.Data;

namespace WebApiTaggedWorld.Controllers
{
    /// <summary>Kontroler za rad sa grupama korisnika.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TargetsController : ControllerBase
    {
        private readonly DataContext db;

        /// <summary>ctor</summary>
        public TargetsController(DataContext db)
        {
            ControllerExtension.Db = this.db = db;
        }

        /// <summary>Dohvatanje targeta koji pripadaju ulogovanom korisniku.</summary>
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<TargetDto>>> GetMyTargets()
        {
            try
            {
                var userId = this.GetUserId();
                //B var targets = await db.Targets.Where(it => it.UserOwnerId == userId && !it.SharedDate.HasValue)
                var targets = await db.Targets.Where(it => it.UserOwnerId == userId && it.IsAccepted)
                    .Select(it => new TargetDto
                    {
                        TargetId = it.TargetId,
                        Content = it.Content,
                        StrTags = it.StrTags,
                        OwnerId = userId,
                        CreatedDate = it.CreatedDate,
                    }).ToListAsync();
                return Ok(targets);
            }
            catch (Exception ex) { return this.Bad(ex); }
        }

        /// <summary>Dohvatanje targeta ulogovanog korisnika koje jos nije prihvatio.</summary>
        [HttpGet("notifications"), Authorize]
        public async Task<ActionResult<IEnumerable<SharedTargetDto>>> GetMyNotifications()
        {
            //TODO mozda dodati kao opcioni parametar DateTime poslednje provere -> uzimanje samo svezih notif.
            try
            {
                var userId = this.GetUserId();
                var targets = await db.Targets.Include(it => it.UserSender).Include(it => it.SharedOnGroup).Where(it => it.UserOwnerId == userId && !it.IsAccepted)
                    .Select(it => new SharedTargetDto
                    {
                        TargetId = it.TargetId,
                        Content = it.Content,
                        StrTags = it.StrTags,
                        OwnerId = userId,
                        CreatedDate = it.CreatedDate,
                        SharedDate = it.SharedDate,
                        UserSenderId = it.UserSenderId,
                        SharedOnGroupId = it.SharedOnGroupId,
                        UserSender = it.UserSender!.FullName,
                        SharedOnGroup = it.SharedOnGroup != null ? it.SharedOnGroup.Name : null,
                    }).ToListAsync();
                return Ok(targets);
            }
            catch (Exception ex) { return this.Bad(ex); }
        }

        /// <summary>Kreiranje novog targeta.</summary>
        [HttpPost, Authorize]
        public async Task<IActionResult> Create([FromBody] TargetDtoBase target)
        {
            try
            {
                //? provera: da li vec postoji target sa datim naslovom i contentom (za link/fajl/folder!)
                var newTarget = Target.CreateTarget(target.Content, target.StrTags, DateTime.Now, await this.GetUser());
                db.Targets.Add(newTarget);
                await db.SaveChangesAsync();
                return Ok(newTarget.TargetId);
            }
            catch (Exception ex) { return this.Bad(ex); }
        }

        /// <summary>Brisanje targeta.</summary>
        [HttpDelete, Authorize]
        public async Task<IActionResult> Delete(int targetId)
        {
            try
            {
                // provera: da li target sa datim id-em postoji
                var t = await db.Targets.FindAsync(targetId);
                if (t == null)
                    return NotFound($"Target id:'{targetId}' not found.");

                //* brisanje datog targeta iz sharing-a
                //var sharings = await db.Sharing.Where(it => it.TargetId == targetId).ToListAsync();
                //db.Sharing.RemoveRange(sharings);

                db.Targets.Remove(t);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }

        /// <summary>Izmena targeta.</summary>
        [HttpPut, Authorize]
        public async Task<IActionResult> Update(int targetId, [FromBody] TargetDtoBase target)
        {
            try
            {
                var t = await db.Targets.FindAsync(targetId);
                if (t == null)
                    return NotFound($"Target id:{targetId} not found.");

                t.Content = target.Content;
                t.StrTags = target.StrTags;
                t.ModifiedDate = DateTime.Now;

                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }
    }
}
