using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using F23.StringSimilarity;
//https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-enumerate-directories-and-files
//https://marketplace.visualstudio.com/items?itemName=DevartSoftware.CodeCompare

namespace CodeChecker
{
    using System.IO;
    using Standard;

    public partial class Form1 : Form
    {
        Operation ops = new Operation();


        //   List<string> FoundMatches = new List<string>();
        // string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOpenDirectory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click on a File in the Folder that holds all the assessments to get the path");

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(ofd.FileName))
                { //https://stackoverflow.com/questions/439007/extracting-path-from-openfiledialog-path-filename

                    ops.docPath = Path.GetDirectoryName(ofd.FileName);
                }
            }
        }
        private async void BtnPlagarism_Click(object sender, EventArgs e)
        {

            if (ops.FoundMatches.Count > 0)
            {
                ops.FoundMatches.Clear();

            }
            ops.AllFiles.Clear();
            lbxOutput.Items.Clear();
            //   
            this.Text = ops.docPath;
            int LevSize = Convert.ToInt32(txtLevSize.Text);
            Boolean IsContains = cbxContains.Checked;

            this.Text = "Working ... be patient, its big ...or your machine is slow";

            //"Similar File Matches found ... " + count + " of Total files " + AllFiles.Count + " ... now checking similarity ... " + levDist.ToString();



            // RunGetAllFilesAysnc(LevSize, IsContains);
            lbxOutput.Items.Insert(0, "Searching ...");

            await Task.Run(() => ops.GetAllFiles(LevSize, IsContains)).ConfigureAwait(false);

            //https://stackoverflow.com/questions/142003/cross-thread-operation-not-valid-control-accessed-from-a-thread-other-than-the

            //output to screen
            Invoke(new Action(() =>
            {
                lbxOutput.Items.Clear();
                lbxOutput.Items.Insert(0, "Search Completed!");
                lbxOutput.Items.AddRange(ops.ScreenResults.ToArray());
            }));






        }

        private async Task RunGetAllFilesAysnc(int LevSize, bool IsContains)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.run?view=netframework-4.7.2

            await Task.Run(() => ops.GetAllFiles(LevSize, IsContains)).ConfigureAwait(false);
            lbxOutput.Items.Insert(0, "Searching ...");

            // Task.Wait();

        }


        private void BtnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ops.PrintResults());
        }


    }



}
