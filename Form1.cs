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
        private void BtnPlagarism_Click(object sender, EventArgs e)
        {
            if (ops.FoundMatches.Count > 0)
            {
                ops.FoundMatches.Clear();
            }
            lbxOutput.Items.Clear();
            //   
            this.Text = ops.docPath;
            int LevSize = Convert.ToInt32(txtLevSize.Text);
            Boolean IsContains = cbxContains.Checked;
            GetAllFiles(LevSize, IsContains);
        }

        private void GetAllFiles(int LevSize, Boolean IsContains)
        {

            List<double> LEVDistance = new List<double>();

            //files and their contents added to the dictionary
            //  Dictionary<string, string> AllFiles = new Dictionary<string, string>();
            //holds a record of  matches to stop them appearing twice
            List<string> NotRepeatingMatches = new List<string>();
            int count = 0;

            var Lev = new Levenshtein();
            try
            {
                ops.ExtractFilePaths();


                foreach (var text in ops.AllFiles)
                {
                    //need this to stop it crashing
                    System.Threading.Thread.CurrentThread.Join(10);

                    //get a short path without the filename
                    int LastSlashText1 = text.Key.Length - text.Key.LastIndexOf(@"\");
                    string ShortText1 = text.Key.Substring(0, text.Key.Length - LastSlashText1);

                    foreach (var text2 in ops.AllFiles)
                    {
                        //get a short path without the filename
                        int LastSlashText2 = text2.Key.Length - text2.Key.LastIndexOf(@"\");
                        string ShortText2 = text2.Key.Substring(0, text2.Key.Length - LastSlashText2);

                        //short string to appear in file? on screen
                        string textShort1 = text.Key.Substring(text.Key.LastIndexOf(@"\") - 25);

                        //need to do contains before the rest as we stop repeats with NotRepeatingMatches
                        Boolean TContainsT2 = false;
                        Boolean T2ContainsT = false;
                        if (IsContains) //do it here so it only runs when contains = true and doesn't slow down loop
                        {
                            TContainsT2 = text.Value.Contains(text2.Value);
                            T2ContainsT = text2.Value.Contains(text.Value);
                        }

                        if (IsContains && (text.Key != text2.Key) && (TContainsT2 || T2ContainsT))
                        {
                            count++;

                            //short string to appear in file? on screen
                            string textShort2 = text2.Key.Substring(text2.Key.LastIndexOf(@"\") - 25);

                            lbxOutput.Items.Add("Contains Text  -- " + textShort1 + " --  -- " + textShort2);

                            ops.FoundMatches.Add("Contains Text  | " + text.Key + " -- MATCHES WITH  -- " + text2.Key + @"\n\n");
                        }




                        //only compare files where the path is not exactly the same so we don't have the same person. && Don't run matches that have already been done
                        if ((text.Key != text2.Key) && !NotRepeatingMatches.Contains(text.Key + text2.Key))

                        //ShortText1 != ShortText2 &&


                        {//add the keys in reverse order so we can check them later (or earlier)
                            NotRepeatingMatches.Add(text2.Key + text.Key);

                            double levDist = Lev.Distance(text.Value, text2.Value);

                            this.Text = "Similar File Matches found ... " + count + " of Total files " + ops.AllFiles.Count + " ... now checking similarity ... " + levDist.ToString();

                            if (levDist < LevSize)
                            {
                                count++;

                                //short string to appear in file? on screen
                                string textShort2 = text2.Key.Substring(text2.Key.LastIndexOf(@"\") - 25);

                                lbxOutput.Items.Add(levDist.ToString() + "  -- " + textShort1 + " --  -- " + textShort2);

                                ops.FoundMatches.Add(levDist.ToString() + " | " + text.Key + " -- MATCHES WITH  -- " + text2.Key + @"\n\n");
                            }

                        }
                    }
                }
                //output to screen
                lbxOutput.Items.Insert(0, "Search Completed!");
                //   lbxOutput.Items.AddRange(FoundMatches.ToArray());

            }
            catch (UnauthorizedAccessException uAEx)
            {
                Console.WriteLine(uAEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                Console.WriteLine(pathEx.Message);
            }
        }

        public void ExtractFilePaths(Dictionary<string, string> AllFiles)
        {
            var files = Directory.EnumerateFiles(ops.docPath, "*.cs", SearchOption.AllDirectories);

            foreach (var f in files)
            {
                //filter the folders from the path
                if (!f.Contains("Debug") && !f.Contains(".vs") && !f.Contains("packages") && !f.Contains("obj") &&
                    !f.Contains("Properties") && !f.Contains("Resources") && !f.Contains("Program.cs"))
                {
                    string text = File.ReadAllText(f).ToLower();

                    //filter the file content
                    if (!string.IsNullOrEmpty(text) && !text.Contains("<auto-generated>"))
                    {
                        AllFiles.Add(f, text);
                    }
                }
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {

            string PathTitle = "PlagarismMatches.txt";

            string path = Directory.GetCurrentDirectory();
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealllines?view=netframework-4.7.2
            File.WriteAllLines(Path.Combine(docPath, PathTitle), ops.FoundMatches);

            MessageBox.Show("File printed to Desktop " + PathTitle);

        }


    }



}
