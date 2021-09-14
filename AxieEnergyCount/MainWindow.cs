using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AxieEnergyCount
{
    public partial class MainWindow : Form
    {
        readonly int StartGameEnergy = 3, EnergyPerTurn = 2, MinEnergy = 0, MaxEnergy = 10;
        readonly Size defaultSize = new Size(356, 400), noBackgroundSize = new Size(356, 202), noBackgroundAndNoButtonsSize = new Size(356, 150);
        int enemyEnergy = 3, wins = 0;
        List<Image> BackgroundImages = new List<Image>();
        List<Label> customLabels = new List<Label>();
        List<Point> buttonsPosition = new List<Point>();
        List<Button> buttons = new List<Button>();

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
            SetupLists();
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

        void SetupLists()
        {
            //BackgroundImages
            BackgroundImages.Add(BackgroundImage1.Image);
            BackgroundImages.Add(BackgroundImage2.Image);
            BackgroundImages.Add(BackgroundImage3.Image);
            BackgroundImages.Add(BackgroundImage4.Image);
            //ButtonDefaultPos
            buttonsPosition.Add(new Point(219, 280));
            buttonsPosition.Add(new Point(279, 280));
            buttonsPosition.Add(new Point(219, 320));
            buttonsPosition.Add(new Point(159, 320));
            buttonsPosition.Add(new Point(8, 106));
            buttonsPosition.Add(new Point(8, 141));
            buttonsPosition.Add(new Point(8, 176));
            //ButtonNoImagePos
            buttonsPosition.Add(new Point(219, 82));
            buttonsPosition.Add(new Point(279, 82));
            buttonsPosition.Add(new Point(219, 122));
            buttonsPosition.Add(new Point(159, 122));
            buttonsPosition.Add(new Point(8, 125));
            buttonsPosition.Add(new Point(36, 125));
            buttonsPosition.Add(new Point(64, 125));
            //Buttons
            buttons.Add(BtnMinusOneEnergy);
            buttons.Add(BtnPlusOneEnergy);
            buttons.Add(BtnNextTurn);
            buttons.Add(BtnNewGame);
            buttons.Add(BtnPlusWin);
            buttons.Add(BtnMinusWin);
            buttons.Add(BtnResetWin);
        }

        void LoadCache()
        {
            CacheController.GetCache();
            CacheController.Save();
        }

        void BackgroundSetup()
        {
            CacheController.config.BackgroundImage = (CacheController.config.BackgroundImage < 0 || CacheController.config.BackgroundImage >= BackgroundImages.Count) ? CacheController.defaultConfig.BackgroundImage : CacheController.config.BackgroundImage;
            PicBoxBG1.Image = BackgroundImages[CacheController.config.BackgroundImage];
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

        private void SetStartPos()
        {
            Screen lastOpenedScreen = Screen.FromPoint(CacheController.config.WindowPosition);
            int lowerX = lastOpenedScreen.Bounds.X;
            int upperX = lastOpenedScreen.Bounds.X + lastOpenedScreen.Bounds.Width - 345;
            int lowerY = lastOpenedScreen.Bounds.Y;
            int upperY = lastOpenedScreen.Bounds.Y + lastOpenedScreen.Bounds.Height - 400;
            if (CacheController.config.WindowPosition.X < lowerX || CacheController.config.WindowPosition.X > upperX || CacheController.config.WindowPosition.Y < lowerY || CacheController.config.WindowPosition.Y > upperY)
                CacheController.config.WindowPosition = CacheController.defaultConfig.WindowPosition;
            Location = CacheController.config.WindowPosition;
        }

        private void LoadVariables()
        {
            ResetWhenWLSubmenuBtn.Checked = CacheController.config.ResetWhenWL;
            AlwaysOnTopSubmenuBtn.Checked = CacheController.config.AlwaysOnTop;
            NoImageSubmenuBtn.Checked = CacheController.config.NoBackground;
            HotkeysEnabledSubmenuBtn.Checked = CacheController.config.EnableHotkeys;
            HideButtonsSubmenuBtn.Checked = CacheController.config.HideButtons;
        }

        private void SetButtonPos(bool toDefaultPos)
        {
            int startIndex = toDefaultPos ? -1 : buttons.Count - 1;
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Location = buttonsPosition[++startIndex];
            }
        }

        private void ChangeSizeAndBG()
        {
            if (HideButtonsSubmenuBtn.Checked && NoImageSubmenuBtn.Checked)
            {
                PicBoxBG1.Image = Properties.Resources.NoBG;
                Size = noBackgroundAndNoButtonsSize;
            }
            else if (NoImageSubmenuBtn.Checked && !HideButtonsSubmenuBtn.Checked)
            {
                PicBoxBG1.Image = Properties.Resources.NoBG;
                Size = noBackgroundSize;
            }
            else
            {
                PicBoxBG1.Image = BackgroundImages[CacheController.config.BackgroundImage];
                Size = defaultSize;
            }
            Refresh();
        }

        //Events
        private void MainWindow_Load(object sender, EventArgs e)
        {
            RegisterHotKeys();
            SetStartPos();
            LoadVariables();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            CacheController.config.WindowPosition = Location;
            CacheController.Save();
            timeEndPeriod(timerAccuracy);
            UnregisterHotKeys();
        }

        private void BackgroundSubmenuBtn_Click(object sender, EventArgs e)
        {
            CacheController.config.BackgroundImage++;
            if (CacheController.config.BackgroundImage >= BackgroundImages.Count)
                CacheController.config.BackgroundImage = 0;
            PicBoxBG1.Image = BackgroundImages[CacheController.config.BackgroundImage];
            CacheController.Save();
        }

        private void ResetWhenWLSubmenuBtn_CheckedChanged(object sender, EventArgs e)
        {
            CacheController.config.ResetWhenWL = ResetWhenWLSubmenuBtn.Checked;
            CacheController.Save();
        }

        private void AlwaysOnTopSubmenuBtn_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = AlwaysOnTopSubmenuBtn.Checked;
            CacheController.config.AlwaysOnTop = AlwaysOnTopSubmenuBtn.Checked;
            CacheController.Save();
        }

        private void NoImageSubmenuBtn_CheckedChanged(object sender, EventArgs e)
        {
            BackgroundSubmenuBtn.Enabled = !NoImageSubmenuBtn.Checked;
            SetButtonPos(!NoImageSubmenuBtn.Checked);
            ChangeSizeAndBG();
            CacheController.config.NoBackground = NoImageSubmenuBtn.Checked;
            CacheController.Save();
        }

        private void HideButtonsSubmenuBtn_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Button btn in buttons)
                btn.Visible = !HideButtonsSubmenuBtn.Checked;
            ChangeSizeAndBG();
            CacheController.config.HideButtons = HideButtonsSubmenuBtn.Checked;
            CacheController.Save();
        }

        private void HotkeysEnableSubmenuBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (HotkeysEnabledSubmenuBtn.Checked)
                RegisterHotKeys();
            else UnregisterHotKeys();
            CacheController.config.EnableHotkeys = HotkeysEnabledSubmenuBtn.Checked;
            CacheController.Save();
        }

        private void HotkeysConfigureSubmenuBtn_Click(object sender, EventArgs e)
        {
            if (HotkeysEnabledSubmenuBtn.Checked)
                UnregisterHotKeys();
            ConfigureHotkeys configureHotkeys = new ConfigureHotkeys()
            {
                Icon = Properties.Resources.vanilla_icon,
                Owner = this,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                TopMost = this.TopMost,
                MaximizeBox = false
            };
            configureHotkeys.ShowDialog();
            if (HotkeysEnabledSubmenuBtn.Checked)
                RegisterHotKeys();
            configureHotkeys.Dispose();
        }

        private void ExitSubmenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
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

        //HotKeys
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private void RegisterHotKeys()
        {
            RegisterHotKey(this.Handle, CacheController.config.KeyBinds.PlusEnergy, 0, CacheController.config.KeyBinds.PlusEnergy);
            RegisterHotKey(this.Handle, CacheController.config.KeyBinds.MinusEnergy, 0, CacheController.config.KeyBinds.MinusEnergy);
            RegisterHotKey(this.Handle, CacheController.config.KeyBinds.ResetWin, 0, CacheController.config.KeyBinds.ResetWin);
            RegisterHotKey(this.Handle, CacheController.config.KeyBinds.MinusWin, 0, CacheController.config.KeyBinds.MinusWin);
            RegisterHotKey(this.Handle, CacheController.config.KeyBinds.PlusWin, 0, CacheController.config.KeyBinds.PlusWin);
            RegisterHotKey(this.Handle, CacheController.config.KeyBinds.NewGame, 0, CacheController.config.KeyBinds.NewGame);
            RegisterHotKey(this.Handle, CacheController.config.KeyBinds.NextTurn, 0, CacheController.config.KeyBinds.NextTurn);
        }

        private void UnregisterHotKeys()
        {
            UnregisterHotKey(this.Handle, CacheController.config.KeyBinds.PlusEnergy);
            UnregisterHotKey(this.Handle, CacheController.config.KeyBinds.MinusEnergy);
            UnregisterHotKey(this.Handle, CacheController.config.KeyBinds.ResetWin);
            UnregisterHotKey(this.Handle, CacheController.config.KeyBinds.MinusWin);
            UnregisterHotKey(this.Handle, CacheController.config.KeyBinds.PlusWin);
            UnregisterHotKey(this.Handle, CacheController.config.KeyBinds.NewGame);
            UnregisterHotKey(this.Handle, CacheController.config.KeyBinds.NextTurn);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int keyValue = m.WParam.ToInt32();
                if (keyValue == CacheController.config.KeyBinds.MinusEnergy)
                    BtnMinusOneEnergy_Click(this, null);
                if (keyValue == CacheController.config.KeyBinds.PlusEnergy)
                    BtnPlusOneEnergy_Click(this, null);
                if (keyValue == CacheController.config.KeyBinds.NextTurn)
                    BtnNextTurn_Click(this, null);
                if (keyValue == CacheController.config.KeyBinds.NewGame)
                    BtnNewGame_Click(this, null);
                if (keyValue == CacheController.config.KeyBinds.PlusWin)
                    BtnPlusWin_Click(this, null);
                if (keyValue == CacheController.config.KeyBinds.MinusWin)
                    BtnMinusWin_Click(this, null);
                if (keyValue == CacheController.config.KeyBinds.ResetWin)
                    BtnResetWin_Click(this, null);
            }
            base.WndProc(ref m);
        }
    }
}
