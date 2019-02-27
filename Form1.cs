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


        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnOpenDirectory_Click(object sender, EventArgs e)
        {
            //clears out old entries
            // ops = new Operation();
            ExtractFiles.AllFiles.Clear();
            Reset();

            MessageBox.Show("Click on a File in the Folder that holds all the assessments to get the path");

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(ofd.FileName))
                { //https://stackoverflow.com/questions/439007/extracting-path-from-openfiledialog-path-filename

                    // ops.docPath = Path.GetDirectoryName(ofd.FileName);
                    ExtractFiles.docPath = Path.GetDirectoryName(ofd.FileName);
                }
            }
            this.Text = ExtractFiles.docPath;
            await ExtractFiles.ExtractFilePaths().ConfigureAwait(false);

            this.Text = "Found " + ExtractFiles.AllFiles.Count.ToString() + " files";

            if (ExtractFiles.AllFiles.Count > 0)
            {
                btnRnPlagCheck.Enabled = true;
            }
        }
        private void Reset()
        {
            if (ops.FoundMatches.Count > 0 || lbxOutput.Items.Count > 0)
            {
                ops.FoundMatches.Clear();
                ExtractFiles.AllFiles.Clear();
                lbxOutput.Items.Clear();
            }
        }
        //run the plagarism checker
        private async void BtnPlagarism_Click(object sender, EventArgs e)
        {

            Reset();
            int LevSize = Convert.ToInt32(txtLevSize.Text);
            Boolean IsContains = ExtractFiles.isIncluded; //cbxContains.Checked;

            this.Text += " - Be patient, its big ...or your machine is slow";

            //"Similar File Matches found ... " + count + " of Total files " + AllFiles.Count + " ... now checking similarity ... " + levDist.ToString();



            // RunGetAllFilesAysnc(LevSize, IsContains);
            lbxOutput.Items.Insert(0, "Searching ...");

            await Task.Run(() => ops.RunLev(LevSize, IsContains)).ConfigureAwait(false);

            //https://stackoverflow.com/questions/142003/cross-thread-operation-not-valid-control-accessed-from-a-thread-other-than-the

            //output to screen
            Invoke(new Action(() =>
            {
                lbxOutput.Items.Clear();
                lbxOutput.Items.Insert(0, "Search Completed!");
                lbxOutput.Items.AddRange(ops.ScreenResults.ToArray());
            }));
        }

        //runs the Lev method, async to stop it from locking the form to the screen
        private async Task RunGetAllFilesAysnc(int LevSize, bool IsContains)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.run?view=netframework-4.7.2

            await Task.Run(() => ops.RunLev(LevSize, IsContains)).ConfigureAwait(false);
            lbxOutput.Items.Insert(0, "Searching ...");

            // Task.Wait();

        }


        private void BtnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ops.PrintResults());
        }

        private void All_CheckedChanged(object sender, EventArgs e)
        {//generate a fake checkbox
            CheckBox fakeCB = new CheckBox();
            //pass across the data from the activated checkbox
            fakeCB = (CheckBox)sender;
            //check if its true
            if (fakeCB.Checked == true)
            {
                switch (fakeCB.Text)
                {
                    case "HTML":
                        ExtractFiles.isHTML = true;
                        break;
                    case "JS":
                        ExtractFiles.isJS = true;
                        break;
                    case "CSS":
                        ExtractFiles.isCSS = true;
                        break;
                    case "CSharp":
                        ExtractFiles.isCSharp = true;
                        break;
                    case "Contains Files":
                        ExtractFiles.isIncluded = true;
                        break;
                    case "Same Folder":
                        ExtractFiles.isSameFolder = true;
                        break;
                }


            }
            else if (fakeCB.Checked == false)
            {
                switch (fakeCB.Text)
                {
                    case "HTML":
                        ExtractFiles.isHTML = false;
                        break;
                    case "JS":
                        ExtractFiles.isJS = false;
                        break;
                    case "CSS":
                        ExtractFiles.isCSS = false;
                        break;
                    case "CSharp":
                        ExtractFiles.isCSharp = false;
                        break;
                    case "Contains Files":
                        ExtractFiles.isIncluded = false;
                        break;
                    case "Same Folder":
                        ExtractFiles.isSameFolder = false;
                        break;
                }


            }

            //only enable the button if there is a file type selected
            if (ExtractFiles.isCSharp || ExtractFiles.isCSS || ExtractFiles.isHTML || ExtractFiles.isJS)
            {
                //   btnRnPlagCheck.Enabled = true;
                btnOpenDirectory.Enabled = true;
            }
            else
            {
                //  btnRnPlagCheck.Enabled = false;
                btnOpenDirectory.Enabled = false;
                MessageBox.Show("Enable a file type checkbox first");
            }

        }
    }



}
