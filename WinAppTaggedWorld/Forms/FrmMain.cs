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

        private const string targetsTestFilePath = "Data/targets.txt";
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
                data.LoadTestTargets(targetsTestFilePath);
                txtTag.AutoCompleteCustomSource.AddRange(data.AllTags.Select(it => it.Name).ToArray());
                targetSelector = new TaggedWorld.Selectors.TargetSelector(data);
                targetSelector.TagsChanged += TargetSelector_TagsChanged;
                tagListMain.ListChanged += TagList_ListChanged;
                targetList.RemoveTarget += TargetList_RemoveTarget;
                targetList.EditTarget += TargetList_EditTarget;
                txtTag.Focus();
                tagListMain.HorizontalScroll.Enabled = false;
                tagListSuggest.HorizontalScroll.Enabled = false;
                tagListMain.TagLabelClicked += (o, ea) => { tagListMain.RemoveTag(o as Controls.TagLabel); };
                tagListSuggest.TagLabelClicked += TagListSuggest_TagLabelClicked;
                RefreshTargets();
                SuggestTags();
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private void TagListSuggest_TagLabelClicked(object? sender, EventArgs e)
        {
            if (sender is Controls.TagLabel tagLabel)
            {
                AddToTags(tagLabel.Tag);
                tagListSuggest.RemoveTag(tagLabel);
            }
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
                    tagListMain.Clear();
                    foreach (var tag in target.Tags)
                        tagListMain.AddTag(tag);
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
                    data.RemoveTarget(ctrl.Target);
                    targetList.RemoveTargetCtrl(ctrl);
                }
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        /// <summary>Ucitavanje TargetCtrl kontrola na osnovu selektovanih tagova.</summary>
        private void RefreshTargets()
            => targetSelector.SetTags(tagListMain.AllTags);

        private void TagList_ListChanged(object? sender, EventArgs e)
        {
            RefreshTargets();
            SuggestTags();
        }

        private void TargetSelector_TagsChanged(object? sender, IEnumerable<Target> targets)
        {
            targetList.Display(targets);
            lblTargetResults.Text = $"Results ({targets.Count()})";
        }

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
                tagListMain.Clear();
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
            tagListMain.Clear();
            txtTag.Focus();
        }

        private void BtnTagListCopy_Click(object sender, EventArgs e)
        {
            try
            {
                tagListMain.CopyToClipboard();
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        /// <summary>Na osnovu taga dodaje se TagLabel kontrola u listu tagova za pretragu.</summary>
        /// <returns>true: uspesno dodata kontrola</returns>
        private bool AddToTags(Tag tag)
        {
            // ponovljeni tag se odbija
            if (tagListMain.Exists(tag))
            {
                Utils.Mbox($"Tag '{tag}' is already listed.");
                return false;
            }
            // tag je spec/tip, a lista vec sadrzi spec/tip
            var currentTypeTag = tagListMain.GetTypeTag();
            if (TaggedWorld.Tag.IsTypeTag(tag.Name) && currentTypeTag != null)
            {
                if (Utils.MboxYesNo($"Do you want to change type to '{tag}'?")
                    == DialogResult.Yes)
                {
                    foreach (var typeTag in TaggedWorld.Tag.TypeTags)
                        if (typeTag != tag.Name)
                            tagListMain.RemoveTag(new Tag(typeTag));
                }
                else
                    return false;
            }
            // prihvatanje tj. dodavanje taga u listu za pretragu
            tagListMain.AddTag(tag);
            txtTag.Focus();
            SuggestTags();
            return true;
        }

        private void SuggestTags()
        {
            //TODO dobro bi bilo da postoji mehanizam za suspendovanje sugestija (kada se dodaje vise tagova odjednom)
            var ts = new TagSuggester(data);
            var suggestions = ts.Suggest(tagListMain.AllTags.Select(it => it.Name));
            tagListSuggest.Clear();
            foreach (var level in suggestions.Where(it => it.Key > 0))
            {
                foreach (var sug in level.Value)
                    tagListSuggest.AddTag(sug);
                if (tagListSuggest.Count >= 5)
                    break;
            }
        }

        private void BtnTargetBrowse_Click(object sender, EventArgs e)
        {
            var typeTag = tagListMain.GetTypeTag();
            var clipboard = Clipboard.GetText();
            if (typeTag == null)
            {
                if (Utils.IsItLink(clipboard))
                    AddToTags(typeTag = new Tag(TaggedWorld.Tag.TypeLink));
                if (File.Exists(clipboard))
                    AddToTags(typeTag = new Tag(TaggedWorld.Tag.TypeFile));
                if (Directory.Exists(clipboard))
                    AddToTags(typeTag = new Tag(TaggedWorld.Tag.TypeFolder));
                if (typeTag != null)
                    txtTargetAddress.Text = clipboard;
            }

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
                var clipboard = Clipboard.GetText();
                if (tagListMain.Exists(TaggedWorld.Tag.TypeLink))
                {
                    if (Utils.IsItLink(clipboard))
                        txtTargetAddress.Text = clipboard;
                    else
                        Utils.GoToLink("");
                }
                else if (tagListMain.Exists(TaggedWorld.Tag.TypeFile))
                {
                    if (File.Exists(clipboard))
                        txtTargetAddress.Text = clipboard;
                    else if (fileBrowse.ShowDialog() == DialogResult.OK)
                        txtTargetAddress.Text = fileBrowse.FileName;
                }
                else if (tagListMain.Exists(TaggedWorld.Tag.TypeFolder))
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

        private void TxtTargetAddress_TextChanged(object sender, EventArgs e)
            => lblTargetExists.Visible = targetList.Exists(txtTargetAddress.Text);

        private void BtnAddTarget_Click(object sender, EventArgs e)
        {
            try
            {
                // dodavanje novog targeta
                if (this.target == null)
                {
                    var tags = tagListMain.AllTags.ToList();
                    var target = new Target(txtTargetAddress.Text, tags);
                    data.AddTarget(target);
                }
                // editovanje targeta
                else
                {
                    target.Tags = tagListMain.AllTags.ToList();
                    target.Address = txtTargetAddress.Text;
                    var ctrl = targetList.GetSelectedCtrl();
                    if (ctrl != null)
                        ctrl.RefreshDisplay();
                    target = null;
                    btnAddTarget.Text = "Add Target";
                }
                targetSelector.SetTags(tagListMain.AllTags);
                txtTargetAddress.Clear();
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                data?.SaveTestTargets(targetsTestFilePath);
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private void BtnDocTest_Click(object sender, EventArgs e)
        {
            new FrmDoc().ShowDialog();
        }
    }
}
