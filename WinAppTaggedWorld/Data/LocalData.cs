using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorldLibrary.DTOs;
using TaggedWorldLibrary.Model;

namespace WinAppTaggedWorld.Data
{
    public class LocalData
    {
        private readonly List<Target> targets = new();
        public IEnumerable<Target> Targets => targets;

        private readonly HashSet<string> tags = new();
        public IEnumerable<string> Tags => tags;

        /// <summary>Grupe kojima korisnik pripada.</summary>
        public IEnumerable<GroupDto>? Groups { get; set; } = null;

        private static readonly LocalData localData = new();

        private LocalData() { }

        public static LocalData GetInstance()
        {
            return localData;
        }

        public async Task GetTargets()
        {
            var dtos = await WebApi.GetList<TargetDto>(WebApi.ReqEnum.Targets);
            if (dtos == null)
                return;
            targets.Clear();
            foreach (var dto in dtos)
                AddTarget(new Target
                {
                    TargetId = dto.TargetId,
                    Content = dto.Content,
                    Tags = TaggedWorldLibrary.Utils.Tags.ParseTags(dto.StrTags).ToList(),
                });
            // ucitavanje u kolekciju Tags
            tags.Clear();
            foreach (var t in TaggedWorldLibrary.Utils.Tags.TypeTags)
                tags.Add(t);
            foreach (var t in targets)
                foreach (var tag in t.Tags)
                    tags.Add(tag);
        }

        /// <summary>Da li ima targeta sa istim sadrzajem tj. adresom.</summary>
        /// <remarks>Za predvidjeni tip doc/document ne treba raditi pretragu po sadrzaju (content/address).</remarks>
        public bool ContainsTargetWSameContent(Target t)
            => targets.Any(it => it.Content == t.Content);

        /// <summary>Da li ima targeta sa istim sadrzajem tj. adresom.</summary>
        /// <remarks>Za predvidjeni tip doc/document ne treba raditi pretragu po sadrzaju (content/address).</remarks>
        public bool ContainsTargetWSameContent(string content)
            => targets.Any(it => it.Content == content);

        public void AddTarget(Target t)
        {
            targets.Add(t);
            //B
            //if (targets != null && !targets.Contains(target))
            //{
            //    targets.Add(target);
            //    return true;
            //}
            //return false;
        }

        public void RemoveTarget(Target target)
        {
            targets.Remove(target);
        }
    }
}
