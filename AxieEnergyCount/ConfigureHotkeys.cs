using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxieEnergyCount
{
    public partial class ConfigureHotkeys : Form
    {
        public ConfigureHotkeys()
        {
            InitializeComponent();
        }

        private void ConfigureHotkeys_Load(object sender, EventArgs e)
        {
            SetButtonsName();
        }

        private void SetButtonsName()
        {
            KeysConverter keysConverter = new KeysConverter();
            AddEBtn.Text = keysConverter.ConvertToString(CacheController.config.KeyBinds.PlusEnergy);
            SubEBtn.Text = keysConverter.ConvertToString(CacheController.config.KeyBinds.MinusEnergy);
            NextTurnBtn.Text = keysConverter.ConvertToString(CacheController.config.KeyBinds.NextTurn);
            NewGameBtn.Text = keysConverter.ConvertToString(CacheController.config.KeyBinds.NewGame);
            AddWBtn.Text = keysConverter.ConvertToString(CacheController.config.KeyBinds.PlusWin);
            SubWBtn.Text = keysConverter.ConvertToString(CacheController.config.KeyBinds.MinusWin);
            ResetWBtn.Text = keysConverter.ConvertToString(CacheController.config.KeyBinds.ResetWin);
        }

        private GetKeyStroke GenNewKeystrokeForm()
        {
            return new GetKeyStroke()
            {
                Icon = Properties.Resources.vanilla_icon,
                Owner = this,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                TopMost = this.TopMost,
                MaximizeBox = false
            };
        }

        private void AddEBtn_Click(object sender, EventArgs e)
        {
            GetKeyStroke getKeyStroke = GenNewKeystrokeForm();
            getKeyStroke.ShowDialog();
            if (getKeyStroke.KeyPressed != Keys.None)
            {
                CacheController.config.KeyBinds.PlusEnergy = (int)getKeyStroke.KeyPressed;
                SetButtonsName();
            }
            getKeyStroke.Dispose();
        }

        private void SubEBtn_Click(object sender, EventArgs e)
        {
            GetKeyStroke getKeyStroke = GenNewKeystrokeForm();
            getKeyStroke.ShowDialog();
            if (getKeyStroke.KeyPressed != Keys.None)
            {
                CacheController.config.KeyBinds.MinusEnergy = (int)getKeyStroke.KeyPressed;
                SetButtonsName();
            }
            getKeyStroke.Dispose();
        }

        private void NextTurnBtn_Click(object sender, EventArgs e)
        {
            GetKeyStroke getKeyStroke = GenNewKeystrokeForm();
            getKeyStroke.ShowDialog();
            if (getKeyStroke.KeyPressed != Keys.None)
            {
                CacheController.config.KeyBinds.NextTurn = (int)getKeyStroke.KeyPressed;
                SetButtonsName();
            }
            getKeyStroke.Dispose();
        }

        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            GetKeyStroke getKeyStroke = GenNewKeystrokeForm();
            getKeyStroke.ShowDialog();
            if (getKeyStroke.KeyPressed != Keys.None)
            {
                CacheController.config.KeyBinds.NewGame = (int)getKeyStroke.KeyPressed;
                SetButtonsName();
            }
            getKeyStroke.Dispose();
        }

        private void AddWBtn_Click(object sender, EventArgs e)
        {
            GetKeyStroke getKeyStroke = GenNewKeystrokeForm();
            getKeyStroke.ShowDialog();
            if (getKeyStroke.KeyPressed != Keys.None)
            {
                CacheController.config.KeyBinds.PlusWin = (int)getKeyStroke.KeyPressed;
                SetButtonsName();
            }
            getKeyStroke.Dispose();
        }

        private void SubWBtn_Click(object sender, EventArgs e)
        {
            GetKeyStroke getKeyStroke = GenNewKeystrokeForm();
            getKeyStroke.ShowDialog();
            if (getKeyStroke.KeyPressed != Keys.None)
            {
                CacheController.config.KeyBinds.MinusWin = (int)getKeyStroke.KeyPressed;
                SetButtonsName();
            }
            getKeyStroke.Dispose();
        }

        private void ResetWBtn_Click(object sender, EventArgs e)
        {
            GetKeyStroke getKeyStroke = GenNewKeystrokeForm();
            getKeyStroke.ShowDialog();
            if (getKeyStroke.KeyPressed != Keys.None)
            {
                CacheController.config.KeyBinds.ResetWin = (int)getKeyStroke.KeyPressed;
                SetButtonsName();
            }
            getKeyStroke.Dispose();
        }

        private void DefaultBtn_Click(object sender, EventArgs e)
        {
            CacheController.config.KeyBinds = CacheController.defaultConfig.KeyBinds;
            SetButtonsName();
        }
    }
}
