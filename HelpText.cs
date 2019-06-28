using System.Collections.Generic;

namespace CodeChecker
{
    public static class HelpText
    {
        private static List<string> HelpIntro = new List<string>();

        public static IEnumerable<string> IntroText()
        {
            HelpIntro.Add("Choose a single or multiple file type first (Bottom Left)");
            HelpIntro.Add("");
            HelpIntro.Add("If you want to check files that are in the SAME folder");
            HelpIntro.Add("Check the Same Folder checkbox - good if you just have a bunch of single files");
            HelpIntro.Add("");
            HelpIntro.Add("If you want to check if one file is contained in another file");
            HelpIntro.Add("Check the Contains Files checkbox - this might not be useful");
            HelpIntro.Add("");
            HelpIntro.Add(
                "Then click on Find Files. - This wants to open a file (naturally enough) and we want a Folder");
            HelpIntro.Add("But there is no such thing as a Find Folder tool");
            HelpIntro.Add("So click on a file IN THE FOLDER THAT YOU WANT THE SEARCH TO START");
            HelpIntro.Add("If there isn't a file, just right click New => Text Document then click on that");
            HelpIntro.Add("");
            HelpIntro.Add("The indexer will search from that folder through every subfolder in the tree");
            HelpIntro.Add("");
            HelpIntro.Add("Then click Check Files to run the checker");
            HelpIntro.Add("There is a CPU meter bottom right to let you know that its still alive");
            HelpIntro.Add("");
            HelpIntro.Add("When finished you will see a truncated version on the screen - here.");
            HelpIntro.Add("Print it to see the entire path of the files in a txt file saved to the Desktop.");

            return HelpIntro;
        }
    }
}