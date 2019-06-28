using System.Windows.Forms;

namespace CodeChecker
{
    public static class RBSettings
    {
        public static void RadioButtonSettings(CheckBox fakeCB)
        {
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
                    case "ProjectGuid Number":
                        ExtractFiles.isGuid = true;
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
                    case "ProjectGuid Number":
                        ExtractFiles.isGuid = false;
                        break;
                }
            }
        }
    }
}