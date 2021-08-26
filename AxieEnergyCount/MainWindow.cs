using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxieEnergyCount
{
    public partial class MainWindow : Form
    {
        List<Image> BackgroundImages = new List<Image>();
        int enemyEnergy = 3, wins = 0, counter = 0;

        //Set clock timer to render gif at 100% speed:
        private const int timerAccuracy = 10;
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int msec);
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        public static extern int timeEndPeriod(int msec);

        public MainWindow()
        {
            SetStartAttributes();
            InitializeComponent();
            BackgroundSetup();
        }

        void SetStartAttributes()
        {
            timeBeginPeriod(timerAccuracy);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        void BackgroundSetup()
        {
            AddImagesToList();
            PicBoxBG1.Image = BackgroundImages[counter];
        }

        void AddImagesToList()
        {
            BackgroundImages.Add(BackgroundImage1.Image);
            BackgroundImages.Add(BackgroundImage2.Image);
            BackgroundImages.Add(BackgroundImage3.Image);
            BackgroundImages.Add(BackgroundImage4.Image);
        }

        private void AddOne()
        {
            enemyEnergy = Clamp(++enemyEnergy, 0, 10);
        }

        private void MinusOne()
        {
            enemyEnergy = Clamp(--enemyEnergy, 0, 10);
        }

        private void NextTurn()
        {
            enemyEnergy = Clamp(enemyEnergy + 2, 0, 10);
        }

        private void NewGame()
        {
            enemyEnergy = 3;
        }

        private void AddOneWin()
        {
            wins = Clamp(++wins, 0, int.MaxValue);
        }

        private void MinusOneWin()
        {
            wins = Clamp(--wins, 0, int.MaxValue);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            timeEndPeriod(timerAccuracy);
        }

        private void BackgroundSubmenuBtn_Click(object sender, EventArgs e)
        {
            counter++;
            if (counter >= BackgroundImages.Count)
                counter = 0;
            PicBoxBG1.Image = BackgroundImages[counter];
        }

        private void exitSubmenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int Clamp(int number, int min, int max)
        {
            return (number < min) ? min : (number > max) ? max : number;
        }
    }
}
