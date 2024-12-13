namespace SODV2202_FinalProject
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpPlayerHand = new FlowLayoutPanel();
            pbDiscardPile = new PictureBox();
            pbDrawCard = new PictureBox();
            lblStatus = new Label();
            DiscardAndDraw = new Panel();
            flpBotHand = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pbDiscardPile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDrawCard).BeginInit();
            DiscardAndDraw.SuspendLayout();
            SuspendLayout();
            // 
            // flpPlayerHand
            // 
            flpPlayerHand.Anchor = AnchorStyles.None;
            flpPlayerHand.AutoScroll = true;
            flpPlayerHand.Location = new Point(205, 511);
            flpPlayerHand.Name = "flpPlayerHand";
            flpPlayerHand.Size = new Size(800, 180);
            flpPlayerHand.TabIndex = 0;
            flpPlayerHand.WrapContents = false;
            // 
            // pbDiscardPile
            // 
            pbDiscardPile.Location = new Point(3, 0);
            pbDiscardPile.Name = "pbDiscardPile";
            pbDiscardPile.Size = new Size(100, 150);
            pbDiscardPile.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDiscardPile.TabIndex = 1;
            pbDiscardPile.TabStop = false;
            // 
            // pbDrawCard
            // 
            pbDrawCard.ImageLocation = "..\\..\\..\\images\\back.png";
            pbDrawCard.Location = new Point(125, 0);
            pbDrawCard.Name = "pbDrawCard";
            pbDrawCard.Size = new Size(100, 150);
            pbDrawCard.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDrawCard.TabIndex = 2;
            pbDrawCard.TabStop = false;
            pbDrawCard.Click += pbDrawCard_Click;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(12, 9);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1158, 36);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DiscardAndDraw
            // 
            DiscardAndDraw.Controls.Add(pbDiscardPile);
            DiscardAndDraw.Controls.Add(pbDrawCard);
            DiscardAndDraw.Location = new Point(503, 280);
            DiscardAndDraw.Name = "DiscardAndDraw";
            DiscardAndDraw.Size = new Size(225, 150);
            DiscardAndDraw.TabIndex = 4;
            // 
            // flpBotHand
            // 
            flpBotHand.Anchor = AnchorStyles.None;
            flpBotHand.AutoScroll = true;
            flpBotHand.Location = new Point(205, 48);
            flpBotHand.Name = "flpBotHand";
            flpBotHand.Size = new Size(800, 180);
            flpBotHand.TabIndex = 5;
            flpBotHand.WrapContents = false;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 703);
            Controls.Add(flpBotHand);
            Controls.Add(DiscardAndDraw);
            Controls.Add(lblStatus);
            Controls.Add(flpPlayerHand);
            Name = "Game";
            Text = "Uno Game";
            Resize += Game_Resize;
            ((System.ComponentModel.ISupportInitialize)pbDiscardPile).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDrawCard).EndInit();
            DiscardAndDraw.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpPlayerHand;
        private PictureBox pbDiscardPile;
        private PictureBox pbDrawCard;
        private Label lblStatus;
        private Panel DiscardAndDraw;
        private FlowLayoutPanel flpBotHand;
    }
}
