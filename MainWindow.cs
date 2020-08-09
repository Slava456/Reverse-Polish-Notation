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
            RPNCheckClass checkClass = new RPNCheckClass(new RPNCountClass(tbIn.Text));
            string strwitherror = string.Empty;
            tbOut.Text = checkClass.CheckAndCountInput(out strwitherror).ToString();
            if (!string.IsNullOrEmpty(strwitherror))
            {
                _= MessageBox.Show(strwitherror);
            }    
        }
    }
}
