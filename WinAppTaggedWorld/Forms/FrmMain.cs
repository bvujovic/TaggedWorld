using System.Windows.Forms;
using TaggedWorldLibrary.DTOs;
using TaggedWorldLibrary.Model;
using TaggedWorldLibrary.Utils;
using WinAppTaggedWorld.Classes;
using WinAppTaggedWorld.Data;

namespace WinAppTaggedWorld.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            data = LocalData.GetInstance();
        }

        private readonly LocalData data;
        /// <summary>Target koji se upravo edituje. null - kada se vrsi pretraga ili dodavanje novog targeta.</summary>
        private Target? target = null;
        /// <summary>Objekat koji filtrira i sortira targete.</summary>
        private Data.Selectors.TargetSelector targetSelector = default!;

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            Text = Utils.AppName;
            var frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() != DialogResult.OK)
            {
                Close();
                return;
            }
            // ovaj kôd se izvrsava samo ako se korisnik uloguje
            try
            {
                await data.GetTargets();
                data.User = await WebApi.GetObject<UserDto>(WebApi.ReqEnum.Users_userDto);
                if (data.User != null)
                {
                    txtUserFullname.Text = data.User.FullName;
                    txtUserUsername.Text = data.User.Username;
                    txtUserEmail.Text = data.User.Email;
                }
                data.Groups = await WebApi.GetList<GroupDto>(WebApi.ReqEnum.Groups);
                groupList.Display(data.Groups);
                gbGroups.Text = groupList.ToString();

                SetTxtTagAutoComplete();
                targetSelector = new Data.Selectors.TargetSelector(data);
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
                AddToTags(tagLabel.Text);
                tagListSuggest.RemoveTag(tagLabel);
            }
        }

        private void TargetList_EditTarget(object? sender, EventArgs e)
        {
            try
            {
                if (sender is Controls.TargetCtrl ctrl)
                {
                    target = ctrl.Target;
                    targetList.SuspendDisplay();
                    txtTargetAddress.Text = target.Content;
                    tagListMain.Clear();
                    suspendSuggestTags = true;
                    foreach (var tag in target.Tags)
                        tagListMain.AddTag(tag);
                    suspendSuggestTags = false;
                    targetList.ResumeDisplay(targetSelector.Targets);
                    targetList.SelectedTarget = target;
                    btnSaveTarget.Text = "Save Target";
                }
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private async void TargetList_RemoveTarget(object? sender, EventArgs e)
        {
            try
            {
                if (sender is Controls.TargetCtrl ctrl)
                {
                    await DataGetter.DeleteTarget(ctrl.Target.TargetId);
                    data.RemoveTarget(ctrl.Target);
                    targetList.RemoveTargetCtrl(ctrl);
                }
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        /// <summary>Ucitavanje TargetCtrl kontrola na osnovu selektovanih tagova.</summary>
        private void RefreshTargets()
            => targetSelector.SetTags(tagListMain.Tags);

        private void TagList_ListChanged(object? sender, EventArgs e)
        {
            RefreshTargets();
            SuggestTags();
        }

        private void TargetSelector_TagsChanged(object? sender, EventArgs e)
        {
            targetList.Display(targetSelector.Targets);
            lblTargetResults.Text = $"Results ({targetSelector.Targets?.Count()})";
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
            var tags = Tags.ParseTags(txtTag.Text);
            targetList.SuspendDisplay();
            foreach (var tag in tags)
                AddToTags(tag);
            targetList.ResumeDisplay(targetSelector.Targets);
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
        private bool AddToTags(string tag)
        {
            // ponovljeni tag se odbija
            if (tagListMain.Exists(tag))
            {
                Utils.Mbox($"Tag '{tag}' is already listed.");
                return false;
            }
            // tag je spec/tip, a lista vec sadrzi spec/tip
            var currentTypeTag = tagListMain.GetTypeTag();
            if (Tags.IsTypeTag(tag) && currentTypeTag != null)
            {
                if (Utils.MboxYesNo($"Do you want to change type to '{tag}'?") == DialogResult.Yes)
                {
                    foreach (var typeTag in Tags.TypeTags)
                        if (typeTag != tag)
                            tagListMain.RemoveTag(typeTag);
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

        private bool suspendSuggestTags = false;

        private void SuggestTags()
        {
            //TODO dobro bi bilo da postoji mehanizam za suspendovanje sugestija (kada se dodaje vise tagova odjednom)
            if (suspendSuggestTags)
                return;
            System.Diagnostics.Debug.WriteLine("SuggestTags");
            var ts = new TagSuggester(data);
            var suggestions = ts.Suggest(tagListMain.Tags);
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
                    AddToTags(typeTag = Tags.TypeLink);
                if (File.Exists(clipboard))
                    AddToTags(typeTag = Tags.TypeFile);
                if (Directory.Exists(clipboard))
                    AddToTags(typeTag = Tags.TypeFolder);
                if (typeTag != null)
                    txtTargetAddress.Text = clipboard;
            }
            if (typeTag != null)
                BrowseTarget();
            else
                Utils.Mbox($"Type tag ({Tags.TypeTagsStr}) is not set yet.");
        }

        /// <summary>Pokretanje dijaloga za odabir fajla/foldera ili paste clipboard-a za link.</summary>
        private bool BrowseTarget()
        {
            try
            {
                var clipboard = Clipboard.GetText();
                if (tagListMain.Exists(Tags.TypeLink))
                {
                    if (Utils.IsItLink(clipboard))
                        txtTargetAddress.Text = clipboard;
                    else
                        Utils.GoToLink("");
                }
                else if (tagListMain.Exists(Tags.TypeFile))
                {
                    if (File.Exists(clipboard))
                        txtTargetAddress.Text = clipboard;
                    else if (fileBrowse.ShowDialog() == DialogResult.OK)
                        txtTargetAddress.Text = fileBrowse.FileName;
                }
                else if (tagListMain.Exists(Tags.TypeFolder))
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
        {
            var address = txtTargetAddress.Text;
            if (Utils.IsItLink(address) && tagListMain.GetTypeTag() != Tags.TypeLink)
                AddToTags(Tags.TypeLink);
            else if (File.Exists(address) && tagListMain.GetTypeTag() != Tags.TypeFile)
                AddToTags(Tags.TypeFile);
            else if (Directory.Exists(address) && tagListMain.GetTypeTag() != Tags.TypeFolder)
                AddToTags(Tags.TypeFolder);
        }

        private async void BtnSaveTarget_Click(object sender, EventArgs e)
        {
            try
            {
                var tags = tagListMain.Tags.ToList();
                var typeTag = Tags.GetTypeTag(tags);
                if (typeTag == null)
                    throw new Exception("Tags must contain one type tag: " + Tags.TypeTagsStr);
                // dodavanje novog targeta
                if (target == null)
                {
                    if (data.ContainsTargetWSameContent(txtTargetAddress.Text) &&
                        Utils.MboxYesNo("Target with the same address already exists. Are you sure that you want to add another one?"
                        , "Save Target") == DialogResult.No)
                        return;
                    var t = new Target
                    {
                        Content = txtTargetAddress.Text,
                        Tags = tags
                    };
                    data.AddTarget(t);
                    await DataGetter.CreateTarget(t);
                }
                // editovanje targeta
                else
                {
                    target.Tags = tagListMain.Tags.ToList();
                    target.Content = txtTargetAddress.Text;
                    await DataGetter.UpdateTarget(target);
                    var ctrl = targetList.GetSelectedCtrl();
                    ctrl?.RefreshDisplay();
                    target = null;
                    data.RefreshTags();
                }
                txtTargetAddress.Clear();
                tagListMain.Clear();
                SetTxtTagAutoComplete();
            }
            catch (Exception ex) { Utils.Mbox(ex); }
        }

        private void SetTxtTagAutoComplete()
        {
            txtTag.AutoCompleteCustomSource.Clear();
            txtTag.AutoCompleteCustomSource.AddRange(data.Tags.ToArray());
        }

        private async void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (WebApi.IsUserLoggedIn)
                    await DataGetter.UserLogoutAsync();
            }
            catch (Exception) { }
        }

        private async void GroupList_SelectionChanged(object sender, EventArgs e)
        {
            //...
            try
            {
                var x = await DataGetter.GetSharedTargetsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}