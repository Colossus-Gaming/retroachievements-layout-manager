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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.userProfilePictureBox = new System.Windows.Forms.PictureBox();
            this.autoStartCheckbox = new System.Windows.Forms.CheckBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.timerStatusLabel = new System.Windows.Forms.Label();
            this.statsGroupBox = new System.Windows.Forms.GroupBox();
            this.autoLaunchStatsWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.customizeStatsButton = new System.Windows.Forms.Button();
            this.openStatsWindowButton = new System.Windows.Forms.Button();
            this.focusGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.focusAchievementButtonRight = new System.Windows.Forms.Button();
            this.focusAchievementButtonLeft = new System.Windows.Forms.Button();
            this.setFocusButton = new System.Windows.Forms.Button();
            this.focusAchievementDescriptionLabel = new System.Windows.Forms.Label();
            this.focusAchievementPictureBox = new System.Windows.Forms.PictureBox();
            this.focusAchievementTitleLabel = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.customizeFocusButton = new System.Windows.Forms.Button();
            this.autoLaunchFocusWindowCheckBox = new System.Windows.Forms.CheckBox();
            this.openFocusWindowButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.raConnectionStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsGroupBox = new System.Windows.Forms.GroupBox();
            this.customizeAlertsButton = new System.Windows.Forms.Button();
            this.autoLaunchNotificationsWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.openNotificationWindowButton = new System.Windows.Forms.Button();
            this.userInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.startButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.customizeGameInfoButton = new System.Windows.Forms.Button();
            this.autoLaunchGameInfoWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.openGameInfoWindowButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.customizeLastFiveButton = new System.Windows.Forms.Button();
            this.autoLaunchLastFiveWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.openLastFiveWindowButton = new System.Windows.Forms.Button();
            this.statsGameRatioOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsTruePointsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsPointsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsRatioOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsAwardsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsRankOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsCustomizationsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.statsRadioButtonBackslash = new System.Windows.Forms.RadioButton();
            this.statsRadioButtonSemicolon = new System.Windows.Forms.RadioButton();
            this.statsRadioButtonDot = new System.Windows.Forms.RadioButton();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.gameRatioEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.gameTruePointsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.gamePointsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.completedEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.gameAchievementsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.button11 = new System.Windows.Forms.Button();
            this.statsGameAchievementsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsGamePointsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsGameTruePointsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsCompletedOverrideTextBox = new System.Windows.Forms.TextBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.truePointsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.ratioEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.pointsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.awardsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.rankEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.statsDefaultButton = new System.Windows.Forms.Button();
            this.gameInfoOverrideSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.releasedDateEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.consoleEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.publisherEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.genreEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.developerEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.titleEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoTitleOverrideTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoDefaultButton = new System.Windows.Forms.Button();
            this.gameInfoGenreOverrideTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoConsoleOverrideTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoPublisherOverrideTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoReleaseDateOverrideTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoDeveloperOverrideTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontBorderEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.fontSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.windowBackgroundGroupBox = new System.Windows.Forms.GroupBox();
            this.windowBackgroundColorButton = new System.Windows.Forms.Button();
            this.windowBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.borderBackgroundGroupBox = new System.Windows.Forms.GroupBox();
            this.borderBackgroundColorButton = new System.Windows.Forms.Button();
            this.borderBackgroudColorPictureBox = new System.Windows.Forms.PictureBox();
            this.pointsFontGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pointsFontOutlineColorButton = new System.Windows.Forms.Button();
            this.pointsFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.pointsFontColorButton = new System.Windows.Forms.Button();
            this.pointsFontOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.pointsFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pointsFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.pointsFontFamilyComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionFontGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.descriptionFontOutlineColorButton = new System.Windows.Forms.Button();
            this.descriptionFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.descriptionFontColorButton = new System.Windows.Forms.Button();
            this.descriptionFontOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.descriptionFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.descriptionFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.descriptionFontFamilyComboBox = new System.Windows.Forms.ComboBox();
            this.lineFontGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lineOutlineColorButton = new System.Windows.Forms.Button();
            this.lineOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.lineColorButton = new System.Windows.Forms.Button();
            this.lineOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.lineOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fontSimpleCheckbox = new System.Windows.Forms.CheckBox();
            this.titleFontGroupBox = new System.Windows.Forms.GroupBox();
            this.titleOutlineLabel = new System.Windows.Forms.Label();
            this.titleFontOutlineColorButton = new System.Windows.Forms.Button();
            this.titleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.titleFontColorButton = new System.Windows.Forms.Button();
            this.titleFontOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.titleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.titleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.titleFontFamilyComboBox = new System.Windows.Forms.ComboBox();
            this.playAchievementButton = new System.Windows.Forms.Button();
            this.customAchievementEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.selectCustomAchievementButton = new System.Windows.Forms.Button();
            this.acheivementEditOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.achievementPositionGroupBox = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.scaleAchievementNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.xPositionLabel1 = new System.Windows.Forms.Label();
            this.yPositionLabel1 = new System.Windows.Forms.Label();
            this.customAchievementXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.customAchievementYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.notificationAchievementInNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsAchievementAnimationInComboBox = new System.Windows.Forms.ComboBox();
            this.customAchievementInSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.notificationAchievementOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsAchievementAnimationOutComboBox = new System.Windows.Forms.ComboBox();
            this.customAchievementOutSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.customAchievementSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customMasterySettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.playMasteryButton = new System.Windows.Forms.Button();
            this.selectCustomMasteryNotificationButton = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.scaleMasteryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.customMasteryXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.customMasteryYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.masteryEditOultineCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.notificationMasteryOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsMasteryAnimationOutComboBox = new System.Windows.Forms.ComboBox();
            this.customMasteryOutSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.notificationMasteryInNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsMasteryAnimationInComboBox = new System.Windows.Forms.ComboBox();
            this.customMasteryInSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.customMasteryEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.achievementListGroupBox = new System.Windows.Forms.GroupBox();
            this.autoLaunchAchievementListWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.customizeAchievementListButton = new System.Windows.Forms.Button();
            this.openAchievementListWindowButton = new System.Windows.Forms.Button();
            this.achievementListOverrideSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.achievementListFitCheckBox = new System.Windows.Forms.CheckBox();
            this.achievementListSingleContainer = new System.Windows.Forms.CheckBox();
            this.achievementListCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.columnBasedRadioButton = new System.Windows.Forms.RadioButton();
            this.rowBasedRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePictureBox)).BeginInit();
            this.statsGroupBox.SuspendLayout();
            this.focusGroupBox.SuspendLayout();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raConnectionStatusPictureBox)).BeginInit();
            this.notificationsGroupBox.SuspendLayout();
            this.userInfoGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statsCustomizationsGroupBox.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.gameInfoOverrideSettingsGroupBox.SuspendLayout();
            this.fontSettingsGroupBox.SuspendLayout();
            this.windowBackgroundGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowBackgroundColorPictureBox)).BeginInit();
            this.borderBackgroundGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderBackgroudColorPictureBox)).BeginInit();
            this.pointsFontGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointsFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsFontColorPictureBox)).BeginInit();
            this.descriptionFontGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionFontColorPictureBox)).BeginInit();
            this.lineFontGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineColorPictureBox)).BeginInit();
            this.titleFontGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titleFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleFontColorPictureBox)).BeginInit();
            this.achievementPositionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleAchievementNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementYNumericUpDown)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationAchievementInNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementInSpeedUpDown)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationAchievementOutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementOutSpeedUpDown)).BeginInit();
            this.customAchievementSettingsGroupBox.SuspendLayout();
            this.customMasterySettingsGroupBox.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleMasteryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryYNumericUpDown)).BeginInit();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationMasteryOutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryOutSpeedUpDown)).BeginInit();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationMasteryInNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryInSpeedUpDown)).BeginInit();
            this.achievementListGroupBox.SuspendLayout();
            this.achievementListOverrideSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.achievementListCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // apiKeyLabel
            // 
            this.apiKeyLabel.AutoSize = true;
            this.apiKeyLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyLabel.Location = new System.Drawing.Point(92, 58);
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(70, 13);
            this.apiKeyLabel.TabIndex = 31;
            this.apiKeyLabel.Text = "API Key";
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.Font = new System.Drawing.Font("Calibri", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyTextBox.Location = new System.Drawing.Point(92, 75);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.PasswordChar = '*';
            this.apiKeyTextBox.Size = new System.Drawing.Size(199, 19);
            this.apiKeyTextBox.TabIndex = 1;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(91, 19);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(79, 13);
            this.usernameLabel.TabIndex = 26;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Calibri", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(92, 36);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(199, 19);
            this.usernameTextBox.TabIndex = 0;
            // 
            // userProfilePictureBox
            // 
            this.userProfilePictureBox.Location = new System.Drawing.Point(6, 15);
            this.userProfilePictureBox.Name = "userProfilePictureBox";
            this.userProfilePictureBox.Size = new System.Drawing.Size(80, 80);
            this.userProfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userProfilePictureBox.TabIndex = 20;
            this.userProfilePictureBox.TabStop = false;
            // 
            // autoStartCheckbox
            // 
            this.autoStartCheckbox.AutoSize = true;
            this.autoStartCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoStartCheckbox.Location = new System.Drawing.Point(92, -2);
            this.autoStartCheckbox.Name = "autoStartCheckbox";
            this.autoStartCheckbox.Size = new System.Drawing.Size(54, 18);
            this.autoStartCheckbox.TabIndex = 2;
            this.autoStartCheckbox.Text = "Auto";
            this.autoStartCheckbox.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopButton.Location = new System.Drawing.Point(292, 73);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(69, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // timerStatusLabel
            // 
            this.timerStatusLabel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timerStatusLabel.Location = new System.Drawing.Point(9, 24);
            this.timerStatusLabel.Name = "timerStatusLabel";
            this.timerStatusLabel.Size = new System.Drawing.Size(353, 61);
            this.timerStatusLabel.TabIndex = 10024;
            this.timerStatusLabel.Text = "Offline";
            // 
            // statsGroupBox
            // 
            this.statsGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.statsGroupBox.Controls.Add(this.autoLaunchStatsWindowCheckbox);
            this.statsGroupBox.Controls.Add(this.customizeStatsButton);
            this.statsGroupBox.Controls.Add(this.openStatsWindowButton);
            this.statsGroupBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statsGroupBox.Location = new System.Drawing.Point(233, 251);
            this.statsGroupBox.Name = "statsGroupBox";
            this.statsGroupBox.Size = new System.Drawing.Size(72, 105);
            this.statsGroupBox.TabIndex = 10023;
            this.statsGroupBox.TabStop = false;
            this.statsGroupBox.Text = "Stats";
            // 
            // autoLaunchStatsWindowCheckbox
            // 
            this.autoLaunchStatsWindowCheckbox.AutoSize = true;
            this.autoLaunchStatsWindowCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLaunchStatsWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchStatsWindowCheckbox.Location = new System.Drawing.Point(6, 18);
            this.autoLaunchStatsWindowCheckbox.Name = "autoLaunchStatsWindowCheckbox";
            this.autoLaunchStatsWindowCheckbox.Size = new System.Drawing.Size(54, 18);
            this.autoLaunchStatsWindowCheckbox.TabIndex = 10022;
            this.autoLaunchStatsWindowCheckbox.Text = "Auto";
            this.autoLaunchStatsWindowCheckbox.UseVisualStyleBackColor = true;
            // 
            // customizeStatsButton
            // 
            this.customizeStatsButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeStatsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeStatsButton.Location = new System.Drawing.Point(6, 70);
            this.customizeStatsButton.Name = "customizeStatsButton";
            this.customizeStatsButton.Size = new System.Drawing.Size(61, 28);
            this.customizeStatsButton.TabIndex = 10024;
            this.customizeStatsButton.Text = "Custom";
            this.customizeStatsButton.UseVisualStyleBackColor = true;
            // 
            // openStatsWindowButton
            // 
            this.openStatsWindowButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openStatsWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openStatsWindowButton.Location = new System.Drawing.Point(6, 37);
            this.openStatsWindowButton.Name = "openStatsWindowButton";
            this.openStatsWindowButton.Size = new System.Drawing.Size(61, 28);
            this.openStatsWindowButton.TabIndex = 10021;
            this.openStatsWindowButton.Text = "Open";
            this.openStatsWindowButton.UseVisualStyleBackColor = true;
            // 
            // focusGroupBox
            // 
            this.focusGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.focusGroupBox.Controls.Add(this.groupBox20);
            this.focusGroupBox.Controls.Add(this.customizeFocusButton);
            this.focusGroupBox.Controls.Add(this.autoLaunchFocusWindowCheckBox);
            this.focusGroupBox.Controls.Add(this.openFocusWindowButton);
            this.focusGroupBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusGroupBox.Location = new System.Drawing.Point(12, 118);
            this.focusGroupBox.Name = "focusGroupBox";
            this.focusGroupBox.Size = new System.Drawing.Size(367, 127);
            this.focusGroupBox.TabIndex = 10001;
            this.focusGroupBox.TabStop = false;
            this.focusGroupBox.Text = "Focus";
            // 
            // groupBox20
            // 
            this.groupBox20.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox20.Controls.Add(this.focusAchievementButtonRight);
            this.groupBox20.Controls.Add(this.focusAchievementButtonLeft);
            this.groupBox20.Controls.Add(this.setFocusButton);
            this.groupBox20.Controls.Add(this.focusAchievementDescriptionLabel);
            this.groupBox20.Controls.Add(this.focusAchievementPictureBox);
            this.groupBox20.Controls.Add(this.focusAchievementTitleLabel);
            this.groupBox20.Controls.Add(this.label33);
            this.groupBox20.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox20.Location = new System.Drawing.Point(74, 15);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(288, 106);
            this.groupBox20.TabIndex = 10026;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Current";
            // 
            // focusAchievementButtonRight
            // 
            this.focusAchievementButtonRight.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonRight.Location = new System.Drawing.Point(240, -1);
            this.focusAchievementButtonRight.Name = "focusAchievementButtonRight";
            this.focusAchievementButtonRight.Size = new System.Drawing.Size(42, 22);
            this.focusAchievementButtonRight.TabIndex = 10;
            this.focusAchievementButtonRight.Text = ">";
            this.focusAchievementButtonRight.UseVisualStyleBackColor = true;
            // 
            // focusAchievementButtonLeft
            // 
            this.focusAchievementButtonLeft.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonLeft.Location = new System.Drawing.Point(192, -1);
            this.focusAchievementButtonLeft.Name = "focusAchievementButtonLeft";
            this.focusAchievementButtonLeft.Size = new System.Drawing.Size(42, 22);
            this.focusAchievementButtonLeft.TabIndex = 9;
            this.focusAchievementButtonLeft.Text = "<";
            this.focusAchievementButtonLeft.UseVisualStyleBackColor = true;
            // 
            // setFocusButton
            // 
            this.setFocusButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setFocusButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setFocusButton.Location = new System.Drawing.Point(140, -1);
            this.setFocusButton.Name = "setFocusButton";
            this.setFocusButton.Size = new System.Drawing.Size(46, 22);
            this.setFocusButton.TabIndex = 10001;
            this.setFocusButton.Text = "Set";
            this.setFocusButton.UseVisualStyleBackColor = true;
            // 
            // focusAchievementDescriptionLabel
            // 
            this.focusAchievementDescriptionLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementDescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusAchievementDescriptionLabel.Location = new System.Drawing.Point(6, 58);
            this.focusAchievementDescriptionLabel.Name = "focusAchievementDescriptionLabel";
            this.focusAchievementDescriptionLabel.Size = new System.Drawing.Size(276, 42);
            this.focusAchievementDescriptionLabel.TabIndex = 5;
            // 
            // focusAchievementPictureBox
            // 
            this.focusAchievementPictureBox.InitialImage = null;
            this.focusAchievementPictureBox.Location = new System.Drawing.Point(6, 13);
            this.focusAchievementPictureBox.Name = "focusAchievementPictureBox";
            this.focusAchievementPictureBox.Size = new System.Drawing.Size(40, 40);
            this.focusAchievementPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.focusAchievementPictureBox.TabIndex = 21;
            this.focusAchievementPictureBox.TabStop = false;
            // 
            // focusAchievementTitleLabel
            // 
            this.focusAchievementTitleLabel.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusAchievementTitleLabel.Location = new System.Drawing.Point(48, 24);
            this.focusAchievementTitleLabel.Name = "focusAchievementTitleLabel";
            this.focusAchievementTitleLabel.Size = new System.Drawing.Size(234, 26);
            this.focusAchievementTitleLabel.TabIndex = 6;
            // 
            // label33
            // 
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label33.Location = new System.Drawing.Point(50, 51);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(230, 2);
            this.label33.TabIndex = 10002;
            // 
            // customizeFocusButton
            // 
            this.customizeFocusButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeFocusButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeFocusButton.Location = new System.Drawing.Point(4, 69);
            this.customizeFocusButton.Name = "customizeFocusButton";
            this.customizeFocusButton.Size = new System.Drawing.Size(62, 28);
            this.customizeFocusButton.TabIndex = 10025;
            this.customizeFocusButton.Text = "Custom";
            this.customizeFocusButton.UseVisualStyleBackColor = true;
            // 
            // autoLaunchFocusWindowCheckBox
            // 
            this.autoLaunchFocusWindowCheckBox.AutoSize = true;
            this.autoLaunchFocusWindowCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLaunchFocusWindowCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchFocusWindowCheckBox.Location = new System.Drawing.Point(6, 18);
            this.autoLaunchFocusWindowCheckBox.Name = "autoLaunchFocusWindowCheckBox";
            this.autoLaunchFocusWindowCheckBox.Size = new System.Drawing.Size(54, 18);
            this.autoLaunchFocusWindowCheckBox.TabIndex = 10020;
            this.autoLaunchFocusWindowCheckBox.Text = "Auto";
            this.autoLaunchFocusWindowCheckBox.UseVisualStyleBackColor = true;
            // 
            // openFocusWindowButton
            // 
            this.openFocusWindowButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFocusWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openFocusWindowButton.Location = new System.Drawing.Point(4, 37);
            this.openFocusWindowButton.Name = "openFocusWindowButton";
            this.openFocusWindowButton.Size = new System.Drawing.Size(62, 28);
            this.openFocusWindowButton.TabIndex = 10014;
            this.openFocusWindowButton.Text = "Open";
            this.openFocusWindowButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Controls.Add(this.timerStatusLabel);
            this.groupBox2.Controls.Add(this.raConnectionStatusPictureBox);
            this.groupBox2.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(11, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 98);
            this.groupBox2.TabIndex = 10027;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // raConnectionStatusPictureBox
            // 
            this.raConnectionStatusPictureBox.Image = global::Retro_Achievement_Tracker.Properties.Resources.red_button;
            this.raConnectionStatusPictureBox.Location = new System.Drawing.Point(339, 0);
            this.raConnectionStatusPictureBox.Name = "raConnectionStatusPictureBox";
            this.raConnectionStatusPictureBox.Size = new System.Drawing.Size(23, 23);
            this.raConnectionStatusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.raConnectionStatusPictureBox.TabIndex = 10025;
            this.raConnectionStatusPictureBox.TabStop = false;
            // 
            // notificationsGroupBox
            // 
            this.notificationsGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.notificationsGroupBox.Controls.Add(this.customizeAlertsButton);
            this.notificationsGroupBox.Controls.Add(this.autoLaunchNotificationsWindowCheckbox);
            this.notificationsGroupBox.Controls.Add(this.openNotificationWindowButton);
            this.notificationsGroupBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.notificationsGroupBox.Location = new System.Drawing.Point(12, 251);
            this.notificationsGroupBox.Name = "notificationsGroupBox";
            this.notificationsGroupBox.Size = new System.Drawing.Size(72, 105);
            this.notificationsGroupBox.TabIndex = 10006;
            this.notificationsGroupBox.TabStop = false;
            this.notificationsGroupBox.Text = "Alerts";
            // 
            // customizeAlertsButton
            // 
            this.customizeAlertsButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeAlertsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeAlertsButton.Location = new System.Drawing.Point(6, 70);
            this.customizeAlertsButton.Name = "customizeAlertsButton";
            this.customizeAlertsButton.Size = new System.Drawing.Size(61, 28);
            this.customizeAlertsButton.TabIndex = 10025;
            this.customizeAlertsButton.Text = "Custom";
            this.customizeAlertsButton.UseVisualStyleBackColor = true;
            // 
            // autoLaunchNotificationsWindowCheckbox
            // 
            this.autoLaunchNotificationsWindowCheckbox.AutoSize = true;
            this.autoLaunchNotificationsWindowCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLaunchNotificationsWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchNotificationsWindowCheckbox.Location = new System.Drawing.Point(6, 18);
            this.autoLaunchNotificationsWindowCheckbox.Name = "autoLaunchNotificationsWindowCheckbox";
            this.autoLaunchNotificationsWindowCheckbox.Size = new System.Drawing.Size(54, 18);
            this.autoLaunchNotificationsWindowCheckbox.TabIndex = 10022;
            this.autoLaunchNotificationsWindowCheckbox.Text = "Auto";
            this.autoLaunchNotificationsWindowCheckbox.UseVisualStyleBackColor = true;
            // 
            // openNotificationWindowButton
            // 
            this.openNotificationWindowButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openNotificationWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openNotificationWindowButton.Location = new System.Drawing.Point(5, 36);
            this.openNotificationWindowButton.Name = "openNotificationWindowButton";
            this.openNotificationWindowButton.Size = new System.Drawing.Size(61, 28);
            this.openNotificationWindowButton.TabIndex = 10021;
            this.openNotificationWindowButton.Text = "Open";
            this.openNotificationWindowButton.UseVisualStyleBackColor = true;
            // 
            // userInfoGroupBox
            // 
            this.userInfoGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.userInfoGroupBox.Controls.Add(this.userProfilePictureBox);
            this.userInfoGroupBox.Controls.Add(this.apiKeyLabel);
            this.userInfoGroupBox.Controls.Add(this.apiKeyTextBox);
            this.userInfoGroupBox.Controls.Add(this.usernameLabel);
            this.userInfoGroupBox.Controls.Add(this.usernameTextBox);
            this.userInfoGroupBox.Controls.Add(this.startButton);
            this.userInfoGroupBox.Controls.Add(this.autoStartCheckbox);
            this.userInfoGroupBox.Controls.Add(this.stopButton);
            this.userInfoGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userInfoGroupBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userInfoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.userInfoGroupBox.Name = "userInfoGroupBox";
            this.userInfoGroupBox.Size = new System.Drawing.Size(367, 100);
            this.userInfoGroupBox.TabIndex = 10008;
            this.userInfoGroupBox.TabStop = false;
            this.userInfoGroupBox.Text = "User Info";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(293, 35);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(69, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Controls.Add(this.customizeGameInfoButton);
            this.groupBox1.Controls.Add(this.autoLaunchGameInfoWindowCheckbox);
            this.groupBox1.Controls.Add(this.openGameInfoWindowButton);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(159, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(72, 105);
            this.groupBox1.TabIndex = 10025;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game";
            // 
            // customizeGameInfoButton
            // 
            this.customizeGameInfoButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeGameInfoButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeGameInfoButton.Location = new System.Drawing.Point(6, 70);
            this.customizeGameInfoButton.Name = "customizeGameInfoButton";
            this.customizeGameInfoButton.Size = new System.Drawing.Size(61, 28);
            this.customizeGameInfoButton.TabIndex = 10024;
            this.customizeGameInfoButton.Text = "Custom";
            this.customizeGameInfoButton.UseVisualStyleBackColor = true;
            // 
            // autoLaunchGameInfoWindowCheckbox
            // 
            this.autoLaunchGameInfoWindowCheckbox.AutoSize = true;
            this.autoLaunchGameInfoWindowCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLaunchGameInfoWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchGameInfoWindowCheckbox.Location = new System.Drawing.Point(7, 18);
            this.autoLaunchGameInfoWindowCheckbox.Name = "autoLaunchGameInfoWindowCheckbox";
            this.autoLaunchGameInfoWindowCheckbox.Size = new System.Drawing.Size(54, 18);
            this.autoLaunchGameInfoWindowCheckbox.TabIndex = 10022;
            this.autoLaunchGameInfoWindowCheckbox.Text = "Auto";
            this.autoLaunchGameInfoWindowCheckbox.UseVisualStyleBackColor = true;
            // 
            // openGameInfoWindowButton
            // 
            this.openGameInfoWindowButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openGameInfoWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openGameInfoWindowButton.Location = new System.Drawing.Point(6, 37);
            this.openGameInfoWindowButton.Name = "openGameInfoWindowButton";
            this.openGameInfoWindowButton.Size = new System.Drawing.Size(60, 28);
            this.openGameInfoWindowButton.TabIndex = 10021;
            this.openGameInfoWindowButton.Text = "Open";
            this.openGameInfoWindowButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.RoyalBlue;
            this.groupBox3.Controls.Add(this.customizeLastFiveButton);
            this.groupBox3.Controls.Add(this.autoLaunchLastFiveWindowCheckbox);
            this.groupBox3.Controls.Add(this.openLastFiveWindowButton);
            this.groupBox3.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(86, 251);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(72, 105);
            this.groupBox3.TabIndex = 10026;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Last 5";
            // 
            // customizeLastFiveButton
            // 
            this.customizeLastFiveButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeLastFiveButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeLastFiveButton.Location = new System.Drawing.Point(5, 70);
            this.customizeLastFiveButton.Name = "customizeLastFiveButton";
            this.customizeLastFiveButton.Size = new System.Drawing.Size(61, 29);
            this.customizeLastFiveButton.TabIndex = 10024;
            this.customizeLastFiveButton.Text = "Custom";
            this.customizeLastFiveButton.UseVisualStyleBackColor = true;
            // 
            // autoLaunchLastFiveWindowCheckbox
            // 
            this.autoLaunchLastFiveWindowCheckbox.AutoSize = true;
            this.autoLaunchLastFiveWindowCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLaunchLastFiveWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchLastFiveWindowCheckbox.Location = new System.Drawing.Point(7, 18);
            this.autoLaunchLastFiveWindowCheckbox.Name = "autoLaunchLastFiveWindowCheckbox";
            this.autoLaunchLastFiveWindowCheckbox.Size = new System.Drawing.Size(54, 18);
            this.autoLaunchLastFiveWindowCheckbox.TabIndex = 10022;
            this.autoLaunchLastFiveWindowCheckbox.Text = "Auto";
            this.autoLaunchLastFiveWindowCheckbox.UseVisualStyleBackColor = true;
            // 
            // openLastFiveWindowButton
            // 
            this.openLastFiveWindowButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openLastFiveWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openLastFiveWindowButton.Location = new System.Drawing.Point(5, 36);
            this.openLastFiveWindowButton.Name = "openLastFiveWindowButton";
            this.openLastFiveWindowButton.Size = new System.Drawing.Size(61, 28);
            this.openLastFiveWindowButton.TabIndex = 10021;
            this.openLastFiveWindowButton.Text = "Open";
            this.openLastFiveWindowButton.UseVisualStyleBackColor = true;
            // 
            // statsGameRatioOverrideTextBox
            // 
            this.statsGameRatioOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGameRatioOverrideTextBox.Location = new System.Drawing.Point(27, 122);
            this.statsGameRatioOverrideTextBox.Name = "statsGameRatioOverrideTextBox";
            this.statsGameRatioOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.statsGameRatioOverrideTextBox.TabIndex = 8;
            this.statsGameRatioOverrideTextBox.Text = "Ratio";
            // 
            // statsTruePointsOverrideTextBox
            // 
            this.statsTruePointsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsTruePointsOverrideTextBox.Location = new System.Drawing.Point(27, 122);
            this.statsTruePointsOverrideTextBox.Name = "statsTruePointsOverrideTextBox";
            this.statsTruePointsOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.statsTruePointsOverrideTextBox.TabIndex = 7;
            this.statsTruePointsOverrideTextBox.Text = "T. Points";
            // 
            // statsPointsOverrideTextBox
            // 
            this.statsPointsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsPointsOverrideTextBox.Location = new System.Drawing.Point(27, 70);
            this.statsPointsOverrideTextBox.Name = "statsPointsOverrideTextBox";
            this.statsPointsOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.statsPointsOverrideTextBox.TabIndex = 6;
            this.statsPointsOverrideTextBox.Text = "Points";
            // 
            // statsRatioOverrideTextBox
            // 
            this.statsRatioOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsRatioOverrideTextBox.Location = new System.Drawing.Point(27, 96);
            this.statsRatioOverrideTextBox.Name = "statsRatioOverrideTextBox";
            this.statsRatioOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.statsRatioOverrideTextBox.TabIndex = 5;
            this.statsRatioOverrideTextBox.Text = "Ratio";
            // 
            // statsAwardsOverrideTextBox
            // 
            this.statsAwardsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsAwardsOverrideTextBox.Location = new System.Drawing.Point(27, 44);
            this.statsAwardsOverrideTextBox.Name = "statsAwardsOverrideTextBox";
            this.statsAwardsOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.statsAwardsOverrideTextBox.TabIndex = 3;
            this.statsAwardsOverrideTextBox.Text = "Awards";
            // 
            // statsRankOverrideTextBox
            // 
            this.statsRankOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsRankOverrideTextBox.Location = new System.Drawing.Point(27, 18);
            this.statsRankOverrideTextBox.Name = "statsRankOverrideTextBox";
            this.statsRankOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.statsRankOverrideTextBox.TabIndex = 1;
            this.statsRankOverrideTextBox.Text = "Rank";
            // 
            // statsCustomizationsGroupBox
            // 
            this.statsCustomizationsGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.statsCustomizationsGroupBox.Controls.Add(this.groupBox17);
            this.statsCustomizationsGroupBox.Controls.Add(this.groupBox16);
            this.statsCustomizationsGroupBox.Controls.Add(this.groupBox15);
            this.statsCustomizationsGroupBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsCustomizationsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statsCustomizationsGroupBox.Location = new System.Drawing.Point(1073, 23);
            this.statsCustomizationsGroupBox.Name = "statsCustomizationsGroupBox";
            this.statsCustomizationsGroupBox.Size = new System.Drawing.Size(396, 246);
            this.statsCustomizationsGroupBox.TabIndex = 10007;
            this.statsCustomizationsGroupBox.TabStop = false;
            this.statsCustomizationsGroupBox.Text = "Stats Customization";
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox17.Controls.Add(this.statsRadioButtonBackslash);
            this.groupBox17.Controls.Add(this.statsRadioButtonSemicolon);
            this.groupBox17.Controls.Add(this.statsRadioButtonDot);
            this.groupBox17.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox17.Location = new System.Drawing.Point(3, 202);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(389, 41);
            this.groupBox17.TabIndex = 57;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Special Characters";
            // 
            // statsRadioButtonBackslash
            // 
            this.statsRadioButtonBackslash.AutoSize = true;
            this.statsRadioButtonBackslash.Location = new System.Drawing.Point(6, 19);
            this.statsRadioButtonBackslash.Name = "statsRadioButtonBackslash";
            this.statsRadioButtonBackslash.Size = new System.Drawing.Size(106, 17);
            this.statsRadioButtonBackslash.TabIndex = 50;
            this.statsRadioButtonBackslash.TabStop = true;
            this.statsRadioButtonBackslash.Text = "Backslash";
            this.statsRadioButtonBackslash.UseVisualStyleBackColor = true;
            // 
            // statsRadioButtonSemicolon
            // 
            this.statsRadioButtonSemicolon.AutoSize = true;
            this.statsRadioButtonSemicolon.Location = new System.Drawing.Point(141, 18);
            this.statsRadioButtonSemicolon.Name = "statsRadioButtonSemicolon";
            this.statsRadioButtonSemicolon.Size = new System.Drawing.Size(106, 17);
            this.statsRadioButtonSemicolon.TabIndex = 53;
            this.statsRadioButtonSemicolon.TabStop = true;
            this.statsRadioButtonSemicolon.Text = "Semicolon";
            this.statsRadioButtonSemicolon.UseVisualStyleBackColor = true;
            // 
            // statsRadioButtonDot
            // 
            this.statsRadioButtonDot.AutoSize = true;
            this.statsRadioButtonDot.Location = new System.Drawing.Point(266, 18);
            this.statsRadioButtonDot.Name = "statsRadioButtonDot";
            this.statsRadioButtonDot.Size = new System.Drawing.Size(115, 17);
            this.statsRadioButtonDot.TabIndex = 52;
            this.statsRadioButtonDot.TabStop = true;
            this.statsRadioButtonDot.Text = "Period/Dot";
            this.statsRadioButtonDot.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox16.Controls.Add(this.gameRatioEnableCheckBox);
            this.groupBox16.Controls.Add(this.gameTruePointsEnableCheckBox);
            this.groupBox16.Controls.Add(this.gamePointsEnableCheckBox);
            this.groupBox16.Controls.Add(this.completedEnableCheckBox);
            this.groupBox16.Controls.Add(this.gameAchievementsEnableCheckBox);
            this.groupBox16.Controls.Add(this.button11);
            this.groupBox16.Controls.Add(this.statsGameRatioOverrideTextBox);
            this.groupBox16.Controls.Add(this.statsGameAchievementsOverrideTextBox);
            this.groupBox16.Controls.Add(this.statsGamePointsOverrideTextBox);
            this.groupBox16.Controls.Add(this.statsGameTruePointsOverrideTextBox);
            this.groupBox16.Controls.Add(this.statsCompletedOverrideTextBox);
            this.groupBox16.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox16.Location = new System.Drawing.Point(201, 19);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(191, 177);
            this.groupBox16.TabIndex = 56;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Game";
            // 
            // gameRatioEnableCheckBox
            // 
            this.gameRatioEnableCheckBox.AutoSize = true;
            this.gameRatioEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameRatioEnableCheckBox.Location = new System.Drawing.Point(6, 127);
            this.gameRatioEnableCheckBox.Name = "gameRatioEnableCheckBox";
            this.gameRatioEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameRatioEnableCheckBox.TabIndex = 61;
            this.gameRatioEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameTruePointsEnableCheckBox
            // 
            this.gameTruePointsEnableCheckBox.AutoSize = true;
            this.gameTruePointsEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameTruePointsEnableCheckBox.Location = new System.Drawing.Point(6, 76);
            this.gameTruePointsEnableCheckBox.Name = "gameTruePointsEnableCheckBox";
            this.gameTruePointsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameTruePointsEnableCheckBox.TabIndex = 60;
            this.gameTruePointsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // gamePointsEnableCheckBox
            // 
            this.gamePointsEnableCheckBox.AutoSize = true;
            this.gamePointsEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamePointsEnableCheckBox.Location = new System.Drawing.Point(6, 50);
            this.gamePointsEnableCheckBox.Name = "gamePointsEnableCheckBox";
            this.gamePointsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gamePointsEnableCheckBox.TabIndex = 59;
            this.gamePointsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // completedEnableCheckBox
            // 
            this.completedEnableCheckBox.AutoSize = true;
            this.completedEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completedEnableCheckBox.Location = new System.Drawing.Point(6, 102);
            this.completedEnableCheckBox.Name = "completedEnableCheckBox";
            this.completedEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.completedEnableCheckBox.TabIndex = 58;
            this.completedEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameAchievementsEnableCheckBox
            // 
            this.gameAchievementsEnableCheckBox.AutoSize = true;
            this.gameAchievementsEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameAchievementsEnableCheckBox.Location = new System.Drawing.Point(6, 22);
            this.gameAchievementsEnableCheckBox.Name = "gameAchievementsEnableCheckBox";
            this.gameAchievementsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameAchievementsEnableCheckBox.TabIndex = 57;
            this.gameAchievementsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button11.Location = new System.Drawing.Point(113, 148);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(72, 23);
            this.button11.TabIndex = 44;
            this.button11.Text = "Default";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // statsGameAchievementsOverrideTextBox
            // 
            this.statsGameAchievementsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGameAchievementsOverrideTextBox.Location = new System.Drawing.Point(27, 19);
            this.statsGameAchievementsOverrideTextBox.Name = "statsGameAchievementsOverrideTextBox";
            this.statsGameAchievementsOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.statsGameAchievementsOverrideTextBox.TabIndex = 13;
            this.statsGameAchievementsOverrideTextBox.Text = "Cheevos";
            // 
            // statsGamePointsOverrideTextBox
            // 
            this.statsGamePointsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGamePointsOverrideTextBox.Location = new System.Drawing.Point(27, 45);
            this.statsGamePointsOverrideTextBox.Name = "statsGamePointsOverrideTextBox";
            this.statsGamePointsOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.statsGamePointsOverrideTextBox.TabIndex = 15;
            this.statsGamePointsOverrideTextBox.Text = "Points";
            // 
            // statsGameTruePointsOverrideTextBox
            // 
            this.statsGameTruePointsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGameTruePointsOverrideTextBox.Location = new System.Drawing.Point(27, 71);
            this.statsGameTruePointsOverrideTextBox.Name = "statsGameTruePointsOverrideTextBox";
            this.statsGameTruePointsOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.statsGameTruePointsOverrideTextBox.TabIndex = 16;
            this.statsGameTruePointsOverrideTextBox.Text = "T. Points";
            // 
            // statsCompletedOverrideTextBox
            // 
            this.statsCompletedOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsCompletedOverrideTextBox.Location = new System.Drawing.Point(27, 96);
            this.statsCompletedOverrideTextBox.Name = "statsCompletedOverrideTextBox";
            this.statsCompletedOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.statsCompletedOverrideTextBox.TabIndex = 48;
            this.statsCompletedOverrideTextBox.Text = "Completed";
            // 
            // groupBox15
            // 
            this.groupBox15.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox15.Controls.Add(this.truePointsEnableCheckBox);
            this.groupBox15.Controls.Add(this.ratioEnableCheckBox);
            this.groupBox15.Controls.Add(this.pointsEnableCheckBox);
            this.groupBox15.Controls.Add(this.awardsEnableCheckBox);
            this.groupBox15.Controls.Add(this.rankEnableCheckBox);
            this.groupBox15.Controls.Add(this.statsRankOverrideTextBox);
            this.groupBox15.Controls.Add(this.statsAwardsOverrideTextBox);
            this.groupBox15.Controls.Add(this.statsDefaultButton);
            this.groupBox15.Controls.Add(this.statsRatioOverrideTextBox);
            this.groupBox15.Controls.Add(this.statsPointsOverrideTextBox);
            this.groupBox15.Controls.Add(this.statsTruePointsOverrideTextBox);
            this.groupBox15.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox15.Location = new System.Drawing.Point(3, 19);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(192, 177);
            this.groupBox15.TabIndex = 55;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "User";
            // 
            // truePointsEnableCheckBox
            // 
            this.truePointsEnableCheckBox.AutoSize = true;
            this.truePointsEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truePointsEnableCheckBox.Location = new System.Drawing.Point(8, 125);
            this.truePointsEnableCheckBox.Name = "truePointsEnableCheckBox";
            this.truePointsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.truePointsEnableCheckBox.TabIndex = 56;
            this.truePointsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // ratioEnableCheckBox
            // 
            this.ratioEnableCheckBox.AutoSize = true;
            this.ratioEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ratioEnableCheckBox.Location = new System.Drawing.Point(8, 102);
            this.ratioEnableCheckBox.Name = "ratioEnableCheckBox";
            this.ratioEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ratioEnableCheckBox.TabIndex = 55;
            this.ratioEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // pointsEnableCheckBox
            // 
            this.pointsEnableCheckBox.AutoSize = true;
            this.pointsEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsEnableCheckBox.Location = new System.Drawing.Point(8, 76);
            this.pointsEnableCheckBox.Name = "pointsEnableCheckBox";
            this.pointsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.pointsEnableCheckBox.TabIndex = 54;
            this.pointsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // awardsEnableCheckBox
            // 
            this.awardsEnableCheckBox.AutoSize = true;
            this.awardsEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.awardsEnableCheckBox.Location = new System.Drawing.Point(8, 50);
            this.awardsEnableCheckBox.Name = "awardsEnableCheckBox";
            this.awardsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.awardsEnableCheckBox.TabIndex = 53;
            this.awardsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // rankEnableCheckBox
            // 
            this.rankEnableCheckBox.AutoSize = true;
            this.rankEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rankEnableCheckBox.Location = new System.Drawing.Point(8, 24);
            this.rankEnableCheckBox.Name = "rankEnableCheckBox";
            this.rankEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.rankEnableCheckBox.TabIndex = 52;
            this.rankEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // statsDefaultButton
            // 
            this.statsDefaultButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsDefaultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statsDefaultButton.Location = new System.Drawing.Point(112, 148);
            this.statsDefaultButton.Name = "statsDefaultButton";
            this.statsDefaultButton.Size = new System.Drawing.Size(72, 23);
            this.statsDefaultButton.TabIndex = 39;
            this.statsDefaultButton.Text = "Default";
            this.statsDefaultButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoOverrideSettingsGroupBox
            // 
            this.gameInfoOverrideSettingsGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.releasedDateEnableCheckBox);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.consoleEnableCheckBox);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.publisherEnableCheckBox);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.genreEnableCheckBox);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.developerEnableCheckBox);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.titleEnableCheckBox);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.gameInfoTitleOverrideTextBox);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.gameInfoDefaultButton);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.gameInfoGenreOverrideTextBox);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.gameInfoConsoleOverrideTextBox);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.gameInfoPublisherOverrideTextBox);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.gameInfoReleaseDateOverrideTextBox);
            this.gameInfoOverrideSettingsGroupBox.Controls.Add(this.gameInfoDeveloperOverrideTextBox);
            this.gameInfoOverrideSettingsGroupBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoOverrideSettingsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameInfoOverrideSettingsGroupBox.Location = new System.Drawing.Point(641, 334);
            this.gameInfoOverrideSettingsGroupBox.Name = "gameInfoOverrideSettingsGroupBox";
            this.gameInfoOverrideSettingsGroupBox.Size = new System.Drawing.Size(396, 126);
            this.gameInfoOverrideSettingsGroupBox.TabIndex = 10008;
            this.gameInfoOverrideSettingsGroupBox.TabStop = false;
            this.gameInfoOverrideSettingsGroupBox.Text = "Game Info Customization";
            // 
            // releasedDateEnableCheckBox
            // 
            this.releasedDateEnableCheckBox.AutoSize = true;
            this.releasedDateEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releasedDateEnableCheckBox.Location = new System.Drawing.Point(207, 77);
            this.releasedDateEnableCheckBox.Name = "releasedDateEnableCheckBox";
            this.releasedDateEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.releasedDateEnableCheckBox.TabIndex = 62;
            this.releasedDateEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // consoleEnableCheckBox
            // 
            this.consoleEnableCheckBox.AutoSize = true;
            this.consoleEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleEnableCheckBox.Location = new System.Drawing.Point(207, 51);
            this.consoleEnableCheckBox.Name = "consoleEnableCheckBox";
            this.consoleEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.consoleEnableCheckBox.TabIndex = 61;
            this.consoleEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // publisherEnableCheckBox
            // 
            this.publisherEnableCheckBox.AutoSize = true;
            this.publisherEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.publisherEnableCheckBox.Location = new System.Drawing.Point(11, 77);
            this.publisherEnableCheckBox.Name = "publisherEnableCheckBox";
            this.publisherEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.publisherEnableCheckBox.TabIndex = 60;
            this.publisherEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // genreEnableCheckBox
            // 
            this.genreEnableCheckBox.AutoSize = true;
            this.genreEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genreEnableCheckBox.Location = new System.Drawing.Point(207, 25);
            this.genreEnableCheckBox.Name = "genreEnableCheckBox";
            this.genreEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.genreEnableCheckBox.TabIndex = 59;
            this.genreEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // developerEnableCheckBox
            // 
            this.developerEnableCheckBox.AutoSize = true;
            this.developerEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developerEnableCheckBox.Location = new System.Drawing.Point(11, 51);
            this.developerEnableCheckBox.Name = "developerEnableCheckBox";
            this.developerEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.developerEnableCheckBox.TabIndex = 58;
            this.developerEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // titleEnableCheckBox
            // 
            this.titleEnableCheckBox.AutoSize = true;
            this.titleEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleEnableCheckBox.Location = new System.Drawing.Point(11, 25);
            this.titleEnableCheckBox.Name = "titleEnableCheckBox";
            this.titleEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.titleEnableCheckBox.TabIndex = 57;
            this.titleEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameInfoTitleOverrideTextBox
            // 
            this.gameInfoTitleOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoTitleOverrideTextBox.Location = new System.Drawing.Point(30, 19);
            this.gameInfoTitleOverrideTextBox.Name = "gameInfoTitleOverrideTextBox";
            this.gameInfoTitleOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.gameInfoTitleOverrideTextBox.TabIndex = 53;
            this.gameInfoTitleOverrideTextBox.Text = "Title";
            // 
            // gameInfoDefaultButton
            // 
            this.gameInfoDefaultButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDefaultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameInfoDefaultButton.Location = new System.Drawing.Point(314, 97);
            this.gameInfoDefaultButton.Name = "gameInfoDefaultButton";
            this.gameInfoDefaultButton.Size = new System.Drawing.Size(72, 23);
            this.gameInfoDefaultButton.TabIndex = 40;
            this.gameInfoDefaultButton.Text = "Default";
            this.gameInfoDefaultButton.UseVisualStyleBackColor = true;
            this.gameInfoDefaultButton.Click += new System.EventHandler(this.GameInfoDefaultButton_Click);
            // 
            // gameInfoGenreOverrideTextBox
            // 
            this.gameInfoGenreOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoGenreOverrideTextBox.Location = new System.Drawing.Point(228, 19);
            this.gameInfoGenreOverrideTextBox.Name = "gameInfoGenreOverrideTextBox";
            this.gameInfoGenreOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.gameInfoGenreOverrideTextBox.TabIndex = 25;
            this.gameInfoGenreOverrideTextBox.Text = "Genre";
            // 
            // gameInfoConsoleOverrideTextBox
            // 
            this.gameInfoConsoleOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoConsoleOverrideTextBox.Location = new System.Drawing.Point(228, 45);
            this.gameInfoConsoleOverrideTextBox.Name = "gameInfoConsoleOverrideTextBox";
            this.gameInfoConsoleOverrideTextBox.Size = new System.Drawing.Size(158, 20);
            this.gameInfoConsoleOverrideTextBox.TabIndex = 19;
            this.gameInfoConsoleOverrideTextBox.Text = "Console";
            // 
            // gameInfoPublisherOverrideTextBox
            // 
            this.gameInfoPublisherOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoPublisherOverrideTextBox.Location = new System.Drawing.Point(31, 74);
            this.gameInfoPublisherOverrideTextBox.Name = "gameInfoPublisherOverrideTextBox";
            this.gameInfoPublisherOverrideTextBox.Size = new System.Drawing.Size(158, 20);
            this.gameInfoPublisherOverrideTextBox.TabIndex = 24;
            this.gameInfoPublisherOverrideTextBox.Text = "Publisher";
            // 
            // gameInfoReleaseDateOverrideTextBox
            // 
            this.gameInfoReleaseDateOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoReleaseDateOverrideTextBox.Location = new System.Drawing.Point(228, 71);
            this.gameInfoReleaseDateOverrideTextBox.Name = "gameInfoReleaseDateOverrideTextBox";
            this.gameInfoReleaseDateOverrideTextBox.Size = new System.Drawing.Size(160, 20);
            this.gameInfoReleaseDateOverrideTextBox.TabIndex = 23;
            this.gameInfoReleaseDateOverrideTextBox.Text = "Released";
            // 
            // gameInfoDeveloperOverrideTextBox
            // 
            this.gameInfoDeveloperOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDeveloperOverrideTextBox.Location = new System.Drawing.Point(30, 45);
            this.gameInfoDeveloperOverrideTextBox.Name = "gameInfoDeveloperOverrideTextBox";
            this.gameInfoDeveloperOverrideTextBox.Size = new System.Drawing.Size(157, 20);
            this.gameInfoDeveloperOverrideTextBox.TabIndex = 21;
            this.gameInfoDeveloperOverrideTextBox.Text = "Developer";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fontBorderEnableCheckBox
            // 
            this.fontBorderEnableCheckBox.AutoSize = true;
            this.fontBorderEnableCheckBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontBorderEnableCheckBox.Location = new System.Drawing.Point(12, 42);
            this.fontBorderEnableCheckBox.Name = "fontBorderEnableCheckBox";
            this.fontBorderEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.fontBorderEnableCheckBox.TabIndex = 41;
            this.fontBorderEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // fontSettingsGroupBox
            // 
            this.fontSettingsGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.fontSettingsGroupBox.Controls.Add(this.windowBackgroundGroupBox);
            this.fontSettingsGroupBox.Controls.Add(this.label9);
            this.fontSettingsGroupBox.Controls.Add(this.borderBackgroundGroupBox);
            this.fontSettingsGroupBox.Controls.Add(this.fontBorderEnableCheckBox);
            this.fontSettingsGroupBox.Controls.Add(this.pointsFontGroupBox);
            this.fontSettingsGroupBox.Controls.Add(this.descriptionFontGroupBox);
            this.fontSettingsGroupBox.Controls.Add(this.lineFontGroupBox);
            this.fontSettingsGroupBox.Controls.Add(this.label2);
            this.fontSettingsGroupBox.Controls.Add(this.fontSimpleCheckbox);
            this.fontSettingsGroupBox.Controls.Add(this.titleFontGroupBox);
            this.fontSettingsGroupBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontSettingsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fontSettingsGroupBox.Location = new System.Drawing.Point(385, 12);
            this.fontSettingsGroupBox.Name = "fontSettingsGroupBox";
            this.fontSettingsGroupBox.Size = new System.Drawing.Size(250, 448);
            this.fontSettingsGroupBox.TabIndex = 10007;
            this.fontSettingsGroupBox.TabStop = false;
            this.fontSettingsGroupBox.Text = "Font";
            // 
            // windowBackgroundGroupBox
            // 
            this.windowBackgroundGroupBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.windowBackgroundGroupBox.Controls.Add(this.windowBackgroundColorButton);
            this.windowBackgroundGroupBox.Controls.Add(this.windowBackgroundColorPictureBox);
            this.windowBackgroundGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.windowBackgroundGroupBox.Location = new System.Drawing.Point(119, 11);
            this.windowBackgroundGroupBox.Name = "windowBackgroundGroupBox";
            this.windowBackgroundGroupBox.Size = new System.Drawing.Size(125, 50);
            this.windowBackgroundGroupBox.TabIndex = 51;
            this.windowBackgroundGroupBox.TabStop = false;
            this.windowBackgroundGroupBox.Text = "Background";
            // 
            // windowBackgroundColorButton
            // 
            this.windowBackgroundColorButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowBackgroundColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.windowBackgroundColorButton.Location = new System.Drawing.Point(6, 19);
            this.windowBackgroundColorButton.Name = "windowBackgroundColorButton";
            this.windowBackgroundColorButton.Size = new System.Drawing.Size(49, 23);
            this.windowBackgroundColorButton.TabIndex = 43;
            this.windowBackgroundColorButton.Text = "Set";
            this.windowBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // windowBackgroundColorPictureBox
            // 
            this.windowBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.windowBackgroundColorPictureBox.Location = new System.Drawing.Point(61, 19);
            this.windowBackgroundColorPictureBox.Name = "windowBackgroundColorPictureBox";
            this.windowBackgroundColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.windowBackgroundColorPictureBox.TabIndex = 42;
            this.windowBackgroundColorPictureBox.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "Border";
            // 
            // borderBackgroundGroupBox
            // 
            this.borderBackgroundGroupBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.borderBackgroundGroupBox.Controls.Add(this.borderBackgroundColorButton);
            this.borderBackgroundGroupBox.Controls.Add(this.borderBackgroudColorPictureBox);
            this.borderBackgroundGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.borderBackgroundGroupBox.Location = new System.Drawing.Point(119, 67);
            this.borderBackgroundGroupBox.Name = "borderBackgroundGroupBox";
            this.borderBackgroundGroupBox.Size = new System.Drawing.Size(125, 50);
            this.borderBackgroundGroupBox.TabIndex = 50;
            this.borderBackgroundGroupBox.TabStop = false;
            this.borderBackgroundGroupBox.Text = "Border";
            // 
            // borderBackgroundColorButton
            // 
            this.borderBackgroundColorButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderBackgroundColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.borderBackgroundColorButton.Location = new System.Drawing.Point(6, 19);
            this.borderBackgroundColorButton.Name = "borderBackgroundColorButton";
            this.borderBackgroundColorButton.Size = new System.Drawing.Size(49, 23);
            this.borderBackgroundColorButton.TabIndex = 43;
            this.borderBackgroundColorButton.Text = "Set";
            this.borderBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // borderBackgroudColorPictureBox
            // 
            this.borderBackgroudColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.borderBackgroudColorPictureBox.Location = new System.Drawing.Point(61, 19);
            this.borderBackgroudColorPictureBox.Name = "borderBackgroudColorPictureBox";
            this.borderBackgroudColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.borderBackgroudColorPictureBox.TabIndex = 42;
            this.borderBackgroudColorPictureBox.TabStop = false;
            // 
            // pointsFontGroupBox
            // 
            this.pointsFontGroupBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pointsFontGroupBox.Controls.Add(this.label4);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontOutlineColorButton);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontOutlineColorPictureBox);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontColorButton);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontOutlineCheckbox);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontOutlineNumericUpDown);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontColorPictureBox);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontFamilyComboBox);
            this.pointsFontGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.pointsFontGroupBox.Location = new System.Drawing.Point(6, 282);
            this.pointsFontGroupBox.Name = "pointsFontGroupBox";
            this.pointsFontGroupBox.Size = new System.Drawing.Size(236, 76);
            this.pointsFontGroupBox.TabIndex = 48;
            this.pointsFontGroupBox.TabStop = false;
            this.pointsFontGroupBox.Text = "Points";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Outline";
            // 
            // pointsFontOutlineColorButton
            // 
            this.pointsFontOutlineColorButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsFontOutlineColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pointsFontOutlineColorButton.Location = new System.Drawing.Point(6, 47);
            this.pointsFontOutlineColorButton.Name = "pointsFontOutlineColorButton";
            this.pointsFontOutlineColorButton.Size = new System.Drawing.Size(49, 23);
            this.pointsFontOutlineColorButton.TabIndex = 45;
            this.pointsFontOutlineColorButton.Text = "Set";
            this.pointsFontOutlineColorButton.UseVisualStyleBackColor = true;
            // 
            // pointsFontOutlineColorPictureBox
            // 
            this.pointsFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pointsFontOutlineColorPictureBox.Location = new System.Drawing.Point(61, 46);
            this.pointsFontOutlineColorPictureBox.Name = "pointsFontOutlineColorPictureBox";
            this.pointsFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.pointsFontOutlineColorPictureBox.TabIndex = 45;
            this.pointsFontOutlineColorPictureBox.TabStop = false;
            // 
            // pointsFontColorButton
            // 
            this.pointsFontColorButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsFontColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pointsFontColorButton.Location = new System.Drawing.Point(6, 17);
            this.pointsFontColorButton.Name = "pointsFontColorButton";
            this.pointsFontColorButton.Size = new System.Drawing.Size(49, 23);
            this.pointsFontColorButton.TabIndex = 45;
            this.pointsFontColorButton.Text = "Set";
            this.pointsFontColorButton.UseVisualStyleBackColor = true;
            // 
            // pointsFontOutlineCheckbox
            // 
            this.pointsFontOutlineCheckbox.AutoSize = true;
            this.pointsFontOutlineCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsFontOutlineCheckbox.Location = new System.Drawing.Point(139, 52);
            this.pointsFontOutlineCheckbox.Name = "pointsFontOutlineCheckbox";
            this.pointsFontOutlineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.pointsFontOutlineCheckbox.TabIndex = 45;
            this.pointsFontOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // pointsFontOutlineNumericUpDown
            // 
            this.pointsFontOutlineNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 46);
            this.pointsFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pointsFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pointsFontOutlineNumericUpDown.Name = "pointsFontOutlineNumericUpDown";
            this.pointsFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 22);
            this.pointsFontOutlineNumericUpDown.TabIndex = 45;
            this.pointsFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pointsFontColorPictureBox
            // 
            this.pointsFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pointsFontColorPictureBox.Location = new System.Drawing.Point(61, 17);
            this.pointsFontColorPictureBox.Name = "pointsFontColorPictureBox";
            this.pointsFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.pointsFontColorPictureBox.TabIndex = 45;
            this.pointsFontColorPictureBox.TabStop = false;
            // 
            // pointsFontFamilyComboBox
            // 
            this.pointsFontFamilyComboBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsFontFamilyComboBox.FormattingEnabled = true;
            this.pointsFontFamilyComboBox.Location = new System.Drawing.Point(89, 16);
            this.pointsFontFamilyComboBox.Name = "pointsFontFamilyComboBox";
            this.pointsFontFamilyComboBox.Size = new System.Drawing.Size(140, 23);
            this.pointsFontFamilyComboBox.TabIndex = 45;
            // 
            // descriptionFontGroupBox
            // 
            this.descriptionFontGroupBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.descriptionFontGroupBox.Controls.Add(this.label3);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontOutlineColorButton);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontOutlineColorPictureBox);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontColorButton);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontOutlineCheckbox);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontOutlineNumericUpDown);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontColorPictureBox);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontFamilyComboBox);
            this.descriptionFontGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.descriptionFontGroupBox.Location = new System.Drawing.Point(6, 202);
            this.descriptionFontGroupBox.Name = "descriptionFontGroupBox";
            this.descriptionFontGroupBox.Size = new System.Drawing.Size(236, 76);
            this.descriptionFontGroupBox.TabIndex = 47;
            this.descriptionFontGroupBox.TabStop = false;
            this.descriptionFontGroupBox.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Outline";
            // 
            // descriptionFontOutlineColorButton
            // 
            this.descriptionFontOutlineColorButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionFontOutlineColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.descriptionFontOutlineColorButton.Location = new System.Drawing.Point(6, 47);
            this.descriptionFontOutlineColorButton.Name = "descriptionFontOutlineColorButton";
            this.descriptionFontOutlineColorButton.Size = new System.Drawing.Size(49, 23);
            this.descriptionFontOutlineColorButton.TabIndex = 45;
            this.descriptionFontOutlineColorButton.Text = "Set";
            this.descriptionFontOutlineColorButton.UseVisualStyleBackColor = true;
            // 
            // descriptionFontOutlineColorPictureBox
            // 
            this.descriptionFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.descriptionFontOutlineColorPictureBox.Location = new System.Drawing.Point(61, 46);
            this.descriptionFontOutlineColorPictureBox.Name = "descriptionFontOutlineColorPictureBox";
            this.descriptionFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.descriptionFontOutlineColorPictureBox.TabIndex = 45;
            this.descriptionFontOutlineColorPictureBox.TabStop = false;
            // 
            // descriptionFontColorButton
            // 
            this.descriptionFontColorButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionFontColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.descriptionFontColorButton.Location = new System.Drawing.Point(6, 17);
            this.descriptionFontColorButton.Name = "descriptionFontColorButton";
            this.descriptionFontColorButton.Size = new System.Drawing.Size(49, 23);
            this.descriptionFontColorButton.TabIndex = 45;
            this.descriptionFontColorButton.Text = "Set";
            this.descriptionFontColorButton.UseVisualStyleBackColor = true;
            // 
            // descriptionFontOutlineCheckbox
            // 
            this.descriptionFontOutlineCheckbox.AutoSize = true;
            this.descriptionFontOutlineCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionFontOutlineCheckbox.Location = new System.Drawing.Point(138, 51);
            this.descriptionFontOutlineCheckbox.Name = "descriptionFontOutlineCheckbox";
            this.descriptionFontOutlineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.descriptionFontOutlineCheckbox.TabIndex = 45;
            this.descriptionFontOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // descriptionFontOutlineNumericUpDown
            // 
            this.descriptionFontOutlineNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 46);
            this.descriptionFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.descriptionFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.descriptionFontOutlineNumericUpDown.Name = "descriptionFontOutlineNumericUpDown";
            this.descriptionFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 22);
            this.descriptionFontOutlineNumericUpDown.TabIndex = 45;
            this.descriptionFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // descriptionFontColorPictureBox
            // 
            this.descriptionFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.descriptionFontColorPictureBox.Location = new System.Drawing.Point(61, 17);
            this.descriptionFontColorPictureBox.Name = "descriptionFontColorPictureBox";
            this.descriptionFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.descriptionFontColorPictureBox.TabIndex = 45;
            this.descriptionFontColorPictureBox.TabStop = false;
            // 
            // descriptionFontFamilyComboBox
            // 
            this.descriptionFontFamilyComboBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionFontFamilyComboBox.FormattingEnabled = true;
            this.descriptionFontFamilyComboBox.Location = new System.Drawing.Point(89, 16);
            this.descriptionFontFamilyComboBox.Name = "descriptionFontFamilyComboBox";
            this.descriptionFontFamilyComboBox.Size = new System.Drawing.Size(140, 23);
            this.descriptionFontFamilyComboBox.TabIndex = 45;
            // 
            // lineFontGroupBox
            // 
            this.lineFontGroupBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lineFontGroupBox.Controls.Add(this.label5);
            this.lineFontGroupBox.Controls.Add(this.lineOutlineColorButton);
            this.lineFontGroupBox.Controls.Add(this.lineOutlineColorPictureBox);
            this.lineFontGroupBox.Controls.Add(this.lineColorButton);
            this.lineFontGroupBox.Controls.Add(this.lineOutlineCheckbox);
            this.lineFontGroupBox.Controls.Add(this.lineOutlineNumericUpDown);
            this.lineFontGroupBox.Controls.Add(this.lineColorPictureBox);
            this.lineFontGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lineFontGroupBox.Location = new System.Drawing.Point(6, 364);
            this.lineFontGroupBox.Name = "lineFontGroupBox";
            this.lineFontGroupBox.Size = new System.Drawing.Size(236, 76);
            this.lineFontGroupBox.TabIndex = 49;
            this.lineFontGroupBox.TabStop = false;
            this.lineFontGroupBox.Text = "Line";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Outline";
            // 
            // lineOutlineColorButton
            // 
            this.lineOutlineColorButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineOutlineColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lineOutlineColorButton.Location = new System.Drawing.Point(6, 47);
            this.lineOutlineColorButton.Name = "lineOutlineColorButton";
            this.lineOutlineColorButton.Size = new System.Drawing.Size(49, 23);
            this.lineOutlineColorButton.TabIndex = 45;
            this.lineOutlineColorButton.Text = "Set";
            this.lineOutlineColorButton.UseVisualStyleBackColor = true;
            // 
            // lineOutlineColorPictureBox
            // 
            this.lineOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineOutlineColorPictureBox.Location = new System.Drawing.Point(61, 46);
            this.lineOutlineColorPictureBox.Name = "lineOutlineColorPictureBox";
            this.lineOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.lineOutlineColorPictureBox.TabIndex = 45;
            this.lineOutlineColorPictureBox.TabStop = false;
            // 
            // lineColorButton
            // 
            this.lineColorButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lineColorButton.Location = new System.Drawing.Point(6, 17);
            this.lineColorButton.Name = "lineColorButton";
            this.lineColorButton.Size = new System.Drawing.Size(49, 23);
            this.lineColorButton.TabIndex = 45;
            this.lineColorButton.Text = "Set";
            this.lineColorButton.UseVisualStyleBackColor = true;
            // 
            // lineOutlineCheckbox
            // 
            this.lineOutlineCheckbox.AutoSize = true;
            this.lineOutlineCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineOutlineCheckbox.Location = new System.Drawing.Point(138, 52);
            this.lineOutlineCheckbox.Name = "lineOutlineCheckbox";
            this.lineOutlineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.lineOutlineCheckbox.TabIndex = 45;
            this.lineOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // lineOutlineNumericUpDown
            // 
            this.lineOutlineNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineOutlineNumericUpDown.Location = new System.Drawing.Point(89, 46);
            this.lineOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.lineOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineOutlineNumericUpDown.Name = "lineOutlineNumericUpDown";
            this.lineOutlineNumericUpDown.Size = new System.Drawing.Size(43, 22);
            this.lineOutlineNumericUpDown.TabIndex = 45;
            this.lineOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lineColorPictureBox
            // 
            this.lineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineColorPictureBox.Location = new System.Drawing.Point(61, 17);
            this.lineColorPictureBox.Name = "lineColorPictureBox";
            this.lineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.lineColorPictureBox.TabIndex = 45;
            this.lineColorPictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Simple";
            // 
            // fontSimpleCheckbox
            // 
            this.fontSimpleCheckbox.AutoSize = true;
            this.fontSimpleCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontSimpleCheckbox.Location = new System.Drawing.Point(12, 19);
            this.fontSimpleCheckbox.Name = "fontSimpleCheckbox";
            this.fontSimpleCheckbox.Size = new System.Drawing.Size(15, 14);
            this.fontSimpleCheckbox.TabIndex = 47;
            this.fontSimpleCheckbox.UseVisualStyleBackColor = true;
            // 
            // titleFontGroupBox
            // 
            this.titleFontGroupBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.titleFontGroupBox.Controls.Add(this.titleOutlineLabel);
            this.titleFontGroupBox.Controls.Add(this.titleFontOutlineColorButton);
            this.titleFontGroupBox.Controls.Add(this.titleFontOutlineColorPictureBox);
            this.titleFontGroupBox.Controls.Add(this.titleFontColorButton);
            this.titleFontGroupBox.Controls.Add(this.titleFontOutlineCheckbox);
            this.titleFontGroupBox.Controls.Add(this.titleFontOutlineNumericUpDown);
            this.titleFontGroupBox.Controls.Add(this.titleFontColorPictureBox);
            this.titleFontGroupBox.Controls.Add(this.titleFontFamilyComboBox);
            this.titleFontGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.titleFontGroupBox.Location = new System.Drawing.Point(6, 121);
            this.titleFontGroupBox.Name = "titleFontGroupBox";
            this.titleFontGroupBox.Size = new System.Drawing.Size(236, 76);
            this.titleFontGroupBox.TabIndex = 46;
            this.titleFontGroupBox.TabStop = false;
            this.titleFontGroupBox.Text = "Title";
            // 
            // titleOutlineLabel
            // 
            this.titleOutlineLabel.AutoSize = true;
            this.titleOutlineLabel.Location = new System.Drawing.Point(151, 52);
            this.titleOutlineLabel.Name = "titleOutlineLabel";
            this.titleOutlineLabel.Size = new System.Drawing.Size(70, 13);
            this.titleOutlineLabel.TabIndex = 46;
            this.titleOutlineLabel.Text = "Outline";
            // 
            // titleFontOutlineColorButton
            // 
            this.titleFontOutlineColorButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleFontOutlineColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.titleFontOutlineColorButton.Location = new System.Drawing.Point(6, 47);
            this.titleFontOutlineColorButton.Name = "titleFontOutlineColorButton";
            this.titleFontOutlineColorButton.Size = new System.Drawing.Size(49, 23);
            this.titleFontOutlineColorButton.TabIndex = 45;
            this.titleFontOutlineColorButton.Text = "Set";
            this.titleFontOutlineColorButton.UseVisualStyleBackColor = true;
            // 
            // titleFontOutlineColorPictureBox
            // 
            this.titleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.titleFontOutlineColorPictureBox.Location = new System.Drawing.Point(61, 46);
            this.titleFontOutlineColorPictureBox.Name = "titleFontOutlineColorPictureBox";
            this.titleFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.titleFontOutlineColorPictureBox.TabIndex = 45;
            this.titleFontOutlineColorPictureBox.TabStop = false;
            // 
            // titleFontColorButton
            // 
            this.titleFontColorButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleFontColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.titleFontColorButton.Location = new System.Drawing.Point(6, 17);
            this.titleFontColorButton.Name = "titleFontColorButton";
            this.titleFontColorButton.Size = new System.Drawing.Size(49, 23);
            this.titleFontColorButton.TabIndex = 45;
            this.titleFontColorButton.Text = "Set";
            this.titleFontColorButton.UseVisualStyleBackColor = true;
            // 
            // titleFontOutlineCheckbox
            // 
            this.titleFontOutlineCheckbox.AutoSize = true;
            this.titleFontOutlineCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleFontOutlineCheckbox.Location = new System.Drawing.Point(139, 51);
            this.titleFontOutlineCheckbox.Name = "titleFontOutlineCheckbox";
            this.titleFontOutlineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.titleFontOutlineCheckbox.TabIndex = 45;
            this.titleFontOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // titleFontOutlineNumericUpDown
            // 
            this.titleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 47);
            this.titleFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.titleFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.titleFontOutlineNumericUpDown.Name = "titleFontOutlineNumericUpDown";
            this.titleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 22);
            this.titleFontOutlineNumericUpDown.TabIndex = 45;
            this.titleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // titleFontColorPictureBox
            // 
            this.titleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.titleFontColorPictureBox.Location = new System.Drawing.Point(61, 17);
            this.titleFontColorPictureBox.Name = "titleFontColorPictureBox";
            this.titleFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.titleFontColorPictureBox.TabIndex = 45;
            this.titleFontColorPictureBox.TabStop = false;
            // 
            // titleFontFamilyComboBox
            // 
            this.titleFontFamilyComboBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleFontFamilyComboBox.FormattingEnabled = true;
            this.titleFontFamilyComboBox.Location = new System.Drawing.Point(89, 16);
            this.titleFontFamilyComboBox.Name = "titleFontFamilyComboBox";
            this.titleFontFamilyComboBox.Size = new System.Drawing.Size(140, 23);
            this.titleFontFamilyComboBox.TabIndex = 45;
            // 
            // playAchievementButton
            // 
            this.playAchievementButton.BackColor = System.Drawing.SystemColors.Control;
            this.playAchievementButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAchievementButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playAchievementButton.Location = new System.Drawing.Point(3, 17);
            this.playAchievementButton.Name = "playAchievementButton";
            this.playAchievementButton.Size = new System.Drawing.Size(55, 23);
            this.playAchievementButton.TabIndex = 2;
            this.playAchievementButton.Text = "Play";
            this.playAchievementButton.UseVisualStyleBackColor = false;
            // 
            // customAchievementEnableCheckbox
            // 
            this.customAchievementEnableCheckbox.AutoSize = true;
            this.customAchievementEnableCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementEnableCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.customAchievementEnableCheckbox.Location = new System.Drawing.Point(174, 0);
            this.customAchievementEnableCheckbox.Name = "customAchievementEnableCheckbox";
            this.customAchievementEnableCheckbox.Size = new System.Drawing.Size(15, 14);
            this.customAchievementEnableCheckbox.TabIndex = 13;
            this.customAchievementEnableCheckbox.UseVisualStyleBackColor = true;
            // 
            // selectCustomAchievementButton
            // 
            this.selectCustomAchievementButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomAchievementButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectCustomAchievementButton.Location = new System.Drawing.Point(3, 45);
            this.selectCustomAchievementButton.Name = "selectCustomAchievementButton";
            this.selectCustomAchievementButton.Size = new System.Drawing.Size(55, 23);
            this.selectCustomAchievementButton.TabIndex = 14;
            this.selectCustomAchievementButton.Text = "File";
            this.selectCustomAchievementButton.UseVisualStyleBackColor = true;
            // 
            // acheivementEditOutlineCheckbox
            // 
            this.acheivementEditOutlineCheckbox.AutoSize = true;
            this.acheivementEditOutlineCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acheivementEditOutlineCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.acheivementEditOutlineCheckbox.Location = new System.Drawing.Point(3, 78);
            this.acheivementEditOutlineCheckbox.Name = "acheivementEditOutlineCheckbox";
            this.acheivementEditOutlineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.acheivementEditOutlineCheckbox.TabIndex = 47;
            this.acheivementEditOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // achievementPositionGroupBox
            // 
            this.achievementPositionGroupBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.achievementPositionGroupBox.Controls.Add(this.label14);
            this.achievementPositionGroupBox.Controls.Add(this.scaleAchievementNumericUpDown);
            this.achievementPositionGroupBox.Controls.Add(this.xPositionLabel1);
            this.achievementPositionGroupBox.Controls.Add(this.yPositionLabel1);
            this.achievementPositionGroupBox.Controls.Add(this.customAchievementXNumericUpDown);
            this.achievementPositionGroupBox.Controls.Add(this.customAchievementYNumericUpDown);
            this.achievementPositionGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.achievementPositionGroupBox.Location = new System.Drawing.Point(68, 19);
            this.achievementPositionGroupBox.Name = "achievementPositionGroupBox";
            this.achievementPositionGroupBox.Size = new System.Drawing.Size(123, 95);
            this.achievementPositionGroupBox.TabIndex = 50;
            this.achievementPositionGroupBox.TabStop = false;
            this.achievementPositionGroupBox.Text = "Position";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label14.Location = new System.Drawing.Point(6, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 12);
            this.label14.TabIndex = 21;
            this.label14.Text = "Scale";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scaleAchievementNumericUpDown
            // 
            this.scaleAchievementNumericUpDown.DecimalPlaces = 2;
            this.scaleAchievementNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleAchievementNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.scaleAchievementNumericUpDown.Location = new System.Drawing.Point(57, 69);
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
            this.scaleAchievementNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.scaleAchievementNumericUpDown.TabIndex = 20;
            this.scaleAchievementNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // xPositionLabel1
            // 
            this.xPositionLabel1.AutoSize = true;
            this.xPositionLabel1.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPositionLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.xPositionLabel1.Location = new System.Drawing.Point(6, 24);
            this.xPositionLabel1.Name = "xPositionLabel1";
            this.xPositionLabel1.Size = new System.Drawing.Size(53, 12);
            this.xPositionLabel1.TabIndex = 18;
            this.xPositionLabel1.Text = "X (px)";
            // 
            // yPositionLabel1
            // 
            this.yPositionLabel1.AutoSize = true;
            this.yPositionLabel1.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yPositionLabel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.yPositionLabel1.Location = new System.Drawing.Point(6, 48);
            this.yPositionLabel1.Name = "yPositionLabel1";
            this.yPositionLabel1.Size = new System.Drawing.Size(53, 12);
            this.yPositionLabel1.TabIndex = 19;
            this.yPositionLabel1.Text = "Y (px)";
            this.yPositionLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customAchievementXNumericUpDown
            // 
            this.customAchievementXNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementXNumericUpDown.Location = new System.Drawing.Point(66, 19);
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
            this.customAchievementXNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.customAchievementXNumericUpDown.TabIndex = 15;
            // 
            // customAchievementYNumericUpDown
            // 
            this.customAchievementYNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementYNumericUpDown.Location = new System.Drawing.Point(66, 45);
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
            this.customAchievementYNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.customAchievementYNumericUpDown.TabIndex = 16;
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.notificationAchievementInNumericUpDown);
            this.groupBox9.Controls.Add(this.notificationsAchievementAnimationInComboBox);
            this.groupBox9.Controls.Add(this.customAchievementInSpeedUpDown);
            this.groupBox9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox9.Location = new System.Drawing.Point(3, 120);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(188, 95);
            this.groupBox9.TabIndex = 52;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "In-Animation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(6, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 12);
            this.label8.TabIndex = 49;
            this.label8.Text = "Speed (ms)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(6, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 40;
            this.label7.Text = "Direction";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "Mark  (ms)";
            // 
            // notificationAchievementInNumericUpDown
            // 
            this.notificationAchievementInNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationAchievementInNumericUpDown.Location = new System.Drawing.Point(114, 16);
            this.notificationAchievementInNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.notificationAchievementInNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.notificationAchievementInNumericUpDown.Name = "notificationAchievementInNumericUpDown";
            this.notificationAchievementInNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.notificationAchievementInNumericUpDown.TabIndex = 26;
            this.notificationAchievementInNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsAchievementAnimationInComboBox
            // 
            this.notificationsAchievementAnimationInComboBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsAchievementAnimationInComboBox.FormattingEnabled = true;
            this.notificationsAchievementAnimationInComboBox.Location = new System.Drawing.Point(89, 63);
            this.notificationsAchievementAnimationInComboBox.Name = "notificationsAchievementAnimationInComboBox";
            this.notificationsAchievementAnimationInComboBox.Size = new System.Drawing.Size(95, 23);
            this.notificationsAchievementAnimationInComboBox.TabIndex = 39;
            // 
            // customAchievementInSpeedUpDown
            // 
            this.customAchievementInSpeedUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementInSpeedUpDown.Location = new System.Drawing.Point(114, 39);
            this.customAchievementInSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.customAchievementInSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.customAchievementInSpeedUpDown.Name = "customAchievementInSpeedUpDown";
            this.customAchievementInSpeedUpDown.Size = new System.Drawing.Size(70, 20);
            this.customAchievementInSpeedUpDown.TabIndex = 48;
            this.customAchievementInSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox10.Controls.Add(this.label11);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Controls.Add(this.label13);
            this.groupBox10.Controls.Add(this.notificationAchievementOutNumericUpDown);
            this.groupBox10.Controls.Add(this.notificationsAchievementAnimationOutComboBox);
            this.groupBox10.Controls.Add(this.customAchievementOutSpeedUpDown);
            this.groupBox10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox10.Location = new System.Drawing.Point(3, 221);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(188, 95);
            this.groupBox10.TabIndex = 53;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Out-Animation";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(6, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 12);
            this.label11.TabIndex = 49;
            this.label11.Text = "Speed (ms)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(6, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 40;
            this.label12.Text = "Direction";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(6, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "Mark  (ms)";
            // 
            // notificationAchievementOutNumericUpDown
            // 
            this.notificationAchievementOutNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationAchievementOutNumericUpDown.Location = new System.Drawing.Point(114, 16);
            this.notificationAchievementOutNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.notificationAchievementOutNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.notificationAchievementOutNumericUpDown.Name = "notificationAchievementOutNumericUpDown";
            this.notificationAchievementOutNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.notificationAchievementOutNumericUpDown.TabIndex = 26;
            this.notificationAchievementOutNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsAchievementAnimationOutComboBox
            // 
            this.notificationsAchievementAnimationOutComboBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsAchievementAnimationOutComboBox.FormattingEnabled = true;
            this.notificationsAchievementAnimationOutComboBox.Location = new System.Drawing.Point(89, 65);
            this.notificationsAchievementAnimationOutComboBox.Name = "notificationsAchievementAnimationOutComboBox";
            this.notificationsAchievementAnimationOutComboBox.Size = new System.Drawing.Size(95, 23);
            this.notificationsAchievementAnimationOutComboBox.TabIndex = 39;
            // 
            // customAchievementOutSpeedUpDown
            // 
            this.customAchievementOutSpeedUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementOutSpeedUpDown.Location = new System.Drawing.Point(114, 42);
            this.customAchievementOutSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.customAchievementOutSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.customAchievementOutSpeedUpDown.Name = "customAchievementOutSpeedUpDown";
            this.customAchievementOutSpeedUpDown.Size = new System.Drawing.Size(70, 20);
            this.customAchievementOutSpeedUpDown.TabIndex = 48;
            this.customAchievementOutSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // customAchievementSettingsGroupBox
            // 
            this.customAchievementSettingsGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.customAchievementSettingsGroupBox.Controls.Add(this.label1);
            this.customAchievementSettingsGroupBox.Controls.Add(this.playAchievementButton);
            this.customAchievementSettingsGroupBox.Controls.Add(this.selectCustomAchievementButton);
            this.customAchievementSettingsGroupBox.Controls.Add(this.achievementPositionGroupBox);
            this.customAchievementSettingsGroupBox.Controls.Add(this.acheivementEditOutlineCheckbox);
            this.customAchievementSettingsGroupBox.Controls.Add(this.groupBox10);
            this.customAchievementSettingsGroupBox.Controls.Add(this.groupBox9);
            this.customAchievementSettingsGroupBox.Controls.Add(this.customAchievementEnableCheckbox);
            this.customAchievementSettingsGroupBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementSettingsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.customAchievementSettingsGroupBox.Location = new System.Drawing.Point(641, 12);
            this.customAchievementSettingsGroupBox.Name = "customAchievementSettingsGroupBox";
            this.customAchievementSettingsGroupBox.Size = new System.Drawing.Size(195, 320);
            this.customAchievementSettingsGroupBox.TabIndex = 54;
            this.customAchievementSettingsGroupBox.TabStop = false;
            this.customAchievementSettingsGroupBox.Text = "Achievement";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(21, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "Edit";
            // 
            // customMasterySettingsGroupBox
            // 
            this.customMasterySettingsGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.customMasterySettingsGroupBox.Controls.Add(this.label15);
            this.customMasterySettingsGroupBox.Controls.Add(this.playMasteryButton);
            this.customMasterySettingsGroupBox.Controls.Add(this.selectCustomMasteryNotificationButton);
            this.customMasterySettingsGroupBox.Controls.Add(this.groupBox13);
            this.customMasterySettingsGroupBox.Controls.Add(this.masteryEditOultineCheckbox);
            this.customMasterySettingsGroupBox.Controls.Add(this.groupBox14);
            this.customMasterySettingsGroupBox.Controls.Add(this.groupBox19);
            this.customMasterySettingsGroupBox.Controls.Add(this.customMasteryEnableCheckbox);
            this.customMasterySettingsGroupBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasterySettingsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.customMasterySettingsGroupBox.Location = new System.Drawing.Point(842, 12);
            this.customMasterySettingsGroupBox.Name = "customMasterySettingsGroupBox";
            this.customMasterySettingsGroupBox.Size = new System.Drawing.Size(195, 320);
            this.customMasterySettingsGroupBox.TabIndex = 54;
            this.customMasterySettingsGroupBox.TabStop = false;
            this.customMasterySettingsGroupBox.Text = "Mastery";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(21, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 12);
            this.label15.TabIndex = 22;
            this.label15.Text = "Edit";
            // 
            // playMasteryButton
            // 
            this.playMasteryButton.BackColor = System.Drawing.SystemColors.Control;
            this.playMasteryButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playMasteryButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playMasteryButton.Location = new System.Drawing.Point(3, 19);
            this.playMasteryButton.Name = "playMasteryButton";
            this.playMasteryButton.Size = new System.Drawing.Size(55, 23);
            this.playMasteryButton.TabIndex = 2;
            this.playMasteryButton.Text = "Play";
            this.playMasteryButton.UseVisualStyleBackColor = false;
            // 
            // selectCustomMasteryNotificationButton
            // 
            this.selectCustomMasteryNotificationButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomMasteryNotificationButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectCustomMasteryNotificationButton.Location = new System.Drawing.Point(3, 45);
            this.selectCustomMasteryNotificationButton.Name = "selectCustomMasteryNotificationButton";
            this.selectCustomMasteryNotificationButton.Size = new System.Drawing.Size(55, 23);
            this.selectCustomMasteryNotificationButton.TabIndex = 14;
            this.selectCustomMasteryNotificationButton.Text = "File";
            this.selectCustomMasteryNotificationButton.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox13.Controls.Add(this.label16);
            this.groupBox13.Controls.Add(this.scaleMasteryNumericUpDown);
            this.groupBox13.Controls.Add(this.label17);
            this.groupBox13.Controls.Add(this.label18);
            this.groupBox13.Controls.Add(this.customMasteryXNumericUpDown);
            this.groupBox13.Controls.Add(this.customMasteryYNumericUpDown);
            this.groupBox13.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox13.Location = new System.Drawing.Point(66, 19);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(125, 95);
            this.groupBox13.TabIndex = 50;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Position";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label16.Location = new System.Drawing.Point(6, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 12);
            this.label16.TabIndex = 21;
            this.label16.Text = "Scale";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scaleMasteryNumericUpDown
            // 
            this.scaleMasteryNumericUpDown.DecimalPlaces = 2;
            this.scaleMasteryNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleMasteryNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.scaleMasteryNumericUpDown.Location = new System.Drawing.Point(57, 69);
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
            this.scaleMasteryNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.scaleMasteryNumericUpDown.TabIndex = 20;
            this.scaleMasteryNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(6, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 18;
            this.label17.Text = "X (px)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label18.Location = new System.Drawing.Point(6, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 19;
            this.label18.Text = "Y (px)";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customMasteryXNumericUpDown
            // 
            this.customMasteryXNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryXNumericUpDown.Location = new System.Drawing.Point(66, 19);
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
            this.customMasteryXNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.customMasteryXNumericUpDown.TabIndex = 15;
            // 
            // customMasteryYNumericUpDown
            // 
            this.customMasteryYNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryYNumericUpDown.Location = new System.Drawing.Point(66, 45);
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
            this.customMasteryYNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.customMasteryYNumericUpDown.TabIndex = 16;
            // 
            // masteryEditOultineCheckbox
            // 
            this.masteryEditOultineCheckbox.AutoSize = true;
            this.masteryEditOultineCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masteryEditOultineCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.masteryEditOultineCheckbox.Location = new System.Drawing.Point(3, 78);
            this.masteryEditOultineCheckbox.Name = "masteryEditOultineCheckbox";
            this.masteryEditOultineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.masteryEditOultineCheckbox.TabIndex = 47;
            this.masteryEditOultineCheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox14.Controls.Add(this.label19);
            this.groupBox14.Controls.Add(this.label20);
            this.groupBox14.Controls.Add(this.label21);
            this.groupBox14.Controls.Add(this.notificationMasteryOutNumericUpDown);
            this.groupBox14.Controls.Add(this.notificationsMasteryAnimationOutComboBox);
            this.groupBox14.Controls.Add(this.customMasteryOutSpeedUpDown);
            this.groupBox14.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox14.Location = new System.Drawing.Point(3, 221);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(188, 95);
            this.groupBox14.TabIndex = 53;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Out-Animation";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label19.Location = new System.Drawing.Point(6, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 12);
            this.label19.TabIndex = 49;
            this.label19.Text = "Speed (ms)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label20.Location = new System.Drawing.Point(6, 71);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 12);
            this.label20.TabIndex = 40;
            this.label20.Text = "Direction";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label21.Location = new System.Drawing.Point(6, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 12);
            this.label21.TabIndex = 20;
            this.label21.Text = "Mark  (ms)";
            // 
            // notificationMasteryOutNumericUpDown
            // 
            this.notificationMasteryOutNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationMasteryOutNumericUpDown.Location = new System.Drawing.Point(108, 14);
            this.notificationMasteryOutNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.notificationMasteryOutNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.notificationMasteryOutNumericUpDown.Name = "notificationMasteryOutNumericUpDown";
            this.notificationMasteryOutNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.notificationMasteryOutNumericUpDown.TabIndex = 26;
            this.notificationMasteryOutNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsMasteryAnimationOutComboBox
            // 
            this.notificationsMasteryAnimationOutComboBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsMasteryAnimationOutComboBox.FormattingEnabled = true;
            this.notificationsMasteryAnimationOutComboBox.Location = new System.Drawing.Point(87, 65);
            this.notificationsMasteryAnimationOutComboBox.Name = "notificationsMasteryAnimationOutComboBox";
            this.notificationsMasteryAnimationOutComboBox.Size = new System.Drawing.Size(91, 23);
            this.notificationsMasteryAnimationOutComboBox.TabIndex = 39;
            // 
            // customMasteryOutSpeedUpDown
            // 
            this.customMasteryOutSpeedUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryOutSpeedUpDown.Location = new System.Drawing.Point(108, 40);
            this.customMasteryOutSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.customMasteryOutSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.customMasteryOutSpeedUpDown.Name = "customMasteryOutSpeedUpDown";
            this.customMasteryOutSpeedUpDown.Size = new System.Drawing.Size(70, 20);
            this.customMasteryOutSpeedUpDown.TabIndex = 48;
            this.customMasteryOutSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // groupBox19
            // 
            this.groupBox19.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox19.Controls.Add(this.label22);
            this.groupBox19.Controls.Add(this.label23);
            this.groupBox19.Controls.Add(this.label24);
            this.groupBox19.Controls.Add(this.notificationMasteryInNumericUpDown);
            this.groupBox19.Controls.Add(this.notificationsMasteryAnimationInComboBox);
            this.groupBox19.Controls.Add(this.customMasteryInSpeedUpDown);
            this.groupBox19.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox19.Location = new System.Drawing.Point(3, 120);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(188, 95);
            this.groupBox19.TabIndex = 52;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "In-Animation";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label22.Location = new System.Drawing.Point(6, 43);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 12);
            this.label22.TabIndex = 49;
            this.label22.Text = "Speed (ms)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label23.Location = new System.Drawing.Point(6, 71);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 12);
            this.label23.TabIndex = 40;
            this.label23.Text = "Direction";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label24.Location = new System.Drawing.Point(6, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(85, 12);
            this.label24.TabIndex = 20;
            this.label24.Text = "Mark  (ms)";
            // 
            // notificationMasteryInNumericUpDown
            // 
            this.notificationMasteryInNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationMasteryInNumericUpDown.Location = new System.Drawing.Point(108, 12);
            this.notificationMasteryInNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.notificationMasteryInNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.notificationMasteryInNumericUpDown.Name = "notificationMasteryInNumericUpDown";
            this.notificationMasteryInNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.notificationMasteryInNumericUpDown.TabIndex = 26;
            this.notificationMasteryInNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsMasteryAnimationInComboBox
            // 
            this.notificationsMasteryAnimationInComboBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsMasteryAnimationInComboBox.FormattingEnabled = true;
            this.notificationsMasteryAnimationInComboBox.Location = new System.Drawing.Point(89, 63);
            this.notificationsMasteryAnimationInComboBox.Name = "notificationsMasteryAnimationInComboBox";
            this.notificationsMasteryAnimationInComboBox.Size = new System.Drawing.Size(91, 23);
            this.notificationsMasteryAnimationInComboBox.TabIndex = 39;
            // 
            // customMasteryInSpeedUpDown
            // 
            this.customMasteryInSpeedUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryInSpeedUpDown.Location = new System.Drawing.Point(108, 38);
            this.customMasteryInSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.customMasteryInSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.customMasteryInSpeedUpDown.Name = "customMasteryInSpeedUpDown";
            this.customMasteryInSpeedUpDown.Size = new System.Drawing.Size(70, 20);
            this.customMasteryInSpeedUpDown.TabIndex = 48;
            this.customMasteryInSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // customMasteryEnableCheckbox
            // 
            this.customMasteryEnableCheckbox.AutoSize = true;
            this.customMasteryEnableCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryEnableCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.customMasteryEnableCheckbox.Location = new System.Drawing.Point(174, 0);
            this.customMasteryEnableCheckbox.Name = "customMasteryEnableCheckbox";
            this.customMasteryEnableCheckbox.Size = new System.Drawing.Size(15, 14);
            this.customMasteryEnableCheckbox.TabIndex = 13;
            this.customMasteryEnableCheckbox.UseVisualStyleBackColor = true;
            // 
            // achievementListGroupBox
            // 
            this.achievementListGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.achievementListGroupBox.Controls.Add(this.autoLaunchAchievementListWindowCheckbox);
            this.achievementListGroupBox.Controls.Add(this.customizeAchievementListButton);
            this.achievementListGroupBox.Controls.Add(this.openAchievementListWindowButton);
            this.achievementListGroupBox.Enabled = false;
            this.achievementListGroupBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementListGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.achievementListGroupBox.Location = new System.Drawing.Point(307, 251);
            this.achievementListGroupBox.Name = "achievementListGroupBox";
            this.achievementListGroupBox.Size = new System.Drawing.Size(72, 105);
            this.achievementListGroupBox.TabIndex = 10025;
            this.achievementListGroupBox.TabStop = false;
            this.achievementListGroupBox.Text = "List";
            // 
            // autoLaunchAchievementListWindowCheckbox
            // 
            this.autoLaunchAchievementListWindowCheckbox.AutoSize = true;
            this.autoLaunchAchievementListWindowCheckbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLaunchAchievementListWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoLaunchAchievementListWindowCheckbox.Location = new System.Drawing.Point(6, 18);
            this.autoLaunchAchievementListWindowCheckbox.Name = "autoLaunchAchievementListWindowCheckbox";
            this.autoLaunchAchievementListWindowCheckbox.Size = new System.Drawing.Size(54, 18);
            this.autoLaunchAchievementListWindowCheckbox.TabIndex = 10022;
            this.autoLaunchAchievementListWindowCheckbox.Text = "Auto";
            this.autoLaunchAchievementListWindowCheckbox.UseVisualStyleBackColor = true;
            // 
            // customizeAchievementListButton
            // 
            this.customizeAchievementListButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeAchievementListButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeAchievementListButton.Location = new System.Drawing.Point(6, 70);
            this.customizeAchievementListButton.Name = "customizeAchievementListButton";
            this.customizeAchievementListButton.Size = new System.Drawing.Size(61, 28);
            this.customizeAchievementListButton.TabIndex = 10024;
            this.customizeAchievementListButton.Text = "Custom";
            this.customizeAchievementListButton.UseVisualStyleBackColor = true;
            // 
            // openAchievementListWindowButton
            // 
            this.openAchievementListWindowButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openAchievementListWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openAchievementListWindowButton.Location = new System.Drawing.Point(6, 37);
            this.openAchievementListWindowButton.Name = "openAchievementListWindowButton";
            this.openAchievementListWindowButton.Size = new System.Drawing.Size(61, 28);
            this.openAchievementListWindowButton.TabIndex = 10021;
            this.openAchievementListWindowButton.Text = "Open";
            this.openAchievementListWindowButton.UseVisualStyleBackColor = true;
            // 
            // achievementListOverrideSettingsGroupBox
            // 
            this.achievementListOverrideSettingsGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.achievementListOverrideSettingsGroupBox.Controls.Add(this.achievementListFitCheckBox);
            this.achievementListOverrideSettingsGroupBox.Controls.Add(this.achievementListSingleContainer);
            this.achievementListOverrideSettingsGroupBox.Controls.Add(this.achievementListCountNumericUpDown);
            this.achievementListOverrideSettingsGroupBox.Controls.Add(this.columnBasedRadioButton);
            this.achievementListOverrideSettingsGroupBox.Controls.Add(this.rowBasedRadioButton);
            this.achievementListOverrideSettingsGroupBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementListOverrideSettingsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.achievementListOverrideSettingsGroupBox.Location = new System.Drawing.Point(1073, 275);
            this.achievementListOverrideSettingsGroupBox.Name = "achievementListOverrideSettingsGroupBox";
            this.achievementListOverrideSettingsGroupBox.Size = new System.Drawing.Size(396, 51);
            this.achievementListOverrideSettingsGroupBox.TabIndex = 10009;
            this.achievementListOverrideSettingsGroupBox.TabStop = false;
            this.achievementListOverrideSettingsGroupBox.Text = "Achievement List Customization";
            // 
            // achievementListFitCheckBox
            // 
            this.achievementListFitCheckBox.AutoSize = true;
            this.achievementListFitCheckBox.Location = new System.Drawing.Point(332, 22);
            this.achievementListFitCheckBox.Name = "achievementListFitCheckBox";
            this.achievementListFitCheckBox.Size = new System.Drawing.Size(53, 17);
            this.achievementListFitCheckBox.TabIndex = 4;
            this.achievementListFitCheckBox.Text = "Fit";
            this.achievementListFitCheckBox.UseVisualStyleBackColor = true;
            // 
            // achievementListSingleContainer
            // 
            this.achievementListSingleContainer.AutoSize = true;
            this.achievementListSingleContainer.Location = new System.Drawing.Point(246, 22);
            this.achievementListSingleContainer.Name = "achievementListSingleContainer";
            this.achievementListSingleContainer.Size = new System.Drawing.Size(80, 17);
            this.achievementListSingleContainer.TabIndex = 3;
            this.achievementListSingleContainer.Text = "Single";
            this.achievementListSingleContainer.UseVisualStyleBackColor = true;
            // 
            // achievementListCountNumericUpDown
            // 
            this.achievementListCountNumericUpDown.Location = new System.Drawing.Point(6, 20);
            this.achievementListCountNumericUpDown.Name = "achievementListCountNumericUpDown";
            this.achievementListCountNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.achievementListCountNumericUpDown.TabIndex = 2;
            // 
            // columnBasedRadioButton
            // 
            this.columnBasedRadioButton.AutoSize = true;
            this.columnBasedRadioButton.Location = new System.Drawing.Point(86, 21);
            this.columnBasedRadioButton.Name = "columnBasedRadioButton";
            this.columnBasedRadioButton.Size = new System.Drawing.Size(79, 17);
            this.columnBasedRadioButton.TabIndex = 1;
            this.columnBasedRadioButton.TabStop = true;
            this.columnBasedRadioButton.Text = "Column";
            this.columnBasedRadioButton.UseVisualStyleBackColor = true;
            // 
            // rowBasedRadioButton
            // 
            this.rowBasedRadioButton.AutoSize = true;
            this.rowBasedRadioButton.Location = new System.Drawing.Point(171, 22);
            this.rowBasedRadioButton.Name = "rowBasedRadioButton";
            this.rowBasedRadioButton.Size = new System.Drawing.Size(52, 17);
            this.rowBasedRadioButton.TabIndex = 0;
            this.rowBasedRadioButton.TabStop = true;
            this.rowBasedRadioButton.Text = "Row";
            this.rowBasedRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1450, 747);
            this.Controls.Add(this.achievementListOverrideSettingsGroupBox);
            this.Controls.Add(this.achievementListGroupBox);
            this.Controls.Add(this.customAchievementSettingsGroupBox);
            this.Controls.Add(this.customMasterySettingsGroupBox);
            this.Controls.Add(this.fontSettingsGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gameInfoOverrideSettingsGroupBox);
            this.Controls.Add(this.statsCustomizationsGroupBox);
            this.Controls.Add(this.notificationsGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.userInfoGroupBox);
            this.Controls.Add(this.statsGroupBox);
            this.Controls.Add(this.focusGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.Text = "Retro Achievements Tracker";
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePictureBox)).EndInit();
            this.statsGroupBox.ResumeLayout(false);
            this.statsGroupBox.PerformLayout();
            this.focusGroupBox.ResumeLayout(false);
            this.focusGroupBox.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.raConnectionStatusPictureBox)).EndInit();
            this.notificationsGroupBox.ResumeLayout(false);
            this.notificationsGroupBox.PerformLayout();
            this.userInfoGroupBox.ResumeLayout(false);
            this.userInfoGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statsCustomizationsGroupBox.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.gameInfoOverrideSettingsGroupBox.ResumeLayout(false);
            this.gameInfoOverrideSettingsGroupBox.PerformLayout();
            this.fontSettingsGroupBox.ResumeLayout(false);
            this.fontSettingsGroupBox.PerformLayout();
            this.windowBackgroundGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.windowBackgroundColorPictureBox)).EndInit();
            this.borderBackgroundGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.borderBackgroudColorPictureBox)).EndInit();
            this.pointsFontGroupBox.ResumeLayout(false);
            this.pointsFontGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointsFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsFontColorPictureBox)).EndInit();
            this.descriptionFontGroupBox.ResumeLayout(false);
            this.descriptionFontGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionFontColorPictureBox)).EndInit();
            this.lineFontGroupBox.ResumeLayout(false);
            this.lineFontGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineColorPictureBox)).EndInit();
            this.titleFontGroupBox.ResumeLayout(false);
            this.titleFontGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titleFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleFontColorPictureBox)).EndInit();
            this.achievementPositionGroupBox.ResumeLayout(false);
            this.achievementPositionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleAchievementNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementYNumericUpDown)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationAchievementInNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementInSpeedUpDown)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationAchievementOutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementOutSpeedUpDown)).EndInit();
            this.customAchievementSettingsGroupBox.ResumeLayout(false);
            this.customAchievementSettingsGroupBox.PerformLayout();
            this.customMasterySettingsGroupBox.ResumeLayout(false);
            this.customMasterySettingsGroupBox.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleMasteryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryYNumericUpDown)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationMasteryOutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryOutSpeedUpDown)).EndInit();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationMasteryInNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customMasteryInSpeedUpDown)).EndInit();
            this.achievementListGroupBox.ResumeLayout(false);
            this.achievementListGroupBox.PerformLayout();
            this.achievementListOverrideSettingsGroupBox.ResumeLayout(false);
            this.achievementListOverrideSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.achievementListCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Label usernameLabel;
        private Label apiKeyLabel;
        private TextBox apiKeyTextBox;
        private TextBox usernameTextBox;
        private PictureBox userProfilePictureBox;
        private Button startButton;
        private Button stopButton;
        private Button openFocusWindowButton;
        private CheckBox autoStartCheckbox;
        private CheckBox autoLaunchFocusWindowCheckBox;
        private GroupBox notificationsGroupBox;
        private GroupBox userInfoGroupBox;
        private GroupBox focusGroupBox;
        private GroupBox statsGroupBox;
        private CheckBox autoLaunchStatsWindowCheckbox;
        private Button openStatsWindowButton;
        private CheckBox autoLaunchNotificationsWindowCheckbox;
        private Button openNotificationWindowButton;
        private Label timerStatusLabel;
        private PictureBox raConnectionStatusPictureBox;
        private Label label33;
        private Label focusAchievementDescriptionLabel;
        private PictureBox focusAchievementPictureBox;
        private Label focusAchievementTitleLabel;
        private Button customizeFocusButton;
        private Button customizeStatsButton;
        private Button customizeAlertsButton;
        private GroupBox groupBox1;
        private Button customizeGameInfoButton;
        private CheckBox autoLaunchGameInfoWindowCheckbox;
        private Button openGameInfoWindowButton;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button customizeLastFiveButton;
        private CheckBox autoLaunchLastFiveWindowCheckbox;
        private Button openLastFiveWindowButton;
        private TextBox statsGameRatioOverrideTextBox;
        private TextBox statsTruePointsOverrideTextBox;
        private TextBox statsPointsOverrideTextBox;
        private TextBox statsRatioOverrideTextBox;
        private TextBox statsAwardsOverrideTextBox;
        private TextBox statsRankOverrideTextBox;
        private GroupBox statsCustomizationsGroupBox;
        private GroupBox gameInfoOverrideSettingsGroupBox;
        private TextBox statsGameTruePointsOverrideTextBox;
        private TextBox statsGamePointsOverrideTextBox;
        private TextBox statsGameAchievementsOverrideTextBox;
        private Button setFocusButton;
        private Button focusAchievementButtonRight;
        private Button focusAchievementButtonLeft;
        private OpenFileDialog openFileDialog1;
        private ColorDialog colorDialog1;
        private TextBox gameInfoGenreOverrideTextBox;
        private TextBox gameInfoConsoleOverrideTextBox;
        private TextBox gameInfoPublisherOverrideTextBox;
        private TextBox gameInfoReleaseDateOverrideTextBox;
        private TextBox gameInfoDeveloperOverrideTextBox;
        private Button statsDefaultButton;
        private Button gameInfoDefaultButton;
        private TextBox gameInfoTitleOverrideTextBox;
        private TextBox statsCompletedOverrideTextBox;
        private CheckBox fontBorderEnableCheckBox;
        private RadioButton statsRadioButtonDot;
        private RadioButton statsRadioButtonBackslash;
        private RadioButton statsRadioButtonSemicolon;
        private GroupBox fontSettingsGroupBox;
        private GroupBox titleFontGroupBox;
        private Button titleFontOutlineColorButton;
        private PictureBox titleFontOutlineColorPictureBox;
        private Button titleFontColorButton;
        private PictureBox titleFontColorPictureBox;
        private NumericUpDown titleFontOutlineNumericUpDown;
        private CheckBox titleFontOutlineCheckbox;
        private ComboBox titleFontFamilyComboBox;
        private Button borderBackgroundColorButton;
        private PictureBox borderBackgroudColorPictureBox;
        private Label titleOutlineLabel;
        private CheckBox fontSimpleCheckbox;
        private Label label2;
        private GroupBox lineFontGroupBox;
        private Label label5;
        private Button lineOutlineColorButton;
        private PictureBox lineOutlineColorPictureBox;
        private Button lineColorButton;
        private CheckBox lineOutlineCheckbox;
        private NumericUpDown lineOutlineNumericUpDown;
        private PictureBox lineColorPictureBox;
        private GroupBox pointsFontGroupBox;
        private Label label4;
        private Button pointsFontOutlineColorButton;
        private PictureBox pointsFontOutlineColorPictureBox;
        private Button pointsFontColorButton;
        private CheckBox pointsFontOutlineCheckbox;
        private NumericUpDown pointsFontOutlineNumericUpDown;
        private PictureBox pointsFontColorPictureBox;
        private ComboBox pointsFontFamilyComboBox;
        private GroupBox descriptionFontGroupBox;
        private Label label3;
        private Button descriptionFontOutlineColorButton;
        private PictureBox descriptionFontOutlineColorPictureBox;
        private Button descriptionFontColorButton;
        private CheckBox descriptionFontOutlineCheckbox;
        private NumericUpDown descriptionFontOutlineNumericUpDown;
        private PictureBox descriptionFontColorPictureBox;
        private ComboBox descriptionFontFamilyComboBox;
        private GroupBox borderBackgroundGroupBox;
        private Button playAchievementButton;
        private CheckBox customAchievementEnableCheckbox;
        private Button selectCustomAchievementButton;
        private CheckBox acheivementEditOutlineCheckbox;
        private GroupBox achievementPositionGroupBox;
        private Label label14;
        private NumericUpDown scaleAchievementNumericUpDown;
        private Label xPositionLabel1;
        private Label yPositionLabel1;
        private NumericUpDown customAchievementXNumericUpDown;
        private NumericUpDown customAchievementYNumericUpDown;
        private GroupBox groupBox9;
        private Label label8;
        private Label label7;
        private Label label6;
        private NumericUpDown notificationAchievementInNumericUpDown;
        private ComboBox notificationsAchievementAnimationInComboBox;
        private NumericUpDown customAchievementInSpeedUpDown;
        private GroupBox groupBox10;
        private Label label11;
        private Label label12;
        private Label label13;
        private NumericUpDown notificationAchievementOutNumericUpDown;
        private ComboBox notificationsAchievementAnimationOutComboBox;
        private NumericUpDown customAchievementOutSpeedUpDown;
        private Label label9;
        private GroupBox groupBox15;
        private GroupBox groupBox16;
        private GroupBox groupBox17;
        private GroupBox customAchievementSettingsGroupBox;
        private Label label1;
        private GroupBox customMasterySettingsGroupBox;
        private Label label15;
        private GroupBox groupBox13;
        private Label label16;
        private NumericUpDown scaleMasteryNumericUpDown;
        private Label label17;
        private Label label18;
        private NumericUpDown customMasteryXNumericUpDown;
        private NumericUpDown customMasteryYNumericUpDown;
        private CheckBox masteryEditOultineCheckbox;
        private GroupBox groupBox14;
        private Label label19;
        private Label label20;
        private Label label21;
        private NumericUpDown notificationMasteryOutNumericUpDown;
        private ComboBox notificationsMasteryAnimationOutComboBox;
        private NumericUpDown customMasteryOutSpeedUpDown;
        private GroupBox groupBox19;
        private Label label22;
        private Label label23;
        private Label label24;
        private NumericUpDown notificationMasteryInNumericUpDown;
        private ComboBox notificationsMasteryAnimationInComboBox;
        private NumericUpDown customMasteryInSpeedUpDown;
        private CheckBox customMasteryEnableCheckbox;
        private Button selectCustomMasteryNotificationButton;
        private Button playMasteryButton;
        private GroupBox groupBox20;
        private Button button11;
        private CheckBox gameRatioEnableCheckBox;
        private CheckBox gameTruePointsEnableCheckBox;
        private CheckBox gamePointsEnableCheckBox;
        private CheckBox completedEnableCheckBox;
        private CheckBox gameAchievementsEnableCheckBox;
        private CheckBox truePointsEnableCheckBox;
        private CheckBox ratioEnableCheckBox;
        private CheckBox pointsEnableCheckBox;
        private CheckBox awardsEnableCheckBox;
        private CheckBox rankEnableCheckBox;
        private CheckBox releasedDateEnableCheckBox;
        private CheckBox consoleEnableCheckBox;
        private CheckBox publisherEnableCheckBox;
        private CheckBox genreEnableCheckBox;
        private CheckBox developerEnableCheckBox;
        private CheckBox titleEnableCheckBox;
        private GroupBox windowBackgroundGroupBox;
        private Button windowBackgroundColorButton;
        private PictureBox windowBackgroundColorPictureBox;
        private GroupBox achievementListGroupBox;
        private CheckBox autoLaunchAchievementListWindowCheckbox;
        private Button customizeAchievementListButton;
        private Button openAchievementListWindowButton;
        private GroupBox achievementListOverrideSettingsGroupBox;
        private CheckBox achievementListFitCheckBox;
        private CheckBox achievementListSingleContainer;
        private NumericUpDown achievementListCountNumericUpDown;
        private RadioButton columnBasedRadioButton;
        private RadioButton rowBasedRadioButton;
    }
}

