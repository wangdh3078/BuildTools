namespace Generator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Path = new System.Windows.Forms.TextBox();
            this.SelectDirectory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.NewProjectName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IsDelete = new System.Windows.Forms.CheckBox();
            this.Btn_Create = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.openNewFolder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择保存路径：";
            // 
            // Path
            // 
            this.Path.Enabled = false;
            this.Path.Location = new System.Drawing.Point(149, 76);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(230, 21);
            this.Path.TabIndex = 1;
            // 
            // SelectDirectory
            // 
            this.SelectDirectory.Location = new System.Drawing.Point(385, 74);
            this.SelectDirectory.Name = "SelectDirectory";
            this.SelectDirectory.Size = new System.Drawing.Size(75, 23);
            this.SelectDirectory.TabIndex = 2;
            this.SelectDirectory.Text = "选择";
            this.SelectDirectory.UseVisualStyleBackColor = true;
            this.SelectDirectory.Click += new System.EventHandler(this.SelectDirectory_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "项目名称：";
            // 
            // NewProjectName
            // 
            this.NewProjectName.Location = new System.Drawing.Point(149, 34);
            this.NewProjectName.Name = "NewProjectName";
            this.NewProjectName.Size = new System.Drawing.Size(230, 21);
            this.NewProjectName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "删除路径下现有文件：";
            // 
            // IsDelete
            // 
            this.IsDelete.AutoSize = true;
            this.IsDelete.Checked = true;
            this.IsDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsDelete.Location = new System.Drawing.Point(150, 124);
            this.IsDelete.Name = "IsDelete";
            this.IsDelete.Size = new System.Drawing.Size(48, 16);
            this.IsDelete.TabIndex = 6;
            this.IsDelete.Text = "删除";
            this.IsDelete.UseVisualStyleBackColor = true;
            // 
            // Btn_Create
            // 
            this.Btn_Create.Location = new System.Drawing.Point(175, 199);
            this.Btn_Create.Name = "Btn_Create";
            this.Btn_Create.Size = new System.Drawing.Size(92, 28);
            this.Btn_Create.TabIndex = 7;
            this.Btn_Create.Text = "创建新项目";
            this.Btn_Create.UseVisualStyleBackColor = true;
            this.Btn_Create.Click += new System.EventHandler(this.Btn_Create_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "生成后打开项目文件夹：";
            // 
            // openNewFolder
            // 
            this.openNewFolder.AutoSize = true;
            this.openNewFolder.Checked = true;
            this.openNewFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openNewFolder.Location = new System.Drawing.Point(150, 166);
            this.openNewFolder.Name = "openNewFolder";
            this.openNewFolder.Size = new System.Drawing.Size(36, 16);
            this.openNewFolder.TabIndex = 9;
            this.openNewFolder.Text = "是";
            this.openNewFolder.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 245);
            this.Controls.Add(this.openNewFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Btn_Create);
            this.Controls.Add(this.IsDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NewProjectName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectDirectory);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "创建新项目";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Button SelectDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NewProjectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox IsDelete;
        private System.Windows.Forms.Button Btn_Create;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox openNewFolder;
    }
}

