namespace SODV2202_FinalProject
{
    partial class ColorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            YellowBtn = new Button();
            BlueBtn = new Button();
            GreenBtn = new Button();
            RedBtn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(YellowBtn);
            panel1.Controls.Add(BlueBtn);
            panel1.Controls.Add(GreenBtn);
            panel1.Controls.Add(RedBtn);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 430);
            panel1.TabIndex = 1;
            // 
            // YellowBtn
            // 
            YellowBtn.BackColor = Color.Yellow;
            YellowBtn.Location = new Point(230, 215);
            YellowBtn.Name = "YellowBtn";
            YellowBtn.Size = new Size(230, 215);
            YellowBtn.TabIndex = 4;
            YellowBtn.Text = "YELLOW";
            YellowBtn.UseVisualStyleBackColor = false;
            YellowBtn.Click += YellowBtn_Click;
            // 
            // BlueBtn
            // 
            BlueBtn.BackColor = Color.Blue;
            BlueBtn.Location = new Point(0, 215);
            BlueBtn.Name = "BlueBtn";
            BlueBtn.Size = new Size(230, 215);
            BlueBtn.TabIndex = 3;
            BlueBtn.Text = "BLUE";
            BlueBtn.UseVisualStyleBackColor = false;
            BlueBtn.Click += BlueBtn_Click;
            // 
            // GreenBtn
            // 
            GreenBtn.BackColor = Color.Green;
            GreenBtn.Location = new Point(230, 0);
            GreenBtn.Name = "GreenBtn";
            GreenBtn.Size = new Size(230, 215);
            GreenBtn.TabIndex = 2;
            GreenBtn.Text = "GREEN";
            GreenBtn.UseVisualStyleBackColor = false;
            GreenBtn.Click += GreenBtn_Click;
            // 
            // RedBtn
            // 
            RedBtn.BackColor = Color.Red;
            RedBtn.Location = new Point(0, 0);
            RedBtn.Name = "RedBtn";
            RedBtn.Size = new Size(230, 215);
            RedBtn.TabIndex = 1;
            RedBtn.Text = "RED";
            RedBtn.UseVisualStyleBackColor = false;
            RedBtn.Click += RedBtn_Click;
            // 
            // ColorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 453);
            ControlBox = false;
            Controls.Add(panel1);
            Name = "ColorForm";
            Text = "Choose Color";
            FormClosing += ColorForm_FormClosing;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button RedBtn;
        private Button YellowBtn;
        private Button BlueBtn;
        private Button GreenBtn;
    }
}