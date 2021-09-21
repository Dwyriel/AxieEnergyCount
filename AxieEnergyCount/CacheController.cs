using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace AxieEnergyCount
{
    static class CacheController
    {
        public readonly static Configs defaultConfig = new Configs();
        public static Configs config;
        private static string path;

        public static void GetCache()
        {
            bool loaded = false;
            path = Path.GetDirectoryName(Application.ExecutablePath) + @"\AxieEnergyCount.ini";
            if (File.Exists(path))
                loaded = Load();
            if (loaded)
                return;
            config = defaultConfig;
        }

        public static void Save()
        {
            FileStream outFile = File.Create(path);
            try
            {
                XmlSerializer format = new XmlSerializer(typeof(Configs));
                format.Serialize(outFile, config);
            }
            catch (Exception e)
            {
                LogAndErrors.ShowErrorTextWithExceptionMessage("An error occurred while saving cache to AxieEnergyCount.ini, check log.txt file.", e, true);
            }
            finally
            {
                outFile.Close();
            }
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
                LogAndErrors.ShowErrorTextWithExceptionMessage("An error occurred while reading AxieEnergyCount.ini, check log.txt file.", e, true);
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
        public int BackgroundImageIndex = 0;
        public bool ResetWhenWL = true, AlwaysOnTop = true, NoBackground = false, EnableHotkeys = true, HideButtons = false;
        public Point WindowPosition = new Point(300, 300);
        public KeyBinds KeyBinds = new KeyBinds();
    }

    public class KeyBinds
    {
        public int PlusEnergy = (int)Keys.Add;
        public int MinusEnergy = (int)Keys.Subtract;
        public int NextTurn = (int)Keys.Multiply;
        public int NewGame = (int)Keys.Divide;
        public int PlusWin = (int)Keys.F8;
        public int MinusWin = (int)Keys.F7;
        public int ResetWin = (int)Keys.F6;
    }
}
