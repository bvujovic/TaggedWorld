using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorldLibrary.DTOs;
using TaggedWorldLibrary.Model;
using static WinAppTaggedWorld.Data.WebApi;

namespace WinAppTaggedWorld.Data
{
    public class DataGetter
    {
        public static async Task UserLoginAsync(UserLoginReq req)
        {
            var body = JsonConvert.SerializeObject(req);
            Token = await PostForJson(ReqEnum.Users_login, body);
        }

        public static async Task UserLogoutAsync()
        {
            await PostForJson(ReqEnum.Users_logout, "");
        }

        public static async Task UserRegisterAsync(UserRegistrationReq req)
        {
            var body = JsonConvert.SerializeObject(req);
            await PostForJson(ReqEnum.Users_register, body);
        }

        public static async Task<IEnumerable<TargetDto>?> GetTargetsAsync()
        {
            return await GetList<TargetDto>(ReqEnum.Targets);
        }

        private static string TargetToDtoJson(Target t)
            => JsonConvert.SerializeObject(new TargetDtoBase
            {
                Content = t.Content,
                StrTags = TaggedWorldLibrary.Utils.Tags.JoinTags(t.Tags),
            });

        public static async Task CreateTarget(Target target)
        {
            var id = await PostForJson(ReqEnum.Targets, TargetToDtoJson(target));
            target.TargetId = int.Parse(id);
        }

        public static async Task DeleteTarget(int targetId)
        {
            await Delete(ReqEnum.Targets_Id, targetId);
        }

        public static async Task UpdateTarget(Target target)
        {
            await ReqForJson(HttpVerb.Put, ReqEnum.Targets_Id
                , TargetToDtoJson(target), target.TargetId.ToString());
        }

        //TODO videti da li je ovaj metod zaista neophodan
        public static async Task<IEnumerable<SharedTarget>?> GetSharedTargetsAsync()
        {
            return await GetList<SharedTarget>(ReqEnum.TargetsShared);
        }

        public static async Task<IEnumerable<VM.GroupVM>?> GetGroupsAsync()
        {
            return await GetList<VM.GroupVM>(ReqEnum.Groups_All);
        }

        public static async Task<IEnumerable<UserDto>?> GetMembersAsync(int groupId)
        {
            return await GetList<UserDto>(ReqEnum.Members, groupId.ToString());
        }

        public static async Task SendTarget(SharingDto sharingDto)
        {
            var json = JsonConvert.SerializeObject(sharingDto);
            await PostForJson(ReqEnum.TargetsShared, json);
        }

        public static async Task MemberJoin(MemberDto member)
        {
            var json = JsonConvert.SerializeObject(member);
            await PostForJson(ReqEnum.MemberJoin, json);
        }

        public static async Task MemberLeave(int groupId, int userId)
        {
            await ReqForJson(HttpVerb.Delete, ReqEnum.MemberLeave, "", $"groupId={groupId}&userId={userId}");
        }

        public static async Task<IEnumerable<SharedTargetDto>?> GetNotifications()
        {
            return await GetList<SharedTargetDto>(ReqEnum.TargetsNotif);
        }

        public static async Task TargetAccept(int targetId)
        {
            await ReqForJson(HttpVerb.Patch, ReqEnum.TargetsAccept, "", targetId.ToString());
        }
    }
}
