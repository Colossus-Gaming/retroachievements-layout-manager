using Retro_Achievement_Tracker.Models;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            

            this.apiKeyLabel = new System.Windows.Forms.Label();
            this.apiKeyTextBox = new System.Windows.Forms.TextBox();
            this.gameInformationImage = new System.Windows.Forms.PictureBox();
            this.gameInformationTitleLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.userProfilePictureBox = new System.Windows.Forms.PictureBox();
            this.autoStartCheckbox = new System.Windows.Forms.CheckBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.awardsLabel = new System.Windows.Forms.Label();
            this.siteRankLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.gameInformationCheevosCountLabel = new System.Windows.Forms.Label();
            this.gameInformationPointsLabel = new System.Windows.Forms.Label();
            this.gameInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.gameInformationConsoleLabel = new System.Windows.Forms.Label();
            this.gameInformationDeveloperLabel = new System.Windows.Forms.Label();
            this.gameInformationPublisherLabel = new System.Windows.Forms.Label();
            this.timerStatusLabel = new System.Windows.Forms.Label();
            this.consoleLogs = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.autoLaunchStatsWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.showStatsWindowButton = new System.Windows.Forms.Button();
            this.supportButton = new System.Windows.Forms.Button();
            this.focusGroupBox = new System.Windows.Forms.GroupBox();
            this.autoLaunchFocusWindowCheckBox = new System.Windows.Forms.CheckBox();
            this.showFocusWindowButton = new System.Windows.Forms.Button();
            this.notificationsGroupBox = new System.Windows.Forms.GroupBox();
            this.autoLaunchNotificationsWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.showNotificationsWindowButton = new System.Windows.Forms.Button();
            this.userInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.startButton = new System.Windows.Forms.Button();
            this.raConnectionStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.raConnectivityLabel = new System.Windows.Forms.Label();
            breakerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameInformationImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePictureBox)).BeginInit();
            this.gameInformationGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.focusGroupBox.SuspendLayout();
            this.notificationsGroupBox.SuspendLayout();
            this.userInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raConnectionStatusPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // breakerLabel
            // 
            breakerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            breakerLabel.Location = new System.Drawing.Point(6, 200);
            breakerLabel.Name = "breakerLabel";
            breakerLabel.Size = new System.Drawing.Size(820, 2);
            breakerLabel.TabIndex = 19;
            // 
            // apiKeyLabel
            // 
            this.apiKeyLabel.AutoSize = true;
            this.apiKeyLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyLabel.Location = new System.Drawing.Point(7, 160);
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(49, 14);
            this.apiKeyLabel.TabIndex = 31;
            this.apiKeyLabel.Text = "API Key";
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyTextBox.Location = new System.Drawing.Point(6, 137);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.PasswordChar = '*';
            this.apiKeyTextBox.Size = new System.Drawing.Size(246, 23);
            this.apiKeyTextBox.TabIndex = 1;
            this.apiKeyTextBox.TextChanged += RequiredField_TextChange;
            // 
            // gameInformationImage
            // 
            this.gameInformationImage.ImageLocation = "";
            this.gameInformationImage.Location = new System.Drawing.Point(6, 26);
            this.gameInformationImage.Name = "gameInformationImage";
            this.gameInformationImage.Size = new System.Drawing.Size(80, 80);
            this.gameInformationImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameInformationImage.TabIndex = 30;
            this.gameInformationImage.TabStop = false;
            // 
            // gameInformationTitleLabel
            // 
            this.gameInformationTitleLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationTitleLabel.Location = new System.Drawing.Point(6, 110);
            this.gameInformationTitleLabel.Name = "gameInformationTitleLabel";
            this.gameInformationTitleLabel.Size = new System.Drawing.Size(230, 65);
            this.gameInformationTitleLabel.TabIndex = 29;
            this.gameInformationTitleLabel.Text = "--";
            this.gameInformationTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(7, 123);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 14);
            this.usernameLabel.TabIndex = 26;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(5, 98);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(246, 23);
            this.usernameTextBox.TabIndex = 0;
            this.usernameTextBox.TextChanged += RequiredField_TextChange;
            // 
            // userProfilePictureBox
            // 
            this.userProfilePictureBox.Location = new System.Drawing.Point(6, 22);
            this.userProfilePictureBox.Name = "userProfilePictureBox";
            this.userProfilePictureBox.Size = new System.Drawing.Size(70, 70);
            this.userProfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userProfilePictureBox.TabIndex = 20;
            this.userProfilePictureBox.TabStop = false;
            // 
            // autoStartCheckbox
            // 
            this.autoStartCheckbox.AutoSize = true;
            this.autoStartCheckbox.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoStartCheckbox.Location = new System.Drawing.Point(82, 78);
            this.autoStartCheckbox.Name = "autoStartCheckbox";
            this.autoStartCheckbox.Size = new System.Drawing.Size(96, 19);
            this.autoStartCheckbox.TabIndex = 2;
            this.autoStartCheckbox.Text = "Auto-Start";
            this.autoStartCheckbox.UseVisualStyleBackColor = true;
            this.autoStartCheckbox.CheckedChanged += AutoStart_CheckedChanged;
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopButton.Location = new System.Drawing.Point(259, 137);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(70, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // awardsLabel
            // 
            this.awardsLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.awardsLabel.Location = new System.Drawing.Point(81, 63);
            this.awardsLabel.Name = "awardsLabel";
            this.awardsLabel.Size = new System.Drawing.Size(130, 20);
            this.awardsLabel.TabIndex = 34;
            this.awardsLabel.Text = "Awards: ---";
            // 
            // siteRankLabel
            // 
            this.siteRankLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siteRankLabel.Location = new System.Drawing.Point(81, 20);
            this.siteRankLabel.Name = "siteRankLabel";
            this.siteRankLabel.Size = new System.Drawing.Size(130, 20);
            this.siteRankLabel.TabIndex = 33;
            this.siteRankLabel.Text = "Rank: -----";
            // 
            // scoreLabel
            // 
            this.pointsLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsLabel.Location = new System.Drawing.Point(81, 42);
            this.pointsLabel.Name = "scoreLabel";
            this.pointsLabel.Size = new System.Drawing.Size(130, 20);
            this.pointsLabel.TabIndex = 32;
            this.pointsLabel.Text = "Score: --------";
            // 
            // gameInformationCheevosCountLabel
            // 
            this.gameInformationCheevosCountLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationCheevosCountLabel.Location = new System.Drawing.Point(92, 26);
            this.gameInformationCheevosCountLabel.Name = "gameInformationCheevosCountLabel";
            this.gameInformationCheevosCountLabel.Size = new System.Drawing.Size(145, 16);
            this.gameInformationCheevosCountLabel.TabIndex = 2;
            this.gameInformationCheevosCountLabel.Text = "---------";
            // 
            // gameInformationPointsLabel
            // 
            this.gameInformationPointsLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationPointsLabel.Location = new System.Drawing.Point(92, 42);
            this.gameInformationPointsLabel.Name = "gameInformationPointsLabel";
            this.gameInformationPointsLabel.Size = new System.Drawing.Size(145, 16);
            this.gameInformationPointsLabel.TabIndex = 33;
            this.gameInformationPointsLabel.Text = "---------";
            // 
            // gameInformationGroupBox
            // 
            this.gameInformationGroupBox.Controls.Add(this.gameInformationConsoleLabel);
            this.gameInformationGroupBox.Controls.Add(this.gameInformationDeveloperLabel);
            this.gameInformationGroupBox.Controls.Add(this.gameInformationPublisherLabel);
            this.gameInformationGroupBox.Controls.Add(this.gameInformationImage);
            this.gameInformationGroupBox.Controls.Add(this.gameInformationTitleLabel);
            this.gameInformationGroupBox.Controls.Add(this.gameInformationCheevosCountLabel);
            this.gameInformationGroupBox.Controls.Add(this.gameInformationPointsLabel);
            this.gameInformationGroupBox.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gameInformationGroupBox.Location = new System.Drawing.Point(354, 12);
            this.gameInformationGroupBox.Name = "gameInformationGroupBox";
            this.gameInformationGroupBox.Size = new System.Drawing.Size(242, 180);
            this.gameInformationGroupBox.TabIndex = 10004;
            this.gameInformationGroupBox.TabStop = false;
            this.gameInformationGroupBox.Text = "Game Info";
            // 
            // gameInformationConsoleLabel
            // 
            this.gameInformationConsoleLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationConsoleLabel.Location = new System.Drawing.Point(92, 64);
            this.gameInformationConsoleLabel.Name = "gameInformationConsoleLabel";
            this.gameInformationConsoleLabel.Size = new System.Drawing.Size(143, 14);
            this.gameInformationConsoleLabel.TabIndex = 36;
            this.gameInformationConsoleLabel.Text = "---------";
            // 
            // gameInformationDeveloperLabel
            // 
            this.gameInformationDeveloperLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationDeveloperLabel.Location = new System.Drawing.Point(92, 78);
            this.gameInformationDeveloperLabel.Name = "gameInformationDeveloperLabel";
            this.gameInformationDeveloperLabel.Size = new System.Drawing.Size(143, 14);
            this.gameInformationDeveloperLabel.TabIndex = 35;
            this.gameInformationDeveloperLabel.Text = "---------";
            // 
            // gameInformationPublisherLabel
            // 
            this.gameInformationPublisherLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationPublisherLabel.Location = new System.Drawing.Point(92, 92);
            this.gameInformationPublisherLabel.Name = "gameInformationPublisherLabel";
            this.gameInformationPublisherLabel.Size = new System.Drawing.Size(143, 14);
            this.gameInformationPublisherLabel.TabIndex = 34;
            this.gameInformationPublisherLabel.Text = "---------";
            // 
            // timerStatusLabel
            // 
            this.timerStatusLabel.AutoSize = true;
            this.timerStatusLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timerStatusLabel.Location = new System.Drawing.Point(14, 377);
            this.timerStatusLabel.Name = "timerStatusLabel";
            this.timerStatusLabel.Size = new System.Drawing.Size(145, 19);
            this.timerStatusLabel.TabIndex = 10024;
            this.timerStatusLabel.Text = "Currently Offline";
            // 
            // consoleLogs
            // 
            this.consoleLogs.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Monofonto"), 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleLogs.FormattingEnabled = true;
            this.consoleLogs.ItemHeight = 14;
            this.consoleLogs.Location = new System.Drawing.Point(12, 216);
            this.consoleLogs.Name = "consoleLogs";
            this.consoleLogs.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.consoleLogs.Size = new System.Drawing.Size(808, 158);
            this.consoleLogs.TabIndex = 10009;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.autoLaunchStatsWindowCheckbox);
            this.groupBox1.Controls.Add(this.showStatsWindowButton);
            this.groupBox1.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(599, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 48);
            this.groupBox1.TabIndex = 10023;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stats";
            // 
            // autoLaunchStatsWindowCheckbox
            // 
            this.autoLaunchStatsWindowCheckbox.AutoSize = true;
            this.autoLaunchStatsWindowCheckbox.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 6F);
            this.autoLaunchStatsWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchStatsWindowCheckbox.Location = new System.Drawing.Point(12, 25);
            this.autoLaunchStatsWindowCheckbox.Name = "autoLaunchStatsWindowCheckbox";
            this.autoLaunchStatsWindowCheckbox.Size = new System.Drawing.Size(92, 18);
            this.autoLaunchStatsWindowCheckbox.TabIndex = 10022;
            this.autoLaunchStatsWindowCheckbox.Text = "Auto-Launch";
            this.autoLaunchStatsWindowCheckbox.UseVisualStyleBackColor = true;
            this.autoLaunchStatsWindowCheckbox.CheckedChanged += new System.EventHandler(this.AutoLaunchStatsWindowCheckbox_CheckedChanged);
            // 
            // showStatsWindowButton
            // 
            this.showStatsWindowButton.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showStatsWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showStatsWindowButton.Location = new System.Drawing.Point(130, 20);
            this.showStatsWindowButton.Name = "showStatsWindowButton";
            this.showStatsWindowButton.Size = new System.Drawing.Size(85, 20);
            this.showStatsWindowButton.TabIndex = 10021;
            this.showStatsWindowButton.Text = "Show";
            this.showStatsWindowButton.UseVisualStyleBackColor = true;
            this.showStatsWindowButton.Click += new System.EventHandler(this.ShowStatsWindowButton_Click);
            // 
            // supportButton
            // 
            this.supportButton.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supportButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.supportButton.Location = new System.Drawing.Point(654, 161);
            this.supportButton.Name = "supportButton";
            this.supportButton.Size = new System.Drawing.Size(125, 31);
            this.supportButton.TabIndex = 10007;
            this.supportButton.Text = "Support";
            this.supportButton.UseVisualStyleBackColor = true;
            this.supportButton.Click += new System.EventHandler(this.SupportButton_Click);
            // 
            // focusGroupBox
            // 
            this.focusGroupBox.Controls.Add(this.autoLaunchFocusWindowCheckBox);
            this.focusGroupBox.Controls.Add(this.showFocusWindowButton);
            this.focusGroupBox.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.focusGroupBox.Location = new System.Drawing.Point(599, 12);
            this.focusGroupBox.Name = "focusGroupBox";
            this.focusGroupBox.Size = new System.Drawing.Size(221, 48);
            this.focusGroupBox.TabIndex = 10001;
            this.focusGroupBox.TabStop = false;
            this.focusGroupBox.Text = "Focus";
            // 
            // autoLaunchFocusWindowCheckBox
            // 
            this.autoLaunchFocusWindowCheckBox.AutoSize = true;
            this.autoLaunchFocusWindowCheckBox.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 6F);
            this.autoLaunchFocusWindowCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchFocusWindowCheckBox.Location = new System.Drawing.Point(12, 25);
            this.autoLaunchFocusWindowCheckBox.Name = "autoLaunchFocusWindowCheckBox";
            this.autoLaunchFocusWindowCheckBox.Size = new System.Drawing.Size(92, 18);
            this.autoLaunchFocusWindowCheckBox.TabIndex = 10020;
            this.autoLaunchFocusWindowCheckBox.Text = "Auto-Launch";
            this.autoLaunchFocusWindowCheckBox.UseVisualStyleBackColor = true;
            this.autoLaunchFocusWindowCheckBox.CheckedChanged += new System.EventHandler(this.AutoLaunchFocusWindowCheckBox_CheckedChanged);
            // 
            // showFocusWindowButton
            // 
            this.showFocusWindowButton.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFocusWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showFocusWindowButton.Location = new System.Drawing.Point(131, 20);
            this.showFocusWindowButton.Name = "showFocusWindowButton";
            this.showFocusWindowButton.Size = new System.Drawing.Size(85, 20);
            this.showFocusWindowButton.TabIndex = 10014;
            this.showFocusWindowButton.Text = "Show";
            this.showFocusWindowButton.UseVisualStyleBackColor = true;
            this.showFocusWindowButton.Click += new System.EventHandler(this.ShowFocusLayoutWindowButton_Click);
            // 
            // notificationsGroupBox
            // 
            this.notificationsGroupBox.Controls.Add(this.autoLaunchNotificationsWindowCheckbox);
            this.notificationsGroupBox.Controls.Add(this.showNotificationsWindowButton);
            this.notificationsGroupBox.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.notificationsGroupBox.Location = new System.Drawing.Point(599, 110);
            this.notificationsGroupBox.Name = "notificationsGroupBox";
            this.notificationsGroupBox.Size = new System.Drawing.Size(221, 48);
            this.notificationsGroupBox.TabIndex = 10006;
            this.notificationsGroupBox.TabStop = false;
            this.notificationsGroupBox.Text = "Notifications";
            // 
            // autoLaunchNotificationsWindowCheckbox
            // 
            this.autoLaunchNotificationsWindowCheckbox.AutoSize = true;
            this.autoLaunchNotificationsWindowCheckbox.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 6F);
            this.autoLaunchNotificationsWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchNotificationsWindowCheckbox.Location = new System.Drawing.Point(12, 25);
            this.autoLaunchNotificationsWindowCheckbox.Name = "autoLaunchNotificationsWindowCheckbox";
            this.autoLaunchNotificationsWindowCheckbox.Size = new System.Drawing.Size(92, 18);
            this.autoLaunchNotificationsWindowCheckbox.TabIndex = 10022;
            this.autoLaunchNotificationsWindowCheckbox.Text = "Auto-Launch";
            this.autoLaunchNotificationsWindowCheckbox.UseVisualStyleBackColor = true;
            this.autoLaunchNotificationsWindowCheckbox.CheckedChanged += new System.EventHandler(this.AutoLaunchNotificationsWindow_CheckedChanged);
            // 
            // showNotificationsWindowButton
            // 
            this.showNotificationsWindowButton.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showNotificationsWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showNotificationsWindowButton.Location = new System.Drawing.Point(131, 20);
            this.showNotificationsWindowButton.Name = "showNotificationsWindowButton";
            this.showNotificationsWindowButton.Size = new System.Drawing.Size(85, 20);
            this.showNotificationsWindowButton.TabIndex = 10021;
            this.showNotificationsWindowButton.Text = "Show";
            this.showNotificationsWindowButton.UseVisualStyleBackColor = true;
            this.showNotificationsWindowButton.Click += new System.EventHandler(this.ShowNotificationsWindowButton_Click);
            // 
            // userInfoGroupBox
            // 
            this.userInfoGroupBox.Controls.Add(this.userProfilePictureBox);
            this.userInfoGroupBox.Controls.Add(this.apiKeyLabel);
            this.userInfoGroupBox.Controls.Add(this.apiKeyTextBox);
            this.userInfoGroupBox.Controls.Add(this.usernameLabel);
            this.userInfoGroupBox.Controls.Add(this.usernameTextBox);
            this.userInfoGroupBox.Controls.Add(this.startButton);
            this.userInfoGroupBox.Controls.Add(this.pointsLabel);
            this.userInfoGroupBox.Controls.Add(this.autoStartCheckbox);
            this.userInfoGroupBox.Controls.Add(this.siteRankLabel);
            this.userInfoGroupBox.Controls.Add(this.stopButton);
            this.userInfoGroupBox.Controls.Add(this.awardsLabel);
            this.userInfoGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userInfoGroupBox.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.userInfoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.userInfoGroupBox.Name = "userInfoGroupBox";
            this.userInfoGroupBox.Size = new System.Drawing.Size(335, 180);
            this.userInfoGroupBox.TabIndex = 10008;
            this.userInfoGroupBox.TabStop = false;
            this.userInfoGroupBox.Text = "User Info";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(259, 98);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(69, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // raConnectionStatusPictureBox
            // 
            this.raConnectionStatusPictureBox.Image = global::Retro_Achievement_Tracker.Properties.Resources.red_button;
            this.raConnectionStatusPictureBox.Location = new System.Drawing.Point(799, 376);
            this.raConnectionStatusPictureBox.Name = "raConnectionStatusPictureBox";
            this.raConnectionStatusPictureBox.Size = new System.Drawing.Size(20, 20);
            this.raConnectionStatusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.raConnectionStatusPictureBox.TabIndex = 10025;
            this.raConnectionStatusPictureBox.TabStop = false;
            // 
            // raConnectivityLabel
            // 
            this.raConnectivityLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.raConnectivityLabel.Font = new System.Drawing.Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raConnectivityLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.raConnectivityLabel.Location = new System.Drawing.Point(364, 377);
            this.raConnectivityLabel.Name = "raConnectivityLabel";
            this.raConnectivityLabel.Size = new System.Drawing.Size(429, 23);
            this.raConnectivityLabel.TabIndex = 10026;
            this.raConnectivityLabel.Text = "RA Connectivity Label";
            this.raConnectivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(831, 401);
            this.Controls.Add(this.raConnectivityLabel);
            this.Controls.Add(this.raConnectionStatusPictureBox);
            this.Controls.Add(this.userInfoGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.supportButton);
            this.Controls.Add(this.timerStatusLabel);
            this.Controls.Add(this.consoleLogs);
            this.Controls.Add(this.gameInformationGroupBox);
            this.Controls.Add(breakerLabel);
            this.Controls.Add(this.focusGroupBox);
            this.Controls.Add(this.notificationsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.Text = "Retro Achievements Tracker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.gameInformationImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePictureBox)).EndInit();
            this.gameInformationGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.focusGroupBox.ResumeLayout(false);
            this.focusGroupBox.PerformLayout();
            this.notificationsGroupBox.ResumeLayout(false);
            this.notificationsGroupBox.PerformLayout();
            this.userInfoGroupBox.ResumeLayout(false);
            this.userInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raConnectionStatusPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion
        private Label usernameLabel;
        private Label apiKeyLabel;
        private Label siteRankLabel;
        private Label pointsLabel;
        private Label gameInformationTitleLabel;
        private Label gameInformationCheevosCountLabel;
        private Label gameInformationPointsLabel;
        private Label gameInformationPublisherLabel;
        private Label gameInformationDeveloperLabel;
        private Label gameInformationConsoleLabel;
        private Label awardsLabel;
        private TextBox apiKeyTextBox;
        private TextBox usernameTextBox;
        private PictureBox gameInformationImage;
        private PictureBox userProfilePictureBox;
        private Button startButton;
        private Button stopButton;
        private Button supportButton;
        private Button showFocusWindowButton;
        private CheckBox autoStartCheckbox;
        private CheckBox autoLaunchFocusWindowCheckBox;
        private GroupBox gameInformationGroupBox;
        private GroupBox notificationsGroupBox;
        private GroupBox userInfoGroupBox;
        private GroupBox focusGroupBox;
        private ListBox consoleLogs;
        private GroupBox groupBox1;
        private CheckBox autoLaunchStatsWindowCheckbox;
        private Button showStatsWindowButton;
        private CheckBox autoLaunchNotificationsWindowCheckbox;
        private Button showNotificationsWindowButton;
        private Label timerStatusLabel;
        private PictureBox raConnectionStatusPictureBox;
        private Label raConnectivityLabel;
    }
}

