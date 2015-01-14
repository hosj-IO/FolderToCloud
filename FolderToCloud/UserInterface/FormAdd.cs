using System;
using System.Collections.Generic;
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
                    _cloudPath = folderBrowserDialogAdd.SelectedPath;
                    textBoxCloud.Text = _cloudPath;
                }
                else
                {
                    _localPath = folderBrowserDialogAdd.SelectedPath;
                    textBoxLocal.Text = _localPath;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
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
                Helpers.FileUtils.RemoveLink(Link, _links);
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

                Helpers.FileUtils.AppendLinkToFile(Link, _links);
                Helpers.Utils.ExecuteLinkCommands(Link, shouldMoveBeDone);
            }
            //TODO feedback if succesfull
            Close();
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = Resources.FormAdd_Add_Name;
            //Check if it an edit or an add
            if (Link != null)
            {
                Name = string.Format(Resources.FormAdd_Edit_Name, Link.ToShortString());
                _localPath = Link.LocalPath;
                //TODO Set these properties via an event
                textBoxLocal.Text = Link.LocalPath;

                _cloudPath = Link.CloudPath;
                textBoxCloud.Text = Link.CloudPath;
            }
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
