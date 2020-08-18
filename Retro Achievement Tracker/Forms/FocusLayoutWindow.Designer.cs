using CefSharp;
using CefSharp.Web;
using CefSharp.WinForms;
using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace Retro_Achievement_Tracker
{
    partial class FocusLayoutWindow
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
            System.Windows.Forms.Label breakerLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FocusLayoutWindow));

            _privateFontCollection = new PrivateFontCollection();

            AddFonts();

            this.focusAchievementTitleLabel = new System.Windows.Forms.Label();
            this.focusAchievementDescriptionLabel = new System.Windows.Forms.Label();
            this.focusAchievementButtonLeft = new System.Windows.Forms.Button();
            this.focusAchievementButtonRight = new System.Windows.Forms.Button();
            this.focusAchievementPictureBox = new System.Windows.Forms.PictureBox();
            this.setFocusButton = new System.Windows.Forms.Button();
            this.hideFocusButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            breakerLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // breakerLabel
            // 
            breakerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            breakerLabel.Location = new System.Drawing.Point(4, 95);
            breakerLabel.Name = "breakerLabel";
            breakerLabel.Size = new System.Drawing.Size(215, 2);
            breakerLabel.TabIndex = 10002;
            // 
            // label1
            // 
            label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label1.Location = new System.Drawing.Point(5, 238);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(215, 2);
            label1.TabIndex = 10003;
            // 
            // focusAchievementTitleLabel
            // 
            this.focusAchievementTitleLabel.Font = new System.Drawing.Font(GetFontFamilyByName("Eight Bit Dragon"), 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementTitleLabel.Location = new System.Drawing.Point(70, 32);
            this.focusAchievementTitleLabel.Name = "focusAchievementTitleLabel";
            this.focusAchievementTitleLabel.Size = new System.Drawing.Size(150, 60);
            this.focusAchievementTitleLabel.TabIndex = 6;
            this.focusAchievementTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            // 
            // focusAchievementDescriptionLabel
            // 
            this.focusAchievementDescriptionLabel.Font = new System.Drawing.Font(GetFontFamilyByName("Eight Bit Dragon"), 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementDescriptionLabel.Location = new System.Drawing.Point(4, 101);
            this.focusAchievementDescriptionLabel.Name = "focusAchievementDescriptionLabel";
            this.focusAchievementDescriptionLabel.Size = new System.Drawing.Size(216, 139);
            this.focusAchievementDescriptionLabel.TabIndex = 5;
            this.focusAchievementDescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            // 
            // focusAchievementButtonLeft
            // 
            this.focusAchievementButtonLeft.Font = new System.Drawing.Font(GetFontFamilyByName("Eight Bit Dragon"), 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonLeft.Location = new System.Drawing.Point(154, 243);
            this.focusAchievementButtonLeft.Name = "focusAchievementButtonLeft";
            this.focusAchievementButtonLeft.Size = new System.Drawing.Size(30, 20);
            this.focusAchievementButtonLeft.TabIndex = 9;
            this.focusAchievementButtonLeft.Text = "<";
            this.focusAchievementButtonLeft.UseVisualStyleBackColor = true;
            this.focusAchievementButtonLeft.Click += new System.EventHandler(this.MoveHuntIndexLeft);
            // 
            // focusAchievementButtonRight
            // 
            this.focusAchievementButtonRight.Font = new System.Drawing.Font(GetFontFamilyByName("Eight Bit Dragon"), 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonRight.Location = new System.Drawing.Point(190, 243);
            this.focusAchievementButtonRight.Name = "focusAchievementButtonRight";
            this.focusAchievementButtonRight.Size = new System.Drawing.Size(30, 20);
            this.focusAchievementButtonRight.TabIndex = 10;
            this.focusAchievementButtonRight.Text = ">";
            this.focusAchievementButtonRight.UseVisualStyleBackColor = true;
            this.focusAchievementButtonRight.Click += new System.EventHandler(this.MoveHuntIndexRight);
            // 
            // focusAchievementPictureBox
            // 
            this.focusAchievementPictureBox.Location = new System.Drawing.Point(4, 32);
            this.focusAchievementPictureBox.Name = "focusAchievementPictureBox";
            this.focusAchievementPictureBox.Size = new System.Drawing.Size(60, 60);
            this.focusAchievementPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.focusAchievementPictureBox.TabIndex = 21;
            this.focusAchievementPictureBox.TabStop = false;
            // 
            // setFocusButton
            // 
            this.setFocusButton.Font = new System.Drawing.Font(GetFontFamilyByName("Eight Bit Dragon"), 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setFocusButton.Location = new System.Drawing.Point(4, 243);
            this.setFocusButton.Name = "setFocusButton";
            this.setFocusButton.Size = new System.Drawing.Size(60, 20);
            this.setFocusButton.TabIndex = 10001;
            this.setFocusButton.Text = "Set";
            this.setFocusButton.UseVisualStyleBackColor = true;
            this.setFocusButton.Click += new System.EventHandler(this.SetFocusButton_Click);
            // 
            // hideFocusButton
            // 
            this.hideFocusButton.Font = new System.Drawing.Font(GetFontFamilyByName("Eight Bit Dragon"), 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideFocusButton.Location = new System.Drawing.Point(70, 243);
            this.hideFocusButton.Name = "hideFocusButton";
            this.hideFocusButton.Size = new System.Drawing.Size(60, 20);
            this.hideFocusButton.TabIndex = 10001;
            this.hideFocusButton.Text = "Hide";
            this.hideFocusButton.UseVisualStyleBackColor = true;
            this.hideFocusButton.Click += new System.EventHandler(this.HideFocusButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(breakerLabel);
            this.groupBox1.Controls.Add(this.focusAchievementPictureBox);
            this.groupBox1.Controls.Add(this.focusAchievementButtonRight);
            this.groupBox1.Controls.Add(this.hideFocusButton);
            this.groupBox1.Controls.Add(this.focusAchievementButtonLeft);
            this.groupBox1.Controls.Add(this.focusAchievementTitleLabel);
            this.groupBox1.Controls.Add(this.setFocusButton);
            this.groupBox1.Controls.Add(this.focusAchievementDescriptionLabel);
            this.groupBox1.Font = new System.Drawing.Font(GetFontFamilyByName("Eight Bit Dragon"), 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 270);
            this.groupBox1.TabIndex = 10002;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Focus";
            // 
            // chromiumWebBrowser
            // 
            this.chromiumWebBrowser.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser.Location = new System.Drawing.Point(240, 0);
            this.chromiumWebBrowser.Name = "chromiumWebBrowser";
            this.chromiumWebBrowser.Size = new System.Drawing.Size(1920, 1080);
            this.chromiumWebBrowser.TabIndex = 0;
            this.chromiumWebBrowser.Dock = System.Windows.Forms.DockStyle.None;
            // 
            // FocusLayoutWindow
            // 

            this.setFocusButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hideFocusButton.ForeColor = System.Drawing.SystemColors.ControlText;

            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1284, 287);
            this.Controls.Add(this.chromiumWebBrowser);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FocusLayoutWindow";
            this.Text = "Retro Achievement - Layout - Focus";
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private FontFamily GetFontFamilyByName(string name)
        {
            return _privateFontCollection.Families.FirstOrDefault(x => x.Name == name);
        }

        private void AddFonts()
        {
            _privateFontCollection.AddFontFile(@"Resources\monofonto.ttf");
            _privateFontCollection.AddFontFile(@"Resources\EightBitDragon-anqx.ttf");
        }

        private System.Windows.Forms.Label focusAchievementTitleLabel;
        private System.Windows.Forms.Label focusAchievementDescriptionLabel;
        private System.Windows.Forms.Button focusAchievementButtonLeft;
        private System.Windows.Forms.Button focusAchievementButtonRight;
        private System.Windows.Forms.PictureBox focusAchievementPictureBox;
        private System.Windows.Forms.Button setFocusButton;
        private System.Windows.Forms.Button hideFocusButton;
        private System.Windows.Forms.GroupBox groupBox1;
        public ChromiumWebBrowser chromiumWebBrowser;
        private PrivateFontCollection _privateFontCollection;
    }
}