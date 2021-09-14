using System;
using System.Windows.Forms;

namespace AxieEnergyCount
{
    public partial class GetKeyStroke : Form
    {
        public Keys KeyPressed;

        public GetKeyStroke()
        {
            InitializeComponent();
        }

        private void GetKeyStroke_Load(object sender, EventArgs e)
        {
            KeyDown += GetKeyStroke_KeyDown;
        }

        private void GetKeyStroke_KeyDown(object sender, KeyEventArgs e)
        {
            KeyPressed = e.KeyCode;
            Close();
        }
    }
}
