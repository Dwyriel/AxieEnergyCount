using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AxieEnergyCount
{
    public partial class MainWindow : Form
    {
        readonly int StartGameEnergy = 3, EnergyPerTurn = 2, MinEnergy = 0, MaxEnergy = 10;
        int enemyEnergy = 3, wins = 0, counter = 0;
        List<Image> BackgroundImages = new List<Image>();
        List<Label> customLabels = new List<Label>();

        //Set clock timer to render gif at 100% speed:
        private const int timerAccuracy = 10;
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int msec);
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        public static extern int timeEndPeriod(int msec);

        public MainWindow()
        {
            SetupCustomLabels();
            SetStartAttributes();
            InitializeComponent();
            AddImagesToList();
            LoadCache();
            BackgroundSetup();
        }

        //Methods
        void SetupCustomLabels()
        {
            customLabels.Add(CreateCustomLabel("Enemy Energy:", 10, 3));
            customLabels.Add(CreateCustomLabel("Wins:", 10, 40));
            customLabels.Add(CreateCustomLabel("3", 275, 5));
            customLabels.Add(CreateCustomLabel("0", 117, 42));
        }

        private Label CreateCustomLabel(string text, int posX, int posY, float fontSize = 30f)
        {
            BorderLabel label = new BorderLabel();
            this.Controls.Add(label);
            label.BackColor = Color.Transparent;
            label.Font = new Font("Arial Black", fontSize, FontStyle.Bold, GraphicsUnit.World);
            label.ForeColor = Color.White;
            label.Text = text;
            label.BorderColor = Color.Black;
            label.BorderSize = 2.2f;
            label.AutoSize = true;
            label.Location = new Point(posX, posY);
            return label;
        }

        void SetStartAttributes()
        {
            timeBeginPeriod(timerAccuracy);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            TopMost = true;
            MaximizeBox = false;
            Icon = Properties.Resources.vanilla_icon;
        }

        void AddImagesToList()
        {
            BackgroundImages.Add(BackgroundImage1.Image);
            BackgroundImages.Add(BackgroundImage2.Image);
            BackgroundImages.Add(BackgroundImage3.Image);
            BackgroundImages.Add(BackgroundImage4.Image);
        }

        void LoadCache()
        {
            CacheController.GetCache();
            if (CacheController.IsEmpty())
            {
                CacheController.cache.Add(counter.ToString());
                CacheController.cache.Add(ResetWhenWLSubmenuBtn.Checked.ToString());
                CacheController.cache.Add(AlwaysOnTopSubmenuBtn.Checked.ToString());
                CacheController.Save();
                return;
            }
            while (CacheController.cache.Count < 3)
                CacheController.cache.Add("");
            counter = int.TryParse(CacheController.cache[0], out int resultCounter) ? (resultCounter < 0) ? 0 : (resultCounter >= BackgroundImages.Count) ? BackgroundImages.Count - 1 : resultCounter : 0;
            ResetWhenWLSubmenuBtn.Checked = bool.TryParse(CacheController.cache[1], out bool resultResetWhenWL) ? resultResetWhenWL : true;
            AlwaysOnTopSubmenuBtn.Checked = bool.TryParse(CacheController.cache[2], out bool resultAlwaysOnTop) ? resultAlwaysOnTop : true;
            CacheController.cache[0] = counter.ToString();
            CacheController.cache[1] = ResetWhenWLSubmenuBtn.Checked.ToString();
            CacheController.cache[2] = AlwaysOnTopSubmenuBtn.Checked.ToString();
            CacheController.Save();
        }

        void BackgroundSetup()
        {
            PicBoxBG1.Image = BackgroundImages[counter];
            int tabIndex = 50;
            foreach (Label label in customLabels)
            {
                label.Parent = PicBoxBG1;
                label.TabIndex = tabIndex++;
            }
        }

        private void ShowNewNumber()
        {
            customLabels[2].Text = enemyEnergy.ToString();
            customLabels[3].Text = wins.ToString();
        }

        private void ResetGame()
        {
            enemyEnergy = StartGameEnergy;
        }

        private int Clamp(int number, int min, int max)
        {
            return (number < min) ? min : (number > max) ? max : number;
        }

        //Events
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
            CacheController.cache[0] = counter.ToString();
            CacheController.Save();
        }

        private void ResetWhenWLSubmenuBtn_CheckedChanged(object sender, EventArgs e)
        {
            CacheController.cache[1] = ResetWhenWLSubmenuBtn.Checked.ToString();
            CacheController.Save();
        }

        private void AlwaysOnTopSubmenuBtn_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = AlwaysOnTopSubmenuBtn.Checked;
            CacheController.cache[2] = AlwaysOnTopSubmenuBtn.Checked.ToString();
            CacheController.Save();
        }

        private void BtnMinusOneEnergy_Click(object sender, EventArgs e)
        {
            enemyEnergy = Clamp(--enemyEnergy, MinEnergy, MaxEnergy);
            ShowNewNumber();
        }

        private void BtnPlusOneEnergy_Click(object sender, EventArgs e)
        {
            enemyEnergy = Clamp(++enemyEnergy, MinEnergy, MaxEnergy);
            ShowNewNumber();
        }

        private void BtnNextTurn_Click(object sender, EventArgs e)
        {
            enemyEnergy = Clamp(enemyEnergy + EnergyPerTurn, MinEnergy, MaxEnergy);
            ShowNewNumber();
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            ResetGame();
            ShowNewNumber();
        }

        private void BtnPlusWin_Click(object sender, EventArgs e)
        {
            wins = Clamp(++wins, 0, int.MaxValue);
            if (ResetWhenWLSubmenuBtn.Checked)
                ResetGame();
            ShowNewNumber();
        }

        private void BtnMinusWin_Click(object sender, EventArgs e)
        {
            wins = Clamp(--wins, 0, int.MaxValue);
            if (ResetWhenWLSubmenuBtn.Checked)
                ResetGame();
            ShowNewNumber();
        }

        private void BtnResetWin_Click(object sender, EventArgs e)
        {
            wins = 0;
            if (ResetWhenWLSubmenuBtn.Checked)
                ResetGame();
            ShowNewNumber();
        }

        private void ExitSubmenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
