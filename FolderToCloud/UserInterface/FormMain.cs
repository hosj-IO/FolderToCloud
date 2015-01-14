using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FolderToCloud.DataClasses;
using FolderToCloud.Properties;

namespace FolderToCloud.UserInterface
{
    public partial class FormMain : Form
    {
        #region Properties

        private List<Link> _links;

        #endregion

        #region Constructor
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void FormMain_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            _links = new List<Link>();
            _links = Helpers.FileUtils.RetrieveLinksFromFile();
            LoadLinksInListBox();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Link link = null;
            using (FormAdd formAdd = new FormAdd())
            {
                DialogResult result = formAdd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    link = formAdd.Link;
                }
            }

            if (link != null)
            {
                Helpers.FileUtils.AppendLinkToFile(link, _links);
                ExecuteLinkCommands(link);
            }
            _links = Helpers.FileUtils.RetrieveLinksFromFile();
            LoadLinksInListBox();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Link selectedLink = listBoxOverview.SelectedItem as Link;
            using (FormDelete formDelete = new FormDelete(selectedLink, _links))
            {
                DialogResult result = formDelete.ShowDialog();
            }
            _links = Helpers.FileUtils.RetrieveLinksFromFile();
            LoadLinksInListBox();
        }
        #endregion

        #region Methods
        private void LoadLinksInListBox()
        {
            listBoxOverview.DataSource = _links;
        }

        private void ExecuteLinkCommands(Link link)
        {
            //Rename the local path to make the Link creation possible
            Directory.Move(link.LocalPath, link.ModifiedLocalPath);

            //Create the link
            string command = string.Format(Resources.mkLinkCommand, link.LocalPath, link.CloudPath);
            System.Diagnostics.Process.Start(Resources.CmdProcessName, command);

            //Move content of the modified Path to the Cloudpath
            if (Helpers.Utils.CopyFolderContents(link.ModifiedLocalPath, link.CloudPath))
            {
                //Remove the modified folder.
                Directory.Delete(link.ModifiedLocalPath, true);
            }
        }
        #endregion
    }
}
