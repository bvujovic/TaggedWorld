using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaggedWorldLibrary;
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
            this.db = db;
        }

        /// <summary>Dohvatanje targeta koji pripadaju ulogovanom korisniku.</summary>
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<TargetDto>>> GetMyTargets()
        {
            try
            {
                if (HttpContext.User?.Identity is not ClaimsIdentity ident)
                    return Unauthorized("ClaimsIdentity not found.");
                var ownerId = ident.GetId();
                var targets = await db.Targets.Where(it => it.UserOwnerId == ownerId)
                    .Select(it => new TargetDto
                    {
                        TargetId = it.TargetId,
                        Title = it.Title,
                        Type = it.Type,
                        Content = it.Content,
                        StrTags = it.StrTags,
                        OwnerId = ownerId,
                        CreatedDate = it.CreatedDate,
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
                if (HttpContext.User?.Identity is not ClaimsIdentity ident)
                    return Unauthorized("ClaimsIdentity not found.");
                var ownerId = ident.GetId();
                var owner = await db.Users.FindAsync(ownerId);
                //? provera: da li vec postoji target sa datim naslovom i contentom (za link/fajl/folder!)
                var newTarget = Target.CreateTarget(target.Title, target.Type, target.Content
                        , target.StrTags, DateTime.Now, owner);
                db.Targets.Add(newTarget);
                await db.SaveChangesAsync();
                return Ok();
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

                // brisanje datog targeta iz sharing-a
                var sharings = await db.Sharing.Where(it => it.TargetId == targetId).ToListAsync();
                db.Sharing.RemoveRange(sharings);

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
                if (HttpContext.User?.Identity is not ClaimsIdentity ident)
                    return Unauthorized("ClaimsIdentity not found.");
                var ownerId = ident.GetId();
                //? var owner = await db.Users.FindAsync(ownerId);

                var t = await db.Targets.FindAsync(targetId);
                if (t == null)
                    return NotFound($"Target id:{targetId} not found.");

                t.Title = target.Title;
                t.Type = target.Type;
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
