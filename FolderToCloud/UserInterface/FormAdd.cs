using System;
using System.Windows.Forms;
using FolderToCloud.DataClasses;

namespace FolderToCloud.UserInterface
{
    public partial class FormAdd : Form
    {
        private string _localPath, _cloudPath;

        public Link Link;

        public FormAdd()
        {
            InitializeComponent();
            InitializeExtraComponent();
        }

        private void InitializeExtraComponent()
        {
            buttonBrowseCloud.Click += buttonBrowse_Click;
            buttonBrowseLocal.Click += buttonBrowse_Click;
        }

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
            if (!string.IsNullOrEmpty(_cloudPath) && !string.IsNullOrEmpty(_localPath))
            {
                Link = new Link(_cloudPath,_localPath);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

    }
}
