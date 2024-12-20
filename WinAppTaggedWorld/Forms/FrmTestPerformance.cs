﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaggedWorldLibrary.Model;
using TaggedWorldLibrary.Utils;
using WinAppTaggedWorld.Classes;
using WinAppTaggedWorld.Data;

namespace WinAppTaggedWorld.Forms
{
    public partial class FrmTestPerformance : Form
    {
        public FrmTestPerformance()
        {
            InitializeComponent();
            data = LocalData.CreateTestInstance();
        }

        private readonly LocalData data;
        private readonly List<int> newTargetIDs = new();

        /// <summary>Tag koji ce sadrzati svi test targeti.</summary>
        public static string TestTag => "_test_";

        private void ControlsEnabled(bool enabled)
        {
            foreach (Control ctrl in Controls)
                ctrl.Enabled = enabled;
        }

        /// <summary>brisanje ranije dodatih test targeta</summary>
        private async Task RemoveTestTargets()
        {
            data.RemoveTargets(newTargetIDs);
            foreach (var id in newTargetIDs)
                await DataGetter.DeleteTarget(id);
        }

        private async void BtnTargetsCreate_Click(object sender, EventArgs e)
        {
            ControlsEnabled(false);
            try
            {
                var cnt = (int)numTargetsCount.Value;
                if (cnt <= 0)
                    throw new Exception("Number of targets has to be greater than 0.");

                txtStatus.AppendText($"Adding {cnt} test targets...\r\n");

                var targetFaker = new Bogus.Faker<Target>()
                    .RuleFor(it => it.Content, f => f.Internet.Url())
                    .RuleFor(it => it.Tags, f => f.Lorem.Words(4).Append(Tags.TypeLink).Append(TestTag).ToList());
                var targets = targetFaker.Generate(cnt);
                //B
                //var targets = new List<Target>(cnt);
                //for (int i = 0; i < cnt; i++)
                //    targets.Add(new Target
                //    {
                //        Content = $"_test_{i:00}",
                //        Tags = new List<string> { "link", "pera", "123" }
                //    });

                var watch = new StopWatch();
                for (int i = 0; i < cnt; i++)
                {
                    var t = targets[i];
                    t.Content += $"_{i}";
                    data.AddTarget(t);
                    await DataGetter.CreateTarget(t);
                    newTargetIDs.Add(t.TargetId);
                }
                txtStatus.AppendText($"Done in {watch} seconds.\r\n");
                var msPerTarget = watch.Interval.TotalMilliseconds / cnt;
                txtStatus.AppendText($"{msPerTarget:0.0} ms per target.\r\n\r\n");

                txtStatus.AppendText("Removing test targets...\r\n");
                watch.Start();
                await RemoveTestTargets();
                txtStatus.AppendText($"Done in {watch} seconds.\r\n");
                msPerTarget = watch.Interval.TotalMilliseconds / cnt;
                txtStatus.AppendText($"{msPerTarget:0.0} ms per target.\r\n");
            }
            catch (Exception ex) { Utils.Mbox(ex, btnTargetsCreate.Text); }
            ControlsEnabled(true);
        }

        private async void BtnRemoveTestTargets_Click(object sender, EventArgs e)
        {
            var ids = data.Targets.Where(it => it.Tags.Contains(TestTag))
                .Select(it => it.TargetId).ToList();
            if (ids.Any())
            {
                data.RemoveTargets(ids);
                foreach (var id in ids)
                    await DataGetter.DeleteTarget(id);
            }
            Utils.Mbox($"Removed {ids.Count} targets.", btnRemoveTestTargets.Text);
        }
    }
}
