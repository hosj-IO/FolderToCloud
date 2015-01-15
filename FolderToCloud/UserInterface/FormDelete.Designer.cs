namespace FolderToCloud.UserInterface
{
    partial class FormDelete
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonRemoveLocal = new System.Windows.Forms.RadioButton();
            this.groupBoxDeleteOptions = new System.Windows.Forms.GroupBox();
            this.radioButtonRemoveEntry = new System.Windows.Forms.RadioButton();
            this.radioButtonRemoveBoth = new System.Windows.Forms.RadioButton();
            this.radioButtonRemoveCloud = new System.Windows.Forms.RadioButton();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelInfoForm = new System.Windows.Forms.Label();
            this.labelSelectedLink = new System.Windows.Forms.Label();
            this.checkBoxRecursive = new System.Windows.Forms.CheckBox();
            this.groupBoxDeleteOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonRemoveLocal
            // 
            this.radioButtonRemoveLocal.AutoSize = true;
            this.radioButtonRemoveLocal.Location = new System.Drawing.Point(6, 19);
            this.radioButtonRemoveLocal.Name = "radioButtonRemoveLocal";
            this.radioButtonRemoveLocal.Size = new System.Drawing.Size(201, 17);
            this.radioButtonRemoveLocal.TabIndex = 0;
            this.radioButtonRemoveLocal.TabStop = true;
            this.radioButtonRemoveLocal.Text = "Remove link folder, keep cloud folder";
            this.radioButtonRemoveLocal.UseVisualStyleBackColor = true;
            // 
            // groupBoxDeleteOptions
            // 
            this.groupBoxDeleteOptions.Controls.Add(this.radioButtonRemoveEntry);
            this.groupBoxDeleteOptions.Controls.Add(this.radioButtonRemoveBoth);
            this.groupBoxDeleteOptions.Controls.Add(this.radioButtonRemoveCloud);
            this.groupBoxDeleteOptions.Controls.Add(this.radioButtonRemoveLocal);
            this.groupBoxDeleteOptions.Location = new System.Drawing.Point(12, 46);
            this.groupBoxDeleteOptions.Name = "groupBoxDeleteOptions";
            this.groupBoxDeleteOptions.Size = new System.Drawing.Size(247, 127);
            this.groupBoxDeleteOptions.TabIndex = 1;
            this.groupBoxDeleteOptions.TabStop = false;
            this.groupBoxDeleteOptions.Text = "Delete Options";
            // 
            // radioButtonRemoveEntry
            // 
            this.radioButtonRemoveEntry.AutoSize = true;
            this.radioButtonRemoveEntry.Location = new System.Drawing.Point(6, 88);
            this.radioButtonRemoveEntry.Name = "radioButtonRemoveEntry";
            this.radioButtonRemoveEntry.Size = new System.Drawing.Size(165, 17);
            this.radioButtonRemoveEntry.TabIndex = 3;
            this.radioButtonRemoveEntry.TabStop = true;
            this.radioButtonRemoveEntry.Text = "Remove entry in this program.";
            this.radioButtonRemoveEntry.UseVisualStyleBackColor = true;
            // 
            // radioButtonRemoveBoth
            // 
            this.radioButtonRemoveBoth.AutoSize = true;
            this.radioButtonRemoveBoth.Location = new System.Drawing.Point(6, 65);
            this.radioButtonRemoveBoth.Name = "radioButtonRemoveBoth";
            this.radioButtonRemoveBoth.Size = new System.Drawing.Size(123, 17);
            this.radioButtonRemoveBoth.TabIndex = 2;
            this.radioButtonRemoveBoth.TabStop = true;
            this.radioButtonRemoveBoth.Text = "Remove both folders";
            this.radioButtonRemoveBoth.UseVisualStyleBackColor = true;
            // 
            // radioButtonRemoveCloud
            // 
            this.radioButtonRemoveCloud.AutoSize = true;
            this.radioButtonRemoveCloud.Location = new System.Drawing.Point(6, 42);
            this.radioButtonRemoveCloud.Name = "radioButtonRemoveCloud";
            this.radioButtonRemoveCloud.Size = new System.Drawing.Size(215, 17);
            this.radioButtonRemoveCloud.TabIndex = 1;
            this.radioButtonRemoveCloud.TabStop = true;
            this.radioButtonRemoveCloud.Text = "Restore local folder, remove cloud folder";
            this.radioButtonRemoveCloud.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(103, 208);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(184, 208);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelInfoForm
            // 
            this.labelInfoForm.AutoSize = true;
            this.labelInfoForm.Location = new System.Drawing.Point(9, 9);
            this.labelInfoForm.Name = "labelInfoForm";
            this.labelInfoForm.Size = new System.Drawing.Size(229, 13);
            this.labelInfoForm.TabIndex = 4;
            this.labelInfoForm.Text = "Select which delete action you wish to perform.";
            // 
            // labelSelectedLink
            // 
            this.labelSelectedLink.AutoSize = true;
            this.labelSelectedLink.Location = new System.Drawing.Point(9, 30);
            this.labelSelectedLink.Name = "labelSelectedLink";
            this.labelSelectedLink.Size = new System.Drawing.Size(35, 13);
            this.labelSelectedLink.TabIndex = 5;
            this.labelSelectedLink.Text = "label2";
            // 
            // checkBoxRecursive
            // 
            this.checkBoxRecursive.AutoSize = true;
            this.checkBoxRecursive.Location = new System.Drawing.Point(18, 179);
            this.checkBoxRecursive.Name = "checkBoxRecursive";
            this.checkBoxRecursive.Size = new System.Drawing.Size(225, 17);
            this.checkBoxRecursive.TabIndex = 4;
            this.checkBoxRecursive.Text = "Delete even if it contains files and folders?";
            this.checkBoxRecursive.UseVisualStyleBackColor = true;
            // 
            // FormDelete
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(269, 243);
            this.Controls.Add(this.checkBoxRecursive);
            this.Controls.Add(this.labelSelectedLink);
            this.Controls.Add(this.labelInfoForm);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBoxDeleteOptions);
            this.Name = "FormDelete";
            this.Text = "Delete Action";
            this.Load += new System.EventHandler(this.FormDelete_Load);
            this.groupBoxDeleteOptions.ResumeLayout(false);
            this.groupBoxDeleteOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonRemoveLocal;
        private System.Windows.Forms.GroupBox groupBoxDeleteOptions;
        private System.Windows.Forms.RadioButton radioButtonRemoveBoth;
        private System.Windows.Forms.RadioButton radioButtonRemoveCloud;
        private System.Windows.Forms.RadioButton radioButtonRemoveEntry;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelInfoForm;
        private System.Windows.Forms.Label labelSelectedLink;
        private System.Windows.Forms.CheckBox checkBoxRecursive;
    }
}