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

        private Data data = default!;
        private TaggedWorld.Selectors.TargetSelector targetSelector = default!;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Text = Utils.AppName;
            var frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() != DialogResult.OK)
            {
                Close();
                return;
            }
            // ovaj kôd se izvrsava ako se korisnik uloguje
            try
            {
                txtTag.AutoCompleteCustomSource.AddRange(TaggedWorld.Tag.TypeTags);
                data = new Data();
                txtTag.AutoCompleteCustomSource.AddRange(data.AllTags.Select(it => it.Name).ToArray());
                targetSelector = new TaggedWorld.Selectors.TargetSelector(data);
                targetSelector.TagsChanged += TargetSelector_TagsChanged;
                tagList.ListChanged += TagList_ListChanged;
                targetList.RemoveTarget += TargetList_RemoveTarget;
                targetList.EditTarget += TargetList_EditTarget;
                txtTag.Focus();
                tagList.HorizontalScroll.Enabled = false;
                RefreshTargets();
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private Target? target = null;

        private void TargetList_EditTarget(object? sender, EventArgs e)
        {
            try
            {
                if (sender is Controls.TargetCtrl ctrl)
                {
                    target = ctrl.Target;
                    txtTargetAddress.Text = target.Address;
                    targetList.SuspendLayout();
                    tagList.Clear();
                    foreach (var tag in target.Tags)
                        tagList.AddTag(tag);
                    targetList.ResumeLayout();
                    targetList.SelectedTarget = target;
                    btnAddTarget.Text = "Save Target";
                }
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private void TargetList_RemoveTarget(object? sender, EventArgs e)
        {
            try
            {
                if (sender is Controls.TargetCtrl ctrl)
                {
                    data.AllTargets.Remove(ctrl.Target);
                    targetList.RemoveTargetCtrl(ctrl);
                }
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        /// <summary>Ucitavanje TargetCtrl kontrola na osnovu selektovanih tagova.</summary>
        private void RefreshTargets()
            => targetSelector.SetTags(tagList.AllTags);

        private void TagList_ListChanged(object? sender, EventArgs e)
            => RefreshTargets();

        private void TargetSelector_TagsChanged(object? sender, IEnumerable<Target> targets)
            => targetList.Display(targets);

        private void TxtTag_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter -> dodavanje unetog teksta u tagove
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                if (txtTag.Text != string.Empty)
                    AddTagFromTxt();
            }
            // Escape -> brisanje liste tagova
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = e.SuppressKeyPress = true;
                tagList.Clear();
            }
        }

        /// <summary>Dodavanje taga iz textBox-a u listu tagova.</summary>
        private void AddTagFromTxt()
        {
            var tags = TaggedWorld.Tag.ParseText(txtTag.Text);
            foreach (var tag in tags)
                AddToTags(tag);
            txtTag.Clear();
        }

        private void BtnSearchAddTag_Click(object sender, EventArgs e)
            => AddTagFromTxt();

        private void BtnTagListClear_Click(object sender, EventArgs e)
        {
            tagList.Clear();
            txtTag.Focus();
        }

        private void BtnTagListCopy_Click(object sender, EventArgs e)
        {
            try
            {
                tagList.CopyToClipboard();
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

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
                }
                else
                    return false;
            }
            // prihvatanje tj. dodavanje taga u listu za pretragu
            tagList.AddTag(tag);
            return true;
        }

        private void BtnTargetBrowse_Click(object sender, EventArgs e)
        {
            var typeTag = tagList.GetTypeTag();
            if (typeTag != null)
                BrowseTarget();
            else
                Utils.Mbox($"Type tag ({string.Join('/', TaggedWorld.Tag.TypeTags)}) is not set yet.");
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
                        txtTargetAddress.Text = clipboard;
                    else
                        Utils.GoToLink("");
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

        private void BtnAddTarget_Click(object sender, EventArgs e)
        {
            try
            {
                // dodavanje novog targeta
                if (this.target == null)
                {
                    var tags = tagList.AllTags.ToList();
                    var target = new Target(txtTargetAddress.Text, tags);
                    data.AllTargets.Add(target);
                }
                // editovanje targeta
                else
                {
                    target.Tags = tagList.AllTags.ToList();
                    target.Address = txtTargetAddress.Text;
                    var ctrl = targetList.GetSelectedCtrl();
                    if (ctrl != null)
                        ctrl.RefreshDisplay();
                    target = null;
                    btnAddTarget.Text = "Add Target";
                }
                targetSelector.SetTags(tagList.AllTags);
                txtTargetAddress.Clear();
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }
    }
}
