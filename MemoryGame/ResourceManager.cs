using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    //Get Appdata folder (when? on startup? Constructor of this class?),
    // store in user.config or something
    //Note that I may need to add some assembly info (company name, etc)
    //make method that copies assets into appdata folder (hopefully with subfolders)
    //method that takes string of name of subfolder (animals, cars food),
    // checks if folder and assets exist, then returns folder path
    class ResourceManager
    {
        public ResourceManager()
        {
            
        }

        private readonly string OutputDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"MemoryGame");

        private void SaveAssetsToFolder(string folderName)
        {
            string outputFolder = Path.Combine(OutputDirectory, folderName);
            //Find all assets
            string[] allAssetsNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            //Copy all assets that belong in the specified folder (Animals, Cars, etc) into the corresponding output folder
            foreach(string assetName in allAssetsNames.Where(name => name.Contains(folderName)).ToList())
            {
                //Find the name of the output file by isolating the end of the asset name
                string outputFileName = Path.Combine(outputFolder, assetName.Substring(assetName.IndexOf('.',assetName.LastIndexOf(folderName))+1));
                using(var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(assetName))
                {
                    using(var file = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                    {
                        resource.CopyTo(file);
                    }
                }
            }
        }

        public string GetAssetsFolder(string category)
        {
            string expectedFolder = Path.Combine(OutputDirectory, category);
            if(!Directory.Exists(expectedFolder) || Directory.GetFiles(expectedFolder).Length == 0)
            {
                Directory.CreateDirectory(expectedFolder);
                SaveAssetsToFolder(category);
            }
            return expectedFolder;
        }
    }
}
