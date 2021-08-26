using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            path = Path.GetDirectoryName(Application.ExecutablePath) + @"\cache.dwy";
            if (File.Exists(path))
                Load();
            else
            {
                cache = new Collection<string>(); ;
            }
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

        public static void Load()
        {
            XmlSerializer format = new XmlSerializer(typeof(Collection<string>));
            FileStream inFile = new FileStream(path, FileMode.Open);
            byte[] buffer = new byte[inFile.Length];
            inFile.Read(buffer, 0, (int)inFile.Length);
            MemoryStream stream = new MemoryStream(buffer);
            cache = (Collection<string>)format.Deserialize(stream);
            inFile.Close();
        }
    }
}
