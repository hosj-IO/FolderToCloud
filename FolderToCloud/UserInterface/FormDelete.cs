using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FolderToCloud.DataClasses;

namespace FolderToCloud.UserInterface
{
    public partial class FormDelete : Form
    {
        #region private properties
        private readonly Link _link;
        private readonly List<Link> _links;
        #endregion

        #region constructor
        public FormDelete(Link link, List<Link> links)
        {
            InitializeComponent();
            _link = link;
            _links = links;
        }
        #endregion

        #region Events
        private void FormDelete_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            labelSelectedLink.Text = _link.ToShortString();
            DisableButtons();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort; 
            bool isRecursive = checkBoxRecursive.Checked;
            List<RadioButton> radioButtons = groupBoxDeleteOptions.Controls.OfType<RadioButton>()
                           .Where(n => n.Checked).ToList();

            if (radioButtons.Count == 1)
            {
                switch (radioButtons[0].Name)
                {
                    case "radioButtonRemoveLocal":
                        Directory.Delete(_link.LocalPath);
                        Helpers.FileUtils.RemoveLinkFromFile(_link, _links);
                        DialogResult = DialogResult.OK;
                        break;
                    case "radioButtonRemoveCloud":
                        break;
                    case "radioButtonRemoveBoth":
                        break;
                    case "radioButtonRemoveEntry":
                        Helpers.FileUtils.RemoveLinkFromFile(_link, _links);
                        DialogResult = DialogResult.OK;
                        break;

                }
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Methods
        private void DisableButtons()
        {
            radioButtonRemoveBoth.Enabled = false;
            radioButtonRemoveCloud.Enabled = false;
        }
        #endregion

    }
}
