using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AxieEnergyCount
{
    static class CacheController
    {
        public static Configs config ;
        private static string path;

        public static void GetCache()
        {
            bool loaded = false;
            path = Path.GetDirectoryName(Application.ExecutablePath) + @"\cache.xml";
            if (File.Exists(path))
                loaded = Load();
            if (loaded)
                return;
            config = new Configs();
        }


        public static void Save()
        {
            FileStream outFile = File.Create(path);
            XmlSerializer format = new XmlSerializer(typeof(Configs));
            format.Serialize(outFile, config);
            outFile.Close();
        }

        public static bool Load()
        {
            XmlSerializer format = new XmlSerializer(typeof(Configs));
            FileStream inFile = new FileStream(path, FileMode.Open);
            try
            {
                byte[] buffer = new byte[inFile.Length];
                inFile.Read(buffer, 0, (int)inFile.Length);
                MemoryStream stream = new MemoryStream(buffer);
                config = (Configs)format.Deserialize(stream);
                return true;
            }
            catch (Exception e)
            {
                StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\log.txt", true);
                sw.WriteLine("[" + DateTime.Now + "] " + e.Message);
                sw.Flush();
                sw.Close();
                MessageBox.Show("An error occurred, check log.txt file.", "Error");
                return false;
            }
            finally
            {
                inFile.Close();
            }
        }
    }

    public class Configs
    {
        public int backgroundImage = 0;
        public bool resetWhenWL = true, alwaysOnTop = true;
        public Point startPos = new Point(300, 300);
    }
}
