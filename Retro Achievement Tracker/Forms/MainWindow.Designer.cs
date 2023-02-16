using System.Windows.Forms;

namespace Retro_Achievement_Tracker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.apiKeyLabel = new System.Windows.Forms.Label();
            this.apiKeyTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.userProfilePictureBox = new System.Windows.Forms.PictureBox();
            this.autoStartCheckbox = new System.Windows.Forms.CheckBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.timerStatusLabel = new System.Windows.Forms.Label();
            this.userInfoAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.userInfoOpenWindowButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.focusAchievementPictureBox = new System.Windows.Forms.PictureBox();
            this.focusAchievementTitleLabel = new System.Windows.Forms.Label();
            this.focusAchievementDescriptionLabel = new System.Windows.Forms.Label();
            this.focusSetButton = new System.Windows.Forms.Button();
            this.focusAchievementButtonPrevious = new System.Windows.Forms.Button();
            this.focusAchievementButtonNext = new System.Windows.Forms.Button();
            this.gameInfoPictureBox = new System.Windows.Forms.PictureBox();
            this.rssFeedFriendCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedCheevoCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedNewsCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedForumCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.raConnectionStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.alertsPlayAchievementButton = new System.Windows.Forms.Button();
            this.alertsSelectCustomAchievementFileButton = new System.Windows.Forms.Button();
            this.alertsCustomAchievementScaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomAchievementXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomAchievementYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsAchievementEditOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.alertsCustomAchievementOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomAchievementAnimationOutComboBox = new System.Windows.Forms.ComboBox();
            this.alertsCustomAchievementOutSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomAchievementInNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomAchievementAnimationInComboBox = new System.Windows.Forms.ComboBox();
            this.alertsCustomAchievementInSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomAchievementEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.alertsPlayMasteryButton = new System.Windows.Forms.Button();
            this.alertsSelectCustomMasteryFileButton = new System.Windows.Forms.Button();
            this.alertsCustomMasteryScaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomMasteryXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomMasteryYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsMasteryEditOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.alertsCustomMasteryOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomMasteryAnimationOutComboBox = new System.Windows.Forms.ComboBox();
            this.alertsCustomMasteryOutSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomMasteryInNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomMasteryAnimationInComboBox = new System.Windows.Forms.ComboBox();
            this.alertsCustomMasteryInSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsCustomMasteryEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.userInfoTruePointsTextBox = new System.Windows.Forms.TextBox();
            this.userInfoPointsTextBox = new System.Windows.Forms.TextBox();
            this.userInfoRatioTextBox = new System.Windows.Forms.TextBox();
            this.userInfoRankTextBox = new System.Windows.Forms.TextBox();
            this.userInfoTruePointsCheckBox = new System.Windows.Forms.CheckBox();
            this.userInfoRatioCheckBox = new System.Windows.Forms.CheckBox();
            this.userInfoPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.userInfoDefaultButton = new System.Windows.Forms.Button();
            this.userInfoRankCheckBox = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.focusBehaviorGoToLastRadioButton = new System.Windows.Forms.RadioButton();
            this.focusBehaviorGoToNextRadioButton = new System.Windows.Forms.RadioButton();
            this.focusBehaviorGoToPreviousRadioButton = new System.Windows.Forms.RadioButton();
            this.focusBehaviorGoToFirstRadioButton = new System.Windows.Forms.RadioButton();
            this.recentAchievementsMaxListLabel = new System.Windows.Forms.Label();
            this.recentAchievementsMaxListNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel64 = new System.Windows.Forms.Panel();
            this.label112 = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.panel63 = new System.Windows.Forms.Panel();
            this.label111 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.panel51 = new System.Windows.Forms.Panel();
            this.focusLinePanel = new System.Windows.Forms.Panel();
            this.label106 = new System.Windows.Forms.Label();
            this.focusLineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label96 = new System.Windows.Forms.Label();
            this.panel59 = new System.Windows.Forms.Panel();
            this.focusBorderCheckBox = new System.Windows.Forms.CheckBox();
            this.focusBorderColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label107 = new System.Windows.Forms.Label();
            this.focusPointsPanel = new System.Windows.Forms.Panel();
            this.label108 = new System.Windows.Forms.Label();
            this.focusPointsFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusPointsFontComboBox = new System.Windows.Forms.ComboBox();
            this.panel52 = new System.Windows.Forms.Panel();
            this.focusAdvancedCheckBox = new System.Windows.Forms.CheckBox();
            this.label97 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.panel61 = new System.Windows.Forms.Panel();
            this.focusTitleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusTitleOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.focusTitleOutlineLabel = new System.Windows.Forms.Label();
            this.focusTitleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusOpenWindowButton = new System.Windows.Forms.Button();
            this.focusDescriptionOutlinePanel = new System.Windows.Forms.Panel();
            this.label110 = new System.Windows.Forms.Label();
            this.focusDescriptionFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusDescriptionFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusDescriptionOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.focusDescriptionPanel = new System.Windows.Forms.Panel();
            this.label101 = new System.Windows.Forms.Label();
            this.focusDescriptionFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusDescriptionFontComboBox = new System.Windows.Forms.ComboBox();
            this.focusAutoOpenWindowCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.panel54 = new System.Windows.Forms.Panel();
            this.focusBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label102 = new System.Windows.Forms.Label();
            this.panel55 = new System.Windows.Forms.Panel();
            this.focusTitleLabel = new System.Windows.Forms.Label();
            this.focusTitleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusTitleFontComboBox = new System.Windows.Forms.ComboBox();
            this.focusPointsOutlinePanel = new System.Windows.Forms.Panel();
            this.focusPointsFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusPointsOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.label104 = new System.Windows.Forms.Label();
            this.focusPointsFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusLineOutlinePanel = new System.Windows.Forms.Panel();
            this.label105 = new System.Windows.Forms.Label();
            this.focusLineOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusLineOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusLineOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.panel65 = new System.Windows.Forms.Panel();
            this.alertsLinePanel = new System.Windows.Forms.Panel();
            this.label113 = new System.Windows.Forms.Label();
            this.alertsLineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label114 = new System.Windows.Forms.Label();
            this.panel67 = new System.Windows.Forms.Panel();
            this.alertsBorderCheckBox = new System.Windows.Forms.CheckBox();
            this.alertsBorderColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label115 = new System.Windows.Forms.Label();
            this.alertsPointsPanel = new System.Windows.Forms.Panel();
            this.label116 = new System.Windows.Forms.Label();
            this.alertsPointsFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.alertsPointsFontComboBox = new System.Windows.Forms.ComboBox();
            this.panel69 = new System.Windows.Forms.Panel();
            this.alertsAdvancedCheckBox = new System.Windows.Forms.CheckBox();
            this.label117 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.panel70 = new System.Windows.Forms.Panel();
            this.alertsTitleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsTitleOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.alertsTitleOutlineLabel = new System.Windows.Forms.Label();
            this.alertsTitleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsOpenWindowButton = new System.Windows.Forms.Button();
            this.alertsDescriptionOutlinePanel = new System.Windows.Forms.Panel();
            this.label122 = new System.Windows.Forms.Label();
            this.alertsDescriptionFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.alertsDescriptionFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsDescriptionOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.alertsDescriptionPanel = new System.Windows.Forms.Panel();
            this.label123 = new System.Windows.Forms.Label();
            this.alertsDescriptionFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.alertsDescriptionFontComboBox = new System.Windows.Forms.ComboBox();
            this.alertsAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.panel73 = new System.Windows.Forms.Panel();
            this.alertsBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label124 = new System.Windows.Forms.Label();
            this.panel74 = new System.Windows.Forms.Panel();
            this.alertsTitleLabel = new System.Windows.Forms.Label();
            this.alertsTitleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.alertsTitleFontComboBox = new System.Windows.Forms.ComboBox();
            this.alertsPointsOutlinePanel = new System.Windows.Forms.Panel();
            this.alertsPointsFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsPointsOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.label126 = new System.Windows.Forms.Label();
            this.alertsPointsFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.alertsLineOutlinePanel = new System.Windows.Forms.Panel();
            this.label127 = new System.Windows.Forms.Label();
            this.alertsLineOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.alertsLineOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alertsLineOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.alertsCustomAchievementPanel = new System.Windows.Forms.Panel();
            this.panel85 = new System.Windows.Forms.Panel();
            this.label136 = new System.Windows.Forms.Label();
            this.panel84 = new System.Windows.Forms.Panel();
            this.label135 = new System.Windows.Forms.Label();
            this.panel86 = new System.Windows.Forms.Panel();
            this.label137 = new System.Windows.Forms.Label();
            this.panel83 = new System.Windows.Forms.Panel();
            this.label129 = new System.Windows.Forms.Label();
            this.panel87 = new System.Windows.Forms.Panel();
            this.label138 = new System.Windows.Forms.Label();
            this.panel78 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.label128 = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.panel79 = new System.Windows.Forms.Panel();
            this.label131 = new System.Windows.Forms.Label();
            this.panel80 = new System.Windows.Forms.Panel();
            this.label132 = new System.Windows.Forms.Label();
            this.panel81 = new System.Windows.Forms.Panel();
            this.label133 = new System.Windows.Forms.Label();
            this.panel82 = new System.Windows.Forms.Panel();
            this.label134 = new System.Windows.Forms.Label();
            this.alertsAchievementEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.alertsCustomMasteryPanel = new System.Windows.Forms.Panel();
            this.panel89 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel90 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel91 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel92 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel93 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel94 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.panel95 = new System.Windows.Forms.Panel();
            this.label140 = new System.Windows.Forms.Label();
            this.panel96 = new System.Windows.Forms.Panel();
            this.label141 = new System.Windows.Forms.Label();
            this.panel97 = new System.Windows.Forms.Panel();
            this.label142 = new System.Windows.Forms.Label();
            this.panel98 = new System.Windows.Forms.Panel();
            this.label143 = new System.Windows.Forms.Label();
            this.alertsMasteryEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.userInfoUsernameLabel = new System.Windows.Forms.Label();
            this.userInfoRankLabel = new System.Windows.Forms.Label();
            this.userInfoPointsLabel = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.userInfoTruePointsLabel = new System.Windows.Forms.Label();
            this.userInfoMottoLabel = new System.Windows.Forms.Label();
            this.userInfoRatioLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label29 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label34 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label33 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.userInfoAdvancedCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.userInfoValuesPanel = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.userInfoValuesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.userInfoValuesFontComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.userInfoBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.userInfoNamesLabel = new System.Windows.Forms.Label();
            this.userInfoNamesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.userInfoNamesFontComboBox = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.userInfoNamesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.userInfoNamesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.userInfoNamesOutlineLabel = new System.Windows.Forms.Label();
            this.userInfoNamesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.userInfoValuesOutlinePanel = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.userInfoValuesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.userInfoValuesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.userInfoValuesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.panel50 = new System.Windows.Forms.Panel();
            this.panel119 = new System.Windows.Forms.Panel();
            this.gameInfoGenreLabel = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.panel117 = new System.Windows.Forms.Panel();
            this.label89 = new System.Windows.Forms.Label();
            this.gameInfoReleasedLabel = new System.Windows.Forms.Label();
            this.panel118 = new System.Windows.Forms.Panel();
            this.label61 = new System.Windows.Forms.Label();
            this.gameInfoPublisherLabel = new System.Windows.Forms.Label();
            this.panel116 = new System.Windows.Forms.Panel();
            this.label57 = new System.Windows.Forms.Label();
            this.gameInfoDeveloperLabel = new System.Windows.Forms.Label();
            this.gameInfoTitleLabel = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.panel29 = new System.Windows.Forms.Panel();
            this.panel49 = new System.Windows.Forms.Panel();
            this.label88 = new System.Windows.Forms.Label();
            this.gameInfoReleasedCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoReleaseDateTextBox = new System.Windows.Forms.TextBox();
            this.panel48 = new System.Windows.Forms.Panel();
            this.label87 = new System.Windows.Forms.Label();
            this.gameInfoGenreCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoGenreTextBox = new System.Windows.Forms.TextBox();
            this.panel30 = new System.Windows.Forms.Panel();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.gameInfoDefaultButton = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel31 = new System.Windows.Forms.Panel();
            this.label67 = new System.Windows.Forms.Label();
            this.gameInfoTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoTitleTextBox = new System.Windows.Forms.TextBox();
            this.panel32 = new System.Windows.Forms.Panel();
            this.label68 = new System.Windows.Forms.Label();
            this.gameInfoConsoleCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoConsoleTextBox = new System.Windows.Forms.TextBox();
            this.panel33 = new System.Windows.Forms.Panel();
            this.label69 = new System.Windows.Forms.Label();
            this.gameInfoPublisherTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoPublisherCheckBox = new System.Windows.Forms.CheckBox();
            this.panel34 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.gameInfoDeveloperTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoDeveloperCheckBox = new System.Windows.Forms.CheckBox();
            this.panel35 = new System.Windows.Forms.Panel();
            this.label71 = new System.Windows.Forms.Label();
            this.panel42 = new System.Windows.Forms.Panel();
            this.gameInfoAdvancedCheckBox = new System.Windows.Forms.CheckBox();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.gameInfoOpenWindowButton = new System.Windows.Forms.Button();
            this.gameInfoValuesPanel = new System.Windows.Forms.Panel();
            this.label82 = new System.Windows.Forms.Label();
            this.gameInfoValuesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoValuesFontComboBox = new System.Windows.Forms.ComboBox();
            this.gameInfoAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.panel44 = new System.Windows.Forms.Panel();
            this.gameInfoBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label83 = new System.Windows.Forms.Label();
            this.panel45 = new System.Windows.Forms.Panel();
            this.gameInfoNamesLabel = new System.Windows.Forms.Label();
            this.gameInfoNamesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoNamesFontComboBox = new System.Windows.Forms.ComboBox();
            this.panel46 = new System.Windows.Forms.Panel();
            this.gameInfoNamesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameInfoNamesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoNamesOutlineLabel = new System.Windows.Forms.Label();
            this.gameInfoNamesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoValuesOutlinePanel = new System.Windows.Forms.Panel();
            this.label86 = new System.Windows.Forms.Label();
            this.gameInfoValuesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoValuesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameInfoValuesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.panel28 = new System.Windows.Forms.Panel();
            this.gameProgressPointsTextLabel = new System.Windows.Forms.Label();
            this.gameProgressHardcoreWorthLabel = new System.Windows.Forms.Label();
            this.gameProgressPoints2Label = new System.Windows.Forms.Label();
            this.gameProgressTruePoints2Label = new System.Windows.Forms.Label();
            this.gameProgressAchievements2Label = new System.Windows.Forms.Label();
            this.gameProgressHaveEarnedLabel = new System.Windows.Forms.Label();
            this.gameProgressPercentCompletePictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressMasteryPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.gameProgressAchievements1Label = new System.Windows.Forms.Label();
            this.gameProgressPoints1Label = new System.Windows.Forms.Label();
            this.gameProgressCompletedLabel = new System.Windows.Forms.Label();
            this.gameProgressTruePoints1Label = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label38 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.gameProgressAdvancedCheckBox = new System.Windows.Forms.CheckBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.gameProgressOpenWindowButton = new System.Windows.Forms.Button();
            this.gameProgressValuesPanel = new System.Windows.Forms.Panel();
            this.label46 = new System.Windows.Forms.Label();
            this.gameProgressValuesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressValuesFontComboBox = new System.Windows.Forms.ComboBox();
            this.gameProgressAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.gameProgressBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label47 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.gameProgressNamesLabel = new System.Windows.Forms.Label();
            this.gameProgressNamesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressNamesFontComboBox = new System.Windows.Forms.ComboBox();
            this.panel23 = new System.Windows.Forms.Panel();
            this.gameProgressNamesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameProgressNamesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressNamesOutlineLabel = new System.Windows.Forms.Label();
            this.gameProgressNamesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressValuesOutlinePanel = new System.Windows.Forms.Panel();
            this.label50 = new System.Windows.Forms.Label();
            this.gameProgressValuesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressValuesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameProgressValuesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.panel36 = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.label55 = new System.Windows.Forms.Label();
            this.gameProgressRadioButtonPeriod = new System.Windows.Forms.RadioButton();
            this.label54 = new System.Windows.Forms.Label();
            this.gameProgressRadioButtonColon = new System.Windows.Forms.RadioButton();
            this.label53 = new System.Windows.Forms.Label();
            this.gameProgressRadioButtonBackslash = new System.Windows.Forms.RadioButton();
            this.label51 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panel37 = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.label52 = new System.Windows.Forms.Label();
            this.gameProgressCompletedTextBox = new System.Windows.Forms.TextBox();
            this.gameProgressCompletedCheckBox = new System.Windows.Forms.CheckBox();
            this.label73 = new System.Windows.Forms.Label();
            this.gameProgressDefaultButton = new System.Windows.Forms.Button();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.panel38 = new System.Windows.Forms.Panel();
            this.label74 = new System.Windows.Forms.Label();
            this.gameProgressAchievementsCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressAchievementsTextBox = new System.Windows.Forms.TextBox();
            this.panel39 = new System.Windows.Forms.Panel();
            this.label75 = new System.Windows.Forms.Label();
            this.gameProgressRatioCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressRatioTextBox = new System.Windows.Forms.TextBox();
            this.panel40 = new System.Windows.Forms.Panel();
            this.label76 = new System.Windows.Forms.Label();
            this.gameProgressTruePointsTextBox = new System.Windows.Forms.TextBox();
            this.gameProgressTruePointsCheckBox = new System.Windows.Forms.CheckBox();
            this.panel41 = new System.Windows.Forms.Panel();
            this.label77 = new System.Windows.Forms.Label();
            this.gameProgressPointsTextBox = new System.Windows.Forms.TextBox();
            this.gameProgressPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.panel113 = new System.Windows.Forms.Panel();
            this.label155 = new System.Windows.Forms.Label();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.recentAchievementsAutoScrollCheckBox = new System.Windows.Forms.CheckBox();
            this.panel99 = new System.Windows.Forms.Panel();
            this.recentAchievementsLinePanel = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.recentAchievementsLineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel101 = new System.Windows.Forms.Panel();
            this.recentAchievementsBorderCheckBox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsBorderColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.recentAchievementsPointsPanel = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.recentAchievementsPointsFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsPointsFontComboBox = new System.Windows.Forms.ComboBox();
            this.panel103 = new System.Windows.Forms.Panel();
            this.recentAchievementsAdvancedCheckBox = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel104 = new System.Windows.Forms.Panel();
            this.recentAchievementsTitleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.recentAchievementsTitleFontOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsTitleOutlineLabel = new System.Windows.Forms.Label();
            this.recentAchievementsTitleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsOpenWindowButton = new System.Windows.Forms.Button();
            this.recentAchievementsDescriptionOutlinePanel = new System.Windows.Forms.Panel();
            this.label144 = new System.Windows.Forms.Label();
            this.recentAchievementsDateFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsDescriptionFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.recentAchievementsDateFontOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsDescriptionPanel = new System.Windows.Forms.Panel();
            this.label145 = new System.Windows.Forms.Label();
            this.recentAchievementsDateFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsDescriptionFontComboBox = new System.Windows.Forms.ComboBox();
            this.recentAchievementsAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.pictureBox23 = new System.Windows.Forms.PictureBox();
            this.panel107 = new System.Windows.Forms.Panel();
            this.recentAchievementsBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label146 = new System.Windows.Forms.Label();
            this.panel108 = new System.Windows.Forms.Panel();
            this.recentAchievementsTitleLabel = new System.Windows.Forms.Label();
            this.recentAchievementsTitleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsTitleFontComboBox = new System.Windows.Forms.ComboBox();
            this.recentAchievementsPointsOutlinePanel = new System.Windows.Forms.Panel();
            this.recentAchievementsPointsFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.recentAchievementsPointsFontOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.label148 = new System.Windows.Forms.Label();
            this.recentAchievementsPointsFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsLineOutlinePanel = new System.Windows.Forms.Panel();
            this.label149 = new System.Windows.Forms.Label();
            this.recentAchievementsLineOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsLineOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.recentAchievementsLineOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.panel115 = new System.Windows.Forms.Panel();
            this.label152 = new System.Windows.Forms.Label();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.achievementListAutoScrollCheckBox = new System.Windows.Forms.CheckBox();
            this.panel111 = new System.Windows.Forms.Panel();
            this.label150 = new System.Windows.Forms.Label();
            this.panel112 = new System.Windows.Forms.Panel();
            this.label151 = new System.Windows.Forms.Label();
            this.achievementListOpenWindowButton = new System.Windows.Forms.Button();
            this.achievementListAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.panel114 = new System.Windows.Forms.Panel();
            this.achievementListBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label156 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel120 = new System.Windows.Forms.Panel();
            this.relatedMediaRAScreenshotRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaRABadgeIconRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaRABoxArtRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaRATitleScreenRadioButton = new System.Windows.Forms.RadioButton();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel121 = new System.Windows.Forms.Panel();
            this.label90 = new System.Windows.Forms.Label();
            this.panel122 = new System.Windows.Forms.Panel();
            this.label91 = new System.Windows.Forms.Label();
            this.relatedMediaOpenWindowButton = new System.Windows.Forms.Button();
            this.relatedMediaAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.panel123 = new System.Windows.Forms.Panel();
            this.relatedMediaBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label92 = new System.Windows.Forms.Label();
            this.panel124 = new System.Windows.Forms.Panel();
            this.relatedMediaLBCartFrontRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaLBCartBackRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaLBBoxBackReconRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaLBBoxFullRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaLBBoxSpineRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaLBClearLogoRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaLBBannerRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaLBTitleScreenRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaSetLaunchBoxPathButton = new System.Windows.Forms.Button();
            this.relatedMediaLBBoxFrontReconRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaLBBoxFrontRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaLBBoxBackRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaLBBox3DRadioButton = new System.Windows.Forms.RadioButton();
            this.relatedMediaLBLinePictureBox = new System.Windows.Forms.PictureBox();
            this.relatedMediaLBLabel = new System.Windows.Forms.Label();
            this.tabControlExtra1 = new TradeWright.UI.Forms.TabControlExtra();
            this.focusTabPage = new System.Windows.Forms.TabPage();
            this.alertsTabPage2 = new System.Windows.Forms.TabPage();
            this.tabControlExtra2 = new TradeWright.UI.Forms.TabControlExtra();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.userInfoTabPage = new System.Windows.Forms.TabPage();
            this.gameInfoTabPage = new System.Windows.Forms.TabPage();
            this.gameProgressTabPage = new System.Windows.Forms.TabPage();
            this.recentCheevosTabPage = new System.Windows.Forms.TabPage();
            this.cheevosListTabPage = new System.Windows.Forms.TabPage();
            this.relatedMediaTabPage = new System.Windows.Forms.TabPage();
            this.browserTabPage = new System.Windows.Forms.TabPage();
            this.panel126 = new System.Windows.Forms.Panel();
            this.label95 = new System.Windows.Forms.Label();
            this.pictureBox27 = new System.Windows.Forms.PictureBox();
            this.panel125 = new System.Windows.Forms.Panel();
            this.label94 = new System.Windows.Forms.Label();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.raConnectionStatusPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementScaleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementOutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementOutSpeedUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementInNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementInSpeedUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryScaleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryOutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryOutSpeedUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryInNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryInSpeedUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsMaxListNumericUpDown)).BeginInit();
            this.panel64.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.panel63.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel51.SuspendLayout();
            this.focusLinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusLineColorPictureBox)).BeginInit();
            this.panel59.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusBorderColorPictureBox)).BeginInit();
            this.focusPointsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontColorPictureBox)).BeginInit();
            this.panel52.SuspendLayout();
            this.panel61.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontOutlineColorPictureBox)).BeginInit();
            this.focusDescriptionOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontOutlineNumericUpDown)).BeginInit();
            this.focusDescriptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.panel54.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusBackgroundColorPictureBox)).BeginInit();
            this.panel55.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontColorPictureBox)).BeginInit();
            this.focusPointsOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontOutlineColorPictureBox)).BeginInit();
            this.focusLineOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusLineOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusLineOutlineNumericUpDown)).BeginInit();
            this.panel65.SuspendLayout();
            this.alertsLinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsLineColorPictureBox)).BeginInit();
            this.panel67.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsBorderColorPictureBox)).BeginInit();
            this.alertsPointsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsPointsFontColorPictureBox)).BeginInit();
            this.panel69.SuspendLayout();
            this.panel70.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsTitleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsTitleFontOutlineColorPictureBox)).BeginInit();
            this.alertsDescriptionOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsDescriptionFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsDescriptionFontOutlineNumericUpDown)).BeginInit();
            this.alertsDescriptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsDescriptionFontColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            this.panel73.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsBackgroundColorPictureBox)).BeginInit();
            this.panel74.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsTitleFontColorPictureBox)).BeginInit();
            this.alertsPointsOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsPointsFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsPointsFontOutlineColorPictureBox)).BeginInit();
            this.alertsLineOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsLineOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsLineOutlineNumericUpDown)).BeginInit();
            this.alertsCustomAchievementPanel.SuspendLayout();
            this.panel85.SuspendLayout();
            this.panel84.SuspendLayout();
            this.panel86.SuspendLayout();
            this.panel83.SuspendLayout();
            this.panel87.SuspendLayout();
            this.panel78.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            this.panel79.SuspendLayout();
            this.panel80.SuspendLayout();
            this.panel81.SuspendLayout();
            this.panel82.SuspendLayout();
            this.alertsCustomMasteryPanel.SuspendLayout();
            this.panel89.SuspendLayout();
            this.panel90.SuspendLayout();
            this.panel91.SuspendLayout();
            this.panel92.SuspendLayout();
            this.panel93.SuspendLayout();
            this.panel94.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.panel95.SuspendLayout();
            this.panel96.SuspendLayout();
            this.panel97.SuspendLayout();
            this.panel98.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel21.SuspendLayout();
            this.panel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel4.SuspendLayout();
            this.userInfoValuesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBackgroundColorPictureBox)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontColorPictureBox)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontOutlineColorPictureBox)).BeginInit();
            this.userInfoValuesOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontOutlineNumericUpDown)).BeginInit();
            this.panel50.SuspendLayout();
            this.panel119.SuspendLayout();
            this.panel117.SuspendLayout();
            this.panel118.SuspendLayout();
            this.panel116.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel29.SuspendLayout();
            this.panel49.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel31.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel42.SuspendLayout();
            this.gameInfoValuesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panel44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoBackgroundColorPictureBox)).BeginInit();
            this.panel45.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontColorPictureBox)).BeginInit();
            this.panel46.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontOutlineColorPictureBox)).BeginInit();
            this.gameInfoValuesOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontOutlineNumericUpDown)).BeginInit();
            this.panel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressPercentCompletePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressMasteryPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.gameProgressValuesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressBackgroundColorPictureBox)).BeginInit();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontColorPictureBox)).BeginInit();
            this.panel23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontOutlineColorPictureBox)).BeginInit();
            this.gameProgressValuesOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontOutlineNumericUpDown)).BeginInit();
            this.panel36.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            this.panel38.SuspendLayout();
            this.panel39.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel113.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.panel99.SuspendLayout();
            this.recentAchievementsLinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineColorPictureBox)).BeginInit();
            this.panel101.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsBorderColorPictureBox)).BeginInit();
            this.recentAchievementsPointsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontColorPictureBox)).BeginInit();
            this.panel103.SuspendLayout();
            this.panel104.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontOutlineColorPictureBox)).BeginInit();
            this.recentAchievementsDescriptionOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDateFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDescriptionFontOutlineNumericUpDown)).BeginInit();
            this.recentAchievementsDescriptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDateFontColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).BeginInit();
            this.panel107.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsBackgroundColorPictureBox)).BeginInit();
            this.panel108.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontColorPictureBox)).BeginInit();
            this.recentAchievementsPointsOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontOutlineColorPictureBox)).BeginInit();
            this.recentAchievementsLineOutlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineOutlineNumericUpDown)).BeginInit();
            this.panel115.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            this.panel111.SuspendLayout();
            this.panel112.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            this.panel114.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.achievementListBackgroundColorPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel120.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            this.panel121.SuspendLayout();
            this.panel122.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            this.panel123.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.relatedMediaBackgroundColorPictureBox)).BeginInit();
            this.panel124.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.relatedMediaLBLinePictureBox)).BeginInit();
            this.tabControlExtra1.SuspendLayout();
            this.focusTabPage.SuspendLayout();
            this.alertsTabPage2.SuspendLayout();
            this.tabControlExtra2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.userInfoTabPage.SuspendLayout();
            this.gameInfoTabPage.SuspendLayout();
            this.gameProgressTabPage.SuspendLayout();
            this.recentCheevosTabPage.SuspendLayout();
            this.cheevosListTabPage.SuspendLayout();
            this.relatedMediaTabPage.SuspendLayout();
            this.browserTabPage.SuspendLayout();
            this.panel126.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).BeginInit();
            this.panel125.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            this.SuspendLayout();
            // 
            // apiKeyLabel
            // 
            this.apiKeyLabel.AutoSize = true;
            this.apiKeyLabel.BackColor = System.Drawing.Color.Transparent;
            this.apiKeyLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.apiKeyLabel.Location = new System.Drawing.Point(13, 4);
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(91, 16);
            this.apiKeyLabel.TabIndex = 31;
            this.apiKeyLabel.Text = "Web API Key";
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.apiKeyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apiKeyTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyTextBox.Location = new System.Drawing.Point(108, 2);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.PasswordChar = '*';
            this.apiKeyTextBox.Size = new System.Drawing.Size(286, 23);
            this.apiKeyTextBox.TabIndex = 1;
            this.apiKeyTextBox.WordWrap = false;
            this.apiKeyTextBox.TextChanged += new System.EventHandler(this.RequiredField_TextChanged);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.usernameLabel.Location = new System.Drawing.Point(33, 5);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(71, 16);
            this.usernameLabel.TabIndex = 26;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(108, 3);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(286, 23);
            this.usernameTextBox.TabIndex = 0;
            this.usernameTextBox.WordWrap = false;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.RequiredField_TextChanged);
            // 
            // userProfilePictureBox
            // 
            this.userProfilePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userProfilePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.userProfilePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userProfilePictureBox.Location = new System.Drawing.Point(384, 40);
            this.userProfilePictureBox.Name = "userProfilePictureBox";
            this.userProfilePictureBox.Size = new System.Drawing.Size(64, 64);
            this.userProfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userProfilePictureBox.TabIndex = 20;
            this.userProfilePictureBox.TabStop = false;
            this.userProfilePictureBox.Click += new System.EventHandler(this.BrowserSensitiveControl_Click);
            // 
            // autoStartCheckbox
            // 
            this.autoStartCheckbox.AutoSize = true;
            this.autoStartCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.autoStartCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.autoStartCheckbox.FlatAppearance.BorderSize = 0;
            this.autoStartCheckbox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.autoStartCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoStartCheckbox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoStartCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.autoStartCheckbox.Location = new System.Drawing.Point(111, 67);
            this.autoStartCheckbox.Name = "autoStartCheckbox";
            this.autoStartCheckbox.Size = new System.Drawing.Size(88, 18);
            this.autoStartCheckbox.TabIndex = 2;
            this.autoStartCheckbox.Text = "Auto-Start";
            this.autoStartCheckbox.UseVisualStyleBackColor = false;
            this.autoStartCheckbox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.stopButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.stopButton.Location = new System.Drawing.Point(322, 63);
            this.stopButton.Margin = new System.Windows.Forms.Padding(0);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 27);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // timerStatusLabel
            // 
            this.timerStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.timerStatusLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.timerStatusLabel.Location = new System.Drawing.Point(12, 76);
            this.timerStatusLabel.Name = "timerStatusLabel";
            this.timerStatusLabel.Size = new System.Drawing.Size(323, 29);
            this.timerStatusLabel.TabIndex = 10024;
            this.timerStatusLabel.Text = "Offline";
            this.timerStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userInfoAutoOpenWindowCheckbox
            // 
            this.userInfoAutoOpenWindowCheckbox.AutoSize = true;
            this.userInfoAutoOpenWindowCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userInfoAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoAutoOpenWindowCheckbox.Location = new System.Drawing.Point(252, 9);
            this.userInfoAutoOpenWindowCheckbox.Name = "userInfoAutoOpenWindowCheckbox";
            this.userInfoAutoOpenWindowCheckbox.Size = new System.Drawing.Size(98, 20);
            this.userInfoAutoOpenWindowCheckbox.TabIndex = 10022;
            this.userInfoAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.userInfoAutoOpenWindowCheckbox.UseVisualStyleBackColor = true;
            this.userInfoAutoOpenWindowCheckbox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // userInfoOpenWindowButton
            // 
            this.userInfoOpenWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoOpenWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.userInfoOpenWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userInfoOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoOpenWindowButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.userInfoOpenWindowButton.Location = new System.Drawing.Point(382, 2);
            this.userInfoOpenWindowButton.Margin = new System.Windows.Forms.Padding(0);
            this.userInfoOpenWindowButton.Name = "userInfoOpenWindowButton";
            this.userInfoOpenWindowButton.Size = new System.Drawing.Size(75, 27);
            this.userInfoOpenWindowButton.TabIndex = 10021;
            this.userInfoOpenWindowButton.Text = "Open";
            this.userInfoOpenWindowButton.UseVisualStyleBackColor = false;
            this.userInfoOpenWindowButton.Click += new System.EventHandler(this.ShowWindowButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.startButton.Location = new System.Drawing.Point(247, 63);
            this.startButton.Margin = new System.Windows.Forms.Padding(0);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 27);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // focusAchievementPictureBox
            // 
            this.focusAchievementPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.focusAchievementPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.focusAchievementPictureBox.InitialImage = null;
            this.focusAchievementPictureBox.Location = new System.Drawing.Point(3, 40);
            this.focusAchievementPictureBox.Name = "focusAchievementPictureBox";
            this.focusAchievementPictureBox.Size = new System.Drawing.Size(112, 112);
            this.focusAchievementPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.focusAchievementPictureBox.TabIndex = 10030;
            this.focusAchievementPictureBox.TabStop = false;
            this.focusAchievementPictureBox.Click += new System.EventHandler(this.BrowserSensitiveControl_Click);
            // 
            // focusAchievementTitleLabel
            // 
            this.focusAchievementTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.focusAchievementTitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.focusAchievementTitleLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.focusAchievementTitleLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusAchievementTitleLabel.Location = new System.Drawing.Point(121, 40);
            this.focusAchievementTitleLabel.Name = "focusAchievementTitleLabel";
            this.focusAchievementTitleLabel.Size = new System.Drawing.Size(165, 112);
            this.focusAchievementTitleLabel.TabIndex = 10027;
            this.focusAchievementTitleLabel.Click += new System.EventHandler(this.BrowserSensitiveControl_Click);
            // 
            // focusAchievementDescriptionLabel
            // 
            this.focusAchievementDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.focusAchievementDescriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.focusAchievementDescriptionLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusAchievementDescriptionLabel.Location = new System.Drawing.Point(2, 155);
            this.focusAchievementDescriptionLabel.Name = "focusAchievementDescriptionLabel";
            this.focusAchievementDescriptionLabel.Size = new System.Drawing.Size(284, 106);
            this.focusAchievementDescriptionLabel.TabIndex = 10026;
            // 
            // focusSetButton
            // 
            this.focusSetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.focusSetButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.focusSetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.focusSetButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusSetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusSetButton.Location = new System.Drawing.Point(211, 263);
            this.focusSetButton.Name = "focusSetButton";
            this.focusSetButton.Size = new System.Drawing.Size(75, 27);
            this.focusSetButton.TabIndex = 10031;
            this.focusSetButton.Text = "Set";
            this.focusSetButton.UseVisualStyleBackColor = false;
            this.focusSetButton.Click += new System.EventHandler(this.SetFocusButton_Click);
            // 
            // focusAchievementButtonPrevious
            // 
            this.focusAchievementButtonPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.focusAchievementButtonPrevious.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.focusAchievementButtonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.focusAchievementButtonPrevious.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusAchievementButtonPrevious.Location = new System.Drawing.Point(4, 263);
            this.focusAchievementButtonPrevious.Name = "focusAchievementButtonPrevious";
            this.focusAchievementButtonPrevious.Size = new System.Drawing.Size(75, 27);
            this.focusAchievementButtonPrevious.TabIndex = 10028;
            this.focusAchievementButtonPrevious.Text = "<";
            this.focusAchievementButtonPrevious.UseVisualStyleBackColor = false;
            this.focusAchievementButtonPrevious.Click += new System.EventHandler(this.MoveFocusIndexPrev_Click);
            // 
            // focusAchievementButtonNext
            // 
            this.focusAchievementButtonNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.focusAchievementButtonNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.focusAchievementButtonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.focusAchievementButtonNext.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusAchievementButtonNext.Location = new System.Drawing.Point(85, 263);
            this.focusAchievementButtonNext.Name = "focusAchievementButtonNext";
            this.focusAchievementButtonNext.Size = new System.Drawing.Size(75, 27);
            this.focusAchievementButtonNext.TabIndex = 10029;
            this.focusAchievementButtonNext.Text = ">";
            this.focusAchievementButtonNext.UseVisualStyleBackColor = false;
            this.focusAchievementButtonNext.Click += new System.EventHandler(this.MoveFocusIndexNext_Click);
            // 
            // gameInfoPictureBox
            // 
            this.gameInfoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameInfoPictureBox.InitialImage = null;
            this.gameInfoPictureBox.Location = new System.Drawing.Point(8, 52);
            this.gameInfoPictureBox.Name = "gameInfoPictureBox";
            this.gameInfoPictureBox.Size = new System.Drawing.Size(96, 96);
            this.gameInfoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameInfoPictureBox.TabIndex = 10004;
            this.gameInfoPictureBox.TabStop = false;
            this.gameInfoPictureBox.Click += new System.EventHandler(this.BrowserSensitiveControl_Click);
            // 
            // rssFeedFriendCheckBox
            // 
            this.rssFeedFriendCheckBox.AutoSize = true;
            this.rssFeedFriendCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedFriendCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedFriendCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.rssFeedFriendCheckBox.Location = new System.Drawing.Point(119, 63);
            this.rssFeedFriendCheckBox.Name = "rssFeedFriendCheckBox";
            this.rssFeedFriendCheckBox.Size = new System.Drawing.Size(77, 17);
            this.rssFeedFriendCheckBox.TabIndex = 10010;
            this.rssFeedFriendCheckBox.Text = "FRIENDS";
            this.rssFeedFriendCheckBox.UseVisualStyleBackColor = false;
            // 
            // rssFeedCheevoCheckBox
            // 
            this.rssFeedCheevoCheckBox.AutoSize = true;
            this.rssFeedCheevoCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedCheevoCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedCheevoCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.rssFeedCheevoCheckBox.Location = new System.Drawing.Point(119, 40);
            this.rssFeedCheevoCheckBox.Name = "rssFeedCheevoCheckBox";
            this.rssFeedCheevoCheckBox.Size = new System.Drawing.Size(74, 17);
            this.rssFeedCheevoCheckBox.TabIndex = 10011;
            this.rssFeedCheevoCheckBox.Text = "CHEEVO";
            this.rssFeedCheevoCheckBox.UseVisualStyleBackColor = false;
            // 
            // rssFeedNewsCheckBox
            // 
            this.rssFeedNewsCheckBox.AutoSize = true;
            this.rssFeedNewsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedNewsCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedNewsCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.rssFeedNewsCheckBox.Location = new System.Drawing.Point(3, 40);
            this.rssFeedNewsCheckBox.Name = "rssFeedNewsCheckBox";
            this.rssFeedNewsCheckBox.Size = new System.Drawing.Size(60, 17);
            this.rssFeedNewsCheckBox.TabIndex = 10012;
            this.rssFeedNewsCheckBox.Text = "NEWS";
            this.rssFeedNewsCheckBox.UseVisualStyleBackColor = false;
            // 
            // rssFeedForumCheckBox
            // 
            this.rssFeedForumCheckBox.AutoSize = true;
            this.rssFeedForumCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedForumCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedForumCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.rssFeedForumCheckBox.Location = new System.Drawing.Point(3, 63);
            this.rssFeedForumCheckBox.Name = "rssFeedForumCheckBox";
            this.rssFeedForumCheckBox.Size = new System.Drawing.Size(66, 17);
            this.rssFeedForumCheckBox.TabIndex = 10009;
            this.rssFeedForumCheckBox.Text = "FORUM";
            this.rssFeedForumCheckBox.UseVisualStyleBackColor = false;
            // 
            // rssFeedListView
            // 
            this.rssFeedListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.rssFeedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.rssFeedListView.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.rssFeedListView.HideSelection = false;
            this.rssFeedListView.Location = new System.Drawing.Point(2, 86);
            this.rssFeedListView.Name = "rssFeedListView";
            this.rssFeedListView.Size = new System.Drawing.Size(283, 273);
            this.rssFeedListView.TabIndex = 10006;
            this.rssFeedListView.UseCompatibleStateImageBehavior = false;
            this.rssFeedListView.View = System.Windows.Forms.View.Details;
            this.rssFeedListView.Click += new System.EventHandler(this.BrowserSensitiveControl_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 400;
            // 
            // raConnectionStatusPictureBox
            // 
            this.raConnectionStatusPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.raConnectionStatusPictureBox.Image = global::Retro_Achievement_Tracker.Properties.Resources.red_button;
            this.raConnectionStatusPictureBox.Location = new System.Drawing.Point(341, 76);
            this.raConnectionStatusPictureBox.Name = "raConnectionStatusPictureBox";
            this.raConnectionStatusPictureBox.Size = new System.Drawing.Size(28, 28);
            this.raConnectionStatusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.raConnectionStatusPictureBox.TabIndex = 10025;
            this.raConnectionStatusPictureBox.TabStop = false;
            // 
            // alertsPlayAchievementButton
            // 
            this.alertsPlayAchievementButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsPlayAchievementButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.alertsPlayAchievementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alertsPlayAchievementButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsPlayAchievementButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.alertsPlayAchievementButton.Location = new System.Drawing.Point(212, 3);
            this.alertsPlayAchievementButton.Name = "alertsPlayAchievementButton";
            this.alertsPlayAchievementButton.Size = new System.Drawing.Size(65, 25);
            this.alertsPlayAchievementButton.TabIndex = 2;
            this.alertsPlayAchievementButton.Text = "Play";
            this.alertsPlayAchievementButton.UseVisualStyleBackColor = false;
            this.alertsPlayAchievementButton.Click += new System.EventHandler(this.ShowAlertButton_Click);
            // 
            // alertsSelectCustomAchievementFileButton
            // 
            this.alertsSelectCustomAchievementFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsSelectCustomAchievementFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.alertsSelectCustomAchievementFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alertsSelectCustomAchievementFileButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsSelectCustomAchievementFileButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.alertsSelectCustomAchievementFileButton.Location = new System.Drawing.Point(209, 266);
            this.alertsSelectCustomAchievementFileButton.Name = "alertsSelectCustomAchievementFileButton";
            this.alertsSelectCustomAchievementFileButton.Size = new System.Drawing.Size(65, 25);
            this.alertsSelectCustomAchievementFileButton.TabIndex = 14;
            this.alertsSelectCustomAchievementFileButton.Text = "File";
            this.alertsSelectCustomAchievementFileButton.UseVisualStyleBackColor = false;
            this.alertsSelectCustomAchievementFileButton.Click += new System.EventHandler(this.SelectCustomAlertButton_Click);
            // 
            // alertsCustomAchievementScaleNumericUpDown
            // 
            this.alertsCustomAchievementScaleNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.alertsCustomAchievementScaleNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomAchievementScaleNumericUpDown.DecimalPlaces = 2;
            this.alertsCustomAchievementScaleNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsCustomAchievementScaleNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomAchievementScaleNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.alertsCustomAchievementScaleNumericUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomAchievementScaleNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.alertsCustomAchievementScaleNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.alertsCustomAchievementScaleNumericUpDown.Name = "alertsCustomAchievementScaleNumericUpDown";
            this.alertsCustomAchievementScaleNumericUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomAchievementScaleNumericUpDown.TabIndex = 20;
            this.alertsCustomAchievementScaleNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alertsCustomAchievementScaleNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomAchievementXNumericUpDown
            // 
            this.alertsCustomAchievementXNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.alertsCustomAchievementXNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomAchievementXNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsCustomAchievementXNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomAchievementXNumericUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomAchievementXNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.alertsCustomAchievementXNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.alertsCustomAchievementXNumericUpDown.Name = "alertsCustomAchievementXNumericUpDown";
            this.alertsCustomAchievementXNumericUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomAchievementXNumericUpDown.TabIndex = 15;
            this.alertsCustomAchievementXNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomAchievementYNumericUpDown
            // 
            this.alertsCustomAchievementYNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.alertsCustomAchievementYNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomAchievementYNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsCustomAchievementYNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomAchievementYNumericUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomAchievementYNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.alertsCustomAchievementYNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.alertsCustomAchievementYNumericUpDown.Name = "alertsCustomAchievementYNumericUpDown";
            this.alertsCustomAchievementYNumericUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomAchievementYNumericUpDown.TabIndex = 16;
            this.alertsCustomAchievementYNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsAchievementEditOutlineCheckbox
            // 
            this.alertsAchievementEditOutlineCheckbox.AutoSize = true;
            this.alertsAchievementEditOutlineCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsAchievementEditOutlineCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsAchievementEditOutlineCheckbox.Location = new System.Drawing.Point(8, 269);
            this.alertsAchievementEditOutlineCheckbox.Name = "alertsAchievementEditOutlineCheckbox";
            this.alertsAchievementEditOutlineCheckbox.Size = new System.Drawing.Size(91, 20);
            this.alertsAchievementEditOutlineCheckbox.TabIndex = 47;
            this.alertsAchievementEditOutlineCheckbox.Text = "Edit Mode";
            this.alertsAchievementEditOutlineCheckbox.UseVisualStyleBackColor = true;
            this.alertsAchievementEditOutlineCheckbox.CheckedChanged += new System.EventHandler(this.CustomAlertsCheckBox_CheckedChanged);
            // 
            // alertsCustomAchievementOutNumericUpDown
            // 
            this.alertsCustomAchievementOutNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.alertsCustomAchievementOutNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomAchievementOutNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsCustomAchievementOutNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomAchievementOutNumericUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomAchievementOutNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.alertsCustomAchievementOutNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.alertsCustomAchievementOutNumericUpDown.Name = "alertsCustomAchievementOutNumericUpDown";
            this.alertsCustomAchievementOutNumericUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomAchievementOutNumericUpDown.TabIndex = 26;
            this.alertsCustomAchievementOutNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.alertsCustomAchievementOutNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomAchievementAnimationOutComboBox
            // 
            this.alertsCustomAchievementAnimationOutComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsCustomAchievementAnimationOutComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsCustomAchievementAnimationOutComboBox.ForeColor = System.Drawing.Color.White;
            this.alertsCustomAchievementAnimationOutComboBox.FormattingEnabled = true;
            this.alertsCustomAchievementAnimationOutComboBox.Location = new System.Drawing.Point(168, 1);
            this.alertsCustomAchievementAnimationOutComboBox.Name = "alertsCustomAchievementAnimationOutComboBox";
            this.alertsCustomAchievementAnimationOutComboBox.Size = new System.Drawing.Size(97, 21);
            this.alertsCustomAchievementAnimationOutComboBox.TabIndex = 39;
            this.alertsCustomAchievementAnimationOutComboBox.SelectedIndexChanged += new System.EventHandler(this.NotificationAnimationComboBox_SelectedIndexChanged);
            // 
            // alertsCustomAchievementOutSpeedUpDown
            // 
            this.alertsCustomAchievementOutSpeedUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.alertsCustomAchievementOutSpeedUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomAchievementOutSpeedUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsCustomAchievementOutSpeedUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomAchievementOutSpeedUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomAchievementOutSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.alertsCustomAchievementOutSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.alertsCustomAchievementOutSpeedUpDown.Name = "alertsCustomAchievementOutSpeedUpDown";
            this.alertsCustomAchievementOutSpeedUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomAchievementOutSpeedUpDown.TabIndex = 48;
            this.alertsCustomAchievementOutSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.alertsCustomAchievementOutSpeedUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomAchievementInNumericUpDown
            // 
            this.alertsCustomAchievementInNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.alertsCustomAchievementInNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomAchievementInNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsCustomAchievementInNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomAchievementInNumericUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomAchievementInNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.alertsCustomAchievementInNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.alertsCustomAchievementInNumericUpDown.Name = "alertsCustomAchievementInNumericUpDown";
            this.alertsCustomAchievementInNumericUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomAchievementInNumericUpDown.TabIndex = 26;
            this.alertsCustomAchievementInNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.alertsCustomAchievementInNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomAchievementAnimationInComboBox
            // 
            this.alertsCustomAchievementAnimationInComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsCustomAchievementAnimationInComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsCustomAchievementAnimationInComboBox.ForeColor = System.Drawing.Color.White;
            this.alertsCustomAchievementAnimationInComboBox.FormattingEnabled = true;
            this.alertsCustomAchievementAnimationInComboBox.Location = new System.Drawing.Point(168, 1);
            this.alertsCustomAchievementAnimationInComboBox.Name = "alertsCustomAchievementAnimationInComboBox";
            this.alertsCustomAchievementAnimationInComboBox.Size = new System.Drawing.Size(97, 21);
            this.alertsCustomAchievementAnimationInComboBox.TabIndex = 39;
            this.alertsCustomAchievementAnimationInComboBox.SelectedIndexChanged += new System.EventHandler(this.NotificationAnimationComboBox_SelectedIndexChanged);
            // 
            // alertsCustomAchievementInSpeedUpDown
            // 
            this.alertsCustomAchievementInSpeedUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.alertsCustomAchievementInSpeedUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomAchievementInSpeedUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsCustomAchievementInSpeedUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomAchievementInSpeedUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomAchievementInSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.alertsCustomAchievementInSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.alertsCustomAchievementInSpeedUpDown.Name = "alertsCustomAchievementInSpeedUpDown";
            this.alertsCustomAchievementInSpeedUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomAchievementInSpeedUpDown.TabIndex = 48;
            this.alertsCustomAchievementInSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.alertsCustomAchievementInSpeedUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomAchievementEnableCheckbox
            // 
            this.alertsCustomAchievementEnableCheckbox.AutoSize = true;
            this.alertsCustomAchievementEnableCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsCustomAchievementEnableCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsCustomAchievementEnableCheckbox.Location = new System.Drawing.Point(86, 6);
            this.alertsCustomAchievementEnableCheckbox.Name = "alertsCustomAchievementEnableCheckbox";
            this.alertsCustomAchievementEnableCheckbox.Size = new System.Drawing.Size(75, 20);
            this.alertsCustomAchievementEnableCheckbox.TabIndex = 13;
            this.alertsCustomAchievementEnableCheckbox.Text = "Custom";
            this.alertsCustomAchievementEnableCheckbox.UseVisualStyleBackColor = true;
            this.alertsCustomAchievementEnableCheckbox.CheckedChanged += new System.EventHandler(this.CustomAlertsCheckBox_CheckedChanged);
            // 
            // alertsPlayMasteryButton
            // 
            this.alertsPlayMasteryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsPlayMasteryButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.alertsPlayMasteryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alertsPlayMasteryButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsPlayMasteryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.alertsPlayMasteryButton.Location = new System.Drawing.Point(212, 3);
            this.alertsPlayMasteryButton.Name = "alertsPlayMasteryButton";
            this.alertsPlayMasteryButton.Size = new System.Drawing.Size(65, 25);
            this.alertsPlayMasteryButton.TabIndex = 2;
            this.alertsPlayMasteryButton.Text = "Play";
            this.alertsPlayMasteryButton.UseVisualStyleBackColor = false;
            this.alertsPlayMasteryButton.Click += new System.EventHandler(this.ShowAlertButton_Click);
            // 
            // alertsSelectCustomMasteryFileButton
            // 
            this.alertsSelectCustomMasteryFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsSelectCustomMasteryFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.alertsSelectCustomMasteryFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alertsSelectCustomMasteryFileButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsSelectCustomMasteryFileButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.alertsSelectCustomMasteryFileButton.Location = new System.Drawing.Point(209, 266);
            this.alertsSelectCustomMasteryFileButton.Name = "alertsSelectCustomMasteryFileButton";
            this.alertsSelectCustomMasteryFileButton.Size = new System.Drawing.Size(65, 25);
            this.alertsSelectCustomMasteryFileButton.TabIndex = 14;
            this.alertsSelectCustomMasteryFileButton.Text = "File";
            this.alertsSelectCustomMasteryFileButton.UseVisualStyleBackColor = false;
            this.alertsSelectCustomMasteryFileButton.Click += new System.EventHandler(this.SelectCustomAlertButton_Click);
            // 
            // alertsCustomMasteryScaleNumericUpDown
            // 
            this.alertsCustomMasteryScaleNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsCustomMasteryScaleNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomMasteryScaleNumericUpDown.DecimalPlaces = 2;
            this.alertsCustomMasteryScaleNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.alertsCustomMasteryScaleNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomMasteryScaleNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.alertsCustomMasteryScaleNumericUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomMasteryScaleNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.alertsCustomMasteryScaleNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.alertsCustomMasteryScaleNumericUpDown.Name = "alertsCustomMasteryScaleNumericUpDown";
            this.alertsCustomMasteryScaleNumericUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomMasteryScaleNumericUpDown.TabIndex = 20;
            this.alertsCustomMasteryScaleNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alertsCustomMasteryScaleNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomMasteryXNumericUpDown
            // 
            this.alertsCustomMasteryXNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsCustomMasteryXNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomMasteryXNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.alertsCustomMasteryXNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomMasteryXNumericUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomMasteryXNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.alertsCustomMasteryXNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.alertsCustomMasteryXNumericUpDown.Name = "alertsCustomMasteryXNumericUpDown";
            this.alertsCustomMasteryXNumericUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomMasteryXNumericUpDown.TabIndex = 15;
            this.alertsCustomMasteryXNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomMasteryYNumericUpDown
            // 
            this.alertsCustomMasteryYNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsCustomMasteryYNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomMasteryYNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.alertsCustomMasteryYNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomMasteryYNumericUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomMasteryYNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.alertsCustomMasteryYNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.alertsCustomMasteryYNumericUpDown.Name = "alertsCustomMasteryYNumericUpDown";
            this.alertsCustomMasteryYNumericUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomMasteryYNumericUpDown.TabIndex = 16;
            this.alertsCustomMasteryYNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsMasteryEditOutlineCheckbox
            // 
            this.alertsMasteryEditOutlineCheckbox.AutoSize = true;
            this.alertsMasteryEditOutlineCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsMasteryEditOutlineCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsMasteryEditOutlineCheckbox.Location = new System.Drawing.Point(8, 269);
            this.alertsMasteryEditOutlineCheckbox.Name = "alertsMasteryEditOutlineCheckbox";
            this.alertsMasteryEditOutlineCheckbox.Size = new System.Drawing.Size(91, 20);
            this.alertsMasteryEditOutlineCheckbox.TabIndex = 47;
            this.alertsMasteryEditOutlineCheckbox.Text = "Edit Mode";
            this.alertsMasteryEditOutlineCheckbox.UseVisualStyleBackColor = true;
            this.alertsMasteryEditOutlineCheckbox.CheckedChanged += new System.EventHandler(this.CustomAlertsCheckBox_CheckedChanged);
            // 
            // alertsCustomMasteryOutNumericUpDown
            // 
            this.alertsCustomMasteryOutNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsCustomMasteryOutNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomMasteryOutNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.alertsCustomMasteryOutNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomMasteryOutNumericUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomMasteryOutNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.alertsCustomMasteryOutNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.alertsCustomMasteryOutNumericUpDown.Name = "alertsCustomMasteryOutNumericUpDown";
            this.alertsCustomMasteryOutNumericUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomMasteryOutNumericUpDown.TabIndex = 26;
            this.alertsCustomMasteryOutNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.alertsCustomMasteryOutNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomMasteryAnimationOutComboBox
            // 
            this.alertsCustomMasteryAnimationOutComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsCustomMasteryAnimationOutComboBox.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.alertsCustomMasteryAnimationOutComboBox.ForeColor = System.Drawing.Color.White;
            this.alertsCustomMasteryAnimationOutComboBox.FormattingEnabled = true;
            this.alertsCustomMasteryAnimationOutComboBox.Location = new System.Drawing.Point(168, 1);
            this.alertsCustomMasteryAnimationOutComboBox.Name = "alertsCustomMasteryAnimationOutComboBox";
            this.alertsCustomMasteryAnimationOutComboBox.Size = new System.Drawing.Size(97, 21);
            this.alertsCustomMasteryAnimationOutComboBox.TabIndex = 39;
            this.alertsCustomMasteryAnimationOutComboBox.SelectedIndexChanged += new System.EventHandler(this.NotificationAnimationComboBox_SelectedIndexChanged);
            // 
            // alertsCustomMasteryOutSpeedUpDown
            // 
            this.alertsCustomMasteryOutSpeedUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsCustomMasteryOutSpeedUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomMasteryOutSpeedUpDown.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.alertsCustomMasteryOutSpeedUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomMasteryOutSpeedUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomMasteryOutSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.alertsCustomMasteryOutSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.alertsCustomMasteryOutSpeedUpDown.Name = "alertsCustomMasteryOutSpeedUpDown";
            this.alertsCustomMasteryOutSpeedUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomMasteryOutSpeedUpDown.TabIndex = 48;
            this.alertsCustomMasteryOutSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.alertsCustomMasteryOutSpeedUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomMasteryInNumericUpDown
            // 
            this.alertsCustomMasteryInNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsCustomMasteryInNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomMasteryInNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.alertsCustomMasteryInNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomMasteryInNumericUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomMasteryInNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.alertsCustomMasteryInNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.alertsCustomMasteryInNumericUpDown.Name = "alertsCustomMasteryInNumericUpDown";
            this.alertsCustomMasteryInNumericUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomMasteryInNumericUpDown.TabIndex = 26;
            this.alertsCustomMasteryInNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.alertsCustomMasteryInNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomMasteryAnimationInComboBox
            // 
            this.alertsCustomMasteryAnimationInComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsCustomMasteryAnimationInComboBox.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.alertsCustomMasteryAnimationInComboBox.ForeColor = System.Drawing.Color.White;
            this.alertsCustomMasteryAnimationInComboBox.FormattingEnabled = true;
            this.alertsCustomMasteryAnimationInComboBox.Location = new System.Drawing.Point(168, 1);
            this.alertsCustomMasteryAnimationInComboBox.Name = "alertsCustomMasteryAnimationInComboBox";
            this.alertsCustomMasteryAnimationInComboBox.Size = new System.Drawing.Size(97, 21);
            this.alertsCustomMasteryAnimationInComboBox.TabIndex = 39;
            this.alertsCustomMasteryAnimationInComboBox.SelectedIndexChanged += new System.EventHandler(this.NotificationAnimationComboBox_SelectedIndexChanged);
            // 
            // alertsCustomMasteryInSpeedUpDown
            // 
            this.alertsCustomMasteryInSpeedUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsCustomMasteryInSpeedUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsCustomMasteryInSpeedUpDown.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.alertsCustomMasteryInSpeedUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsCustomMasteryInSpeedUpDown.Location = new System.Drawing.Point(168, 4);
            this.alertsCustomMasteryInSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.alertsCustomMasteryInSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.alertsCustomMasteryInSpeedUpDown.Name = "alertsCustomMasteryInSpeedUpDown";
            this.alertsCustomMasteryInSpeedUpDown.Size = new System.Drawing.Size(97, 17);
            this.alertsCustomMasteryInSpeedUpDown.TabIndex = 48;
            this.alertsCustomMasteryInSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.alertsCustomMasteryInSpeedUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsCustomMasteryEnableCheckbox
            // 
            this.alertsCustomMasteryEnableCheckbox.AutoSize = true;
            this.alertsCustomMasteryEnableCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsCustomMasteryEnableCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsCustomMasteryEnableCheckbox.Location = new System.Drawing.Point(86, 6);
            this.alertsCustomMasteryEnableCheckbox.Name = "alertsCustomMasteryEnableCheckbox";
            this.alertsCustomMasteryEnableCheckbox.Size = new System.Drawing.Size(75, 20);
            this.alertsCustomMasteryEnableCheckbox.TabIndex = 13;
            this.alertsCustomMasteryEnableCheckbox.Text = "Custom";
            this.alertsCustomMasteryEnableCheckbox.UseVisualStyleBackColor = true;
            this.alertsCustomMasteryEnableCheckbox.CheckedChanged += new System.EventHandler(this.CustomAlertsCheckBox_CheckedChanged);
            // 
            // userInfoTruePointsTextBox
            // 
            this.userInfoTruePointsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoTruePointsTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoTruePointsTextBox.ForeColor = System.Drawing.Color.White;
            this.userInfoTruePointsTextBox.Location = new System.Drawing.Point(116, 0);
            this.userInfoTruePointsTextBox.Name = "userInfoTruePointsTextBox";
            this.userInfoTruePointsTextBox.Size = new System.Drawing.Size(99, 23);
            this.userInfoTruePointsTextBox.TabIndex = 7;
            this.userInfoTruePointsTextBox.Text = "True Points";
            this.userInfoTruePointsTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // userInfoPointsTextBox
            // 
            this.userInfoPointsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoPointsTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoPointsTextBox.ForeColor = System.Drawing.Color.White;
            this.userInfoPointsTextBox.Location = new System.Drawing.Point(116, 0);
            this.userInfoPointsTextBox.Name = "userInfoPointsTextBox";
            this.userInfoPointsTextBox.Size = new System.Drawing.Size(99, 23);
            this.userInfoPointsTextBox.TabIndex = 6;
            this.userInfoPointsTextBox.Text = "Points";
            this.userInfoPointsTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // userInfoRatioTextBox
            // 
            this.userInfoRatioTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoRatioTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRatioTextBox.ForeColor = System.Drawing.Color.White;
            this.userInfoRatioTextBox.Location = new System.Drawing.Point(116, 0);
            this.userInfoRatioTextBox.Name = "userInfoRatioTextBox";
            this.userInfoRatioTextBox.Size = new System.Drawing.Size(99, 23);
            this.userInfoRatioTextBox.TabIndex = 5;
            this.userInfoRatioTextBox.Text = "Retro Ratio";
            this.userInfoRatioTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // userInfoRankTextBox
            // 
            this.userInfoRankTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoRankTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRankTextBox.ForeColor = System.Drawing.Color.White;
            this.userInfoRankTextBox.Location = new System.Drawing.Point(116, 0);
            this.userInfoRankTextBox.Name = "userInfoRankTextBox";
            this.userInfoRankTextBox.Size = new System.Drawing.Size(99, 23);
            this.userInfoRankTextBox.TabIndex = 1;
            this.userInfoRankTextBox.Text = "Rank";
            this.userInfoRankTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // userInfoTruePointsCheckBox
            // 
            this.userInfoTruePointsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.userInfoTruePointsCheckBox.FlatAppearance.BorderSize = 0;
            this.userInfoTruePointsCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoTruePointsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.userInfoTruePointsCheckBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoTruePointsCheckBox.ForeColor = System.Drawing.Color.White;
            this.userInfoTruePointsCheckBox.Location = new System.Drawing.Point(225, 5);
            this.userInfoTruePointsCheckBox.Name = "userInfoTruePointsCheckBox";
            this.userInfoTruePointsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.userInfoTruePointsCheckBox.TabIndex = 56;
            this.userInfoTruePointsCheckBox.UseVisualStyleBackColor = true;
            this.userInfoTruePointsCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // userInfoRatioCheckBox
            // 
            this.userInfoRatioCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.userInfoRatioCheckBox.FlatAppearance.BorderSize = 0;
            this.userInfoRatioCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoRatioCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.userInfoRatioCheckBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRatioCheckBox.ForeColor = System.Drawing.Color.White;
            this.userInfoRatioCheckBox.Location = new System.Drawing.Point(225, 5);
            this.userInfoRatioCheckBox.Name = "userInfoRatioCheckBox";
            this.userInfoRatioCheckBox.Size = new System.Drawing.Size(15, 14);
            this.userInfoRatioCheckBox.TabIndex = 55;
            this.userInfoRatioCheckBox.UseVisualStyleBackColor = true;
            this.userInfoRatioCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // userInfoPointsCheckBox
            // 
            this.userInfoPointsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.userInfoPointsCheckBox.FlatAppearance.BorderSize = 0;
            this.userInfoPointsCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoPointsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.userInfoPointsCheckBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoPointsCheckBox.ForeColor = System.Drawing.Color.White;
            this.userInfoPointsCheckBox.Location = new System.Drawing.Point(225, 5);
            this.userInfoPointsCheckBox.Name = "userInfoPointsCheckBox";
            this.userInfoPointsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.userInfoPointsCheckBox.TabIndex = 54;
            this.userInfoPointsCheckBox.UseVisualStyleBackColor = true;
            this.userInfoPointsCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // userInfoDefaultButton
            // 
            this.userInfoDefaultButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoDefaultButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.userInfoDefaultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userInfoDefaultButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoDefaultButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.userInfoDefaultButton.Location = new System.Drawing.Point(204, 2);
            this.userInfoDefaultButton.Margin = new System.Windows.Forms.Padding(0);
            this.userInfoDefaultButton.Name = "userInfoDefaultButton";
            this.userInfoDefaultButton.Size = new System.Drawing.Size(75, 27);
            this.userInfoDefaultButton.TabIndex = 39;
            this.userInfoDefaultButton.Text = "Default";
            this.userInfoDefaultButton.UseVisualStyleBackColor = false;
            this.userInfoDefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // userInfoRankCheckBox
            // 
            this.userInfoRankCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.userInfoRankCheckBox.FlatAppearance.BorderSize = 0;
            this.userInfoRankCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoRankCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.userInfoRankCheckBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRankCheckBox.ForeColor = System.Drawing.Color.White;
            this.userInfoRankCheckBox.Location = new System.Drawing.Point(225, 5);
            this.userInfoRankCheckBox.Name = "userInfoRankCheckBox";
            this.userInfoRankCheckBox.Size = new System.Drawing.Size(15, 14);
            this.userInfoRankCheckBox.TabIndex = 52;
            this.userInfoRankCheckBox.UseVisualStyleBackColor = true;
            this.userInfoRankCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // focusBehaviorGoToLastRadioButton
            // 
            this.focusBehaviorGoToLastRadioButton.AutoSize = true;
            this.focusBehaviorGoToLastRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusBehaviorGoToLastRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusBehaviorGoToLastRadioButton.Location = new System.Drawing.Point(223, 40);
            this.focusBehaviorGoToLastRadioButton.Name = "focusBehaviorGoToLastRadioButton";
            this.focusBehaviorGoToLastRadioButton.Size = new System.Drawing.Size(53, 20);
            this.focusBehaviorGoToLastRadioButton.TabIndex = 3;
            this.focusBehaviorGoToLastRadioButton.Text = "Last";
            this.focusBehaviorGoToLastRadioButton.UseVisualStyleBackColor = true;
            this.focusBehaviorGoToLastRadioButton.CheckedChanged += new System.EventHandler(this.RefocusBehavior_RadioButtonCheckChanged);
            // 
            // focusBehaviorGoToNextRadioButton
            // 
            this.focusBehaviorGoToNextRadioButton.AutoSize = true;
            this.focusBehaviorGoToNextRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusBehaviorGoToNextRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusBehaviorGoToNextRadioButton.Location = new System.Drawing.Point(68, 40);
            this.focusBehaviorGoToNextRadioButton.Name = "focusBehaviorGoToNextRadioButton";
            this.focusBehaviorGoToNextRadioButton.Size = new System.Drawing.Size(55, 20);
            this.focusBehaviorGoToNextRadioButton.TabIndex = 2;
            this.focusBehaviorGoToNextRadioButton.Text = "Next";
            this.focusBehaviorGoToNextRadioButton.UseVisualStyleBackColor = true;
            this.focusBehaviorGoToNextRadioButton.CheckedChanged += new System.EventHandler(this.RefocusBehavior_RadioButtonCheckChanged);
            // 
            // focusBehaviorGoToPreviousRadioButton
            // 
            this.focusBehaviorGoToPreviousRadioButton.AutoSize = true;
            this.focusBehaviorGoToPreviousRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusBehaviorGoToPreviousRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusBehaviorGoToPreviousRadioButton.Location = new System.Drawing.Point(137, 40);
            this.focusBehaviorGoToPreviousRadioButton.Name = "focusBehaviorGoToPreviousRadioButton";
            this.focusBehaviorGoToPreviousRadioButton.Size = new System.Drawing.Size(80, 20);
            this.focusBehaviorGoToPreviousRadioButton.TabIndex = 1;
            this.focusBehaviorGoToPreviousRadioButton.Text = "Previous";
            this.focusBehaviorGoToPreviousRadioButton.UseVisualStyleBackColor = true;
            this.focusBehaviorGoToPreviousRadioButton.CheckedChanged += new System.EventHandler(this.RefocusBehavior_RadioButtonCheckChanged);
            // 
            // focusBehaviorGoToFirstRadioButton
            // 
            this.focusBehaviorGoToFirstRadioButton.AutoSize = true;
            this.focusBehaviorGoToFirstRadioButton.Checked = true;
            this.focusBehaviorGoToFirstRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusBehaviorGoToFirstRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusBehaviorGoToFirstRadioButton.Location = new System.Drawing.Point(8, 40);
            this.focusBehaviorGoToFirstRadioButton.Name = "focusBehaviorGoToFirstRadioButton";
            this.focusBehaviorGoToFirstRadioButton.Size = new System.Drawing.Size(54, 20);
            this.focusBehaviorGoToFirstRadioButton.TabIndex = 0;
            this.focusBehaviorGoToFirstRadioButton.TabStop = true;
            this.focusBehaviorGoToFirstRadioButton.Text = "First";
            this.focusBehaviorGoToFirstRadioButton.UseVisualStyleBackColor = true;
            this.focusBehaviorGoToFirstRadioButton.CheckedChanged += new System.EventHandler(this.RefocusBehavior_RadioButtonCheckChanged);
            // 
            // recentAchievementsMaxListLabel
            // 
            this.recentAchievementsMaxListLabel.AutoSize = true;
            this.recentAchievementsMaxListLabel.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsMaxListLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsMaxListLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsMaxListLabel.Location = new System.Drawing.Point(127, 41);
            this.recentAchievementsMaxListLabel.Name = "recentAchievementsMaxListLabel";
            this.recentAchievementsMaxListLabel.Size = new System.Drawing.Size(93, 16);
            this.recentAchievementsMaxListLabel.TabIndex = 10015;
            this.recentAchievementsMaxListLabel.Text = "Max List Size";
            // 
            // recentAchievementsMaxListNumericUpDown
            // 
            this.recentAchievementsMaxListNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.recentAchievementsMaxListNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.recentAchievementsMaxListNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.recentAchievementsMaxListNumericUpDown.Location = new System.Drawing.Point(226, 40);
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
            this.recentAchievementsMaxListNumericUpDown.Size = new System.Drawing.Size(51, 21);
            this.recentAchievementsMaxListNumericUpDown.TabIndex = 22;
            this.recentAchievementsMaxListNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentAchievementsMaxListNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // panel64
            // 
            this.panel64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel64.Controls.Add(this.label112);
            this.panel64.Controls.Add(this.focusBehaviorGoToLastRadioButton);
            this.panel64.Controls.Add(this.pictureBox12);
            this.panel64.Controls.Add(this.focusBehaviorGoToFirstRadioButton);
            this.panel64.Controls.Add(this.focusBehaviorGoToNextRadioButton);
            this.panel64.Controls.Add(this.focusBehaviorGoToPreviousRadioButton);
            this.panel64.Location = new System.Drawing.Point(3, 302);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(289, 63);
            this.panel64.TabIndex = 10084;
            // 
            // label112
            // 
            this.label112.BackColor = System.Drawing.Color.Transparent;
            this.label112.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label112.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label112.Location = new System.Drawing.Point(3, 3);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(273, 26);
            this.label112.TabIndex = 10082;
            this.label112.Text = "Auto-Focus Rule";
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox12.Location = new System.Drawing.Point(2, 32);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(275, 2);
            this.pictureBox12.TabIndex = 10083;
            this.pictureBox12.TabStop = false;
            // 
            // panel63
            // 
            this.panel63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel63.Controls.Add(this.label111);
            this.panel63.Controls.Add(this.pictureBox10);
            this.panel63.Controls.Add(this.focusAchievementPictureBox);
            this.panel63.Controls.Add(this.focusAchievementButtonPrevious);
            this.panel63.Controls.Add(this.focusAchievementButtonNext);
            this.panel63.Controls.Add(this.focusAchievementDescriptionLabel);
            this.panel63.Controls.Add(this.focusAchievementTitleLabel);
            this.panel63.Controls.Add(this.focusSetButton);
            this.panel63.Location = new System.Drawing.Point(3, 3);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(289, 293);
            this.panel63.TabIndex = 10081;
            // 
            // label111
            // 
            this.label111.BackColor = System.Drawing.Color.Transparent;
            this.label111.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label111.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label111.Location = new System.Drawing.Point(3, 3);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(273, 26);
            this.label111.TabIndex = 10082;
            this.label111.Text = "Current Achievement";
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox10.Location = new System.Drawing.Point(2, 32);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(275, 2);
            this.pictureBox10.TabIndex = 10083;
            this.pictureBox10.TabStop = false;
            // 
            // panel51
            // 
            this.panel51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel51.Controls.Add(this.focusLinePanel);
            this.panel51.Controls.Add(this.label96);
            this.panel51.Controls.Add(this.panel59);
            this.panel51.Controls.Add(this.focusPointsPanel);
            this.panel51.Controls.Add(this.panel52);
            this.panel51.Controls.Add(this.panel61);
            this.panel51.Controls.Add(this.focusOpenWindowButton);
            this.panel51.Controls.Add(this.focusDescriptionOutlinePanel);
            this.panel51.Controls.Add(this.focusDescriptionPanel);
            this.panel51.Controls.Add(this.focusAutoOpenWindowCheckBox);
            this.panel51.Controls.Add(this.pictureBox11);
            this.panel51.Controls.Add(this.panel54);
            this.panel51.Controls.Add(this.panel55);
            this.panel51.Controls.Add(this.focusPointsOutlinePanel);
            this.panel51.Controls.Add(this.focusLineOutlinePanel);
            this.panel51.Location = new System.Drawing.Point(296, 3);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(468, 285);
            this.panel51.TabIndex = 10080;
            // 
            // focusLinePanel
            // 
            this.focusLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.focusLinePanel.Controls.Add(this.label106);
            this.focusLinePanel.Controls.Add(this.focusLineColorPictureBox);
            this.focusLinePanel.Location = new System.Drawing.Point(2, 172);
            this.focusLinePanel.Name = "focusLinePanel";
            this.focusLinePanel.Size = new System.Drawing.Size(463, 23);
            this.focusLinePanel.TabIndex = 10068;
            // 
            // label106
            // 
            this.label106.BackColor = System.Drawing.Color.Transparent;
            this.label106.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label106.Location = new System.Drawing.Point(3, 4);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(144, 16);
            this.label106.TabIndex = 10066;
            this.label106.Text = "Line";
            // 
            // focusLineColorPictureBox
            // 
            this.focusLineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.focusLineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusLineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.focusLineColorPictureBox.Name = "focusLineColorPictureBox";
            this.focusLineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.focusLineColorPictureBox.TabIndex = 45;
            this.focusLineColorPictureBox.TabStop = false;
            this.focusLineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.Transparent;
            this.label96.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label96.Location = new System.Drawing.Point(3, 3);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(243, 26);
            this.label96.TabIndex = 10062;
            this.label96.Text = "Window/Font Settings";
            // 
            // panel59
            // 
            this.panel59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel59.Controls.Add(this.focusBorderCheckBox);
            this.panel59.Controls.Add(this.focusBorderColorPictureBox);
            this.panel59.Controls.Add(this.label107);
            this.panel59.Location = new System.Drawing.Point(2, 84);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(463, 23);
            this.panel59.TabIndex = 10069;
            // 
            // focusBorderCheckBox
            // 
            this.focusBorderCheckBox.AutoSize = true;
            this.focusBorderCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusBorderCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusBorderCheckBox.Location = new System.Drawing.Point(413, 5);
            this.focusBorderCheckBox.Name = "focusBorderCheckBox";
            this.focusBorderCheckBox.Size = new System.Drawing.Size(15, 14);
            this.focusBorderCheckBox.TabIndex = 10065;
            this.focusBorderCheckBox.UseVisualStyleBackColor = true;
            this.focusBorderCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // focusBorderColorPictureBox
            // 
            this.focusBorderColorPictureBox.BackColor = System.Drawing.Color.White;
            this.focusBorderColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusBorderColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.focusBorderColorPictureBox.Name = "focusBorderColorPictureBox";
            this.focusBorderColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.focusBorderColorPictureBox.TabIndex = 42;
            this.focusBorderColorPictureBox.TabStop = false;
            this.focusBorderColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label107
            // 
            this.label107.BackColor = System.Drawing.Color.Transparent;
            this.label107.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label107.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label107.Location = new System.Drawing.Point(3, 3);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(144, 16);
            this.label107.TabIndex = 10064;
            this.label107.Text = "Border";
            // 
            // focusPointsPanel
            // 
            this.focusPointsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.focusPointsPanel.Controls.Add(this.label108);
            this.focusPointsPanel.Controls.Add(this.focusPointsFontColorPictureBox);
            this.focusPointsPanel.Controls.Add(this.focusPointsFontComboBox);
            this.focusPointsPanel.Location = new System.Drawing.Point(2, 150);
            this.focusPointsPanel.Name = "focusPointsPanel";
            this.focusPointsPanel.Size = new System.Drawing.Size(463, 23);
            this.focusPointsPanel.TabIndex = 10070;
            // 
            // label108
            // 
            this.label108.BackColor = System.Drawing.Color.Transparent;
            this.label108.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label108.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label108.Location = new System.Drawing.Point(3, 4);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(144, 16);
            this.label108.TabIndex = 10065;
            this.label108.Text = "Points";
            // 
            // focusPointsFontColorPictureBox
            // 
            this.focusPointsFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.focusPointsFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusPointsFontColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.focusPointsFontColorPictureBox.Name = "focusPointsFontColorPictureBox";
            this.focusPointsFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.focusPointsFontColorPictureBox.TabIndex = 45;
            this.focusPointsFontColorPictureBox.TabStop = false;
            this.focusPointsFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // focusPointsFontComboBox
            // 
            this.focusPointsFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.focusPointsFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusPointsFontComboBox.ForeColor = System.Drawing.Color.White;
            this.focusPointsFontComboBox.FormattingEnabled = true;
            this.focusPointsFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.focusPointsFontComboBox.Name = "focusPointsFontComboBox";
            this.focusPointsFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.focusPointsFontComboBox.TabIndex = 45;
            this.focusPointsFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // panel52
            // 
            this.panel52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel52.Controls.Add(this.focusAdvancedCheckBox);
            this.panel52.Controls.Add(this.label97);
            this.panel52.Controls.Add(this.label98);
            this.panel52.Controls.Add(this.label99);
            this.panel52.Controls.Add(this.label100);
            this.panel52.Location = new System.Drawing.Point(2, 40);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(463, 23);
            this.panel52.TabIndex = 10076;
            // 
            // focusAdvancedCheckBox
            // 
            this.focusAdvancedCheckBox.AutoSize = true;
            this.focusAdvancedCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.focusAdvancedCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.focusAdvancedCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAdvancedCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusAdvancedCheckBox.Location = new System.Drawing.Point(5, 2);
            this.focusAdvancedCheckBox.Name = "focusAdvancedCheckBox";
            this.focusAdvancedCheckBox.Size = new System.Drawing.Size(91, 20);
            this.focusAdvancedCheckBox.TabIndex = 10053;
            this.focusAdvancedCheckBox.Text = "Advanced";
            this.focusAdvancedCheckBox.UseVisualStyleBackColor = false;
            this.focusAdvancedCheckBox.CheckedChanged += new System.EventHandler(this.AdvancedCheckBox_Click);
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.Color.Transparent;
            this.label97.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label97.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label97.Location = new System.Drawing.Point(150, 3);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(48, 16);
            this.label97.TabIndex = 10065;
            this.label97.Text = "Color";
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.Color.Transparent;
            this.label98.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label98.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label98.Location = new System.Drawing.Point(194, 3);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(50, 16);
            this.label98.TabIndex = 10066;
            this.label98.Text = "Font";
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.Color.Transparent;
            this.label99.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label99.Location = new System.Drawing.Point(349, 3);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(41, 16);
            this.label99.TabIndex = 10068;
            this.label99.Text = "Size";
            // 
            // label100
            // 
            this.label100.BackColor = System.Drawing.Color.Transparent;
            this.label100.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label100.Location = new System.Drawing.Point(396, 3);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(59, 16);
            this.label100.TabIndex = 10067;
            this.label100.Text = "Enabled";
            // 
            // panel61
            // 
            this.panel61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel61.Controls.Add(this.focusTitleFontOutlineNumericUpDown);
            this.panel61.Controls.Add(this.focusTitleOutlineCheckBox);
            this.panel61.Controls.Add(this.focusTitleOutlineLabel);
            this.panel61.Controls.Add(this.focusTitleFontOutlineColorPictureBox);
            this.panel61.Location = new System.Drawing.Point(2, 194);
            this.panel61.Name = "panel61";
            this.panel61.Size = new System.Drawing.Size(463, 23);
            this.panel61.TabIndex = 10071;
            // 
            // focusTitleFontOutlineNumericUpDown
            // 
            this.focusTitleFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.focusTitleFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.focusTitleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusTitleFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.focusTitleFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.focusTitleFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.focusTitleFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.focusTitleFontOutlineNumericUpDown.Name = "focusTitleFontOutlineNumericUpDown";
            this.focusTitleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.focusTitleFontOutlineNumericUpDown.TabIndex = 45;
            this.focusTitleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.focusTitleFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // focusTitleOutlineCheckBox
            // 
            this.focusTitleOutlineCheckBox.AutoSize = true;
            this.focusTitleOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusTitleOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusTitleOutlineCheckBox.Location = new System.Drawing.Point(413, 5);
            this.focusTitleOutlineCheckBox.Name = "focusTitleOutlineCheckBox";
            this.focusTitleOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.focusTitleOutlineCheckBox.TabIndex = 45;
            this.focusTitleOutlineCheckBox.UseVisualStyleBackColor = true;
            this.focusTitleOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // focusTitleOutlineLabel
            // 
            this.focusTitleOutlineLabel.BackColor = System.Drawing.Color.Transparent;
            this.focusTitleOutlineLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusTitleOutlineLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusTitleOutlineLabel.Location = new System.Drawing.Point(3, 3);
            this.focusTitleOutlineLabel.Name = "focusTitleOutlineLabel";
            this.focusTitleOutlineLabel.Size = new System.Drawing.Size(144, 16);
            this.focusTitleOutlineLabel.TabIndex = 10066;
            this.focusTitleOutlineLabel.Text = "Title Outline";
            // 
            // focusTitleFontOutlineColorPictureBox
            // 
            this.focusTitleFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.focusTitleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusTitleFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.focusTitleFontOutlineColorPictureBox.Name = "focusTitleFontOutlineColorPictureBox";
            this.focusTitleFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.focusTitleFontOutlineColorPictureBox.TabIndex = 45;
            this.focusTitleFontOutlineColorPictureBox.TabStop = false;
            this.focusTitleFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // focusOpenWindowButton
            // 
            this.focusOpenWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.focusOpenWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.focusOpenWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.focusOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusOpenWindowButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusOpenWindowButton.Location = new System.Drawing.Point(382, 2);
            this.focusOpenWindowButton.Margin = new System.Windows.Forms.Padding(0);
            this.focusOpenWindowButton.Name = "focusOpenWindowButton";
            this.focusOpenWindowButton.Size = new System.Drawing.Size(75, 27);
            this.focusOpenWindowButton.TabIndex = 10021;
            this.focusOpenWindowButton.Text = "Open";
            this.focusOpenWindowButton.UseVisualStyleBackColor = false;
            this.focusOpenWindowButton.Click += new System.EventHandler(this.ShowWindowButton_Click);
            // 
            // focusDescriptionOutlinePanel
            // 
            this.focusDescriptionOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.focusDescriptionOutlinePanel.Controls.Add(this.label110);
            this.focusDescriptionOutlinePanel.Controls.Add(this.focusDescriptionFontOutlineColorPictureBox);
            this.focusDescriptionOutlinePanel.Controls.Add(this.focusDescriptionFontOutlineNumericUpDown);
            this.focusDescriptionOutlinePanel.Controls.Add(this.focusDescriptionOutlineCheckBox);
            this.focusDescriptionOutlinePanel.Location = new System.Drawing.Point(2, 216);
            this.focusDescriptionOutlinePanel.Name = "focusDescriptionOutlinePanel";
            this.focusDescriptionOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.focusDescriptionOutlinePanel.TabIndex = 10072;
            // 
            // label110
            // 
            this.label110.BackColor = System.Drawing.Color.Transparent;
            this.label110.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label110.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label110.Location = new System.Drawing.Point(3, 4);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(144, 16);
            this.label110.TabIndex = 10066;
            this.label110.Text = "Description Outline";
            // 
            // focusDescriptionFontOutlineColorPictureBox
            // 
            this.focusDescriptionFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.focusDescriptionFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusDescriptionFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.focusDescriptionFontOutlineColorPictureBox.Name = "focusDescriptionFontOutlineColorPictureBox";
            this.focusDescriptionFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.focusDescriptionFontOutlineColorPictureBox.TabIndex = 45;
            this.focusDescriptionFontOutlineColorPictureBox.TabStop = false;
            this.focusDescriptionFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // focusDescriptionFontOutlineNumericUpDown
            // 
            this.focusDescriptionFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.focusDescriptionFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.focusDescriptionFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusDescriptionFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.focusDescriptionFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.focusDescriptionFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.focusDescriptionFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.focusDescriptionFontOutlineNumericUpDown.Name = "focusDescriptionFontOutlineNumericUpDown";
            this.focusDescriptionFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.focusDescriptionFontOutlineNumericUpDown.TabIndex = 45;
            this.focusDescriptionFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.focusDescriptionFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // focusDescriptionOutlineCheckBox
            // 
            this.focusDescriptionOutlineCheckBox.AutoSize = true;
            this.focusDescriptionOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusDescriptionOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusDescriptionOutlineCheckBox.Location = new System.Drawing.Point(413, 6);
            this.focusDescriptionOutlineCheckBox.Name = "focusDescriptionOutlineCheckBox";
            this.focusDescriptionOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.focusDescriptionOutlineCheckBox.TabIndex = 45;
            this.focusDescriptionOutlineCheckBox.UseVisualStyleBackColor = true;
            this.focusDescriptionOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // focusDescriptionPanel
            // 
            this.focusDescriptionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.focusDescriptionPanel.Controls.Add(this.label101);
            this.focusDescriptionPanel.Controls.Add(this.focusDescriptionFontColorPictureBox);
            this.focusDescriptionPanel.Controls.Add(this.focusDescriptionFontComboBox);
            this.focusDescriptionPanel.Location = new System.Drawing.Point(2, 128);
            this.focusDescriptionPanel.Name = "focusDescriptionPanel";
            this.focusDescriptionPanel.Size = new System.Drawing.Size(463, 23);
            this.focusDescriptionPanel.TabIndex = 10061;
            // 
            // label101
            // 
            this.label101.BackColor = System.Drawing.Color.Transparent;
            this.label101.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label101.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label101.Location = new System.Drawing.Point(3, 4);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(144, 16);
            this.label101.TabIndex = 10066;
            this.label101.Text = "Description";
            // 
            // focusDescriptionFontColorPictureBox
            // 
            this.focusDescriptionFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.focusDescriptionFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusDescriptionFontColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.focusDescriptionFontColorPictureBox.Name = "focusDescriptionFontColorPictureBox";
            this.focusDescriptionFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.focusDescriptionFontColorPictureBox.TabIndex = 45;
            this.focusDescriptionFontColorPictureBox.TabStop = false;
            this.focusDescriptionFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // focusDescriptionFontComboBox
            // 
            this.focusDescriptionFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.focusDescriptionFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusDescriptionFontComboBox.ForeColor = System.Drawing.Color.White;
            this.focusDescriptionFontComboBox.FormattingEnabled = true;
            this.focusDescriptionFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.focusDescriptionFontComboBox.Name = "focusDescriptionFontComboBox";
            this.focusDescriptionFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.focusDescriptionFontComboBox.TabIndex = 45;
            this.focusDescriptionFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // focusAutoOpenWindowCheckBox
            // 
            this.focusAutoOpenWindowCheckBox.AutoSize = true;
            this.focusAutoOpenWindowCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.focusAutoOpenWindowCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAutoOpenWindowCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusAutoOpenWindowCheckBox.Location = new System.Drawing.Point(252, 9);
            this.focusAutoOpenWindowCheckBox.Name = "focusAutoOpenWindowCheckBox";
            this.focusAutoOpenWindowCheckBox.Size = new System.Drawing.Size(98, 20);
            this.focusAutoOpenWindowCheckBox.TabIndex = 10022;
            this.focusAutoOpenWindowCheckBox.Text = "Auto-Open";
            this.focusAutoOpenWindowCheckBox.UseVisualStyleBackColor = true;
            this.focusAutoOpenWindowCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox11.Location = new System.Drawing.Point(2, 32);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(460, 2);
            this.pictureBox11.TabIndex = 10063;
            this.pictureBox11.TabStop = false;
            // 
            // panel54
            // 
            this.panel54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel54.Controls.Add(this.focusBackgroundColorPictureBox);
            this.panel54.Controls.Add(this.label102);
            this.panel54.Location = new System.Drawing.Point(2, 62);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(463, 23);
            this.panel54.TabIndex = 10061;
            // 
            // focusBackgroundColorPictureBox
            // 
            this.focusBackgroundColorPictureBox.BackColor = System.Drawing.Color.White;
            this.focusBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusBackgroundColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.focusBackgroundColorPictureBox.Name = "focusBackgroundColorPictureBox";
            this.focusBackgroundColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.focusBackgroundColorPictureBox.TabIndex = 42;
            this.focusBackgroundColorPictureBox.TabStop = false;
            this.focusBackgroundColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label102
            // 
            this.label102.BackColor = System.Drawing.Color.Transparent;
            this.label102.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label102.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label102.Location = new System.Drawing.Point(3, 3);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(144, 16);
            this.label102.TabIndex = 10064;
            this.label102.Text = "Window Background";
            // 
            // panel55
            // 
            this.panel55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel55.Controls.Add(this.focusTitleLabel);
            this.panel55.Controls.Add(this.focusTitleFontColorPictureBox);
            this.panel55.Controls.Add(this.focusTitleFontComboBox);
            this.panel55.Location = new System.Drawing.Point(2, 106);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(463, 23);
            this.panel55.TabIndex = 10061;
            // 
            // focusTitleLabel
            // 
            this.focusTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.focusTitleLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusTitleLabel.Location = new System.Drawing.Point(3, 4);
            this.focusTitleLabel.Name = "focusTitleLabel";
            this.focusTitleLabel.Size = new System.Drawing.Size(144, 16);
            this.focusTitleLabel.TabIndex = 10065;
            this.focusTitleLabel.Text = "Title";
            // 
            // focusTitleFontColorPictureBox
            // 
            this.focusTitleFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.focusTitleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusTitleFontColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.focusTitleFontColorPictureBox.Name = "focusTitleFontColorPictureBox";
            this.focusTitleFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.focusTitleFontColorPictureBox.TabIndex = 45;
            this.focusTitleFontColorPictureBox.TabStop = false;
            this.focusTitleFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // focusTitleFontComboBox
            // 
            this.focusTitleFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.focusTitleFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusTitleFontComboBox.ForeColor = System.Drawing.Color.White;
            this.focusTitleFontComboBox.FormattingEnabled = true;
            this.focusTitleFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.focusTitleFontComboBox.Name = "focusTitleFontComboBox";
            this.focusTitleFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.focusTitleFontComboBox.TabIndex = 45;
            this.focusTitleFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // focusPointsOutlinePanel
            // 
            this.focusPointsOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.focusPointsOutlinePanel.Controls.Add(this.focusPointsFontOutlineNumericUpDown);
            this.focusPointsOutlinePanel.Controls.Add(this.focusPointsOutlineCheckBox);
            this.focusPointsOutlinePanel.Controls.Add(this.label104);
            this.focusPointsOutlinePanel.Controls.Add(this.focusPointsFontOutlineColorPictureBox);
            this.focusPointsOutlinePanel.Location = new System.Drawing.Point(2, 238);
            this.focusPointsOutlinePanel.Name = "focusPointsOutlinePanel";
            this.focusPointsOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.focusPointsOutlinePanel.TabIndex = 10061;
            // 
            // focusPointsFontOutlineNumericUpDown
            // 
            this.focusPointsFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.focusPointsFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.focusPointsFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusPointsFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.focusPointsFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.focusPointsFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.focusPointsFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.focusPointsFontOutlineNumericUpDown.Name = "focusPointsFontOutlineNumericUpDown";
            this.focusPointsFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.focusPointsFontOutlineNumericUpDown.TabIndex = 45;
            this.focusPointsFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.focusPointsFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // focusPointsOutlineCheckBox
            // 
            this.focusPointsOutlineCheckBox.AutoSize = true;
            this.focusPointsOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusPointsOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusPointsOutlineCheckBox.Location = new System.Drawing.Point(413, 5);
            this.focusPointsOutlineCheckBox.Name = "focusPointsOutlineCheckBox";
            this.focusPointsOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.focusPointsOutlineCheckBox.TabIndex = 45;
            this.focusPointsOutlineCheckBox.UseVisualStyleBackColor = true;
            this.focusPointsOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // label104
            // 
            this.label104.BackColor = System.Drawing.Color.Transparent;
            this.label104.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label104.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label104.Location = new System.Drawing.Point(3, 3);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(144, 16);
            this.label104.TabIndex = 10066;
            this.label104.Text = "Points Outline";
            // 
            // focusPointsFontOutlineColorPictureBox
            // 
            this.focusPointsFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.focusPointsFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusPointsFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.focusPointsFontOutlineColorPictureBox.Name = "focusPointsFontOutlineColorPictureBox";
            this.focusPointsFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.focusPointsFontOutlineColorPictureBox.TabIndex = 45;
            this.focusPointsFontOutlineColorPictureBox.TabStop = false;
            this.focusPointsFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // focusLineOutlinePanel
            // 
            this.focusLineOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.focusLineOutlinePanel.Controls.Add(this.label105);
            this.focusLineOutlinePanel.Controls.Add(this.focusLineOutlineColorPictureBox);
            this.focusLineOutlinePanel.Controls.Add(this.focusLineOutlineNumericUpDown);
            this.focusLineOutlinePanel.Controls.Add(this.focusLineOutlineCheckBox);
            this.focusLineOutlinePanel.Location = new System.Drawing.Point(2, 260);
            this.focusLineOutlinePanel.Name = "focusLineOutlinePanel";
            this.focusLineOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.focusLineOutlinePanel.TabIndex = 10067;
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.Color.Transparent;
            this.label105.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label105.Location = new System.Drawing.Point(3, 4);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(144, 16);
            this.label105.TabIndex = 10066;
            this.label105.Text = "Line Outline";
            // 
            // focusLineOutlineColorPictureBox
            // 
            this.focusLineOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.focusLineOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusLineOutlineColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.focusLineOutlineColorPictureBox.Name = "focusLineOutlineColorPictureBox";
            this.focusLineOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.focusLineOutlineColorPictureBox.TabIndex = 45;
            this.focusLineOutlineColorPictureBox.TabStop = false;
            this.focusLineOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // focusLineOutlineNumericUpDown
            // 
            this.focusLineOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.focusLineOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.focusLineOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusLineOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.focusLineOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.focusLineOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.focusLineOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.focusLineOutlineNumericUpDown.Name = "focusLineOutlineNumericUpDown";
            this.focusLineOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.focusLineOutlineNumericUpDown.TabIndex = 45;
            this.focusLineOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.focusLineOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // focusLineOutlineCheckBox
            // 
            this.focusLineOutlineCheckBox.AutoSize = true;
            this.focusLineOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusLineOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusLineOutlineCheckBox.Location = new System.Drawing.Point(413, 6);
            this.focusLineOutlineCheckBox.Name = "focusLineOutlineCheckBox";
            this.focusLineOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.focusLineOutlineCheckBox.TabIndex = 45;
            this.focusLineOutlineCheckBox.UseVisualStyleBackColor = true;
            this.focusLineOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // panel65
            // 
            this.panel65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel65.Controls.Add(this.alertsLinePanel);
            this.panel65.Controls.Add(this.label114);
            this.panel65.Controls.Add(this.panel67);
            this.panel65.Controls.Add(this.alertsPointsPanel);
            this.panel65.Controls.Add(this.panel69);
            this.panel65.Controls.Add(this.panel70);
            this.panel65.Controls.Add(this.notificationsOpenWindowButton);
            this.panel65.Controls.Add(this.alertsDescriptionOutlinePanel);
            this.panel65.Controls.Add(this.alertsDescriptionPanel);
            this.panel65.Controls.Add(this.alertsAutoOpenWindowCheckbox);
            this.panel65.Controls.Add(this.pictureBox20);
            this.panel65.Controls.Add(this.panel73);
            this.panel65.Controls.Add(this.panel74);
            this.panel65.Controls.Add(this.alertsPointsOutlinePanel);
            this.panel65.Controls.Add(this.alertsLineOutlinePanel);
            this.panel65.Location = new System.Drawing.Point(296, 3);
            this.panel65.Name = "panel65";
            this.panel65.Size = new System.Drawing.Size(468, 285);
            this.panel65.TabIndex = 10081;
            // 
            // alertsLinePanel
            // 
            this.alertsLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsLinePanel.Controls.Add(this.label113);
            this.alertsLinePanel.Controls.Add(this.alertsLineColorPictureBox);
            this.alertsLinePanel.Location = new System.Drawing.Point(2, 172);
            this.alertsLinePanel.Name = "alertsLinePanel";
            this.alertsLinePanel.Size = new System.Drawing.Size(463, 23);
            this.alertsLinePanel.TabIndex = 10068;
            // 
            // label113
            // 
            this.label113.BackColor = System.Drawing.Color.Transparent;
            this.label113.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label113.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label113.Location = new System.Drawing.Point(3, 4);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(144, 16);
            this.label113.TabIndex = 10066;
            this.label113.Text = "Line";
            // 
            // alertsLineColorPictureBox
            // 
            this.alertsLineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.alertsLineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alertsLineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.alertsLineColorPictureBox.Name = "alertsLineColorPictureBox";
            this.alertsLineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.alertsLineColorPictureBox.TabIndex = 45;
            this.alertsLineColorPictureBox.TabStop = false;
            this.alertsLineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label114
            // 
            this.label114.BackColor = System.Drawing.Color.Transparent;
            this.label114.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label114.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label114.Location = new System.Drawing.Point(3, 3);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(243, 26);
            this.label114.TabIndex = 10062;
            this.label114.Text = "Window/Font Settings";
            // 
            // panel67
            // 
            this.panel67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel67.Controls.Add(this.alertsBorderCheckBox);
            this.panel67.Controls.Add(this.alertsBorderColorPictureBox);
            this.panel67.Controls.Add(this.label115);
            this.panel67.Location = new System.Drawing.Point(2, 84);
            this.panel67.Name = "panel67";
            this.panel67.Size = new System.Drawing.Size(463, 23);
            this.panel67.TabIndex = 10069;
            // 
            // alertsBorderCheckBox
            // 
            this.alertsBorderCheckBox.AutoSize = true;
            this.alertsBorderCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsBorderCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsBorderCheckBox.Location = new System.Drawing.Point(413, 5);
            this.alertsBorderCheckBox.Name = "alertsBorderCheckBox";
            this.alertsBorderCheckBox.Size = new System.Drawing.Size(15, 14);
            this.alertsBorderCheckBox.TabIndex = 10065;
            this.alertsBorderCheckBox.UseVisualStyleBackColor = true;
            this.alertsBorderCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // alertsBorderColorPictureBox
            // 
            this.alertsBorderColorPictureBox.BackColor = System.Drawing.Color.White;
            this.alertsBorderColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alertsBorderColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.alertsBorderColorPictureBox.Name = "alertsBorderColorPictureBox";
            this.alertsBorderColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.alertsBorderColorPictureBox.TabIndex = 42;
            this.alertsBorderColorPictureBox.TabStop = false;
            this.alertsBorderColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label115
            // 
            this.label115.BackColor = System.Drawing.Color.Transparent;
            this.label115.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label115.Location = new System.Drawing.Point(3, 3);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(144, 16);
            this.label115.TabIndex = 10064;
            this.label115.Text = "Border";
            // 
            // alertsPointsPanel
            // 
            this.alertsPointsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsPointsPanel.Controls.Add(this.label116);
            this.alertsPointsPanel.Controls.Add(this.alertsPointsFontColorPictureBox);
            this.alertsPointsPanel.Controls.Add(this.alertsPointsFontComboBox);
            this.alertsPointsPanel.Location = new System.Drawing.Point(2, 150);
            this.alertsPointsPanel.Name = "alertsPointsPanel";
            this.alertsPointsPanel.Size = new System.Drawing.Size(463, 23);
            this.alertsPointsPanel.TabIndex = 10070;
            // 
            // label116
            // 
            this.label116.BackColor = System.Drawing.Color.Transparent;
            this.label116.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label116.Location = new System.Drawing.Point(3, 4);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(144, 16);
            this.label116.TabIndex = 10065;
            this.label116.Text = "Points";
            // 
            // alertsPointsFontColorPictureBox
            // 
            this.alertsPointsFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.alertsPointsFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alertsPointsFontColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.alertsPointsFontColorPictureBox.Name = "alertsPointsFontColorPictureBox";
            this.alertsPointsFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.alertsPointsFontColorPictureBox.TabIndex = 45;
            this.alertsPointsFontColorPictureBox.TabStop = false;
            this.alertsPointsFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // alertsPointsFontComboBox
            // 
            this.alertsPointsFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsPointsFontComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.alertsPointsFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsPointsFontComboBox.ForeColor = System.Drawing.Color.White;
            this.alertsPointsFontComboBox.FormattingEnabled = true;
            this.alertsPointsFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.alertsPointsFontComboBox.Name = "alertsPointsFontComboBox";
            this.alertsPointsFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.alertsPointsFontComboBox.TabIndex = 45;
            this.alertsPointsFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // panel69
            // 
            this.panel69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel69.Controls.Add(this.alertsAdvancedCheckBox);
            this.panel69.Controls.Add(this.label117);
            this.panel69.Controls.Add(this.label118);
            this.panel69.Controls.Add(this.label119);
            this.panel69.Controls.Add(this.label120);
            this.panel69.Location = new System.Drawing.Point(2, 40);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(463, 23);
            this.panel69.TabIndex = 10076;
            // 
            // alertsAdvancedCheckBox
            // 
            this.alertsAdvancedCheckBox.AutoSize = true;
            this.alertsAdvancedCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.alertsAdvancedCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.alertsAdvancedCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsAdvancedCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsAdvancedCheckBox.Location = new System.Drawing.Point(5, 2);
            this.alertsAdvancedCheckBox.Name = "alertsAdvancedCheckBox";
            this.alertsAdvancedCheckBox.Size = new System.Drawing.Size(91, 20);
            this.alertsAdvancedCheckBox.TabIndex = 10053;
            this.alertsAdvancedCheckBox.Text = "Advanced";
            this.alertsAdvancedCheckBox.UseVisualStyleBackColor = false;
            this.alertsAdvancedCheckBox.CheckedChanged += new System.EventHandler(this.AdvancedCheckBox_Click);
            // 
            // label117
            // 
            this.label117.BackColor = System.Drawing.Color.Transparent;
            this.label117.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label117.Location = new System.Drawing.Point(150, 3);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(48, 16);
            this.label117.TabIndex = 10065;
            this.label117.Text = "Color";
            // 
            // label118
            // 
            this.label118.BackColor = System.Drawing.Color.Transparent;
            this.label118.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label118.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label118.Location = new System.Drawing.Point(194, 3);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(50, 16);
            this.label118.TabIndex = 10066;
            this.label118.Text = "Font";
            // 
            // label119
            // 
            this.label119.BackColor = System.Drawing.Color.Transparent;
            this.label119.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label119.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label119.Location = new System.Drawing.Point(349, 3);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(41, 16);
            this.label119.TabIndex = 10068;
            this.label119.Text = "Size";
            // 
            // label120
            // 
            this.label120.BackColor = System.Drawing.Color.Transparent;
            this.label120.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label120.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label120.Location = new System.Drawing.Point(396, 3);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(59, 16);
            this.label120.TabIndex = 10067;
            this.label120.Text = "Enabled";
            // 
            // panel70
            // 
            this.panel70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel70.Controls.Add(this.alertsTitleFontOutlineNumericUpDown);
            this.panel70.Controls.Add(this.alertsTitleOutlineCheckBox);
            this.panel70.Controls.Add(this.alertsTitleOutlineLabel);
            this.panel70.Controls.Add(this.alertsTitleFontOutlineColorPictureBox);
            this.panel70.Location = new System.Drawing.Point(2, 194);
            this.panel70.Name = "panel70";
            this.panel70.Size = new System.Drawing.Size(463, 23);
            this.panel70.TabIndex = 10071;
            // 
            // alertsTitleFontOutlineNumericUpDown
            // 
            this.alertsTitleFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsTitleFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsTitleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsTitleFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsTitleFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.alertsTitleFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.alertsTitleFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alertsTitleFontOutlineNumericUpDown.Name = "alertsTitleFontOutlineNumericUpDown";
            this.alertsTitleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.alertsTitleFontOutlineNumericUpDown.TabIndex = 45;
            this.alertsTitleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alertsTitleFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsTitleOutlineCheckBox
            // 
            this.alertsTitleOutlineCheckBox.AutoSize = true;
            this.alertsTitleOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsTitleOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsTitleOutlineCheckBox.Location = new System.Drawing.Point(413, 5);
            this.alertsTitleOutlineCheckBox.Name = "alertsTitleOutlineCheckBox";
            this.alertsTitleOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.alertsTitleOutlineCheckBox.TabIndex = 45;
            this.alertsTitleOutlineCheckBox.UseVisualStyleBackColor = true;
            this.alertsTitleOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // alertsTitleOutlineLabel
            // 
            this.alertsTitleOutlineLabel.BackColor = System.Drawing.Color.Transparent;
            this.alertsTitleOutlineLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsTitleOutlineLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsTitleOutlineLabel.Location = new System.Drawing.Point(3, 3);
            this.alertsTitleOutlineLabel.Name = "alertsTitleOutlineLabel";
            this.alertsTitleOutlineLabel.Size = new System.Drawing.Size(144, 16);
            this.alertsTitleOutlineLabel.TabIndex = 10066;
            this.alertsTitleOutlineLabel.Text = "Title Outline";
            // 
            // alertsTitleFontOutlineColorPictureBox
            // 
            this.alertsTitleFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.alertsTitleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alertsTitleFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.alertsTitleFontOutlineColorPictureBox.Name = "alertsTitleFontOutlineColorPictureBox";
            this.alertsTitleFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.alertsTitleFontOutlineColorPictureBox.TabIndex = 45;
            this.alertsTitleFontOutlineColorPictureBox.TabStop = false;
            this.alertsTitleFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // notificationsOpenWindowButton
            // 
            this.notificationsOpenWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.notificationsOpenWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.notificationsOpenWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notificationsOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsOpenWindowButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.notificationsOpenWindowButton.Location = new System.Drawing.Point(382, 2);
            this.notificationsOpenWindowButton.Margin = new System.Windows.Forms.Padding(0);
            this.notificationsOpenWindowButton.Name = "notificationsOpenWindowButton";
            this.notificationsOpenWindowButton.Size = new System.Drawing.Size(75, 27);
            this.notificationsOpenWindowButton.TabIndex = 10021;
            this.notificationsOpenWindowButton.Text = "Open";
            this.notificationsOpenWindowButton.UseVisualStyleBackColor = false;
            this.notificationsOpenWindowButton.Click += new System.EventHandler(this.ShowWindowButton_Click);
            // 
            // alertsDescriptionOutlinePanel
            // 
            this.alertsDescriptionOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsDescriptionOutlinePanel.Controls.Add(this.label122);
            this.alertsDescriptionOutlinePanel.Controls.Add(this.alertsDescriptionFontOutlineColorPictureBox);
            this.alertsDescriptionOutlinePanel.Controls.Add(this.alertsDescriptionFontOutlineNumericUpDown);
            this.alertsDescriptionOutlinePanel.Controls.Add(this.alertsDescriptionOutlineCheckBox);
            this.alertsDescriptionOutlinePanel.Location = new System.Drawing.Point(2, 216);
            this.alertsDescriptionOutlinePanel.Name = "alertsDescriptionOutlinePanel";
            this.alertsDescriptionOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.alertsDescriptionOutlinePanel.TabIndex = 10072;
            // 
            // label122
            // 
            this.label122.BackColor = System.Drawing.Color.Transparent;
            this.label122.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label122.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label122.Location = new System.Drawing.Point(3, 4);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(144, 16);
            this.label122.TabIndex = 10066;
            this.label122.Text = "Description Outline";
            // 
            // alertsDescriptionFontOutlineColorPictureBox
            // 
            this.alertsDescriptionFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.alertsDescriptionFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alertsDescriptionFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.alertsDescriptionFontOutlineColorPictureBox.Name = "alertsDescriptionFontOutlineColorPictureBox";
            this.alertsDescriptionFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.alertsDescriptionFontOutlineColorPictureBox.TabIndex = 45;
            this.alertsDescriptionFontOutlineColorPictureBox.TabStop = false;
            this.alertsDescriptionFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // alertsDescriptionFontOutlineNumericUpDown
            // 
            this.alertsDescriptionFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsDescriptionFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsDescriptionFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsDescriptionFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsDescriptionFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.alertsDescriptionFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.alertsDescriptionFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alertsDescriptionFontOutlineNumericUpDown.Name = "alertsDescriptionFontOutlineNumericUpDown";
            this.alertsDescriptionFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.alertsDescriptionFontOutlineNumericUpDown.TabIndex = 45;
            this.alertsDescriptionFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alertsDescriptionFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsDescriptionOutlineCheckBox
            // 
            this.alertsDescriptionOutlineCheckBox.AutoSize = true;
            this.alertsDescriptionOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsDescriptionOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsDescriptionOutlineCheckBox.Location = new System.Drawing.Point(413, 6);
            this.alertsDescriptionOutlineCheckBox.Name = "alertsDescriptionOutlineCheckBox";
            this.alertsDescriptionOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.alertsDescriptionOutlineCheckBox.TabIndex = 45;
            this.alertsDescriptionOutlineCheckBox.UseVisualStyleBackColor = true;
            this.alertsDescriptionOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // alertsDescriptionPanel
            // 
            this.alertsDescriptionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsDescriptionPanel.Controls.Add(this.label123);
            this.alertsDescriptionPanel.Controls.Add(this.alertsDescriptionFontColorPictureBox);
            this.alertsDescriptionPanel.Controls.Add(this.alertsDescriptionFontComboBox);
            this.alertsDescriptionPanel.Location = new System.Drawing.Point(2, 128);
            this.alertsDescriptionPanel.Name = "alertsDescriptionPanel";
            this.alertsDescriptionPanel.Size = new System.Drawing.Size(463, 23);
            this.alertsDescriptionPanel.TabIndex = 10061;
            // 
            // label123
            // 
            this.label123.BackColor = System.Drawing.Color.Transparent;
            this.label123.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label123.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label123.Location = new System.Drawing.Point(3, 4);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(144, 16);
            this.label123.TabIndex = 10066;
            this.label123.Text = "Description";
            // 
            // alertsDescriptionFontColorPictureBox
            // 
            this.alertsDescriptionFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.alertsDescriptionFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alertsDescriptionFontColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.alertsDescriptionFontColorPictureBox.Name = "alertsDescriptionFontColorPictureBox";
            this.alertsDescriptionFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.alertsDescriptionFontColorPictureBox.TabIndex = 45;
            this.alertsDescriptionFontColorPictureBox.TabStop = false;
            this.alertsDescriptionFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // alertsDescriptionFontComboBox
            // 
            this.alertsDescriptionFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsDescriptionFontComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.alertsDescriptionFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsDescriptionFontComboBox.ForeColor = System.Drawing.Color.White;
            this.alertsDescriptionFontComboBox.FormattingEnabled = true;
            this.alertsDescriptionFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.alertsDescriptionFontComboBox.Name = "alertsDescriptionFontComboBox";
            this.alertsDescriptionFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.alertsDescriptionFontComboBox.TabIndex = 45;
            this.alertsDescriptionFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // alertsAutoOpenWindowCheckbox
            // 
            this.alertsAutoOpenWindowCheckbox.AutoSize = true;
            this.alertsAutoOpenWindowCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.alertsAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsAutoOpenWindowCheckbox.Location = new System.Drawing.Point(252, 9);
            this.alertsAutoOpenWindowCheckbox.Name = "alertsAutoOpenWindowCheckbox";
            this.alertsAutoOpenWindowCheckbox.Size = new System.Drawing.Size(98, 20);
            this.alertsAutoOpenWindowCheckbox.TabIndex = 10022;
            this.alertsAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.alertsAutoOpenWindowCheckbox.UseVisualStyleBackColor = true;
            this.alertsAutoOpenWindowCheckbox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // pictureBox20
            // 
            this.pictureBox20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox20.Location = new System.Drawing.Point(2, 32);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(460, 2);
            this.pictureBox20.TabIndex = 10063;
            this.pictureBox20.TabStop = false;
            // 
            // panel73
            // 
            this.panel73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel73.Controls.Add(this.alertsBackgroundColorPictureBox);
            this.panel73.Controls.Add(this.label124);
            this.panel73.Location = new System.Drawing.Point(2, 62);
            this.panel73.Name = "panel73";
            this.panel73.Size = new System.Drawing.Size(463, 23);
            this.panel73.TabIndex = 10061;
            // 
            // alertsBackgroundColorPictureBox
            // 
            this.alertsBackgroundColorPictureBox.BackColor = System.Drawing.Color.White;
            this.alertsBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alertsBackgroundColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.alertsBackgroundColorPictureBox.Name = "alertsBackgroundColorPictureBox";
            this.alertsBackgroundColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.alertsBackgroundColorPictureBox.TabIndex = 42;
            this.alertsBackgroundColorPictureBox.TabStop = false;
            this.alertsBackgroundColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label124
            // 
            this.label124.BackColor = System.Drawing.Color.Transparent;
            this.label124.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label124.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label124.Location = new System.Drawing.Point(3, 3);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(144, 16);
            this.label124.TabIndex = 10064;
            this.label124.Text = "Window Background";
            // 
            // panel74
            // 
            this.panel74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel74.Controls.Add(this.alertsTitleLabel);
            this.panel74.Controls.Add(this.alertsTitleFontColorPictureBox);
            this.panel74.Controls.Add(this.alertsTitleFontComboBox);
            this.panel74.Location = new System.Drawing.Point(2, 106);
            this.panel74.Name = "panel74";
            this.panel74.Size = new System.Drawing.Size(463, 23);
            this.panel74.TabIndex = 10061;
            // 
            // alertsTitleLabel
            // 
            this.alertsTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.alertsTitleLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsTitleLabel.Location = new System.Drawing.Point(3, 4);
            this.alertsTitleLabel.Name = "alertsTitleLabel";
            this.alertsTitleLabel.Size = new System.Drawing.Size(144, 16);
            this.alertsTitleLabel.TabIndex = 10065;
            this.alertsTitleLabel.Text = "Title";
            // 
            // alertsTitleFontColorPictureBox
            // 
            this.alertsTitleFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.alertsTitleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alertsTitleFontColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.alertsTitleFontColorPictureBox.Name = "alertsTitleFontColorPictureBox";
            this.alertsTitleFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.alertsTitleFontColorPictureBox.TabIndex = 45;
            this.alertsTitleFontColorPictureBox.TabStop = false;
            this.alertsTitleFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // alertsTitleFontComboBox
            // 
            this.alertsTitleFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsTitleFontComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.alertsTitleFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsTitleFontComboBox.ForeColor = System.Drawing.Color.White;
            this.alertsTitleFontComboBox.FormattingEnabled = true;
            this.alertsTitleFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.alertsTitleFontComboBox.Name = "alertsTitleFontComboBox";
            this.alertsTitleFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.alertsTitleFontComboBox.TabIndex = 45;
            this.alertsTitleFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // alertsPointsOutlinePanel
            // 
            this.alertsPointsOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsPointsOutlinePanel.Controls.Add(this.alertsPointsFontOutlineNumericUpDown);
            this.alertsPointsOutlinePanel.Controls.Add(this.alertsPointsOutlineCheckBox);
            this.alertsPointsOutlinePanel.Controls.Add(this.label126);
            this.alertsPointsOutlinePanel.Controls.Add(this.alertsPointsFontOutlineColorPictureBox);
            this.alertsPointsOutlinePanel.Location = new System.Drawing.Point(2, 238);
            this.alertsPointsOutlinePanel.Name = "alertsPointsOutlinePanel";
            this.alertsPointsOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.alertsPointsOutlinePanel.TabIndex = 10061;
            // 
            // alertsPointsFontOutlineNumericUpDown
            // 
            this.alertsPointsFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsPointsFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsPointsFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsPointsFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsPointsFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.alertsPointsFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.alertsPointsFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alertsPointsFontOutlineNumericUpDown.Name = "alertsPointsFontOutlineNumericUpDown";
            this.alertsPointsFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.alertsPointsFontOutlineNumericUpDown.TabIndex = 45;
            this.alertsPointsFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alertsPointsFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsPointsOutlineCheckBox
            // 
            this.alertsPointsOutlineCheckBox.AutoSize = true;
            this.alertsPointsOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsPointsOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsPointsOutlineCheckBox.Location = new System.Drawing.Point(413, 5);
            this.alertsPointsOutlineCheckBox.Name = "alertsPointsOutlineCheckBox";
            this.alertsPointsOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.alertsPointsOutlineCheckBox.TabIndex = 45;
            this.alertsPointsOutlineCheckBox.UseVisualStyleBackColor = true;
            this.alertsPointsOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // label126
            // 
            this.label126.BackColor = System.Drawing.Color.Transparent;
            this.label126.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label126.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label126.Location = new System.Drawing.Point(3, 3);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(144, 16);
            this.label126.TabIndex = 10066;
            this.label126.Text = "Points Outline";
            // 
            // alertsPointsFontOutlineColorPictureBox
            // 
            this.alertsPointsFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.alertsPointsFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alertsPointsFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.alertsPointsFontOutlineColorPictureBox.Name = "alertsPointsFontOutlineColorPictureBox";
            this.alertsPointsFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.alertsPointsFontOutlineColorPictureBox.TabIndex = 45;
            this.alertsPointsFontOutlineColorPictureBox.TabStop = false;
            this.alertsPointsFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // alertsLineOutlinePanel
            // 
            this.alertsLineOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsLineOutlinePanel.Controls.Add(this.label127);
            this.alertsLineOutlinePanel.Controls.Add(this.alertsLineOutlineColorPictureBox);
            this.alertsLineOutlinePanel.Controls.Add(this.alertsLineOutlineNumericUpDown);
            this.alertsLineOutlinePanel.Controls.Add(this.alertsLineOutlineCheckBox);
            this.alertsLineOutlinePanel.Location = new System.Drawing.Point(2, 260);
            this.alertsLineOutlinePanel.Name = "alertsLineOutlinePanel";
            this.alertsLineOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.alertsLineOutlinePanel.TabIndex = 10067;
            // 
            // label127
            // 
            this.label127.BackColor = System.Drawing.Color.Transparent;
            this.label127.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label127.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label127.Location = new System.Drawing.Point(3, 4);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(144, 16);
            this.label127.TabIndex = 10066;
            this.label127.Text = "Line Outline";
            // 
            // alertsLineOutlineColorPictureBox
            // 
            this.alertsLineOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.alertsLineOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alertsLineOutlineColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.alertsLineOutlineColorPictureBox.Name = "alertsLineOutlineColorPictureBox";
            this.alertsLineOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.alertsLineOutlineColorPictureBox.TabIndex = 45;
            this.alertsLineOutlineColorPictureBox.TabStop = false;
            this.alertsLineOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // alertsLineOutlineNumericUpDown
            // 
            this.alertsLineOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.alertsLineOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alertsLineOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsLineOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.alertsLineOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.alertsLineOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.alertsLineOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alertsLineOutlineNumericUpDown.Name = "alertsLineOutlineNumericUpDown";
            this.alertsLineOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.alertsLineOutlineNumericUpDown.TabIndex = 45;
            this.alertsLineOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alertsLineOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // alertsLineOutlineCheckBox
            // 
            this.alertsLineOutlineCheckBox.AutoSize = true;
            this.alertsLineOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsLineOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsLineOutlineCheckBox.Location = new System.Drawing.Point(413, 6);
            this.alertsLineOutlineCheckBox.Name = "alertsLineOutlineCheckBox";
            this.alertsLineOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.alertsLineOutlineCheckBox.TabIndex = 45;
            this.alertsLineOutlineCheckBox.UseVisualStyleBackColor = true;
            this.alertsLineOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // alertsCustomAchievementPanel
            // 
            this.alertsCustomAchievementPanel.Controls.Add(this.panel85);
            this.alertsCustomAchievementPanel.Controls.Add(this.panel84);
            this.alertsCustomAchievementPanel.Controls.Add(this.panel86);
            this.alertsCustomAchievementPanel.Controls.Add(this.alertsSelectCustomAchievementFileButton);
            this.alertsCustomAchievementPanel.Controls.Add(this.panel83);
            this.alertsCustomAchievementPanel.Controls.Add(this.alertsAchievementEditOutlineCheckbox);
            this.alertsCustomAchievementPanel.Controls.Add(this.panel87);
            this.alertsCustomAchievementPanel.Controls.Add(this.panel78);
            this.alertsCustomAchievementPanel.Controls.Add(this.label130);
            this.alertsCustomAchievementPanel.Controls.Add(this.pictureBox13);
            this.alertsCustomAchievementPanel.Controls.Add(this.panel79);
            this.alertsCustomAchievementPanel.Controls.Add(this.panel80);
            this.alertsCustomAchievementPanel.Controls.Add(this.panel81);
            this.alertsCustomAchievementPanel.Controls.Add(this.panel82);
            this.alertsCustomAchievementPanel.Location = new System.Drawing.Point(3, 32);
            this.alertsCustomAchievementPanel.Name = "alertsCustomAchievementPanel";
            this.alertsCustomAchievementPanel.Size = new System.Drawing.Size(278, 294);
            this.alertsCustomAchievementPanel.TabIndex = 10082;
            // 
            // panel85
            // 
            this.panel85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel85.Controls.Add(this.label136);
            this.panel85.Controls.Add(this.alertsCustomAchievementAnimationOutComboBox);
            this.panel85.Location = new System.Drawing.Point(2, 238);
            this.panel85.Name = "panel85";
            this.panel85.Size = new System.Drawing.Size(272, 22);
            this.panel85.TabIndex = 10074;
            // 
            // label136
            // 
            this.label136.BackColor = System.Drawing.Color.Transparent;
            this.label136.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label136.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label136.Location = new System.Drawing.Point(3, 4);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(159, 16);
            this.label136.TabIndex = 10069;
            this.label136.Text = "Animate Out Direction";
            // 
            // panel84
            // 
            this.panel84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel84.Controls.Add(this.label135);
            this.panel84.Controls.Add(this.alertsCustomAchievementAnimationInComboBox);
            this.panel84.Location = new System.Drawing.Point(2, 172);
            this.panel84.Name = "panel84";
            this.panel84.Size = new System.Drawing.Size(272, 22);
            this.panel84.TabIndex = 10071;
            // 
            // label135
            // 
            this.label135.BackColor = System.Drawing.Color.Transparent;
            this.label135.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label135.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label135.Location = new System.Drawing.Point(3, 4);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(150, 16);
            this.label135.TabIndex = 10069;
            this.label135.Text = "Animate In Direction";
            // 
            // panel86
            // 
            this.panel86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel86.Controls.Add(this.label137);
            this.panel86.Controls.Add(this.alertsCustomAchievementOutSpeedUpDown);
            this.panel86.Location = new System.Drawing.Point(2, 216);
            this.panel86.Name = "panel86";
            this.panel86.Size = new System.Drawing.Size(272, 22);
            this.panel86.TabIndex = 10073;
            // 
            // label137
            // 
            this.label137.BackColor = System.Drawing.Color.Transparent;
            this.label137.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label137.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label137.Location = new System.Drawing.Point(3, 4);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(150, 16);
            this.label137.TabIndex = 10069;
            this.label137.Text = "Animate Out Duration";
            // 
            // panel83
            // 
            this.panel83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel83.Controls.Add(this.label129);
            this.panel83.Controls.Add(this.alertsCustomAchievementInSpeedUpDown);
            this.panel83.Location = new System.Drawing.Point(2, 150);
            this.panel83.Name = "panel83";
            this.panel83.Size = new System.Drawing.Size(272, 22);
            this.panel83.TabIndex = 10070;
            // 
            // label129
            // 
            this.label129.BackColor = System.Drawing.Color.Transparent;
            this.label129.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label129.Location = new System.Drawing.Point(3, 4);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(150, 16);
            this.label129.TabIndex = 10069;
            this.label129.Text = "Animate In Duration";
            // 
            // panel87
            // 
            this.panel87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel87.Controls.Add(this.label138);
            this.panel87.Controls.Add(this.alertsCustomAchievementOutNumericUpDown);
            this.panel87.Location = new System.Drawing.Point(2, 194);
            this.panel87.Name = "panel87";
            this.panel87.Size = new System.Drawing.Size(272, 23);
            this.panel87.TabIndex = 10072;
            // 
            // label138
            // 
            this.label138.BackColor = System.Drawing.Color.Transparent;
            this.label138.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label138.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label138.Location = new System.Drawing.Point(3, 4);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(150, 16);
            this.label138.TabIndex = 10069;
            this.label138.Text = "Animate Out Time";
            // 
            // panel78
            // 
            this.panel78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel78.Controls.Add(this.label42);
            this.panel78.Controls.Add(this.label128);
            this.panel78.Location = new System.Drawing.Point(2, 40);
            this.panel78.Name = "panel78";
            this.panel78.Size = new System.Drawing.Size(272, 23);
            this.panel78.TabIndex = 10079;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label42.Location = new System.Drawing.Point(3, 3);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(50, 16);
            this.label42.TabIndex = 10071;
            this.label42.Text = "Field";
            // 
            // label128
            // 
            this.label128.BackColor = System.Drawing.Color.Transparent;
            this.label128.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label128.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label128.Location = new System.Drawing.Point(186, 3);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(58, 16);
            this.label128.TabIndex = 10073;
            this.label128.Text = "Value";
            // 
            // label130
            // 
            this.label130.BackColor = System.Drawing.Color.Transparent;
            this.label130.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label130.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label130.Location = new System.Drawing.Point(3, 3);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(152, 26);
            this.label130.TabIndex = 10069;
            this.label130.Text = "Achievement";
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox13.Location = new System.Drawing.Point(2, 32);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(265, 2);
            this.pictureBox13.TabIndex = 10070;
            this.pictureBox13.TabStop = false;
            // 
            // panel79
            // 
            this.panel79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel79.Controls.Add(this.label131);
            this.panel79.Controls.Add(this.alertsCustomAchievementXNumericUpDown);
            this.panel79.Location = new System.Drawing.Point(2, 62);
            this.panel79.Name = "panel79";
            this.panel79.Size = new System.Drawing.Size(272, 23);
            this.panel79.TabIndex = 10061;
            // 
            // label131
            // 
            this.label131.BackColor = System.Drawing.Color.Transparent;
            this.label131.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label131.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label131.Location = new System.Drawing.Point(3, 3);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(94, 16);
            this.label131.TabIndex = 10066;
            this.label131.Text = "X position";
            // 
            // panel80
            // 
            this.panel80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel80.Controls.Add(this.label132);
            this.panel80.Controls.Add(this.alertsCustomAchievementInNumericUpDown);
            this.panel80.Location = new System.Drawing.Point(2, 128);
            this.panel80.Name = "panel80";
            this.panel80.Size = new System.Drawing.Size(272, 23);
            this.panel80.TabIndex = 10061;
            // 
            // label132
            // 
            this.label132.BackColor = System.Drawing.Color.Transparent;
            this.label132.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label132.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label132.Location = new System.Drawing.Point(3, 4);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(150, 16);
            this.label132.TabIndex = 10069;
            this.label132.Text = "Animate In Time";
            // 
            // panel81
            // 
            this.panel81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel81.Controls.Add(this.label133);
            this.panel81.Controls.Add(this.alertsCustomAchievementScaleNumericUpDown);
            this.panel81.Location = new System.Drawing.Point(2, 106);
            this.panel81.Name = "panel81";
            this.panel81.Size = new System.Drawing.Size(272, 23);
            this.panel81.TabIndex = 10061;
            // 
            // label133
            // 
            this.label133.BackColor = System.Drawing.Color.Transparent;
            this.label133.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label133.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label133.Location = new System.Drawing.Point(3, 4);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(94, 16);
            this.label133.TabIndex = 10068;
            this.label133.Text = "Scale";
            // 
            // panel82
            // 
            this.panel82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel82.Controls.Add(this.label134);
            this.panel82.Controls.Add(this.alertsCustomAchievementYNumericUpDown);
            this.panel82.Location = new System.Drawing.Point(2, 84);
            this.panel82.Name = "panel82";
            this.panel82.Size = new System.Drawing.Size(272, 23);
            this.panel82.TabIndex = 10061;
            // 
            // label134
            // 
            this.label134.BackColor = System.Drawing.Color.Transparent;
            this.label134.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label134.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label134.Location = new System.Drawing.Point(3, 4);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(94, 16);
            this.label134.TabIndex = 10067;
            this.label134.Text = "Y position";
            // 
            // alertsAchievementEnableCheckbox
            // 
            this.alertsAchievementEnableCheckbox.AutoSize = true;
            this.alertsAchievementEnableCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsAchievementEnableCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsAchievementEnableCheckbox.Location = new System.Drawing.Point(11, 6);
            this.alertsAchievementEnableCheckbox.Name = "alertsAchievementEnableCheckbox";
            this.alertsAchievementEnableCheckbox.Size = new System.Drawing.Size(69, 20);
            this.alertsAchievementEnableCheckbox.TabIndex = 54;
            this.alertsAchievementEnableCheckbox.Text = "Enable";
            this.alertsAchievementEnableCheckbox.UseVisualStyleBackColor = true;
            this.alertsAchievementEnableCheckbox.CheckedChanged += new System.EventHandler(this.CustomAlertsCheckBox_CheckedChanged);
            // 
            // alertsCustomMasteryPanel
            // 
            this.alertsCustomMasteryPanel.Controls.Add(this.panel89);
            this.alertsCustomMasteryPanel.Controls.Add(this.panel90);
            this.alertsCustomMasteryPanel.Controls.Add(this.panel91);
            this.alertsCustomMasteryPanel.Controls.Add(this.alertsMasteryEditOutlineCheckbox);
            this.alertsCustomMasteryPanel.Controls.Add(this.alertsSelectCustomMasteryFileButton);
            this.alertsCustomMasteryPanel.Controls.Add(this.panel92);
            this.alertsCustomMasteryPanel.Controls.Add(this.panel93);
            this.alertsCustomMasteryPanel.Controls.Add(this.panel94);
            this.alertsCustomMasteryPanel.Controls.Add(this.label139);
            this.alertsCustomMasteryPanel.Controls.Add(this.pictureBox14);
            this.alertsCustomMasteryPanel.Controls.Add(this.panel95);
            this.alertsCustomMasteryPanel.Controls.Add(this.panel96);
            this.alertsCustomMasteryPanel.Controls.Add(this.panel97);
            this.alertsCustomMasteryPanel.Controls.Add(this.panel98);
            this.alertsCustomMasteryPanel.Location = new System.Drawing.Point(3, 32);
            this.alertsCustomMasteryPanel.Name = "alertsCustomMasteryPanel";
            this.alertsCustomMasteryPanel.Size = new System.Drawing.Size(279, 294);
            this.alertsCustomMasteryPanel.TabIndex = 10083;
            // 
            // panel89
            // 
            this.panel89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel89.Controls.Add(this.label6);
            this.panel89.Controls.Add(this.alertsCustomMasteryAnimationOutComboBox);
            this.panel89.Location = new System.Drawing.Point(2, 238);
            this.panel89.Name = "panel89";
            this.panel89.Size = new System.Drawing.Size(272, 23);
            this.panel89.TabIndex = 10074;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 16);
            this.label6.TabIndex = 10069;
            this.label6.Text = "Animate Out Direction";
            // 
            // panel90
            // 
            this.panel90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel90.Controls.Add(this.label7);
            this.panel90.Controls.Add(this.alertsCustomMasteryAnimationInComboBox);
            this.panel90.Location = new System.Drawing.Point(2, 172);
            this.panel90.Name = "panel90";
            this.panel90.Size = new System.Drawing.Size(272, 23);
            this.panel90.TabIndex = 10071;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label7.Location = new System.Drawing.Point(3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 16);
            this.label7.TabIndex = 10069;
            this.label7.Text = "Animate In Direction";
            // 
            // panel91
            // 
            this.panel91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel91.Controls.Add(this.label8);
            this.panel91.Controls.Add(this.alertsCustomMasteryOutSpeedUpDown);
            this.panel91.Location = new System.Drawing.Point(2, 216);
            this.panel91.Name = "panel91";
            this.panel91.Size = new System.Drawing.Size(272, 23);
            this.panel91.TabIndex = 10073;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label8.Location = new System.Drawing.Point(3, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 16);
            this.label8.TabIndex = 10069;
            this.label8.Text = "Animate Out Duration";
            // 
            // panel92
            // 
            this.panel92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel92.Controls.Add(this.label11);
            this.panel92.Controls.Add(this.alertsCustomMasteryInSpeedUpDown);
            this.panel92.Location = new System.Drawing.Point(2, 150);
            this.panel92.Name = "panel92";
            this.panel92.Size = new System.Drawing.Size(272, 23);
            this.panel92.TabIndex = 10070;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label11.Location = new System.Drawing.Point(3, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 16);
            this.label11.TabIndex = 10069;
            this.label11.Text = "Animate In Duration";
            // 
            // panel93
            // 
            this.panel93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel93.Controls.Add(this.label12);
            this.panel93.Controls.Add(this.alertsCustomMasteryOutNumericUpDown);
            this.panel93.Location = new System.Drawing.Point(2, 194);
            this.panel93.Name = "panel93";
            this.panel93.Size = new System.Drawing.Size(272, 23);
            this.panel93.TabIndex = 10072;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label12.Location = new System.Drawing.Point(3, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 16);
            this.label12.TabIndex = 10069;
            this.label12.Text = "Animate Out Time";
            // 
            // panel94
            // 
            this.panel94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel94.Controls.Add(this.label13);
            this.panel94.Controls.Add(this.label14);
            this.panel94.Location = new System.Drawing.Point(2, 40);
            this.panel94.Name = "panel94";
            this.panel94.Size = new System.Drawing.Size(272, 23);
            this.panel94.TabIndex = 10079;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label13.Location = new System.Drawing.Point(3, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 16);
            this.label13.TabIndex = 10071;
            this.label13.Text = "Field";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label14.Location = new System.Drawing.Point(186, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 16);
            this.label14.TabIndex = 10073;
            this.label14.Text = "Value";
            // 
            // label139
            // 
            this.label139.BackColor = System.Drawing.Color.Transparent;
            this.label139.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label139.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label139.Location = new System.Drawing.Point(3, 3);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(152, 26);
            this.label139.TabIndex = 10069;
            this.label139.Text = "Mastery";
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox14.Location = new System.Drawing.Point(2, 32);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(265, 2);
            this.pictureBox14.TabIndex = 10070;
            this.pictureBox14.TabStop = false;
            // 
            // panel95
            // 
            this.panel95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel95.Controls.Add(this.label140);
            this.panel95.Controls.Add(this.alertsCustomMasteryXNumericUpDown);
            this.panel95.Location = new System.Drawing.Point(2, 62);
            this.panel95.Name = "panel95";
            this.panel95.Size = new System.Drawing.Size(272, 23);
            this.panel95.TabIndex = 10061;
            // 
            // label140
            // 
            this.label140.BackColor = System.Drawing.Color.Transparent;
            this.label140.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label140.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label140.Location = new System.Drawing.Point(3, 3);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(94, 16);
            this.label140.TabIndex = 10066;
            this.label140.Text = "X position";
            // 
            // panel96
            // 
            this.panel96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel96.Controls.Add(this.label141);
            this.panel96.Controls.Add(this.alertsCustomMasteryInNumericUpDown);
            this.panel96.Location = new System.Drawing.Point(2, 128);
            this.panel96.Name = "panel96";
            this.panel96.Size = new System.Drawing.Size(272, 23);
            this.panel96.TabIndex = 10061;
            // 
            // label141
            // 
            this.label141.BackColor = System.Drawing.Color.Transparent;
            this.label141.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label141.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label141.Location = new System.Drawing.Point(3, 4);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(150, 16);
            this.label141.TabIndex = 10069;
            this.label141.Text = "Animate In Time";
            // 
            // panel97
            // 
            this.panel97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel97.Controls.Add(this.label142);
            this.panel97.Controls.Add(this.alertsCustomMasteryScaleNumericUpDown);
            this.panel97.Location = new System.Drawing.Point(2, 106);
            this.panel97.Name = "panel97";
            this.panel97.Size = new System.Drawing.Size(272, 23);
            this.panel97.TabIndex = 10061;
            // 
            // label142
            // 
            this.label142.BackColor = System.Drawing.Color.Transparent;
            this.label142.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label142.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label142.Location = new System.Drawing.Point(3, 4);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(94, 16);
            this.label142.TabIndex = 10068;
            this.label142.Text = "Scale";
            // 
            // panel98
            // 
            this.panel98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel98.Controls.Add(this.label143);
            this.panel98.Controls.Add(this.alertsCustomMasteryYNumericUpDown);
            this.panel98.Location = new System.Drawing.Point(2, 84);
            this.panel98.Name = "panel98";
            this.panel98.Size = new System.Drawing.Size(272, 23);
            this.panel98.TabIndex = 10061;
            // 
            // label143
            // 
            this.label143.BackColor = System.Drawing.Color.Transparent;
            this.label143.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label143.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label143.Location = new System.Drawing.Point(3, 4);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(94, 16);
            this.label143.TabIndex = 10067;
            this.label143.Text = "Y position";
            // 
            // alertsMasteryEnableCheckbox
            // 
            this.alertsMasteryEnableCheckbox.AutoSize = true;
            this.alertsMasteryEnableCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsMasteryEnableCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.alertsMasteryEnableCheckbox.Location = new System.Drawing.Point(11, 6);
            this.alertsMasteryEnableCheckbox.Name = "alertsMasteryEnableCheckbox";
            this.alertsMasteryEnableCheckbox.Size = new System.Drawing.Size(69, 20);
            this.alertsMasteryEnableCheckbox.TabIndex = 54;
            this.alertsMasteryEnableCheckbox.Text = "Enable";
            this.alertsMasteryEnableCheckbox.UseVisualStyleBackColor = true;
            this.alertsMasteryEnableCheckbox.CheckedChanged += new System.EventHandler(this.CustomAlertsCheckBox_CheckedChanged);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel14.Controls.Add(this.userInfoUsernameLabel);
            this.panel14.Controls.Add(this.userInfoRankLabel);
            this.panel14.Controls.Add(this.userInfoPointsLabel);
            this.panel14.Controls.Add(this.label37);
            this.panel14.Controls.Add(this.userInfoTruePointsLabel);
            this.panel14.Controls.Add(this.userProfilePictureBox);
            this.panel14.Controls.Add(this.userInfoMottoLabel);
            this.panel14.Controls.Add(this.userInfoRatioLabel);
            this.panel14.Controls.Add(this.pictureBox2);
            this.panel14.Location = new System.Drawing.Point(296, 184);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(468, 181);
            this.panel14.TabIndex = 10079;
            // 
            // userInfoUsernameLabel
            // 
            this.userInfoUsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.userInfoUsernameLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoUsernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoUsernameLabel.Location = new System.Drawing.Point(3, 3);
            this.userInfoUsernameLabel.Name = "userInfoUsernameLabel";
            this.userInfoUsernameLabel.Size = new System.Drawing.Size(459, 26);
            this.userInfoUsernameLabel.TabIndex = 10058;
            this.userInfoUsernameLabel.Text = "Username";
            // 
            // userInfoRankLabel
            // 
            this.userInfoRankLabel.BackColor = System.Drawing.Color.Transparent;
            this.userInfoRankLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRankLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoRankLabel.Location = new System.Drawing.Point(6, 78);
            this.userInfoRankLabel.Name = "userInfoRankLabel";
            this.userInfoRankLabel.Size = new System.Drawing.Size(202, 16);
            this.userInfoRankLabel.TabIndex = 10054;
            this.userInfoRankLabel.Text = "Site Rank: 15000";
            // 
            // userInfoPointsLabel
            // 
            this.userInfoPointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.userInfoPointsLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoPointsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoPointsLabel.Location = new System.Drawing.Point(6, 62);
            this.userInfoPointsLabel.Name = "userInfoPointsLabel";
            this.userInfoPointsLabel.Size = new System.Drawing.Size(187, 16);
            this.userInfoPointsLabel.TabIndex = 10055;
            this.userInfoPointsLabel.Text = "Hardcore Points: 348897";
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label37.Location = new System.Drawing.Point(6, 94);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(94, 16);
            this.label37.TabIndex = 10075;
            this.label37.Text = "Retro Ratio:";
            // 
            // userInfoTruePointsLabel
            // 
            this.userInfoTruePointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.userInfoTruePointsLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoTruePointsLabel.ForeColor = System.Drawing.Color.White;
            this.userInfoTruePointsLabel.Location = new System.Drawing.Point(194, 62);
            this.userInfoTruePointsLabel.Name = "userInfoTruePointsLabel";
            this.userInfoTruePointsLabel.Size = new System.Drawing.Size(85, 16);
            this.userInfoTruePointsLabel.TabIndex = 10056;
            this.userInfoTruePointsLabel.Text = "(10019920)";
            // 
            // userInfoMottoLabel
            // 
            this.userInfoMottoLabel.AutoSize = true;
            this.userInfoMottoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoMottoLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoMottoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoMottoLabel.Location = new System.Drawing.Point(6, 37);
            this.userInfoMottoLabel.Margin = new System.Windows.Forms.Padding(3);
            this.userInfoMottoLabel.Name = "userInfoMottoLabel";
            this.userInfoMottoLabel.Padding = new System.Windows.Forms.Padding(3);
            this.userInfoMottoLabel.Size = new System.Drawing.Size(158, 22);
            this.userInfoMottoLabel.TabIndex = 10074;
            this.userInfoMottoLabel.Text = "twitch.tv/RetroS3xual";
            // 
            // userInfoRatioLabel
            // 
            this.userInfoRatioLabel.BackColor = System.Drawing.Color.Transparent;
            this.userInfoRatioLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRatioLabel.ForeColor = System.Drawing.Color.White;
            this.userInfoRatioLabel.Location = new System.Drawing.Point(97, 94);
            this.userInfoRatioLabel.Name = "userInfoRatioLabel";
            this.userInfoRatioLabel.Size = new System.Drawing.Size(73, 16);
            this.userInfoRatioLabel.TabIndex = 10057;
            this.userInfoRatioLabel.Text = "3.62";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox2.Location = new System.Drawing.Point(2, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(460, 2);
            this.pictureBox2.TabIndex = 10059;
            this.pictureBox2.TabStop = false;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel21.Controls.Add(this.panel22);
            this.panel21.Controls.Add(this.label28);
            this.panel21.Controls.Add(this.userInfoDefaultButton);
            this.panel21.Controls.Add(this.pictureBox4);
            this.panel21.Controls.Add(this.panel10);
            this.panel21.Controls.Add(this.panel13);
            this.panel21.Controls.Add(this.panel12);
            this.panel21.Controls.Add(this.panel11);
            this.panel21.Location = new System.Drawing.Point(4, 3);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(287, 158);
            this.panel21.TabIndex = 10078;
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel22.Controls.Add(this.label29);
            this.panel22.Controls.Add(this.label32);
            this.panel22.Controls.Add(this.label30);
            this.panel22.Location = new System.Drawing.Point(2, 40);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(278, 23);
            this.panel22.TabIndex = 10079;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label29.Location = new System.Drawing.Point(3, 3);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(50, 16);
            this.label29.TabIndex = 10071;
            this.label29.Text = "Field";
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label32.Location = new System.Drawing.Point(113, 3);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(102, 16);
            this.label32.TabIndex = 10073;
            this.label32.Text = "Display Text";
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label30.Location = new System.Drawing.Point(221, 3);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(61, 16);
            this.label30.TabIndex = 10072;
            this.label30.Text = "Enabled";
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label28.Location = new System.Drawing.Point(3, 3);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(190, 26);
            this.label28.TabIndex = 10069;
            this.label28.Text = "Field Overrides";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox4.Location = new System.Drawing.Point(2, 32);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(275, 2);
            this.pictureBox4.TabIndex = 10070;
            this.pictureBox4.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel10.Controls.Add(this.label31);
            this.panel10.Controls.Add(this.userInfoRankCheckBox);
            this.panel10.Controls.Add(this.userInfoRankTextBox);
            this.panel10.Location = new System.Drawing.Point(2, 62);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(278, 23);
            this.panel10.TabIndex = 10061;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label31.Location = new System.Drawing.Point(3, 3);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 16);
            this.label31.TabIndex = 10066;
            this.label31.Text = "Rank";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel13.Controls.Add(this.label35);
            this.panel13.Controls.Add(this.userInfoRatioCheckBox);
            this.panel13.Controls.Add(this.userInfoRatioTextBox);
            this.panel13.Location = new System.Drawing.Point(2, 128);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(278, 23);
            this.panel13.TabIndex = 10061;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label35.Location = new System.Drawing.Point(3, 4);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(94, 16);
            this.label35.TabIndex = 10069;
            this.label35.Text = "Retro Ratio";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel12.Controls.Add(this.label34);
            this.panel12.Controls.Add(this.userInfoTruePointsTextBox);
            this.panel12.Controls.Add(this.userInfoTruePointsCheckBox);
            this.panel12.Location = new System.Drawing.Point(2, 106);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(278, 23);
            this.panel12.TabIndex = 10061;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label34.Location = new System.Drawing.Point(3, 4);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(94, 16);
            this.label34.TabIndex = 10068;
            this.label34.Text = "True Points";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel11.Controls.Add(this.label33);
            this.panel11.Controls.Add(this.userInfoPointsTextBox);
            this.panel11.Controls.Add(this.userInfoPointsCheckBox);
            this.panel11.Location = new System.Drawing.Point(2, 84);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(278, 23);
            this.panel11.TabIndex = 10061;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label33.Location = new System.Drawing.Point(3, 4);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(94, 16);
            this.label33.TabIndex = 10067;
            this.label33.Text = "Points";
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel20.Controls.Add(this.label2);
            this.panel20.Controls.Add(this.panel4);
            this.panel20.Controls.Add(this.userInfoOpenWindowButton);
            this.panel20.Controls.Add(this.userInfoValuesPanel);
            this.panel20.Controls.Add(this.userInfoAutoOpenWindowCheckbox);
            this.panel20.Controls.Add(this.pictureBox3);
            this.panel20.Controls.Add(this.panel5);
            this.panel20.Controls.Add(this.panel6);
            this.panel20.Controls.Add(this.panel7);
            this.panel20.Controls.Add(this.userInfoValuesOutlinePanel);
            this.panel20.Location = new System.Drawing.Point(296, 3);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(468, 176);
            this.panel20.TabIndex = 10077;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 26);
            this.label2.TabIndex = 10062;
            this.label2.Text = "Window/Font Settings";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel4.Controls.Add(this.userInfoAdvancedCheckBox);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Location = new System.Drawing.Point(2, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(463, 23);
            this.panel4.TabIndex = 10076;
            // 
            // userInfoAdvancedCheckBox
            // 
            this.userInfoAdvancedCheckBox.AutoSize = true;
            this.userInfoAdvancedCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.userInfoAdvancedCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userInfoAdvancedCheckBox.FlatAppearance.BorderSize = 0;
            this.userInfoAdvancedCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.userInfoAdvancedCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoAdvancedCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoAdvancedCheckBox.Location = new System.Drawing.Point(5, 2);
            this.userInfoAdvancedCheckBox.Name = "userInfoAdvancedCheckBox";
            this.userInfoAdvancedCheckBox.Size = new System.Drawing.Size(91, 20);
            this.userInfoAdvancedCheckBox.TabIndex = 10053;
            this.userInfoAdvancedCheckBox.Text = "Advanced";
            this.userInfoAdvancedCheckBox.UseVisualStyleBackColor = false;
            this.userInfoAdvancedCheckBox.CheckedChanged += new System.EventHandler(this.AdvancedCheckBox_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(150, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 10065;
            this.label4.Text = "Color";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label9.Location = new System.Drawing.Point(194, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 10066;
            this.label9.Text = "Font";
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label25.Location = new System.Drawing.Point(349, 3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 16);
            this.label25.TabIndex = 10068;
            this.label25.Text = "Size";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label15.Location = new System.Drawing.Point(396, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 16);
            this.label15.TabIndex = 10067;
            this.label15.Text = "Enabled";
            // 
            // userInfoValuesPanel
            // 
            this.userInfoValuesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoValuesPanel.Controls.Add(this.label26);
            this.userInfoValuesPanel.Controls.Add(this.userInfoValuesFontColorPictureBox);
            this.userInfoValuesPanel.Controls.Add(this.userInfoValuesFontComboBox);
            this.userInfoValuesPanel.Location = new System.Drawing.Point(2, 106);
            this.userInfoValuesPanel.Name = "userInfoValuesPanel";
            this.userInfoValuesPanel.Size = new System.Drawing.Size(463, 23);
            this.userInfoValuesPanel.TabIndex = 10061;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label26.Location = new System.Drawing.Point(3, 4);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(144, 16);
            this.label26.TabIndex = 10066;
            this.label26.Text = "Values";
            // 
            // userInfoValuesFontColorPictureBox
            // 
            this.userInfoValuesFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.userInfoValuesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoValuesFontColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.userInfoValuesFontColorPictureBox.Name = "userInfoValuesFontColorPictureBox";
            this.userInfoValuesFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.userInfoValuesFontColorPictureBox.TabIndex = 45;
            this.userInfoValuesFontColorPictureBox.TabStop = false;
            this.userInfoValuesFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // userInfoValuesFontComboBox
            // 
            this.userInfoValuesFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoValuesFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoValuesFontComboBox.ForeColor = System.Drawing.Color.White;
            this.userInfoValuesFontComboBox.FormattingEnabled = true;
            this.userInfoValuesFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.userInfoValuesFontComboBox.Name = "userInfoValuesFontComboBox";
            this.userInfoValuesFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.userInfoValuesFontComboBox.TabIndex = 45;
            this.userInfoValuesFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox3.Location = new System.Drawing.Point(2, 32);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(460, 2);
            this.pictureBox3.TabIndex = 10063;
            this.pictureBox3.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel5.Controls.Add(this.userInfoBackgroundColorPictureBox);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(2, 62);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(463, 23);
            this.panel5.TabIndex = 10061;
            // 
            // userInfoBackgroundColorPictureBox
            // 
            this.userInfoBackgroundColorPictureBox.BackColor = System.Drawing.Color.White;
            this.userInfoBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoBackgroundColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.userInfoBackgroundColorPictureBox.Name = "userInfoBackgroundColorPictureBox";
            this.userInfoBackgroundColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.userInfoBackgroundColorPictureBox.TabIndex = 42;
            this.userInfoBackgroundColorPictureBox.TabStop = false;
            this.userInfoBackgroundColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 10064;
            this.label3.Text = "Window Background";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel6.Controls.Add(this.userInfoNamesLabel);
            this.panel6.Controls.Add(this.userInfoNamesFontColorPictureBox);
            this.panel6.Controls.Add(this.userInfoNamesFontComboBox);
            this.panel6.Location = new System.Drawing.Point(2, 84);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(463, 23);
            this.panel6.TabIndex = 10061;
            // 
            // userInfoNamesLabel
            // 
            this.userInfoNamesLabel.BackColor = System.Drawing.Color.Transparent;
            this.userInfoNamesLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoNamesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoNamesLabel.Location = new System.Drawing.Point(3, 4);
            this.userInfoNamesLabel.Name = "userInfoNamesLabel";
            this.userInfoNamesLabel.Size = new System.Drawing.Size(144, 16);
            this.userInfoNamesLabel.TabIndex = 10065;
            this.userInfoNamesLabel.Text = "Names";
            // 
            // userInfoNamesFontColorPictureBox
            // 
            this.userInfoNamesFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.userInfoNamesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoNamesFontColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.userInfoNamesFontColorPictureBox.Name = "userInfoNamesFontColorPictureBox";
            this.userInfoNamesFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.userInfoNamesFontColorPictureBox.TabIndex = 45;
            this.userInfoNamesFontColorPictureBox.TabStop = false;
            this.userInfoNamesFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // userInfoNamesFontComboBox
            // 
            this.userInfoNamesFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoNamesFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoNamesFontComboBox.ForeColor = System.Drawing.Color.White;
            this.userInfoNamesFontComboBox.FormattingEnabled = true;
            this.userInfoNamesFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.userInfoNamesFontComboBox.Name = "userInfoNamesFontComboBox";
            this.userInfoNamesFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.userInfoNamesFontComboBox.TabIndex = 45;
            this.userInfoNamesFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel7.Controls.Add(this.userInfoNamesFontOutlineNumericUpDown);
            this.panel7.Controls.Add(this.userInfoNamesOutlineCheckBox);
            this.panel7.Controls.Add(this.userInfoNamesOutlineLabel);
            this.panel7.Controls.Add(this.userInfoNamesFontOutlineColorPictureBox);
            this.panel7.Location = new System.Drawing.Point(2, 128);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(463, 23);
            this.panel7.TabIndex = 10061;
            // 
            // userInfoNamesFontOutlineNumericUpDown
            // 
            this.userInfoNamesFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.userInfoNamesFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userInfoNamesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoNamesFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.userInfoNamesFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.userInfoNamesFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.userInfoNamesFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.userInfoNamesFontOutlineNumericUpDown.Name = "userInfoNamesFontOutlineNumericUpDown";
            this.userInfoNamesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.userInfoNamesFontOutlineNumericUpDown.TabIndex = 45;
            this.userInfoNamesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.userInfoNamesFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // userInfoNamesOutlineCheckBox
            // 
            this.userInfoNamesOutlineCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.userInfoNamesOutlineCheckBox.FlatAppearance.BorderSize = 0;
            this.userInfoNamesOutlineCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoNamesOutlineCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.userInfoNamesOutlineCheckBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoNamesOutlineCheckBox.ForeColor = System.Drawing.Color.White;
            this.userInfoNamesOutlineCheckBox.Location = new System.Drawing.Point(413, 5);
            this.userInfoNamesOutlineCheckBox.Name = "userInfoNamesOutlineCheckBox";
            this.userInfoNamesOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.userInfoNamesOutlineCheckBox.TabIndex = 45;
            this.userInfoNamesOutlineCheckBox.UseVisualStyleBackColor = true;
            this.userInfoNamesOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // userInfoNamesOutlineLabel
            // 
            this.userInfoNamesOutlineLabel.BackColor = System.Drawing.Color.Transparent;
            this.userInfoNamesOutlineLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoNamesOutlineLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoNamesOutlineLabel.Location = new System.Drawing.Point(3, 3);
            this.userInfoNamesOutlineLabel.Name = "userInfoNamesOutlineLabel";
            this.userInfoNamesOutlineLabel.Size = new System.Drawing.Size(144, 16);
            this.userInfoNamesOutlineLabel.TabIndex = 10066;
            this.userInfoNamesOutlineLabel.Text = "Names Outline";
            // 
            // userInfoNamesFontOutlineColorPictureBox
            // 
            this.userInfoNamesFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.userInfoNamesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoNamesFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.userInfoNamesFontOutlineColorPictureBox.Name = "userInfoNamesFontOutlineColorPictureBox";
            this.userInfoNamesFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.userInfoNamesFontOutlineColorPictureBox.TabIndex = 45;
            this.userInfoNamesFontOutlineColorPictureBox.TabStop = false;
            this.userInfoNamesFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // userInfoValuesOutlinePanel
            // 
            this.userInfoValuesOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoValuesOutlinePanel.Controls.Add(this.label27);
            this.userInfoValuesOutlinePanel.Controls.Add(this.userInfoValuesFontOutlineColorPictureBox);
            this.userInfoValuesOutlinePanel.Controls.Add(this.userInfoValuesFontOutlineNumericUpDown);
            this.userInfoValuesOutlinePanel.Controls.Add(this.userInfoValuesOutlineCheckBox);
            this.userInfoValuesOutlinePanel.Location = new System.Drawing.Point(2, 150);
            this.userInfoValuesOutlinePanel.Name = "userInfoValuesOutlinePanel";
            this.userInfoValuesOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.userInfoValuesOutlinePanel.TabIndex = 10067;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label27.Location = new System.Drawing.Point(3, 4);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(144, 16);
            this.label27.TabIndex = 10066;
            this.label27.Text = "Values Outline";
            // 
            // userInfoValuesFontOutlineColorPictureBox
            // 
            this.userInfoValuesFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.userInfoValuesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoValuesFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.userInfoValuesFontOutlineColorPictureBox.Name = "userInfoValuesFontOutlineColorPictureBox";
            this.userInfoValuesFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.userInfoValuesFontOutlineColorPictureBox.TabIndex = 45;
            this.userInfoValuesFontOutlineColorPictureBox.TabStop = false;
            this.userInfoValuesFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // userInfoValuesFontOutlineNumericUpDown
            // 
            this.userInfoValuesFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.userInfoValuesFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userInfoValuesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoValuesFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.userInfoValuesFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.userInfoValuesFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.userInfoValuesFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.userInfoValuesFontOutlineNumericUpDown.Name = "userInfoValuesFontOutlineNumericUpDown";
            this.userInfoValuesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.userInfoValuesFontOutlineNumericUpDown.TabIndex = 45;
            this.userInfoValuesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.userInfoValuesFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // userInfoValuesOutlineCheckBox
            // 
            this.userInfoValuesOutlineCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.userInfoValuesOutlineCheckBox.FlatAppearance.BorderSize = 0;
            this.userInfoValuesOutlineCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoValuesOutlineCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.userInfoValuesOutlineCheckBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoValuesOutlineCheckBox.ForeColor = System.Drawing.Color.White;
            this.userInfoValuesOutlineCheckBox.Location = new System.Drawing.Point(413, 6);
            this.userInfoValuesOutlineCheckBox.Name = "userInfoValuesOutlineCheckBox";
            this.userInfoValuesOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.userInfoValuesOutlineCheckBox.TabIndex = 45;
            this.userInfoValuesOutlineCheckBox.UseVisualStyleBackColor = true;
            this.userInfoValuesOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // panel50
            // 
            this.panel50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel50.Controls.Add(this.panel119);
            this.panel50.Controls.Add(this.panel117);
            this.panel50.Controls.Add(this.panel118);
            this.panel50.Controls.Add(this.panel116);
            this.panel50.Controls.Add(this.gameInfoTitleLabel);
            this.panel50.Controls.Add(this.pictureBox8);
            this.panel50.Controls.Add(this.gameInfoPictureBox);
            this.panel50.Location = new System.Drawing.Point(296, 184);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(468, 181);
            this.panel50.TabIndex = 10081;
            // 
            // panel119
            // 
            this.panel119.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel119.Controls.Add(this.gameInfoGenreLabel);
            this.panel119.Controls.Add(this.label62);
            this.panel119.Controls.Add(this.label36);
            this.panel119.Location = new System.Drawing.Point(109, 102);
            this.panel119.Name = "panel119";
            this.panel119.Size = new System.Drawing.Size(348, 25);
            this.panel119.TabIndex = 10073;
            // 
            // gameInfoGenreLabel
            // 
            this.gameInfoGenreLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoGenreLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoGenreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameInfoGenreLabel.Location = new System.Drawing.Point(103, 5);
            this.gameInfoGenreLabel.Name = "gameInfoGenreLabel";
            this.gameInfoGenreLabel.Size = new System.Drawing.Size(242, 16);
            this.gameInfoGenreLabel.TabIndex = 10066;
            this.gameInfoGenreLabel.UseMnemonic = false;
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label62.Location = new System.Drawing.Point(3, 5);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(94, 16);
            this.label62.TabIndex = 10070;
            this.label62.Text = "Genre";
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.label36.Location = new System.Drawing.Point(135, 3);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(210, 16);
            this.label36.TabIndex = 10066;
            this.label36.UseMnemonic = false;
            // 
            // panel117
            // 
            this.panel117.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel117.Controls.Add(this.label89);
            this.panel117.Controls.Add(this.gameInfoReleasedLabel);
            this.panel117.Location = new System.Drawing.Point(109, 127);
            this.panel117.Name = "panel117";
            this.panel117.Size = new System.Drawing.Size(348, 25);
            this.panel117.TabIndex = 10072;
            // 
            // label89
            // 
            this.label89.BackColor = System.Drawing.Color.Transparent;
            this.label89.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label89.Location = new System.Drawing.Point(3, 5);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(94, 16);
            this.label89.TabIndex = 10070;
            this.label89.Text = "Released";
            // 
            // gameInfoReleasedLabel
            // 
            this.gameInfoReleasedLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoReleasedLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoReleasedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoReleasedLabel.Location = new System.Drawing.Point(103, 5);
            this.gameInfoReleasedLabel.Name = "gameInfoReleasedLabel";
            this.gameInfoReleasedLabel.Size = new System.Drawing.Size(242, 16);
            this.gameInfoReleasedLabel.TabIndex = 10067;
            this.gameInfoReleasedLabel.UseMnemonic = false;
            // 
            // panel118
            // 
            this.panel118.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel118.Controls.Add(this.label61);
            this.panel118.Controls.Add(this.gameInfoPublisherLabel);
            this.panel118.Location = new System.Drawing.Point(109, 77);
            this.panel118.Name = "panel118";
            this.panel118.Size = new System.Drawing.Size(348, 25);
            this.panel118.TabIndex = 10073;
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.Color.Transparent;
            this.label61.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label61.Location = new System.Drawing.Point(3, 6);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(94, 16);
            this.label61.TabIndex = 10069;
            this.label61.Text = "Publisher";
            // 
            // gameInfoPublisherLabel
            // 
            this.gameInfoPublisherLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoPublisherLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoPublisherLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameInfoPublisherLabel.Location = new System.Drawing.Point(103, 6);
            this.gameInfoPublisherLabel.Name = "gameInfoPublisherLabel";
            this.gameInfoPublisherLabel.Size = new System.Drawing.Size(242, 16);
            this.gameInfoPublisherLabel.TabIndex = 10064;
            this.gameInfoPublisherLabel.UseMnemonic = false;
            // 
            // panel116
            // 
            this.panel116.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel116.Controls.Add(this.label57);
            this.panel116.Controls.Add(this.gameInfoDeveloperLabel);
            this.panel116.Location = new System.Drawing.Point(109, 52);
            this.panel116.Name = "panel116";
            this.panel116.Size = new System.Drawing.Size(348, 25);
            this.panel116.TabIndex = 10071;
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.Transparent;
            this.label57.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label57.Location = new System.Drawing.Point(3, 3);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(94, 16);
            this.label57.TabIndex = 10070;
            this.label57.Text = "Developer";
            // 
            // gameInfoDeveloperLabel
            // 
            this.gameInfoDeveloperLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoDeveloperLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDeveloperLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameInfoDeveloperLabel.Location = new System.Drawing.Point(103, 3);
            this.gameInfoDeveloperLabel.Name = "gameInfoDeveloperLabel";
            this.gameInfoDeveloperLabel.Size = new System.Drawing.Size(242, 16);
            this.gameInfoDeveloperLabel.TabIndex = 10063;
            this.gameInfoDeveloperLabel.UseMnemonic = false;
            // 
            // gameInfoTitleLabel
            // 
            this.gameInfoTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoTitleLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoTitleLabel.Location = new System.Drawing.Point(3, 3);
            this.gameInfoTitleLabel.Name = "gameInfoTitleLabel";
            this.gameInfoTitleLabel.Size = new System.Drawing.Size(459, 38);
            this.gameInfoTitleLabel.TabIndex = 10058;
            this.gameInfoTitleLabel.Text = "Game Info Title";
            this.gameInfoTitleLabel.UseMnemonic = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox8.Location = new System.Drawing.Point(2, 44);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(460, 2);
            this.pictureBox8.TabIndex = 10059;
            this.pictureBox8.TabStop = false;
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel29.Controls.Add(this.panel49);
            this.panel29.Controls.Add(this.panel48);
            this.panel29.Controls.Add(this.panel30);
            this.panel29.Controls.Add(this.label66);
            this.panel29.Controls.Add(this.gameInfoDefaultButton);
            this.panel29.Controls.Add(this.pictureBox7);
            this.panel29.Controls.Add(this.panel31);
            this.panel29.Controls.Add(this.panel32);
            this.panel29.Controls.Add(this.panel33);
            this.panel29.Controls.Add(this.panel34);
            this.panel29.Location = new System.Drawing.Point(4, 3);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(287, 201);
            this.panel29.TabIndex = 10080;
            // 
            // panel49
            // 
            this.panel49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel49.Controls.Add(this.label88);
            this.panel49.Controls.Add(this.gameInfoReleasedCheckBox);
            this.panel49.Controls.Add(this.gameInfoReleaseDateTextBox);
            this.panel49.Location = new System.Drawing.Point(2, 172);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(278, 23);
            this.panel49.TabIndex = 10071;
            // 
            // label88
            // 
            this.label88.BackColor = System.Drawing.Color.Transparent;
            this.label88.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label88.Location = new System.Drawing.Point(3, 4);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(94, 16);
            this.label88.TabIndex = 10069;
            this.label88.Text = "Released";
            // 
            // gameInfoReleasedCheckBox
            // 
            this.gameInfoReleasedCheckBox.AutoSize = true;
            this.gameInfoReleasedCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoReleasedCheckBox.Location = new System.Drawing.Point(225, 5);
            this.gameInfoReleasedCheckBox.Name = "gameInfoReleasedCheckBox";
            this.gameInfoReleasedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoReleasedCheckBox.TabIndex = 55;
            this.gameInfoReleasedCheckBox.UseVisualStyleBackColor = true;
            this.gameInfoReleasedCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // gameInfoReleaseDateTextBox
            // 
            this.gameInfoReleaseDateTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoReleaseDateTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoReleaseDateTextBox.ForeColor = System.Drawing.Color.White;
            this.gameInfoReleaseDateTextBox.Location = new System.Drawing.Point(116, 0);
            this.gameInfoReleaseDateTextBox.Name = "gameInfoReleaseDateTextBox";
            this.gameInfoReleaseDateTextBox.Size = new System.Drawing.Size(99, 23);
            this.gameInfoReleaseDateTextBox.TabIndex = 5;
            this.gameInfoReleaseDateTextBox.Text = "Released";
            this.gameInfoReleaseDateTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // panel48
            // 
            this.panel48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel48.Controls.Add(this.label87);
            this.panel48.Controls.Add(this.gameInfoGenreCheckBox);
            this.panel48.Controls.Add(this.gameInfoGenreTextBox);
            this.panel48.Location = new System.Drawing.Point(2, 150);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(278, 23);
            this.panel48.TabIndex = 10070;
            // 
            // label87
            // 
            this.label87.BackColor = System.Drawing.Color.Transparent;
            this.label87.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label87.Location = new System.Drawing.Point(3, 4);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(94, 16);
            this.label87.TabIndex = 10069;
            this.label87.Text = "Genre";
            // 
            // gameInfoGenreCheckBox
            // 
            this.gameInfoGenreCheckBox.AutoSize = true;
            this.gameInfoGenreCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoGenreCheckBox.Location = new System.Drawing.Point(225, 5);
            this.gameInfoGenreCheckBox.Name = "gameInfoGenreCheckBox";
            this.gameInfoGenreCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoGenreCheckBox.TabIndex = 55;
            this.gameInfoGenreCheckBox.UseVisualStyleBackColor = true;
            this.gameInfoGenreCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // gameInfoGenreTextBox
            // 
            this.gameInfoGenreTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoGenreTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoGenreTextBox.ForeColor = System.Drawing.Color.White;
            this.gameInfoGenreTextBox.Location = new System.Drawing.Point(116, 0);
            this.gameInfoGenreTextBox.Name = "gameInfoGenreTextBox";
            this.gameInfoGenreTextBox.Size = new System.Drawing.Size(99, 23);
            this.gameInfoGenreTextBox.TabIndex = 5;
            this.gameInfoGenreTextBox.Text = "Genre";
            this.gameInfoGenreTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel30.Controls.Add(this.label63);
            this.panel30.Controls.Add(this.label64);
            this.panel30.Controls.Add(this.label65);
            this.panel30.Location = new System.Drawing.Point(2, 40);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(278, 23);
            this.panel30.TabIndex = 10079;
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label63.Location = new System.Drawing.Point(3, 3);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(50, 16);
            this.label63.TabIndex = 10071;
            this.label63.Text = "Field";
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.Color.Transparent;
            this.label64.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label64.Location = new System.Drawing.Point(113, 3);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(102, 16);
            this.label64.TabIndex = 10073;
            this.label64.Text = "Display Text";
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Transparent;
            this.label65.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label65.Location = new System.Drawing.Point(221, 3);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(61, 16);
            this.label65.TabIndex = 10072;
            this.label65.Text = "Enabled";
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label66.Location = new System.Drawing.Point(3, 3);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(190, 26);
            this.label66.TabIndex = 10069;
            this.label66.Text = "Field Overrides";
            // 
            // gameInfoDefaultButton
            // 
            this.gameInfoDefaultButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoDefaultButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.gameInfoDefaultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameInfoDefaultButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDefaultButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.gameInfoDefaultButton.Location = new System.Drawing.Point(204, 2);
            this.gameInfoDefaultButton.Margin = new System.Windows.Forms.Padding(0);
            this.gameInfoDefaultButton.Name = "gameInfoDefaultButton";
            this.gameInfoDefaultButton.Size = new System.Drawing.Size(75, 27);
            this.gameInfoDefaultButton.TabIndex = 39;
            this.gameInfoDefaultButton.Text = "Default";
            this.gameInfoDefaultButton.UseVisualStyleBackColor = false;
            this.gameInfoDefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox7.Location = new System.Drawing.Point(2, 32);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(275, 2);
            this.pictureBox7.TabIndex = 10070;
            this.pictureBox7.TabStop = false;
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel31.Controls.Add(this.label67);
            this.panel31.Controls.Add(this.gameInfoTitleCheckBox);
            this.panel31.Controls.Add(this.gameInfoTitleTextBox);
            this.panel31.Location = new System.Drawing.Point(2, 62);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(278, 23);
            this.panel31.TabIndex = 10061;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Transparent;
            this.label67.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label67.Location = new System.Drawing.Point(3, 3);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(94, 16);
            this.label67.TabIndex = 10066;
            this.label67.Text = "Title";
            // 
            // gameInfoTitleCheckBox
            // 
            this.gameInfoTitleCheckBox.AutoSize = true;
            this.gameInfoTitleCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoTitleCheckBox.Location = new System.Drawing.Point(225, 5);
            this.gameInfoTitleCheckBox.Name = "gameInfoTitleCheckBox";
            this.gameInfoTitleCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoTitleCheckBox.TabIndex = 52;
            this.gameInfoTitleCheckBox.UseVisualStyleBackColor = true;
            this.gameInfoTitleCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // gameInfoTitleTextBox
            // 
            this.gameInfoTitleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoTitleTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoTitleTextBox.ForeColor = System.Drawing.Color.White;
            this.gameInfoTitleTextBox.Location = new System.Drawing.Point(116, 0);
            this.gameInfoTitleTextBox.Name = "gameInfoTitleTextBox";
            this.gameInfoTitleTextBox.Size = new System.Drawing.Size(99, 23);
            this.gameInfoTitleTextBox.TabIndex = 1;
            this.gameInfoTitleTextBox.Text = "Title";
            this.gameInfoTitleTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel32.Controls.Add(this.label68);
            this.panel32.Controls.Add(this.gameInfoConsoleCheckBox);
            this.panel32.Controls.Add(this.gameInfoConsoleTextBox);
            this.panel32.Location = new System.Drawing.Point(2, 128);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(278, 23);
            this.panel32.TabIndex = 10061;
            // 
            // label68
            // 
            this.label68.BackColor = System.Drawing.Color.Transparent;
            this.label68.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label68.Location = new System.Drawing.Point(3, 4);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(94, 16);
            this.label68.TabIndex = 10069;
            this.label68.Text = "Console";
            // 
            // gameInfoConsoleCheckBox
            // 
            this.gameInfoConsoleCheckBox.AutoSize = true;
            this.gameInfoConsoleCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoConsoleCheckBox.Location = new System.Drawing.Point(225, 5);
            this.gameInfoConsoleCheckBox.Name = "gameInfoConsoleCheckBox";
            this.gameInfoConsoleCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoConsoleCheckBox.TabIndex = 55;
            this.gameInfoConsoleCheckBox.UseVisualStyleBackColor = true;
            this.gameInfoConsoleCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // gameInfoConsoleTextBox
            // 
            this.gameInfoConsoleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoConsoleTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoConsoleTextBox.ForeColor = System.Drawing.Color.White;
            this.gameInfoConsoleTextBox.Location = new System.Drawing.Point(116, 0);
            this.gameInfoConsoleTextBox.Name = "gameInfoConsoleTextBox";
            this.gameInfoConsoleTextBox.Size = new System.Drawing.Size(99, 23);
            this.gameInfoConsoleTextBox.TabIndex = 5;
            this.gameInfoConsoleTextBox.Text = "Console";
            this.gameInfoConsoleTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // panel33
            // 
            this.panel33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel33.Controls.Add(this.label69);
            this.panel33.Controls.Add(this.gameInfoPublisherTextBox);
            this.panel33.Controls.Add(this.gameInfoPublisherCheckBox);
            this.panel33.Location = new System.Drawing.Point(2, 106);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(278, 23);
            this.panel33.TabIndex = 10061;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.Transparent;
            this.label69.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label69.Location = new System.Drawing.Point(3, 4);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(94, 16);
            this.label69.TabIndex = 10068;
            this.label69.Text = "Publisher";
            // 
            // gameInfoPublisherTextBox
            // 
            this.gameInfoPublisherTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoPublisherTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoPublisherTextBox.ForeColor = System.Drawing.Color.White;
            this.gameInfoPublisherTextBox.Location = new System.Drawing.Point(116, 0);
            this.gameInfoPublisherTextBox.Name = "gameInfoPublisherTextBox";
            this.gameInfoPublisherTextBox.Size = new System.Drawing.Size(99, 23);
            this.gameInfoPublisherTextBox.TabIndex = 7;
            this.gameInfoPublisherTextBox.Text = "Publisher";
            this.gameInfoPublisherTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // gameInfoPublisherCheckBox
            // 
            this.gameInfoPublisherCheckBox.AutoSize = true;
            this.gameInfoPublisherCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoPublisherCheckBox.Location = new System.Drawing.Point(225, 5);
            this.gameInfoPublisherCheckBox.Name = "gameInfoPublisherCheckBox";
            this.gameInfoPublisherCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoPublisherCheckBox.TabIndex = 56;
            this.gameInfoPublisherCheckBox.UseVisualStyleBackColor = true;
            this.gameInfoPublisherCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel34.Controls.Add(this.label70);
            this.panel34.Controls.Add(this.gameInfoDeveloperTextBox);
            this.panel34.Controls.Add(this.gameInfoDeveloperCheckBox);
            this.panel34.Location = new System.Drawing.Point(2, 84);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(278, 23);
            this.panel34.TabIndex = 10061;
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.Transparent;
            this.label70.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label70.Location = new System.Drawing.Point(3, 4);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(94, 16);
            this.label70.TabIndex = 10067;
            this.label70.Text = "Developer";
            // 
            // gameInfoDeveloperTextBox
            // 
            this.gameInfoDeveloperTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoDeveloperTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDeveloperTextBox.ForeColor = System.Drawing.Color.White;
            this.gameInfoDeveloperTextBox.Location = new System.Drawing.Point(116, 0);
            this.gameInfoDeveloperTextBox.Name = "gameInfoDeveloperTextBox";
            this.gameInfoDeveloperTextBox.Size = new System.Drawing.Size(99, 23);
            this.gameInfoDeveloperTextBox.TabIndex = 6;
            this.gameInfoDeveloperTextBox.Text = "Developer";
            this.gameInfoDeveloperTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // gameInfoDeveloperCheckBox
            // 
            this.gameInfoDeveloperCheckBox.AutoSize = true;
            this.gameInfoDeveloperCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDeveloperCheckBox.Location = new System.Drawing.Point(225, 5);
            this.gameInfoDeveloperCheckBox.Name = "gameInfoDeveloperCheckBox";
            this.gameInfoDeveloperCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoDeveloperCheckBox.TabIndex = 54;
            this.gameInfoDeveloperCheckBox.UseVisualStyleBackColor = true;
            this.gameInfoDeveloperCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // panel35
            // 
            this.panel35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel35.Controls.Add(this.label71);
            this.panel35.Controls.Add(this.panel42);
            this.panel35.Controls.Add(this.gameInfoOpenWindowButton);
            this.panel35.Controls.Add(this.gameInfoValuesPanel);
            this.panel35.Controls.Add(this.gameInfoAutoOpenWindowCheckbox);
            this.panel35.Controls.Add(this.pictureBox9);
            this.panel35.Controls.Add(this.panel44);
            this.panel35.Controls.Add(this.panel45);
            this.panel35.Controls.Add(this.panel46);
            this.panel35.Controls.Add(this.gameInfoValuesOutlinePanel);
            this.panel35.Location = new System.Drawing.Point(296, 3);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(468, 176);
            this.panel35.TabIndex = 10079;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.Transparent;
            this.label71.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label71.Location = new System.Drawing.Point(3, 3);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(243, 26);
            this.label71.TabIndex = 10062;
            this.label71.Text = "Window/Font Settings";
            // 
            // panel42
            // 
            this.panel42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel42.Controls.Add(this.gameInfoAdvancedCheckBox);
            this.panel42.Controls.Add(this.label78);
            this.panel42.Controls.Add(this.label79);
            this.panel42.Controls.Add(this.label80);
            this.panel42.Controls.Add(this.label81);
            this.panel42.Location = new System.Drawing.Point(2, 40);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(463, 23);
            this.panel42.TabIndex = 10076;
            // 
            // gameInfoAdvancedCheckBox
            // 
            this.gameInfoAdvancedCheckBox.AutoSize = true;
            this.gameInfoAdvancedCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoAdvancedCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.gameInfoAdvancedCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoAdvancedCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoAdvancedCheckBox.Location = new System.Drawing.Point(5, 2);
            this.gameInfoAdvancedCheckBox.Name = "gameInfoAdvancedCheckBox";
            this.gameInfoAdvancedCheckBox.Size = new System.Drawing.Size(91, 20);
            this.gameInfoAdvancedCheckBox.TabIndex = 10053;
            this.gameInfoAdvancedCheckBox.Text = "Advanced";
            this.gameInfoAdvancedCheckBox.UseVisualStyleBackColor = false;
            this.gameInfoAdvancedCheckBox.CheckedChanged += new System.EventHandler(this.AdvancedCheckBox_Click);
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.Transparent;
            this.label78.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label78.Location = new System.Drawing.Point(150, 3);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(48, 16);
            this.label78.TabIndex = 10065;
            this.label78.Text = "Color";
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.Transparent;
            this.label79.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label79.Location = new System.Drawing.Point(194, 3);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(50, 16);
            this.label79.TabIndex = 10066;
            this.label79.Text = "Font";
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.Transparent;
            this.label80.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label80.Location = new System.Drawing.Point(349, 3);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(41, 16);
            this.label80.TabIndex = 10068;
            this.label80.Text = "Size";
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.Transparent;
            this.label81.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label81.Location = new System.Drawing.Point(396, 3);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(59, 16);
            this.label81.TabIndex = 10067;
            this.label81.Text = "Enabled";
            // 
            // gameInfoOpenWindowButton
            // 
            this.gameInfoOpenWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoOpenWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.gameInfoOpenWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameInfoOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoOpenWindowButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameInfoOpenWindowButton.Location = new System.Drawing.Point(382, 2);
            this.gameInfoOpenWindowButton.Margin = new System.Windows.Forms.Padding(0);
            this.gameInfoOpenWindowButton.Name = "gameInfoOpenWindowButton";
            this.gameInfoOpenWindowButton.Size = new System.Drawing.Size(75, 27);
            this.gameInfoOpenWindowButton.TabIndex = 10021;
            this.gameInfoOpenWindowButton.Text = "Open";
            this.gameInfoOpenWindowButton.UseVisualStyleBackColor = false;
            this.gameInfoOpenWindowButton.Click += new System.EventHandler(this.ShowWindowButton_Click);
            // 
            // gameInfoValuesPanel
            // 
            this.gameInfoValuesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoValuesPanel.Controls.Add(this.label82);
            this.gameInfoValuesPanel.Controls.Add(this.gameInfoValuesFontColorPictureBox);
            this.gameInfoValuesPanel.Controls.Add(this.gameInfoValuesFontComboBox);
            this.gameInfoValuesPanel.Location = new System.Drawing.Point(2, 106);
            this.gameInfoValuesPanel.Name = "gameInfoValuesPanel";
            this.gameInfoValuesPanel.Size = new System.Drawing.Size(463, 23);
            this.gameInfoValuesPanel.TabIndex = 10061;
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.Color.Transparent;
            this.label82.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label82.Location = new System.Drawing.Point(3, 4);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(144, 16);
            this.label82.TabIndex = 10066;
            this.label82.Text = "Values";
            // 
            // gameInfoValuesFontColorPictureBox
            // 
            this.gameInfoValuesFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.gameInfoValuesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoValuesFontColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.gameInfoValuesFontColorPictureBox.Name = "gameInfoValuesFontColorPictureBox";
            this.gameInfoValuesFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.gameInfoValuesFontColorPictureBox.TabIndex = 45;
            this.gameInfoValuesFontColorPictureBox.TabStop = false;
            this.gameInfoValuesFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // gameInfoValuesFontComboBox
            // 
            this.gameInfoValuesFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoValuesFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoValuesFontComboBox.ForeColor = System.Drawing.Color.White;
            this.gameInfoValuesFontComboBox.FormattingEnabled = true;
            this.gameInfoValuesFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.gameInfoValuesFontComboBox.Name = "gameInfoValuesFontComboBox";
            this.gameInfoValuesFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.gameInfoValuesFontComboBox.TabIndex = 45;
            this.gameInfoValuesFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // gameInfoAutoOpenWindowCheckbox
            // 
            this.gameInfoAutoOpenWindowCheckbox.AutoSize = true;
            this.gameInfoAutoOpenWindowCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.gameInfoAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoAutoOpenWindowCheckbox.Location = new System.Drawing.Point(252, 9);
            this.gameInfoAutoOpenWindowCheckbox.Name = "gameInfoAutoOpenWindowCheckbox";
            this.gameInfoAutoOpenWindowCheckbox.Size = new System.Drawing.Size(98, 20);
            this.gameInfoAutoOpenWindowCheckbox.TabIndex = 10022;
            this.gameInfoAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.gameInfoAutoOpenWindowCheckbox.UseVisualStyleBackColor = true;
            this.gameInfoAutoOpenWindowCheckbox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox9.Location = new System.Drawing.Point(2, 32);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(460, 2);
            this.pictureBox9.TabIndex = 10063;
            this.pictureBox9.TabStop = false;
            // 
            // panel44
            // 
            this.panel44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel44.Controls.Add(this.gameInfoBackgroundColorPictureBox);
            this.panel44.Controls.Add(this.label83);
            this.panel44.Location = new System.Drawing.Point(2, 62);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(463, 23);
            this.panel44.TabIndex = 10061;
            // 
            // gameInfoBackgroundColorPictureBox
            // 
            this.gameInfoBackgroundColorPictureBox.BackColor = System.Drawing.Color.White;
            this.gameInfoBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoBackgroundColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.gameInfoBackgroundColorPictureBox.Name = "gameInfoBackgroundColorPictureBox";
            this.gameInfoBackgroundColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.gameInfoBackgroundColorPictureBox.TabIndex = 42;
            this.gameInfoBackgroundColorPictureBox.TabStop = false;
            this.gameInfoBackgroundColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.Color.Transparent;
            this.label83.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label83.Location = new System.Drawing.Point(3, 3);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(144, 16);
            this.label83.TabIndex = 10064;
            this.label83.Text = "Window Background";
            // 
            // panel45
            // 
            this.panel45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel45.Controls.Add(this.gameInfoNamesLabel);
            this.panel45.Controls.Add(this.gameInfoNamesFontColorPictureBox);
            this.panel45.Controls.Add(this.gameInfoNamesFontComboBox);
            this.panel45.Location = new System.Drawing.Point(2, 84);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(463, 23);
            this.panel45.TabIndex = 10061;
            // 
            // gameInfoNamesLabel
            // 
            this.gameInfoNamesLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoNamesLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoNamesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoNamesLabel.Location = new System.Drawing.Point(3, 4);
            this.gameInfoNamesLabel.Name = "gameInfoNamesLabel";
            this.gameInfoNamesLabel.Size = new System.Drawing.Size(144, 16);
            this.gameInfoNamesLabel.TabIndex = 10065;
            this.gameInfoNamesLabel.Text = "Names";
            // 
            // gameInfoNamesFontColorPictureBox
            // 
            this.gameInfoNamesFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.gameInfoNamesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoNamesFontColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.gameInfoNamesFontColorPictureBox.Name = "gameInfoNamesFontColorPictureBox";
            this.gameInfoNamesFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.gameInfoNamesFontColorPictureBox.TabIndex = 45;
            this.gameInfoNamesFontColorPictureBox.TabStop = false;
            this.gameInfoNamesFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // gameInfoNamesFontComboBox
            // 
            this.gameInfoNamesFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoNamesFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoNamesFontComboBox.ForeColor = System.Drawing.Color.White;
            this.gameInfoNamesFontComboBox.FormattingEnabled = true;
            this.gameInfoNamesFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.gameInfoNamesFontComboBox.Name = "gameInfoNamesFontComboBox";
            this.gameInfoNamesFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.gameInfoNamesFontComboBox.TabIndex = 45;
            this.gameInfoNamesFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // panel46
            // 
            this.panel46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel46.Controls.Add(this.gameInfoNamesFontOutlineNumericUpDown);
            this.panel46.Controls.Add(this.gameInfoNamesOutlineCheckBox);
            this.panel46.Controls.Add(this.gameInfoNamesOutlineLabel);
            this.panel46.Controls.Add(this.gameInfoNamesFontOutlineColorPictureBox);
            this.panel46.Location = new System.Drawing.Point(2, 128);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(463, 23);
            this.panel46.TabIndex = 10061;
            // 
            // gameInfoNamesFontOutlineNumericUpDown
            // 
            this.gameInfoNamesFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.gameInfoNamesFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gameInfoNamesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoNamesFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.gameInfoNamesFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.gameInfoNamesFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.gameInfoNamesFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gameInfoNamesFontOutlineNumericUpDown.Name = "gameInfoNamesFontOutlineNumericUpDown";
            this.gameInfoNamesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.gameInfoNamesFontOutlineNumericUpDown.TabIndex = 45;
            this.gameInfoNamesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gameInfoNamesFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // gameInfoNamesOutlineCheckBox
            // 
            this.gameInfoNamesOutlineCheckBox.AutoSize = true;
            this.gameInfoNamesOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoNamesOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoNamesOutlineCheckBox.Location = new System.Drawing.Point(413, 5);
            this.gameInfoNamesOutlineCheckBox.Name = "gameInfoNamesOutlineCheckBox";
            this.gameInfoNamesOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoNamesOutlineCheckBox.TabIndex = 45;
            this.gameInfoNamesOutlineCheckBox.UseVisualStyleBackColor = true;
            this.gameInfoNamesOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // gameInfoNamesOutlineLabel
            // 
            this.gameInfoNamesOutlineLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoNamesOutlineLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoNamesOutlineLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoNamesOutlineLabel.Location = new System.Drawing.Point(3, 3);
            this.gameInfoNamesOutlineLabel.Name = "gameInfoNamesOutlineLabel";
            this.gameInfoNamesOutlineLabel.Size = new System.Drawing.Size(144, 16);
            this.gameInfoNamesOutlineLabel.TabIndex = 10066;
            this.gameInfoNamesOutlineLabel.Text = "Names Outline";
            // 
            // gameInfoNamesFontOutlineColorPictureBox
            // 
            this.gameInfoNamesFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.gameInfoNamesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoNamesFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.gameInfoNamesFontOutlineColorPictureBox.Name = "gameInfoNamesFontOutlineColorPictureBox";
            this.gameInfoNamesFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.gameInfoNamesFontOutlineColorPictureBox.TabIndex = 45;
            this.gameInfoNamesFontOutlineColorPictureBox.TabStop = false;
            this.gameInfoNamesFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // gameInfoValuesOutlinePanel
            // 
            this.gameInfoValuesOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoValuesOutlinePanel.Controls.Add(this.label86);
            this.gameInfoValuesOutlinePanel.Controls.Add(this.gameInfoValuesFontOutlineColorPictureBox);
            this.gameInfoValuesOutlinePanel.Controls.Add(this.gameInfoValuesFontOutlineNumericUpDown);
            this.gameInfoValuesOutlinePanel.Controls.Add(this.gameInfoValuesOutlineCheckBox);
            this.gameInfoValuesOutlinePanel.Location = new System.Drawing.Point(2, 150);
            this.gameInfoValuesOutlinePanel.Name = "gameInfoValuesOutlinePanel";
            this.gameInfoValuesOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.gameInfoValuesOutlinePanel.TabIndex = 10067;
            // 
            // label86
            // 
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label86.Location = new System.Drawing.Point(3, 4);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(144, 16);
            this.label86.TabIndex = 10066;
            this.label86.Text = "Values Outline";
            // 
            // gameInfoValuesFontOutlineColorPictureBox
            // 
            this.gameInfoValuesFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.gameInfoValuesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoValuesFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.gameInfoValuesFontOutlineColorPictureBox.Name = "gameInfoValuesFontOutlineColorPictureBox";
            this.gameInfoValuesFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.gameInfoValuesFontOutlineColorPictureBox.TabIndex = 45;
            this.gameInfoValuesFontOutlineColorPictureBox.TabStop = false;
            this.gameInfoValuesFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // gameInfoValuesFontOutlineNumericUpDown
            // 
            this.gameInfoValuesFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.gameInfoValuesFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gameInfoValuesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoValuesFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.gameInfoValuesFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.gameInfoValuesFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.gameInfoValuesFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gameInfoValuesFontOutlineNumericUpDown.Name = "gameInfoValuesFontOutlineNumericUpDown";
            this.gameInfoValuesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.gameInfoValuesFontOutlineNumericUpDown.TabIndex = 45;
            this.gameInfoValuesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gameInfoValuesFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // gameInfoValuesOutlineCheckBox
            // 
            this.gameInfoValuesOutlineCheckBox.AutoSize = true;
            this.gameInfoValuesOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoValuesOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoValuesOutlineCheckBox.Location = new System.Drawing.Point(413, 6);
            this.gameInfoValuesOutlineCheckBox.Name = "gameInfoValuesOutlineCheckBox";
            this.gameInfoValuesOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoValuesOutlineCheckBox.TabIndex = 45;
            this.gameInfoValuesOutlineCheckBox.UseVisualStyleBackColor = true;
            this.gameInfoValuesOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel28.Controls.Add(this.gameProgressPointsTextLabel);
            this.panel28.Controls.Add(this.gameProgressHardcoreWorthLabel);
            this.panel28.Controls.Add(this.gameProgressPoints2Label);
            this.panel28.Controls.Add(this.gameProgressTruePoints2Label);
            this.panel28.Controls.Add(this.gameProgressAchievements2Label);
            this.panel28.Controls.Add(this.gameProgressHaveEarnedLabel);
            this.panel28.Controls.Add(this.gameProgressPercentCompletePictureBox);
            this.panel28.Controls.Add(this.gameProgressMasteryPictureBox);
            this.panel28.Controls.Add(this.pictureBox21);
            this.panel28.Controls.Add(this.label60);
            this.panel28.Controls.Add(this.label59);
            this.panel28.Controls.Add(this.label58);
            this.panel28.Controls.Add(this.label56);
            this.panel28.Controls.Add(this.pictureBox5);
            this.panel28.Controls.Add(this.gameProgressAchievements1Label);
            this.panel28.Controls.Add(this.gameProgressPoints1Label);
            this.panel28.Controls.Add(this.gameProgressCompletedLabel);
            this.panel28.Controls.Add(this.gameProgressTruePoints1Label);
            this.panel28.Location = new System.Drawing.Point(296, 184);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(468, 181);
            this.panel28.TabIndex = 10082;
            // 
            // gameProgressPointsTextLabel
            // 
            this.gameProgressPointsTextLabel.AutoSize = true;
            this.gameProgressPointsTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressPointsTextLabel.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.gameProgressPointsTextLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressPointsTextLabel.Location = new System.Drawing.Point(119, 82);
            this.gameProgressPointsTextLabel.Name = "gameProgressPointsTextLabel";
            this.gameProgressPointsTextLabel.Size = new System.Drawing.Size(52, 16);
            this.gameProgressPointsTextLabel.TabIndex = 10074;
            this.gameProgressPointsTextLabel.Text = "points.";
            // 
            // gameProgressHardcoreWorthLabel
            // 
            this.gameProgressHardcoreWorthLabel.AutoSize = true;
            this.gameProgressHardcoreWorthLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressHardcoreWorthLabel.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.gameProgressHardcoreWorthLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressHardcoreWorthLabel.Location = new System.Drawing.Point(154, 62);
            this.gameProgressHardcoreWorthLabel.Name = "gameProgressHardcoreWorthLabel";
            this.gameProgressHardcoreWorthLabel.Size = new System.Drawing.Size(221, 16);
            this.gameProgressHardcoreWorthLabel.TabIndex = 10073;
            this.gameProgressHardcoreWorthLabel.Text = "HARDCORE achievements, worth";
            // 
            // gameProgressPoints2Label
            // 
            this.gameProgressPoints2Label.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressPoints2Label.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressPoints2Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressPoints2Label.Location = new System.Drawing.Point(5, 82);
            this.gameProgressPoints2Label.Name = "gameProgressPoints2Label";
            this.gameProgressPoints2Label.Size = new System.Drawing.Size(55, 16);
            this.gameProgressPoints2Label.TabIndex = 10071;
            this.gameProgressPoints2Label.Text = "99999";
            this.gameProgressPoints2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameProgressTruePoints2Label
            // 
            this.gameProgressTruePoints2Label.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressTruePoints2Label.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressTruePoints2Label.ForeColor = System.Drawing.Color.White;
            this.gameProgressTruePoints2Label.Location = new System.Drawing.Point(54, 82);
            this.gameProgressTruePoints2Label.Name = "gameProgressTruePoints2Label";
            this.gameProgressTruePoints2Label.Size = new System.Drawing.Size(72, 16);
            this.gameProgressTruePoints2Label.TabIndex = 10072;
            this.gameProgressTruePoints2Label.Text = "(999999)";
            this.gameProgressTruePoints2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameProgressAchievements2Label
            // 
            this.gameProgressAchievements2Label.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressAchievements2Label.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressAchievements2Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressAchievements2Label.Location = new System.Drawing.Point(120, 62);
            this.gameProgressAchievements2Label.Name = "gameProgressAchievements2Label";
            this.gameProgressAchievements2Label.Size = new System.Drawing.Size(35, 16);
            this.gameProgressAchievements2Label.TabIndex = 10070;
            this.gameProgressAchievements2Label.Text = "999";
            this.gameProgressAchievements2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameProgressHaveEarnedLabel
            // 
            this.gameProgressHaveEarnedLabel.AutoSize = true;
            this.gameProgressHaveEarnedLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressHaveEarnedLabel.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.gameProgressHaveEarnedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressHaveEarnedLabel.Location = new System.Drawing.Point(5, 62);
            this.gameProgressHaveEarnedLabel.Name = "gameProgressHaveEarnedLabel";
            this.gameProgressHaveEarnedLabel.Size = new System.Drawing.Size(118, 16);
            this.gameProgressHaveEarnedLabel.TabIndex = 10069;
            this.gameProgressHaveEarnedLabel.Text = "You have earned";
            // 
            // gameProgressPercentCompletePictureBox
            // 
            this.gameProgressPercentCompletePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameProgressPercentCompletePictureBox.Location = new System.Drawing.Point(254, 143);
            this.gameProgressPercentCompletePictureBox.Name = "gameProgressPercentCompletePictureBox";
            this.gameProgressPercentCompletePictureBox.Size = new System.Drawing.Size(182, 3);
            this.gameProgressPercentCompletePictureBox.TabIndex = 10066;
            this.gameProgressPercentCompletePictureBox.TabStop = false;
            // 
            // gameProgressMasteryPictureBox
            // 
            this.gameProgressMasteryPictureBox.Image = global::Retro_Achievement_Tracker.Properties.Resources.mastered_icon;
            this.gameProgressMasteryPictureBox.Location = new System.Drawing.Point(437, 135);
            this.gameProgressMasteryPictureBox.Name = "gameProgressMasteryPictureBox";
            this.gameProgressMasteryPictureBox.Size = new System.Drawing.Size(20, 20);
            this.gameProgressMasteryPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameProgressMasteryPictureBox.TabIndex = 10068;
            this.gameProgressMasteryPictureBox.TabStop = false;
            // 
            // pictureBox21
            // 
            this.pictureBox21.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox21.Image = global::Retro_Achievement_Tracker.Properties.Resources.progression_meter;
            this.pictureBox21.Location = new System.Drawing.Point(250, 130);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(211, 30);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox21.TabIndex = 10067;
            this.pictureBox21.TabStop = false;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.Transparent;
            this.label60.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label60.Location = new System.Drawing.Point(367, 41);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(54, 16);
            this.label60.TabIndex = 10065;
            this.label60.Text = "points.";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.Transparent;
            this.label59.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label59.Location = new System.Drawing.Point(107, 41);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(141, 16);
            this.label59.TabIndex = 10064;
            this.label59.Text = "achievements worth";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label58.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label58.Location = new System.Drawing.Point(3, 41);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(71, 16);
            this.label58.TabIndex = 10063;
            this.label58.Text = "There are";
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.Transparent;
            this.label56.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label56.Location = new System.Drawing.Point(3, 3);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(192, 26);
            this.label56.TabIndex = 10058;
            this.label56.Text = "Achievements";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox5.Location = new System.Drawing.Point(2, 32);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(460, 2);
            this.pictureBox5.TabIndex = 10059;
            this.pictureBox5.TabStop = false;
            // 
            // gameProgressAchievements1Label
            // 
            this.gameProgressAchievements1Label.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressAchievements1Label.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressAchievements1Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressAchievements1Label.Location = new System.Drawing.Point(74, 41);
            this.gameProgressAchievements1Label.Name = "gameProgressAchievements1Label";
            this.gameProgressAchievements1Label.Size = new System.Drawing.Size(35, 16);
            this.gameProgressAchievements1Label.TabIndex = 10058;
            this.gameProgressAchievements1Label.Text = "999";
            this.gameProgressAchievements1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameProgressPoints1Label
            // 
            this.gameProgressPoints1Label.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressPoints1Label.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressPoints1Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressPoints1Label.Location = new System.Drawing.Point(249, 41);
            this.gameProgressPoints1Label.Name = "gameProgressPoints1Label";
            this.gameProgressPoints1Label.Size = new System.Drawing.Size(55, 16);
            this.gameProgressPoints1Label.TabIndex = 10059;
            this.gameProgressPoints1Label.Text = "99999";
            this.gameProgressPoints1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameProgressCompletedLabel
            // 
            this.gameProgressCompletedLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressCompletedLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressCompletedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressCompletedLabel.Location = new System.Drawing.Point(299, 159);
            this.gameProgressCompletedLabel.Name = "gameProgressCompletedLabel";
            this.gameProgressCompletedLabel.Size = new System.Drawing.Size(112, 16);
            this.gameProgressCompletedLabel.TabIndex = 10061;
            this.gameProgressCompletedLabel.Text = "0% Complete";
            // 
            // gameProgressTruePoints1Label
            // 
            this.gameProgressTruePoints1Label.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressTruePoints1Label.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressTruePoints1Label.ForeColor = System.Drawing.Color.White;
            this.gameProgressTruePoints1Label.Location = new System.Drawing.Point(299, 41);
            this.gameProgressTruePoints1Label.Name = "gameProgressTruePoints1Label";
            this.gameProgressTruePoints1Label.Size = new System.Drawing.Size(76, 16);
            this.gameProgressTruePoints1Label.TabIndex = 10060;
            this.gameProgressTruePoints1Label.Text = "(999999)";
            this.gameProgressTruePoints1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel15.Controls.Add(this.label38);
            this.panel15.Controls.Add(this.panel16);
            this.panel15.Controls.Add(this.gameProgressOpenWindowButton);
            this.panel15.Controls.Add(this.gameProgressValuesPanel);
            this.panel15.Controls.Add(this.gameProgressAutoOpenWindowCheckbox);
            this.panel15.Controls.Add(this.pictureBox6);
            this.panel15.Controls.Add(this.panel18);
            this.panel15.Controls.Add(this.panel19);
            this.panel15.Controls.Add(this.panel23);
            this.panel15.Controls.Add(this.gameProgressValuesOutlinePanel);
            this.panel15.Location = new System.Drawing.Point(296, 3);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(468, 176);
            this.panel15.TabIndex = 10081;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label38.Location = new System.Drawing.Point(3, 3);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(243, 26);
            this.label38.TabIndex = 10062;
            this.label38.Text = "Window/Font Settings";
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel16.Controls.Add(this.gameProgressAdvancedCheckBox);
            this.panel16.Controls.Add(this.label41);
            this.panel16.Controls.Add(this.label43);
            this.panel16.Controls.Add(this.label44);
            this.panel16.Controls.Add(this.label45);
            this.panel16.Location = new System.Drawing.Point(2, 40);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(463, 23);
            this.panel16.TabIndex = 10076;
            // 
            // gameProgressAdvancedCheckBox
            // 
            this.gameProgressAdvancedCheckBox.AutoSize = true;
            this.gameProgressAdvancedCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressAdvancedCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.gameProgressAdvancedCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressAdvancedCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressAdvancedCheckBox.Location = new System.Drawing.Point(5, 2);
            this.gameProgressAdvancedCheckBox.Name = "gameProgressAdvancedCheckBox";
            this.gameProgressAdvancedCheckBox.Size = new System.Drawing.Size(91, 20);
            this.gameProgressAdvancedCheckBox.TabIndex = 10053;
            this.gameProgressAdvancedCheckBox.Text = "Advanced";
            this.gameProgressAdvancedCheckBox.UseVisualStyleBackColor = false;
            this.gameProgressAdvancedCheckBox.CheckedChanged += new System.EventHandler(this.AdvancedCheckBox_Click);
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label41.Location = new System.Drawing.Point(150, 3);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(48, 16);
            this.label41.TabIndex = 10065;
            this.label41.Text = "Color";
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label43.Location = new System.Drawing.Point(194, 3);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(50, 16);
            this.label43.TabIndex = 10066;
            this.label43.Text = "Font";
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label44.Location = new System.Drawing.Point(349, 3);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(41, 16);
            this.label44.TabIndex = 10068;
            this.label44.Text = "Size";
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label45.Location = new System.Drawing.Point(396, 3);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(59, 16);
            this.label45.TabIndex = 10067;
            this.label45.Text = "Enabled";
            // 
            // gameProgressOpenWindowButton
            // 
            this.gameProgressOpenWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressOpenWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.gameProgressOpenWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameProgressOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressOpenWindowButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameProgressOpenWindowButton.Location = new System.Drawing.Point(382, 2);
            this.gameProgressOpenWindowButton.Margin = new System.Windows.Forms.Padding(0);
            this.gameProgressOpenWindowButton.Name = "gameProgressOpenWindowButton";
            this.gameProgressOpenWindowButton.Size = new System.Drawing.Size(75, 27);
            this.gameProgressOpenWindowButton.TabIndex = 10021;
            this.gameProgressOpenWindowButton.Text = "Open";
            this.gameProgressOpenWindowButton.UseVisualStyleBackColor = false;
            this.gameProgressOpenWindowButton.Click += new System.EventHandler(this.ShowWindowButton_Click);
            // 
            // gameProgressValuesPanel
            // 
            this.gameProgressValuesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressValuesPanel.Controls.Add(this.label46);
            this.gameProgressValuesPanel.Controls.Add(this.gameProgressValuesFontColorPictureBox);
            this.gameProgressValuesPanel.Controls.Add(this.gameProgressValuesFontComboBox);
            this.gameProgressValuesPanel.Location = new System.Drawing.Point(2, 106);
            this.gameProgressValuesPanel.Name = "gameProgressValuesPanel";
            this.gameProgressValuesPanel.Size = new System.Drawing.Size(463, 23);
            this.gameProgressValuesPanel.TabIndex = 10061;
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label46.Location = new System.Drawing.Point(3, 4);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(144, 16);
            this.label46.TabIndex = 10066;
            this.label46.Text = "Values";
            // 
            // gameProgressValuesFontColorPictureBox
            // 
            this.gameProgressValuesFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.gameProgressValuesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressValuesFontColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.gameProgressValuesFontColorPictureBox.Name = "gameProgressValuesFontColorPictureBox";
            this.gameProgressValuesFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.gameProgressValuesFontColorPictureBox.TabIndex = 45;
            this.gameProgressValuesFontColorPictureBox.TabStop = false;
            this.gameProgressValuesFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // gameProgressValuesFontComboBox
            // 
            this.gameProgressValuesFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressValuesFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressValuesFontComboBox.ForeColor = System.Drawing.Color.White;
            this.gameProgressValuesFontComboBox.FormattingEnabled = true;
            this.gameProgressValuesFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.gameProgressValuesFontComboBox.Name = "gameProgressValuesFontComboBox";
            this.gameProgressValuesFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.gameProgressValuesFontComboBox.TabIndex = 45;
            this.gameProgressValuesFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // gameProgressAutoOpenWindowCheckbox
            // 
            this.gameProgressAutoOpenWindowCheckbox.AutoSize = true;
            this.gameProgressAutoOpenWindowCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.gameProgressAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressAutoOpenWindowCheckbox.Location = new System.Drawing.Point(252, 9);
            this.gameProgressAutoOpenWindowCheckbox.Name = "gameProgressAutoOpenWindowCheckbox";
            this.gameProgressAutoOpenWindowCheckbox.Size = new System.Drawing.Size(98, 20);
            this.gameProgressAutoOpenWindowCheckbox.TabIndex = 10022;
            this.gameProgressAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.gameProgressAutoOpenWindowCheckbox.UseVisualStyleBackColor = true;
            this.gameProgressAutoOpenWindowCheckbox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox6.Location = new System.Drawing.Point(2, 32);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(460, 2);
            this.pictureBox6.TabIndex = 10063;
            this.pictureBox6.TabStop = false;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel18.Controls.Add(this.gameProgressBackgroundColorPictureBox);
            this.panel18.Controls.Add(this.label47);
            this.panel18.Location = new System.Drawing.Point(2, 62);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(463, 23);
            this.panel18.TabIndex = 10061;
            // 
            // gameProgressBackgroundColorPictureBox
            // 
            this.gameProgressBackgroundColorPictureBox.BackColor = System.Drawing.Color.White;
            this.gameProgressBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressBackgroundColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.gameProgressBackgroundColorPictureBox.Name = "gameProgressBackgroundColorPictureBox";
            this.gameProgressBackgroundColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.gameProgressBackgroundColorPictureBox.TabIndex = 42;
            this.gameProgressBackgroundColorPictureBox.TabStop = false;
            this.gameProgressBackgroundColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.Transparent;
            this.label47.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label47.Location = new System.Drawing.Point(3, 3);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(144, 16);
            this.label47.TabIndex = 10064;
            this.label47.Text = "Window Background";
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel19.Controls.Add(this.gameProgressNamesLabel);
            this.panel19.Controls.Add(this.gameProgressNamesFontColorPictureBox);
            this.panel19.Controls.Add(this.gameProgressNamesFontComboBox);
            this.panel19.Location = new System.Drawing.Point(2, 84);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(463, 23);
            this.panel19.TabIndex = 10061;
            // 
            // gameProgressNamesLabel
            // 
            this.gameProgressNamesLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressNamesLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressNamesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressNamesLabel.Location = new System.Drawing.Point(3, 4);
            this.gameProgressNamesLabel.Name = "gameProgressNamesLabel";
            this.gameProgressNamesLabel.Size = new System.Drawing.Size(144, 16);
            this.gameProgressNamesLabel.TabIndex = 10065;
            this.gameProgressNamesLabel.Text = "Names";
            // 
            // gameProgressNamesFontColorPictureBox
            // 
            this.gameProgressNamesFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.gameProgressNamesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressNamesFontColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.gameProgressNamesFontColorPictureBox.Name = "gameProgressNamesFontColorPictureBox";
            this.gameProgressNamesFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.gameProgressNamesFontColorPictureBox.TabIndex = 45;
            this.gameProgressNamesFontColorPictureBox.TabStop = false;
            this.gameProgressNamesFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // gameProgressNamesFontComboBox
            // 
            this.gameProgressNamesFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressNamesFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressNamesFontComboBox.ForeColor = System.Drawing.Color.White;
            this.gameProgressNamesFontComboBox.FormattingEnabled = true;
            this.gameProgressNamesFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.gameProgressNamesFontComboBox.Name = "gameProgressNamesFontComboBox";
            this.gameProgressNamesFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.gameProgressNamesFontComboBox.TabIndex = 45;
            this.gameProgressNamesFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel23.Controls.Add(this.gameProgressNamesFontOutlineNumericUpDown);
            this.panel23.Controls.Add(this.gameProgressNamesOutlineCheckBox);
            this.panel23.Controls.Add(this.gameProgressNamesOutlineLabel);
            this.panel23.Controls.Add(this.gameProgressNamesFontOutlineColorPictureBox);
            this.panel23.Location = new System.Drawing.Point(2, 128);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(463, 23);
            this.panel23.TabIndex = 10061;
            // 
            // gameProgressNamesFontOutlineNumericUpDown
            // 
            this.gameProgressNamesFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.gameProgressNamesFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gameProgressNamesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressNamesFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.gameProgressNamesFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.gameProgressNamesFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.gameProgressNamesFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gameProgressNamesFontOutlineNumericUpDown.Name = "gameProgressNamesFontOutlineNumericUpDown";
            this.gameProgressNamesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.gameProgressNamesFontOutlineNumericUpDown.TabIndex = 45;
            this.gameProgressNamesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gameProgressNamesFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // gameProgressNamesOutlineCheckBox
            // 
            this.gameProgressNamesOutlineCheckBox.AutoSize = true;
            this.gameProgressNamesOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressNamesOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressNamesOutlineCheckBox.Location = new System.Drawing.Point(413, 5);
            this.gameProgressNamesOutlineCheckBox.Name = "gameProgressNamesOutlineCheckBox";
            this.gameProgressNamesOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressNamesOutlineCheckBox.TabIndex = 45;
            this.gameProgressNamesOutlineCheckBox.UseVisualStyleBackColor = true;
            this.gameProgressNamesOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // gameProgressNamesOutlineLabel
            // 
            this.gameProgressNamesOutlineLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressNamesOutlineLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressNamesOutlineLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressNamesOutlineLabel.Location = new System.Drawing.Point(3, 3);
            this.gameProgressNamesOutlineLabel.Name = "gameProgressNamesOutlineLabel";
            this.gameProgressNamesOutlineLabel.Size = new System.Drawing.Size(144, 16);
            this.gameProgressNamesOutlineLabel.TabIndex = 10066;
            this.gameProgressNamesOutlineLabel.Text = "Names Outline";
            // 
            // gameProgressNamesFontOutlineColorPictureBox
            // 
            this.gameProgressNamesFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.gameProgressNamesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressNamesFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.gameProgressNamesFontOutlineColorPictureBox.Name = "gameProgressNamesFontOutlineColorPictureBox";
            this.gameProgressNamesFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.gameProgressNamesFontOutlineColorPictureBox.TabIndex = 45;
            this.gameProgressNamesFontOutlineColorPictureBox.TabStop = false;
            this.gameProgressNamesFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // gameProgressValuesOutlinePanel
            // 
            this.gameProgressValuesOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressValuesOutlinePanel.Controls.Add(this.label50);
            this.gameProgressValuesOutlinePanel.Controls.Add(this.gameProgressValuesFontOutlineColorPictureBox);
            this.gameProgressValuesOutlinePanel.Controls.Add(this.gameProgressValuesFontOutlineNumericUpDown);
            this.gameProgressValuesOutlinePanel.Controls.Add(this.gameProgressValuesOutlineCheckBox);
            this.gameProgressValuesOutlinePanel.Location = new System.Drawing.Point(2, 150);
            this.gameProgressValuesOutlinePanel.Name = "gameProgressValuesOutlinePanel";
            this.gameProgressValuesOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.gameProgressValuesOutlinePanel.TabIndex = 10067;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label50.Location = new System.Drawing.Point(3, 4);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(144, 16);
            this.label50.TabIndex = 10066;
            this.label50.Text = "Values Outline";
            // 
            // gameProgressValuesFontOutlineColorPictureBox
            // 
            this.gameProgressValuesFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.gameProgressValuesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressValuesFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.gameProgressValuesFontOutlineColorPictureBox.Name = "gameProgressValuesFontOutlineColorPictureBox";
            this.gameProgressValuesFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.gameProgressValuesFontOutlineColorPictureBox.TabIndex = 45;
            this.gameProgressValuesFontOutlineColorPictureBox.TabStop = false;
            this.gameProgressValuesFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // gameProgressValuesFontOutlineNumericUpDown
            // 
            this.gameProgressValuesFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.gameProgressValuesFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gameProgressValuesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressValuesFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.gameProgressValuesFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.gameProgressValuesFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.gameProgressValuesFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gameProgressValuesFontOutlineNumericUpDown.Name = "gameProgressValuesFontOutlineNumericUpDown";
            this.gameProgressValuesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.gameProgressValuesFontOutlineNumericUpDown.TabIndex = 45;
            this.gameProgressValuesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gameProgressValuesFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // gameProgressValuesOutlineCheckBox
            // 
            this.gameProgressValuesOutlineCheckBox.AutoSize = true;
            this.gameProgressValuesOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressValuesOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressValuesOutlineCheckBox.Location = new System.Drawing.Point(413, 6);
            this.gameProgressValuesOutlineCheckBox.Name = "gameProgressValuesOutlineCheckBox";
            this.gameProgressValuesOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressValuesOutlineCheckBox.TabIndex = 45;
            this.gameProgressValuesOutlineCheckBox.UseVisualStyleBackColor = true;
            this.gameProgressValuesOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // panel36
            // 
            this.panel36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.panel36.Controls.Add(this.panel27);
            this.panel36.Controls.Add(this.panel25);
            this.panel36.Controls.Add(this.panel37);
            this.panel36.Controls.Add(this.panel26);
            this.panel36.Controls.Add(this.label73);
            this.panel36.Controls.Add(this.gameProgressDefaultButton);
            this.panel36.Controls.Add(this.pictureBox17);
            this.panel36.Controls.Add(this.panel38);
            this.panel36.Controls.Add(this.panel39);
            this.panel36.Controls.Add(this.panel40);
            this.panel36.Controls.Add(this.panel41);
            this.panel36.Location = new System.Drawing.Point(4, 3);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(287, 222);
            this.panel36.TabIndex = 10080;
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel27.Controls.Add(this.label55);
            this.panel27.Controls.Add(this.gameProgressRadioButtonPeriod);
            this.panel27.Controls.Add(this.label54);
            this.panel27.Controls.Add(this.gameProgressRadioButtonColon);
            this.panel27.Controls.Add(this.label53);
            this.panel27.Controls.Add(this.gameProgressRadioButtonBackslash);
            this.panel27.Controls.Add(this.label51);
            this.panel27.Location = new System.Drawing.Point(2, 194);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(278, 23);
            this.panel27.TabIndex = 10073;
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label55.Location = new System.Drawing.Point(231, 4);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(15, 16);
            this.label55.TabIndex = 10074;
            this.label55.Text = ".";
            // 
            // gameProgressRadioButtonPeriod
            // 
            this.gameProgressRadioButtonPeriod.AutoSize = true;
            this.gameProgressRadioButtonPeriod.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressRadioButtonPeriod.Location = new System.Drawing.Point(213, 5);
            this.gameProgressRadioButtonPeriod.Name = "gameProgressRadioButtonPeriod";
            this.gameProgressRadioButtonPeriod.Size = new System.Drawing.Size(14, 13);
            this.gameProgressRadioButtonPeriod.TabIndex = 10073;
            this.gameProgressRadioButtonPeriod.UseVisualStyleBackColor = true;
            this.gameProgressRadioButtonPeriod.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label54.Location = new System.Drawing.Point(176, 4);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(15, 16);
            this.label54.TabIndex = 10072;
            this.label54.Text = ":";
            // 
            // gameProgressRadioButtonColon
            // 
            this.gameProgressRadioButtonColon.AutoSize = true;
            this.gameProgressRadioButtonColon.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressRadioButtonColon.Location = new System.Drawing.Point(158, 5);
            this.gameProgressRadioButtonColon.Name = "gameProgressRadioButtonColon";
            this.gameProgressRadioButtonColon.Size = new System.Drawing.Size(14, 13);
            this.gameProgressRadioButtonColon.TabIndex = 10071;
            this.gameProgressRadioButtonColon.UseVisualStyleBackColor = true;
            this.gameProgressRadioButtonColon.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label53.Location = new System.Drawing.Point(118, 4);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(15, 16);
            this.label53.TabIndex = 10070;
            this.label53.Text = "/";
            // 
            // gameProgressRadioButtonBackslash
            // 
            this.gameProgressRadioButtonBackslash.AutoSize = true;
            this.gameProgressRadioButtonBackslash.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressRadioButtonBackslash.Location = new System.Drawing.Point(100, 5);
            this.gameProgressRadioButtonBackslash.Name = "gameProgressRadioButtonBackslash";
            this.gameProgressRadioButtonBackslash.Size = new System.Drawing.Size(14, 13);
            this.gameProgressRadioButtonBackslash.TabIndex = 10067;
            this.gameProgressRadioButtonBackslash.UseVisualStyleBackColor = true;
            this.gameProgressRadioButtonBackslash.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.Transparent;
            this.label51.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label51.Location = new System.Drawing.Point(3, 4);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(94, 16);
            this.label51.TabIndex = 10069;
            this.label51.Text = "Separator";
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel25.Location = new System.Drawing.Point(2, 172);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(278, 23);
            this.panel25.TabIndex = 10072;
            // 
            // panel37
            // 
            this.panel37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel37.Controls.Add(this.label39);
            this.panel37.Controls.Add(this.label40);
            this.panel37.Controls.Add(this.label72);
            this.panel37.Location = new System.Drawing.Point(2, 40);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(278, 23);
            this.panel37.TabIndex = 10079;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label39.Location = new System.Drawing.Point(3, 3);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(50, 16);
            this.label39.TabIndex = 10071;
            this.label39.Text = "Field";
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label40.Location = new System.Drawing.Point(113, 3);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(102, 16);
            this.label40.TabIndex = 10073;
            this.label40.Text = "Display Text";
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.Color.Transparent;
            this.label72.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label72.Location = new System.Drawing.Point(221, 3);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(61, 16);
            this.label72.TabIndex = 10072;
            this.label72.Text = "Enabled";
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel26.Controls.Add(this.label52);
            this.panel26.Controls.Add(this.gameProgressCompletedTextBox);
            this.panel26.Controls.Add(this.gameProgressCompletedCheckBox);
            this.panel26.Location = new System.Drawing.Point(2, 150);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(278, 23);
            this.panel26.TabIndex = 10071;
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label52.Location = new System.Drawing.Point(3, 4);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(94, 16);
            this.label52.TabIndex = 10068;
            this.label52.Text = "Completed";
            // 
            // gameProgressCompletedTextBox
            // 
            this.gameProgressCompletedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressCompletedTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressCompletedTextBox.ForeColor = System.Drawing.Color.White;
            this.gameProgressCompletedTextBox.Location = new System.Drawing.Point(116, 0);
            this.gameProgressCompletedTextBox.Name = "gameProgressCompletedTextBox";
            this.gameProgressCompletedTextBox.Size = new System.Drawing.Size(99, 23);
            this.gameProgressCompletedTextBox.TabIndex = 7;
            this.gameProgressCompletedTextBox.Text = "Completed";
            this.gameProgressCompletedTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // gameProgressCompletedCheckBox
            // 
            this.gameProgressCompletedCheckBox.AutoSize = true;
            this.gameProgressCompletedCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressCompletedCheckBox.Location = new System.Drawing.Point(225, 5);
            this.gameProgressCompletedCheckBox.Name = "gameProgressCompletedCheckBox";
            this.gameProgressCompletedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressCompletedCheckBox.TabIndex = 56;
            this.gameProgressCompletedCheckBox.UseVisualStyleBackColor = true;
            this.gameProgressCompletedCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // label73
            // 
            this.label73.BackColor = System.Drawing.Color.Transparent;
            this.label73.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label73.Location = new System.Drawing.Point(3, 3);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(190, 26);
            this.label73.TabIndex = 10069;
            this.label73.Text = "Field Overrides";
            // 
            // gameProgressDefaultButton
            // 
            this.gameProgressDefaultButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressDefaultButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.gameProgressDefaultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameProgressDefaultButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressDefaultButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.gameProgressDefaultButton.Location = new System.Drawing.Point(204, 2);
            this.gameProgressDefaultButton.Margin = new System.Windows.Forms.Padding(0);
            this.gameProgressDefaultButton.Name = "gameProgressDefaultButton";
            this.gameProgressDefaultButton.Size = new System.Drawing.Size(75, 27);
            this.gameProgressDefaultButton.TabIndex = 39;
            this.gameProgressDefaultButton.Text = "Default";
            this.gameProgressDefaultButton.UseVisualStyleBackColor = false;
            this.gameProgressDefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // pictureBox17
            // 
            this.pictureBox17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox17.Location = new System.Drawing.Point(2, 32);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(275, 2);
            this.pictureBox17.TabIndex = 10070;
            this.pictureBox17.TabStop = false;
            // 
            // panel38
            // 
            this.panel38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel38.Controls.Add(this.label74);
            this.panel38.Controls.Add(this.gameProgressAchievementsCheckBox);
            this.panel38.Controls.Add(this.gameProgressAchievementsTextBox);
            this.panel38.Location = new System.Drawing.Point(2, 62);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(278, 23);
            this.panel38.TabIndex = 10061;
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.Transparent;
            this.label74.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label74.Location = new System.Drawing.Point(3, 3);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(112, 16);
            this.label74.TabIndex = 10066;
            this.label74.Text = "Achievements";
            // 
            // gameProgressAchievementsCheckBox
            // 
            this.gameProgressAchievementsCheckBox.AutoSize = true;
            this.gameProgressAchievementsCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressAchievementsCheckBox.Location = new System.Drawing.Point(225, 5);
            this.gameProgressAchievementsCheckBox.Name = "gameProgressAchievementsCheckBox";
            this.gameProgressAchievementsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressAchievementsCheckBox.TabIndex = 52;
            this.gameProgressAchievementsCheckBox.UseVisualStyleBackColor = true;
            this.gameProgressAchievementsCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // gameProgressAchievementsTextBox
            // 
            this.gameProgressAchievementsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressAchievementsTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressAchievementsTextBox.ForeColor = System.Drawing.Color.White;
            this.gameProgressAchievementsTextBox.Location = new System.Drawing.Point(116, 0);
            this.gameProgressAchievementsTextBox.Name = "gameProgressAchievementsTextBox";
            this.gameProgressAchievementsTextBox.Size = new System.Drawing.Size(99, 23);
            this.gameProgressAchievementsTextBox.TabIndex = 1;
            this.gameProgressAchievementsTextBox.Text = "Achievements";
            this.gameProgressAchievementsTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // panel39
            // 
            this.panel39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel39.Controls.Add(this.label75);
            this.panel39.Controls.Add(this.gameProgressRatioCheckBox);
            this.panel39.Controls.Add(this.gameProgressRatioTextBox);
            this.panel39.Location = new System.Drawing.Point(2, 128);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(278, 23);
            this.panel39.TabIndex = 10061;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.Transparent;
            this.label75.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label75.Location = new System.Drawing.Point(3, 4);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(94, 16);
            this.label75.TabIndex = 10069;
            this.label75.Text = "Retro Ratio";
            // 
            // gameProgressRatioCheckBox
            // 
            this.gameProgressRatioCheckBox.AutoSize = true;
            this.gameProgressRatioCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressRatioCheckBox.Location = new System.Drawing.Point(225, 5);
            this.gameProgressRatioCheckBox.Name = "gameProgressRatioCheckBox";
            this.gameProgressRatioCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressRatioCheckBox.TabIndex = 55;
            this.gameProgressRatioCheckBox.UseVisualStyleBackColor = true;
            this.gameProgressRatioCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // gameProgressRatioTextBox
            // 
            this.gameProgressRatioTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressRatioTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressRatioTextBox.ForeColor = System.Drawing.Color.White;
            this.gameProgressRatioTextBox.Location = new System.Drawing.Point(116, 0);
            this.gameProgressRatioTextBox.Name = "gameProgressRatioTextBox";
            this.gameProgressRatioTextBox.Size = new System.Drawing.Size(99, 23);
            this.gameProgressRatioTextBox.TabIndex = 5;
            this.gameProgressRatioTextBox.Text = "Retro Ratio";
            this.gameProgressRatioTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // panel40
            // 
            this.panel40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel40.Controls.Add(this.label76);
            this.panel40.Controls.Add(this.gameProgressTruePointsTextBox);
            this.panel40.Controls.Add(this.gameProgressTruePointsCheckBox);
            this.panel40.Location = new System.Drawing.Point(2, 106);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(278, 23);
            this.panel40.TabIndex = 10061;
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.Color.Transparent;
            this.label76.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label76.Location = new System.Drawing.Point(3, 4);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(94, 16);
            this.label76.TabIndex = 10068;
            this.label76.Text = "True Points";
            // 
            // gameProgressTruePointsTextBox
            // 
            this.gameProgressTruePointsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressTruePointsTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressTruePointsTextBox.ForeColor = System.Drawing.Color.White;
            this.gameProgressTruePointsTextBox.Location = new System.Drawing.Point(116, 0);
            this.gameProgressTruePointsTextBox.Name = "gameProgressTruePointsTextBox";
            this.gameProgressTruePointsTextBox.Size = new System.Drawing.Size(99, 23);
            this.gameProgressTruePointsTextBox.TabIndex = 7;
            this.gameProgressTruePointsTextBox.Text = "True Points";
            this.gameProgressTruePointsTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // gameProgressTruePointsCheckBox
            // 
            this.gameProgressTruePointsCheckBox.AutoSize = true;
            this.gameProgressTruePointsCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressTruePointsCheckBox.Location = new System.Drawing.Point(225, 5);
            this.gameProgressTruePointsCheckBox.Name = "gameProgressTruePointsCheckBox";
            this.gameProgressTruePointsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressTruePointsCheckBox.TabIndex = 56;
            this.gameProgressTruePointsCheckBox.UseVisualStyleBackColor = true;
            this.gameProgressTruePointsCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // panel41
            // 
            this.panel41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel41.Controls.Add(this.label77);
            this.panel41.Controls.Add(this.gameProgressPointsTextBox);
            this.panel41.Controls.Add(this.gameProgressPointsCheckBox);
            this.panel41.Location = new System.Drawing.Point(2, 84);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(278, 23);
            this.panel41.TabIndex = 10061;
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.Transparent;
            this.label77.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label77.Location = new System.Drawing.Point(3, 4);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(94, 16);
            this.label77.TabIndex = 10067;
            this.label77.Text = "Points";
            // 
            // gameProgressPointsTextBox
            // 
            this.gameProgressPointsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressPointsTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressPointsTextBox.ForeColor = System.Drawing.Color.White;
            this.gameProgressPointsTextBox.Location = new System.Drawing.Point(116, 0);
            this.gameProgressPointsTextBox.Name = "gameProgressPointsTextBox";
            this.gameProgressPointsTextBox.Size = new System.Drawing.Size(99, 23);
            this.gameProgressPointsTextBox.TabIndex = 6;
            this.gameProgressPointsTextBox.Text = "Points";
            this.gameProgressPointsTextBox.TextChanged += new System.EventHandler(this.OverrideTextBox_TextChanged);
            // 
            // gameProgressPointsCheckBox
            // 
            this.gameProgressPointsCheckBox.AutoSize = true;
            this.gameProgressPointsCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressPointsCheckBox.Location = new System.Drawing.Point(225, 5);
            this.gameProgressPointsCheckBox.Name = "gameProgressPointsCheckBox";
            this.gameProgressPointsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressPointsCheckBox.TabIndex = 54;
            this.gameProgressPointsCheckBox.UseVisualStyleBackColor = true;
            this.gameProgressPointsCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // panel113
            // 
            this.panel113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel113.Controls.Add(this.label155);
            this.panel113.Controls.Add(this.pictureBox15);
            this.panel113.Controls.Add(this.recentAchievementsMaxListNumericUpDown);
            this.panel113.Controls.Add(this.recentAchievementsMaxListLabel);
            this.panel113.Controls.Add(this.recentAchievementsAutoScrollCheckBox);
            this.panel113.Location = new System.Drawing.Point(4, 3);
            this.panel113.Name = "panel113";
            this.panel113.Size = new System.Drawing.Size(289, 64);
            this.panel113.TabIndex = 10083;
            // 
            // label155
            // 
            this.label155.BackColor = System.Drawing.Color.Transparent;
            this.label155.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label155.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label155.Location = new System.Drawing.Point(3, 3);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(190, 26);
            this.label155.TabIndex = 10069;
            this.label155.Text = "List Settings";
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox15.Location = new System.Drawing.Point(2, 32);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(275, 2);
            this.pictureBox15.TabIndex = 10070;
            this.pictureBox15.TabStop = false;
            // 
            // recentAchievementsAutoScrollCheckBox
            // 
            this.recentAchievementsAutoScrollCheckBox.AutoSize = true;
            this.recentAchievementsAutoScrollCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsAutoScrollCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.recentAchievementsAutoScrollCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsAutoScrollCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsAutoScrollCheckBox.Location = new System.Drawing.Point(3, 39);
            this.recentAchievementsAutoScrollCheckBox.Name = "recentAchievementsAutoScrollCheckBox";
            this.recentAchievementsAutoScrollCheckBox.Size = new System.Drawing.Size(98, 20);
            this.recentAchievementsAutoScrollCheckBox.TabIndex = 10055;
            this.recentAchievementsAutoScrollCheckBox.Text = "Auto-scroll";
            this.recentAchievementsAutoScrollCheckBox.UseVisualStyleBackColor = false;
            this.recentAchievementsAutoScrollCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // panel99
            // 
            this.panel99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel99.Controls.Add(this.recentAchievementsLinePanel);
            this.panel99.Controls.Add(this.label17);
            this.panel99.Controls.Add(this.panel101);
            this.panel99.Controls.Add(this.recentAchievementsPointsPanel);
            this.panel99.Controls.Add(this.panel103);
            this.panel99.Controls.Add(this.panel104);
            this.panel99.Controls.Add(this.recentAchievementsOpenWindowButton);
            this.panel99.Controls.Add(this.recentAchievementsDescriptionOutlinePanel);
            this.panel99.Controls.Add(this.recentAchievementsDescriptionPanel);
            this.panel99.Controls.Add(this.recentAchievementsAutoOpenWindowCheckbox);
            this.panel99.Controls.Add(this.pictureBox23);
            this.panel99.Controls.Add(this.panel107);
            this.panel99.Controls.Add(this.panel108);
            this.panel99.Controls.Add(this.recentAchievementsPointsOutlinePanel);
            this.panel99.Controls.Add(this.recentAchievementsLineOutlinePanel);
            this.panel99.Location = new System.Drawing.Point(296, 3);
            this.panel99.Name = "panel99";
            this.panel99.Size = new System.Drawing.Size(468, 285);
            this.panel99.TabIndex = 10082;
            // 
            // recentAchievementsLinePanel
            // 
            this.recentAchievementsLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.recentAchievementsLinePanel.Controls.Add(this.label16);
            this.recentAchievementsLinePanel.Controls.Add(this.recentAchievementsLineColorPictureBox);
            this.recentAchievementsLinePanel.Location = new System.Drawing.Point(2, 172);
            this.recentAchievementsLinePanel.Name = "recentAchievementsLinePanel";
            this.recentAchievementsLinePanel.Size = new System.Drawing.Size(463, 23);
            this.recentAchievementsLinePanel.TabIndex = 10068;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label16.Location = new System.Drawing.Point(3, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(144, 16);
            this.label16.TabIndex = 10066;
            this.label16.Text = "Line";
            // 
            // recentAchievementsLineColorPictureBox
            // 
            this.recentAchievementsLineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.recentAchievementsLineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsLineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.recentAchievementsLineColorPictureBox.Name = "recentAchievementsLineColorPictureBox";
            this.recentAchievementsLineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.recentAchievementsLineColorPictureBox.TabIndex = 45;
            this.recentAchievementsLineColorPictureBox.TabStop = false;
            this.recentAchievementsLineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label17.Location = new System.Drawing.Point(3, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(243, 26);
            this.label17.TabIndex = 10062;
            this.label17.Text = "Window/Font Settings";
            // 
            // panel101
            // 
            this.panel101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel101.Controls.Add(this.recentAchievementsBorderCheckBox);
            this.panel101.Controls.Add(this.recentAchievementsBorderColorPictureBox);
            this.panel101.Controls.Add(this.label18);
            this.panel101.Location = new System.Drawing.Point(2, 84);
            this.panel101.Name = "panel101";
            this.panel101.Size = new System.Drawing.Size(463, 23);
            this.panel101.TabIndex = 10069;
            // 
            // recentAchievementsBorderCheckBox
            // 
            this.recentAchievementsBorderCheckBox.AutoSize = true;
            this.recentAchievementsBorderCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsBorderCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsBorderCheckBox.Location = new System.Drawing.Point(413, 5);
            this.recentAchievementsBorderCheckBox.Name = "recentAchievementsBorderCheckBox";
            this.recentAchievementsBorderCheckBox.Size = new System.Drawing.Size(15, 14);
            this.recentAchievementsBorderCheckBox.TabIndex = 10065;
            this.recentAchievementsBorderCheckBox.UseVisualStyleBackColor = true;
            this.recentAchievementsBorderCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // recentAchievementsBorderColorPictureBox
            // 
            this.recentAchievementsBorderColorPictureBox.BackColor = System.Drawing.Color.White;
            this.recentAchievementsBorderColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsBorderColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.recentAchievementsBorderColorPictureBox.Name = "recentAchievementsBorderColorPictureBox";
            this.recentAchievementsBorderColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.recentAchievementsBorderColorPictureBox.TabIndex = 42;
            this.recentAchievementsBorderColorPictureBox.TabStop = false;
            this.recentAchievementsBorderColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label18.Location = new System.Drawing.Point(3, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(144, 16);
            this.label18.TabIndex = 10064;
            this.label18.Text = "Border";
            // 
            // recentAchievementsPointsPanel
            // 
            this.recentAchievementsPointsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.recentAchievementsPointsPanel.Controls.Add(this.label19);
            this.recentAchievementsPointsPanel.Controls.Add(this.recentAchievementsPointsFontColorPictureBox);
            this.recentAchievementsPointsPanel.Controls.Add(this.recentAchievementsPointsFontComboBox);
            this.recentAchievementsPointsPanel.Location = new System.Drawing.Point(2, 150);
            this.recentAchievementsPointsPanel.Name = "recentAchievementsPointsPanel";
            this.recentAchievementsPointsPanel.Size = new System.Drawing.Size(463, 23);
            this.recentAchievementsPointsPanel.TabIndex = 10070;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label19.Location = new System.Drawing.Point(3, 4);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(144, 16);
            this.label19.TabIndex = 10065;
            this.label19.Text = "Points";
            // 
            // recentAchievementsPointsFontColorPictureBox
            // 
            this.recentAchievementsPointsFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.recentAchievementsPointsFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsPointsFontColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.recentAchievementsPointsFontColorPictureBox.Name = "recentAchievementsPointsFontColorPictureBox";
            this.recentAchievementsPointsFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.recentAchievementsPointsFontColorPictureBox.TabIndex = 45;
            this.recentAchievementsPointsFontColorPictureBox.TabStop = false;
            this.recentAchievementsPointsFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // recentAchievementsPointsFontComboBox
            // 
            this.recentAchievementsPointsFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.recentAchievementsPointsFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsPointsFontComboBox.ForeColor = System.Drawing.Color.White;
            this.recentAchievementsPointsFontComboBox.FormattingEnabled = true;
            this.recentAchievementsPointsFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.recentAchievementsPointsFontComboBox.Name = "recentAchievementsPointsFontComboBox";
            this.recentAchievementsPointsFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.recentAchievementsPointsFontComboBox.TabIndex = 45;
            this.recentAchievementsPointsFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // panel103
            // 
            this.panel103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel103.Controls.Add(this.recentAchievementsAdvancedCheckBox);
            this.panel103.Controls.Add(this.label20);
            this.panel103.Controls.Add(this.label21);
            this.panel103.Controls.Add(this.label22);
            this.panel103.Controls.Add(this.label23);
            this.panel103.Location = new System.Drawing.Point(2, 40);
            this.panel103.Name = "panel103";
            this.panel103.Size = new System.Drawing.Size(463, 23);
            this.panel103.TabIndex = 10076;
            // 
            // recentAchievementsAdvancedCheckBox
            // 
            this.recentAchievementsAdvancedCheckBox.AutoSize = true;
            this.recentAchievementsAdvancedCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsAdvancedCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.recentAchievementsAdvancedCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsAdvancedCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsAdvancedCheckBox.Location = new System.Drawing.Point(5, 2);
            this.recentAchievementsAdvancedCheckBox.Name = "recentAchievementsAdvancedCheckBox";
            this.recentAchievementsAdvancedCheckBox.Size = new System.Drawing.Size(91, 20);
            this.recentAchievementsAdvancedCheckBox.TabIndex = 10053;
            this.recentAchievementsAdvancedCheckBox.Text = "Advanced";
            this.recentAchievementsAdvancedCheckBox.UseVisualStyleBackColor = false;
            this.recentAchievementsAdvancedCheckBox.CheckedChanged += new System.EventHandler(this.AdvancedCheckBox_Click);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label20.Location = new System.Drawing.Point(150, 3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 16);
            this.label20.TabIndex = 10065;
            this.label20.Text = "Color";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label21.Location = new System.Drawing.Point(194, 3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 16);
            this.label21.TabIndex = 10066;
            this.label21.Text = "Font";
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label22.Location = new System.Drawing.Point(349, 3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 16);
            this.label22.TabIndex = 10068;
            this.label22.Text = "Size";
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label23.Location = new System.Drawing.Point(396, 3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 16);
            this.label23.TabIndex = 10067;
            this.label23.Text = "Enabled";
            // 
            // panel104
            // 
            this.panel104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel104.Controls.Add(this.recentAchievementsTitleFontOutlineNumericUpDown);
            this.panel104.Controls.Add(this.recentAchievementsTitleFontOutlineCheckBox);
            this.panel104.Controls.Add(this.recentAchievementsTitleOutlineLabel);
            this.panel104.Controls.Add(this.recentAchievementsTitleFontOutlineColorPictureBox);
            this.panel104.Location = new System.Drawing.Point(2, 194);
            this.panel104.Name = "panel104";
            this.panel104.Size = new System.Drawing.Size(463, 23);
            this.panel104.TabIndex = 10071;
            // 
            // recentAchievementsTitleFontOutlineNumericUpDown
            // 
            this.recentAchievementsTitleFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.recentAchievementsTitleFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recentAchievementsTitleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsTitleFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.recentAchievementsTitleFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.recentAchievementsTitleFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.recentAchievementsTitleFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentAchievementsTitleFontOutlineNumericUpDown.Name = "recentAchievementsTitleFontOutlineNumericUpDown";
            this.recentAchievementsTitleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.recentAchievementsTitleFontOutlineNumericUpDown.TabIndex = 45;
            this.recentAchievementsTitleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentAchievementsTitleFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // recentAchievementsTitleFontOutlineCheckBox
            // 
            this.recentAchievementsTitleFontOutlineCheckBox.AutoSize = true;
            this.recentAchievementsTitleFontOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsTitleFontOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsTitleFontOutlineCheckBox.Location = new System.Drawing.Point(413, 5);
            this.recentAchievementsTitleFontOutlineCheckBox.Name = "recentAchievementsTitleFontOutlineCheckBox";
            this.recentAchievementsTitleFontOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.recentAchievementsTitleFontOutlineCheckBox.TabIndex = 45;
            this.recentAchievementsTitleFontOutlineCheckBox.UseVisualStyleBackColor = true;
            this.recentAchievementsTitleFontOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // recentAchievementsTitleOutlineLabel
            // 
            this.recentAchievementsTitleOutlineLabel.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsTitleOutlineLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsTitleOutlineLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsTitleOutlineLabel.Location = new System.Drawing.Point(3, 3);
            this.recentAchievementsTitleOutlineLabel.Name = "recentAchievementsTitleOutlineLabel";
            this.recentAchievementsTitleOutlineLabel.Size = new System.Drawing.Size(144, 16);
            this.recentAchievementsTitleOutlineLabel.TabIndex = 10066;
            this.recentAchievementsTitleOutlineLabel.Text = "Title Outline";
            // 
            // recentAchievementsTitleFontOutlineColorPictureBox
            // 
            this.recentAchievementsTitleFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.recentAchievementsTitleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsTitleFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.recentAchievementsTitleFontOutlineColorPictureBox.Name = "recentAchievementsTitleFontOutlineColorPictureBox";
            this.recentAchievementsTitleFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.recentAchievementsTitleFontOutlineColorPictureBox.TabIndex = 45;
            this.recentAchievementsTitleFontOutlineColorPictureBox.TabStop = false;
            this.recentAchievementsTitleFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // recentAchievementsOpenWindowButton
            // 
            this.recentAchievementsOpenWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.recentAchievementsOpenWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.recentAchievementsOpenWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recentAchievementsOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsOpenWindowButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.recentAchievementsOpenWindowButton.Location = new System.Drawing.Point(382, 2);
            this.recentAchievementsOpenWindowButton.Margin = new System.Windows.Forms.Padding(0);
            this.recentAchievementsOpenWindowButton.Name = "recentAchievementsOpenWindowButton";
            this.recentAchievementsOpenWindowButton.Size = new System.Drawing.Size(75, 27);
            this.recentAchievementsOpenWindowButton.TabIndex = 10021;
            this.recentAchievementsOpenWindowButton.Text = "Open";
            this.recentAchievementsOpenWindowButton.UseVisualStyleBackColor = false;
            this.recentAchievementsOpenWindowButton.Click += new System.EventHandler(this.ShowWindowButton_Click);
            // 
            // recentAchievementsDescriptionOutlinePanel
            // 
            this.recentAchievementsDescriptionOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.recentAchievementsDescriptionOutlinePanel.Controls.Add(this.label144);
            this.recentAchievementsDescriptionOutlinePanel.Controls.Add(this.recentAchievementsDateFontOutlineColorPictureBox);
            this.recentAchievementsDescriptionOutlinePanel.Controls.Add(this.recentAchievementsDescriptionFontOutlineNumericUpDown);
            this.recentAchievementsDescriptionOutlinePanel.Controls.Add(this.recentAchievementsDateFontOutlineCheckBox);
            this.recentAchievementsDescriptionOutlinePanel.Location = new System.Drawing.Point(2, 216);
            this.recentAchievementsDescriptionOutlinePanel.Name = "recentAchievementsDescriptionOutlinePanel";
            this.recentAchievementsDescriptionOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.recentAchievementsDescriptionOutlinePanel.TabIndex = 10072;
            // 
            // label144
            // 
            this.label144.BackColor = System.Drawing.Color.Transparent;
            this.label144.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label144.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label144.Location = new System.Drawing.Point(3, 4);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(144, 16);
            this.label144.TabIndex = 10066;
            this.label144.Text = "Date Outline";
            // 
            // recentAchievementsDateFontOutlineColorPictureBox
            // 
            this.recentAchievementsDateFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.recentAchievementsDateFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsDateFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.recentAchievementsDateFontOutlineColorPictureBox.Name = "recentAchievementsDateFontOutlineColorPictureBox";
            this.recentAchievementsDateFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.recentAchievementsDateFontOutlineColorPictureBox.TabIndex = 45;
            this.recentAchievementsDateFontOutlineColorPictureBox.TabStop = false;
            this.recentAchievementsDateFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // recentAchievementsDescriptionFontOutlineNumericUpDown
            // 
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.Name = "recentAchievementsDescriptionFontOutlineNumericUpDown";
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.TabIndex = 45;
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // recentAchievementsDateFontOutlineCheckBox
            // 
            this.recentAchievementsDateFontOutlineCheckBox.AutoSize = true;
            this.recentAchievementsDateFontOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsDateFontOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsDateFontOutlineCheckBox.Location = new System.Drawing.Point(413, 6);
            this.recentAchievementsDateFontOutlineCheckBox.Name = "recentAchievementsDateFontOutlineCheckBox";
            this.recentAchievementsDateFontOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.recentAchievementsDateFontOutlineCheckBox.TabIndex = 45;
            this.recentAchievementsDateFontOutlineCheckBox.UseVisualStyleBackColor = true;
            this.recentAchievementsDateFontOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // recentAchievementsDescriptionPanel
            // 
            this.recentAchievementsDescriptionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.recentAchievementsDescriptionPanel.Controls.Add(this.label145);
            this.recentAchievementsDescriptionPanel.Controls.Add(this.recentAchievementsDateFontColorPictureBox);
            this.recentAchievementsDescriptionPanel.Controls.Add(this.recentAchievementsDescriptionFontComboBox);
            this.recentAchievementsDescriptionPanel.Location = new System.Drawing.Point(2, 128);
            this.recentAchievementsDescriptionPanel.Name = "recentAchievementsDescriptionPanel";
            this.recentAchievementsDescriptionPanel.Size = new System.Drawing.Size(463, 23);
            this.recentAchievementsDescriptionPanel.TabIndex = 10061;
            // 
            // label145
            // 
            this.label145.BackColor = System.Drawing.Color.Transparent;
            this.label145.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label145.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label145.Location = new System.Drawing.Point(3, 4);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(144, 16);
            this.label145.TabIndex = 10066;
            this.label145.Text = "Date";
            // 
            // recentAchievementsDateFontColorPictureBox
            // 
            this.recentAchievementsDateFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.recentAchievementsDateFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsDateFontColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.recentAchievementsDateFontColorPictureBox.Name = "recentAchievementsDateFontColorPictureBox";
            this.recentAchievementsDateFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.recentAchievementsDateFontColorPictureBox.TabIndex = 45;
            this.recentAchievementsDateFontColorPictureBox.TabStop = false;
            this.recentAchievementsDateFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // recentAchievementsDescriptionFontComboBox
            // 
            this.recentAchievementsDescriptionFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.recentAchievementsDescriptionFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsDescriptionFontComboBox.ForeColor = System.Drawing.Color.White;
            this.recentAchievementsDescriptionFontComboBox.FormattingEnabled = true;
            this.recentAchievementsDescriptionFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.recentAchievementsDescriptionFontComboBox.Name = "recentAchievementsDescriptionFontComboBox";
            this.recentAchievementsDescriptionFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.recentAchievementsDescriptionFontComboBox.TabIndex = 45;
            this.recentAchievementsDescriptionFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // recentAchievementsAutoOpenWindowCheckbox
            // 
            this.recentAchievementsAutoOpenWindowCheckbox.AutoSize = true;
            this.recentAchievementsAutoOpenWindowCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.recentAchievementsAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsAutoOpenWindowCheckbox.Location = new System.Drawing.Point(252, 9);
            this.recentAchievementsAutoOpenWindowCheckbox.Name = "recentAchievementsAutoOpenWindowCheckbox";
            this.recentAchievementsAutoOpenWindowCheckbox.Size = new System.Drawing.Size(98, 20);
            this.recentAchievementsAutoOpenWindowCheckbox.TabIndex = 10022;
            this.recentAchievementsAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.recentAchievementsAutoOpenWindowCheckbox.UseVisualStyleBackColor = true;
            this.recentAchievementsAutoOpenWindowCheckbox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // pictureBox23
            // 
            this.pictureBox23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox23.Location = new System.Drawing.Point(2, 32);
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.Size = new System.Drawing.Size(460, 2);
            this.pictureBox23.TabIndex = 10063;
            this.pictureBox23.TabStop = false;
            // 
            // panel107
            // 
            this.panel107.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel107.Controls.Add(this.recentAchievementsBackgroundColorPictureBox);
            this.panel107.Controls.Add(this.label146);
            this.panel107.Location = new System.Drawing.Point(2, 62);
            this.panel107.Name = "panel107";
            this.panel107.Size = new System.Drawing.Size(463, 23);
            this.panel107.TabIndex = 10061;
            // 
            // recentAchievementsBackgroundColorPictureBox
            // 
            this.recentAchievementsBackgroundColorPictureBox.BackColor = System.Drawing.Color.White;
            this.recentAchievementsBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsBackgroundColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.recentAchievementsBackgroundColorPictureBox.Name = "recentAchievementsBackgroundColorPictureBox";
            this.recentAchievementsBackgroundColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.recentAchievementsBackgroundColorPictureBox.TabIndex = 42;
            this.recentAchievementsBackgroundColorPictureBox.TabStop = false;
            this.recentAchievementsBackgroundColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label146
            // 
            this.label146.BackColor = System.Drawing.Color.Transparent;
            this.label146.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label146.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label146.Location = new System.Drawing.Point(3, 3);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(144, 16);
            this.label146.TabIndex = 10064;
            this.label146.Text = "Window Background";
            // 
            // panel108
            // 
            this.panel108.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel108.Controls.Add(this.recentAchievementsTitleLabel);
            this.panel108.Controls.Add(this.recentAchievementsTitleFontColorPictureBox);
            this.panel108.Controls.Add(this.recentAchievementsTitleFontComboBox);
            this.panel108.Location = new System.Drawing.Point(2, 106);
            this.panel108.Name = "panel108";
            this.panel108.Size = new System.Drawing.Size(463, 23);
            this.panel108.TabIndex = 10061;
            // 
            // recentAchievementsTitleLabel
            // 
            this.recentAchievementsTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsTitleLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsTitleLabel.Location = new System.Drawing.Point(3, 4);
            this.recentAchievementsTitleLabel.Name = "recentAchievementsTitleLabel";
            this.recentAchievementsTitleLabel.Size = new System.Drawing.Size(144, 16);
            this.recentAchievementsTitleLabel.TabIndex = 10065;
            this.recentAchievementsTitleLabel.Text = "Title";
            // 
            // recentAchievementsTitleFontColorPictureBox
            // 
            this.recentAchievementsTitleFontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.recentAchievementsTitleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsTitleFontColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.recentAchievementsTitleFontColorPictureBox.Name = "recentAchievementsTitleFontColorPictureBox";
            this.recentAchievementsTitleFontColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.recentAchievementsTitleFontColorPictureBox.TabIndex = 45;
            this.recentAchievementsTitleFontColorPictureBox.TabStop = false;
            this.recentAchievementsTitleFontColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // recentAchievementsTitleFontComboBox
            // 
            this.recentAchievementsTitleFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.recentAchievementsTitleFontComboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsTitleFontComboBox.ForeColor = System.Drawing.Color.White;
            this.recentAchievementsTitleFontComboBox.FormattingEnabled = true;
            this.recentAchievementsTitleFontComboBox.Location = new System.Drawing.Point(193, 2);
            this.recentAchievementsTitleFontComboBox.Name = "recentAchievementsTitleFontComboBox";
            this.recentAchievementsTitleFontComboBox.Size = new System.Drawing.Size(202, 21);
            this.recentAchievementsTitleFontComboBox.TabIndex = 45;
            this.recentAchievementsTitleFontComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // recentAchievementsPointsOutlinePanel
            // 
            this.recentAchievementsPointsOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.recentAchievementsPointsOutlinePanel.Controls.Add(this.recentAchievementsPointsFontOutlineNumericUpDown);
            this.recentAchievementsPointsOutlinePanel.Controls.Add(this.recentAchievementsPointsFontOutlineCheckBox);
            this.recentAchievementsPointsOutlinePanel.Controls.Add(this.label148);
            this.recentAchievementsPointsOutlinePanel.Controls.Add(this.recentAchievementsPointsFontOutlineColorPictureBox);
            this.recentAchievementsPointsOutlinePanel.Location = new System.Drawing.Point(2, 238);
            this.recentAchievementsPointsOutlinePanel.Name = "recentAchievementsPointsOutlinePanel";
            this.recentAchievementsPointsOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.recentAchievementsPointsOutlinePanel.TabIndex = 10061;
            // 
            // recentAchievementsPointsFontOutlineNumericUpDown
            // 
            this.recentAchievementsPointsFontOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.recentAchievementsPointsFontOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recentAchievementsPointsFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsPointsFontOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.recentAchievementsPointsFontOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.recentAchievementsPointsFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.recentAchievementsPointsFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentAchievementsPointsFontOutlineNumericUpDown.Name = "recentAchievementsPointsFontOutlineNumericUpDown";
            this.recentAchievementsPointsFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.recentAchievementsPointsFontOutlineNumericUpDown.TabIndex = 45;
            this.recentAchievementsPointsFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentAchievementsPointsFontOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // recentAchievementsPointsFontOutlineCheckBox
            // 
            this.recentAchievementsPointsFontOutlineCheckBox.AutoSize = true;
            this.recentAchievementsPointsFontOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsPointsFontOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsPointsFontOutlineCheckBox.Location = new System.Drawing.Point(413, 5);
            this.recentAchievementsPointsFontOutlineCheckBox.Name = "recentAchievementsPointsFontOutlineCheckBox";
            this.recentAchievementsPointsFontOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.recentAchievementsPointsFontOutlineCheckBox.TabIndex = 45;
            this.recentAchievementsPointsFontOutlineCheckBox.UseVisualStyleBackColor = true;
            this.recentAchievementsPointsFontOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // label148
            // 
            this.label148.BackColor = System.Drawing.Color.Transparent;
            this.label148.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label148.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label148.Location = new System.Drawing.Point(3, 3);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(144, 16);
            this.label148.TabIndex = 10066;
            this.label148.Text = "Points Outline";
            // 
            // recentAchievementsPointsFontOutlineColorPictureBox
            // 
            this.recentAchievementsPointsFontOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.recentAchievementsPointsFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsPointsFontOutlineColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.recentAchievementsPointsFontOutlineColorPictureBox.Name = "recentAchievementsPointsFontOutlineColorPictureBox";
            this.recentAchievementsPointsFontOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.recentAchievementsPointsFontOutlineColorPictureBox.TabIndex = 45;
            this.recentAchievementsPointsFontOutlineColorPictureBox.TabStop = false;
            this.recentAchievementsPointsFontOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // recentAchievementsLineOutlinePanel
            // 
            this.recentAchievementsLineOutlinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.recentAchievementsLineOutlinePanel.Controls.Add(this.label149);
            this.recentAchievementsLineOutlinePanel.Controls.Add(this.recentAchievementsLineOutlineColorPictureBox);
            this.recentAchievementsLineOutlinePanel.Controls.Add(this.recentAchievementsLineOutlineNumericUpDown);
            this.recentAchievementsLineOutlinePanel.Controls.Add(this.recentAchievementsLineOutlineCheckBox);
            this.recentAchievementsLineOutlinePanel.Location = new System.Drawing.Point(2, 260);
            this.recentAchievementsLineOutlinePanel.Name = "recentAchievementsLineOutlinePanel";
            this.recentAchievementsLineOutlinePanel.Size = new System.Drawing.Size(463, 23);
            this.recentAchievementsLineOutlinePanel.TabIndex = 10067;
            // 
            // label149
            // 
            this.label149.BackColor = System.Drawing.Color.Transparent;
            this.label149.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label149.Location = new System.Drawing.Point(3, 4);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(144, 16);
            this.label149.TabIndex = 10066;
            this.label149.Text = "Line Outline";
            // 
            // recentAchievementsLineOutlineColorPictureBox
            // 
            this.recentAchievementsLineOutlineColorPictureBox.BackColor = System.Drawing.Color.White;
            this.recentAchievementsLineOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsLineOutlineColorPictureBox.Location = new System.Drawing.Point(153, 4);
            this.recentAchievementsLineOutlineColorPictureBox.Name = "recentAchievementsLineOutlineColorPictureBox";
            this.recentAchievementsLineOutlineColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.recentAchievementsLineOutlineColorPictureBox.TabIndex = 45;
            this.recentAchievementsLineOutlineColorPictureBox.TabStop = false;
            this.recentAchievementsLineOutlineColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // recentAchievementsLineOutlineNumericUpDown
            // 
            this.recentAchievementsLineOutlineNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.recentAchievementsLineOutlineNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recentAchievementsLineOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsLineOutlineNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.recentAchievementsLineOutlineNumericUpDown.Location = new System.Drawing.Point(352, 4);
            this.recentAchievementsLineOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.recentAchievementsLineOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentAchievementsLineOutlineNumericUpDown.Name = "recentAchievementsLineOutlineNumericUpDown";
            this.recentAchievementsLineOutlineNumericUpDown.Size = new System.Drawing.Size(43, 17);
            this.recentAchievementsLineOutlineNumericUpDown.TabIndex = 45;
            this.recentAchievementsLineOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentAchievementsLineOutlineNumericUpDown.ValueChanged += new System.EventHandler(this.CustomNumericUpDown_ValueChanged);
            // 
            // recentAchievementsLineOutlineCheckBox
            // 
            this.recentAchievementsLineOutlineCheckBox.AutoSize = true;
            this.recentAchievementsLineOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsLineOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsLineOutlineCheckBox.Location = new System.Drawing.Point(413, 6);
            this.recentAchievementsLineOutlineCheckBox.Name = "recentAchievementsLineOutlineCheckBox";
            this.recentAchievementsLineOutlineCheckBox.Size = new System.Drawing.Size(15, 14);
            this.recentAchievementsLineOutlineCheckBox.TabIndex = 45;
            this.recentAchievementsLineOutlineCheckBox.UseVisualStyleBackColor = true;
            this.recentAchievementsLineOutlineCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // panel115
            // 
            this.panel115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel115.Controls.Add(this.label152);
            this.panel115.Controls.Add(this.pictureBox18);
            this.panel115.Controls.Add(this.achievementListAutoScrollCheckBox);
            this.panel115.Location = new System.Drawing.Point(4, 3);
            this.panel115.Name = "panel115";
            this.panel115.Size = new System.Drawing.Size(289, 64);
            this.panel115.TabIndex = 10084;
            // 
            // label152
            // 
            this.label152.BackColor = System.Drawing.Color.Transparent;
            this.label152.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label152.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label152.Location = new System.Drawing.Point(3, 3);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(190, 26);
            this.label152.TabIndex = 10069;
            this.label152.Text = "List Settings";
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox18.Location = new System.Drawing.Point(2, 32);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(275, 2);
            this.pictureBox18.TabIndex = 10070;
            this.pictureBox18.TabStop = false;
            // 
            // achievementListAutoScrollCheckBox
            // 
            this.achievementListAutoScrollCheckBox.AutoSize = true;
            this.achievementListAutoScrollCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.achievementListAutoScrollCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.achievementListAutoScrollCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementListAutoScrollCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.achievementListAutoScrollCheckBox.Location = new System.Drawing.Point(3, 39);
            this.achievementListAutoScrollCheckBox.Name = "achievementListAutoScrollCheckBox";
            this.achievementListAutoScrollCheckBox.Size = new System.Drawing.Size(98, 20);
            this.achievementListAutoScrollCheckBox.TabIndex = 10055;
            this.achievementListAutoScrollCheckBox.Text = "Auto-scroll";
            this.achievementListAutoScrollCheckBox.UseVisualStyleBackColor = false;
            this.achievementListAutoScrollCheckBox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // panel111
            // 
            this.panel111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel111.Controls.Add(this.label150);
            this.panel111.Controls.Add(this.panel112);
            this.panel111.Controls.Add(this.achievementListOpenWindowButton);
            this.panel111.Controls.Add(this.achievementListAutoOpenWindowCheckbox);
            this.panel111.Controls.Add(this.pictureBox16);
            this.panel111.Controls.Add(this.panel114);
            this.panel111.Location = new System.Drawing.Point(296, 3);
            this.panel111.Name = "panel111";
            this.panel111.Size = new System.Drawing.Size(468, 87);
            this.panel111.TabIndex = 10082;
            // 
            // label150
            // 
            this.label150.BackColor = System.Drawing.Color.Transparent;
            this.label150.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label150.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label150.Location = new System.Drawing.Point(3, 3);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(243, 26);
            this.label150.TabIndex = 10062;
            this.label150.Text = "Window/Font Settings";
            // 
            // panel112
            // 
            this.panel112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.panel112.Controls.Add(this.label151);
            this.panel112.Location = new System.Drawing.Point(2, 40);
            this.panel112.Name = "panel112";
            this.panel112.Size = new System.Drawing.Size(463, 23);
            this.panel112.TabIndex = 10076;
            // 
            // label151
            // 
            this.label151.BackColor = System.Drawing.Color.Transparent;
            this.label151.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label151.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label151.Location = new System.Drawing.Point(150, 3);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(48, 16);
            this.label151.TabIndex = 10065;
            this.label151.Text = "Color";
            // 
            // achievementListOpenWindowButton
            // 
            this.achievementListOpenWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.achievementListOpenWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.achievementListOpenWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.achievementListOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementListOpenWindowButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.achievementListOpenWindowButton.Location = new System.Drawing.Point(382, 2);
            this.achievementListOpenWindowButton.Margin = new System.Windows.Forms.Padding(0);
            this.achievementListOpenWindowButton.Name = "achievementListOpenWindowButton";
            this.achievementListOpenWindowButton.Size = new System.Drawing.Size(75, 27);
            this.achievementListOpenWindowButton.TabIndex = 10021;
            this.achievementListOpenWindowButton.Text = "Open";
            this.achievementListOpenWindowButton.UseVisualStyleBackColor = false;
            this.achievementListOpenWindowButton.Click += new System.EventHandler(this.ShowWindowButton_Click);
            // 
            // achievementListAutoOpenWindowCheckbox
            // 
            this.achievementListAutoOpenWindowCheckbox.AutoSize = true;
            this.achievementListAutoOpenWindowCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.achievementListAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementListAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.achievementListAutoOpenWindowCheckbox.Location = new System.Drawing.Point(252, 9);
            this.achievementListAutoOpenWindowCheckbox.Name = "achievementListAutoOpenWindowCheckbox";
            this.achievementListAutoOpenWindowCheckbox.Size = new System.Drawing.Size(98, 20);
            this.achievementListAutoOpenWindowCheckbox.TabIndex = 10022;
            this.achievementListAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.achievementListAutoOpenWindowCheckbox.UseVisualStyleBackColor = true;
            this.achievementListAutoOpenWindowCheckbox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // pictureBox16
            // 
            this.pictureBox16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox16.Location = new System.Drawing.Point(2, 32);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(460, 2);
            this.pictureBox16.TabIndex = 10063;
            this.pictureBox16.TabStop = false;
            // 
            // panel114
            // 
            this.panel114.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel114.Controls.Add(this.achievementListBackgroundColorPictureBox);
            this.panel114.Controls.Add(this.label156);
            this.panel114.Location = new System.Drawing.Point(2, 62);
            this.panel114.Name = "panel114";
            this.panel114.Size = new System.Drawing.Size(463, 23);
            this.panel114.TabIndex = 10061;
            // 
            // achievementListBackgroundColorPictureBox
            // 
            this.achievementListBackgroundColorPictureBox.BackColor = System.Drawing.Color.White;
            this.achievementListBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.achievementListBackgroundColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.achievementListBackgroundColorPictureBox.Name = "achievementListBackgroundColorPictureBox";
            this.achievementListBackgroundColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.achievementListBackgroundColorPictureBox.TabIndex = 42;
            this.achievementListBackgroundColorPictureBox.TabStop = false;
            this.achievementListBackgroundColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label156
            // 
            this.label156.BackColor = System.Drawing.Color.Transparent;
            this.label156.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label156.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label156.Location = new System.Drawing.Point(3, 3);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(144, 16);
            this.label156.TabIndex = 10064;
            this.label156.Text = "Window Background";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.startButton);
            this.panel1.Controls.Add(this.stopButton);
            this.panel1.Controls.Add(this.autoStartCheckbox);
            this.panel1.Location = new System.Drawing.Point(376, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 96);
            this.panel1.TabIndex = 10031;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel3.Controls.Add(this.apiKeyLabel);
            this.panel3.Controls.Add(this.apiKeyTextBox);
            this.panel3.Location = new System.Drawing.Point(3, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(397, 28);
            this.panel3.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel2.Controls.Add(this.usernameLabel);
            this.panel2.Controls.Add(this.usernameTextBox);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 28);
            this.panel2.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Retro_Achievement_Tracker.Properties.Resources.retro_achievements_banner;
            this.pictureBox1.Location = new System.Drawing.Point(11, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10032;
            this.pictureBox1.TabStop = false;
            // 
            // panel120
            // 
            this.panel120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel120.Controls.Add(this.relatedMediaRAScreenshotRadioButton);
            this.panel120.Controls.Add(this.relatedMediaRABadgeIconRadioButton);
            this.panel120.Controls.Add(this.relatedMediaRABoxArtRadioButton);
            this.panel120.Controls.Add(this.relatedMediaRATitleScreenRadioButton);
            this.panel120.Controls.Add(this.pictureBox19);
            this.panel120.Controls.Add(this.label1);
            this.panel120.Location = new System.Drawing.Point(4, 3);
            this.panel120.Name = "panel120";
            this.panel120.Size = new System.Drawing.Size(289, 147);
            this.panel120.TabIndex = 0;
            // 
            // relatedMediaRAScreenshotRadioButton
            // 
            this.relatedMediaRAScreenshotRadioButton.AutoSize = true;
            this.relatedMediaRAScreenshotRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaRAScreenshotRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaRAScreenshotRadioButton.Location = new System.Drawing.Point(8, 118);
            this.relatedMediaRAScreenshotRadioButton.Name = "relatedMediaRAScreenshotRadioButton";
            this.relatedMediaRAScreenshotRadioButton.Size = new System.Drawing.Size(100, 20);
            this.relatedMediaRAScreenshotRadioButton.TabIndex = 10075;
            this.relatedMediaRAScreenshotRadioButton.Text = "Screenshot";
            this.relatedMediaRAScreenshotRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaRAScreenshotRadioButton.CheckedChanged += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaRABadgeIconRadioButton
            // 
            this.relatedMediaRABadgeIconRadioButton.AutoSize = true;
            this.relatedMediaRABadgeIconRadioButton.Checked = true;
            this.relatedMediaRABadgeIconRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaRABadgeIconRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaRABadgeIconRadioButton.Location = new System.Drawing.Point(8, 40);
            this.relatedMediaRABadgeIconRadioButton.Name = "relatedMediaRABadgeIconRadioButton";
            this.relatedMediaRABadgeIconRadioButton.Size = new System.Drawing.Size(99, 20);
            this.relatedMediaRABadgeIconRadioButton.TabIndex = 10072;
            this.relatedMediaRABadgeIconRadioButton.TabStop = true;
            this.relatedMediaRABadgeIconRadioButton.Text = "Badge Icon";
            this.relatedMediaRABadgeIconRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaRABadgeIconRadioButton.CheckedChanged += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaRABoxArtRadioButton
            // 
            this.relatedMediaRABoxArtRadioButton.AutoSize = true;
            this.relatedMediaRABoxArtRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaRABoxArtRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaRABoxArtRadioButton.Location = new System.Drawing.Point(8, 66);
            this.relatedMediaRABoxArtRadioButton.Name = "relatedMediaRABoxArtRadioButton";
            this.relatedMediaRABoxArtRadioButton.Size = new System.Drawing.Size(73, 20);
            this.relatedMediaRABoxArtRadioButton.TabIndex = 10074;
            this.relatedMediaRABoxArtRadioButton.Text = "Box Art";
            this.relatedMediaRABoxArtRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaRABoxArtRadioButton.CheckedChanged += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaRATitleScreenRadioButton
            // 
            this.relatedMediaRATitleScreenRadioButton.AutoSize = true;
            this.relatedMediaRATitleScreenRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaRATitleScreenRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaRATitleScreenRadioButton.Location = new System.Drawing.Point(8, 92);
            this.relatedMediaRATitleScreenRadioButton.Name = "relatedMediaRATitleScreenRadioButton";
            this.relatedMediaRATitleScreenRadioButton.Size = new System.Drawing.Size(105, 20);
            this.relatedMediaRATitleScreenRadioButton.TabIndex = 10073;
            this.relatedMediaRATitleScreenRadioButton.Text = "Title Screen";
            this.relatedMediaRATitleScreenRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaRATitleScreenRadioButton.CheckedChanged += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // pictureBox19
            // 
            this.pictureBox19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox19.Location = new System.Drawing.Point(2, 32);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(275, 2);
            this.pictureBox19.TabIndex = 10071;
            this.pictureBox19.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 26);
            this.label1.TabIndex = 10063;
            this.label1.Text = "RetroAchievements.org";
            // 
            // panel121
            // 
            this.panel121.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel121.Controls.Add(this.label90);
            this.panel121.Controls.Add(this.panel122);
            this.panel121.Controls.Add(this.relatedMediaOpenWindowButton);
            this.panel121.Controls.Add(this.relatedMediaAutoOpenWindowCheckbox);
            this.panel121.Controls.Add(this.pictureBox22);
            this.panel121.Controls.Add(this.panel123);
            this.panel121.Location = new System.Drawing.Point(296, 3);
            this.panel121.Name = "panel121";
            this.panel121.Size = new System.Drawing.Size(468, 87);
            this.panel121.TabIndex = 10083;
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.Transparent;
            this.label90.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label90.Location = new System.Drawing.Point(3, 3);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(243, 26);
            this.label90.TabIndex = 10062;
            this.label90.Text = "Window/Font Settings";
            // 
            // panel122
            // 
            this.panel122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.panel122.Controls.Add(this.label91);
            this.panel122.Location = new System.Drawing.Point(2, 40);
            this.panel122.Name = "panel122";
            this.panel122.Size = new System.Drawing.Size(463, 23);
            this.panel122.TabIndex = 10076;
            // 
            // label91
            // 
            this.label91.BackColor = System.Drawing.Color.Transparent;
            this.label91.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label91.Location = new System.Drawing.Point(150, 3);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(48, 16);
            this.label91.TabIndex = 10065;
            this.label91.Text = "Color";
            // 
            // relatedMediaOpenWindowButton
            // 
            this.relatedMediaOpenWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.relatedMediaOpenWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.relatedMediaOpenWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.relatedMediaOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaOpenWindowButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.relatedMediaOpenWindowButton.Location = new System.Drawing.Point(382, 2);
            this.relatedMediaOpenWindowButton.Margin = new System.Windows.Forms.Padding(0);
            this.relatedMediaOpenWindowButton.Name = "relatedMediaOpenWindowButton";
            this.relatedMediaOpenWindowButton.Size = new System.Drawing.Size(75, 27);
            this.relatedMediaOpenWindowButton.TabIndex = 10021;
            this.relatedMediaOpenWindowButton.Text = "Open";
            this.relatedMediaOpenWindowButton.UseVisualStyleBackColor = false;
            this.relatedMediaOpenWindowButton.Click += new System.EventHandler(this.ShowWindowButton_Click);
            // 
            // relatedMediaAutoOpenWindowCheckbox
            // 
            this.relatedMediaAutoOpenWindowCheckbox.AutoSize = true;
            this.relatedMediaAutoOpenWindowCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.relatedMediaAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaAutoOpenWindowCheckbox.Location = new System.Drawing.Point(252, 9);
            this.relatedMediaAutoOpenWindowCheckbox.Name = "relatedMediaAutoOpenWindowCheckbox";
            this.relatedMediaAutoOpenWindowCheckbox.Size = new System.Drawing.Size(98, 20);
            this.relatedMediaAutoOpenWindowCheckbox.TabIndex = 10022;
            this.relatedMediaAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.relatedMediaAutoOpenWindowCheckbox.UseVisualStyleBackColor = true;
            this.relatedMediaAutoOpenWindowCheckbox.CheckedChanged += new System.EventHandler(this.FeatureEnablementCheckBox_CheckedChanged);
            // 
            // pictureBox22
            // 
            this.pictureBox22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox22.Location = new System.Drawing.Point(2, 32);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(460, 2);
            this.pictureBox22.TabIndex = 10063;
            this.pictureBox22.TabStop = false;
            // 
            // panel123
            // 
            this.panel123.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel123.Controls.Add(this.relatedMediaBackgroundColorPictureBox);
            this.panel123.Controls.Add(this.label92);
            this.panel123.Location = new System.Drawing.Point(2, 62);
            this.panel123.Name = "panel123";
            this.panel123.Size = new System.Drawing.Size(463, 23);
            this.panel123.TabIndex = 10061;
            // 
            // relatedMediaBackgroundColorPictureBox
            // 
            this.relatedMediaBackgroundColorPictureBox.BackColor = System.Drawing.Color.White;
            this.relatedMediaBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.relatedMediaBackgroundColorPictureBox.Location = new System.Drawing.Point(153, 3);
            this.relatedMediaBackgroundColorPictureBox.Name = "relatedMediaBackgroundColorPictureBox";
            this.relatedMediaBackgroundColorPictureBox.Size = new System.Drawing.Size(16, 16);
            this.relatedMediaBackgroundColorPictureBox.TabIndex = 42;
            this.relatedMediaBackgroundColorPictureBox.TabStop = false;
            this.relatedMediaBackgroundColorPictureBox.Click += new System.EventHandler(this.FontColorPictureBox_Click);
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.Color.Transparent;
            this.label92.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label92.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label92.Location = new System.Drawing.Point(3, 3);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(144, 16);
            this.label92.TabIndex = 10064;
            this.label92.Text = "Window Background";
            // 
            // panel124
            // 
            this.panel124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel124.Controls.Add(this.relatedMediaLBCartFrontRadioButton);
            this.panel124.Controls.Add(this.relatedMediaLBCartBackRadioButton);
            this.panel124.Controls.Add(this.relatedMediaLBBoxBackReconRadioButton);
            this.panel124.Controls.Add(this.relatedMediaLBBoxFullRadioButton);
            this.panel124.Controls.Add(this.relatedMediaLBBoxSpineRadioButton);
            this.panel124.Controls.Add(this.relatedMediaLBClearLogoRadioButton);
            this.panel124.Controls.Add(this.relatedMediaLBBannerRadioButton);
            this.panel124.Controls.Add(this.relatedMediaLBTitleScreenRadioButton);
            this.panel124.Controls.Add(this.relatedMediaSetLaunchBoxPathButton);
            this.panel124.Controls.Add(this.relatedMediaLBBoxFrontReconRadioButton);
            this.panel124.Controls.Add(this.relatedMediaLBBoxFrontRadioButton);
            this.panel124.Controls.Add(this.relatedMediaLBBoxBackRadioButton);
            this.panel124.Controls.Add(this.relatedMediaLBBox3DRadioButton);
            this.panel124.Controls.Add(this.relatedMediaLBLinePictureBox);
            this.panel124.Controls.Add(this.relatedMediaLBLabel);
            this.panel124.Location = new System.Drawing.Point(5, 156);
            this.panel124.Name = "panel124";
            this.panel124.Size = new System.Drawing.Size(289, 209);
            this.panel124.TabIndex = 10076;
            // 
            // relatedMediaLBCartFrontRadioButton
            // 
            this.relatedMediaLBCartFrontRadioButton.AutoSize = true;
            this.relatedMediaLBCartFrontRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBCartFrontRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBCartFrontRadioButton.Location = new System.Drawing.Point(173, 144);
            this.relatedMediaLBCartFrontRadioButton.Name = "relatedMediaLBCartFrontRadioButton";
            this.relatedMediaLBCartFrontRadioButton.Size = new System.Drawing.Size(105, 20);
            this.relatedMediaLBCartFrontRadioButton.TabIndex = 10084;
            this.relatedMediaLBCartFrontRadioButton.Text = "Cart - Front";
            this.relatedMediaLBCartFrontRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBCartFrontRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaLBCartBackRadioButton
            // 
            this.relatedMediaLBCartBackRadioButton.AutoSize = true;
            this.relatedMediaLBCartBackRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBCartBackRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBCartBackRadioButton.Location = new System.Drawing.Point(173, 170);
            this.relatedMediaLBCartBackRadioButton.Name = "relatedMediaLBCartBackRadioButton";
            this.relatedMediaLBCartBackRadioButton.Size = new System.Drawing.Size(101, 20);
            this.relatedMediaLBCartBackRadioButton.TabIndex = 10085;
            this.relatedMediaLBCartBackRadioButton.Text = "Cart - Back";
            this.relatedMediaLBCartBackRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBCartBackRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaLBBoxBackReconRadioButton
            // 
            this.relatedMediaLBBoxBackReconRadioButton.AutoSize = true;
            this.relatedMediaLBBoxBackReconRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBBoxBackReconRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBBoxBackReconRadioButton.Location = new System.Drawing.Point(7, 144);
            this.relatedMediaLBBoxBackReconRadioButton.Name = "relatedMediaLBBoxBackReconRadioButton";
            this.relatedMediaLBBoxBackReconRadioButton.Size = new System.Drawing.Size(153, 20);
            this.relatedMediaLBBoxBackReconRadioButton.TabIndex = 10082;
            this.relatedMediaLBBoxBackReconRadioButton.Text = "Box - Back (Recon)";
            this.relatedMediaLBBoxBackReconRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBBoxBackReconRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaLBBoxFullRadioButton
            // 
            this.relatedMediaLBBoxFullRadioButton.AutoSize = true;
            this.relatedMediaLBBoxFullRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBBoxFullRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBBoxFullRadioButton.Location = new System.Drawing.Point(7, 170);
            this.relatedMediaLBBoxFullRadioButton.Name = "relatedMediaLBBoxFullRadioButton";
            this.relatedMediaLBBoxFullRadioButton.Size = new System.Drawing.Size(87, 20);
            this.relatedMediaLBBoxFullRadioButton.TabIndex = 10083;
            this.relatedMediaLBBoxFullRadioButton.Text = "Box - Full";
            this.relatedMediaLBBoxFullRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBBoxFullRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaLBBoxSpineRadioButton
            // 
            this.relatedMediaLBBoxSpineRadioButton.AutoSize = true;
            this.relatedMediaLBBoxSpineRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBBoxSpineRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBBoxSpineRadioButton.Location = new System.Drawing.Point(173, 40);
            this.relatedMediaLBBoxSpineRadioButton.Name = "relatedMediaLBBoxSpineRadioButton";
            this.relatedMediaLBBoxSpineRadioButton.Size = new System.Drawing.Size(101, 20);
            this.relatedMediaLBBoxSpineRadioButton.TabIndex = 10081;
            this.relatedMediaLBBoxSpineRadioButton.Text = "Box - Spine";
            this.relatedMediaLBBoxSpineRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBBoxSpineRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaLBClearLogoRadioButton
            // 
            this.relatedMediaLBClearLogoRadioButton.AutoSize = true;
            this.relatedMediaLBClearLogoRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBClearLogoRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBClearLogoRadioButton.Location = new System.Drawing.Point(173, 118);
            this.relatedMediaLBClearLogoRadioButton.Name = "relatedMediaLBClearLogoRadioButton";
            this.relatedMediaLBClearLogoRadioButton.Size = new System.Drawing.Size(94, 20);
            this.relatedMediaLBClearLogoRadioButton.TabIndex = 10078;
            this.relatedMediaLBClearLogoRadioButton.Text = "Clear Logo";
            this.relatedMediaLBClearLogoRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBClearLogoRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaLBBannerRadioButton
            // 
            this.relatedMediaLBBannerRadioButton.AutoSize = true;
            this.relatedMediaLBBannerRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBBannerRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBBannerRadioButton.Location = new System.Drawing.Point(173, 66);
            this.relatedMediaLBBannerRadioButton.Name = "relatedMediaLBBannerRadioButton";
            this.relatedMediaLBBannerRadioButton.Size = new System.Drawing.Size(70, 20);
            this.relatedMediaLBBannerRadioButton.TabIndex = 10080;
            this.relatedMediaLBBannerRadioButton.Text = "Banner";
            this.relatedMediaLBBannerRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBBannerRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaLBTitleScreenRadioButton
            // 
            this.relatedMediaLBTitleScreenRadioButton.AutoSize = true;
            this.relatedMediaLBTitleScreenRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBTitleScreenRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBTitleScreenRadioButton.Location = new System.Drawing.Point(173, 92);
            this.relatedMediaLBTitleScreenRadioButton.Name = "relatedMediaLBTitleScreenRadioButton";
            this.relatedMediaLBTitleScreenRadioButton.Size = new System.Drawing.Size(105, 20);
            this.relatedMediaLBTitleScreenRadioButton.TabIndex = 10079;
            this.relatedMediaLBTitleScreenRadioButton.Text = "Title Screen";
            this.relatedMediaLBTitleScreenRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBTitleScreenRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaSetLaunchBoxPathButton
            // 
            this.relatedMediaSetLaunchBoxPathButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.relatedMediaSetLaunchBoxPathButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.relatedMediaSetLaunchBoxPathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.relatedMediaSetLaunchBoxPathButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaSetLaunchBoxPathButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.relatedMediaSetLaunchBoxPathButton.Location = new System.Drawing.Point(202, 3);
            this.relatedMediaSetLaunchBoxPathButton.Margin = new System.Windows.Forms.Padding(0);
            this.relatedMediaSetLaunchBoxPathButton.Name = "relatedMediaSetLaunchBoxPathButton";
            this.relatedMediaSetLaunchBoxPathButton.Size = new System.Drawing.Size(75, 27);
            this.relatedMediaSetLaunchBoxPathButton.TabIndex = 10077;
            this.relatedMediaSetLaunchBoxPathButton.Text = "Set...";
            this.relatedMediaSetLaunchBoxPathButton.UseVisualStyleBackColor = false;
            this.relatedMediaSetLaunchBoxPathButton.Click += new System.EventHandler(this.SetRelatedMediaPathButton_Click);
            // 
            // relatedMediaLBBoxFrontReconRadioButton
            // 
            this.relatedMediaLBBoxFrontReconRadioButton.AutoSize = true;
            this.relatedMediaLBBoxFrontReconRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBBoxFrontReconRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBBoxFrontReconRadioButton.Location = new System.Drawing.Point(7, 118);
            this.relatedMediaLBBoxFrontReconRadioButton.Name = "relatedMediaLBBoxFrontReconRadioButton";
            this.relatedMediaLBBoxFrontReconRadioButton.Size = new System.Drawing.Size(157, 20);
            this.relatedMediaLBBoxFrontReconRadioButton.TabIndex = 10075;
            this.relatedMediaLBBoxFrontReconRadioButton.Text = "Box - Front (Recon)";
            this.relatedMediaLBBoxFrontReconRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBBoxFrontReconRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaLBBoxFrontRadioButton
            // 
            this.relatedMediaLBBoxFrontRadioButton.AutoSize = true;
            this.relatedMediaLBBoxFrontRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBBoxFrontRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBBoxFrontRadioButton.Location = new System.Drawing.Point(7, 40);
            this.relatedMediaLBBoxFrontRadioButton.Name = "relatedMediaLBBoxFrontRadioButton";
            this.relatedMediaLBBoxFrontRadioButton.Size = new System.Drawing.Size(100, 20);
            this.relatedMediaLBBoxFrontRadioButton.TabIndex = 10072;
            this.relatedMediaLBBoxFrontRadioButton.Text = "Box - Front";
            this.relatedMediaLBBoxFrontRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBBoxFrontRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaLBBoxBackRadioButton
            // 
            this.relatedMediaLBBoxBackRadioButton.AutoSize = true;
            this.relatedMediaLBBoxBackRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBBoxBackRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBBoxBackRadioButton.Location = new System.Drawing.Point(7, 66);
            this.relatedMediaLBBoxBackRadioButton.Name = "relatedMediaLBBoxBackRadioButton";
            this.relatedMediaLBBoxBackRadioButton.Size = new System.Drawing.Size(96, 20);
            this.relatedMediaLBBoxBackRadioButton.TabIndex = 10074;
            this.relatedMediaLBBoxBackRadioButton.Text = "Box - Back";
            this.relatedMediaLBBoxBackRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBBoxBackRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaLBBox3DRadioButton
            // 
            this.relatedMediaLBBox3DRadioButton.AutoSize = true;
            this.relatedMediaLBBox3DRadioButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBBox3DRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBBox3DRadioButton.Location = new System.Drawing.Point(7, 92);
            this.relatedMediaLBBox3DRadioButton.Name = "relatedMediaLBBox3DRadioButton";
            this.relatedMediaLBBox3DRadioButton.Size = new System.Drawing.Size(82, 20);
            this.relatedMediaLBBox3DRadioButton.TabIndex = 10073;
            this.relatedMediaLBBox3DRadioButton.Text = "Box - 3D";
            this.relatedMediaLBBox3DRadioButton.UseVisualStyleBackColor = true;
            this.relatedMediaLBBox3DRadioButton.Click += new System.EventHandler(this.RelatedMedia_RadioButtonCheckChanged);
            // 
            // relatedMediaLBLinePictureBox
            // 
            this.relatedMediaLBLinePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBLinePictureBox.Location = new System.Drawing.Point(2, 32);
            this.relatedMediaLBLinePictureBox.Name = "relatedMediaLBLinePictureBox";
            this.relatedMediaLBLinePictureBox.Size = new System.Drawing.Size(275, 2);
            this.relatedMediaLBLinePictureBox.TabIndex = 10071;
            this.relatedMediaLBLinePictureBox.TabStop = false;
            // 
            // relatedMediaLBLabel
            // 
            this.relatedMediaLBLabel.BackColor = System.Drawing.Color.Transparent;
            this.relatedMediaLBLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatedMediaLBLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.relatedMediaLBLabel.Location = new System.Drawing.Point(3, 3);
            this.relatedMediaLBLabel.Name = "relatedMediaLBLabel";
            this.relatedMediaLBLabel.Size = new System.Drawing.Size(196, 26);
            this.relatedMediaLBLabel.TabIndex = 10063;
            this.relatedMediaLBLabel.Text = "LaunchBox";
            // 
            // tabControlExtra1
            // 
            this.tabControlExtra1.Controls.Add(this.focusTabPage);
            this.tabControlExtra1.Controls.Add(this.alertsTabPage2);
            this.tabControlExtra1.Controls.Add(this.userInfoTabPage);
            this.tabControlExtra1.Controls.Add(this.gameInfoTabPage);
            this.tabControlExtra1.Controls.Add(this.gameProgressTabPage);
            this.tabControlExtra1.Controls.Add(this.recentCheevosTabPage);
            this.tabControlExtra1.Controls.Add(this.cheevosListTabPage);
            this.tabControlExtra1.Controls.Add(this.relatedMediaTabPage);
            this.tabControlExtra1.Controls.Add(this.browserTabPage);
            // 
            // 
            // 
            this.tabControlExtra1.DisplayStyleProvider.BlendStyle = TradeWright.UI.Forms.BlendStyle.Normal;
            this.tabControlExtra1.DisplayStyleProvider.BorderColorDisabled = System.Drawing.SystemColors.ControlLight;
            this.tabControlExtra1.DisplayStyleProvider.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.tabControlExtra1.DisplayStyleProvider.BorderColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra1.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra1.DisplayStyleProvider.BorderColorUnselected = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonFillColorFocused = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonFillColorFocusedActive = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonFillColorHighlighted = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonFillColorHighlightedActive = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonFillColorSelected = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonFillColorSelectedActive = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonFillColorUnselected = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonOutlineColorFocused = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonOutlineColorFocusedActive = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonOutlineColorHighlighted = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonOutlineColorHighlightedActive = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonOutlineColorSelected = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonOutlineColorSelectedActive = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserButtonOutlineColorUnselected = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.CloserColorFocused = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra1.DisplayStyleProvider.CloserColorFocusedActive = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra1.DisplayStyleProvider.CloserColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra1.DisplayStyleProvider.CloserColorHighlightedActive = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra1.DisplayStyleProvider.CloserColorSelected = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra1.DisplayStyleProvider.CloserColorSelectedActive = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra1.DisplayStyleProvider.CloserColorUnselected = System.Drawing.Color.Empty;
            this.tabControlExtra1.DisplayStyleProvider.FocusTrack = false;
            this.tabControlExtra1.DisplayStyleProvider.HotTrack = true;
            this.tabControlExtra1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabControlExtra1.DisplayStyleProvider.Opacity = 1F;
            this.tabControlExtra1.DisplayStyleProvider.Overlap = 0;
            this.tabControlExtra1.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.tabControlExtra1.DisplayStyleProvider.PageBackgroundColorDisabled = System.Drawing.SystemColors.Control;
            this.tabControlExtra1.DisplayStyleProvider.PageBackgroundColorFocused = System.Drawing.SystemColors.ControlLight;
            this.tabControlExtra1.DisplayStyleProvider.PageBackgroundColorHighlighted = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.tabControlExtra1.DisplayStyleProvider.PageBackgroundColorSelected = System.Drawing.SystemColors.ControlLightLight;
            this.tabControlExtra1.DisplayStyleProvider.PageBackgroundColorUnselected = System.Drawing.SystemColors.Control;
            this.tabControlExtra1.DisplayStyleProvider.Radius = 2;
            this.tabControlExtra1.DisplayStyleProvider.SelectedTabIsLarger = true;
            this.tabControlExtra1.DisplayStyleProvider.ShowTabCloser = false;
            this.tabControlExtra1.DisplayStyleProvider.TabColorDisabled1 = System.Drawing.SystemColors.Control;
            this.tabControlExtra1.DisplayStyleProvider.TabColorDisabled2 = System.Drawing.SystemColors.Control;
            this.tabControlExtra1.DisplayStyleProvider.TabColorFocused1 = System.Drawing.SystemColors.ControlLight;
            this.tabControlExtra1.DisplayStyleProvider.TabColorFocused2 = System.Drawing.SystemColors.ControlLight;
            this.tabControlExtra1.DisplayStyleProvider.TabColorHighLighted1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.tabControlExtra1.DisplayStyleProvider.TabColorHighLighted2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.tabControlExtra1.DisplayStyleProvider.TabColorSelected1 = System.Drawing.SystemColors.ControlLightLight;
            this.tabControlExtra1.DisplayStyleProvider.TabColorSelected2 = System.Drawing.SystemColors.ControlLightLight;
            this.tabControlExtra1.DisplayStyleProvider.TabColorUnSelected1 = System.Drawing.SystemColors.Control;
            this.tabControlExtra1.DisplayStyleProvider.TabColorUnSelected2 = System.Drawing.SystemColors.Control;
            this.tabControlExtra1.DisplayStyleProvider.TabPageMargin = new System.Windows.Forms.Padding(1);
            this.tabControlExtra1.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra1.DisplayStyleProvider.TextColorFocused = System.Drawing.SystemColors.ControlText;
            this.tabControlExtra1.DisplayStyleProvider.TextColorHighlighted = System.Drawing.SystemColors.ControlText;
            this.tabControlExtra1.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.tabControlExtra1.DisplayStyleProvider.TextColorUnselected = System.Drawing.SystemColors.ControlText;
            this.tabControlExtra1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlExtra1.HotTrack = true;
            this.tabControlExtra1.Location = new System.Drawing.Point(4, 111);
            this.tabControlExtra1.Name = "tabControlExtra1";
            this.tabControlExtra1.SelectedIndex = 0;
            this.tabControlExtra1.ShowToolTips = true;
            this.tabControlExtra1.Size = new System.Drawing.Size(777, 398);
            this.tabControlExtra1.TabIndex = 10033;
            // 
            // focusTabPage
            // 
            this.focusTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.focusTabPage.Controls.Add(this.panel64);
            this.focusTabPage.Controls.Add(this.panel63);
            this.focusTabPage.Controls.Add(this.panel51);
            this.focusTabPage.Location = new System.Drawing.Point(4, 26);
            this.focusTabPage.Name = "focusTabPage";
            this.focusTabPage.Size = new System.Drawing.Size(769, 368);
            this.focusTabPage.TabIndex = 0;
            this.focusTabPage.Text = "Focus";
            // 
            // alertsTabPage2
            // 
            this.alertsTabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.alertsTabPage2.Controls.Add(this.tabControlExtra2);
            this.alertsTabPage2.Controls.Add(this.panel65);
            this.alertsTabPage2.Location = new System.Drawing.Point(4, 26);
            this.alertsTabPage2.Name = "alertsTabPage2";
            this.alertsTabPage2.Size = new System.Drawing.Size(769, 368);
            this.alertsTabPage2.TabIndex = 1;
            this.alertsTabPage2.Text = "Alerts";
            // 
            // tabControlExtra2
            // 
            this.tabControlExtra2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlExtra2.Controls.Add(this.tabPage1);
            this.tabControlExtra2.Controls.Add(this.tabPage2);
            this.tabControlExtra2.Cursor = System.Windows.Forms.Cursors.Arrow;
            // 
            // 
            // 
            this.tabControlExtra2.DisplayStyleProvider.BlendStyle = TradeWright.UI.Forms.BlendStyle.Normal;
            this.tabControlExtra2.DisplayStyleProvider.BorderColorDisabled = System.Drawing.SystemColors.ControlLight;
            this.tabControlExtra2.DisplayStyleProvider.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.tabControlExtra2.DisplayStyleProvider.BorderColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra2.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra2.DisplayStyleProvider.BorderColorUnselected = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonFillColorFocused = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonFillColorFocusedActive = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonFillColorHighlighted = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonFillColorHighlightedActive = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonFillColorSelected = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonFillColorSelectedActive = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonFillColorUnselected = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonOutlineColorFocused = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonOutlineColorFocusedActive = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonOutlineColorHighlighted = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonOutlineColorHighlightedActive = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonOutlineColorSelected = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonOutlineColorSelectedActive = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserButtonOutlineColorUnselected = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.CloserColorFocused = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra2.DisplayStyleProvider.CloserColorFocusedActive = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra2.DisplayStyleProvider.CloserColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra2.DisplayStyleProvider.CloserColorHighlightedActive = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra2.DisplayStyleProvider.CloserColorSelected = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra2.DisplayStyleProvider.CloserColorSelectedActive = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra2.DisplayStyleProvider.CloserColorUnselected = System.Drawing.Color.Empty;
            this.tabControlExtra2.DisplayStyleProvider.FocusTrack = false;
            this.tabControlExtra2.DisplayStyleProvider.HotTrack = true;
            this.tabControlExtra2.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabControlExtra2.DisplayStyleProvider.Opacity = 1F;
            this.tabControlExtra2.DisplayStyleProvider.Overlap = 0;
            this.tabControlExtra2.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.tabControlExtra2.DisplayStyleProvider.PageBackgroundColorDisabled = System.Drawing.SystemColors.Control;
            this.tabControlExtra2.DisplayStyleProvider.PageBackgroundColorFocused = System.Drawing.SystemColors.ControlLight;
            this.tabControlExtra2.DisplayStyleProvider.PageBackgroundColorHighlighted = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.tabControlExtra2.DisplayStyleProvider.PageBackgroundColorSelected = System.Drawing.SystemColors.ControlLightLight;
            this.tabControlExtra2.DisplayStyleProvider.PageBackgroundColorUnselected = System.Drawing.SystemColors.Control;
            this.tabControlExtra2.DisplayStyleProvider.Radius = 2;
            this.tabControlExtra2.DisplayStyleProvider.SelectedTabIsLarger = true;
            this.tabControlExtra2.DisplayStyleProvider.ShowTabCloser = false;
            this.tabControlExtra2.DisplayStyleProvider.TabColorDisabled1 = System.Drawing.SystemColors.Control;
            this.tabControlExtra2.DisplayStyleProvider.TabColorDisabled2 = System.Drawing.SystemColors.Control;
            this.tabControlExtra2.DisplayStyleProvider.TabColorFocused1 = System.Drawing.SystemColors.ControlLight;
            this.tabControlExtra2.DisplayStyleProvider.TabColorFocused2 = System.Drawing.SystemColors.ControlLight;
            this.tabControlExtra2.DisplayStyleProvider.TabColorHighLighted1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.tabControlExtra2.DisplayStyleProvider.TabColorHighLighted2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.tabControlExtra2.DisplayStyleProvider.TabColorSelected1 = System.Drawing.SystemColors.ControlLightLight;
            this.tabControlExtra2.DisplayStyleProvider.TabColorSelected2 = System.Drawing.SystemColors.ControlLightLight;
            this.tabControlExtra2.DisplayStyleProvider.TabColorUnSelected1 = System.Drawing.SystemColors.Control;
            this.tabControlExtra2.DisplayStyleProvider.TabColorUnSelected2 = System.Drawing.SystemColors.Control;
            this.tabControlExtra2.DisplayStyleProvider.TabPageMargin = new System.Windows.Forms.Padding(1);
            this.tabControlExtra2.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.tabControlExtra2.DisplayStyleProvider.TextColorFocused = System.Drawing.SystemColors.ControlText;
            this.tabControlExtra2.DisplayStyleProvider.TextColorHighlighted = System.Drawing.SystemColors.ControlText;
            this.tabControlExtra2.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.tabControlExtra2.DisplayStyleProvider.TextColorUnselected = System.Drawing.SystemColors.ControlText;
            this.tabControlExtra2.HotTrack = true;
            this.tabControlExtra2.Location = new System.Drawing.Point(3, 3);
            this.tabControlExtra2.Name = "tabControlExtra2";
            this.tabControlExtra2.SelectedIndex = 0;
            this.tabControlExtra2.Size = new System.Drawing.Size(292, 362);
            this.tabControlExtra2.TabIndex = 10082;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.tabPage1.Controls.Add(this.alertsCustomAchievementPanel);
            this.tabPage1.Controls.Add(this.alertsAchievementEnableCheckbox);
            this.tabPage1.Controls.Add(this.alertsPlayAchievementButton);
            this.tabPage1.Controls.Add(this.alertsCustomAchievementEnableCheckbox);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(284, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Achievement";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.tabPage2.Controls.Add(this.alertsCustomMasteryPanel);
            this.tabPage2.Controls.Add(this.alertsMasteryEnableCheckbox);
            this.tabPage2.Controls.Add(this.alertsPlayMasteryButton);
            this.tabPage2.Controls.Add(this.alertsCustomMasteryEnableCheckbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(284, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mastery";
            // 
            // userInfoTabPage
            // 
            this.userInfoTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.userInfoTabPage.Controls.Add(this.panel14);
            this.userInfoTabPage.Controls.Add(this.panel21);
            this.userInfoTabPage.Controls.Add(this.panel20);
            this.userInfoTabPage.Location = new System.Drawing.Point(4, 26);
            this.userInfoTabPage.Name = "userInfoTabPage";
            this.userInfoTabPage.Size = new System.Drawing.Size(769, 368);
            this.userInfoTabPage.TabIndex = 2;
            this.userInfoTabPage.Text = "User Info";
            // 
            // gameInfoTabPage
            // 
            this.gameInfoTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameInfoTabPage.Controls.Add(this.panel50);
            this.gameInfoTabPage.Controls.Add(this.panel29);
            this.gameInfoTabPage.Controls.Add(this.panel35);
            this.gameInfoTabPage.Location = new System.Drawing.Point(4, 26);
            this.gameInfoTabPage.Name = "gameInfoTabPage";
            this.gameInfoTabPage.Size = new System.Drawing.Size(769, 368);
            this.gameInfoTabPage.TabIndex = 3;
            this.gameInfoTabPage.Text = "Game Info";
            // 
            // gameProgressTabPage
            // 
            this.gameProgressTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.gameProgressTabPage.Controls.Add(this.panel28);
            this.gameProgressTabPage.Controls.Add(this.panel36);
            this.gameProgressTabPage.Controls.Add(this.panel15);
            this.gameProgressTabPage.Location = new System.Drawing.Point(4, 26);
            this.gameProgressTabPage.Name = "gameProgressTabPage";
            this.gameProgressTabPage.Size = new System.Drawing.Size(769, 368);
            this.gameProgressTabPage.TabIndex = 4;
            this.gameProgressTabPage.Text = "Progress";
            // 
            // recentCheevosTabPage
            // 
            this.recentCheevosTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.recentCheevosTabPage.Controls.Add(this.panel113);
            this.recentCheevosTabPage.Controls.Add(this.panel99);
            this.recentCheevosTabPage.Location = new System.Drawing.Point(4, 26);
            this.recentCheevosTabPage.Name = "recentCheevosTabPage";
            this.recentCheevosTabPage.Size = new System.Drawing.Size(769, 368);
            this.recentCheevosTabPage.TabIndex = 5;
            this.recentCheevosTabPage.Text = "Recent Unlocks";
            // 
            // cheevosListTabPage
            // 
            this.cheevosListTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.cheevosListTabPage.Controls.Add(this.panel115);
            this.cheevosListTabPage.Controls.Add(this.panel111);
            this.cheevosListTabPage.Location = new System.Drawing.Point(4, 26);
            this.cheevosListTabPage.Name = "cheevosListTabPage";
            this.cheevosListTabPage.Size = new System.Drawing.Size(769, 368);
            this.cheevosListTabPage.TabIndex = 6;
            this.cheevosListTabPage.Text = "Achievement List";
            // 
            // relatedMediaTabPage
            // 
            this.relatedMediaTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.relatedMediaTabPage.Controls.Add(this.panel124);
            this.relatedMediaTabPage.Controls.Add(this.panel120);
            this.relatedMediaTabPage.Controls.Add(this.panel121);
            this.relatedMediaTabPage.Location = new System.Drawing.Point(4, 26);
            this.relatedMediaTabPage.Name = "relatedMediaTabPage";
            this.relatedMediaTabPage.Size = new System.Drawing.Size(769, 368);
            this.relatedMediaTabPage.TabIndex = 7;
            this.relatedMediaTabPage.Text = "Related Media";
            // 
            // browserTabPage
            // 
            this.browserTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.browserTabPage.Controls.Add(this.panel126);
            this.browserTabPage.Controls.Add(this.panel125);
            this.browserTabPage.Location = new System.Drawing.Point(4, 26);
            this.browserTabPage.Name = "browserTabPage";
            this.browserTabPage.Size = new System.Drawing.Size(769, 368);
            this.browserTabPage.TabIndex = 8;
            this.browserTabPage.Text = "Browser";
            // 
            // panel126
            // 
            this.panel126.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel126.Controls.Add(this.label95);
            this.panel126.Controls.Add(this.pictureBox27);
            this.panel126.Location = new System.Drawing.Point(299, 3);
            this.panel126.Name = "panel126";
            this.panel126.Size = new System.Drawing.Size(467, 362);
            this.panel126.TabIndex = 10086;
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.Color.Transparent;
            this.label95.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label95.Location = new System.Drawing.Point(3, 3);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(190, 26);
            this.label95.TabIndex = 10069;
            this.label95.Text = "Browser";
            // 
            // pictureBox27
            // 
            this.pictureBox27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox27.Location = new System.Drawing.Point(2, 32);
            this.pictureBox27.Name = "pictureBox27";
            this.pictureBox27.Size = new System.Drawing.Size(460, 2);
            this.pictureBox27.TabIndex = 10070;
            this.pictureBox27.TabStop = false;
            // 
            // panel125
            // 
            this.panel125.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel125.Controls.Add(this.label94);
            this.panel125.Controls.Add(this.rssFeedFriendCheckBox);
            this.panel125.Controls.Add(this.pictureBox26);
            this.panel125.Controls.Add(this.rssFeedNewsCheckBox);
            this.panel125.Controls.Add(this.rssFeedForumCheckBox);
            this.panel125.Controls.Add(this.rssFeedListView);
            this.panel125.Controls.Add(this.rssFeedCheevoCheckBox);
            this.panel125.Location = new System.Drawing.Point(4, 3);
            this.panel125.Name = "panel125";
            this.panel125.Size = new System.Drawing.Size(289, 362);
            this.panel125.TabIndex = 10085;
            // 
            // label94
            // 
            this.label94.BackColor = System.Drawing.Color.Transparent;
            this.label94.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label94.Location = new System.Drawing.Point(3, 3);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(190, 26);
            this.label94.TabIndex = 10069;
            this.label94.Text = "RSS Feed";
            // 
            // pictureBox26
            // 
            this.pictureBox26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.pictureBox26.Location = new System.Drawing.Point(2, 32);
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.Size = new System.Drawing.Size(275, 2);
            this.pictureBox26.TabIndex = 10070;
            this.pictureBox26.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(786, 514);
            this.Controls.Add(this.tabControlExtra1);
            this.Controls.Add(this.raConnectionStatusPictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.timerStatusLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Retro Achievements Tracker";
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.raConnectionStatusPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementScaleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementOutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementOutSpeedUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementInNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomAchievementInSpeedUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryScaleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryOutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryOutSpeedUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryInNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsCustomMasteryInSpeedUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsMaxListNumericUpDown)).EndInit();
            this.panel64.ResumeLayout(false);
            this.panel64.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.panel63.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel51.ResumeLayout(false);
            this.panel51.PerformLayout();
            this.focusLinePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.focusLineColorPictureBox)).EndInit();
            this.panel59.ResumeLayout(false);
            this.panel59.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusBorderColorPictureBox)).EndInit();
            this.focusPointsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontColorPictureBox)).EndInit();
            this.panel52.ResumeLayout(false);
            this.panel52.PerformLayout();
            this.panel61.ResumeLayout(false);
            this.panel61.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontOutlineColorPictureBox)).EndInit();
            this.focusDescriptionOutlinePanel.ResumeLayout(false);
            this.focusDescriptionOutlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontOutlineNumericUpDown)).EndInit();
            this.focusDescriptionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.panel54.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.focusBackgroundColorPictureBox)).EndInit();
            this.panel55.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontColorPictureBox)).EndInit();
            this.focusPointsOutlinePanel.ResumeLayout(false);
            this.focusPointsOutlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontOutlineColorPictureBox)).EndInit();
            this.focusLineOutlinePanel.ResumeLayout(false);
            this.focusLineOutlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusLineOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusLineOutlineNumericUpDown)).EndInit();
            this.panel65.ResumeLayout(false);
            this.panel65.PerformLayout();
            this.alertsLinePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alertsLineColorPictureBox)).EndInit();
            this.panel67.ResumeLayout(false);
            this.panel67.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsBorderColorPictureBox)).EndInit();
            this.alertsPointsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alertsPointsFontColorPictureBox)).EndInit();
            this.panel69.ResumeLayout(false);
            this.panel69.PerformLayout();
            this.panel70.ResumeLayout(false);
            this.panel70.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsTitleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsTitleFontOutlineColorPictureBox)).EndInit();
            this.alertsDescriptionOutlinePanel.ResumeLayout(false);
            this.alertsDescriptionOutlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsDescriptionFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsDescriptionFontOutlineNumericUpDown)).EndInit();
            this.alertsDescriptionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alertsDescriptionFontColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            this.panel73.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alertsBackgroundColorPictureBox)).EndInit();
            this.panel74.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alertsTitleFontColorPictureBox)).EndInit();
            this.alertsPointsOutlinePanel.ResumeLayout(false);
            this.alertsPointsOutlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsPointsFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsPointsFontOutlineColorPictureBox)).EndInit();
            this.alertsLineOutlinePanel.ResumeLayout(false);
            this.alertsLineOutlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertsLineOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsLineOutlineNumericUpDown)).EndInit();
            this.alertsCustomAchievementPanel.ResumeLayout(false);
            this.alertsCustomAchievementPanel.PerformLayout();
            this.panel85.ResumeLayout(false);
            this.panel84.ResumeLayout(false);
            this.panel86.ResumeLayout(false);
            this.panel83.ResumeLayout(false);
            this.panel87.ResumeLayout(false);
            this.panel78.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            this.panel79.ResumeLayout(false);
            this.panel80.ResumeLayout(false);
            this.panel81.ResumeLayout(false);
            this.panel82.ResumeLayout(false);
            this.alertsCustomMasteryPanel.ResumeLayout(false);
            this.alertsCustomMasteryPanel.PerformLayout();
            this.panel89.ResumeLayout(false);
            this.panel90.ResumeLayout(false);
            this.panel91.ResumeLayout(false);
            this.panel92.ResumeLayout(false);
            this.panel93.ResumeLayout(false);
            this.panel94.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.panel95.ResumeLayout(false);
            this.panel96.ResumeLayout(false);
            this.panel97.ResumeLayout(false);
            this.panel98.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel21.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.userInfoValuesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBackgroundColorPictureBox)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontColorPictureBox)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontOutlineColorPictureBox)).EndInit();
            this.userInfoValuesOutlinePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontOutlineNumericUpDown)).EndInit();
            this.panel50.ResumeLayout(false);
            this.panel119.ResumeLayout(false);
            this.panel117.ResumeLayout(false);
            this.panel118.ResumeLayout(false);
            this.panel116.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panel29.ResumeLayout(false);
            this.panel49.ResumeLayout(false);
            this.panel49.PerformLayout();
            this.panel48.ResumeLayout(false);
            this.panel48.PerformLayout();
            this.panel30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.panel33.ResumeLayout(false);
            this.panel33.PerformLayout();
            this.panel34.ResumeLayout(false);
            this.panel34.PerformLayout();
            this.panel35.ResumeLayout(false);
            this.panel35.PerformLayout();
            this.panel42.ResumeLayout(false);
            this.panel42.PerformLayout();
            this.gameInfoValuesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panel44.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoBackgroundColorPictureBox)).EndInit();
            this.panel45.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontColorPictureBox)).EndInit();
            this.panel46.ResumeLayout(false);
            this.panel46.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontOutlineColorPictureBox)).EndInit();
            this.gameInfoValuesOutlinePanel.ResumeLayout(false);
            this.gameInfoValuesOutlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontOutlineNumericUpDown)).EndInit();
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressPercentCompletePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressMasteryPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.gameProgressValuesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressBackgroundColorPictureBox)).EndInit();
            this.panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontColorPictureBox)).EndInit();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontOutlineColorPictureBox)).EndInit();
            this.gameProgressValuesOutlinePanel.ResumeLayout(false);
            this.gameProgressValuesOutlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontOutlineNumericUpDown)).EndInit();
            this.panel36.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.panel37.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            this.panel38.ResumeLayout(false);
            this.panel38.PerformLayout();
            this.panel39.ResumeLayout(false);
            this.panel39.PerformLayout();
            this.panel40.ResumeLayout(false);
            this.panel40.PerformLayout();
            this.panel41.ResumeLayout(false);
            this.panel41.PerformLayout();
            this.panel113.ResumeLayout(false);
            this.panel113.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.panel99.ResumeLayout(false);
            this.panel99.PerformLayout();
            this.recentAchievementsLinePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineColorPictureBox)).EndInit();
            this.panel101.ResumeLayout(false);
            this.panel101.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsBorderColorPictureBox)).EndInit();
            this.recentAchievementsPointsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontColorPictureBox)).EndInit();
            this.panel103.ResumeLayout(false);
            this.panel103.PerformLayout();
            this.panel104.ResumeLayout(false);
            this.panel104.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontOutlineColorPictureBox)).EndInit();
            this.recentAchievementsDescriptionOutlinePanel.ResumeLayout(false);
            this.recentAchievementsDescriptionOutlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDateFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDescriptionFontOutlineNumericUpDown)).EndInit();
            this.recentAchievementsDescriptionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDateFontColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).EndInit();
            this.panel107.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsBackgroundColorPictureBox)).EndInit();
            this.panel108.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontColorPictureBox)).EndInit();
            this.recentAchievementsPointsOutlinePanel.ResumeLayout(false);
            this.recentAchievementsPointsOutlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontOutlineColorPictureBox)).EndInit();
            this.recentAchievementsLineOutlinePanel.ResumeLayout(false);
            this.recentAchievementsLineOutlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineOutlineNumericUpDown)).EndInit();
            this.panel115.ResumeLayout(false);
            this.panel115.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            this.panel111.ResumeLayout(false);
            this.panel111.PerformLayout();
            this.panel112.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            this.panel114.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.achievementListBackgroundColorPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel120.ResumeLayout(false);
            this.panel120.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            this.panel121.ResumeLayout(false);
            this.panel121.PerformLayout();
            this.panel122.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            this.panel123.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.relatedMediaBackgroundColorPictureBox)).EndInit();
            this.panel124.ResumeLayout(false);
            this.panel124.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.relatedMediaLBLinePictureBox)).EndInit();
            this.tabControlExtra1.ResumeLayout(false);
            this.focusTabPage.ResumeLayout(false);
            this.alertsTabPage2.ResumeLayout(false);
            this.tabControlExtra2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.userInfoTabPage.ResumeLayout(false);
            this.gameInfoTabPage.ResumeLayout(false);
            this.gameProgressTabPage.ResumeLayout(false);
            this.recentCheevosTabPage.ResumeLayout(false);
            this.cheevosListTabPage.ResumeLayout(false);
            this.relatedMediaTabPage.ResumeLayout(false);
            this.browserTabPage.ResumeLayout(false);
            this.panel126.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).EndInit();
            this.panel125.ResumeLayout(false);
            this.panel125.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
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
        private CheckBox autoStartCheckbox;
        private CheckBox userInfoAutoOpenWindowCheckbox;
        private Button userInfoOpenWindowButton;
        private Label timerStatusLabel;
        private PictureBox raConnectionStatusPictureBox;
        private TextBox userInfoTruePointsTextBox;
        private TextBox userInfoPointsTextBox;
        private TextBox userInfoRatioTextBox;
        private TextBox userInfoRankTextBox;
        private OpenFileDialog openFileDialog1;
        private ColorDialog colorDialog1;
        private Button userInfoDefaultButton;
        private Button alertsPlayAchievementButton;
        private CheckBox alertsCustomAchievementEnableCheckbox;
        private Button alertsSelectCustomAchievementFileButton;
        private CheckBox alertsAchievementEditOutlineCheckbox;
        private NumericUpDown alertsCustomAchievementScaleNumericUpDown;
        private NumericUpDown alertsCustomAchievementYNumericUpDown;
        private ComboBox alertsCustomAchievementAnimationInComboBox;
        private NumericUpDown alertsCustomAchievementInSpeedUpDown;
        private ComboBox alertsCustomAchievementAnimationOutComboBox;
        private NumericUpDown alertsCustomAchievementOutSpeedUpDown;
        private NumericUpDown alertsCustomMasteryScaleNumericUpDown;
        private NumericUpDown alertsCustomMasteryYNumericUpDown;
        private CheckBox alertsMasteryEditOutlineCheckbox;
        private ComboBox alertsCustomMasteryAnimationOutComboBox;
        private NumericUpDown alertsCustomMasteryOutSpeedUpDown;
        private ComboBox alertsCustomMasteryAnimationInComboBox;
        private NumericUpDown alertsCustomMasteryInSpeedUpDown;
        private CheckBox alertsCustomMasteryEnableCheckbox;
        private Button alertsSelectCustomMasteryFileButton;
        private Button alertsPlayMasteryButton;
        private CheckBox userInfoTruePointsCheckBox;
        private CheckBox userInfoRatioCheckBox;
        private CheckBox userInfoPointsCheckBox;
        private CheckBox userInfoRankCheckBox;
        private PictureBox gameInfoPictureBox;
        private ListView rssFeedListView;
        private CheckBox rssFeedNewsCheckBox;
        private CheckBox rssFeedCheevoCheckBox;
        private CheckBox rssFeedFriendCheckBox;
        private CheckBox rssFeedForumCheckBox;
        private ColumnHeader columnHeader1;
        private Label recentAchievementsMaxListLabel;
        private NumericUpDown recentAchievementsMaxListNumericUpDown;
        private RadioButton focusBehaviorGoToLastRadioButton;
        private RadioButton focusBehaviorGoToNextRadioButton;
        private RadioButton focusBehaviorGoToPreviousRadioButton;
        private RadioButton focusBehaviorGoToFirstRadioButton;
        private PictureBox focusAchievementPictureBox;
        private Label focusAchievementTitleLabel;
        private Label focusAchievementDescriptionLabel;
        private Button focusSetButton;
        private Button focusAchievementButtonPrevious;
        private Button focusAchievementButtonNext;
        private NumericUpDown alertsCustomAchievementXNumericUpDown;
        private NumericUpDown alertsCustomAchievementOutNumericUpDown;
        private NumericUpDown alertsCustomAchievementInNumericUpDown;
        private NumericUpDown alertsCustomMasteryXNumericUpDown;
        private NumericUpDown alertsCustomMasteryOutNumericUpDown;
        private NumericUpDown alertsCustomMasteryInNumericUpDown;
        private PictureBox userInfoBackgroundColorPictureBox;
        private PictureBox userInfoNamesFontOutlineColorPictureBox;
        private CheckBox userInfoNamesOutlineCheckBox;
        private NumericUpDown userInfoNamesFontOutlineNumericUpDown;
        private PictureBox userInfoNamesFontColorPictureBox;
        private ComboBox userInfoNamesFontComboBox;
        private PictureBox userInfoValuesFontOutlineColorPictureBox;
        private CheckBox userInfoValuesOutlineCheckBox;
        private NumericUpDown userInfoValuesFontOutlineNumericUpDown;
        private PictureBox userInfoValuesFontColorPictureBox;
        private ComboBox userInfoValuesFontComboBox;
        private CheckBox recentAchievementsAutoScrollCheckBox;
        private CheckBox userInfoAdvancedCheckBox;
        private Label userInfoRatioLabel;
        private Label userInfoTruePointsLabel;
        private Label userInfoPointsLabel;
        private Label userInfoRankLabel;
        private Label gameProgressTruePoints1Label;
        private Label gameProgressPoints1Label;
        private Label gameProgressAchievements1Label;
        private Label gameInfoReleasedLabel;
        private Label gameInfoGenreLabel;
        private Label gameInfoPublisherLabel;
        private Label gameInfoDeveloperLabel;
        private CheckBox alertsAchievementEnableCheckbox;
        private CheckBox alertsMasteryEnableCheckbox;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label userInfoUsernameLabel;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label2;
        private Panel panel6;
        private Label userInfoNamesLabel;
        private Label label4;
        private Panel panel5;
        private Label label3;
        private Panel userInfoValuesOutlinePanel;
        private Label label27;
        private Panel userInfoValuesPanel;
        private Label label26;
        private Label label25;
        private Label label15;
        private Panel panel7;
        private Label userInfoNamesOutlineLabel;
        private Label label9;
        private Label label32;
        private Label label30;
        private Label label29;
        private Panel panel10;
        private Label label31;
        private PictureBox pictureBox4;
        private Label label28;
        private Panel panel12;
        private Panel panel11;
        private Label label33;
        private Label label34;
        private Panel panel13;
        private Label label35;
        private Label userInfoMottoLabel;
        private Label label37;
        private Panel panel4;
        private Panel panel20;
        private Panel panel21;
        private Panel panel22;
        private Panel panel36;
        private Panel panel37;
        private Label label39;
        private Label label40;
        private Label label72;
        private Label label73;
        private Button gameProgressDefaultButton;
        private PictureBox pictureBox17;
        private Panel panel38;
        private Label label74;
        private CheckBox gameProgressAchievementsCheckBox;
        private TextBox gameProgressAchievementsTextBox;
        private Panel panel39;
        private Label label75;
        private CheckBox gameProgressRatioCheckBox;
        private TextBox gameProgressRatioTextBox;
        private Panel panel40;
        private Label label76;
        private TextBox gameProgressTruePointsTextBox;
        private CheckBox gameProgressTruePointsCheckBox;
        private Panel panel41;
        private Label label77;
        private TextBox gameProgressPointsTextBox;
        private CheckBox gameProgressPointsCheckBox;
        private Panel panel14;
        private Panel panel15;
        private Label label38;
        private Panel panel16;
        private CheckBox gameProgressAdvancedCheckBox;
        private Label label41;
        private Label label43;
        private Label label44;
        private Label label45;
        private Button gameProgressOpenWindowButton;
        private Panel gameProgressValuesPanel;
        private Label label46;
        private PictureBox gameProgressValuesFontColorPictureBox;
        private ComboBox gameProgressValuesFontComboBox;
        private CheckBox gameProgressAutoOpenWindowCheckbox;
        private PictureBox pictureBox6;
        private Panel panel18;
        private PictureBox gameProgressBackgroundColorPictureBox;
        private Label label47;
        private Panel panel19;
        private Label gameProgressNamesLabel;
        private PictureBox gameProgressNamesFontColorPictureBox;
        private ComboBox gameProgressNamesFontComboBox;
        private Panel panel23;
        private NumericUpDown gameProgressNamesFontOutlineNumericUpDown;
        private CheckBox gameProgressNamesOutlineCheckBox;
        private Label gameProgressNamesOutlineLabel;
        private PictureBox gameProgressNamesFontOutlineColorPictureBox;
        private Panel gameProgressValuesOutlinePanel;
        private Label label50;
        private PictureBox gameProgressValuesFontOutlineColorPictureBox;
        private NumericUpDown gameProgressValuesFontOutlineNumericUpDown;
        private CheckBox gameProgressValuesOutlineCheckBox;
        private Panel panel26;
        private Label label52;
        private TextBox gameProgressCompletedTextBox;
        private CheckBox gameProgressCompletedCheckBox;
        private Panel panel28;
        private Label label56;
        private PictureBox pictureBox5;
        private Panel panel27;
        private Label label55;
        private RadioButton gameProgressRadioButtonPeriod;
        private Label label54;
        private RadioButton gameProgressRadioButtonColon;
        private Label label53;
        private RadioButton gameProgressRadioButtonBackslash;
        private Label label51;
        private Panel panel25;
        private Panel panel29;
        private Panel panel48;
        private Label label87;
        private CheckBox gameInfoGenreCheckBox;
        private TextBox gameInfoGenreTextBox;
        private Panel panel30;
        private Label label63;
        private Label label64;
        private Label label65;
        private Label label66;
        private Button gameInfoDefaultButton;
        private PictureBox pictureBox7;
        private Panel panel31;
        private Label label67;
        private CheckBox gameInfoTitleCheckBox;
        private TextBox gameInfoTitleTextBox;
        private Panel panel32;
        private Label label68;
        private CheckBox gameInfoConsoleCheckBox;
        private TextBox gameInfoConsoleTextBox;
        private Panel panel33;
        private Label label69;
        private TextBox gameInfoPublisherTextBox;
        private CheckBox gameInfoPublisherCheckBox;
        private Panel panel34;
        private Label label70;
        private TextBox gameInfoDeveloperTextBox;
        private CheckBox gameInfoDeveloperCheckBox;
        private Panel panel35;
        private Label label71;
        private Panel panel42;
        private CheckBox gameInfoAdvancedCheckBox;
        private Label label78;
        private Label label79;
        private Label label80;
        private Label label81;
        private Button gameInfoOpenWindowButton;
        private Panel gameInfoValuesPanel;
        private Label label82;
        private PictureBox gameInfoValuesFontColorPictureBox;
        private ComboBox gameInfoValuesFontComboBox;
        private CheckBox gameInfoAutoOpenWindowCheckbox;
        private PictureBox pictureBox9;
        private Panel panel44;
        private PictureBox gameInfoBackgroundColorPictureBox;
        private Label label83;
        private Panel panel45;
        private Label gameInfoNamesLabel;
        private PictureBox gameInfoNamesFontColorPictureBox;
        private ComboBox gameInfoNamesFontComboBox;
        private Panel panel46;
        private NumericUpDown gameInfoNamesFontOutlineNumericUpDown;
        private CheckBox gameInfoNamesOutlineCheckBox;
        private Label gameInfoNamesOutlineLabel;
        private PictureBox gameInfoNamesFontOutlineColorPictureBox;
        private Panel gameInfoValuesOutlinePanel;
        private Label label86;
        private PictureBox gameInfoValuesFontOutlineColorPictureBox;
        private NumericUpDown gameInfoValuesFontOutlineNumericUpDown;
        private CheckBox gameInfoValuesOutlineCheckBox;
        private Panel panel49;
        private Label label88;
        private CheckBox gameInfoReleasedCheckBox;
        private TextBox gameInfoReleaseDateTextBox;
        private Panel panel51;
        private Panel focusLinePanel;
        private Label label106;
        private PictureBox focusLineColorPictureBox;
        private Label label96;
        private Panel panel59;
        private PictureBox focusBorderColorPictureBox;
        private Label label107;
        private Panel focusPointsPanel;
        private Label label108;
        private PictureBox focusPointsFontColorPictureBox;
        private ComboBox focusPointsFontComboBox;
        private Panel panel52;
        private CheckBox focusAdvancedCheckBox;
        private Label label97;
        private Label label98;
        private Label label99;
        private Label label100;
        private Panel panel61;
        private NumericUpDown focusTitleFontOutlineNumericUpDown;
        private CheckBox focusTitleOutlineCheckBox;
        private Label focusTitleOutlineLabel;
        private PictureBox focusTitleFontOutlineColorPictureBox;
        private Button focusOpenWindowButton;
        private Panel focusDescriptionOutlinePanel;
        private Label label110;
        private PictureBox focusDescriptionFontOutlineColorPictureBox;
        private NumericUpDown focusDescriptionFontOutlineNumericUpDown;
        private CheckBox focusDescriptionOutlineCheckBox;
        private Panel focusDescriptionPanel;
        private Label label101;
        private PictureBox focusDescriptionFontColorPictureBox;
        private ComboBox focusDescriptionFontComboBox;
        private CheckBox focusAutoOpenWindowCheckBox;
        private PictureBox pictureBox11;
        private Panel panel54;
        private PictureBox focusBackgroundColorPictureBox;
        private Label label102;
        private Panel panel55;
        private Label focusTitleLabel;
        private PictureBox focusTitleFontColorPictureBox;
        private ComboBox focusTitleFontComboBox;
        private Panel focusPointsOutlinePanel;
        private NumericUpDown focusPointsFontOutlineNumericUpDown;
        private CheckBox focusPointsOutlineCheckBox;
        private Label label104;
        private PictureBox focusPointsFontOutlineColorPictureBox;
        private Panel focusLineOutlinePanel;
        private Label label105;
        private PictureBox focusLineOutlineColorPictureBox;
        private NumericUpDown focusLineOutlineNumericUpDown;
        private CheckBox focusLineOutlineCheckBox;
        private Panel panel50;
        private Label gameInfoTitleLabel;
        private PictureBox pictureBox8;
        private CheckBox focusBorderCheckBox;
        private Panel panel63;
        private Label label111;
        private PictureBox pictureBox10;
        private Panel panel64;
        private Label label112;
        private PictureBox pictureBox12;
        private Panel panel65;
        private Panel alertsLinePanel;
        private Label label113;
        private PictureBox alertsLineColorPictureBox;
        private Label label114;
        private Panel panel67;
        private CheckBox alertsBorderCheckBox;
        private PictureBox alertsBorderColorPictureBox;
        private Label label115;
        private Panel alertsPointsPanel;
        private Label label116;
        private PictureBox alertsPointsFontColorPictureBox;
        private ComboBox alertsPointsFontComboBox;
        private Panel panel69;
        private CheckBox alertsAdvancedCheckBox;
        private Label label117;
        private Label label118;
        private Label label119;
        private Label label120;
        private Panel panel70;
        private NumericUpDown alertsTitleFontOutlineNumericUpDown;
        private CheckBox alertsTitleOutlineCheckBox;
        private Label alertsTitleOutlineLabel;
        private PictureBox alertsTitleFontOutlineColorPictureBox;
        private Button notificationsOpenWindowButton;
        private Panel alertsDescriptionOutlinePanel;
        private Label label122;
        private PictureBox alertsDescriptionFontOutlineColorPictureBox;
        private NumericUpDown alertsDescriptionFontOutlineNumericUpDown;
        private CheckBox alertsDescriptionOutlineCheckBox;
        private Panel alertsDescriptionPanel;
        private Label label123;
        private PictureBox alertsDescriptionFontColorPictureBox;
        private ComboBox alertsDescriptionFontComboBox;
        private CheckBox alertsAutoOpenWindowCheckbox;
        private PictureBox pictureBox20;
        private Panel panel73;
        private PictureBox alertsBackgroundColorPictureBox;
        private Label label124;
        private Panel panel74;
        private Label alertsTitleLabel;
        private PictureBox alertsTitleFontColorPictureBox;
        private ComboBox alertsTitleFontComboBox;
        private Panel alertsPointsOutlinePanel;
        private NumericUpDown alertsPointsFontOutlineNumericUpDown;
        private CheckBox alertsPointsOutlineCheckBox;
        private Label label126;
        private PictureBox alertsPointsFontOutlineColorPictureBox;
        private Panel alertsLineOutlinePanel;
        private Label label127;
        private PictureBox alertsLineOutlineColorPictureBox;
        private NumericUpDown alertsLineOutlineNumericUpDown;
        private CheckBox alertsLineOutlineCheckBox;
        private Panel alertsCustomAchievementPanel;
        private Panel panel84;
        private Label label135;
        private Panel panel83;
        private Label label129;
        private Panel panel78;
        private Label label42;
        private Label label128;
        private Label label130;
        private PictureBox pictureBox13;
        private Panel panel79;
        private Label label131;
        private Panel panel80;
        private Label label132;
        private Panel panel81;
        private Label label133;
        private Panel panel82;
        private Label label134;
        private Panel panel85;
        private Label label136;
        private Panel panel86;
        private Label label137;
        private Panel panel87;
        private Label label138;
        private Panel alertsCustomMasteryPanel;
        private Panel panel89;
        private Label label6;
        private Panel panel90;
        private Label label7;
        private Panel panel91;
        private Label label8;
        private Panel panel92;
        private Label label11;
        private Panel panel93;
        private Label label12;
        private Panel panel94;
        private Label label13;
        private Label label14;
        private Label label139;
        private PictureBox pictureBox14;
        private Panel panel95;
        private Label label140;
        private Panel panel96;
        private Label label141;
        private Panel panel97;
        private Label label142;
        private Panel panel98;
        private Label label143;
        private Panel panel99;
        private Panel recentAchievementsLinePanel;
        private Label label16;
        private PictureBox recentAchievementsLineColorPictureBox;
        private Label label17;
        private Panel panel101;
        private CheckBox recentAchievementsBorderCheckBox;
        private PictureBox recentAchievementsBorderColorPictureBox;
        private Label label18;
        private Panel recentAchievementsPointsPanel;
        private Label label19;
        private PictureBox recentAchievementsPointsFontColorPictureBox;
        private ComboBox recentAchievementsPointsFontComboBox;
        private Panel panel103;
        private CheckBox recentAchievementsAdvancedCheckBox;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Panel panel104;
        private NumericUpDown recentAchievementsTitleFontOutlineNumericUpDown;
        private CheckBox recentAchievementsTitleFontOutlineCheckBox;
        private Label recentAchievementsTitleOutlineLabel;
        private PictureBox recentAchievementsTitleFontOutlineColorPictureBox;
        private Button recentAchievementsOpenWindowButton;
        private Panel recentAchievementsDescriptionOutlinePanel;
        private Label label144;
        private PictureBox recentAchievementsDateFontOutlineColorPictureBox;
        private NumericUpDown recentAchievementsDescriptionFontOutlineNumericUpDown;
        private CheckBox recentAchievementsDateFontOutlineCheckBox;
        private Panel recentAchievementsDescriptionPanel;
        private Label label145;
        private PictureBox recentAchievementsDateFontColorPictureBox;
        private ComboBox recentAchievementsDescriptionFontComboBox;
        private CheckBox recentAchievementsAutoOpenWindowCheckbox;
        private PictureBox pictureBox23;
        private Panel panel107;
        private PictureBox recentAchievementsBackgroundColorPictureBox;
        private Label label146;
        private Panel panel108;
        private Label recentAchievementsTitleLabel;
        private PictureBox recentAchievementsTitleFontColorPictureBox;
        private ComboBox recentAchievementsTitleFontComboBox;
        private Panel recentAchievementsPointsOutlinePanel;
        private NumericUpDown recentAchievementsPointsFontOutlineNumericUpDown;
        private CheckBox recentAchievementsPointsFontOutlineCheckBox;
        private Label label148;
        private PictureBox recentAchievementsPointsFontOutlineColorPictureBox;
        private Panel recentAchievementsLineOutlinePanel;
        private Label label149;
        private PictureBox recentAchievementsLineOutlineColorPictureBox;
        private NumericUpDown recentAchievementsLineOutlineNumericUpDown;
        private CheckBox recentAchievementsLineOutlineCheckBox;
        private Panel panel111;
        private Label label150;
        private Panel panel112;
        private Label label151;
        private Button achievementListOpenWindowButton;
        private CheckBox achievementListAutoOpenWindowCheckbox;
        private PictureBox pictureBox16;
        private Panel panel114;
        private PictureBox achievementListBackgroundColorPictureBox;
        private Label label156;
        private Panel panel113;
        private Label label155;
        private PictureBox pictureBox15;
        private Panel panel115;
        private Label label152;
        private PictureBox pictureBox18;
        private CheckBox achievementListAutoScrollCheckBox;
        private Label label89;
        private Label label62;
        private Label label61;
        private Label label57;
        private Label gameProgressCompletedLabel;
        private Label label60;
        private Label label59;
        private Label label58;
        private PictureBox pictureBox21;
        private PictureBox gameProgressPercentCompletePictureBox;
        private PictureBox gameProgressMasteryPictureBox;
        private Panel panel119;
        private Label label36;
        private Panel panel117;
        private Panel panel118;
        private Panel panel116;
        private Panel panel120;
        private Label label1;
        private Panel panel121;
        private Label label90;
        private Panel panel122;
        private Label label91;
        private Button relatedMediaOpenWindowButton;
        private CheckBox relatedMediaAutoOpenWindowCheckbox;
        private PictureBox pictureBox22;
        private Panel panel123;
        private PictureBox relatedMediaBackgroundColorPictureBox;
        private Label label92;
        private PictureBox pictureBox19;
        private RadioButton relatedMediaRAScreenshotRadioButton;
        private RadioButton relatedMediaRABadgeIconRadioButton;
        private RadioButton relatedMediaRABoxArtRadioButton;
        private RadioButton relatedMediaRATitleScreenRadioButton;
        private Panel panel124;
        private RadioButton relatedMediaLBBoxFrontReconRadioButton;
        private RadioButton relatedMediaLBBoxFrontRadioButton;
        private RadioButton relatedMediaLBBoxBackRadioButton;
        private RadioButton relatedMediaLBBox3DRadioButton;
        private PictureBox relatedMediaLBLinePictureBox;
        private Label relatedMediaLBLabel;
        private TradeWright.UI.Forms.TabControlExtra tabControlExtra1;
        private TabPage focusTabPage;
        private TabPage alertsTabPage2;
        private TabPage userInfoTabPage;
        private TabPage gameInfoTabPage;
        private TabPage gameProgressTabPage;
        private TabPage recentCheevosTabPage;
        private TabPage cheevosListTabPage;
        private TabPage relatedMediaTabPage;
        private TabPage browserTabPage;
        private TradeWright.UI.Forms.TabControlExtra tabControlExtra2;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel125;
        private Label label94;
        private PictureBox pictureBox26;
        private Panel panel126;
        private Label label95;
        private PictureBox pictureBox27;
        private Button relatedMediaSetLaunchBoxPathButton;
        private RadioButton relatedMediaLBCartFrontRadioButton;
        private RadioButton relatedMediaLBCartBackRadioButton;
        private RadioButton relatedMediaLBBoxBackReconRadioButton;
        private RadioButton relatedMediaLBBoxFullRadioButton;
        private RadioButton relatedMediaLBBoxSpineRadioButton;
        private RadioButton relatedMediaLBClearLogoRadioButton;
        private RadioButton relatedMediaLBBannerRadioButton;
        private RadioButton relatedMediaLBTitleScreenRadioButton;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label gameProgressHaveEarnedLabel;
        private Label gameProgressAchievements2Label;
        private Label gameProgressPointsTextLabel;
        private Label gameProgressHardcoreWorthLabel;
        private Label gameProgressPoints2Label;
        private Label gameProgressTruePoints2Label;
    }
}

