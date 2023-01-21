using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TaggedWorldLibrary.Model;
using WebApiTaggedWorld.Classes;
using WebApiTaggedWorld.Data;
using TaggedWorldLibrary.DTOs;

namespace WebApiTaggedWorld.Controllers
{
    /// <summary>Kontroler za rad sa grupama korisnika.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly DataContext db;

        /// <summary>ctor</summary>
        public GroupsController(DataContext db)
        {
            ControllerExtension.Db = this.db = db;
        }

        /// <summary>Dohvatanje grupa kojima pripada ulogovani korisnik.</summary>
        [HttpGet, Authorize]
        public async Task<ActionResult<List<GroupDto>>> GetMyGroups()
        {
            var groups = await db.Group.Where(it => it.Members.Select(it => it.UserId).Contains(this.GetUserId()))
                .ToListAsync();
            var res = groups.Select(it => new GroupDto { GroupId = it.GroupId, Name = it.Name, StrTags = it.StrTags, Description = it.Description });
            return Ok(res);
        }

        /// <summary>Kreiranje nove grupe korisnika.</summary>
        [HttpPost, Authorize]
        public async Task<IActionResult> Create(GroupDto groupData)
        {
            try
            {
                // provera: da li vec postoji grupa sa datim imenom
                var g = await db.Group.FirstOrDefaultAsync(it => it.Name == groupData.Name);
                if (g != null)
                    return BadRequest($"Group '{groupData.Name}' already exists.");

                // kreiranje grupe
                var group = new Group
                {
                    Name = groupData.Name,
                    Description = groupData.Description,
                    StrTags = groupData.StrTags,
                    Created = DateTime.Now
                };
                db.Group.Add(group);

                // dodavanje ulogovanog korisnika u clanove grupe kao administratora
                var member = new Member
                {
                    Group = group,
                    IsAdministrator = true,
                    UserId = this.GetUserId()
                };
                db.Member.Add(member);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }

        /// <summary>Brisanje grupe korisnika.</summary>
        [HttpDelete, Authorize]
        public async Task<IActionResult> Delete(int groupId)
        {
            try
            {
                // provera: da li grupa sa datim imenom postoji
                //B var g = await db.Group.FirstOrDefaultAsync(it => it.Name == name);
                var g = await db.Group.FindAsync(groupId);
                if (g == null)
                    return BadRequest($"Group with id:'{groupId}' doesn't exist.");
                // provere: da li je broj clanova grupe 1 i da li taj poslednji korisnik admin te grupe
                var cntMembers = await db.Member.CountAsync(it => it.GroupId == g.GroupId);
                if (cntMembers > 1)
                    return BadRequest("Group has to be empty except for the person (admin) that wants to delete it.");
                var lastMember = await db.Member.FirstOrDefaultAsync(it => it.UserId == this.GetUserId());
                if (lastMember == null || !lastMember.IsAdministrator)
                    return BadRequest("You have to be an administrator of the group to be able to delete it.");

                db.Member.Remove(lastMember);
                db.Group.Remove(g);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }

        /// <summary>Izmena podataka za grupu korisnika.</summary>
        [HttpPut, Authorize]
        public async Task<IActionResult> Update([FromBody] GroupDto groupData)
        {
            try
            {
                int groupId = groupData.GroupId;
                // provera: da li grupa sa datim imenom postoji
                var g = await db.Group.FindAsync(groupId);
                if (g == null)
                    return BadRequest($"GroupId '{groupId}' doesn't exist.");

                // provere: da li je ulogovani korisnik admin te grupe
                var cnt = await db.Member.CountAsync(it => it.UserId == this.GetUserId()
                    && it.GroupId == groupId && it.IsAdministrator);
                if (cnt != 1)
                    return BadRequest("You have to be an administrator of the group to be able to update it.");

                // izmena podataka
                g.Name = groupData.Name;
                g.Description = groupData.Description;
                g.StrTags = groupData.StrTags;
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return this.Bad(ex); }
        }
    }
}
