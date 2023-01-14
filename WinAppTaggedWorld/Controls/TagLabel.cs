using System;
using System.Windows.Forms;

namespace WinAppTaggedWorld.Controls
{
    public partial class TagLabel : Label
    {
        public TagLabel(string tag)
        {
            InitializeComponent();
            Text = tag;
        }
    }
}
