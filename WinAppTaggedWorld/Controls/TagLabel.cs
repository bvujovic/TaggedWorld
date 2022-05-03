using System;
using TaggedWorld;

namespace WinAppTaggedWorld.Controls
{
    public partial class TagLabel : Label
    {
        public TagLabel(Tag tag)
        {
            InitializeComponent();
            Tag = tag;
        }

        private Tag tag = default!;
        /// <summary>Tag/labela/oznaka koju ova kontrola prikazuje.</summary>
        public new Tag Tag
        {
            get { return tag; }
            set
            {
                tag = value;
                Text = tag.Name;
            }
        }
    }
}
