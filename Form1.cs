﻿using System;
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
        List<string> FoundMatches = new List<string>();
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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

                    docPath = Path.GetDirectoryName(ofd.FileName);
                }
            }
        }
        private void BtnPlagarism_Click(object sender, EventArgs e)
        {
            if (FoundMatches.Count > 0)
            {
                FoundMatches.Clear();
            }
            lbxOutput.Items.Clear();
            //   
            this.Text = docPath;
            GetAllFiles();
        }

        private void GetAllFiles()
        {
            int LevSize = Convert.ToInt32(txtLevSize.Text);
            List<double> LEVDistance = new List<double>();

            //files and their contents added to the dictionary
            Dictionary<string, string> AllFiles = new Dictionary<string, string>();
            //holds a record of found matches to stop them appearing twice
            List<string> FoundMatches = new List<string>();
            int count = 0;

            var Lev = new Levenshtein();
            try
            {
                var files = Directory.EnumerateFiles(docPath, "*.cs", SearchOption.AllDirectories);

                foreach (var f in files)
                {
                    //filter the folders from the path
                    if (!f.Contains("Debug") && !f.Contains(".vs") && !f.Contains("packages") && !f.Contains("obj") && !f.Contains("Properties") && !f.Contains("Resources") && !f.Contains("Program.cs"))
                    {
                        string text = File.ReadAllText(f).ToLower();

                        //filter the file content
                        if (!string.IsNullOrEmpty(text) && !text.Contains("<auto-generated>"))
                        {
                            AllFiles.Add(f, text);
                            //  lbxOutput.Items.Add(f);
                        }
                    }
                }


                foreach (var text in AllFiles)
                {
                    //need this to stop it crashing
                    System.Threading.Thread.CurrentThread.Join(10);

                    //get a short path without the filename
                    int LastSlashText1 = text.Key.Length - text.Key.LastIndexOf(@"\");
                    string ShortText1 = text.Key.Substring(0, text.Key.Length - LastSlashText1);

                    foreach (var text2 in AllFiles)
                    {
                        //get a short path without the filename
                        int LastSlashText2 = text2.Key.Length - text2.Key.LastIndexOf(@"\");
                        string ShortText2 = text2.Key.Substring(0, text2.Key.Length - LastSlashText2);

                        //short string to appear in file? on screen
                        string textShort1 = text.Key.Substring(text.Key.LastIndexOf(@"\") - 25);

                        //only compare files where the path is not exactly the same so we don't have the same person. && Don't run matches that have already been done
                        if (ShortText1 != ShortText2 && !FoundMatches.Contains(text.Key + text2.Key))

                        {//add the keys in reverse order so we can check them later (or earlier)
                            FoundMatches.Add(text2.Key + text.Key);

                            double levDist = Lev.Distance(text.Value, text2.Value);

                            this.Text = "Similar File Matches found ... " + count + " of Total files " + AllFiles.Count + " ... now checking similarity ... " + levDist.ToString();

                            if (levDist < LevSize)
                            {
                                count++;

                                //short string to appear in file? on screen
                                string textShort2 = text2.Key.Substring(text2.Key.LastIndexOf(@"\") - 25);

                                lbxOutput.Items.Add(levDist.ToString() + "  -- " + textShort1 + " --  -- " + textShort2);

                                FoundMatches.Add(levDist.ToString() + " | " + text.Key + " --  -- " + text2.Key);
                            }

                        }
                    }
                }
                //output to screen
                //  lbxOutput.Items.Insert(0, "Matches will Appear TWICE");
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

        private void BtnPrint_Click(object sender, EventArgs e)
        {

            string PathTitle = "PlagarismMatches.txt";

            string path = Directory.GetCurrentDirectory();
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealllines?view=netframework-4.7.2
            File.WriteAllLines(Path.Combine(docPath, PathTitle), FoundMatches);

            MessageBox.Show("File printed to Desktop " + PathTitle);

        }


    }



}
