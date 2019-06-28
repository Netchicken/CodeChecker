using System;
using System.Collections.Generic;
using System.IO;

namespace CodeChecker
{
    using F23.StringSimilarity;
    using System.Diagnostics;

    public class Operation
    {
        public string ShowTestingPaths { get; set; }

        public string Text { get; set; }
        public string Text2 { get; set; }
        //files and their contents added to the dictionary

        public List<string> FoundMatches = new List<string>();

        public List<string> ScreenResults = new List<string>();

        public void RunLev(int LevSize, Boolean IsContains)
        {
            List<double> LEVDistance = new List<double>();

            //holds a record of  matches to stop them appearing twice
            List<string> NotRepeatingMatches = new List<string>();
            int count = 0;
            var Lev = new Levenshtein();
            try
            {
                foreach (var text1 in ExtractFiles.AllFiles)
                {


                    //get a short path without the filename for path comparisons
                    string FolderPathNoFile1 = GetShortPath(text1.Key);
                    //short string to appear in file on screen

                    foreach (var text2 in ExtractFiles.AllFiles)
                    {//everything wrapped in this to check that we haven't compared these two files before in this loop
                        //only check files with same suffix
                        if (GetFileType(text1.Key) == GetFileType(text2.Key) && !NotRepeatingMatches.Contains(text1.Key + text2.Key))
                        {
                            //need this to stop it crashing
                            System.Threading.Thread.CurrentThread.Join(10);

                            //    ShowTestingPaths = text1 + " " + text2;

                            //get shorttext to stop files in same path being checked 
                            string FolderPathNoFile2 = GetShortPath(text2.Key);

                            //if I want to compare files in the same folder then shorttext comparison must be FALSE so it thinks they are different folders
                            if (ExtractFiles.isSameFolder)
                            {
                                FolderPathNoFile2 = "Some Random value to fool checker thats its a different file";
                            }

                            if (IsContains) //do it here so it only runs when contains = true and doesn't slow down loop
                            {
                                count = CheckIfContainsTrue(text1, text2, FolderPathNoFile1,
                                    FolderPathNoFile2, count);
                            }


                            //only compare files where the path is not exactly the same so we don't have the same person. && Don't run matches that have already been done
                            if ((text1.Key != text2.Key) && !NotRepeatingMatches.Contains(text1.Key + text2.Key) && (FolderPathNoFile1 != FolderPathNoFile2))
                            {
                                double levDist = Lev.Distance(text1.Value, text2.Value);

                                if (levDist < LevSize)
                                {
                                    count++;

                                    ScreenResults.Add(levDist.ToString() + "  -- " + GetShortPathWithFileName(text1.Key) + " --  -- " + GetShortPathWithFileName(text2.Key));

                                    FoundMatches.Add(levDist.ToString() + " | " + text1.Key + " -- MATCHES WITH  -- " + text2.Key + Environment.NewLine + Environment.NewLine);
                                }
                            }
                            //add the keys in reverse order so we can check them later (or earlier)to filter out matches that have been done
                            NotRepeatingMatches.Add(text2.Key + text1.Key);
                        }
                    }

                }
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
        /// <summary>
        /// Runs if the Contains = true
        /// </summary>
        private int CheckIfContainsTrue(KeyValuePair<string, string> text1, KeyValuePair<string, string> text2, string FolderPathNoFile1,
             string FolderPathNoFile2, int count)
        {
            //need to do contains before the rest as we stop repeats with NotRepeatingMatches
            Boolean TContainsT2 = false;
            Boolean T2ContainsT = false;

            //do it here so it only runs when contains = true and doesn't slow down loop
            TContainsT2 = text1.Value.Contains(text2.Value);
            T2ContainsT = text2.Value.Contains(text1.Value);

            if ((text1.Key != text2.Key) && (TContainsT2 || T2ContainsT) &&
                (FolderPathNoFile1 != FolderPathNoFile2))
            {
                count++;

                // ScreenResults.Add("Contains Text  -- " + GetShortPathWithFileName(text1.Key) + " --  -- " + GetShortPathWithFileName(text2.Key));

                FoundMatches.Add("Contains Text  | " + text1.Key + " -- MATCHES WITH  -- " + text2.Key + @"\n\n");
            }
            return count;
        }

        /// <summary>
        /// Short path without file name used to check if the files come from the same folder
        /// </summary>
        private string GetShortPath(string text)
        {
            //get a short path without the filename for path comparisons
            int LastSlashText1 = text.Length - text.LastIndexOf(@"\");
            return text.Substring(0, text.Length - LastSlashText1);

        }
        /// <summary>
        /// Short string to appear on screen with file name but beginning truncated
        /// </summary>
        private string GetShortPathWithFileName(string text)
        {
            return text.Substring(text.LastIndexOf(@"\")); //- 25
        }
        private string GetFileType(string text)
        {
            return text.Substring(text.LastIndexOf(@"."));
        }


        /// <summary>
        /// Print out the data 
        /// </summary>
        public string PrintResults()
        {
            try
            {
                string PathTitle = "Plagarism-Matches.txt";

                string path = Directory.GetCurrentDirectory();
                string docPath =
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealllines?view=netframework-4.7.2
                File.WriteAllLines(Path.Combine(docPath, PathTitle), FoundMatches);

                return " File Printed look for Plagarism-Matches.txt on desktop";
            }
            catch (Exception e)
            {
                return " File not printed error" + e;
            }

        }

        public double GetProcesses()
        {
            // Get all instances of Notepad running on the local computer.
            // This will return an empty array if notepad isn't running.
            // Process[] localByName = Process.GetProcessesByName("CodeChecker");


            var memory = 0.0;
            using (Process proc = Process.GetCurrentProcess())
            {
                // The proc.PrivateMemorySize64 will returns the private memory usage in byte.
                // Would like to Convert it to Megabyte? divide it by 1e+6
                memory = proc.PrivateMemorySize64 / 1e+6;
            }
            return memory;
        }


    }
}
