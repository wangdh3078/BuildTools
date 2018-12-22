using Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SelectDirectory_Click(object sender, EventArgs e)
        {
            //指定folder根=桌面
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            //是否添加新建文件夹的按钮
            folderBrowserDialog.ShowNewFolderButton = true;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Path.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NewProjectName.Text))
            {
                MessageBox.Show("请输入新项目名称");
                return;
            }
            if (string.IsNullOrEmpty(Path.Text))
            {
                MessageBox.Show("请选择项目保存位置");
                return;
            }
            var templatePath = AppDomain.CurrentDomain.BaseDirectory + "/Template";
            try
            {
                Btn_Create.Text = "生成中...";

                Task task = Task.Run(() =>
                  {
                      ZipHelper.UnZipFile(AppDomain.CurrentDomain.BaseDirectory + "/Template.zip", AppDomain.CurrentDomain.BaseDirectory, string.Empty, true);
                      FileHelper.FindAllFiles(templatePath);
                  });

                Task task2 = task.ContinueWith(t =>
                {
                    FileHelper.CreateNewProject(Path.Text, NewProjectName.Text, templatePath, IsDelete.Checked);
                });
                task2.Wait();
                MessageBox.Show("创建成功");
                //ZipHelper.CompressFile(Path.Text, AppDomain.CurrentDomain.BaseDirectory + "/ZIP/"+ NewProjectName.Text+".zip");
                Directory.Delete(templatePath, true);
                if (openNewFolder.Checked)
                {
                    Process.Start("explorer.exe", Path.Text);
                }
            }
            catch (Exception ex)
            {
                Directory.Delete(templatePath, true);
                MessageBox.Show(ex.Message);
            }
            Btn_Create.Text = "创建新项目";
        }
    }
}
