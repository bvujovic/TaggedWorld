using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinAppTaggedWorld.Controls
{
    public partial class TagLabelList : FlowLayoutPanel
    {
        public TagLabelList()
        {
            InitializeComponent();
        }

        public void AddTag(string tag)
        {
            var tagLabel = new TagLabel(tag);
            Controls.Add(tagLabel);
            ListChanged?.Invoke(this, EventArgs.Empty);
            tagLabel.Click += TagLabel_Click;
        }

        public event EventHandler TagLabelClicked;

        private void TagLabel_Click(object? sender, EventArgs e)
        {
            if (e is MouseEventArgs mea && mea.Button == MouseButtons.Left)
                TagLabelClicked?.Invoke(sender, e);
        }

        public TagLabel? GetTagLabel(string tag)
        {
            foreach (var tagLabel in Controls.OfType<TagLabel>())
                if (tagLabel.Text == tag)
                    return tagLabel;
            return null;
        }
        
        /// <summary>Vraća specijalni/tip tag, ako postoji.</summary>
        public string? GetTypeTag()
        {
            foreach (var tag in AllTags)
                if (TaggedWorldLibrary.Utils.Tags.IsTypeTag(tag))
                    return tag;
            return null;
        }

        /// <summary>Tagovi iz liste za pretragu.</summary>
        public IEnumerable<string> AllTags
            => Controls.OfType<TagLabel>().Select(it => it.Text);

        /// <summary>Broj tagova u listi.</summary>
        public int Count
            => AllTags.Count();

        /// <summary>Da li je je dati tag vec prikazan u listi tagova za pretragu.</summary>
        public bool Exists(string tag)
            => AllTags.Contains(tag);

        /// <summary>Brisanje taga iz liste.</summary>
        public bool RemoveTag(TagLabel? tagLabel)
        {
            if (tagLabel != null)
            {
                Controls.Remove(tagLabel);
                ListChanged?.Invoke(this, EventArgs.Empty);
                return true;
            }
            else
                return false;
        }

        /// <summary>Brisanje taga iz liste.</summary>
        public bool RemoveTag(string tag)
        {
            var tagLabel = GetTagLabel(tag);
            return RemoveTag(tagLabel);
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
