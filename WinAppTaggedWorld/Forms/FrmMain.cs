using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TaggedWorld;
using WinAppTaggedWorld.Classes;

namespace WinAppTaggedWorld.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Text = Utils.AppName;
            cmbNewTargetType.Items.Clear();
            foreach (var tag in TaggedWorld.Tag.TypeTags)
                cmbNewTargetType.Items.Add(tag);
        }

        private void TxtTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                if (txtTag.Text != string.Empty)
                    AddTagFromTxt();
            }
        }

        /// <summary>Dodavanje taga iz textBox-a u listu tagova.</summary>
        private void AddTagFromTxt()
        {
            var tag = new Tag(txtTag.Text);
            if (AddToTags(tag))
                txtTag.Clear();
        }

        private void BtnSearchAddTag_Click(object sender, EventArgs e)
            => AddTagFromTxt();

        /// <summary>Na osnovu taga dodaje se TagLabel kontrola u listu tagova za pretragu.</summary>
        /// <returns>true: uspesno dodata kontrola</returns>
        private bool AddToTags(Tag tag)
        {
            // ponovljeni tag se odbija
            if (tagList.Exists(tag))
            {
                Utils.Mbox($"Tag '{tag}' is already listed.");
                return false;
            }
            // tag je spec/tip, a lista vec sadrzi spec/tip
            var currentTypeTag = tagList.GetTypeTag();
            if (TaggedWorld.Tag.IsTypeTag(tag.Name) && currentTypeTag != null)
            {
                if (Utils.MboxYesNo($"Do you want to change type to '{tag}'?")
                    == DialogResult.Yes)
                {
                    foreach (var typeTag in TaggedWorld.Tag.TypeTags)
                        if (typeTag != tag.Name)
                            tagList.RemoveTag(new Tag(typeTag));
                    //tagList.AddTag(tag);
                    //return true;
                }
                else
                    return false;
            }
            // prihvatanje tj. dodavanje taga u listu za pretragu
            tagList.AddTag(tag);
            if (TaggedWorld.Tag.IsTypeTag(tag.Name))
                BrowseTarget();
            return true;
        }

        /// <summary>Pokretanje dijaloga za odabir fajla/foldera ili paste clipboard-a za link.</summary>
        private bool BrowseTarget()
        {
            try
            {
                if (tagList.Exists(TaggedWorld.Tag.TypeLink))
                {
                    var clipboard = Clipboard.GetText();
                    if (Utils.IsItLink(clipboard))
                    {
                        //B Utils.GoToLink(clipboard);
                        txtTargetAddress.Text = clipboard;
                    }
                }
                else if (tagList.Exists(TaggedWorld.Tag.TypeFile))
                {
                    if (fileBrowse.ShowDialog() == DialogResult.OK)
                        txtTargetAddress.Text = fileBrowse.FileName;
                }
                else if (tagList.Exists(TaggedWorld.Tag.TypeFolder))
                {
                    if (folderBrowse.ShowDialog() == DialogResult.OK)
                        txtTargetAddress.Text = folderBrowse.SelectedPath;
                }
                return true;
            }
            catch (Exception ex)
            {
                Utils.Mbox(ex, "Browse Target");
                return false;
            }
        }

        //private Target? newTarget = null;

        private void CmbNewTargetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selItem = cmbNewTargetType.SelectedItem;
            if (selItem != null)
            {
                var tag = new Tag(selItem.ToString());
                AddToTags(tag);
                //newTarget = new Target(tag);
            }
        }

        private void BtnAddTarget_Click(object sender, EventArgs e)
        {
            try
            {
                var tags = tagList.AllTags.ToList();
                var target = new Target(txtTargetAddress.Text, tags);
                var targetCtrl = new Controls.TargetCtrl(target);
                targetList.AddTargetCtrl(targetCtrl);
                // targetList.Controls.Add(targetCtrl);

                tagList.Clear();
                txtTargetAddress.Clear();
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }
    }
}
