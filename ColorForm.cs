using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SODV2202_FinalProject
{
    public partial class ColorForm : Form
    {
        public string SelectedColor { get; private set; } = null;
        public ColorForm()
        {
            InitializeComponent();
        }
        private void RedBtn_Click(object sender, EventArgs e)
        {
            SelectedColor = "Red";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void GreenBtn_Click(object sender, EventArgs e)
        {
            SelectedColor = "Green";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BlueBtn_Click(object sender, EventArgs e)
        {
            SelectedColor = "Blue";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void YellowBtn_Click(object sender, EventArgs e)
        {
            SelectedColor = "Yellow";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ColorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedColor))
            {
                // Prevent closing if no color is selected
                MessageBox.Show("You must choose a color before closing the form!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
    }
}
