using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
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

        private Tag tag;
        /// <summary>Tag/labela/oznaka koju ova kontrola prikazuje.</summary>
        public new Tag Tag
        {
            get { return tag; }
            set
            {
                tag = value;
                this.Text = tag.Name;
            }
        }
    }
}
