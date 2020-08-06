using System;
using System.Windows.Forms;
using RPNLib;

namespace TestRPN
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_Click(object sender, EventArgs e)
        {
            tbOut.Text = (new RPNClass(tbIn.Text)).Calculate().ToString();
        }
    }
}
