using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AxieEnergyCount
{
    static class CacheController
    {
        public static Collection<string> cache;
        private static string path;

        public static void GetCache()
        {
            bool loaded = false;
            path = Path.GetDirectoryName(Application.ExecutablePath) + @"\cache.dwy";
            if (File.Exists(path))
                loaded = Load();
            if (loaded)
                return;
            cache = new Collection<string>();
        }

        public static bool IsEmpty()
        {
            return cache.Count < 1;
        }

        public static void Save()
        {
            FileStream outFile = File.Create(path);
            XmlSerializer format = new XmlSerializer(typeof(Collection<string>));
            format.Serialize(outFile, cache);
            outFile.Close();
        }

        public static bool Load()
        {
            XmlSerializer format = new XmlSerializer(typeof(Collection<string>));
            FileStream inFile = new FileStream(path, FileMode.Open);
            try
            {
                byte[] buffer = new byte[inFile.Length];
                inFile.Read(buffer, 0, (int)inFile.Length);
                MemoryStream stream = new MemoryStream(buffer);
                cache = (Collection<string>)format.Deserialize(stream);
                return true;
            }
            catch (Exception e)
            {
                StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\log.txt", true);
                sw.WriteLine("[" + DateTime.Now + "] " + e.Message);
                sw.Flush();
                sw.Close();
                return false;
            }
            finally
            {
                inFile.Close();
            }
        }
    }
}
