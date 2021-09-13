using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AxieEnergyCount
{
    public partial class MainWindow : Form
    {
        readonly int StartGameEnergy = 3, EnergyPerTurn = 2, MinEnergy = 0, MaxEnergy = 10;
        int enemyEnergy = 3, wins = 0;
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
            ResetWhenWLSubmenuBtn.Checked = CacheController.config.resetWhenWL;
            AlwaysOnTopSubmenuBtn.Checked = CacheController.config.alwaysOnTop;
            CacheController.Save();
        }

        void BackgroundSetup()
        {
            CacheController.config.backgroundImage = (CacheController.config.backgroundImage < 0 || CacheController.config.backgroundImage >= BackgroundImages.Count) ? CacheController.defaultConfig.backgroundImage : CacheController.config.backgroundImage;
            PicBoxBG1.Image = BackgroundImages[CacheController.config.backgroundImage];
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
        private void MainWindow_Load(object sender, EventArgs e)
        {
            Screen lastOpenedScreen = Screen.FromPoint(CacheController.config.startPos);
            int lowerX = lastOpenedScreen.Bounds.X;
            int upperX = lastOpenedScreen.Bounds.X + lastOpenedScreen.Bounds.Width - 345;
            int lowerY = lastOpenedScreen.Bounds.Y;
            int upperY = lastOpenedScreen.Bounds.Y + lastOpenedScreen.Bounds.Height - 400;
            if (CacheController.config.startPos.X < lowerX || CacheController.config.startPos.X > upperX || CacheController.config.startPos.Y < lowerY || CacheController.config.startPos.Y > upperY)
                CacheController.config.startPos = CacheController.defaultConfig.startPos;
            Location = CacheController.config.startPos;
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            CacheController.config.startPos = Location;
            CacheController.Save();
            timeEndPeriod(timerAccuracy);
        }

        private void BackgroundSubmenuBtn_Click(object sender, EventArgs e)
        {
            CacheController.config.backgroundImage++;
            if (CacheController.config.backgroundImage >= BackgroundImages.Count)
                CacheController.config.backgroundImage = 0;
            PicBoxBG1.Image = BackgroundImages[CacheController.config.backgroundImage];
            CacheController.Save();
        }

        private void ResetWhenWLSubmenuBtn_CheckedChanged(object sender, EventArgs e)
        {
            CacheController.config.resetWhenWL = ResetWhenWLSubmenuBtn.Checked;
            CacheController.Save();
        }

        private void AlwaysOnTopSubmenuBtn_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = AlwaysOnTopSubmenuBtn.Checked;
            CacheController.config.alwaysOnTop = AlwaysOnTopSubmenuBtn.Checked;
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
