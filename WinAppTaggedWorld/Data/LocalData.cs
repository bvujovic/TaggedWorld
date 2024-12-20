﻿using Newtonsoft.Json;
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
        public IEnumerable<GroupDto>? MyGroups { get; set; } = null;

        /// <summary>Osnovni podaci o ulogovanom korisniku.</summary>
        public UserDto User { get; set; }

        private static readonly LocalData localData = new();

        private LocalData() { }

        public static LocalData GetInstance()
        {
            return localData;
        }

        /// <summary>Ovo bi trebalo koristiti samo za potrebe testiranja.</summary>
        public static LocalData CreateTestInstance()
        {
            return new LocalData();
        }

        /// <summary>Dohvatanje svih korisnikovih targeta.</summary>
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
            if (ContainsTargetWSameContent(t.Content))
                throw new Exception("Target with the same content already exists.");
            targets.Add(t);
            foreach (var tag in t.Tags)
                tags.Add(tag);
        }

        public void RemoveTarget(Target t)
        {
            targets.Remove(t);
            RefreshTags();
        }

        public void RemoveTargets(IEnumerable<int> ids)
        {
            foreach (var id in ids)
                targets.RemoveAll(it => it.TargetId == id);
            RefreshTags();
        }

        public void Clear()
        {
            targets.Clear();
            tags.Clear();
        }

        /// <summary>Osvezavanje liste tags na osnovu tagova iz svih targeta.</summary>
        public void RefreshTags()
        {
            tags.Clear();
            foreach (var t in TaggedWorldLibrary.Utils.Tags.TypeTags)
                tags.Add(t);
            foreach (var t in targets)
                foreach (var tag in t.Tags)
                    tags.Add(tag);
        }
    }
}
