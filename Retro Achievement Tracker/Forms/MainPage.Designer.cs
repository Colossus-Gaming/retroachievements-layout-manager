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
            this.statsGroupBox = new System.Windows.Forms.GroupBox();
            this.statsFontGroupBox = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.statsBackgroundColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.statsFontOutlineSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.statsFontOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.statsFontOutlineColorPickerButton = new System.Windows.Forms.Button();
            this.statsFontOutlineColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.statsFontColorPickerButton = new System.Windows.Forms.Button();
            this.statsFontColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.statsFontColorLabel = new System.Windows.Forms.Label();
            this.autoLaunchStatsWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.showStatsWindowButton = new System.Windows.Forms.Button();
            this.supportButton = new System.Windows.Forms.Button();
            this.focusGroupBox = new System.Windows.Forms.GroupBox();
            this.focusFontGroupBox = new System.Windows.Forms.GroupBox();
            this.focusBackgroundColorPickerButton = new System.Windows.Forms.Button();
            this.focusBackgroundColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.label26 = new System.Windows.Forms.Label();
            this.focusFontOutlineSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusFontOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.focusFontOutlineColorPickerButton = new System.Windows.Forms.Button();
            this.focusFontOutlineColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.focusFontColorPickerButton = new System.Windows.Forms.Button();
            this.focusFontColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.label30 = new System.Windows.Forms.Label();
            this.lockedAchievementsGroupBox = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.focusAchievementDescriptionLabel = new System.Windows.Forms.Label();
            this.focusAchievementPictureBox = new System.Windows.Forms.PictureBox();
            this.focusAchievementButtonRight = new System.Windows.Forms.Button();
            this.hideFocusButton = new System.Windows.Forms.Button();
            this.setFocusButton = new System.Windows.Forms.Button();
            this.focusAchievementButtonLeft = new System.Windows.Forms.Button();
            this.focusAchievementTitleLabel = new System.Windows.Forms.Label();
            this.autoLaunchFocusWindowCheckBox = new System.Windows.Forms.CheckBox();
            this.showFocusWindowButton = new System.Windows.Forms.Button();
            this.notificationsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.inMasteryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.inLabel2 = new System.Windows.Forms.Label();
            this.outMasteryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectCustomMasteryNotificationButton = new System.Windows.Forms.Button();
            this.outLabel2 = new System.Windows.Forms.Label();
            this.scaleLabel2 = new System.Windows.Forms.Label();
            this.scaleMasteryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.yPositionLabel2 = new System.Windows.Forms.Label();
            this.xPositionLabel2 = new System.Windows.Forms.Label();
            this.masteryEditOultineCheckbox = new System.Windows.Forms.CheckBox();
            this.customMasteryYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.customMasteryXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.useCustomMasteryCheckbox = new System.Windows.Forms.CheckBox();
            this.showGameMasteryButton = new System.Windows.Forms.Button();
            this.autoLaunchNotificationsWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.showNotificationsWindowButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.inAchievementNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.inLabel1 = new System.Windows.Forms.Label();
            this.outAchievementNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectCustomAchievementButton = new System.Windows.Forms.Button();
            this.outLabel1 = new System.Windows.Forms.Label();
            this.scaleLabel1 = new System.Windows.Forms.Label();
            this.scaleAchievementNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.yPositionLabel1 = new System.Windows.Forms.Label();
            this.xPositionLabel1 = new System.Windows.Forms.Label();
            this.acheivementEditOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.customAchievementYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.customAchievementXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.useCustomAchievementCheckbox = new System.Windows.Forms.CheckBox();
            this.showAchievementButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.notificationsBackgroundColorPickerButton = new System.Windows.Forms.Button();
            this.notificationsBackgroundColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.notificationsFontOutlineSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsFontOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.notificationsFontOutlineColorPickerButton = new System.Windows.Forms.Button();
            this.notificationsFontOutlineColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.notificationsFontColorPickerButton = new System.Windows.Forms.Button();
            this.notificationsFontColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.startButton = new System.Windows.Forms.Button();
            this.raConnectionStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.raConnectivityLabel = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statsFontComboBox = new System.Windows.Forms.ComboBox();
            this.focusFontComboBox = new System.Windows.Forms.ComboBox();
            this.notificationsFontComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameInformationImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePictureBox)).BeginInit();
            this.gameInformationGroupBox.SuspendLayout();
            this.statsGroupBox.SuspendLayout();
            this.statsFontGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statsBackgroundColorDisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsFontOutlineSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsFontOutlineColorDisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsFontColorDisplayBox)).BeginInit();
            this.focusGroupBox.SuspendLayout();
            this.focusFontGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusBackgroundColorDisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusFontOutlineSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusFontOutlineColorDisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusFontColorDisplayBox)).BeginInit();
            this.lockedAchievementsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).BeginInit();
            this.notificationsGroupBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inMasteryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outMasteryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleMasteryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryXNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inAchievementNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outAchievementNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleAchievementNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementXNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsBackgroundColorDisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsFontOutlineSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsFontOutlineColorDisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsFontColorDisplayBox)).BeginInit();
            this.userInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raConnectionStatusPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // apiKeyLabel
            // 
            this.apiKeyLabel.AutoSize = true;
            this.apiKeyLabel.Font = new System.Drawing.Font("Calibri", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyLabel.Location = new System.Drawing.Point(7, 159);
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(32, 11);
            this.apiKeyLabel.TabIndex = 31;
            this.apiKeyLabel.Text = "API Key";
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.Font = new System.Drawing.Font("Calibri", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyTextBox.Location = new System.Drawing.Point(6, 137);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.PasswordChar = '*';
            this.apiKeyTextBox.Size = new System.Drawing.Size(155, 19);
            this.apiKeyTextBox.TabIndex = 1;
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
            this.gameInformationTitleLabel.Font = new System.Drawing.Font("Calibri", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.usernameLabel.Font = new System.Drawing.Font("Calibri", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(7, 117);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(42, 11);
            this.usernameLabel.TabIndex = 26;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Calibri", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(5, 98);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(156, 19);
            this.usernameTextBox.TabIndex = 0;
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
            this.autoStartCheckbox.Font = new System.Drawing.Font("Calibri", 7.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoStartCheckbox.Location = new System.Drawing.Point(82, 78);
            this.autoStartCheckbox.Name = "autoStartCheckbox";
            this.autoStartCheckbox.Size = new System.Drawing.Size(74, 17);
            this.autoStartCheckbox.TabIndex = 2;
            this.autoStartCheckbox.Text = "Auto-Start";
            this.autoStartCheckbox.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Calibri", 7.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopButton.Location = new System.Drawing.Point(165, 135);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(70, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // awardsLabel
            // 
            this.awardsLabel.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.awardsLabel.Location = new System.Drawing.Point(81, 63);
            this.awardsLabel.Name = "awardsLabel";
            this.awardsLabel.Size = new System.Drawing.Size(130, 20);
            this.awardsLabel.TabIndex = 34;
            this.awardsLabel.Text = "Awards: ---";
            // 
            // siteRankLabel
            // 
            this.siteRankLabel.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siteRankLabel.Location = new System.Drawing.Point(81, 20);
            this.siteRankLabel.Name = "siteRankLabel";
            this.siteRankLabel.Size = new System.Drawing.Size(130, 20);
            this.siteRankLabel.TabIndex = 33;
            this.siteRankLabel.Text = "Rank: -----";
            // 
            // pointsLabel
            // 
            this.pointsLabel.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsLabel.Location = new System.Drawing.Point(81, 42);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(130, 20);
            this.pointsLabel.TabIndex = 32;
            this.pointsLabel.Text = "Score: --------";
            // 
            // gameInformationCheevosCountLabel
            // 
            this.gameInformationCheevosCountLabel.Font = new System.Drawing.Font("Calibri", 7.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationCheevosCountLabel.Location = new System.Drawing.Point(92, 26);
            this.gameInformationCheevosCountLabel.Name = "gameInformationCheevosCountLabel";
            this.gameInformationCheevosCountLabel.Size = new System.Drawing.Size(145, 16);
            this.gameInformationCheevosCountLabel.TabIndex = 2;
            this.gameInformationCheevosCountLabel.Text = "---------";
            // 
            // gameInformationPointsLabel
            // 
            this.gameInformationPointsLabel.Font = new System.Drawing.Font("Calibri", 7.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.gameInformationGroupBox.Font = new System.Drawing.Font("Calibri", 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameInformationGroupBox.Location = new System.Drawing.Point(12, 252);
            this.gameInformationGroupBox.Name = "gameInformationGroupBox";
            this.gameInformationGroupBox.Size = new System.Drawing.Size(242, 180);
            this.gameInformationGroupBox.TabIndex = 10004;
            this.gameInformationGroupBox.TabStop = false;
            this.gameInformationGroupBox.Text = "Game Info";
            // 
            // gameInformationConsoleLabel
            // 
            this.gameInformationConsoleLabel.Font = new System.Drawing.Font("Calibri", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationConsoleLabel.Location = new System.Drawing.Point(92, 64);
            this.gameInformationConsoleLabel.Name = "gameInformationConsoleLabel";
            this.gameInformationConsoleLabel.Size = new System.Drawing.Size(143, 14);
            this.gameInformationConsoleLabel.TabIndex = 36;
            this.gameInformationConsoleLabel.Text = "---------";
            // 
            // gameInformationDeveloperLabel
            // 
            this.gameInformationDeveloperLabel.Font = new System.Drawing.Font("Calibri", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationDeveloperLabel.Location = new System.Drawing.Point(92, 78);
            this.gameInformationDeveloperLabel.Name = "gameInformationDeveloperLabel";
            this.gameInformationDeveloperLabel.Size = new System.Drawing.Size(143, 14);
            this.gameInformationDeveloperLabel.TabIndex = 35;
            this.gameInformationDeveloperLabel.Text = "---------";
            // 
            // gameInformationPublisherLabel
            // 
            this.gameInformationPublisherLabel.Font = new System.Drawing.Font("Calibri", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInformationPublisherLabel.Location = new System.Drawing.Point(92, 92);
            this.gameInformationPublisherLabel.Name = "gameInformationPublisherLabel";
            this.gameInformationPublisherLabel.Size = new System.Drawing.Size(143, 14);
            this.gameInformationPublisherLabel.TabIndex = 34;
            this.gameInformationPublisherLabel.Text = "---------";
            // 
            // timerStatusLabel
            // 
            this.timerStatusLabel.AutoSize = true;
            this.timerStatusLabel.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timerStatusLabel.Location = new System.Drawing.Point(38, 198);
            this.timerStatusLabel.Name = "timerStatusLabel";
            this.timerStatusLabel.Size = new System.Drawing.Size(45, 17);
            this.timerStatusLabel.TabIndex = 10024;
            this.timerStatusLabel.Text = "Offline";
            // 
            // statsGroupBox
            // 
            this.statsGroupBox.Controls.Add(this.statsFontGroupBox);
            this.statsGroupBox.Controls.Add(this.autoLaunchStatsWindowCheckbox);
            this.statsGroupBox.Controls.Add(this.showStatsWindowButton);
            this.statsGroupBox.Font = new System.Drawing.Font("Calibri", 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statsGroupBox.Location = new System.Drawing.Point(260, 12);
            this.statsGroupBox.Name = "statsGroupBox";
            this.statsGroupBox.Size = new System.Drawing.Size(179, 214);
            this.statsGroupBox.TabIndex = 10023;
            this.statsGroupBox.TabStop = false;
            this.statsGroupBox.Text = "Stats";
            // 
            // statsFontGroupBox
            // 
            this.statsFontGroupBox.Controls.Add(this.statsFontComboBox);
            this.statsFontGroupBox.Controls.Add(this.button9);
            this.statsFontGroupBox.Controls.Add(this.statsBackgroundColorDisplayBox);
            this.statsFontGroupBox.Controls.Add(this.label19);
            this.statsFontGroupBox.Controls.Add(this.statsFontOutlineSizeUpDown);
            this.statsFontGroupBox.Controls.Add(this.statsFontOutlineCheckbox);
            this.statsFontGroupBox.Controls.Add(this.statsFontOutlineColorPickerButton);
            this.statsFontGroupBox.Controls.Add(this.statsFontOutlineColorDisplayBox);
            this.statsFontGroupBox.Controls.Add(this.statsFontColorPickerButton);
            this.statsFontGroupBox.Controls.Add(this.statsFontColorDisplayBox);
            this.statsFontGroupBox.Controls.Add(this.statsFontColorLabel);
            this.statsFontGroupBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsFontGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statsFontGroupBox.Location = new System.Drawing.Point(6, 44);
            this.statsFontGroupBox.Name = "statsFontGroupBox";
            this.statsFontGroupBox.Size = new System.Drawing.Size(166, 163);
            this.statsFontGroupBox.TabIndex = 10005;
            this.statsFontGroupBox.TabStop = false;
            this.statsFontGroupBox.Text = "Font";
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button9.Location = new System.Drawing.Point(110, 58);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(49, 23);
            this.button9.TabIndex = 37;
            this.button9.Text = "Set";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // statsBackgroundColorDisplayBox
            // 
            this.statsBackgroundColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statsBackgroundColorDisplayBox.Enabled = false;
            this.statsBackgroundColorDisplayBox.Location = new System.Drawing.Point(84, 59);
            this.statsBackgroundColorDisplayBox.Name = "statsBackgroundColorDisplayBox";
            this.statsBackgroundColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.statsBackgroundColorDisplayBox.TabIndex = 36;
            this.statsBackgroundColorDisplayBox.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Enabled = false;
            this.label19.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 15);
            this.label19.TabIndex = 35;
            this.label19.Text = "Background";
            // 
            // statsFontOutlineSizeUpDown
            // 
            this.statsFontOutlineSizeUpDown.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsFontOutlineSizeUpDown.Location = new System.Drawing.Point(110, 134);
            this.statsFontOutlineSizeUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.statsFontOutlineSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.statsFontOutlineSizeUpDown.Name = "statsFontOutlineSizeUpDown";
            this.statsFontOutlineSizeUpDown.Size = new System.Drawing.Size(49, 23);
            this.statsFontOutlineSizeUpDown.TabIndex = 28;
            this.statsFontOutlineSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // statsFontOutlineCheckbox
            // 
            this.statsFontOutlineCheckbox.AutoSize = true;
            this.statsFontOutlineCheckbox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsFontOutlineCheckbox.Location = new System.Drawing.Point(9, 109);
            this.statsFontOutlineCheckbox.Name = "statsFontOutlineCheckbox";
            this.statsFontOutlineCheckbox.Size = new System.Drawing.Size(61, 17);
            this.statsFontOutlineCheckbox.TabIndex = 27;
            this.statsFontOutlineCheckbox.Text = "Outline";
            this.statsFontOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // statsFontOutlineColorPickerButton
            // 
            this.statsFontOutlineColorPickerButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsFontOutlineColorPickerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statsFontOutlineColorPickerButton.Location = new System.Drawing.Point(110, 106);
            this.statsFontOutlineColorPickerButton.Name = "statsFontOutlineColorPickerButton";
            this.statsFontOutlineColorPickerButton.Size = new System.Drawing.Size(49, 23);
            this.statsFontOutlineColorPickerButton.TabIndex = 26;
            this.statsFontOutlineColorPickerButton.Text = "Set";
            this.statsFontOutlineColorPickerButton.UseVisualStyleBackColor = true;
            // 
            // statsFontOutlineColorDisplayBox
            // 
            this.statsFontOutlineColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statsFontOutlineColorDisplayBox.Location = new System.Drawing.Point(84, 106);
            this.statsFontOutlineColorDisplayBox.Name = "statsFontOutlineColorDisplayBox";
            this.statsFontOutlineColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.statsFontOutlineColorDisplayBox.TabIndex = 25;
            this.statsFontOutlineColorDisplayBox.TabStop = false;
            // 
            // statsFontColorPickerButton
            // 
            this.statsFontColorPickerButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsFontColorPickerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statsFontColorPickerButton.Location = new System.Drawing.Point(110, 83);
            this.statsFontColorPickerButton.Name = "statsFontColorPickerButton";
            this.statsFontColorPickerButton.Size = new System.Drawing.Size(49, 23);
            this.statsFontColorPickerButton.TabIndex = 22;
            this.statsFontColorPickerButton.Text = "Set";
            this.statsFontColorPickerButton.UseVisualStyleBackColor = true;
            // 
            // statsFontColorDisplayBox
            // 
            this.statsFontColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statsFontColorDisplayBox.Location = new System.Drawing.Point(84, 83);
            this.statsFontColorDisplayBox.Name = "statsFontColorDisplayBox";
            this.statsFontColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.statsFontColorDisplayBox.TabIndex = 21;
            this.statsFontColorDisplayBox.TabStop = false;
            // 
            // statsFontColorLabel
            // 
            this.statsFontColorLabel.AutoSize = true;
            this.statsFontColorLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsFontColorLabel.Location = new System.Drawing.Point(6, 84);
            this.statsFontColorLabel.Name = "statsFontColorLabel";
            this.statsFontColorLabel.Size = new System.Drawing.Size(64, 15);
            this.statsFontColorLabel.TabIndex = 20;
            this.statsFontColorLabel.Text = "Font Color";
            // 
            // autoLaunchStatsWindowCheckbox
            // 
            this.autoLaunchStatsWindowCheckbox.AutoSize = true;
            this.autoLaunchStatsWindowCheckbox.Font = new System.Drawing.Font("Calibri", 6F);
            this.autoLaunchStatsWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchStatsWindowCheckbox.Location = new System.Drawing.Point(9, 28);
            this.autoLaunchStatsWindowCheckbox.Name = "autoLaunchStatsWindowCheckbox";
            this.autoLaunchStatsWindowCheckbox.Size = new System.Drawing.Size(64, 14);
            this.autoLaunchStatsWindowCheckbox.TabIndex = 10022;
            this.autoLaunchStatsWindowCheckbox.Text = "Auto-Launch";
            this.autoLaunchStatsWindowCheckbox.UseVisualStyleBackColor = true;
            this.autoLaunchStatsWindowCheckbox.CheckedChanged += new System.EventHandler(this.AutoLaunchStatsWindowCheckbox_CheckedChanged);
            // 
            // showStatsWindowButton
            // 
            this.showStatsWindowButton.Font = new System.Drawing.Font("Calibri", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showStatsWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showStatsWindowButton.Location = new System.Drawing.Point(75, 24);
            this.showStatsWindowButton.Name = "showStatsWindowButton";
            this.showStatsWindowButton.Size = new System.Drawing.Size(48, 20);
            this.showStatsWindowButton.TabIndex = 10021;
            this.showStatsWindowButton.Text = "Show";
            this.showStatsWindowButton.UseVisualStyleBackColor = true;
            this.showStatsWindowButton.Click += new System.EventHandler(this.ShowStatsWindowButton_Click);
            // 
            // supportButton
            // 
            this.supportButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supportButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.supportButton.Location = new System.Drawing.Point(180, 19);
            this.supportButton.Name = "supportButton";
            this.supportButton.Size = new System.Drawing.Size(55, 20);
            this.supportButton.TabIndex = 10007;
            this.supportButton.Text = "Donate";
            this.supportButton.UseVisualStyleBackColor = true;
            this.supportButton.Click += new System.EventHandler(this.SupportButton_Click);
            // 
            // focusGroupBox
            // 
            this.focusGroupBox.Controls.Add(this.focusFontGroupBox);
            this.focusGroupBox.Controls.Add(this.lockedAchievementsGroupBox);
            this.focusGroupBox.Controls.Add(this.autoLaunchFocusWindowCheckBox);
            this.focusGroupBox.Controls.Add(this.showFocusWindowButton);
            this.focusGroupBox.Font = new System.Drawing.Font("Calibri", 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusGroupBox.Location = new System.Drawing.Point(445, 12);
            this.focusGroupBox.Name = "focusGroupBox";
            this.focusGroupBox.Size = new System.Drawing.Size(451, 214);
            this.focusGroupBox.TabIndex = 10001;
            this.focusGroupBox.TabStop = false;
            this.focusGroupBox.Text = "Focus";
            // 
            // focusFontGroupBox
            // 
            this.focusFontGroupBox.Controls.Add(this.focusFontComboBox);
            this.focusFontGroupBox.Controls.Add(this.focusBackgroundColorPickerButton);
            this.focusFontGroupBox.Controls.Add(this.focusBackgroundColorDisplayBox);
            this.focusFontGroupBox.Controls.Add(this.label26);
            this.focusFontGroupBox.Controls.Add(this.focusFontOutlineSizeUpDown);
            this.focusFontGroupBox.Controls.Add(this.focusFontOutlineCheckbox);
            this.focusFontGroupBox.Controls.Add(this.focusFontOutlineColorPickerButton);
            this.focusFontGroupBox.Controls.Add(this.focusFontOutlineColorDisplayBox);
            this.focusFontGroupBox.Controls.Add(this.focusFontColorPickerButton);
            this.focusFontGroupBox.Controls.Add(this.focusFontColorDisplayBox);
            this.focusFontGroupBox.Controls.Add(this.label30);
            this.focusFontGroupBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusFontGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusFontGroupBox.Location = new System.Drawing.Point(6, 44);
            this.focusFontGroupBox.Name = "focusFontGroupBox";
            this.focusFontGroupBox.Size = new System.Drawing.Size(164, 163);
            this.focusFontGroupBox.TabIndex = 10021;
            this.focusFontGroupBox.TabStop = false;
            this.focusFontGroupBox.Text = "Font";
            // 
            // focusBackgroundColorPickerButton
            // 
            this.focusBackgroundColorPickerButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusBackgroundColorPickerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusBackgroundColorPickerButton.Location = new System.Drawing.Point(110, 59);
            this.focusBackgroundColorPickerButton.Name = "focusBackgroundColorPickerButton";
            this.focusBackgroundColorPickerButton.Size = new System.Drawing.Size(49, 23);
            this.focusBackgroundColorPickerButton.TabIndex = 37;
            this.focusBackgroundColorPickerButton.Text = "Set";
            this.focusBackgroundColorPickerButton.UseVisualStyleBackColor = true;
            // 
            // focusBackgroundColorDisplayBox
            // 
            this.focusBackgroundColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusBackgroundColorDisplayBox.Location = new System.Drawing.Point(84, 59);
            this.focusBackgroundColorDisplayBox.Name = "focusBackgroundColorDisplayBox";
            this.focusBackgroundColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.focusBackgroundColorDisplayBox.TabIndex = 36;
            this.focusBackgroundColorDisplayBox.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(6, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 15);
            this.label26.TabIndex = 35;
            this.label26.Text = "Background";
            // 
            // focusFontOutlineSizeUpDown
            // 
            this.focusFontOutlineSizeUpDown.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusFontOutlineSizeUpDown.Location = new System.Drawing.Point(110, 134);
            this.focusFontOutlineSizeUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.focusFontOutlineSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.focusFontOutlineSizeUpDown.Name = "focusFontOutlineSizeUpDown";
            this.focusFontOutlineSizeUpDown.Size = new System.Drawing.Size(49, 23);
            this.focusFontOutlineSizeUpDown.TabIndex = 28;
            this.focusFontOutlineSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // focusFontOutlineCheckbox
            // 
            this.focusFontOutlineCheckbox.AutoSize = true;
            this.focusFontOutlineCheckbox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusFontOutlineCheckbox.Location = new System.Drawing.Point(9, 106);
            this.focusFontOutlineCheckbox.Name = "focusFontOutlineCheckbox";
            this.focusFontOutlineCheckbox.Size = new System.Drawing.Size(61, 17);
            this.focusFontOutlineCheckbox.TabIndex = 27;
            this.focusFontOutlineCheckbox.Text = "Outline";
            this.focusFontOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // focusFontOutlineColorPickerButton
            // 
            this.focusFontOutlineColorPickerButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusFontOutlineColorPickerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusFontOutlineColorPickerButton.Location = new System.Drawing.Point(110, 107);
            this.focusFontOutlineColorPickerButton.Name = "focusFontOutlineColorPickerButton";
            this.focusFontOutlineColorPickerButton.Size = new System.Drawing.Size(49, 23);
            this.focusFontOutlineColorPickerButton.TabIndex = 26;
            this.focusFontOutlineColorPickerButton.Text = "Set";
            this.focusFontOutlineColorPickerButton.UseVisualStyleBackColor = true;
            // 
            // focusFontOutlineColorDisplayBox
            // 
            this.focusFontOutlineColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusFontOutlineColorDisplayBox.Location = new System.Drawing.Point(84, 108);
            this.focusFontOutlineColorDisplayBox.Name = "focusFontOutlineColorDisplayBox";
            this.focusFontOutlineColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.focusFontOutlineColorDisplayBox.TabIndex = 25;
            this.focusFontOutlineColorDisplayBox.TabStop = false;
            // 
            // focusFontColorPickerButton
            // 
            this.focusFontColorPickerButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusFontColorPickerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusFontColorPickerButton.Location = new System.Drawing.Point(110, 84);
            this.focusFontColorPickerButton.Name = "focusFontColorPickerButton";
            this.focusFontColorPickerButton.Size = new System.Drawing.Size(49, 23);
            this.focusFontColorPickerButton.TabIndex = 22;
            this.focusFontColorPickerButton.Text = "Set";
            this.focusFontColorPickerButton.UseVisualStyleBackColor = true;
            // 
            // focusFontColorDisplayBox
            // 
            this.focusFontColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusFontColorDisplayBox.Location = new System.Drawing.Point(84, 84);
            this.focusFontColorDisplayBox.Name = "focusFontColorDisplayBox";
            this.focusFontColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.focusFontColorDisplayBox.TabIndex = 21;
            this.focusFontColorDisplayBox.TabStop = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(7, 84);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(64, 15);
            this.label30.TabIndex = 20;
            this.label30.Text = "Font Color";
            // 
            // lockedAchievementsGroupBox
            // 
            this.lockedAchievementsGroupBox.Controls.Add(this.label33);
            this.lockedAchievementsGroupBox.Controls.Add(this.focusAchievementDescriptionLabel);
            this.lockedAchievementsGroupBox.Controls.Add(this.focusAchievementPictureBox);
            this.lockedAchievementsGroupBox.Controls.Add(this.focusAchievementButtonRight);
            this.lockedAchievementsGroupBox.Controls.Add(this.hideFocusButton);
            this.lockedAchievementsGroupBox.Controls.Add(this.setFocusButton);
            this.lockedAchievementsGroupBox.Controls.Add(this.focusAchievementButtonLeft);
            this.lockedAchievementsGroupBox.Controls.Add(this.focusAchievementTitleLabel);
            this.lockedAchievementsGroupBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lockedAchievementsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lockedAchievementsGroupBox.Location = new System.Drawing.Point(176, 44);
            this.lockedAchievementsGroupBox.Name = "lockedAchievementsGroupBox";
            this.lockedAchievementsGroupBox.Size = new System.Drawing.Size(266, 162);
            this.lockedAchievementsGroupBox.TabIndex = 10002;
            this.lockedAchievementsGroupBox.TabStop = false;
            this.lockedAchievementsGroupBox.Text = "Locked Achievements";
            // 
            // label33
            // 
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label33.Location = new System.Drawing.Point(4, 95);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(325, 2);
            this.label33.TabIndex = 10002;
            // 
            // focusAchievementDescriptionLabel
            // 
            this.focusAchievementDescriptionLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementDescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusAchievementDescriptionLabel.Location = new System.Drawing.Point(5, 99);
            this.focusAchievementDescriptionLabel.Name = "focusAchievementDescriptionLabel";
            this.focusAchievementDescriptionLabel.Size = new System.Drawing.Size(261, 60);
            this.focusAchievementDescriptionLabel.TabIndex = 5;
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
            // focusAchievementButtonRight
            // 
            this.focusAchievementButtonRight.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonRight.Location = new System.Drawing.Point(222, 73);
            this.focusAchievementButtonRight.Name = "focusAchievementButtonRight";
            this.focusAchievementButtonRight.Size = new System.Drawing.Size(38, 20);
            this.focusAchievementButtonRight.TabIndex = 10;
            this.focusAchievementButtonRight.Text = ">";
            this.focusAchievementButtonRight.UseVisualStyleBackColor = true;
            // 
            // hideFocusButton
            // 
            this.hideFocusButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideFocusButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hideFocusButton.Location = new System.Drawing.Point(222, 29);
            this.hideFocusButton.Name = "hideFocusButton";
            this.hideFocusButton.Size = new System.Drawing.Size(38, 20);
            this.hideFocusButton.TabIndex = 10001;
            this.hideFocusButton.Text = "Hide";
            this.hideFocusButton.UseVisualStyleBackColor = true;
            // 
            // setFocusButton
            // 
            this.setFocusButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setFocusButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setFocusButton.Location = new System.Drawing.Point(184, 29);
            this.setFocusButton.Name = "setFocusButton";
            this.setFocusButton.Size = new System.Drawing.Size(38, 20);
            this.setFocusButton.TabIndex = 10001;
            this.setFocusButton.Text = "Set";
            this.setFocusButton.UseVisualStyleBackColor = true;
            // 
            // focusAchievementButtonLeft
            // 
            this.focusAchievementButtonLeft.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonLeft.Location = new System.Drawing.Point(184, 73);
            this.focusAchievementButtonLeft.Name = "focusAchievementButtonLeft";
            this.focusAchievementButtonLeft.Size = new System.Drawing.Size(38, 20);
            this.focusAchievementButtonLeft.TabIndex = 9;
            this.focusAchievementButtonLeft.Text = "<";
            this.focusAchievementButtonLeft.UseVisualStyleBackColor = true;
            // 
            // focusAchievementTitleLabel
            // 
            this.focusAchievementTitleLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusAchievementTitleLabel.Location = new System.Drawing.Point(70, 32);
            this.focusAchievementTitleLabel.Name = "focusAchievementTitleLabel";
            this.focusAchievementTitleLabel.Size = new System.Drawing.Size(108, 60);
            this.focusAchievementTitleLabel.TabIndex = 6;
            // 
            // autoLaunchFocusWindowCheckBox
            // 
            this.autoLaunchFocusWindowCheckBox.AutoSize = true;
            this.autoLaunchFocusWindowCheckBox.Font = new System.Drawing.Font("Calibri", 6F);
            this.autoLaunchFocusWindowCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchFocusWindowCheckBox.Location = new System.Drawing.Point(12, 29);
            this.autoLaunchFocusWindowCheckBox.Name = "autoLaunchFocusWindowCheckBox";
            this.autoLaunchFocusWindowCheckBox.Size = new System.Drawing.Size(64, 14);
            this.autoLaunchFocusWindowCheckBox.TabIndex = 10020;
            this.autoLaunchFocusWindowCheckBox.Text = "Auto-Launch";
            this.autoLaunchFocusWindowCheckBox.UseVisualStyleBackColor = true;
            this.autoLaunchFocusWindowCheckBox.CheckedChanged += new System.EventHandler(this.AutoLaunchFocusWindowCheckBox_CheckedChanged);
            // 
            // showFocusWindowButton
            // 
            this.showFocusWindowButton.Font = new System.Drawing.Font("Calibri", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFocusWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showFocusWindowButton.Location = new System.Drawing.Point(82, 24);
            this.showFocusWindowButton.Name = "showFocusWindowButton";
            this.showFocusWindowButton.Size = new System.Drawing.Size(48, 20);
            this.showFocusWindowButton.TabIndex = 10014;
            this.showFocusWindowButton.Text = "Show";
            this.showFocusWindowButton.UseVisualStyleBackColor = true;
            this.showFocusWindowButton.Click += new System.EventHandler(this.ShowFocusLayoutWindowButton_Click);
            // 
            // notificationsGroupBox
            // 
            this.notificationsGroupBox.Controls.Add(this.groupBox4);
            this.notificationsGroupBox.Controls.Add(this.autoLaunchNotificationsWindowCheckbox);
            this.notificationsGroupBox.Controls.Add(this.showNotificationsWindowButton);
            this.notificationsGroupBox.Controls.Add(this.groupBox3);
            this.notificationsGroupBox.Controls.Add(this.groupBox2);
            this.notificationsGroupBox.Font = new System.Drawing.Font("Calibri", 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.notificationsGroupBox.Location = new System.Drawing.Point(260, 227);
            this.notificationsGroupBox.Name = "notificationsGroupBox";
            this.notificationsGroupBox.Size = new System.Drawing.Size(636, 207);
            this.notificationsGroupBox.TabIndex = 10006;
            this.notificationsGroupBox.TabStop = false;
            this.notificationsGroupBox.Text = "Notifications";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.inMasteryNumericUpDown);
            this.groupBox4.Controls.Add(this.inLabel2);
            this.groupBox4.Controls.Add(this.outMasteryNumericUpDown);
            this.groupBox4.Controls.Add(this.selectCustomMasteryNotificationButton);
            this.groupBox4.Controls.Add(this.outLabel2);
            this.groupBox4.Controls.Add(this.scaleLabel2);
            this.groupBox4.Controls.Add(this.scaleMasteryNumericUpDown);
            this.groupBox4.Controls.Add(this.yPositionLabel2);
            this.groupBox4.Controls.Add(this.xPositionLabel2);
            this.groupBox4.Controls.Add(this.masteryEditOultineCheckbox);
            this.groupBox4.Controls.Add(this.customMasteryYNumericUpDown);
            this.groupBox4.Controls.Add(this.customMasteryXNumericUpDown);
            this.groupBox4.Controls.Add(this.useCustomMasteryCheckbox);
            this.groupBox4.Controls.Add(this.showGameMasteryButton);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Location = new System.Drawing.Point(402, 45);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 157);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mastery";
            // 
            // inMasteryNumericUpDown
            // 
            this.inMasteryNumericUpDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inMasteryNumericUpDown.Location = new System.Drawing.Point(151, 83);
            this.inMasteryNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.inMasteryNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.inMasteryNumericUpDown.Name = "inMasteryNumericUpDown";
            this.inMasteryNumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.inMasteryNumericUpDown.TabIndex = 26;
            this.inMasteryNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // inLabel2
            // 
            this.inLabel2.AutoSize = true;
            this.inLabel2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inLabel2.Location = new System.Drawing.Point(99, 89);
            this.inLabel2.Name = "inLabel2";
            this.inLabel2.Size = new System.Drawing.Size(38, 13);
            this.inLabel2.TabIndex = 25;
            this.inLabel2.Text = "In (ms)";
            // 
            // outMasteryNumericUpDown
            // 
            this.outMasteryNumericUpDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outMasteryNumericUpDown.Location = new System.Drawing.Point(151, 106);
            this.outMasteryNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.outMasteryNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.outMasteryNumericUpDown.Name = "outMasteryNumericUpDown";
            this.outMasteryNumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.outMasteryNumericUpDown.TabIndex = 24;
            this.outMasteryNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // selectCustomMasteryNotificationButton
            // 
            this.selectCustomMasteryNotificationButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomMasteryNotificationButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectCustomMasteryNotificationButton.Location = new System.Drawing.Point(7, 57);
            this.selectCustomMasteryNotificationButton.Name = "selectCustomMasteryNotificationButton";
            this.selectCustomMasteryNotificationButton.Size = new System.Drawing.Size(48, 23);
            this.selectCustomMasteryNotificationButton.TabIndex = 14;
            this.selectCustomMasteryNotificationButton.Text = "Select";
            this.selectCustomMasteryNotificationButton.UseVisualStyleBackColor = true;
            // 
            // outLabel2
            // 
            this.outLabel2.AutoSize = true;
            this.outLabel2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outLabel2.Location = new System.Drawing.Point(99, 110);
            this.outLabel2.Name = "outLabel2";
            this.outLabel2.Size = new System.Drawing.Size(46, 13);
            this.outLabel2.TabIndex = 23;
            this.outLabel2.Text = "Out (ms)";
            // 
            // scaleLabel2
            // 
            this.scaleLabel2.AutoSize = true;
            this.scaleLabel2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleLabel2.Location = new System.Drawing.Point(8, 136);
            this.scaleLabel2.Name = "scaleLabel2";
            this.scaleLabel2.Size = new System.Drawing.Size(32, 13);
            this.scaleLabel2.TabIndex = 21;
            this.scaleLabel2.Text = "Scale";
            this.scaleLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scaleMasteryNumericUpDown
            // 
            this.scaleMasteryNumericUpDown.DecimalPlaces = 2;
            this.scaleMasteryNumericUpDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleMasteryNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.scaleMasteryNumericUpDown.Location = new System.Drawing.Point(46, 131);
            this.scaleMasteryNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.scaleMasteryNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.scaleMasteryNumericUpDown.Name = "scaleMasteryNumericUpDown";
            this.scaleMasteryNumericUpDown.Size = new System.Drawing.Size(47, 21);
            this.scaleMasteryNumericUpDown.TabIndex = 20;
            this.scaleMasteryNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yPositionLabel2
            // 
            this.yPositionLabel2.AutoSize = true;
            this.yPositionLabel2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yPositionLabel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.yPositionLabel2.Location = new System.Drawing.Point(8, 110);
            this.yPositionLabel2.Name = "yPositionLabel2";
            this.yPositionLabel2.Size = new System.Drawing.Size(13, 15);
            this.yPositionLabel2.TabIndex = 19;
            this.yPositionLabel2.Text = "Y";
            this.yPositionLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xPositionLabel2
            // 
            this.xPositionLabel2.AutoSize = true;
            this.xPositionLabel2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPositionLabel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.xPositionLabel2.Location = new System.Drawing.Point(8, 86);
            this.xPositionLabel2.Name = "xPositionLabel2";
            this.xPositionLabel2.Size = new System.Drawing.Size(14, 15);
            this.xPositionLabel2.TabIndex = 18;
            this.xPositionLabel2.Text = "X";
            // 
            // masteryEditOultineCheckbox
            // 
            this.masteryEditOultineCheckbox.AutoSize = true;
            this.masteryEditOultineCheckbox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masteryEditOultineCheckbox.Location = new System.Drawing.Point(63, 63);
            this.masteryEditOultineCheckbox.Name = "masteryEditOultineCheckbox";
            this.masteryEditOultineCheckbox.Size = new System.Drawing.Size(44, 17);
            this.masteryEditOultineCheckbox.TabIndex = 17;
            this.masteryEditOultineCheckbox.Text = "Edit";
            this.masteryEditOultineCheckbox.UseVisualStyleBackColor = true;
            // 
            // customMasteryYNumericUpDown
            // 
            this.customMasteryYNumericUpDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryYNumericUpDown.Location = new System.Drawing.Point(23, 106);
            this.customMasteryYNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.customMasteryYNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.customMasteryYNumericUpDown.Name = "customMasteryYNumericUpDown";
            this.customMasteryYNumericUpDown.Size = new System.Drawing.Size(70, 21);
            this.customMasteryYNumericUpDown.TabIndex = 16;
            // 
            // customMasteryXNumericUpDown
            // 
            this.customMasteryXNumericUpDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryXNumericUpDown.Location = new System.Drawing.Point(23, 83);
            this.customMasteryXNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.customMasteryXNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.customMasteryXNumericUpDown.Name = "customMasteryXNumericUpDown";
            this.customMasteryXNumericUpDown.Size = new System.Drawing.Size(70, 21);
            this.customMasteryXNumericUpDown.TabIndex = 15;
            // 
            // useCustomMasteryCheckbox
            // 
            this.useCustomMasteryCheckbox.AutoSize = true;
            this.useCustomMasteryCheckbox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useCustomMasteryCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.useCustomMasteryCheckbox.Location = new System.Drawing.Point(63, 36);
            this.useCustomMasteryCheckbox.Name = "useCustomMasteryCheckbox";
            this.useCustomMasteryCheckbox.Size = new System.Drawing.Size(87, 17);
            this.useCustomMasteryCheckbox.TabIndex = 13;
            this.useCustomMasteryCheckbox.Text = "Custom Alert";
            this.useCustomMasteryCheckbox.UseVisualStyleBackColor = true;
            // 
            // showGameMasteryButton
            // 
            this.showGameMasteryButton.BackColor = System.Drawing.SystemColors.Control;
            this.showGameMasteryButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showGameMasteryButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showGameMasteryButton.Location = new System.Drawing.Point(6, 30);
            this.showGameMasteryButton.Name = "showGameMasteryButton";
            this.showGameMasteryButton.Size = new System.Drawing.Size(49, 23);
            this.showGameMasteryButton.TabIndex = 2;
            this.showGameMasteryButton.Text = "Show";
            this.showGameMasteryButton.UseVisualStyleBackColor = false;
            // 
            // autoLaunchNotificationsWindowCheckbox
            // 
            this.autoLaunchNotificationsWindowCheckbox.AutoSize = true;
            this.autoLaunchNotificationsWindowCheckbox.Font = new System.Drawing.Font("Calibri", 6F);
            this.autoLaunchNotificationsWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchNotificationsWindowCheckbox.Location = new System.Drawing.Point(9, 30);
            this.autoLaunchNotificationsWindowCheckbox.Name = "autoLaunchNotificationsWindowCheckbox";
            this.autoLaunchNotificationsWindowCheckbox.Size = new System.Drawing.Size(64, 14);
            this.autoLaunchNotificationsWindowCheckbox.TabIndex = 10022;
            this.autoLaunchNotificationsWindowCheckbox.Text = "Auto-Launch";
            this.autoLaunchNotificationsWindowCheckbox.UseVisualStyleBackColor = true;
            this.autoLaunchNotificationsWindowCheckbox.CheckedChanged += new System.EventHandler(this.AutoLaunchNotificationsWindow_CheckedChanged);
            // 
            // showNotificationsWindowButton
            // 
            this.showNotificationsWindowButton.Font = new System.Drawing.Font("Calibri", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showNotificationsWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showNotificationsWindowButton.Location = new System.Drawing.Point(82, 25);
            this.showNotificationsWindowButton.Name = "showNotificationsWindowButton";
            this.showNotificationsWindowButton.Size = new System.Drawing.Size(48, 20);
            this.showNotificationsWindowButton.TabIndex = 10021;
            this.showNotificationsWindowButton.Text = "Show";
            this.showNotificationsWindowButton.UseVisualStyleBackColor = true;
            this.showNotificationsWindowButton.Click += new System.EventHandler(this.ShowNotificationsWindowButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.inAchievementNumericUpDown);
            this.groupBox3.Controls.Add(this.inLabel1);
            this.groupBox3.Controls.Add(this.outAchievementNumericUpDown);
            this.groupBox3.Controls.Add(this.selectCustomAchievementButton);
            this.groupBox3.Controls.Add(this.outLabel1);
            this.groupBox3.Controls.Add(this.scaleLabel1);
            this.groupBox3.Controls.Add(this.scaleAchievementNumericUpDown);
            this.groupBox3.Controls.Add(this.yPositionLabel1);
            this.groupBox3.Controls.Add(this.xPositionLabel1);
            this.groupBox3.Controls.Add(this.acheivementEditOutlineCheckbox);
            this.groupBox3.Controls.Add(this.customAchievementYNumericUpDown);
            this.groupBox3.Controls.Add(this.customAchievementXNumericUpDown);
            this.groupBox3.Controls.Add(this.useCustomAchievementCheckbox);
            this.groupBox3.Controls.Add(this.showAchievementButton);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(185, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 157);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Achievement";
            // 
            // inAchievementNumericUpDown
            // 
            this.inAchievementNumericUpDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inAchievementNumericUpDown.Location = new System.Drawing.Point(142, 83);
            this.inAchievementNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.inAchievementNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.inAchievementNumericUpDown.Name = "inAchievementNumericUpDown";
            this.inAchievementNumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.inAchievementNumericUpDown.TabIndex = 26;
            this.inAchievementNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // inLabel1
            // 
            this.inLabel1.AutoSize = true;
            this.inLabel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inLabel1.Location = new System.Drawing.Point(92, 89);
            this.inLabel1.Name = "inLabel1";
            this.inLabel1.Size = new System.Drawing.Size(38, 13);
            this.inLabel1.TabIndex = 25;
            this.inLabel1.Text = "In (ms)";
            // 
            // outAchievementNumericUpDown
            // 
            this.outAchievementNumericUpDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outAchievementNumericUpDown.Location = new System.Drawing.Point(142, 108);
            this.outAchievementNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.outAchievementNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.outAchievementNumericUpDown.Name = "outAchievementNumericUpDown";
            this.outAchievementNumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.outAchievementNumericUpDown.TabIndex = 24;
            this.outAchievementNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // selectCustomAchievementButton
            // 
            this.selectCustomAchievementButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomAchievementButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectCustomAchievementButton.Location = new System.Drawing.Point(6, 57);
            this.selectCustomAchievementButton.Name = "selectCustomAchievementButton";
            this.selectCustomAchievementButton.Size = new System.Drawing.Size(48, 23);
            this.selectCustomAchievementButton.TabIndex = 14;
            this.selectCustomAchievementButton.Text = "Select";
            this.selectCustomAchievementButton.UseVisualStyleBackColor = true;
            // 
            // outLabel1
            // 
            this.outLabel1.AutoSize = true;
            this.outLabel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outLabel1.Location = new System.Drawing.Point(92, 110);
            this.outLabel1.Name = "outLabel1";
            this.outLabel1.Size = new System.Drawing.Size(46, 13);
            this.outLabel1.TabIndex = 23;
            this.outLabel1.Text = "Out (ms)";
            // 
            // scaleLabel1
            // 
            this.scaleLabel1.AutoSize = true;
            this.scaleLabel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleLabel1.Location = new System.Drawing.Point(7, 136);
            this.scaleLabel1.Name = "scaleLabel1";
            this.scaleLabel1.Size = new System.Drawing.Size(32, 13);
            this.scaleLabel1.TabIndex = 21;
            this.scaleLabel1.Text = "Scale";
            this.scaleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scaleAchievementNumericUpDown
            // 
            this.scaleAchievementNumericUpDown.DecimalPlaces = 2;
            this.scaleAchievementNumericUpDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleAchievementNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.scaleAchievementNumericUpDown.Location = new System.Drawing.Point(45, 131);
            this.scaleAchievementNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.scaleAchievementNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.scaleAchievementNumericUpDown.Name = "scaleAchievementNumericUpDown";
            this.scaleAchievementNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.scaleAchievementNumericUpDown.TabIndex = 20;
            this.scaleAchievementNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yPositionLabel1
            // 
            this.yPositionLabel1.AutoSize = true;
            this.yPositionLabel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yPositionLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.yPositionLabel1.Location = new System.Drawing.Point(4, 107);
            this.yPositionLabel1.Name = "yPositionLabel1";
            this.yPositionLabel1.Size = new System.Drawing.Size(13, 15);
            this.yPositionLabel1.TabIndex = 19;
            this.yPositionLabel1.Text = "Y";
            this.yPositionLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xPositionLabel1
            // 
            this.xPositionLabel1.AutoSize = true;
            this.xPositionLabel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPositionLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.xPositionLabel1.Location = new System.Drawing.Point(3, 86);
            this.xPositionLabel1.Name = "xPositionLabel1";
            this.xPositionLabel1.Size = new System.Drawing.Size(14, 15);
            this.xPositionLabel1.TabIndex = 18;
            this.xPositionLabel1.Text = "X";
            // 
            // acheivementEditOutlineCheckbox
            // 
            this.acheivementEditOutlineCheckbox.AutoSize = true;
            this.acheivementEditOutlineCheckbox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acheivementEditOutlineCheckbox.Location = new System.Drawing.Point(61, 61);
            this.acheivementEditOutlineCheckbox.Name = "acheivementEditOutlineCheckbox";
            this.acheivementEditOutlineCheckbox.Size = new System.Drawing.Size(44, 17);
            this.acheivementEditOutlineCheckbox.TabIndex = 17;
            this.acheivementEditOutlineCheckbox.Text = "Edit";
            this.acheivementEditOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // customAchievementYNumericUpDown
            // 
            this.customAchievementYNumericUpDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementYNumericUpDown.Location = new System.Drawing.Point(18, 106);
            this.customAchievementYNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.customAchievementYNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.customAchievementYNumericUpDown.Name = "customAchievementYNumericUpDown";
            this.customAchievementYNumericUpDown.Size = new System.Drawing.Size(70, 21);
            this.customAchievementYNumericUpDown.TabIndex = 16;
            // 
            // customAchievementXNumericUpDown
            // 
            this.customAchievementXNumericUpDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementXNumericUpDown.Location = new System.Drawing.Point(18, 83);
            this.customAchievementXNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.customAchievementXNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.customAchievementXNumericUpDown.Name = "customAchievementXNumericUpDown";
            this.customAchievementXNumericUpDown.Size = new System.Drawing.Size(70, 21);
            this.customAchievementXNumericUpDown.TabIndex = 15;
            // 
            // useCustomAchievementCheckbox
            // 
            this.useCustomAchievementCheckbox.AutoSize = true;
            this.useCustomAchievementCheckbox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useCustomAchievementCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.useCustomAchievementCheckbox.Location = new System.Drawing.Point(61, 36);
            this.useCustomAchievementCheckbox.Name = "useCustomAchievementCheckbox";
            this.useCustomAchievementCheckbox.Size = new System.Drawing.Size(87, 17);
            this.useCustomAchievementCheckbox.TabIndex = 13;
            this.useCustomAchievementCheckbox.Text = "Custom Alert";
            this.useCustomAchievementCheckbox.UseVisualStyleBackColor = true;
            // 
            // showAchievementButton
            // 
            this.showAchievementButton.BackColor = System.Drawing.SystemColors.Control;
            this.showAchievementButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAchievementButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showAchievementButton.Location = new System.Drawing.Point(6, 30);
            this.showAchievementButton.Name = "showAchievementButton";
            this.showAchievementButton.Size = new System.Drawing.Size(49, 23);
            this.showAchievementButton.TabIndex = 2;
            this.showAchievementButton.Text = "Show";
            this.showAchievementButton.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.notificationsFontComboBox);
            this.groupBox2.Controls.Add(this.notificationsBackgroundColorPickerButton);
            this.groupBox2.Controls.Add(this.notificationsBackgroundColorDisplayBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.notificationsFontOutlineSizeUpDown);
            this.groupBox2.Controls.Add(this.notificationsFontOutlineCheckbox);
            this.groupBox2.Controls.Add(this.notificationsFontOutlineColorPickerButton);
            this.groupBox2.Controls.Add(this.notificationsFontOutlineColorDisplayBox);
            this.groupBox2.Controls.Add(this.notificationsFontColorPickerButton);
            this.groupBox2.Controls.Add(this.notificationsFontColorDisplayBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(6, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 157);
            this.groupBox2.TabIndex = 10004;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Font";
            // 
            // notificationsBackgroundColorPickerButton
            // 
            this.notificationsBackgroundColorPickerButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsBackgroundColorPickerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsBackgroundColorPickerButton.Location = new System.Drawing.Point(110, 51);
            this.notificationsBackgroundColorPickerButton.Name = "notificationsBackgroundColorPickerButton";
            this.notificationsBackgroundColorPickerButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsBackgroundColorPickerButton.TabIndex = 37;
            this.notificationsBackgroundColorPickerButton.Text = "Set";
            this.notificationsBackgroundColorPickerButton.UseVisualStyleBackColor = true;
            // 
            // notificationsBackgroundColorDisplayBox
            // 
            this.notificationsBackgroundColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsBackgroundColorDisplayBox.Location = new System.Drawing.Point(84, 52);
            this.notificationsBackgroundColorDisplayBox.Name = "notificationsBackgroundColorDisplayBox";
            this.notificationsBackgroundColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsBackgroundColorDisplayBox.TabIndex = 36;
            this.notificationsBackgroundColorDisplayBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 35;
            this.label2.Text = "Background";
            // 
            // notificationsFontOutlineSizeUpDown
            // 
            this.notificationsFontOutlineSizeUpDown.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsFontOutlineSizeUpDown.Location = new System.Drawing.Point(110, 126);
            this.notificationsFontOutlineSizeUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.notificationsFontOutlineSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.notificationsFontOutlineSizeUpDown.Name = "notificationsFontOutlineSizeUpDown";
            this.notificationsFontOutlineSizeUpDown.Size = new System.Drawing.Size(49, 23);
            this.notificationsFontOutlineSizeUpDown.TabIndex = 28;
            this.notificationsFontOutlineSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // notificationsFontOutlineCheckbox
            // 
            this.notificationsFontOutlineCheckbox.AutoSize = true;
            this.notificationsFontOutlineCheckbox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsFontOutlineCheckbox.Location = new System.Drawing.Point(9, 104);
            this.notificationsFontOutlineCheckbox.Name = "notificationsFontOutlineCheckbox";
            this.notificationsFontOutlineCheckbox.Size = new System.Drawing.Size(61, 17);
            this.notificationsFontOutlineCheckbox.TabIndex = 27;
            this.notificationsFontOutlineCheckbox.Text = "Outline";
            this.notificationsFontOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // notificationsFontOutlineColorPickerButton
            // 
            this.notificationsFontOutlineColorPickerButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsFontOutlineColorPickerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsFontOutlineColorPickerButton.Location = new System.Drawing.Point(110, 99);
            this.notificationsFontOutlineColorPickerButton.Name = "notificationsFontOutlineColorPickerButton";
            this.notificationsFontOutlineColorPickerButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsFontOutlineColorPickerButton.TabIndex = 26;
            this.notificationsFontOutlineColorPickerButton.Text = "Set";
            this.notificationsFontOutlineColorPickerButton.UseVisualStyleBackColor = true;
            // 
            // notificationsFontOutlineColorDisplayBox
            // 
            this.notificationsFontOutlineColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsFontOutlineColorDisplayBox.Location = new System.Drawing.Point(84, 99);
            this.notificationsFontOutlineColorDisplayBox.Name = "notificationsFontOutlineColorDisplayBox";
            this.notificationsFontOutlineColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsFontOutlineColorDisplayBox.TabIndex = 25;
            this.notificationsFontOutlineColorDisplayBox.TabStop = false;
            // 
            // notificationsFontColorPickerButton
            // 
            this.notificationsFontColorPickerButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsFontColorPickerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsFontColorPickerButton.Location = new System.Drawing.Point(110, 75);
            this.notificationsFontColorPickerButton.Name = "notificationsFontColorPickerButton";
            this.notificationsFontColorPickerButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsFontColorPickerButton.TabIndex = 22;
            this.notificationsFontColorPickerButton.Text = "Set";
            this.notificationsFontColorPickerButton.UseVisualStyleBackColor = true;
            // 
            // notificationsFontColorDisplayBox
            // 
            this.notificationsFontColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsFontColorDisplayBox.Location = new System.Drawing.Point(84, 75);
            this.notificationsFontColorDisplayBox.Name = "notificationsFontColorDisplayBox";
            this.notificationsFontColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsFontColorDisplayBox.TabIndex = 21;
            this.notificationsFontColorDisplayBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Font Color";
            // 
            // userInfoGroupBox
            // 
            this.userInfoGroupBox.Controls.Add(this.userProfilePictureBox);
            this.userInfoGroupBox.Controls.Add(this.apiKeyLabel);
            this.userInfoGroupBox.Controls.Add(this.apiKeyTextBox);
            this.userInfoGroupBox.Controls.Add(this.usernameLabel);
            this.userInfoGroupBox.Controls.Add(this.supportButton);
            this.userInfoGroupBox.Controls.Add(this.usernameTextBox);
            this.userInfoGroupBox.Controls.Add(this.startButton);
            this.userInfoGroupBox.Controls.Add(this.pointsLabel);
            this.userInfoGroupBox.Controls.Add(this.autoStartCheckbox);
            this.userInfoGroupBox.Controls.Add(this.siteRankLabel);
            this.userInfoGroupBox.Controls.Add(this.stopButton);
            this.userInfoGroupBox.Controls.Add(this.awardsLabel);
            this.userInfoGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userInfoGroupBox.Font = new System.Drawing.Font("Calibri", 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userInfoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.userInfoGroupBox.Name = "userInfoGroupBox";
            this.userInfoGroupBox.Size = new System.Drawing.Size(242, 180);
            this.userInfoGroupBox.TabIndex = 10008;
            this.userInfoGroupBox.TabStop = false;
            this.userInfoGroupBox.Text = "User Info";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Calibri", 7.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(165, 96);
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
            this.raConnectionStatusPictureBox.Location = new System.Drawing.Point(12, 195);
            this.raConnectionStatusPictureBox.Name = "raConnectionStatusPictureBox";
            this.raConnectionStatusPictureBox.Size = new System.Drawing.Size(20, 20);
            this.raConnectionStatusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.raConnectionStatusPictureBox.TabIndex = 10025;
            this.raConnectionStatusPictureBox.TabStop = false;
            // 
            // raConnectivityLabel
            // 
            this.raConnectivityLabel.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raConnectivityLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.raConnectivityLabel.Location = new System.Drawing.Point(9, 215);
            this.raConnectivityLabel.Name = "raConnectivityLabel";
            this.raConnectivityLabel.Size = new System.Drawing.Size(248, 41);
            this.raConnectivityLabel.TabIndex = 10026;
            this.raConnectivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statsFontComboBox
            // 
            this.statsFontComboBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsFontComboBox.FormattingEnabled = true;
            this.statsFontComboBox.Location = new System.Drawing.Point(9, 28);
            this.statsFontComboBox.Name = "statsFontComboBox";
            this.statsFontComboBox.Size = new System.Drawing.Size(150, 23);
            this.statsFontComboBox.TabIndex = 38;
            // 
            // focusFontComboBox
            // 
            this.focusFontComboBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusFontComboBox.FormattingEnabled = true;
            this.focusFontComboBox.Location = new System.Drawing.Point(6, 28);
            this.focusFontComboBox.Name = "focusFontComboBox";
            this.focusFontComboBox.Size = new System.Drawing.Size(152, 23);
            this.focusFontComboBox.TabIndex = 38;
            // 
            // notificationsFontComboBox
            // 
            this.notificationsFontComboBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsFontComboBox.FormattingEnabled = true;
            this.notificationsFontComboBox.Location = new System.Drawing.Point(9, 22);
            this.notificationsFontComboBox.Name = "notificationsFontComboBox";
            this.notificationsFontComboBox.Size = new System.Drawing.Size(150, 23);
            this.notificationsFontComboBox.TabIndex = 38;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(900, 440);
            this.Controls.Add(this.raConnectivityLabel);
            this.Controls.Add(this.raConnectionStatusPictureBox);
            this.Controls.Add(this.userInfoGroupBox);
            this.Controls.Add(this.statsGroupBox);
            this.Controls.Add(this.timerStatusLabel);
            this.Controls.Add(this.gameInformationGroupBox);
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
            this.statsGroupBox.ResumeLayout(false);
            this.statsGroupBox.PerformLayout();
            this.statsFontGroupBox.ResumeLayout(false);
            this.statsFontGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statsBackgroundColorDisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsFontOutlineSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsFontOutlineColorDisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsFontColorDisplayBox)).EndInit();
            this.focusGroupBox.ResumeLayout(false);
            this.focusGroupBox.PerformLayout();
            this.focusFontGroupBox.ResumeLayout(false);
            this.focusFontGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusBackgroundColorDisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusFontOutlineSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusFontOutlineColorDisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusFontColorDisplayBox)).EndInit();
            this.lockedAchievementsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).EndInit();
            this.notificationsGroupBox.ResumeLayout(false);
            this.notificationsGroupBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inMasteryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outMasteryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleMasteryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryXNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inAchievementNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outAchievementNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleAchievementNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementXNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsBackgroundColorDisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsFontOutlineSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsFontOutlineColorDisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsFontColorDisplayBox)).EndInit();
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
        private GroupBox statsGroupBox;
        private CheckBox autoLaunchStatsWindowCheckbox;
        private Button showStatsWindowButton;
        private CheckBox autoLaunchNotificationsWindowCheckbox;
        private Button showNotificationsWindowButton;
        private Label timerStatusLabel;
        private PictureBox raConnectionStatusPictureBox;
        private Label raConnectivityLabel;
        private Button notificationsBackgroundColorPickerButton;
        private PictureBox notificationsBackgroundColorDisplayBox;
        private Label label2;
        private NumericUpDown notificationsFontOutlineSizeUpDown;
        private CheckBox notificationsFontOutlineCheckbox;
        private Button notificationsFontOutlineColorPickerButton;
        private PictureBox notificationsFontOutlineColorDisplayBox;
        private Button notificationsFontColorPickerButton;
        private PictureBox notificationsFontColorDisplayBox;
        private Label label6;
        private GroupBox groupBox2;
        private NumericUpDown inAchievementNumericUpDown;
        private Label inLabel1;
        private NumericUpDown outAchievementNumericUpDown;
        private Button selectCustomAchievementButton;
        private Label outLabel1;
        private Label scaleLabel1;
        private NumericUpDown scaleAchievementNumericUpDown;
        private Label yPositionLabel1;
        private Label xPositionLabel1;
        private CheckBox acheivementEditOutlineCheckbox;
        private NumericUpDown customAchievementYNumericUpDown;
        private NumericUpDown customAchievementXNumericUpDown;
        private CheckBox useCustomAchievementCheckbox;
        private Button showAchievementButton;
        private GroupBox groupBox3;
        private GroupBox statsFontGroupBox;
        private Button button9;
        private PictureBox statsBackgroundColorDisplayBox;
        private Label label19;
        private NumericUpDown statsFontOutlineSizeUpDown;
        private CheckBox statsFontOutlineCheckbox;
        private Button statsFontOutlineColorPickerButton;
        private PictureBox statsFontOutlineColorDisplayBox;
        private Button statsFontColorPickerButton;
        private PictureBox statsFontColorDisplayBox;
        private Label statsFontColorLabel;
        private GroupBox focusFontGroupBox;
        private Button focusBackgroundColorPickerButton;
        private PictureBox focusBackgroundColorDisplayBox;
        private Label label26;
        private NumericUpDown focusFontOutlineSizeUpDown;
        private CheckBox focusFontOutlineCheckbox;
        private Button focusFontOutlineColorPickerButton;
        private PictureBox focusFontOutlineColorDisplayBox;
        private Button focusFontColorPickerButton;
        private PictureBox focusFontColorDisplayBox;
        private Label label30;
        private GroupBox groupBox4;
        private NumericUpDown inMasteryNumericUpDown;
        private Label inLabel2;
        private NumericUpDown outMasteryNumericUpDown;
        private Button selectCustomMasteryNotificationButton;
        private Label outLabel2;
        private Label scaleLabel2;
        private NumericUpDown scaleMasteryNumericUpDown;
        private Label yPositionLabel2;
        private Label xPositionLabel2;
        private CheckBox masteryEditOultineCheckbox;
        private NumericUpDown customMasteryYNumericUpDown;
        private NumericUpDown customMasteryXNumericUpDown;
        private CheckBox useCustomMasteryCheckbox;
        private Button showGameMasteryButton;
        private GroupBox lockedAchievementsGroupBox;
        private Label label33;
        private Label focusAchievementDescriptionLabel;
        private PictureBox focusAchievementPictureBox;
        private Button focusAchievementButtonRight;
        private Button hideFocusButton;
        private Button focusAchievementButtonLeft;
        private Label focusAchievementTitleLabel;
        private Button setFocusButton;
        private ColorDialog colorDialog1;
        private OpenFileDialog openFileDialog1;
        private ComboBox statsFontComboBox;
        private ComboBox focusFontComboBox;
        private ComboBox notificationsFontComboBox;
    }
}

