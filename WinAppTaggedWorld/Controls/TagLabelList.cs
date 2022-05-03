using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using TaggedWorld;

namespace WinAppTaggedWorld.Controls
{
    public partial class TagLabelList : FlowLayoutPanel
    {
        public TagLabelList()
        {
            InitializeComponent();
        }

        public void AddTag(Tag tag)
        {
            var tagLabel = new TagLabel(tag);
            Controls.Add(tagLabel);
            ListChanged?.Invoke(this, EventArgs.Empty);
            tagLabel.Click += TagLabel_Click;
        }

        private void TagLabel_Click(object? sender, EventArgs e)
        {
            if (e is MouseEventArgs mea && mea.Button == MouseButtons.Left)
                RemoveTag((sender as TagLabel).Tag);
        }

        public TagLabel? GetTagLabel(string tag)
        {
            foreach (var tagLabel in Controls.OfType<TagLabel>())
                if (tagLabel.Tag.Name == tag)
                    return tagLabel;
            return null;
        }

        /// <summary>Vraća specijalni/tip tag, ako postoji.</summary>
        public Tag? GetTypeTag()
        {
            foreach (var tag in AllTags)
                if (TaggedWorld.Tag.IsTypeTag(tag.Name))
                    return tag;
            return null;
        }

        /// <summary>Tagovi iz liste za pretragu.</summary>
        public IEnumerable<Tag> AllTags
            => Controls.OfType<TagLabel>().Select(it => it.Tag);

        /// <summary>Da li je je dati tag vec prikazan u listi tagova za pretragu.</summary>
        public bool Exists(Tag tag)
            => AllTags.Contains(tag);

        /// <summary>Da li je je dati tag vec prikazan u listi tagova za pretragu.</summary>
        public bool Exists(string tagName)
            => Exists(new Tag(tagName));

        /// <summary>Brisanje taga iz liste.</summary>
        public bool RemoveTag(Tag tag)
        {
            var tagLabel = GetTagLabel(tag.Name);
            if (tagLabel != null)
            {
                Controls.Remove(tagLabel);
                ListChanged?.Invoke(this, EventArgs.Empty);
                return true;
            }
            else
                return false;
        }

        /// <summary>Brisanje svih tagova iz liste.</summary>
        public void Clear()
        {
            Controls.Clear();
            ListChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ListChanged = default!;

        public void CopyToClipboard()
        {
            if (!AllTags.Any())
                throw new Exception("Nothing to copy to the clipboard - tag list is empty.");
            Clipboard.SetText(string.Join(", ", AllTags));
        }
    }
}
