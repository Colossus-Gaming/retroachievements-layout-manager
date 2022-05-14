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
            this.userStatsGroupBox = new System.Windows.Forms.GroupBox();
            this.autoOpenUserStatsWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.customizeUserStatsButton = new System.Windows.Forms.Button();
            this.openUserStatsWindowButton = new System.Windows.Forms.Button();
            this.focusGroupBox = new System.Windows.Forms.GroupBox();
            this.customizeFocusButton = new System.Windows.Forms.Button();
            this.autoOpenFocusWindowCheckBox = new System.Windows.Forms.CheckBox();
            this.openFocusWindowButton = new System.Windows.Forms.Button();
            this.userInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.focusAchievementPictureBox = new System.Windows.Forms.PictureBox();
            this.focusAchievementTitleLabel = new System.Windows.Forms.Label();
            this.focusAchievementDescriptionLabel = new System.Windows.Forms.Label();
            this.setFocusButton = new System.Windows.Forms.Button();
            this.focusAchievementButtonLeft = new System.Windows.Forms.Button();
            this.focusAchievementButtonRight = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gameInfoPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoTitleLabel = new System.Windows.Forms.Label();
            this.gameInfoProgressLabel = new System.Windows.Forms.Label();
            this.rssFeedFriendCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedCheevoCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedNewsCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedForumCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.raConnectionStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsGroupBox = new System.Windows.Forms.GroupBox();
            this.customizeAlertsButton = new System.Windows.Forms.Button();
            this.autoOpenAlertsWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.openNotificationWindowButton = new System.Windows.Forms.Button();
            this.gameInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.customizeGameInfoButton = new System.Windows.Forms.Button();
            this.autoOpenGameInfoWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.openGameInfoWindowButton = new System.Windows.Forms.Button();
            this.recentAchievementsGroupBox = new System.Windows.Forms.GroupBox();
            this.customizeLastFiveButton = new System.Windows.Forms.Button();
            this.autoOpenLastFiveWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.openLastFiveWindowButton = new System.Windows.Forms.Button();
            this.statsGameRatioOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsTruePointsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsPointsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsRatioOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsAwardsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsRankOverrideTextBox = new System.Windows.Forms.TextBox();
            this.userStatsCustomizationGroupBox = new System.Windows.Forms.GroupBox();
            this.truePointsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.ratioEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.pointsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.awardsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.userStatsDefaultButton = new System.Windows.Forms.Button();
            this.rankEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.statsRadioButtonBackslash = new System.Windows.Forms.RadioButton();
            this.statsRadioButtonSemicolon = new System.Windows.Forms.RadioButton();
            this.statsRadioButtonDot = new System.Windows.Forms.RadioButton();
            this.gameRatioEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.gameTruePointsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.gamePointsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.completedEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.gameAchievementsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.gameStatsDefaultButton = new System.Windows.Forms.Button();
            this.statsGameAchievementsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsGamePointsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsGameTruePointsOverrideTextBox = new System.Windows.Forms.TextBox();
            this.statsCompletedOverrideTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoCustomizationGroupBox = new System.Windows.Forms.GroupBox();
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
            this.fontBorderCheckBox = new System.Windows.Forms.CheckBox();
            this.windowBackgroundGroupBox = new System.Windows.Forms.GroupBox();
            this.windowBackgroundColorButton = new System.Windows.Forms.Button();
            this.windowBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.fontBorderLabel = new System.Windows.Forms.Label();
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
            this.simpleFontLabel = new System.Windows.Forms.Label();
            this.simpleFontCheckBox = new System.Windows.Forms.CheckBox();
            this.titleFontGroupBox = new System.Windows.Forms.GroupBox();
            this.titleOutlineLabel = new System.Windows.Forms.Label();
            this.titleFontOutlineColorButton = new System.Windows.Forms.Button();
            this.titleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.titleFontColorButton = new System.Windows.Forms.Button();
            this.titleFontOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.titleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.titleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.titleFontFamilyComboBox = new System.Windows.Forms.ComboBox();
            this.customMasterySettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
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
            this.customAchievementCustomizationGroupBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.replayAchievementButton = new System.Windows.Forms.Button();
            this.selectCustomAchievementButton = new System.Windows.Forms.Button();
            this.achievementPositionGroupBox = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.scaleAchievementNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.xPositionLabel1 = new System.Windows.Forms.Label();
            this.yPositionLabel1 = new System.Windows.Forms.Label();
            this.customAchievementXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.customAchievementYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.acheivementEditOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.notificationAchievementOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsAchievementAnimationOutComboBox = new System.Windows.Forms.ComboBox();
            this.customAchievementOutSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.notificationAchievementInNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsAchievementAnimationInComboBox = new System.Windows.Forms.ComboBox();
            this.customAchievementInSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.customAchievementEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.achievementListGroupBox = new System.Windows.Forms.GroupBox();
            this.autoOpenAchievementListWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.customizeAchievementListButton = new System.Windows.Forms.Button();
            this.openAchievementListWindowButton = new System.Windows.Forms.Button();
            this.gameStatsGroupBox = new System.Windows.Forms.GroupBox();
            this.autoOpenGameStatsWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.customizeGameStatsButton = new System.Windows.Forms.Button();
            this.openGameStatsWindowButton = new System.Windows.Forms.Button();
            this.gameStatsCustomizationGroupBox = new System.Windows.Forms.GroupBox();
            this.settingsAndBrowserGroupBox = new System.Windows.Forms.GroupBox();
            this.recentAchievementsMaxListLabel = new System.Windows.Forms.Label();
            this.recentAchievementsMaxListNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.autoSrollLabel = new System.Windows.Forms.Label();
            this.autoScrollCheckBox = new System.Windows.Forms.CheckBox();
            this.userBrowserGroupBox = new System.Windows.Forms.GroupBox();
            this.autoOpenWebBrowserCheckbox = new System.Windows.Forms.CheckBox();
            this.toggleUserBrowserButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePictureBox)).BeginInit();
            this.userStatsGroupBox.SuspendLayout();
            this.focusGroupBox.SuspendLayout();
            this.userInfoGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raConnectionStatusPictureBox)).BeginInit();
            this.notificationsGroupBox.SuspendLayout();
            this.gameInfoGroupBox.SuspendLayout();
            this.recentAchievementsGroupBox.SuspendLayout();
            this.userStatsCustomizationGroupBox.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.gameInfoCustomizationGroupBox.SuspendLayout();
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
            this.customAchievementCustomizationGroupBox.SuspendLayout();
            this.achievementPositionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleAchievementNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementYNumericUpDown)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationAchievementOutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementOutSpeedUpDown)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationAchievementInNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementInSpeedUpDown)).BeginInit();
            this.achievementListGroupBox.SuspendLayout();
            this.gameStatsGroupBox.SuspendLayout();
            this.gameStatsCustomizationGroupBox.SuspendLayout();
            this.settingsAndBrowserGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsMaxListNumericUpDown)).BeginInit();
            this.userBrowserGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // apiKeyLabel
            // 
            this.apiKeyLabel.AutoSize = true;
            this.apiKeyLabel.BackColor = System.Drawing.Color.Transparent;
            this.apiKeyLabel.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyLabel.Location = new System.Drawing.Point(88, 59);
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(61, 11);
            this.apiKeyLabel.TabIndex = 31;
            this.apiKeyLabel.Text = "API Key";
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.Font = new System.Drawing.Font("Calibri", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyTextBox.Location = new System.Drawing.Point(88, 69);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.PasswordChar = '*';
            this.apiKeyTextBox.Size = new System.Drawing.Size(165, 19);
            this.apiKeyTextBox.TabIndex = 1;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(88, 25);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(69, 11);
            this.usernameLabel.TabIndex = 26;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Calibri", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(88, 37);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(165, 19);
            this.usernameTextBox.TabIndex = 0;
            // 
            // userProfilePictureBox
            // 
            this.userProfilePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.userProfilePictureBox.Location = new System.Drawing.Point(6, 12);
            this.userProfilePictureBox.Name = "userProfilePictureBox";
            this.userProfilePictureBox.Size = new System.Drawing.Size(76, 76);
            this.userProfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userProfilePictureBox.TabIndex = 20;
            this.userProfilePictureBox.TabStop = false;
            // 
            // autoStartCheckbox
            // 
            this.autoStartCheckbox.AutoSize = true;
            this.autoStartCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.autoStartCheckbox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoStartCheckbox.Location = new System.Drawing.Point(232, 17);
            this.autoStartCheckbox.Name = "autoStartCheckbox";
            this.autoStartCheckbox.Size = new System.Drawing.Size(94, 15);
            this.autoStartCheckbox.TabIndex = 2;
            this.autoStartCheckbox.Text = "Auto-Start";
            this.autoStartCheckbox.UseVisualStyleBackColor = false;
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopButton.Location = new System.Drawing.Point(259, 70);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 21);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // timerStatusLabel
            // 
            this.timerStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.timerStatusLabel.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timerStatusLabel.Location = new System.Drawing.Point(6, 14);
            this.timerStatusLabel.Name = "timerStatusLabel";
            this.timerStatusLabel.Size = new System.Drawing.Size(269, 25);
            this.timerStatusLabel.TabIndex = 10024;
            this.timerStatusLabel.Text = "Offline";
            // 
            // userStatsGroupBox
            // 
            this.userStatsGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.userStatsGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block;
            this.userStatsGroupBox.Controls.Add(this.autoOpenUserStatsWindowCheckbox);
            this.userStatsGroupBox.Controls.Add(this.customizeUserStatsButton);
            this.userStatsGroupBox.Controls.Add(this.openUserStatsWindowButton);
            this.userStatsGroupBox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userStatsGroupBox.ForeColor = System.Drawing.Color.White;
            this.userStatsGroupBox.Location = new System.Drawing.Point(353, 210);
            this.userStatsGroupBox.Name = "userStatsGroupBox";
            this.userStatsGroupBox.Size = new System.Drawing.Size(315, 45);
            this.userStatsGroupBox.TabIndex = 10023;
            this.userStatsGroupBox.TabStop = false;
            this.userStatsGroupBox.Text = "User Info";
            // 
            // autoOpenUserStatsWindowCheckbox
            // 
            this.autoOpenUserStatsWindowCheckbox.AutoSize = true;
            this.autoOpenUserStatsWindowCheckbox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoOpenUserStatsWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoOpenUserStatsWindowCheckbox.Location = new System.Drawing.Point(6, 19);
            this.autoOpenUserStatsWindowCheckbox.Name = "autoOpenUserStatsWindowCheckbox";
            this.autoOpenUserStatsWindowCheckbox.Size = new System.Drawing.Size(87, 15);
            this.autoOpenUserStatsWindowCheckbox.TabIndex = 10022;
            this.autoOpenUserStatsWindowCheckbox.Text = "Auto-Open";
            this.autoOpenUserStatsWindowCheckbox.UseVisualStyleBackColor = true;
            // 
            // customizeUserStatsButton
            // 
            this.customizeUserStatsButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeUserStatsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeUserStatsButton.Location = new System.Drawing.Point(226, 10);
            this.customizeUserStatsButton.Name = "customizeUserStatsButton";
            this.customizeUserStatsButton.Size = new System.Drawing.Size(85, 28);
            this.customizeUserStatsButton.TabIndex = 10024;
            this.customizeUserStatsButton.Text = "Custom";
            this.customizeUserStatsButton.UseVisualStyleBackColor = true;
            // 
            // openUserStatsWindowButton
            // 
            this.openUserStatsWindowButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openUserStatsWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openUserStatsWindowButton.Location = new System.Drawing.Point(135, 11);
            this.openUserStatsWindowButton.Name = "openUserStatsWindowButton";
            this.openUserStatsWindowButton.Size = new System.Drawing.Size(85, 28);
            this.openUserStatsWindowButton.TabIndex = 10021;
            this.openUserStatsWindowButton.Text = "Open";
            this.openUserStatsWindowButton.UseVisualStyleBackColor = true;
            // 
            // focusGroupBox
            // 
            this.focusGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.focusGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block;
            this.focusGroupBox.Controls.Add(this.customizeFocusButton);
            this.focusGroupBox.Controls.Add(this.autoOpenFocusWindowCheckBox);
            this.focusGroupBox.Controls.Add(this.openFocusWindowButton);
            this.focusGroupBox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusGroupBox.Location = new System.Drawing.Point(353, 6);
            this.focusGroupBox.Name = "focusGroupBox";
            this.focusGroupBox.Size = new System.Drawing.Size(315, 45);
            this.focusGroupBox.TabIndex = 10001;
            this.focusGroupBox.TabStop = false;
            this.focusGroupBox.Text = "Cheevo Focus";
            // 
            // customizeFocusButton
            // 
            this.customizeFocusButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeFocusButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeFocusButton.Location = new System.Drawing.Point(226, 11);
            this.customizeFocusButton.Name = "customizeFocusButton";
            this.customizeFocusButton.Size = new System.Drawing.Size(85, 28);
            this.customizeFocusButton.TabIndex = 10025;
            this.customizeFocusButton.Text = "Custom";
            this.customizeFocusButton.UseVisualStyleBackColor = true;
            // 
            // autoOpenFocusWindowCheckBox
            // 
            this.autoOpenFocusWindowCheckBox.AutoSize = true;
            this.autoOpenFocusWindowCheckBox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoOpenFocusWindowCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoOpenFocusWindowCheckBox.Location = new System.Drawing.Point(6, 21);
            this.autoOpenFocusWindowCheckBox.Name = "autoOpenFocusWindowCheckBox";
            this.autoOpenFocusWindowCheckBox.Size = new System.Drawing.Size(87, 15);
            this.autoOpenFocusWindowCheckBox.TabIndex = 10020;
            this.autoOpenFocusWindowCheckBox.Text = "Auto-Open";
            this.autoOpenFocusWindowCheckBox.UseVisualStyleBackColor = true;
            // 
            // openFocusWindowButton
            // 
            this.openFocusWindowButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFocusWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openFocusWindowButton.Location = new System.Drawing.Point(135, 11);
            this.openFocusWindowButton.Name = "openFocusWindowButton";
            this.openFocusWindowButton.Size = new System.Drawing.Size(85, 28);
            this.openFocusWindowButton.TabIndex = 10014;
            this.openFocusWindowButton.Text = "Open";
            this.openFocusWindowButton.UseVisualStyleBackColor = true;
            // 
            // userInfoGroupBox
            // 
            this.userInfoGroupBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.userInfoGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block;
            this.userInfoGroupBox.Controls.Add(this.groupBox3);
            this.userInfoGroupBox.Controls.Add(this.groupBox1);
            this.userInfoGroupBox.Controls.Add(this.rssFeedFriendCheckBox);
            this.userInfoGroupBox.Controls.Add(this.rssFeedCheevoCheckBox);
            this.userInfoGroupBox.Controls.Add(this.rssFeedNewsCheckBox);
            this.userInfoGroupBox.Controls.Add(this.rssFeedForumCheckBox);
            this.userInfoGroupBox.Controls.Add(this.rssFeedListView);
            this.userInfoGroupBox.Controls.Add(this.apiKeyLabel);
            this.userInfoGroupBox.Controls.Add(this.userProfilePictureBox);
            this.userInfoGroupBox.Controls.Add(this.apiKeyTextBox);
            this.userInfoGroupBox.Controls.Add(this.usernameLabel);
            this.userInfoGroupBox.Controls.Add(this.usernameTextBox);
            this.userInfoGroupBox.Controls.Add(this.startButton);
            this.userInfoGroupBox.Controls.Add(this.autoStartCheckbox);
            this.userInfoGroupBox.Controls.Add(this.stopButton);
            this.userInfoGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoGroupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.userInfoGroupBox.Location = new System.Drawing.Point(6, 6);
            this.userInfoGroupBox.Name = "userInfoGroupBox";
            this.userInfoGroupBox.Size = new System.Drawing.Size(341, 453);
            this.userInfoGroupBox.TabIndex = 10026;
            this.userInfoGroupBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.focusAchievementPictureBox);
            this.groupBox3.Controls.Add(this.focusAchievementTitleLabel);
            this.groupBox3.Controls.Add(this.focusAchievementDescriptionLabel);
            this.groupBox3.Controls.Add(this.setFocusButton);
            this.groupBox3.Controls.Add(this.focusAchievementButtonLeft);
            this.groupBox3.Controls.Add(this.focusAchievementButtonRight);
            this.groupBox3.Location = new System.Drawing.Point(6, 292);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 155);
            this.groupBox3.TabIndex = 10014;
            this.groupBox3.TabStop = false;
            // 
            // focusAchievementPictureBox
            // 
            this.focusAchievementPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.focusAchievementPictureBox.InitialImage = null;
            this.focusAchievementPictureBox.Location = new System.Drawing.Point(3, 10);
            this.focusAchievementPictureBox.Name = "focusAchievementPictureBox";
            this.focusAchievementPictureBox.Size = new System.Drawing.Size(96, 96);
            this.focusAchievementPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.focusAchievementPictureBox.TabIndex = 21;
            this.focusAchievementPictureBox.TabStop = false;
            // 
            // focusAchievementTitleLabel
            // 
            this.focusAchievementTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.focusAchievementTitleLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusAchievementTitleLabel.Location = new System.Drawing.Point(105, 10);
            this.focusAchievementTitleLabel.Name = "focusAchievementTitleLabel";
            this.focusAchievementTitleLabel.Size = new System.Drawing.Size(217, 53);
            this.focusAchievementTitleLabel.TabIndex = 6;
            // 
            // focusAchievementDescriptionLabel
            // 
            this.focusAchievementDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.focusAchievementDescriptionLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementDescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusAchievementDescriptionLabel.Location = new System.Drawing.Point(105, 69);
            this.focusAchievementDescriptionLabel.Name = "focusAchievementDescriptionLabel";
            this.focusAchievementDescriptionLabel.Size = new System.Drawing.Size(217, 83);
            this.focusAchievementDescriptionLabel.TabIndex = 5;
            // 
            // setFocusButton
            // 
            this.setFocusButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.setFocusButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setFocusButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setFocusButton.Location = new System.Drawing.Point(3, 131);
            this.setFocusButton.Name = "setFocusButton";
            this.setFocusButton.Size = new System.Drawing.Size(96, 21);
            this.setFocusButton.TabIndex = 10001;
            this.setFocusButton.Text = "Set";
            this.setFocusButton.UseVisualStyleBackColor = false;
            // 
            // focusAchievementButtonLeft
            // 
            this.focusAchievementButtonLeft.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonLeft.Location = new System.Drawing.Point(3, 107);
            this.focusAchievementButtonLeft.Name = "focusAchievementButtonLeft";
            this.focusAchievementButtonLeft.Size = new System.Drawing.Size(42, 22);
            this.focusAchievementButtonLeft.TabIndex = 9;
            this.focusAchievementButtonLeft.Text = "<";
            this.focusAchievementButtonLeft.UseVisualStyleBackColor = true;
            // 
            // focusAchievementButtonRight
            // 
            this.focusAchievementButtonRight.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonRight.Location = new System.Drawing.Point(57, 107);
            this.focusAchievementButtonRight.Name = "focusAchievementButtonRight";
            this.focusAchievementButtonRight.Size = new System.Drawing.Size(42, 22);
            this.focusAchievementButtonRight.TabIndex = 10;
            this.focusAchievementButtonRight.Text = ">";
            this.focusAchievementButtonRight.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.gameInfoPictureBox);
            this.groupBox1.Controls.Add(this.gameInfoTitleLabel);
            this.groupBox1.Controls.Add(this.gameInfoProgressLabel);
            this.groupBox1.Location = new System.Drawing.Point(6, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 101);
            this.groupBox1.TabIndex = 10013;
            this.groupBox1.TabStop = false;
            // 
            // gameInfoPictureBox
            // 
            this.gameInfoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoPictureBox.InitialImage = null;
            this.gameInfoPictureBox.Location = new System.Drawing.Point(6, 12);
            this.gameInfoPictureBox.Name = "gameInfoPictureBox";
            this.gameInfoPictureBox.Size = new System.Drawing.Size(83, 83);
            this.gameInfoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameInfoPictureBox.TabIndex = 10004;
            this.gameInfoPictureBox.TabStop = false;
            // 
            // gameInfoTitleLabel
            // 
            this.gameInfoTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoTitleLabel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameInfoTitleLabel.Location = new System.Drawing.Point(95, 10);
            this.gameInfoTitleLabel.Name = "gameInfoTitleLabel";
            this.gameInfoTitleLabel.Size = new System.Drawing.Size(227, 56);
            this.gameInfoTitleLabel.TabIndex = 10007;
            this.gameInfoTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameInfoProgressLabel
            // 
            this.gameInfoProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoProgressLabel.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoProgressLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameInfoProgressLabel.Location = new System.Drawing.Point(97, 66);
            this.gameInfoProgressLabel.Name = "gameInfoProgressLabel";
            this.gameInfoProgressLabel.Size = new System.Drawing.Size(225, 26);
            this.gameInfoProgressLabel.TabIndex = 10008;
            this.gameInfoProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rssFeedFriendCheckBox
            // 
            this.rssFeedFriendCheckBox.AutoSize = true;
            this.rssFeedFriendCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedFriendCheckBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedFriendCheckBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rssFeedFriendCheckBox.Location = new System.Drawing.Point(252, 95);
            this.rssFeedFriendCheckBox.Name = "rssFeedFriendCheckBox";
            this.rssFeedFriendCheckBox.Size = new System.Drawing.Size(73, 15);
            this.rssFeedFriendCheckBox.TabIndex = 10010;
            this.rssFeedFriendCheckBox.Text = "FRIENDS";
            this.rssFeedFriendCheckBox.UseVisualStyleBackColor = false;
            // 
            // rssFeedCheevoCheckBox
            // 
            this.rssFeedCheevoCheckBox.AutoSize = true;
            this.rssFeedCheevoCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedCheevoCheckBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedCheevoCheckBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rssFeedCheevoCheckBox.Location = new System.Drawing.Point(158, 95);
            this.rssFeedCheevoCheckBox.Name = "rssFeedCheevoCheckBox";
            this.rssFeedCheevoCheckBox.Size = new System.Drawing.Size(66, 15);
            this.rssFeedCheevoCheckBox.TabIndex = 10011;
            this.rssFeedCheevoCheckBox.Text = "CHEEVO";
            this.rssFeedCheevoCheckBox.UseVisualStyleBackColor = false;
            // 
            // rssFeedNewsCheckBox
            // 
            this.rssFeedNewsCheckBox.AutoSize = true;
            this.rssFeedNewsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedNewsCheckBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedNewsCheckBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rssFeedNewsCheckBox.Location = new System.Drawing.Point(6, 95);
            this.rssFeedNewsCheckBox.Name = "rssFeedNewsCheckBox";
            this.rssFeedNewsCheckBox.Size = new System.Drawing.Size(52, 15);
            this.rssFeedNewsCheckBox.TabIndex = 10012;
            this.rssFeedNewsCheckBox.Text = "NEWS";
            this.rssFeedNewsCheckBox.UseVisualStyleBackColor = false;
            // 
            // rssFeedForumCheckBox
            // 
            this.rssFeedForumCheckBox.AutoSize = true;
            this.rssFeedForumCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedForumCheckBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedForumCheckBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rssFeedForumCheckBox.Location = new System.Drawing.Point(76, 95);
            this.rssFeedForumCheckBox.Name = "rssFeedForumCheckBox";
            this.rssFeedForumCheckBox.Size = new System.Drawing.Size(59, 15);
            this.rssFeedForumCheckBox.TabIndex = 10009;
            this.rssFeedForumCheckBox.Text = "FORUM";
            this.rssFeedForumCheckBox.UseVisualStyleBackColor = false;
            // 
            // rssFeedListView
            // 
            this.rssFeedListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.rssFeedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.rssFeedListView.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.rssFeedListView.HideSelection = false;
            this.rssFeedListView.Location = new System.Drawing.Point(6, 110);
            this.rssFeedListView.Name = "rssFeedListView";
            this.rssFeedListView.Size = new System.Drawing.Size(328, 80);
            this.rssFeedListView.TabIndex = 10006;
            this.rssFeedListView.UseCompatibleStateImageBehavior = false;
            this.rssFeedListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 400;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(259, 37);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 21);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block;
            this.groupBox2.Controls.Add(this.raConnectionStatusPictureBox);
            this.groupBox2.Controls.Add(this.timerStatusLabel);
            this.groupBox2.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(353, 414);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 45);
            this.groupBox2.TabIndex = 10027;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // raConnectionStatusPictureBox
            // 
            this.raConnectionStatusPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.raConnectionStatusPictureBox.Image = global::Retro_Achievement_Tracker.Properties.Resources.red_button;
            this.raConnectionStatusPictureBox.Location = new System.Drawing.Point(281, 11);
            this.raConnectionStatusPictureBox.Name = "raConnectionStatusPictureBox";
            this.raConnectionStatusPictureBox.Size = new System.Drawing.Size(28, 28);
            this.raConnectionStatusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.raConnectionStatusPictureBox.TabIndex = 10025;
            this.raConnectionStatusPictureBox.TabStop = false;
            // 
            // notificationsGroupBox
            // 
            this.notificationsGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.notificationsGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block;
            this.notificationsGroupBox.Controls.Add(this.customizeAlertsButton);
            this.notificationsGroupBox.Controls.Add(this.autoOpenAlertsWindowCheckbox);
            this.notificationsGroupBox.Controls.Add(this.openNotificationWindowButton);
            this.notificationsGroupBox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.notificationsGroupBox.Location = new System.Drawing.Point(353, 57);
            this.notificationsGroupBox.Name = "notificationsGroupBox";
            this.notificationsGroupBox.Size = new System.Drawing.Size(315, 45);
            this.notificationsGroupBox.TabIndex = 10006;
            this.notificationsGroupBox.TabStop = false;
            this.notificationsGroupBox.Text = "Cheevo Alerts";
            // 
            // customizeAlertsButton
            // 
            this.customizeAlertsButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeAlertsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeAlertsButton.Location = new System.Drawing.Point(226, 11);
            this.customizeAlertsButton.Name = "customizeAlertsButton";
            this.customizeAlertsButton.Size = new System.Drawing.Size(85, 28);
            this.customizeAlertsButton.TabIndex = 10025;
            this.customizeAlertsButton.Text = "Custom";
            this.customizeAlertsButton.UseVisualStyleBackColor = true;
            // 
            // autoOpenAlertsWindowCheckbox
            // 
            this.autoOpenAlertsWindowCheckbox.AutoSize = true;
            this.autoOpenAlertsWindowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.autoOpenAlertsWindowCheckbox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoOpenAlertsWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoOpenAlertsWindowCheckbox.Location = new System.Drawing.Point(6, 21);
            this.autoOpenAlertsWindowCheckbox.Name = "autoOpenAlertsWindowCheckbox";
            this.autoOpenAlertsWindowCheckbox.Size = new System.Drawing.Size(87, 15);
            this.autoOpenAlertsWindowCheckbox.TabIndex = 10022;
            this.autoOpenAlertsWindowCheckbox.Text = "Auto-Open";
            this.autoOpenAlertsWindowCheckbox.UseVisualStyleBackColor = false;
            // 
            // openNotificationWindowButton
            // 
            this.openNotificationWindowButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openNotificationWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openNotificationWindowButton.Location = new System.Drawing.Point(135, 11);
            this.openNotificationWindowButton.Name = "openNotificationWindowButton";
            this.openNotificationWindowButton.Size = new System.Drawing.Size(85, 28);
            this.openNotificationWindowButton.TabIndex = 10021;
            this.openNotificationWindowButton.Text = "Open";
            this.openNotificationWindowButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoGroupBox
            // 
            this.gameInfoGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.gameInfoGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block;
            this.gameInfoGroupBox.Controls.Add(this.customizeGameInfoButton);
            this.gameInfoGroupBox.Controls.Add(this.autoOpenGameInfoWindowCheckbox);
            this.gameInfoGroupBox.Controls.Add(this.openGameInfoWindowButton);
            this.gameInfoGroupBox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameInfoGroupBox.Location = new System.Drawing.Point(353, 261);
            this.gameInfoGroupBox.Name = "gameInfoGroupBox";
            this.gameInfoGroupBox.Size = new System.Drawing.Size(315, 45);
            this.gameInfoGroupBox.TabIndex = 10025;
            this.gameInfoGroupBox.TabStop = false;
            this.gameInfoGroupBox.Text = "Game Info";
            // 
            // customizeGameInfoButton
            // 
            this.customizeGameInfoButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeGameInfoButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeGameInfoButton.Location = new System.Drawing.Point(226, 10);
            this.customizeGameInfoButton.Name = "customizeGameInfoButton";
            this.customizeGameInfoButton.Size = new System.Drawing.Size(85, 28);
            this.customizeGameInfoButton.TabIndex = 10024;
            this.customizeGameInfoButton.Text = "Custom";
            this.customizeGameInfoButton.UseVisualStyleBackColor = true;
            // 
            // autoOpenGameInfoWindowCheckbox
            // 
            this.autoOpenGameInfoWindowCheckbox.AutoSize = true;
            this.autoOpenGameInfoWindowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.autoOpenGameInfoWindowCheckbox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoOpenGameInfoWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoOpenGameInfoWindowCheckbox.Location = new System.Drawing.Point(6, 18);
            this.autoOpenGameInfoWindowCheckbox.Name = "autoOpenGameInfoWindowCheckbox";
            this.autoOpenGameInfoWindowCheckbox.Size = new System.Drawing.Size(87, 15);
            this.autoOpenGameInfoWindowCheckbox.TabIndex = 10022;
            this.autoOpenGameInfoWindowCheckbox.Text = "Auto-Open";
            this.autoOpenGameInfoWindowCheckbox.UseVisualStyleBackColor = false;
            // 
            // openGameInfoWindowButton
            // 
            this.openGameInfoWindowButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openGameInfoWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openGameInfoWindowButton.Location = new System.Drawing.Point(135, 10);
            this.openGameInfoWindowButton.Name = "openGameInfoWindowButton";
            this.openGameInfoWindowButton.Size = new System.Drawing.Size(85, 28);
            this.openGameInfoWindowButton.TabIndex = 10021;
            this.openGameInfoWindowButton.Text = "Open";
            this.openGameInfoWindowButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsGroupBox
            // 
            this.recentAchievementsGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.recentAchievementsGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block;
            this.recentAchievementsGroupBox.Controls.Add(this.customizeLastFiveButton);
            this.recentAchievementsGroupBox.Controls.Add(this.autoOpenLastFiveWindowCheckbox);
            this.recentAchievementsGroupBox.Controls.Add(this.openLastFiveWindowButton);
            this.recentAchievementsGroupBox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.recentAchievementsGroupBox.Location = new System.Drawing.Point(353, 108);
            this.recentAchievementsGroupBox.Name = "recentAchievementsGroupBox";
            this.recentAchievementsGroupBox.Size = new System.Drawing.Size(315, 45);
            this.recentAchievementsGroupBox.TabIndex = 10026;
            this.recentAchievementsGroupBox.TabStop = false;
            this.recentAchievementsGroupBox.Text = "Recent Cheevos";
            // 
            // customizeLastFiveButton
            // 
            this.customizeLastFiveButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeLastFiveButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeLastFiveButton.Location = new System.Drawing.Point(226, 11);
            this.customizeLastFiveButton.Name = "customizeLastFiveButton";
            this.customizeLastFiveButton.Size = new System.Drawing.Size(85, 29);
            this.customizeLastFiveButton.TabIndex = 10024;
            this.customizeLastFiveButton.Text = "Custom";
            this.customizeLastFiveButton.UseVisualStyleBackColor = true;
            // 
            // autoOpenLastFiveWindowCheckbox
            // 
            this.autoOpenLastFiveWindowCheckbox.AutoSize = true;
            this.autoOpenLastFiveWindowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.autoOpenLastFiveWindowCheckbox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoOpenLastFiveWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoOpenLastFiveWindowCheckbox.Location = new System.Drawing.Point(6, 21);
            this.autoOpenLastFiveWindowCheckbox.Name = "autoOpenLastFiveWindowCheckbox";
            this.autoOpenLastFiveWindowCheckbox.Size = new System.Drawing.Size(87, 15);
            this.autoOpenLastFiveWindowCheckbox.TabIndex = 10022;
            this.autoOpenLastFiveWindowCheckbox.Text = "Auto-Open";
            this.autoOpenLastFiveWindowCheckbox.UseVisualStyleBackColor = false;
            // 
            // openLastFiveWindowButton
            // 
            this.openLastFiveWindowButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openLastFiveWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openLastFiveWindowButton.Location = new System.Drawing.Point(135, 11);
            this.openLastFiveWindowButton.Name = "openLastFiveWindowButton";
            this.openLastFiveWindowButton.Size = new System.Drawing.Size(85, 28);
            this.openLastFiveWindowButton.TabIndex = 10021;
            this.openLastFiveWindowButton.Text = "Open";
            this.openLastFiveWindowButton.UseVisualStyleBackColor = true;
            // 
            // statsGameRatioOverrideTextBox
            // 
            this.statsGameRatioOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGameRatioOverrideTextBox.Location = new System.Drawing.Point(27, 95);
            this.statsGameRatioOverrideTextBox.Name = "statsGameRatioOverrideTextBox";
            this.statsGameRatioOverrideTextBox.Size = new System.Drawing.Size(160, 18);
            this.statsGameRatioOverrideTextBox.TabIndex = 8;
            this.statsGameRatioOverrideTextBox.Text = "Ratio";
            // 
            // statsTruePointsOverrideTextBox
            // 
            this.statsTruePointsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsTruePointsOverrideTextBox.Location = new System.Drawing.Point(27, 75);
            this.statsTruePointsOverrideTextBox.Name = "statsTruePointsOverrideTextBox";
            this.statsTruePointsOverrideTextBox.Size = new System.Drawing.Size(157, 18);
            this.statsTruePointsOverrideTextBox.TabIndex = 7;
            this.statsTruePointsOverrideTextBox.Text = "T. Points";
            // 
            // statsPointsOverrideTextBox
            // 
            this.statsPointsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsPointsOverrideTextBox.Location = new System.Drawing.Point(27, 55);
            this.statsPointsOverrideTextBox.Name = "statsPointsOverrideTextBox";
            this.statsPointsOverrideTextBox.Size = new System.Drawing.Size(157, 18);
            this.statsPointsOverrideTextBox.TabIndex = 6;
            this.statsPointsOverrideTextBox.Text = "Points";
            // 
            // statsRatioOverrideTextBox
            // 
            this.statsRatioOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsRatioOverrideTextBox.Location = new System.Drawing.Point(27, 95);
            this.statsRatioOverrideTextBox.Name = "statsRatioOverrideTextBox";
            this.statsRatioOverrideTextBox.Size = new System.Drawing.Size(157, 18);
            this.statsRatioOverrideTextBox.TabIndex = 5;
            this.statsRatioOverrideTextBox.Text = "Ratio";
            // 
            // statsAwardsOverrideTextBox
            // 
            this.statsAwardsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsAwardsOverrideTextBox.Location = new System.Drawing.Point(27, 35);
            this.statsAwardsOverrideTextBox.Name = "statsAwardsOverrideTextBox";
            this.statsAwardsOverrideTextBox.Size = new System.Drawing.Size(157, 18);
            this.statsAwardsOverrideTextBox.TabIndex = 3;
            this.statsAwardsOverrideTextBox.Text = "Awards";
            // 
            // statsRankOverrideTextBox
            // 
            this.statsRankOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsRankOverrideTextBox.Location = new System.Drawing.Point(27, 15);
            this.statsRankOverrideTextBox.Name = "statsRankOverrideTextBox";
            this.statsRankOverrideTextBox.Size = new System.Drawing.Size(157, 18);
            this.statsRankOverrideTextBox.TabIndex = 1;
            this.statsRankOverrideTextBox.Text = "Rank";
            // 
            // userStatsCustomizationGroupBox
            // 
            this.userStatsCustomizationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.userStatsCustomizationGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block5;
            this.userStatsCustomizationGroupBox.Controls.Add(this.truePointsEnableCheckBox);
            this.userStatsCustomizationGroupBox.Controls.Add(this.ratioEnableCheckBox);
            this.userStatsCustomizationGroupBox.Controls.Add(this.statsRankOverrideTextBox);
            this.userStatsCustomizationGroupBox.Controls.Add(this.pointsEnableCheckBox);
            this.userStatsCustomizationGroupBox.Controls.Add(this.statsAwardsOverrideTextBox);
            this.userStatsCustomizationGroupBox.Controls.Add(this.awardsEnableCheckBox);
            this.userStatsCustomizationGroupBox.Controls.Add(this.statsPointsOverrideTextBox);
            this.userStatsCustomizationGroupBox.Controls.Add(this.userStatsDefaultButton);
            this.userStatsCustomizationGroupBox.Controls.Add(this.rankEnableCheckBox);
            this.userStatsCustomizationGroupBox.Controls.Add(this.statsTruePointsOverrideTextBox);
            this.userStatsCustomizationGroupBox.Controls.Add(this.statsRatioOverrideTextBox);
            this.userStatsCustomizationGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userStatsCustomizationGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userStatsCustomizationGroupBox.Location = new System.Drawing.Point(367, 333);
            this.userStatsCustomizationGroupBox.Name = "userStatsCustomizationGroupBox";
            this.userStatsCustomizationGroupBox.Size = new System.Drawing.Size(195, 149);
            this.userStatsCustomizationGroupBox.TabIndex = 10007;
            this.userStatsCustomizationGroupBox.TabStop = false;
            this.userStatsCustomizationGroupBox.Text = "Label Text";
            // 
            // truePointsEnableCheckBox
            // 
            this.truePointsEnableCheckBox.AutoSize = true;
            this.truePointsEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truePointsEnableCheckBox.Location = new System.Drawing.Point(6, 80);
            this.truePointsEnableCheckBox.Name = "truePointsEnableCheckBox";
            this.truePointsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.truePointsEnableCheckBox.TabIndex = 56;
            this.truePointsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // ratioEnableCheckBox
            // 
            this.ratioEnableCheckBox.AutoSize = true;
            this.ratioEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ratioEnableCheckBox.Location = new System.Drawing.Point(6, 100);
            this.ratioEnableCheckBox.Name = "ratioEnableCheckBox";
            this.ratioEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ratioEnableCheckBox.TabIndex = 55;
            this.ratioEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // pointsEnableCheckBox
            // 
            this.pointsEnableCheckBox.AutoSize = true;
            this.pointsEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsEnableCheckBox.Location = new System.Drawing.Point(6, 60);
            this.pointsEnableCheckBox.Name = "pointsEnableCheckBox";
            this.pointsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.pointsEnableCheckBox.TabIndex = 54;
            this.pointsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // awardsEnableCheckBox
            // 
            this.awardsEnableCheckBox.AutoSize = true;
            this.awardsEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.awardsEnableCheckBox.Location = new System.Drawing.Point(6, 40);
            this.awardsEnableCheckBox.Name = "awardsEnableCheckBox";
            this.awardsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.awardsEnableCheckBox.TabIndex = 53;
            this.awardsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // userStatsDefaultButton
            // 
            this.userStatsDefaultButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userStatsDefaultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userStatsDefaultButton.Location = new System.Drawing.Point(112, 121);
            this.userStatsDefaultButton.Name = "userStatsDefaultButton";
            this.userStatsDefaultButton.Size = new System.Drawing.Size(72, 23);
            this.userStatsDefaultButton.TabIndex = 39;
            this.userStatsDefaultButton.Text = "Default";
            this.userStatsDefaultButton.UseVisualStyleBackColor = true;
            // 
            // rankEnableCheckBox
            // 
            this.rankEnableCheckBox.AutoSize = true;
            this.rankEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rankEnableCheckBox.Location = new System.Drawing.Point(6, 20);
            this.rankEnableCheckBox.Name = "rankEnableCheckBox";
            this.rankEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.rankEnableCheckBox.TabIndex = 52;
            this.rankEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.Transparent;
            this.groupBox17.Controls.Add(this.statsRadioButtonBackslash);
            this.groupBox17.Controls.Add(this.statsRadioButtonSemicolon);
            this.groupBox17.Controls.Add(this.statsRadioButtonDot);
            this.groupBox17.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox17.Location = new System.Drawing.Point(4, 152);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(185, 67);
            this.groupBox17.TabIndex = 57;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Special Characters";
            // 
            // statsRadioButtonBackslash
            // 
            this.statsRadioButtonBackslash.AutoSize = true;
            this.statsRadioButtonBackslash.Location = new System.Drawing.Point(6, 14);
            this.statsRadioButtonBackslash.Name = "statsRadioButtonBackslash";
            this.statsRadioButtonBackslash.Size = new System.Drawing.Size(114, 15);
            this.statsRadioButtonBackslash.TabIndex = 50;
            this.statsRadioButtonBackslash.TabStop = true;
            this.statsRadioButtonBackslash.Text = "[/] Backslash";
            this.statsRadioButtonBackslash.UseVisualStyleBackColor = true;
            // 
            // statsRadioButtonSemicolon
            // 
            this.statsRadioButtonSemicolon.AutoSize = true;
            this.statsRadioButtonSemicolon.Location = new System.Drawing.Point(6, 30);
            this.statsRadioButtonSemicolon.Name = "statsRadioButtonSemicolon";
            this.statsRadioButtonSemicolon.Size = new System.Drawing.Size(86, 15);
            this.statsRadioButtonSemicolon.TabIndex = 53;
            this.statsRadioButtonSemicolon.TabStop = true;
            this.statsRadioButtonSemicolon.Text = "[:] Colon";
            this.statsRadioButtonSemicolon.UseVisualStyleBackColor = true;
            // 
            // statsRadioButtonDot
            // 
            this.statsRadioButtonDot.AutoSize = true;
            this.statsRadioButtonDot.Location = new System.Drawing.Point(6, 46);
            this.statsRadioButtonDot.Name = "statsRadioButtonDot";
            this.statsRadioButtonDot.Size = new System.Drawing.Size(121, 15);
            this.statsRadioButtonDot.TabIndex = 52;
            this.statsRadioButtonDot.TabStop = true;
            this.statsRadioButtonDot.Text = "[.] Period/Dot";
            this.statsRadioButtonDot.UseVisualStyleBackColor = true;
            // 
            // gameRatioEnableCheckBox
            // 
            this.gameRatioEnableCheckBox.AutoSize = true;
            this.gameRatioEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameRatioEnableCheckBox.Location = new System.Drawing.Point(6, 100);
            this.gameRatioEnableCheckBox.Name = "gameRatioEnableCheckBox";
            this.gameRatioEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameRatioEnableCheckBox.TabIndex = 61;
            this.gameRatioEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameTruePointsEnableCheckBox
            // 
            this.gameTruePointsEnableCheckBox.AutoSize = true;
            this.gameTruePointsEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameTruePointsEnableCheckBox.Location = new System.Drawing.Point(6, 60);
            this.gameTruePointsEnableCheckBox.Name = "gameTruePointsEnableCheckBox";
            this.gameTruePointsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameTruePointsEnableCheckBox.TabIndex = 60;
            this.gameTruePointsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // gamePointsEnableCheckBox
            // 
            this.gamePointsEnableCheckBox.AutoSize = true;
            this.gamePointsEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamePointsEnableCheckBox.Location = new System.Drawing.Point(6, 40);
            this.gamePointsEnableCheckBox.Name = "gamePointsEnableCheckBox";
            this.gamePointsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gamePointsEnableCheckBox.TabIndex = 59;
            this.gamePointsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // completedEnableCheckBox
            // 
            this.completedEnableCheckBox.AutoSize = true;
            this.completedEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completedEnableCheckBox.Location = new System.Drawing.Point(6, 80);
            this.completedEnableCheckBox.Name = "completedEnableCheckBox";
            this.completedEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.completedEnableCheckBox.TabIndex = 58;
            this.completedEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameAchievementsEnableCheckBox
            // 
            this.gameAchievementsEnableCheckBox.AutoSize = true;
            this.gameAchievementsEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameAchievementsEnableCheckBox.Location = new System.Drawing.Point(6, 20);
            this.gameAchievementsEnableCheckBox.Name = "gameAchievementsEnableCheckBox";
            this.gameAchievementsEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameAchievementsEnableCheckBox.TabIndex = 57;
            this.gameAchievementsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameStatsDefaultButton
            // 
            this.gameStatsDefaultButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameStatsDefaultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameStatsDefaultButton.Location = new System.Drawing.Point(112, 123);
            this.gameStatsDefaultButton.Name = "gameStatsDefaultButton";
            this.gameStatsDefaultButton.Size = new System.Drawing.Size(72, 23);
            this.gameStatsDefaultButton.TabIndex = 44;
            this.gameStatsDefaultButton.Text = "Default";
            this.gameStatsDefaultButton.UseVisualStyleBackColor = true;
            // 
            // statsGameAchievementsOverrideTextBox
            // 
            this.statsGameAchievementsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGameAchievementsOverrideTextBox.Location = new System.Drawing.Point(27, 15);
            this.statsGameAchievementsOverrideTextBox.Name = "statsGameAchievementsOverrideTextBox";
            this.statsGameAchievementsOverrideTextBox.Size = new System.Drawing.Size(160, 18);
            this.statsGameAchievementsOverrideTextBox.TabIndex = 13;
            this.statsGameAchievementsOverrideTextBox.Text = "Cheevos";
            // 
            // statsGamePointsOverrideTextBox
            // 
            this.statsGamePointsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGamePointsOverrideTextBox.Location = new System.Drawing.Point(27, 35);
            this.statsGamePointsOverrideTextBox.Name = "statsGamePointsOverrideTextBox";
            this.statsGamePointsOverrideTextBox.Size = new System.Drawing.Size(160, 18);
            this.statsGamePointsOverrideTextBox.TabIndex = 15;
            this.statsGamePointsOverrideTextBox.Text = "Points";
            // 
            // statsGameTruePointsOverrideTextBox
            // 
            this.statsGameTruePointsOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGameTruePointsOverrideTextBox.Location = new System.Drawing.Point(27, 55);
            this.statsGameTruePointsOverrideTextBox.Name = "statsGameTruePointsOverrideTextBox";
            this.statsGameTruePointsOverrideTextBox.Size = new System.Drawing.Size(160, 18);
            this.statsGameTruePointsOverrideTextBox.TabIndex = 16;
            this.statsGameTruePointsOverrideTextBox.Text = "T. Points";
            // 
            // statsCompletedOverrideTextBox
            // 
            this.statsCompletedOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsCompletedOverrideTextBox.Location = new System.Drawing.Point(27, 75);
            this.statsCompletedOverrideTextBox.Name = "statsCompletedOverrideTextBox";
            this.statsCompletedOverrideTextBox.Size = new System.Drawing.Size(160, 18);
            this.statsCompletedOverrideTextBox.TabIndex = 48;
            this.statsCompletedOverrideTextBox.Text = "Completed";
            // 
            // gameInfoCustomizationGroupBox
            // 
            this.gameInfoCustomizationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoCustomizationGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block5;
            this.gameInfoCustomizationGroupBox.Controls.Add(this.releasedDateEnableCheckBox);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.consoleEnableCheckBox);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.publisherEnableCheckBox);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.genreEnableCheckBox);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.developerEnableCheckBox);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.titleEnableCheckBox);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.gameInfoTitleOverrideTextBox);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.gameInfoDefaultButton);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.gameInfoGenreOverrideTextBox);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.gameInfoConsoleOverrideTextBox);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.gameInfoPublisherOverrideTextBox);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.gameInfoReleaseDateOverrideTextBox);
            this.gameInfoCustomizationGroupBox.Controls.Add(this.gameInfoDeveloperOverrideTextBox);
            this.gameInfoCustomizationGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoCustomizationGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameInfoCustomizationGroupBox.Location = new System.Drawing.Point(523, 263);
            this.gameInfoCustomizationGroupBox.Name = "gameInfoCustomizationGroupBox";
            this.gameInfoCustomizationGroupBox.Size = new System.Drawing.Size(195, 169);
            this.gameInfoCustomizationGroupBox.TabIndex = 10008;
            this.gameInfoCustomizationGroupBox.TabStop = false;
            this.gameInfoCustomizationGroupBox.Text = "Label Text";
            // 
            // releasedDateEnableCheckBox
            // 
            this.releasedDateEnableCheckBox.AutoSize = true;
            this.releasedDateEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releasedDateEnableCheckBox.Location = new System.Drawing.Point(6, 120);
            this.releasedDateEnableCheckBox.Name = "releasedDateEnableCheckBox";
            this.releasedDateEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.releasedDateEnableCheckBox.TabIndex = 62;
            this.releasedDateEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // consoleEnableCheckBox
            // 
            this.consoleEnableCheckBox.AutoSize = true;
            this.consoleEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleEnableCheckBox.Location = new System.Drawing.Point(6, 100);
            this.consoleEnableCheckBox.Name = "consoleEnableCheckBox";
            this.consoleEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.consoleEnableCheckBox.TabIndex = 61;
            this.consoleEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // publisherEnableCheckBox
            // 
            this.publisherEnableCheckBox.AutoSize = true;
            this.publisherEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.publisherEnableCheckBox.Location = new System.Drawing.Point(6, 60);
            this.publisherEnableCheckBox.Name = "publisherEnableCheckBox";
            this.publisherEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.publisherEnableCheckBox.TabIndex = 60;
            this.publisherEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // genreEnableCheckBox
            // 
            this.genreEnableCheckBox.AutoSize = true;
            this.genreEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genreEnableCheckBox.Location = new System.Drawing.Point(6, 80);
            this.genreEnableCheckBox.Name = "genreEnableCheckBox";
            this.genreEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.genreEnableCheckBox.TabIndex = 59;
            this.genreEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // developerEnableCheckBox
            // 
            this.developerEnableCheckBox.AutoSize = true;
            this.developerEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developerEnableCheckBox.Location = new System.Drawing.Point(6, 40);
            this.developerEnableCheckBox.Name = "developerEnableCheckBox";
            this.developerEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.developerEnableCheckBox.TabIndex = 58;
            this.developerEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // titleEnableCheckBox
            // 
            this.titleEnableCheckBox.AutoSize = true;
            this.titleEnableCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleEnableCheckBox.Location = new System.Drawing.Point(6, 20);
            this.titleEnableCheckBox.Name = "titleEnableCheckBox";
            this.titleEnableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.titleEnableCheckBox.TabIndex = 57;
            this.titleEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameInfoTitleOverrideTextBox
            // 
            this.gameInfoTitleOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoTitleOverrideTextBox.Location = new System.Drawing.Point(27, 15);
            this.gameInfoTitleOverrideTextBox.Name = "gameInfoTitleOverrideTextBox";
            this.gameInfoTitleOverrideTextBox.Size = new System.Drawing.Size(160, 18);
            this.gameInfoTitleOverrideTextBox.TabIndex = 53;
            this.gameInfoTitleOverrideTextBox.Text = "Title";
            // 
            // gameInfoDefaultButton
            // 
            this.gameInfoDefaultButton.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDefaultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameInfoDefaultButton.Location = new System.Drawing.Point(115, 141);
            this.gameInfoDefaultButton.Name = "gameInfoDefaultButton";
            this.gameInfoDefaultButton.Size = new System.Drawing.Size(72, 23);
            this.gameInfoDefaultButton.TabIndex = 40;
            this.gameInfoDefaultButton.Text = "Default";
            this.gameInfoDefaultButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoGenreOverrideTextBox
            // 
            this.gameInfoGenreOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoGenreOverrideTextBox.Location = new System.Drawing.Point(27, 75);
            this.gameInfoGenreOverrideTextBox.Name = "gameInfoGenreOverrideTextBox";
            this.gameInfoGenreOverrideTextBox.Size = new System.Drawing.Size(160, 18);
            this.gameInfoGenreOverrideTextBox.TabIndex = 25;
            this.gameInfoGenreOverrideTextBox.Text = "Genre";
            // 
            // gameInfoConsoleOverrideTextBox
            // 
            this.gameInfoConsoleOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoConsoleOverrideTextBox.Location = new System.Drawing.Point(27, 95);
            this.gameInfoConsoleOverrideTextBox.Name = "gameInfoConsoleOverrideTextBox";
            this.gameInfoConsoleOverrideTextBox.Size = new System.Drawing.Size(160, 18);
            this.gameInfoConsoleOverrideTextBox.TabIndex = 19;
            this.gameInfoConsoleOverrideTextBox.Text = "Console";
            // 
            // gameInfoPublisherOverrideTextBox
            // 
            this.gameInfoPublisherOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoPublisherOverrideTextBox.Location = new System.Drawing.Point(27, 55);
            this.gameInfoPublisherOverrideTextBox.Name = "gameInfoPublisherOverrideTextBox";
            this.gameInfoPublisherOverrideTextBox.Size = new System.Drawing.Size(160, 18);
            this.gameInfoPublisherOverrideTextBox.TabIndex = 24;
            this.gameInfoPublisherOverrideTextBox.Text = "Publisher";
            // 
            // gameInfoReleaseDateOverrideTextBox
            // 
            this.gameInfoReleaseDateOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoReleaseDateOverrideTextBox.Location = new System.Drawing.Point(27, 115);
            this.gameInfoReleaseDateOverrideTextBox.Name = "gameInfoReleaseDateOverrideTextBox";
            this.gameInfoReleaseDateOverrideTextBox.Size = new System.Drawing.Size(160, 18);
            this.gameInfoReleaseDateOverrideTextBox.TabIndex = 23;
            this.gameInfoReleaseDateOverrideTextBox.Text = "Released";
            // 
            // gameInfoDeveloperOverrideTextBox
            // 
            this.gameInfoDeveloperOverrideTextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDeveloperOverrideTextBox.Location = new System.Drawing.Point(27, 35);
            this.gameInfoDeveloperOverrideTextBox.Name = "gameInfoDeveloperOverrideTextBox";
            this.gameInfoDeveloperOverrideTextBox.Size = new System.Drawing.Size(160, 18);
            this.gameInfoDeveloperOverrideTextBox.TabIndex = 21;
            this.gameInfoDeveloperOverrideTextBox.Text = "Developer";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fontBorderCheckBox
            // 
            this.fontBorderCheckBox.AutoSize = true;
            this.fontBorderCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.fontBorderCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontBorderCheckBox.Location = new System.Drawing.Point(8, 74);
            this.fontBorderCheckBox.Name = "fontBorderCheckBox";
            this.fontBorderCheckBox.Size = new System.Drawing.Size(15, 14);
            this.fontBorderCheckBox.TabIndex = 41;
            this.fontBorderCheckBox.UseVisualStyleBackColor = false;
            // 
            // windowBackgroundGroupBox
            // 
            this.windowBackgroundGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.windowBackgroundGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block5;
            this.windowBackgroundGroupBox.Controls.Add(this.windowBackgroundColorButton);
            this.windowBackgroundGroupBox.Controls.Add(this.windowBackgroundColorPictureBox);
            this.windowBackgroundGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowBackgroundGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.windowBackgroundGroupBox.Location = new System.Drawing.Point(6, 11);
            this.windowBackgroundGroupBox.Name = "windowBackgroundGroupBox";
            this.windowBackgroundGroupBox.Size = new System.Drawing.Size(67, 38);
            this.windowBackgroundGroupBox.TabIndex = 50;
            this.windowBackgroundGroupBox.TabStop = false;
            this.windowBackgroundGroupBox.Text = "Back";
            // 
            // windowBackgroundColorButton
            // 
            this.windowBackgroundColorButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowBackgroundColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.windowBackgroundColorButton.Location = new System.Drawing.Point(2, 10);
            this.windowBackgroundColorButton.Name = "windowBackgroundColorButton";
            this.windowBackgroundColorButton.Size = new System.Drawing.Size(36, 23);
            this.windowBackgroundColorButton.TabIndex = 43;
            this.windowBackgroundColorButton.Text = "Set";
            this.windowBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // windowBackgroundColorPictureBox
            // 
            this.windowBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.windowBackgroundColorPictureBox.Location = new System.Drawing.Point(40, 10);
            this.windowBackgroundColorPictureBox.Name = "windowBackgroundColorPictureBox";
            this.windowBackgroundColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.windowBackgroundColorPictureBox.TabIndex = 42;
            this.windowBackgroundColorPictureBox.TabStop = false;
            // 
            // fontBorderLabel
            // 
            this.fontBorderLabel.AutoSize = true;
            this.fontBorderLabel.BackColor = System.Drawing.Color.Transparent;
            this.fontBorderLabel.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontBorderLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fontBorderLabel.Location = new System.Drawing.Point(28, 76);
            this.fontBorderLabel.Name = "fontBorderLabel";
            this.fontBorderLabel.Size = new System.Drawing.Size(47, 11);
            this.fontBorderLabel.TabIndex = 51;
            this.fontBorderLabel.Text = "Border";
            // 
            // borderBackgroundGroupBox
            // 
            this.borderBackgroundGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.borderBackgroundGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block5;
            this.borderBackgroundGroupBox.Controls.Add(this.borderBackgroundColorButton);
            this.borderBackgroundGroupBox.Controls.Add(this.borderBackgroudColorPictureBox);
            this.borderBackgroundGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderBackgroundGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.borderBackgroundGroupBox.Location = new System.Drawing.Point(79, 11);
            this.borderBackgroundGroupBox.Name = "borderBackgroundGroupBox";
            this.borderBackgroundGroupBox.Size = new System.Drawing.Size(67, 38);
            this.borderBackgroundGroupBox.TabIndex = 50;
            this.borderBackgroundGroupBox.TabStop = false;
            this.borderBackgroundGroupBox.Text = "Border";
            // 
            // borderBackgroundColorButton
            // 
            this.borderBackgroundColorButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderBackgroundColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.borderBackgroundColorButton.Location = new System.Drawing.Point(2, 10);
            this.borderBackgroundColorButton.Name = "borderBackgroundColorButton";
            this.borderBackgroundColorButton.Size = new System.Drawing.Size(36, 23);
            this.borderBackgroundColorButton.TabIndex = 43;
            this.borderBackgroundColorButton.Text = "Set";
            this.borderBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // borderBackgroudColorPictureBox
            // 
            this.borderBackgroudColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.borderBackgroudColorPictureBox.Location = new System.Drawing.Point(40, 10);
            this.borderBackgroudColorPictureBox.Name = "borderBackgroudColorPictureBox";
            this.borderBackgroudColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.borderBackgroudColorPictureBox.TabIndex = 42;
            this.borderBackgroudColorPictureBox.TabStop = false;
            // 
            // pointsFontGroupBox
            // 
            this.pointsFontGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.pointsFontGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block5;
            this.pointsFontGroupBox.Controls.Add(this.label4);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontOutlineColorButton);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontOutlineColorPictureBox);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontColorButton);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontOutlineCheckbox);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontOutlineNumericUpDown);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontColorPictureBox);
            this.pointsFontGroupBox.Controls.Add(this.pointsFontFamilyComboBox);
            this.pointsFontGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsFontGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pointsFontGroupBox.Location = new System.Drawing.Point(6, 293);
            this.pointsFontGroupBox.Name = "pointsFontGroupBox";
            this.pointsFontGroupBox.Size = new System.Drawing.Size(152, 85);
            this.pointsFontGroupBox.TabIndex = 48;
            this.pointsFontGroupBox.TabStop = false;
            this.pointsFontGroupBox.Text = "Points";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 11);
            this.label4.TabIndex = 46;
            this.label4.Text = "Outline";
            // 
            // pointsFontOutlineColorButton
            // 
            this.pointsFontOutlineColorButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsFontOutlineColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pointsFontOutlineColorButton.Location = new System.Drawing.Point(6, 56);
            this.pointsFontOutlineColorButton.Name = "pointsFontOutlineColorButton";
            this.pointsFontOutlineColorButton.Size = new System.Drawing.Size(49, 23);
            this.pointsFontOutlineColorButton.TabIndex = 45;
            this.pointsFontOutlineColorButton.Text = "Set";
            this.pointsFontOutlineColorButton.UseVisualStyleBackColor = true;
            // 
            // pointsFontOutlineColorPictureBox
            // 
            this.pointsFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pointsFontOutlineColorPictureBox.Location = new System.Drawing.Point(61, 57);
            this.pointsFontOutlineColorPictureBox.Name = "pointsFontOutlineColorPictureBox";
            this.pointsFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.pointsFontOutlineColorPictureBox.TabIndex = 45;
            this.pointsFontOutlineColorPictureBox.TabStop = false;
            // 
            // pointsFontColorButton
            // 
            this.pointsFontColorButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsFontColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pointsFontColorButton.Location = new System.Drawing.Point(6, 34);
            this.pointsFontColorButton.Name = "pointsFontColorButton";
            this.pointsFontColorButton.Size = new System.Drawing.Size(49, 23);
            this.pointsFontColorButton.TabIndex = 45;
            this.pointsFontColorButton.Text = "Set";
            this.pointsFontColorButton.UseVisualStyleBackColor = true;
            // 
            // pointsFontOutlineCheckbox
            // 
            this.pointsFontOutlineCheckbox.AutoSize = true;
            this.pointsFontOutlineCheckbox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsFontOutlineCheckbox.Location = new System.Drawing.Point(86, 58);
            this.pointsFontOutlineCheckbox.Name = "pointsFontOutlineCheckbox";
            this.pointsFontOutlineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.pointsFontOutlineCheckbox.TabIndex = 45;
            this.pointsFontOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // pointsFontOutlineNumericUpDown
            // 
            this.pointsFontOutlineNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsFontOutlineNumericUpDown.Location = new System.Drawing.Point(103, 53);
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
            this.pointsFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 20);
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
            this.pointsFontColorPictureBox.Location = new System.Drawing.Point(61, 34);
            this.pointsFontColorPictureBox.Name = "pointsFontColorPictureBox";
            this.pointsFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.pointsFontColorPictureBox.TabIndex = 45;
            this.pointsFontColorPictureBox.TabStop = false;
            // 
            // pointsFontFamilyComboBox
            // 
            this.pointsFontFamilyComboBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsFontFamilyComboBox.FormattingEnabled = true;
            this.pointsFontFamilyComboBox.Location = new System.Drawing.Point(6, 10);
            this.pointsFontFamilyComboBox.Name = "pointsFontFamilyComboBox";
            this.pointsFontFamilyComboBox.Size = new System.Drawing.Size(140, 21);
            this.pointsFontFamilyComboBox.TabIndex = 45;
            // 
            // descriptionFontGroupBox
            // 
            this.descriptionFontGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.descriptionFontGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block5;
            this.descriptionFontGroupBox.Controls.Add(this.label3);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontOutlineColorButton);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontOutlineColorPictureBox);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontColorButton);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontOutlineCheckbox);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontOutlineNumericUpDown);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontColorPictureBox);
            this.descriptionFontGroupBox.Controls.Add(this.descriptionFontFamilyComboBox);
            this.descriptionFontGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionFontGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.descriptionFontGroupBox.Location = new System.Drawing.Point(8, 202);
            this.descriptionFontGroupBox.Name = "descriptionFontGroupBox";
            this.descriptionFontGroupBox.Size = new System.Drawing.Size(152, 85);
            this.descriptionFontGroupBox.TabIndex = 47;
            this.descriptionFontGroupBox.TabStop = false;
            this.descriptionFontGroupBox.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 11);
            this.label3.TabIndex = 46;
            this.label3.Text = "Outline";
            // 
            // descriptionFontOutlineColorButton
            // 
            this.descriptionFontOutlineColorButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionFontOutlineColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.descriptionFontOutlineColorButton.Location = new System.Drawing.Point(6, 56);
            this.descriptionFontOutlineColorButton.Name = "descriptionFontOutlineColorButton";
            this.descriptionFontOutlineColorButton.Size = new System.Drawing.Size(49, 23);
            this.descriptionFontOutlineColorButton.TabIndex = 45;
            this.descriptionFontOutlineColorButton.Text = "Set";
            this.descriptionFontOutlineColorButton.UseVisualStyleBackColor = true;
            // 
            // descriptionFontOutlineColorPictureBox
            // 
            this.descriptionFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.descriptionFontOutlineColorPictureBox.Location = new System.Drawing.Point(61, 57);
            this.descriptionFontOutlineColorPictureBox.Name = "descriptionFontOutlineColorPictureBox";
            this.descriptionFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.descriptionFontOutlineColorPictureBox.TabIndex = 45;
            this.descriptionFontOutlineColorPictureBox.TabStop = false;
            // 
            // descriptionFontColorButton
            // 
            this.descriptionFontColorButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionFontColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.descriptionFontColorButton.Location = new System.Drawing.Point(6, 34);
            this.descriptionFontColorButton.Name = "descriptionFontColorButton";
            this.descriptionFontColorButton.Size = new System.Drawing.Size(49, 23);
            this.descriptionFontColorButton.TabIndex = 45;
            this.descriptionFontColorButton.Text = "Set";
            this.descriptionFontColorButton.UseVisualStyleBackColor = true;
            // 
            // descriptionFontOutlineCheckbox
            // 
            this.descriptionFontOutlineCheckbox.AutoSize = true;
            this.descriptionFontOutlineCheckbox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionFontOutlineCheckbox.Location = new System.Drawing.Point(86, 58);
            this.descriptionFontOutlineCheckbox.Name = "descriptionFontOutlineCheckbox";
            this.descriptionFontOutlineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.descriptionFontOutlineCheckbox.TabIndex = 45;
            this.descriptionFontOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // descriptionFontOutlineNumericUpDown
            // 
            this.descriptionFontOutlineNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionFontOutlineNumericUpDown.Location = new System.Drawing.Point(103, 53);
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
            this.descriptionFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 20);
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
            this.descriptionFontColorPictureBox.Location = new System.Drawing.Point(61, 34);
            this.descriptionFontColorPictureBox.Name = "descriptionFontColorPictureBox";
            this.descriptionFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.descriptionFontColorPictureBox.TabIndex = 45;
            this.descriptionFontColorPictureBox.TabStop = false;
            // 
            // descriptionFontFamilyComboBox
            // 
            this.descriptionFontFamilyComboBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionFontFamilyComboBox.FormattingEnabled = true;
            this.descriptionFontFamilyComboBox.Location = new System.Drawing.Point(6, 10);
            this.descriptionFontFamilyComboBox.Name = "descriptionFontFamilyComboBox";
            this.descriptionFontFamilyComboBox.Size = new System.Drawing.Size(140, 21);
            this.descriptionFontFamilyComboBox.TabIndex = 45;
            // 
            // lineFontGroupBox
            // 
            this.lineFontGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.lineFontGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block5;
            this.lineFontGroupBox.Controls.Add(this.label5);
            this.lineFontGroupBox.Controls.Add(this.lineOutlineColorButton);
            this.lineFontGroupBox.Controls.Add(this.lineOutlineColorPictureBox);
            this.lineFontGroupBox.Controls.Add(this.lineColorButton);
            this.lineFontGroupBox.Controls.Add(this.lineOutlineCheckbox);
            this.lineFontGroupBox.Controls.Add(this.lineOutlineNumericUpDown);
            this.lineFontGroupBox.Controls.Add(this.lineColorPictureBox);
            this.lineFontGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineFontGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lineFontGroupBox.Location = new System.Drawing.Point(6, 384);
            this.lineFontGroupBox.Name = "lineFontGroupBox";
            this.lineFontGroupBox.Size = new System.Drawing.Size(152, 62);
            this.lineFontGroupBox.TabIndex = 49;
            this.lineFontGroupBox.TabStop = false;
            this.lineFontGroupBox.Text = "Line";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 11);
            this.label5.TabIndex = 46;
            this.label5.Text = "Outline";
            // 
            // lineOutlineColorButton
            // 
            this.lineOutlineColorButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineOutlineColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lineOutlineColorButton.Location = new System.Drawing.Point(4, 34);
            this.lineOutlineColorButton.Name = "lineOutlineColorButton";
            this.lineOutlineColorButton.Size = new System.Drawing.Size(49, 23);
            this.lineOutlineColorButton.TabIndex = 45;
            this.lineOutlineColorButton.Text = "Set";
            this.lineOutlineColorButton.UseVisualStyleBackColor = true;
            // 
            // lineOutlineColorPictureBox
            // 
            this.lineOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineOutlineColorPictureBox.Location = new System.Drawing.Point(59, 34);
            this.lineOutlineColorPictureBox.Name = "lineOutlineColorPictureBox";
            this.lineOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.lineOutlineColorPictureBox.TabIndex = 45;
            this.lineOutlineColorPictureBox.TabStop = false;
            // 
            // lineColorButton
            // 
            this.lineColorButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lineColorButton.Location = new System.Drawing.Point(4, 11);
            this.lineColorButton.Name = "lineColorButton";
            this.lineColorButton.Size = new System.Drawing.Size(49, 23);
            this.lineColorButton.TabIndex = 45;
            this.lineColorButton.Text = "Set";
            this.lineColorButton.UseVisualStyleBackColor = true;
            // 
            // lineOutlineCheckbox
            // 
            this.lineOutlineCheckbox.AutoSize = true;
            this.lineOutlineCheckbox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineOutlineCheckbox.Location = new System.Drawing.Point(84, 36);
            this.lineOutlineCheckbox.Name = "lineOutlineCheckbox";
            this.lineOutlineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.lineOutlineCheckbox.TabIndex = 45;
            this.lineOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // lineOutlineNumericUpDown
            // 
            this.lineOutlineNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineOutlineNumericUpDown.Location = new System.Drawing.Point(101, 29);
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
            this.lineOutlineNumericUpDown.Size = new System.Drawing.Size(43, 20);
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
            this.lineColorPictureBox.Location = new System.Drawing.Point(59, 11);
            this.lineColorPictureBox.Name = "lineColorPictureBox";
            this.lineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.lineColorPictureBox.TabIndex = 45;
            this.lineColorPictureBox.TabStop = false;
            // 
            // simpleFontLabel
            // 
            this.simpleFontLabel.AutoSize = true;
            this.simpleFontLabel.BackColor = System.Drawing.Color.Transparent;
            this.simpleFontLabel.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleFontLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.simpleFontLabel.Location = new System.Drawing.Point(28, 56);
            this.simpleFontLabel.Name = "simpleFontLabel";
            this.simpleFontLabel.Size = new System.Drawing.Size(47, 11);
            this.simpleFontLabel.TabIndex = 47;
            this.simpleFontLabel.Text = "Simple";
            // 
            // simpleFontCheckBox
            // 
            this.simpleFontCheckBox.AutoSize = true;
            this.simpleFontCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.simpleFontCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleFontCheckBox.Location = new System.Drawing.Point(8, 54);
            this.simpleFontCheckBox.Name = "simpleFontCheckBox";
            this.simpleFontCheckBox.Size = new System.Drawing.Size(15, 14);
            this.simpleFontCheckBox.TabIndex = 47;
            this.simpleFontCheckBox.UseVisualStyleBackColor = false;
            // 
            // titleFontGroupBox
            // 
            this.titleFontGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.titleFontGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block5;
            this.titleFontGroupBox.Controls.Add(this.titleOutlineLabel);
            this.titleFontGroupBox.Controls.Add(this.titleFontOutlineColorButton);
            this.titleFontGroupBox.Controls.Add(this.titleFontOutlineColorPictureBox);
            this.titleFontGroupBox.Controls.Add(this.titleFontColorButton);
            this.titleFontGroupBox.Controls.Add(this.titleFontOutlineCheckbox);
            this.titleFontGroupBox.Controls.Add(this.titleFontOutlineNumericUpDown);
            this.titleFontGroupBox.Controls.Add(this.titleFontColorPictureBox);
            this.titleFontGroupBox.Controls.Add(this.titleFontFamilyComboBox);
            this.titleFontGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleFontGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleFontGroupBox.Location = new System.Drawing.Point(6, 111);
            this.titleFontGroupBox.Name = "titleFontGroupBox";
            this.titleFontGroupBox.Size = new System.Drawing.Size(152, 85);
            this.titleFontGroupBox.TabIndex = 46;
            this.titleFontGroupBox.TabStop = false;
            this.titleFontGroupBox.Text = "Title";
            // 
            // titleOutlineLabel
            // 
            this.titleOutlineLabel.AutoSize = true;
            this.titleOutlineLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleOutlineLabel.Location = new System.Drawing.Point(87, 37);
            this.titleOutlineLabel.Name = "titleOutlineLabel";
            this.titleOutlineLabel.Size = new System.Drawing.Size(54, 11);
            this.titleOutlineLabel.TabIndex = 46;
            this.titleOutlineLabel.Text = "Outline";
            // 
            // titleFontOutlineColorButton
            // 
            this.titleFontOutlineColorButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleFontOutlineColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.titleFontOutlineColorButton.Location = new System.Drawing.Point(6, 56);
            this.titleFontOutlineColorButton.Name = "titleFontOutlineColorButton";
            this.titleFontOutlineColorButton.Size = new System.Drawing.Size(49, 23);
            this.titleFontOutlineColorButton.TabIndex = 45;
            this.titleFontOutlineColorButton.Text = "Set";
            this.titleFontOutlineColorButton.UseVisualStyleBackColor = true;
            // 
            // titleFontOutlineColorPictureBox
            // 
            this.titleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.titleFontOutlineColorPictureBox.Location = new System.Drawing.Point(61, 57);
            this.titleFontOutlineColorPictureBox.Name = "titleFontOutlineColorPictureBox";
            this.titleFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.titleFontOutlineColorPictureBox.TabIndex = 45;
            this.titleFontOutlineColorPictureBox.TabStop = false;
            // 
            // titleFontColorButton
            // 
            this.titleFontColorButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleFontColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.titleFontColorButton.Location = new System.Drawing.Point(6, 34);
            this.titleFontColorButton.Name = "titleFontColorButton";
            this.titleFontColorButton.Size = new System.Drawing.Size(49, 23);
            this.titleFontColorButton.TabIndex = 45;
            this.titleFontColorButton.Text = "Set";
            this.titleFontColorButton.UseVisualStyleBackColor = true;
            // 
            // titleFontOutlineCheckbox
            // 
            this.titleFontOutlineCheckbox.AutoSize = true;
            this.titleFontOutlineCheckbox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleFontOutlineCheckbox.Location = new System.Drawing.Point(86, 58);
            this.titleFontOutlineCheckbox.Name = "titleFontOutlineCheckbox";
            this.titleFontOutlineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.titleFontOutlineCheckbox.TabIndex = 45;
            this.titleFontOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // titleFontOutlineNumericUpDown
            // 
            this.titleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleFontOutlineNumericUpDown.Location = new System.Drawing.Point(103, 53);
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
            this.titleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.titleFontOutlineNumericUpDown.TabIndex = 45;
            this.titleFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.titleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // titleFontColorPictureBox
            // 
            this.titleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.titleFontColorPictureBox.Location = new System.Drawing.Point(61, 34);
            this.titleFontColorPictureBox.Name = "titleFontColorPictureBox";
            this.titleFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.titleFontColorPictureBox.TabIndex = 45;
            this.titleFontColorPictureBox.TabStop = false;
            // 
            // titleFontFamilyComboBox
            // 
            this.titleFontFamilyComboBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleFontFamilyComboBox.FormattingEnabled = true;
            this.titleFontFamilyComboBox.Location = new System.Drawing.Point(6, 10);
            this.titleFontFamilyComboBox.Name = "titleFontFamilyComboBox";
            this.titleFontFamilyComboBox.Size = new System.Drawing.Size(140, 21);
            this.titleFontFamilyComboBox.TabIndex = 45;
            // 
            // customMasterySettingsGroupBox
            // 
            this.customMasterySettingsGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.customMasterySettingsGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block5;
            this.customMasterySettingsGroupBox.Controls.Add(this.label25);
            this.customMasterySettingsGroupBox.Controls.Add(this.label15);
            this.customMasterySettingsGroupBox.Controls.Add(this.playMasteryButton);
            this.customMasterySettingsGroupBox.Controls.Add(this.selectCustomMasteryNotificationButton);
            this.customMasterySettingsGroupBox.Controls.Add(this.groupBox13);
            this.customMasterySettingsGroupBox.Controls.Add(this.masteryEditOultineCheckbox);
            this.customMasterySettingsGroupBox.Controls.Add(this.groupBox14);
            this.customMasterySettingsGroupBox.Controls.Add(this.groupBox19);
            this.customMasterySettingsGroupBox.Controls.Add(this.customMasteryEnableCheckbox);
            this.customMasterySettingsGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasterySettingsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.customMasterySettingsGroupBox.Location = new System.Drawing.Point(344, 11);
            this.customMasterySettingsGroupBox.Name = "customMasterySettingsGroupBox";
            this.customMasterySettingsGroupBox.Size = new System.Drawing.Size(173, 316);
            this.customMasterySettingsGroupBox.TabIndex = 54;
            this.customMasterySettingsGroupBox.TabStop = false;
            this.customMasterySettingsGroupBox.Text = "Mastery";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label25.Location = new System.Drawing.Point(96, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 11);
            this.label25.TabIndex = 55;
            this.label25.Text = "Custom";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(112, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 11);
            this.label15.TabIndex = 22;
            this.label15.Text = "Edit";
            // 
            // playMasteryButton
            // 
            this.playMasteryButton.BackColor = System.Drawing.SystemColors.Control;
            this.playMasteryButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playMasteryButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playMasteryButton.Location = new System.Drawing.Point(4, 9);
            this.playMasteryButton.Name = "playMasteryButton";
            this.playMasteryButton.Size = new System.Drawing.Size(72, 23);
            this.playMasteryButton.TabIndex = 2;
            this.playMasteryButton.Text = "Replay";
            this.playMasteryButton.UseVisualStyleBackColor = false;
            // 
            // selectCustomMasteryNotificationButton
            // 
            this.selectCustomMasteryNotificationButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomMasteryNotificationButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectCustomMasteryNotificationButton.Location = new System.Drawing.Point(93, 42);
            this.selectCustomMasteryNotificationButton.Name = "selectCustomMasteryNotificationButton";
            this.selectCustomMasteryNotificationButton.Size = new System.Drawing.Size(55, 23);
            this.selectCustomMasteryNotificationButton.TabIndex = 14;
            this.selectCustomMasteryNotificationButton.Text = "File";
            this.selectCustomMasteryNotificationButton.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.BackColor = System.Drawing.Color.Transparent;
            this.groupBox13.Controls.Add(this.label16);
            this.groupBox13.Controls.Add(this.scaleMasteryNumericUpDown);
            this.groupBox13.Controls.Add(this.label17);
            this.groupBox13.Controls.Add(this.label18);
            this.groupBox13.Controls.Add(this.customMasteryXNumericUpDown);
            this.groupBox13.Controls.Add(this.customMasteryYNumericUpDown);
            this.groupBox13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox13.Location = new System.Drawing.Point(4, 38);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(83, 101);
            this.groupBox13.TabIndex = 50;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Position";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(6, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 11);
            this.label16.TabIndex = 21;
            this.label16.Text = "Scale";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scaleMasteryNumericUpDown
            // 
            this.scaleMasteryNumericUpDown.DecimalPlaces = 2;
            this.scaleMasteryNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleMasteryNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.scaleMasteryNumericUpDown.Location = new System.Drawing.Point(16, 76);
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
            this.scaleMasteryNumericUpDown.Size = new System.Drawing.Size(60, 18);
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
            this.label17.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(7, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(12, 11);
            this.label17.TabIndex = 18;
            this.label17.Text = "X";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label18.Location = new System.Drawing.Point(7, 37);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(12, 11);
            this.label18.TabIndex = 19;
            this.label18.Text = "Y";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customMasteryXNumericUpDown
            // 
            this.customMasteryXNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryXNumericUpDown.Location = new System.Drawing.Point(25, 10);
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
            this.customMasteryXNumericUpDown.Size = new System.Drawing.Size(51, 18);
            this.customMasteryXNumericUpDown.TabIndex = 15;
            // 
            // customMasteryYNumericUpDown
            // 
            this.customMasteryYNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryYNumericUpDown.Location = new System.Drawing.Point(25, 32);
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
            this.customMasteryYNumericUpDown.Size = new System.Drawing.Size(51, 18);
            this.customMasteryYNumericUpDown.TabIndex = 16;
            // 
            // masteryEditOultineCheckbox
            // 
            this.masteryEditOultineCheckbox.AutoSize = true;
            this.masteryEditOultineCheckbox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masteryEditOultineCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.masteryEditOultineCheckbox.Location = new System.Drawing.Point(93, 67);
            this.masteryEditOultineCheckbox.Name = "masteryEditOultineCheckbox";
            this.masteryEditOultineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.masteryEditOultineCheckbox.TabIndex = 47;
            this.masteryEditOultineCheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.BackColor = System.Drawing.Color.Transparent;
            this.groupBox14.Controls.Add(this.label19);
            this.groupBox14.Controls.Add(this.label20);
            this.groupBox14.Controls.Add(this.label21);
            this.groupBox14.Controls.Add(this.notificationMasteryOutNumericUpDown);
            this.groupBox14.Controls.Add(this.notificationsMasteryAnimationOutComboBox);
            this.groupBox14.Controls.Add(this.customMasteryOutSpeedUpDown);
            this.groupBox14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox14.Location = new System.Drawing.Point(4, 233);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(165, 80);
            this.groupBox14.TabIndex = 53;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Out-Animation";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label19.Location = new System.Drawing.Point(6, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 11);
            this.label19.TabIndex = 49;
            this.label19.Text = "Speed (ms)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label20.Location = new System.Drawing.Point(6, 63);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 11);
            this.label20.TabIndex = 40;
            this.label20.Text = "Direction";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label21.Location = new System.Drawing.Point(6, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 11);
            this.label21.TabIndex = 20;
            this.label21.Text = "Mark  (ms)";
            // 
            // notificationMasteryOutNumericUpDown
            // 
            this.notificationMasteryOutNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationMasteryOutNumericUpDown.Location = new System.Drawing.Point(96, 14);
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
            this.notificationMasteryOutNumericUpDown.Size = new System.Drawing.Size(63, 18);
            this.notificationMasteryOutNumericUpDown.TabIndex = 26;
            this.notificationMasteryOutNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsMasteryAnimationOutComboBox
            // 
            this.notificationsMasteryAnimationOutComboBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsMasteryAnimationOutComboBox.FormattingEnabled = true;
            this.notificationsMasteryAnimationOutComboBox.Location = new System.Drawing.Point(96, 56);
            this.notificationsMasteryAnimationOutComboBox.Name = "notificationsMasteryAnimationOutComboBox";
            this.notificationsMasteryAnimationOutComboBox.Size = new System.Drawing.Size(63, 21);
            this.notificationsMasteryAnimationOutComboBox.TabIndex = 39;
            // 
            // customMasteryOutSpeedUpDown
            // 
            this.customMasteryOutSpeedUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryOutSpeedUpDown.Location = new System.Drawing.Point(96, 36);
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
            this.customMasteryOutSpeedUpDown.Size = new System.Drawing.Size(63, 18);
            this.customMasteryOutSpeedUpDown.TabIndex = 48;
            this.customMasteryOutSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // groupBox19
            // 
            this.groupBox19.BackColor = System.Drawing.Color.Transparent;
            this.groupBox19.Controls.Add(this.label22);
            this.groupBox19.Controls.Add(this.label23);
            this.groupBox19.Controls.Add(this.label24);
            this.groupBox19.Controls.Add(this.notificationMasteryInNumericUpDown);
            this.groupBox19.Controls.Add(this.notificationsMasteryAnimationInComboBox);
            this.groupBox19.Controls.Add(this.customMasteryInSpeedUpDown);
            this.groupBox19.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox19.Location = new System.Drawing.Point(4, 145);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(165, 80);
            this.groupBox19.TabIndex = 52;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "In-Animation";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label22.Location = new System.Drawing.Point(6, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 11);
            this.label22.TabIndex = 49;
            this.label22.Text = "Speed (ms)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label23.Location = new System.Drawing.Point(6, 63);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 11);
            this.label23.TabIndex = 40;
            this.label23.Text = "Direction";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label24.Location = new System.Drawing.Point(6, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(75, 11);
            this.label24.TabIndex = 20;
            this.label24.Text = "Mark  (ms)";
            // 
            // notificationMasteryInNumericUpDown
            // 
            this.notificationMasteryInNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationMasteryInNumericUpDown.Location = new System.Drawing.Point(96, 11);
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
            this.notificationMasteryInNumericUpDown.Size = new System.Drawing.Size(63, 18);
            this.notificationMasteryInNumericUpDown.TabIndex = 26;
            this.notificationMasteryInNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsMasteryAnimationInComboBox
            // 
            this.notificationsMasteryAnimationInComboBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsMasteryAnimationInComboBox.FormattingEnabled = true;
            this.notificationsMasteryAnimationInComboBox.Location = new System.Drawing.Point(96, 56);
            this.notificationsMasteryAnimationInComboBox.Name = "notificationsMasteryAnimationInComboBox";
            this.notificationsMasteryAnimationInComboBox.Size = new System.Drawing.Size(63, 21);
            this.notificationsMasteryAnimationInComboBox.TabIndex = 39;
            // 
            // customMasteryInSpeedUpDown
            // 
            this.customMasteryInSpeedUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryInSpeedUpDown.Location = new System.Drawing.Point(96, 34);
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
            this.customMasteryInSpeedUpDown.Size = new System.Drawing.Size(63, 18);
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
            this.customMasteryEnableCheckbox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryEnableCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.customMasteryEnableCheckbox.Location = new System.Drawing.Point(80, 14);
            this.customMasteryEnableCheckbox.Name = "customMasteryEnableCheckbox";
            this.customMasteryEnableCheckbox.Size = new System.Drawing.Size(15, 14);
            this.customMasteryEnableCheckbox.TabIndex = 13;
            this.customMasteryEnableCheckbox.UseVisualStyleBackColor = true;
            // 
            // customAchievementCustomizationGroupBox
            // 
            this.customAchievementCustomizationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.customAchievementCustomizationGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block5;
            this.customAchievementCustomizationGroupBox.Controls.Add(this.label10);
            this.customAchievementCustomizationGroupBox.Controls.Add(this.label1);
            this.customAchievementCustomizationGroupBox.Controls.Add(this.replayAchievementButton);
            this.customAchievementCustomizationGroupBox.Controls.Add(this.selectCustomAchievementButton);
            this.customAchievementCustomizationGroupBox.Controls.Add(this.achievementPositionGroupBox);
            this.customAchievementCustomizationGroupBox.Controls.Add(this.acheivementEditOutlineCheckbox);
            this.customAchievementCustomizationGroupBox.Controls.Add(this.groupBox10);
            this.customAchievementCustomizationGroupBox.Controls.Add(this.groupBox9);
            this.customAchievementCustomizationGroupBox.Controls.Add(this.customAchievementEnableCheckbox);
            this.customAchievementCustomizationGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementCustomizationGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.customAchievementCustomizationGroupBox.Location = new System.Drawing.Point(165, 11);
            this.customAchievementCustomizationGroupBox.Name = "customAchievementCustomizationGroupBox";
            this.customAchievementCustomizationGroupBox.Size = new System.Drawing.Size(173, 316);
            this.customAchievementCustomizationGroupBox.TabIndex = 54;
            this.customAchievementCustomizationGroupBox.TabStop = false;
            this.customAchievementCustomizationGroupBox.Text = "Achievement";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(96, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 11);
            this.label10.TabIndex = 54;
            this.label10.Text = "custom";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(112, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 11);
            this.label1.TabIndex = 22;
            this.label1.Text = "Edit";
            // 
            // replayAchievementButton
            // 
            this.replayAchievementButton.BackColor = System.Drawing.SystemColors.Control;
            this.replayAchievementButton.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replayAchievementButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.replayAchievementButton.Location = new System.Drawing.Point(4, 9);
            this.replayAchievementButton.Name = "replayAchievementButton";
            this.replayAchievementButton.Size = new System.Drawing.Size(72, 23);
            this.replayAchievementButton.TabIndex = 2;
            this.replayAchievementButton.Text = "Replay";
            this.replayAchievementButton.UseVisualStyleBackColor = false;
            // 
            // selectCustomAchievementButton
            // 
            this.selectCustomAchievementButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomAchievementButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectCustomAchievementButton.Location = new System.Drawing.Point(93, 42);
            this.selectCustomAchievementButton.Name = "selectCustomAchievementButton";
            this.selectCustomAchievementButton.Size = new System.Drawing.Size(55, 23);
            this.selectCustomAchievementButton.TabIndex = 14;
            this.selectCustomAchievementButton.Text = "File";
            this.selectCustomAchievementButton.UseVisualStyleBackColor = true;
            // 
            // achievementPositionGroupBox
            // 
            this.achievementPositionGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.achievementPositionGroupBox.Controls.Add(this.label14);
            this.achievementPositionGroupBox.Controls.Add(this.scaleAchievementNumericUpDown);
            this.achievementPositionGroupBox.Controls.Add(this.xPositionLabel1);
            this.achievementPositionGroupBox.Controls.Add(this.yPositionLabel1);
            this.achievementPositionGroupBox.Controls.Add(this.customAchievementXNumericUpDown);
            this.achievementPositionGroupBox.Controls.Add(this.customAchievementYNumericUpDown);
            this.achievementPositionGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.achievementPositionGroupBox.Location = new System.Drawing.Point(4, 38);
            this.achievementPositionGroupBox.Name = "achievementPositionGroupBox";
            this.achievementPositionGroupBox.Size = new System.Drawing.Size(83, 101);
            this.achievementPositionGroupBox.TabIndex = 50;
            this.achievementPositionGroupBox.TabStop = false;
            this.achievementPositionGroupBox.Text = "Position";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(6, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 11);
            this.label14.TabIndex = 21;
            this.label14.Text = "Scale";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scaleAchievementNumericUpDown
            // 
            this.scaleAchievementNumericUpDown.DecimalPlaces = 2;
            this.scaleAchievementNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleAchievementNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.scaleAchievementNumericUpDown.Location = new System.Drawing.Point(16, 76);
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
            this.scaleAchievementNumericUpDown.Size = new System.Drawing.Size(60, 18);
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
            this.xPositionLabel1.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPositionLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.xPositionLabel1.Location = new System.Drawing.Point(7, 17);
            this.xPositionLabel1.Name = "xPositionLabel1";
            this.xPositionLabel1.Size = new System.Drawing.Size(12, 11);
            this.xPositionLabel1.TabIndex = 18;
            this.xPositionLabel1.Text = "X";
            // 
            // yPositionLabel1
            // 
            this.yPositionLabel1.AutoSize = true;
            this.yPositionLabel1.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yPositionLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.yPositionLabel1.Location = new System.Drawing.Point(7, 37);
            this.yPositionLabel1.Name = "yPositionLabel1";
            this.yPositionLabel1.Size = new System.Drawing.Size(12, 11);
            this.yPositionLabel1.TabIndex = 19;
            this.yPositionLabel1.Text = "Y";
            this.yPositionLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customAchievementXNumericUpDown
            // 
            this.customAchievementXNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementXNumericUpDown.Location = new System.Drawing.Point(25, 10);
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
            this.customAchievementXNumericUpDown.Size = new System.Drawing.Size(51, 18);
            this.customAchievementXNumericUpDown.TabIndex = 15;
            // 
            // customAchievementYNumericUpDown
            // 
            this.customAchievementYNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementYNumericUpDown.Location = new System.Drawing.Point(25, 32);
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
            this.customAchievementYNumericUpDown.Size = new System.Drawing.Size(51, 18);
            this.customAchievementYNumericUpDown.TabIndex = 16;
            // 
            // acheivementEditOutlineCheckbox
            // 
            this.acheivementEditOutlineCheckbox.AutoSize = true;
            this.acheivementEditOutlineCheckbox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acheivementEditOutlineCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.acheivementEditOutlineCheckbox.Location = new System.Drawing.Point(93, 67);
            this.acheivementEditOutlineCheckbox.Name = "acheivementEditOutlineCheckbox";
            this.acheivementEditOutlineCheckbox.Size = new System.Drawing.Size(15, 14);
            this.acheivementEditOutlineCheckbox.TabIndex = 47;
            this.acheivementEditOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.Transparent;
            this.groupBox10.Controls.Add(this.label11);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Controls.Add(this.label13);
            this.groupBox10.Controls.Add(this.notificationAchievementOutNumericUpDown);
            this.groupBox10.Controls.Add(this.notificationsAchievementAnimationOutComboBox);
            this.groupBox10.Controls.Add(this.customAchievementOutSpeedUpDown);
            this.groupBox10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox10.Location = new System.Drawing.Point(6, 233);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(165, 80);
            this.groupBox10.TabIndex = 53;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Out-Animation";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(6, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 11);
            this.label11.TabIndex = 49;
            this.label11.Text = "Speed (ms)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(6, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 11);
            this.label12.TabIndex = 40;
            this.label12.Text = "Direction";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(6, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 11);
            this.label13.TabIndex = 20;
            this.label13.Text = "Mark  (ms)";
            // 
            // notificationAchievementOutNumericUpDown
            // 
            this.notificationAchievementOutNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationAchievementOutNumericUpDown.Location = new System.Drawing.Point(96, 11);
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
            this.notificationAchievementOutNumericUpDown.Size = new System.Drawing.Size(63, 18);
            this.notificationAchievementOutNumericUpDown.TabIndex = 26;
            this.notificationAchievementOutNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsAchievementAnimationOutComboBox
            // 
            this.notificationsAchievementAnimationOutComboBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsAchievementAnimationOutComboBox.FormattingEnabled = true;
            this.notificationsAchievementAnimationOutComboBox.Location = new System.Drawing.Point(96, 56);
            this.notificationsAchievementAnimationOutComboBox.Name = "notificationsAchievementAnimationOutComboBox";
            this.notificationsAchievementAnimationOutComboBox.Size = new System.Drawing.Size(63, 21);
            this.notificationsAchievementAnimationOutComboBox.TabIndex = 39;
            // 
            // customAchievementOutSpeedUpDown
            // 
            this.customAchievementOutSpeedUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementOutSpeedUpDown.Location = new System.Drawing.Point(96, 34);
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
            this.customAchievementOutSpeedUpDown.Size = new System.Drawing.Size(63, 18);
            this.customAchievementOutSpeedUpDown.TabIndex = 48;
            this.customAchievementOutSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.Transparent;
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.notificationAchievementInNumericUpDown);
            this.groupBox9.Controls.Add(this.notificationsAchievementAnimationInComboBox);
            this.groupBox9.Controls.Add(this.customAchievementInSpeedUpDown);
            this.groupBox9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox9.Location = new System.Drawing.Point(4, 145);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(165, 80);
            this.groupBox9.TabIndex = 52;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "In-Animation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(6, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 11);
            this.label8.TabIndex = 49;
            this.label8.Text = "Speed (ms)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(6, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 11);
            this.label7.TabIndex = 40;
            this.label7.Text = "Direction";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 11);
            this.label6.TabIndex = 20;
            this.label6.Text = "Mark  (ms)";
            // 
            // notificationAchievementInNumericUpDown
            // 
            this.notificationAchievementInNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationAchievementInNumericUpDown.Location = new System.Drawing.Point(96, 11);
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
            this.notificationAchievementInNumericUpDown.Size = new System.Drawing.Size(63, 18);
            this.notificationAchievementInNumericUpDown.TabIndex = 26;
            this.notificationAchievementInNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsAchievementAnimationInComboBox
            // 
            this.notificationsAchievementAnimationInComboBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsAchievementAnimationInComboBox.FormattingEnabled = true;
            this.notificationsAchievementAnimationInComboBox.Location = new System.Drawing.Point(96, 56);
            this.notificationsAchievementAnimationInComboBox.Name = "notificationsAchievementAnimationInComboBox";
            this.notificationsAchievementAnimationInComboBox.Size = new System.Drawing.Size(63, 21);
            this.notificationsAchievementAnimationInComboBox.TabIndex = 39;
            // 
            // customAchievementInSpeedUpDown
            // 
            this.customAchievementInSpeedUpDown.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementInSpeedUpDown.Location = new System.Drawing.Point(96, 34);
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
            this.customAchievementInSpeedUpDown.Size = new System.Drawing.Size(63, 18);
            this.customAchievementInSpeedUpDown.TabIndex = 48;
            this.customAchievementInSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // customAchievementEnableCheckbox
            // 
            this.customAchievementEnableCheckbox.AutoSize = true;
            this.customAchievementEnableCheckbox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementEnableCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.customAchievementEnableCheckbox.Location = new System.Drawing.Point(80, 14);
            this.customAchievementEnableCheckbox.Name = "customAchievementEnableCheckbox";
            this.customAchievementEnableCheckbox.Size = new System.Drawing.Size(15, 14);
            this.customAchievementEnableCheckbox.TabIndex = 13;
            this.customAchievementEnableCheckbox.UseVisualStyleBackColor = true;
            // 
            // achievementListGroupBox
            // 
            this.achievementListGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.achievementListGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block;
            this.achievementListGroupBox.Controls.Add(this.autoOpenAchievementListWindowCheckbox);
            this.achievementListGroupBox.Controls.Add(this.customizeAchievementListButton);
            this.achievementListGroupBox.Controls.Add(this.openAchievementListWindowButton);
            this.achievementListGroupBox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementListGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.achievementListGroupBox.Location = new System.Drawing.Point(353, 159);
            this.achievementListGroupBox.Name = "achievementListGroupBox";
            this.achievementListGroupBox.Size = new System.Drawing.Size(315, 45);
            this.achievementListGroupBox.TabIndex = 10025;
            this.achievementListGroupBox.TabStop = false;
            this.achievementListGroupBox.Text = "Cheevo List";
            // 
            // autoOpenAchievementListWindowCheckbox
            // 
            this.autoOpenAchievementListWindowCheckbox.AutoSize = true;
            this.autoOpenAchievementListWindowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.autoOpenAchievementListWindowCheckbox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoOpenAchievementListWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoOpenAchievementListWindowCheckbox.Location = new System.Drawing.Point(6, 21);
            this.autoOpenAchievementListWindowCheckbox.Name = "autoOpenAchievementListWindowCheckbox";
            this.autoOpenAchievementListWindowCheckbox.Size = new System.Drawing.Size(87, 15);
            this.autoOpenAchievementListWindowCheckbox.TabIndex = 10022;
            this.autoOpenAchievementListWindowCheckbox.Text = "Auto-Open";
            this.autoOpenAchievementListWindowCheckbox.UseVisualStyleBackColor = false;
            // 
            // customizeAchievementListButton
            // 
            this.customizeAchievementListButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeAchievementListButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeAchievementListButton.Location = new System.Drawing.Point(226, 10);
            this.customizeAchievementListButton.Name = "customizeAchievementListButton";
            this.customizeAchievementListButton.Size = new System.Drawing.Size(85, 28);
            this.customizeAchievementListButton.TabIndex = 10024;
            this.customizeAchievementListButton.Text = "Custom";
            this.customizeAchievementListButton.UseVisualStyleBackColor = true;
            // 
            // openAchievementListWindowButton
            // 
            this.openAchievementListWindowButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openAchievementListWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openAchievementListWindowButton.Location = new System.Drawing.Point(135, 10);
            this.openAchievementListWindowButton.Name = "openAchievementListWindowButton";
            this.openAchievementListWindowButton.Size = new System.Drawing.Size(85, 28);
            this.openAchievementListWindowButton.TabIndex = 10021;
            this.openAchievementListWindowButton.Text = "Open";
            this.openAchievementListWindowButton.UseVisualStyleBackColor = true;
            // 
            // gameStatsGroupBox
            // 
            this.gameStatsGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.gameStatsGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block;
            this.gameStatsGroupBox.Controls.Add(this.autoOpenGameStatsWindowCheckbox);
            this.gameStatsGroupBox.Controls.Add(this.customizeGameStatsButton);
            this.gameStatsGroupBox.Controls.Add(this.openGameStatsWindowButton);
            this.gameStatsGroupBox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameStatsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameStatsGroupBox.Location = new System.Drawing.Point(353, 312);
            this.gameStatsGroupBox.Name = "gameStatsGroupBox";
            this.gameStatsGroupBox.Size = new System.Drawing.Size(315, 45);
            this.gameStatsGroupBox.TabIndex = 10025;
            this.gameStatsGroupBox.TabStop = false;
            this.gameStatsGroupBox.Text = "Game Stats";
            // 
            // autoOpenGameStatsWindowCheckbox
            // 
            this.autoOpenGameStatsWindowCheckbox.AutoSize = true;
            this.autoOpenGameStatsWindowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.autoOpenGameStatsWindowCheckbox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoOpenGameStatsWindowCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoOpenGameStatsWindowCheckbox.Location = new System.Drawing.Point(6, 21);
            this.autoOpenGameStatsWindowCheckbox.Name = "autoOpenGameStatsWindowCheckbox";
            this.autoOpenGameStatsWindowCheckbox.Size = new System.Drawing.Size(87, 15);
            this.autoOpenGameStatsWindowCheckbox.TabIndex = 10022;
            this.autoOpenGameStatsWindowCheckbox.Text = "Auto-Open";
            this.autoOpenGameStatsWindowCheckbox.UseVisualStyleBackColor = false;
            // 
            // customizeGameStatsButton
            // 
            this.customizeGameStatsButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizeGameStatsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customizeGameStatsButton.Location = new System.Drawing.Point(226, 10);
            this.customizeGameStatsButton.Name = "customizeGameStatsButton";
            this.customizeGameStatsButton.Size = new System.Drawing.Size(85, 28);
            this.customizeGameStatsButton.TabIndex = 10024;
            this.customizeGameStatsButton.Text = "Custom";
            this.customizeGameStatsButton.UseVisualStyleBackColor = true;
            // 
            // openGameStatsWindowButton
            // 
            this.openGameStatsWindowButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openGameStatsWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openGameStatsWindowButton.Location = new System.Drawing.Point(135, 10);
            this.openGameStatsWindowButton.Name = "openGameStatsWindowButton";
            this.openGameStatsWindowButton.Size = new System.Drawing.Size(85, 28);
            this.openGameStatsWindowButton.TabIndex = 10021;
            this.openGameStatsWindowButton.Text = "Open";
            this.openGameStatsWindowButton.UseVisualStyleBackColor = true;
            // 
            // gameStatsCustomizationGroupBox
            // 
            this.gameStatsCustomizationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.gameStatsCustomizationGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block5;
            this.gameStatsCustomizationGroupBox.Controls.Add(this.gameStatsDefaultButton);
            this.gameStatsCustomizationGroupBox.Controls.Add(this.groupBox17);
            this.gameStatsCustomizationGroupBox.Controls.Add(this.gameRatioEnableCheckBox);
            this.gameStatsCustomizationGroupBox.Controls.Add(this.statsGameAchievementsOverrideTextBox);
            this.gameStatsCustomizationGroupBox.Controls.Add(this.completedEnableCheckBox);
            this.gameStatsCustomizationGroupBox.Controls.Add(this.statsGameRatioOverrideTextBox);
            this.gameStatsCustomizationGroupBox.Controls.Add(this.gameTruePointsEnableCheckBox);
            this.gameStatsCustomizationGroupBox.Controls.Add(this.gameAchievementsEnableCheckBox);
            this.gameStatsCustomizationGroupBox.Controls.Add(this.gamePointsEnableCheckBox);
            this.gameStatsCustomizationGroupBox.Controls.Add(this.statsCompletedOverrideTextBox);
            this.gameStatsCustomizationGroupBox.Controls.Add(this.statsGamePointsOverrideTextBox);
            this.gameStatsCustomizationGroupBox.Controls.Add(this.statsGameTruePointsOverrideTextBox);
            this.gameStatsCustomizationGroupBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameStatsCustomizationGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameStatsCustomizationGroupBox.Location = new System.Drawing.Point(166, 333);
            this.gameStatsCustomizationGroupBox.Name = "gameStatsCustomizationGroupBox";
            this.gameStatsCustomizationGroupBox.Size = new System.Drawing.Size(195, 226);
            this.gameStatsCustomizationGroupBox.TabIndex = 10008;
            this.gameStatsCustomizationGroupBox.TabStop = false;
            this.gameStatsCustomizationGroupBox.Text = "Label Text";
            // 
            // settingsAndBrowserGroupBox
            // 
            this.settingsAndBrowserGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block;
            this.settingsAndBrowserGroupBox.Controls.Add(this.recentAchievementsMaxListLabel);
            this.settingsAndBrowserGroupBox.Controls.Add(this.recentAchievementsMaxListNumericUpDown);
            this.settingsAndBrowserGroupBox.Controls.Add(this.autoSrollLabel);
            this.settingsAndBrowserGroupBox.Controls.Add(this.autoScrollCheckBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.userStatsCustomizationGroupBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.lineFontGroupBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.pointsFontGroupBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.gameStatsCustomizationGroupBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.gameInfoCustomizationGroupBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.borderBackgroundGroupBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.descriptionFontGroupBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.windowBackgroundGroupBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.customMasterySettingsGroupBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.titleFontGroupBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.fontBorderLabel);
            this.settingsAndBrowserGroupBox.Controls.Add(this.simpleFontCheckBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.simpleFontLabel);
            this.settingsAndBrowserGroupBox.Controls.Add(this.customAchievementCustomizationGroupBox);
            this.settingsAndBrowserGroupBox.Controls.Add(this.fontBorderCheckBox);
            this.settingsAndBrowserGroupBox.Location = new System.Drawing.Point(674, 6);
            this.settingsAndBrowserGroupBox.Name = "settingsAndBrowserGroupBox";
            this.settingsAndBrowserGroupBox.Size = new System.Drawing.Size(560, 453);
            this.settingsAndBrowserGroupBox.TabIndex = 10028;
            this.settingsAndBrowserGroupBox.TabStop = false;
            // 
            // recentAchievementsMaxListLabel
            // 
            this.recentAchievementsMaxListLabel.AutoSize = true;
            this.recentAchievementsMaxListLabel.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsMaxListLabel.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsMaxListLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.recentAchievementsMaxListLabel.Location = new System.Drawing.Point(113, 56);
            this.recentAchievementsMaxListLabel.Name = "recentAchievementsMaxListLabel";
            this.recentAchievementsMaxListLabel.Size = new System.Drawing.Size(96, 11);
            this.recentAchievementsMaxListLabel.TabIndex = 10015;
            this.recentAchievementsMaxListLabel.Text = "Max List Size";
            // 
            // recentAchievementsMaxListNumericUpDown
            // 
            this.recentAchievementsMaxListNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsMaxListNumericUpDown.Location = new System.Drawing.Point(115, 70);
            this.recentAchievementsMaxListNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.recentAchievementsMaxListNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentAchievementsMaxListNumericUpDown.Name = "recentAchievementsMaxListNumericUpDown";
            this.recentAchievementsMaxListNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.recentAchievementsMaxListNumericUpDown.TabIndex = 22;
            this.recentAchievementsMaxListNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // autoSrollLabel
            // 
            this.autoSrollLabel.AutoSize = true;
            this.autoSrollLabel.BackColor = System.Drawing.Color.Transparent;
            this.autoSrollLabel.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoSrollLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.autoSrollLabel.Location = new System.Drawing.Point(28, 95);
            this.autoSrollLabel.Name = "autoSrollLabel";
            this.autoSrollLabel.Size = new System.Drawing.Size(82, 11);
            this.autoSrollLabel.TabIndex = 10014;
            this.autoSrollLabel.Text = "Auto-scroll";
            // 
            // autoScrollCheckBox
            // 
            this.autoScrollCheckBox.AutoSize = true;
            this.autoScrollCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.autoScrollCheckBox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoScrollCheckBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.autoScrollCheckBox.Location = new System.Drawing.Point(8, 94);
            this.autoScrollCheckBox.Name = "autoScrollCheckBox";
            this.autoScrollCheckBox.Size = new System.Drawing.Size(15, 14);
            this.autoScrollCheckBox.TabIndex = 10013;
            this.autoScrollCheckBox.UseVisualStyleBackColor = false;
            // 
            // userBrowserGroupBox
            // 
            this.userBrowserGroupBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.userBrowserGroupBox.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block;
            this.userBrowserGroupBox.Controls.Add(this.autoOpenWebBrowserCheckbox);
            this.userBrowserGroupBox.Controls.Add(this.toggleUserBrowserButton);
            this.userBrowserGroupBox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userBrowserGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userBrowserGroupBox.Location = new System.Drawing.Point(353, 363);
            this.userBrowserGroupBox.Name = "userBrowserGroupBox";
            this.userBrowserGroupBox.Size = new System.Drawing.Size(315, 45);
            this.userBrowserGroupBox.TabIndex = 10026;
            this.userBrowserGroupBox.TabStop = false;
            this.userBrowserGroupBox.Text = "Browser / RSS";
            // 
            // autoOpenWebBrowserCheckbox
            // 
            this.autoOpenWebBrowserCheckbox.AutoSize = true;
            this.autoOpenWebBrowserCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.autoOpenWebBrowserCheckbox.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoOpenWebBrowserCheckbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoOpenWebBrowserCheckbox.Location = new System.Drawing.Point(6, 21);
            this.autoOpenWebBrowserCheckbox.Name = "autoOpenWebBrowserCheckbox";
            this.autoOpenWebBrowserCheckbox.Size = new System.Drawing.Size(87, 15);
            this.autoOpenWebBrowserCheckbox.TabIndex = 10022;
            this.autoOpenWebBrowserCheckbox.Text = "Auto-Open";
            this.autoOpenWebBrowserCheckbox.UseVisualStyleBackColor = false;
            // 
            // toggleUserBrowserButton
            // 
            this.toggleUserBrowserButton.Font = new System.Drawing.Font("Lucida Console", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleUserBrowserButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toggleUserBrowserButton.Location = new System.Drawing.Point(135, 11);
            this.toggleUserBrowserButton.Name = "toggleUserBrowserButton";
            this.toggleUserBrowserButton.Size = new System.Drawing.Size(85, 28);
            this.toggleUserBrowserButton.TabIndex = 10021;
            this.toggleUserBrowserButton.Text = "Open";
            this.toggleUserBrowserButton.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::Retro_Achievement_Tracker.Properties.Resources.chrono_trigger_block1;
            this.ClientSize = new System.Drawing.Size(1196, 464);
            this.Controls.Add(this.userBrowserGroupBox);
            this.Controls.Add(this.settingsAndBrowserGroupBox);
            this.Controls.Add(this.userInfoGroupBox);
            this.Controls.Add(this.gameStatsGroupBox);
            this.Controls.Add(this.achievementListGroupBox);
            this.Controls.Add(this.gameInfoGroupBox);
            this.Controls.Add(this.notificationsGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.recentAchievementsGroupBox);
            this.Controls.Add(this.userStatsGroupBox);
            this.Controls.Add(this.focusGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.Text = "Retro Achievements Tracker";
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePictureBox)).EndInit();
            this.userStatsGroupBox.ResumeLayout(false);
            this.userStatsGroupBox.PerformLayout();
            this.focusGroupBox.ResumeLayout(false);
            this.focusGroupBox.PerformLayout();
            this.userInfoGroupBox.ResumeLayout(false);
            this.userInfoGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.raConnectionStatusPictureBox)).EndInit();
            this.notificationsGroupBox.ResumeLayout(false);
            this.notificationsGroupBox.PerformLayout();
            this.gameInfoGroupBox.ResumeLayout(false);
            this.gameInfoGroupBox.PerformLayout();
            this.recentAchievementsGroupBox.ResumeLayout(false);
            this.recentAchievementsGroupBox.PerformLayout();
            this.userStatsCustomizationGroupBox.ResumeLayout(false);
            this.userStatsCustomizationGroupBox.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.gameInfoCustomizationGroupBox.ResumeLayout(false);
            this.gameInfoCustomizationGroupBox.PerformLayout();
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
            this.customAchievementCustomizationGroupBox.ResumeLayout(false);
            this.customAchievementCustomizationGroupBox.PerformLayout();
            this.achievementPositionGroupBox.ResumeLayout(false);
            this.achievementPositionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleAchievementNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementYNumericUpDown)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationAchievementOutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementOutSpeedUpDown)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationAchievementInNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customAchievementInSpeedUpDown)).EndInit();
            this.achievementListGroupBox.ResumeLayout(false);
            this.achievementListGroupBox.PerformLayout();
            this.gameStatsGroupBox.ResumeLayout(false);
            this.gameStatsGroupBox.PerformLayout();
            this.gameStatsCustomizationGroupBox.ResumeLayout(false);
            this.gameStatsCustomizationGroupBox.PerformLayout();
            this.settingsAndBrowserGroupBox.ResumeLayout(false);
            this.settingsAndBrowserGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsMaxListNumericUpDown)).EndInit();
            this.userBrowserGroupBox.ResumeLayout(false);
            this.userBrowserGroupBox.PerformLayout();
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
        private CheckBox autoOpenFocusWindowCheckBox;
        private GroupBox notificationsGroupBox;
        private GroupBox focusGroupBox;
        private GroupBox userStatsGroupBox;
        private CheckBox autoOpenUserStatsWindowCheckbox;
        private Button openUserStatsWindowButton;
        private CheckBox autoOpenAlertsWindowCheckbox;
        private Button openNotificationWindowButton;
        private Label timerStatusLabel;
        private PictureBox raConnectionStatusPictureBox;
        private Label focusAchievementDescriptionLabel;
        private PictureBox focusAchievementPictureBox;
        private Label focusAchievementTitleLabel;
        private Button customizeFocusButton;
        private Button customizeUserStatsButton;
        private Button customizeAlertsButton;
        private GroupBox gameInfoGroupBox;
        private Button customizeGameInfoButton;
        private CheckBox autoOpenGameInfoWindowCheckbox;
        private Button openGameInfoWindowButton;
        private GroupBox groupBox2;
        private GroupBox recentAchievementsGroupBox;
        private Button customizeLastFiveButton;
        private CheckBox autoOpenLastFiveWindowCheckbox;
        private Button openLastFiveWindowButton;
        private TextBox statsGameRatioOverrideTextBox;
        private TextBox statsTruePointsOverrideTextBox;
        private TextBox statsPointsOverrideTextBox;
        private TextBox statsRatioOverrideTextBox;
        private TextBox statsAwardsOverrideTextBox;
        private TextBox statsRankOverrideTextBox;
        private GroupBox userStatsCustomizationGroupBox;
        private GroupBox gameInfoCustomizationGroupBox;
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
        private Button userStatsDefaultButton;
        private Button gameInfoDefaultButton;
        private TextBox gameInfoTitleOverrideTextBox;
        private TextBox statsCompletedOverrideTextBox;
        private CheckBox fontBorderCheckBox;
        private RadioButton statsRadioButtonDot;
        private RadioButton statsRadioButtonBackslash;
        private RadioButton statsRadioButtonSemicolon;
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
        private CheckBox simpleFontCheckBox;
        private Label simpleFontLabel;
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
        private Button replayAchievementButton;
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
        private Label fontBorderLabel;
        private GroupBox groupBox17;
        private GroupBox customAchievementCustomizationGroupBox;
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
        private GroupBox userInfoGroupBox;
        private Button gameStatsDefaultButton;
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
        private CheckBox autoOpenAchievementListWindowCheckbox;
        private Button customizeAchievementListButton;
        private Button openAchievementListWindowButton;
        private GroupBox gameStatsGroupBox;
        private CheckBox autoOpenGameStatsWindowCheckbox;
        private Button customizeGameStatsButton;
        private Button openGameStatsWindowButton;
        private GroupBox gameStatsCustomizationGroupBox;
        private Label label10;
        private Label label25;
        private PictureBox gameInfoPictureBox;
        private ListView rssFeedListView;
        private Label gameInfoProgressLabel;
        private Label gameInfoTitleLabel;
        private GroupBox settingsAndBrowserGroupBox;
        private CheckBox rssFeedNewsCheckBox;
        private CheckBox rssFeedCheevoCheckBox;
        private CheckBox rssFeedFriendCheckBox;
        private CheckBox rssFeedForumCheckBox;
        private GroupBox userBrowserGroupBox;
        private CheckBox autoOpenWebBrowserCheckbox;
        private Button toggleUserBrowserButton;
        private CheckBox autoScrollCheckBox;
        private ColumnHeader columnHeader1;
        private Label autoSrollLabel;
        private GroupBox groupBox3;
        private GroupBox groupBox1;
        private Label recentAchievementsMaxListLabel;
        private NumericUpDown recentAchievementsMaxListNumericUpDown;
    }
}

