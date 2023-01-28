using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using TaggedWorldLibrary.DTOs;

namespace WinAppTaggedWorld.Controls
{
    public partial class GroupList : UserControl
    {
        public GroupList()
        {
            InitializeComponent();
        }

        /// <summary>Prikaz svih prosledjenih grupa.</summary>
        public void Display(IEnumerable<GroupDto>? groups)
        {
            Controls.Clear();
            if (groups != null)
            {
                // dodavanje grupa ciji je korisnik clan
                foreach (var g in groups.Reverse())
                {
                    var ctrl = new CheckBox
                    {
                        Text = g.Name,
                        Tag = g,
                        Checked = false,
                        Dock = DockStyle.Top,
                    };
                    ctrl.CheckedChanged += SelectionChanged;
                    var tt = new ToolTip { };
                    tt.SetToolTip(ctrl, g.StrTags);
                    Controls.Add(ctrl);
                }
                // dodavanje posebne stavke koja predstavlja korisnika (targeti koji nisu share-ovani na grupama)
                var ctrlMe = new CheckBox
                {
                    Text = "me",
                    Tag = null,
                    Checked = true,
                    Dock = DockStyle.Top,
                    Font = new Font(this.Font, FontStyle.Italic),
                };
                ctrlMe.CheckedChanged += SelectionChanged;
                Controls.Add(ctrlMe);
            }
            Count = Controls.Count;
        }

        /// <summary>Broj prikazanih grupa.</summary>
        public int Count { get; private set; } = 0;

        /// <summary>Dešava se prilikom (de)čekiranja neke od ponuđenih stavki tj. grupa.</summary>
        public event EventHandler? SelectionChanged;

        public override string ToString()
            => $"Groups ({Count})";
    }
}
