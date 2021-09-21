using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AxieEnergyCount
{
    static class UserImage
    {
        public static List<Image> UserImages = new List<Image>();
        private const string FolderName = @"\Images";
        private static DirectoryInfo ImagesDir;

        public static void LoadImages()
        {
            try
            {
                ImagesDir = Directory.CreateDirectory(Path.GetDirectoryName(Application.ExecutablePath) + FolderName);
                if (!ImagesDir.Exists)
                    return;
                GetAllImageFiles(ImagesDir.GetFiles());
            }
            catch (Exception exception)
            {
                LogAndErrors.ShowErrorTextWithExceptionMessage("Error occurred while loading custom images", exception, true);
            }
        }

        private static void GetAllImageFiles(FileInfo[] files)
        {
            UserImages = new List<Image>();
            foreach (FileInfo file in files)
            {
                if (!file.Exists || file.IsReadOnly)
                    continue;
                //! Uncomment if Extension verification is needed
                /*if (file.Extension != ".png" && file.Extension != ".jpg" && file.Extension != ".jpeg" && file.Extension != ".gif" && file.Extension != ".raw")
                    continue;*/
                Image image = null;
                try { image = Image.FromFile(file.FullName); }
                catch { }
                if (image is null)
                    continue;
                UserImages.Add(image);
            }
        }
    }
}
