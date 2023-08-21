using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTaggedWorld.Classes;
using WebApiTaggedWorld.Data;
using Microsoft.EntityFrameworkCore;
using TaggedWorldLibrary.DTOs;
using System.Runtime.Serialization;
using TaggedWorldLibrary.Model;

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

        /// <summary>Dohvatanje deljenih targeta za korisnika.</summary>
        [HttpGet, Authorize]
        public async Task<ActionResult<List<SharedTargetDto>>> GetSharedTargets()
        {
            var userId = this.GetUserId();
            var targets = await db.Targets.Where(it => it.UserOwnerId == userId && it.SharedDate.HasValue)
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
                }).ToListAsync();
            return Ok(targets);
        }

        /// <summary>Korisnik prihvata deljeni target sa datim id-em.</summary>
        // Patch objasnjenje: https://stackoverflow.com/questions/107390/whats-the-difference-between-a-post-and-a-put-http-request
        [HttpPatch("accept"), Authorize]
        public async Task<IActionResult> AcceptTarget(int targetId)
        {
            try
            {
                var t = await db.Targets.FindAsync(targetId);
                if (t == null)
                    return NotFound($"Target id:{targetId} not found.");
                t.IsAccepted = true;
                t.ModifiedDate = DateTime.Now;
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }

        /// <summary>Kreiranje novog deljenja.</summary>
        [HttpPost, Authorize]
        public async Task<IActionResult> Create([FromBody] SharingDto sharing)
        {
            try
            {
                var senderId = this.GetUserId();
                var t = await db.Targets.FindAsync(sharing.TargetId);
                if (t == null)
                    return NotFound($"Target with id: {sharing.TargetId} is not found.");

                if (sharing.ReceiveUserId.HasValue) // slanje targeta pojedincu
                {
                    var receiver = await db.Users.FindAsync(sharing.ReceiveUserId);
                    if (receiver == null)
                        return NotFound($"User with id: {sharing.ReceiveUserId} is not found.");
                    var newTarget = Target.CreateTarget(t.Content, t.StrTags, DateTime.Now, receiver);
                    newTarget.UserSenderId = senderId;
                    newTarget.SharedDate = DateTime.Now;
                    newTarget.IsAccepted = false;
                    db.Targets.Add(newTarget);
                }
                else // slanje targeta grupi
                {
                    // da li je korisnik clan grupe
                    var isMember = await db.Member.AnyAsync(it => it.GroupId == sharing.ReceiveGroupId && it.UserId == senderId);
                    if (!isMember)
                        return BadRequest($"User cannot share in group id: {sharing.ReceiveGroupId}.");

                    var receiverIDs = await db.Member
                        .Where(it => it.GroupId == sharing.ReceiveGroupId && it.UserId != senderId)
                        .Select(it => it.UserId).ToListAsync();
                    var newTargets = new List<Target>();
                    foreach (var receiverId in receiverIDs)
                        newTargets.Add(new Target
                        {
                            Content = t.Content,
                            StrTags = t.StrTags,
                            UserOwnerId = receiverId,
                            UserAccessedId = receiverId,
                            UserModifiedId = receiverId,
                            UserSenderId = senderId,
                            SharedOnGroupId = sharing.ReceiveGroupId,
                            CreatedDate = DateTime.Now,
                            AccessedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            SharedDate = DateTime.Now,
                            IsAccepted = false,
                        });
                    if (newTargets.Any())
                        db.Targets.AddRange(newTargets);
                }
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                //if (ex.Message.Contains("UNIQUE constraint"))
                //    return BadRequest("Target is already shared in the group.");
                //if (ex.Message.Contains("'Sharing.TargetId' is unknown"))
                //    return NotFound($"Target id:{sharing.TargetId} is not found.");
                return this.Bad(ex);
            }
        }
    }
}
