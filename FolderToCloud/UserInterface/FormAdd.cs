using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FolderToCloud.DataClasses;
using FolderToCloud.Properties;

namespace FolderToCloud.UserInterface
{
    public partial class FormAdd : Form
    {
        #region private properties
        private string _localPath, _cloudPath;
        private List<Link> _links;
        #endregion

        #region public properties
        public Link Link;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FormAdd"/> class. Use this constructor for an add.
        /// </summary>
        public FormAdd()
        {
            InitializeComponent();
            InitializeExtraComponent();
            buttonAdd.Text = Resources.FormAdd_FormAdd_Add;
            SetEnabledCloudControls(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormAdd"/> class. Use this constructor for an edit.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="links">The links.</param>
        public FormAdd(Link link, List<Link> links)
        {
            InitializeComponent();
            InitializeExtraComponent();
            Link = link;
            _links = links;
            buttonAdd.Text = Resources.FormAdd_FormAdd_Edit;
            SetEnabledCloudControls(false);
        }
        #endregion

        #region events


        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            Button senderButton = sender as Button;
            DialogResult result = folderBrowserDialogAdd.ShowDialog();
            if (result == DialogResult.OK)
            {
                //check from which button the call is coming from.
                if (senderButton != null && senderButton.Name == buttonBrowseCloud.Name)
                {
                    textBoxCloud.Text = folderBrowserDialogAdd.SelectedPath;

                }
                else
                {
                    textBoxLocal.Text = folderBrowserDialogAdd.SelectedPath;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //Test if paths are valid
            if (Helpers.Utils.IsLocalOrCloudNotParentNorChild(_localPath, _cloudPath))
            {
                bool shouldMoveBeDone = true;
                //Check if it is an add or edit
                if (Link == null)
                {
                    //Add
                    if (!string.IsNullOrEmpty(_cloudPath) && !string.IsNullOrEmpty(_localPath))
                    {
                        Link = new Link(_cloudPath, _localPath);
                    }
                }
                else
                {
                    //Edit
                    //Remove old link
                    try
                    {
                        Helpers.FileUtils.RemoveLink(Link, _links);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(
                            Resources
                                .FormAdd_buttonAdd_Click_The_link_does_not_appear_to_be_a_link__try_manually_deleting_the_link_,
                            Resources.FormAdd_buttonAdd_Click_Error_removing_link, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    shouldMoveBeDone = false;
                    if (!string.IsNullOrEmpty(_localPath))
                    {
                        Link.LocalPath = _localPath;
                    }
                }

                if (Link != null)
                {
                    if (_links == null)
                        _links = new List<Link>();
                    if (!shouldMoveBeDone)
                    {
                        //No move will be done, check that localpath is empty, else let the user choose to move it manually or not.
                        if (!Helpers.Utils.IsDirectoryEmpty(_localPath))
                        {
                            DialogResult result = MessageBox.Show(Resources.FormAdd_buttonAdd_Click_The_new_local_path_is_not_empty__do_you_wish_that_the_content_is_moved_,
                                Resources.FormAdd_buttonAdd_Click_Local_path_not_empty, MessageBoxButtons.YesNo,
                                                                  MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                shouldMoveBeDone = true;
                            }
                            else
                            {
                               return;
                            }
                        }
                    }
                    Helpers.FileUtils.AppendLinkToFile(Link, _links);
                    Helpers.Utils.ExecuteLinkCommands(Link, shouldMoveBeDone);
                }
                //TODO feedback if succesfull
                Close();
            }
            else
            {
                MessageBox.Show(
                    Resources.FormAdd_buttonAdd_Click_Linked_Folder_cannot_be_parents_childs_of_each_other_,
                    Resources.FormAdd_buttonAdd_Click_Validation_error_, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = Resources.FormAdd_Add_Name;
            //Disable add button, will be re-enabled when paths are valid.
            buttonAdd.Enabled = false;

            //Check if it an edit or an add
            if (Link != null)
            {
                Text = string.Format(Resources.FormAdd_Edit_Name, Link.ToShortString());
                _localPath = Link.LocalPath;
                textBoxLocal.Text = Link.LocalPath;

                _cloudPath = Link.CloudPath;
                textBoxCloud.Text = Link.CloudPath;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            _localPath = textBoxLocal.Text;
            if (Link == null)
                _cloudPath = textBoxCloud.Text;

            bool isValidPath = Helpers.Utils.IsValidPathString(_localPath);

            //Both Path have to be valid, only check when Local path is valid
            if (Link == null && isValidPath)
                isValidPath = Helpers.Utils.IsValidPathString(_cloudPath);

            //Check if localpath has changed
            if (Link != null && isValidPath)
            {
                if (Link.LocalPath == _localPath)
                    isValidPath = false;
            }
            buttonAdd.Enabled = isValidPath;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes extra components. Adds extra subscriptions to events.
        /// </summary>
        private void InitializeExtraComponent()
        {
            buttonBrowseCloud.Click += buttonBrowse_Click;
            buttonBrowseLocal.Click += buttonBrowse_Click;

            textBoxCloud.TextChanged += textBox_TextChanged;
            textBoxLocal.TextChanged += textBox_TextChanged;
        }

        /// <summary>
        /// Sets the enabled cloud controls.
        /// </summary>
        /// <param name="isEnabled">if set to <c>true</c> [is enabled].</param>
        private void SetEnabledCloudControls(bool isEnabled)
        {
            textBoxCloud.Enabled = isEnabled;
            buttonBrowseCloud.Enabled = isEnabled;
        }
        #endregion
    }
}
