namespace FolderToCloud.UserInterface
{
    partial class FormAdd
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
            this.labelLocalInfo = new System.Windows.Forms.Label();
            this.textBoxLocal = new System.Windows.Forms.TextBox();
            this.folderBrowserDialogAdd = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonBrowseLocal = new System.Windows.Forms.Button();
            this.labelCloudInfo = new System.Windows.Forms.Label();
            this.textBoxCloud = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonBrowseCloud = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLocalInfo
            // 
            this.labelLocalInfo.AutoSize = true;
            this.labelLocalInfo.Location = new System.Drawing.Point(12, 9);
            this.labelLocalInfo.Name = "labelLocalInfo";
            this.labelLocalInfo.Size = new System.Drawing.Size(58, 13);
            this.labelLocalInfo.TabIndex = 0;
            this.labelLocalInfo.Text = "Local Path";
            // 
            // textBoxLocal
            // 
            this.textBoxLocal.AllowDrop = true;
            this.textBoxLocal.Location = new System.Drawing.Point(77, 6);
            this.textBoxLocal.Name = "textBoxLocal";
            this.textBoxLocal.Size = new System.Drawing.Size(374, 20);
            this.textBoxLocal.TabIndex = 1;
            // 
            // buttonBrowseLocal
            // 
            this.buttonBrowseLocal.Location = new System.Drawing.Point(457, 6);
            this.buttonBrowseLocal.Name = "buttonBrowseLocal";
            this.buttonBrowseLocal.Size = new System.Drawing.Size(75, 20);
            this.buttonBrowseLocal.TabIndex = 2;
            this.buttonBrowseLocal.Text = "Browse";
            this.buttonBrowseLocal.UseVisualStyleBackColor = true;
            // 
            // labelCloudInfo
            // 
            this.labelCloudInfo.AutoSize = true;
            this.labelCloudInfo.Location = new System.Drawing.Point(12, 35);
            this.labelCloudInfo.Name = "labelCloudInfo";
            this.labelCloudInfo.Size = new System.Drawing.Size(59, 13);
            this.labelCloudInfo.TabIndex = 3;
            this.labelCloudInfo.Text = "Cloud Path";
            // 
            // textBoxCloud
            // 
            this.textBoxCloud.AllowDrop = true;
            this.textBoxCloud.Location = new System.Drawing.Point(77, 32);
            this.textBoxCloud.Name = "textBoxCloud";
            this.textBoxCloud.Size = new System.Drawing.Size(374, 20);
            this.textBoxCloud.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(376, 58);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(295, 58);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonBrowseCloud
            // 
            this.buttonBrowseCloud.Location = new System.Drawing.Point(457, 31);
            this.buttonBrowseCloud.Name = "buttonBrowseCloud";
            this.buttonBrowseCloud.Size = new System.Drawing.Size(75, 20);
            this.buttonBrowseCloud.TabIndex = 4;
            this.buttonBrowseCloud.Text = "Browse";
            this.buttonBrowseCloud.UseVisualStyleBackColor = true;
            // 
            // FormAdd
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(570, 91);
            this.Controls.Add(this.buttonBrowseCloud);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxCloud);
            this.Controls.Add(this.labelCloudInfo);
            this.Controls.Add(this.buttonBrowseLocal);
            this.Controls.Add(this.textBoxLocal);
            this.Controls.Add(this.labelLocalInfo);
            this.Name = "FormAdd";
            this.Text = "FormAdd";
            this.Load += new System.EventHandler(this.FormAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLocalInfo;
        private System.Windows.Forms.TextBox textBoxLocal;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogAdd;
        private System.Windows.Forms.Button buttonBrowseLocal;
        private System.Windows.Forms.Label labelCloudInfo;
        private System.Windows.Forms.TextBox textBoxCloud;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonBrowseCloud;
    }
}