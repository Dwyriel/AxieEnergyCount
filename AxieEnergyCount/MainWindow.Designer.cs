
namespace AxieEnergyCount
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundSubmenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetWhenWLSubmenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AlwaysOnTopSubmenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitSubmenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundImage4 = new System.Windows.Forms.PictureBox();
            this.BackgroundImage3 = new System.Windows.Forms.PictureBox();
            this.BackgroundImage2 = new System.Windows.Forms.PictureBox();
            this.BackgroundImage1 = new System.Windows.Forms.PictureBox();
            this.PicBoxBG1 = new System.Windows.Forms.PictureBox();
            this.BtnNextTurn = new System.Windows.Forms.Button();
            this.BtnMinusOneEnergy = new System.Windows.Forms.Button();
            this.BtnPlusOneEnergy = new System.Windows.Forms.Button();
            this.BtnNewGame = new System.Windows.Forms.Button();
            this.BtnPlusWin = new System.Windows.Forms.Button();
            this.BtnResetWin = new System.Windows.Forms.Button();
            this.BtnMinusWin = new System.Windows.Forms.Button();
            this.BtnPlusOneCard = new System.Windows.Forms.Button();
            this.BtnMinusOneCard = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxBG1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(340, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackgroundSubmenuBtn,
            this.ResetWhenWLSubmenuBtn,
            this.AlwaysOnTopSubmenuBtn,
            this.ExitSubmenuBtn});
            this.OptionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.OptionsToolStripMenuItem.Text = "Options";
            // 
            // BackgroundSubmenuBtn
            // 
            this.BackgroundSubmenuBtn.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundSubmenuBtn.Name = "BackgroundSubmenuBtn";
            this.BackgroundSubmenuBtn.Size = new System.Drawing.Size(161, 22);
            this.BackgroundSubmenuBtn.Text = "Background";
            this.BackgroundSubmenuBtn.Click += new System.EventHandler(this.BackgroundSubmenuBtn_Click);
            // 
            // ResetWhenWLSubmenuBtn
            // 
            this.ResetWhenWLSubmenuBtn.Checked = true;
            this.ResetWhenWLSubmenuBtn.CheckOnClick = true;
            this.ResetWhenWLSubmenuBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ResetWhenWLSubmenuBtn.Name = "ResetWhenWLSubmenuBtn";
            this.ResetWhenWLSubmenuBtn.Size = new System.Drawing.Size(161, 22);
            this.ResetWhenWLSubmenuBtn.Text = "Reset When W/L";
            this.ResetWhenWLSubmenuBtn.CheckedChanged += new System.EventHandler(this.ResetWhenWLSubmenuBtn_CheckedChanged);
            // 
            // AlwaysOnTopSubmenuBtn
            // 
            this.AlwaysOnTopSubmenuBtn.Checked = true;
            this.AlwaysOnTopSubmenuBtn.CheckOnClick = true;
            this.AlwaysOnTopSubmenuBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AlwaysOnTopSubmenuBtn.Name = "AlwaysOnTopSubmenuBtn";
            this.AlwaysOnTopSubmenuBtn.Size = new System.Drawing.Size(161, 22);
            this.AlwaysOnTopSubmenuBtn.Text = "Always on Top";
            this.AlwaysOnTopSubmenuBtn.CheckedChanged += new System.EventHandler(this.AlwaysOnTopSubmenuBtn_CheckedChanged);
            // 
            // ExitSubmenuBtn
            // 
            this.ExitSubmenuBtn.Name = "ExitSubmenuBtn";
            this.ExitSubmenuBtn.Size = new System.Drawing.Size(161, 22);
            this.ExitSubmenuBtn.Text = "Exit";
            this.ExitSubmenuBtn.Click += new System.EventHandler(this.ExitSubmenuBtn_Click);
            // 
            // BackgroundImage4
            // 
            this.BackgroundImage4.Image = global::AxieEnergyCount.Properties.Resources.tumblr_pcltzsiH4h1wceprro6_400;
            this.BackgroundImage4.Location = new System.Drawing.Point(162, 187);
            this.BackgroundImage4.Name = "BackgroundImage4";
            this.BackgroundImage4.Size = new System.Drawing.Size(109, 69);
            this.BackgroundImage4.TabIndex = 5;
            this.BackgroundImage4.TabStop = false;
            this.BackgroundImage4.Visible = false;
            // 
            // BackgroundImage3
            // 
            this.BackgroundImage3.Image = global::AxieEnergyCount.Properties.Resources.cat_angela;
            this.BackgroundImage3.Location = new System.Drawing.Point(147, 172);
            this.BackgroundImage3.Name = "BackgroundImage3";
            this.BackgroundImage3.Size = new System.Drawing.Size(109, 69);
            this.BackgroundImage3.TabIndex = 4;
            this.BackgroundImage3.TabStop = false;
            this.BackgroundImage3.Visible = false;
            // 
            // BackgroundImage2
            // 
            this.BackgroundImage2.Image = global::AxieEnergyCount.Properties.Resources.seraph_of_the_end_stare;
            this.BackgroundImage2.Location = new System.Drawing.Point(131, 155);
            this.BackgroundImage2.Name = "BackgroundImage2";
            this.BackgroundImage2.Size = new System.Drawing.Size(109, 69);
            this.BackgroundImage2.TabIndex = 3;
            this.BackgroundImage2.TabStop = false;
            this.BackgroundImage2.Visible = false;
            // 
            // BackgroundImage1
            // 
            this.BackgroundImage1.Image = global::AxieEnergyCount.Properties.Resources.nekoha_anime;
            this.BackgroundImage1.Location = new System.Drawing.Point(117, 142);
            this.BackgroundImage1.Name = "BackgroundImage1";
            this.BackgroundImage1.Size = new System.Drawing.Size(109, 69);
            this.BackgroundImage1.TabIndex = 2;
            this.BackgroundImage1.TabStop = false;
            this.BackgroundImage1.Visible = false;
            // 
            // PicBoxBG1
            // 
            this.PicBoxBG1.Location = new System.Drawing.Point(0, 21);
            this.PicBoxBG1.Name = "PicBoxBG1";
            this.PicBoxBG1.Size = new System.Drawing.Size(340, 340);
            this.PicBoxBG1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxBG1.TabIndex = 0;
            this.PicBoxBG1.TabStop = false;
            // 
            // BtnNextTurn
            // 
            this.BtnNextTurn.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.BtnNextTurn.Location = new System.Drawing.Point(6, 314);
            this.BtnNextTurn.Name = "BtnNextTurn";
            this.BtnNextTurn.Size = new System.Drawing.Size(120, 40);
            this.BtnNextTurn.TabIndex = 3;
            this.BtnNextTurn.Text = "Next Turn";
            this.BtnNextTurn.UseVisualStyleBackColor = true;
            this.BtnNextTurn.Click += new System.EventHandler(this.BtnNextTurn_Click);
            // 
            // BtnMinusOneEnergy
            // 
            this.BtnMinusOneEnergy.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.BtnMinusOneEnergy.Location = new System.Drawing.Point(125, 314);
            this.BtnMinusOneEnergy.Name = "BtnMinusOneEnergy";
            this.BtnMinusOneEnergy.Size = new System.Drawing.Size(53, 40);
            this.BtnMinusOneEnergy.TabIndex = 1;
            this.BtnMinusOneEnergy.Text = "-1";
            this.BtnMinusOneEnergy.UseVisualStyleBackColor = true;
            this.BtnMinusOneEnergy.Click += new System.EventHandler(this.BtnMinusOneEnergy_Click);
            // 
            // BtnPlusOneEnergy
            // 
            this.BtnPlusOneEnergy.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.BtnPlusOneEnergy.Location = new System.Drawing.Point(177, 314);
            this.BtnPlusOneEnergy.Name = "BtnPlusOneEnergy";
            this.BtnPlusOneEnergy.Size = new System.Drawing.Size(53, 40);
            this.BtnPlusOneEnergy.TabIndex = 2;
            this.BtnPlusOneEnergy.Text = "+1";
            this.BtnPlusOneEnergy.UseVisualStyleBackColor = true;
            this.BtnPlusOneEnergy.Click += new System.EventHandler(this.BtnPlusOneEnergy_Click);
            // 
            // BtnNewGame
            // 
            this.BtnNewGame.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.BtnNewGame.Location = new System.Drawing.Point(6, 274);
            this.BtnNewGame.Name = "BtnNewGame";
            this.BtnNewGame.Size = new System.Drawing.Size(120, 40);
            this.BtnNewGame.TabIndex = 4;
            this.BtnNewGame.Text = "New Game";
            this.BtnNewGame.UseVisualStyleBackColor = true;
            this.BtnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // BtnPlusWin
            // 
            this.BtnPlusWin.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.BtnPlusWin.Location = new System.Drawing.Point(10, 148);
            this.BtnPlusWin.Name = "BtnPlusWin";
            this.BtnPlusWin.Size = new System.Drawing.Size(29, 36);
            this.BtnPlusWin.TabIndex = 5;
            this.BtnPlusWin.Text = "+";
            this.BtnPlusWin.UseVisualStyleBackColor = true;
            this.BtnPlusWin.Click += new System.EventHandler(this.BtnPlusWin_Click);
            // 
            // BtnResetWin
            // 
            this.BtnResetWin.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.BtnResetWin.Location = new System.Drawing.Point(10, 218);
            this.BtnResetWin.Name = "BtnResetWin";
            this.BtnResetWin.Size = new System.Drawing.Size(29, 36);
            this.BtnResetWin.TabIndex = 6;
            this.BtnResetWin.Text = "R";
            this.BtnResetWin.UseVisualStyleBackColor = true;
            this.BtnResetWin.Click += new System.EventHandler(this.BtnResetWin_Click);
            // 
            // BtnMinusWin
            // 
            this.BtnMinusWin.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.BtnMinusWin.Location = new System.Drawing.Point(10, 183);
            this.BtnMinusWin.Name = "BtnMinusWin";
            this.BtnMinusWin.Size = new System.Drawing.Size(29, 36);
            this.BtnMinusWin.TabIndex = 7;
            this.BtnMinusWin.Text = "-";
            this.BtnMinusWin.UseVisualStyleBackColor = true;
            this.BtnMinusWin.Click += new System.EventHandler(this.BtnMinusWin_Click);
            // 
            // BtnPlusOneCard
            // 
            this.BtnPlusOneCard.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.BtnPlusOneCard.Location = new System.Drawing.Point(281, 314);
            this.BtnPlusOneCard.Name = "BtnPlusOneCard";
            this.BtnPlusOneCard.Size = new System.Drawing.Size(53, 40);
            this.BtnPlusOneCard.TabIndex = 9;
            this.BtnPlusOneCard.Text = "+1";
            this.BtnPlusOneCard.UseVisualStyleBackColor = true;
            this.BtnPlusOneCard.Click += new System.EventHandler(this.BtnPlusOneCard_Click);
            // 
            // BtnMinusOneCard
            // 
            this.BtnMinusOneCard.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.BtnMinusOneCard.Location = new System.Drawing.Point(229, 314);
            this.BtnMinusOneCard.Name = "BtnMinusOneCard";
            this.BtnMinusOneCard.Size = new System.Drawing.Size(53, 40);
            this.BtnMinusOneCard.TabIndex = 8;
            this.BtnMinusOneCard.Text = "-1";
            this.BtnMinusOneCard.UseVisualStyleBackColor = true;
            this.BtnMinusOneCard.Click += new System.EventHandler(this.BtnMinusOneCard_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 361);
            this.Controls.Add(this.BtnPlusOneCard);
            this.Controls.Add(this.BtnMinusOneCard);
            this.Controls.Add(this.BtnMinusWin);
            this.Controls.Add(this.BtnResetWin);
            this.Controls.Add(this.BtnPlusWin);
            this.Controls.Add(this.BtnNewGame);
            this.Controls.Add(this.BtnPlusOneEnergy);
            this.Controls.Add(this.BtnMinusOneEnergy);
            this.Controls.Add(this.BtnNextTurn);
            this.Controls.Add(this.BackgroundImage4);
            this.Controls.Add(this.BackgroundImage3);
            this.Controls.Add(this.BackgroundImage2);
            this.Controls.Add(this.BackgroundImage1);
            this.Controls.Add(this.PicBoxBG1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Axie Energy Count";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxBG1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBoxBG1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackgroundSubmenuBtn;
        private System.Windows.Forms.ToolStripMenuItem ExitSubmenuBtn;
        private System.Windows.Forms.PictureBox BackgroundImage1;
        private System.Windows.Forms.PictureBox BackgroundImage2;
        private System.Windows.Forms.PictureBox BackgroundImage3;
        private System.Windows.Forms.PictureBox BackgroundImage4;
        private System.Windows.Forms.Button BtnNextTurn;
        private System.Windows.Forms.ToolStripMenuItem ResetWhenWLSubmenuBtn;
        private System.Windows.Forms.Button BtnMinusOneEnergy;
        private System.Windows.Forms.Button BtnPlusOneEnergy;
        private System.Windows.Forms.Button BtnNewGame;
        private System.Windows.Forms.Button BtnPlusWin;
        private System.Windows.Forms.Button BtnResetWin;
        private System.Windows.Forms.Button BtnMinusWin;
        private System.Windows.Forms.ToolStripMenuItem AlwaysOnTopSubmenuBtn;
        private System.Windows.Forms.Button BtnPlusOneCard;
        private System.Windows.Forms.Button BtnMinusOneCard;
    }
}

