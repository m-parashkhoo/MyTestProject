using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _951017dey_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void DisplayDirectoriesAndFies()
        {
            if (string.IsNullOrWhiteSpace(txtPath.Text))
            {
                System.Windows.Forms.MessageBox.Show(text: "آدرس صحیح نمی باشد!.",
                  caption: "خطا",
                  buttons: MessageBoxButtons.OK,
                  icon: MessageBoxIcon.Error,
                  defaultButton: MessageBoxDefaultButton.Button1,
                  options: MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                txtPath.Focus();
                return;
            }




            System.IO.DirectoryInfo oDirectoryInfo =
                new System.IO.DirectoryInfo(path: txtPath.Text);


            txtPath.Text =
                txtPath.Text.Trim();

            listBoxDirectorys.Items.Clear();

            if (txtPath.Text.Length > 3)
            {
                listBoxDirectorys.Items.Add("..");
            }

            foreach (System.IO.DirectoryInfo oDirectory in oDirectoryInfo.GetDirectories())
            {
                listBoxDirectorys.Items.Add(oDirectory.Name);
            }

            listBoxFiles.Items.Clear();

            foreach (System.IO.FileInfo oFiles in oDirectoryInfo.GetFiles())
            {
                listBoxFiles.Items.Add(oFiles.Name);
            }





        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DisplayDirectoriesAndFies();
        }

        private void listBoxDirectorys_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxDirectorys.SelectedItem != null)
            {
                if (listBoxDirectorys.SelectedItem.ToString() != "..")
                {
                    txtPath.Text =
                        string.Format(@"{0}\{1}", txtPath.Text, listBoxDirectorys.SelectedItem);
                }
                else
                {
                    int intIndex = txtPath.Text.LastIndexOf("\\");
                    txtPath.Text =
                        txtPath.Text.Substring(startIndex: 0, length: intIndex);
                }

                DisplayDirectoriesAndFies();
            }

        }
    }
}
