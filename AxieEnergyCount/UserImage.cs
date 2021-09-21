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
                if (!Directory.Exists(Path.GetDirectoryName(Application.ExecutablePath) + FolderName))
                    return;
                ImagesDir = Directory.CreateDirectory(Path.GetDirectoryName(Application.ExecutablePath) + FolderName);
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

        public static bool AddNewImage()
        {
            FileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "Images|*.png;*.jpeg;*.jpg;*.gif",
                CheckFileExists = true,
                Title = "Select Image"
            };
            DialogResult result = fileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                if (ImagesDir is null || !ImagesDir.Exists)
                    ImagesDir = Directory.CreateDirectory(Path.GetDirectoryName(Application.ExecutablePath) + FolderName);
                FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                try
                {
                    File.Copy(fileInfo.FullName, ImagesDir.FullName + @"\" + fileInfo.Name);
                    return true;
                } catch (Exception exception)
                {
                    LogAndErrors.ShowErrorTextWithExceptionMessage("Error occurred when saving selected image", exception);
                }
            }
            return false;
        }
    }
}
