using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-enumerate-directories-and-files
//https://marketplace.visualstudio.com/items?itemName=DevartSoftware.CodeCompare

namespace CodeChecker
{
    using System.Diagnostics;
    using System.IO;

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
            HelpIntroText();
        }

        private void HelpIntroText()
        {
            lbxOutput.Items.AddRange(HelpText.IntroText().ToArray());

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
            this.Text = "Path Being searched = " + ExtractFiles.docPath;
            lbxOutput.Items.Add("Searching for File Paths ...");
            await ExtractFiles.ExtractFilePaths().ConfigureAwait(false);

            //output to screen
            Invoke(new Action(() =>
            {
                this.Text = "Found " + ExtractFiles.AllFiles.Count.ToString() + " files at " + ExtractFiles.docPath;

                if (ExtractFiles.AllFiles.Count > 0)
                {
                    lbxOutput.Items.Clear();
                    btnRnPlagCheck.Enabled = true;
                    lbxOutput.Items.Add(this.Text + " Now press Check Files");


                    foreach (var file in ExtractFiles.AllFiles)
                    {
                        lbxOutput.Items.Add(file.Key.ToString());


                    }




                }
            }));
        }
        private void Reset()
        {
            if (ops.FoundMatches.Count > 0 || lbxOutput.Items.Count > 0)
            {
                ops.ScreenResults.Clear();
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


            lbxOutput.Items.Insert(0, "Comparing files ...");

            //runs the Lev method, async to stop it from locking the form to the screen
            await Task.Run(() => ops.RunLev(LevSize, IsContains)).ConfigureAwait(false);

            //https://stackoverflow.com/questions/142003/cross-thread-operation-not-valid-control-accessed-from-a-thread-other-than-the

            //output to screen
            Invoke(new Action(() =>
            {
                lbxOutput.Items.Clear();
                lbxOutput.Items.Insert(0, "Search Completed!");


                if (ops.ScreenResults.Count == 0)
                {
                    lbxOutput.Items.Add("No results");

                }

                if (ExtractFiles.isSameFolder == false)
                {
                    lbxOutput.Items.Add("Try checking the Same Folder TickBox and run Check Files again");
                }


                foreach (var output in ops.ScreenResults)
                {
                    lbxOutput.Items.Add(output.ToString());
                }

                this.Text += "File Path is " + ExtractFiles.docPath;
              
            }));
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
            RBSettings.RadioButtonSettings(fakeCB);

            //only enable the button if there is a file type selected
            if (ExtractFiles.isCSharp || ExtractFiles.isCSS || ExtractFiles.isHTML || ExtractFiles.isJS || ExtractFiles.isGuid)
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


        private void CbxGuid_MouseHover(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(cbxGuid, "Each VS Project has a unique ProjectGuid ID in the .csproj file." + Environment.NewLine + "Lets compare them to see if a project has been copied");

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
            ToolTip.SetToolTip(txtLevSize, "How many changes there are between files. " + Environment.NewLine + "Smaller is more similar, bigger is less." + Environment.NewLine + "Shows how many changes to make one file the same as another ");
        }

        private void BtnOpenDirectory_MouseHover(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(btnOpenDirectory, "Choose a file in the top level of the folders, it will check every subfolder." + Environment.NewLine + " Needs a file to click on." + Environment.NewLine + "This also loads the files, so will need to be done when making changes to checkboxes ");
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
