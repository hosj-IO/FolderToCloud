using System;
using System.Collections.Generic;
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

            using (FormAdd formAdd = new FormAdd())
            {
                formAdd.ShowDialog();
            }

            _links = Helpers.FileUtils.RetrieveLinksFromFile();
            LoadLinksInListBox();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Link selectedLink = listBoxOverview.SelectedItem as Link;
            if (selectedLink != null)
            {
                using (FormDelete formDelete = new FormDelete(selectedLink, _links))
                {
                    DialogResult result = formDelete.ShowDialog();
                    if (result != DialogResult.OK)
                    {
                        //TODO improve message
                        MessageBox.Show("Delete was not possible, try manually");
                    }
                }
                _links = Helpers.FileUtils.RetrieveLinksFromFile();
                LoadLinksInListBox();
            }
            else
            {
                MessageBox.Show(Resources.FormMain_buttonDelete_Click_Please_select_a_link_to_delete_,
                                Resources.FormMain_buttonDelete_Click_No_link_selected_, MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Link selectedLink = listBoxOverview.SelectedItem as Link;
            if (selectedLink != null)
            {
                using (FormAdd formAdd = new FormAdd(selectedLink, _links))
                {
                    formAdd.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(Resources.FormMain_buttonDelete_Click_Please_select_a_link_to_delete_,
                                Resources.FormMain_buttonDelete_Click_No_link_selected_, MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            _links = Helpers.FileUtils.RetrieveLinksFromFile();
            LoadLinksInListBox();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads the links in ListBox.
        /// </summary>
        private void LoadLinksInListBox()
        {
            listBoxOverview.DataSource = _links;
        }

        #endregion

    }
}
