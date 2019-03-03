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
    using System.Diagnostics;
    using System.IO;
    using Standard;

    public partial class Form1 : Form
    {
        Operation ops = new Operation();

        //https://stackoverflow.com/questions/750574/how-to-get-memory-available-or-used-in-c-sharp/750595#750595
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;

        public Form1()
        {
            InitializeComponent();
            InitialiseCPUCounter();
            InitializeRAMCounter();
            updateTimer.Start();
            lbxOutput.Items.Add("Choose a single or multiple file type first (Bottom Left)");
            lbxOutput.Items.Add("");
            lbxOutput.Items.Add("If you want to check files that are in the SAME folder");
            lbxOutput.Items.Add("Check the Same Folder checkbox - good if you just have a bunch of single files");
            lbxOutput.Items.Add("");
            lbxOutput.Items.Add("If you want to check if one file is contained in another file");
            lbxOutput.Items.Add("Check the Contains Files checkbox - this might not be useful");
            lbxOutput.Items.Add("");
            lbxOutput.Items.Add("Then click on Find Files. - This wants to open a file (naturally enough)");
            lbxOutput.Items.Add("But there is no such thing as a Find Folder tool and we want a FOLDER");
            lbxOutput.Items.Add("So click on a file IN THE FOLDER THAT YOU WANT THE SEARCH TO START");
            lbxOutput.Items.Add("If there isn't a file, just right click New => Text Document then click on that");
            lbxOutput.Items.Add("");
            lbxOutput.Items.Add("The indexer will search from that folder through every subfolder in the tree");
            lbxOutput.Items.Add("");
            lbxOutput.Items.Add("Then click Check Files to run the checker");
            lbxOutput.Items.Add("There is a CPU meter bottom right to let you know that its still alive");
            lbxOutput.Items.Add("");
            lbxOutput.Items.Add("When finished you will see a truncated version on the screen - here.");
            lbxOutput.Items.Add("Print it to see the entire path of the files in a txt file saved to the Desktop.");

        }

        private async void BtnOpenDirectory_Click(object sender, EventArgs e)
        {
            //clears out old entries
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
            lbxOutput.Items.Add("Searching for File Paths ...");
            await ExtractFiles.ExtractFilePaths().ConfigureAwait(false);

            //output to screen
            Invoke(new Action(() =>
            {
                this.Text = "Found " + ExtractFiles.AllFiles.Count.ToString() + " files";

                if (ExtractFiles.AllFiles.Count > 0)
                {
                    lbxOutput.Items.Clear();
                    btnRnPlagCheck.Enabled = true;
                    lbxOutput.Items.Add(this.Text);
                }
            }));
        }
        private void Reset()
        {
            if (ops.FoundMatches.Count > 0 || lbxOutput.Items.Count > 0)
            {
                ops.FoundMatches.Clear();
                //  ExtractFiles.AllFiles.Clear();
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
            lbxOutput.Items.Insert(0, "Comparing files ...");

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
            Reset();
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

        private void CbxSameFolder_MouseHover(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(cbxSameFolder, "Compare files in the same folder");

        }

        private void CbxContains_MouseHover(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(cbxContains, "Checks if one file is contained in another file - experimental");
        }

        private void TxtLevSize_MouseHover(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(txtLevSize, "Smaller is more similar, bigger is less." + Environment.NewLine + "Shows how many changes to make one file the same as another ");
        }

        private void BtnOpenDirectory_MouseHover(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(btnOpenDirectory, "Choose a file in the top level of the folders, it will check every subfolder. Needs a file to click on." + Environment.NewLine + "This also loads the files, so will need to be done when making changes to checkboxes ");
        }

        private void BtnRnPlagCheck_MouseHover(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(btnRnPlagCheck, "For large numbers of files leave this program open and make a coffee. " + Environment.NewLine + "It's working hard ");
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            lblCPU.Text = "CPU " + Convert.ToInt32(cpuCounter.NextValue()).ToString() + "%";

            lblRamCounter.Text = Convert.ToInt32(ramCounter.NextValue()).ToString() + " Mb";
        }

        //https://stackoverflow.com/questions/51392374/performancecounter-cpu-memory-like-task-manager

        private void InitialiseCPUCounter()
        {
            cpuCounter = new PerformanceCounter(
                "Processor",
                "% Processor Time",
                "_Total",
                true
            );
        }

        private void InitializeRAMCounter()
        {
            ramCounter = new PerformanceCounter(
                "Memory",
                "Available MBytes",
                true);

        }




    }



}
