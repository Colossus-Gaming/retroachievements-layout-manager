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
            this.focusAutoOpenWindowCheckBox = new System.Windows.Forms.CheckBox();
            this.focusOpenWindowButton = new System.Windows.Forms.Button();
            this.gameInfoPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoTitleLabel = new System.Windows.Forms.Label();
            this.rssFeedFriendCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedCheevoCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedNewsCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedForumCheckBox = new System.Windows.Forms.CheckBox();
            this.rssFeedListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.raConnectionStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.notificationsOpenWindowButton = new System.Windows.Forms.Button();
            this.playAchievementButton = new System.Windows.Forms.Button();
            this.selectCustomAchievementFileButton = new System.Windows.Forms.Button();
            this.achievementPositionGroupBox = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.notificationsCustomAchievementScaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.xPositionLabel1 = new System.Windows.Forms.Label();
            this.yPositionLabel1 = new System.Windows.Forms.Label();
            this.notificationsCustomAchievementXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsCustomAchievementYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.acheivementEditOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.achievementOutAnimationGroupBox = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.notificationsCustomAchievementOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsCustomAchievementAnimationOutComboBox = new System.Windows.Forms.ComboBox();
            this.notificationsCustomAchievementOutSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.achievementInAnimationGroupBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.notificationsCustomAchievementInNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsCustomAchievementAnimationInComboBox = new System.Windows.Forms.ComboBox();
            this.notificationsCustomAchievementInSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.customAchievementEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.playMasteryButton = new System.Windows.Forms.Button();
            this.selectCustomMasteryFileButton = new System.Windows.Forms.Button();
            this.masteryPositionGroupBox = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.notificationsCustomMasteryScaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.notificationsCustomMasteryXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsCustomMasteryYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.masteryEditOultineCheckbox = new System.Windows.Forms.CheckBox();
            this.masteryOutAnimationGroupBox = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.notificationsCustomMasteryOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsCustomMasteryAnimationOutComboBox = new System.Windows.Forms.ComboBox();
            this.notificationsCustomMasteryOutSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.masteryInAnimationGroupBox = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.notificationsCustomMasteryInNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsCustomMasteryAnimationInComboBox = new System.Windows.Forms.ComboBox();
            this.notificationsCustomMasteryInSpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.customMasteryEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.gameInfoAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.gameInfoOpenWindowButton = new System.Windows.Forms.Button();
            this.recentAchievementsAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsOpenWindowButton = new System.Windows.Forms.Button();
            this.gameProgressRatioTextBox = new System.Windows.Forms.TextBox();
            this.userInfoTruePointsTextBox = new System.Windows.Forms.TextBox();
            this.userInfoPointsTextBox = new System.Windows.Forms.TextBox();
            this.userInfoRatioTextBox = new System.Windows.Forms.TextBox();
            this.userInfoRankTextBox = new System.Windows.Forms.TextBox();
            this.userInfoTruePointsCheckBox = new System.Windows.Forms.CheckBox();
            this.userInfoRatioCheckBox = new System.Windows.Forms.CheckBox();
            this.userInfoPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.userInfoDefaultButton = new System.Windows.Forms.Button();
            this.userInfoRankCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.gameProgressRadioButtonBackslash = new System.Windows.Forms.RadioButton();
            this.gameProgressRadioButtonSemicolon = new System.Windows.Forms.RadioButton();
            this.gameProgressRadioButtonDot = new System.Windows.Forms.RadioButton();
            this.gameProgressRatioCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressTruePointsCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressCompletedCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressAchievementsCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressDefaultButton = new System.Windows.Forms.Button();
            this.gameProgressAchievementsTextBox = new System.Windows.Forms.TextBox();
            this.gameProgressPointsTextBox = new System.Windows.Forms.TextBox();
            this.gameProgressTruePointsTextBox = new System.Windows.Forms.TextBox();
            this.gameProgressCompletedTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoReleasedCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoConsoleCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoPublisherCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoGenreCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoDeveloperCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoTitleTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoDefaultButton = new System.Windows.Forms.Button();
            this.gameInfoGenreTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoConsoleTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoPublisherTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoReleaseDateTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoDeveloperTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.gameInfoBackgroundColorGroupBox = new System.Windows.Forms.GroupBox();
            this.gameInfoSetBackgroundColorButton = new System.Windows.Forms.Button();
            this.gameInfoBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoValuesGroupBox = new System.Windows.Forms.GroupBox();
            this.gameInfoValuesFontOutlineColorBoxButton = new System.Windows.Forms.Button();
            this.gameInfoValuesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoValuesFontColorBoxButton = new System.Windows.Forms.Button();
            this.gameInfoValuesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoValuesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameInfoValuesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoValuesFontComboBox = new System.Windows.Forms.ComboBox();
            this.gameInfoNamesGroupBox = new System.Windows.Forms.GroupBox();
            this.gameInfoNamesFontOutlineColorBoxButton = new System.Windows.Forms.Button();
            this.gameInfoNamesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoNamesFontColorBoxButton = new System.Windows.Forms.Button();
            this.gameInfoNamesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoNamesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameInfoNamesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoNamesFontComboBox = new System.Windows.Forms.ComboBox();
            this.achievementListAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.achievementListOpenWindowButton = new System.Windows.Forms.Button();
            this.gameProgressAutoOpenWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.gameProgressOpenWindowButton = new System.Windows.Forms.Button();
            this.focusBehaviorGroupBox = new System.Windows.Forms.GroupBox();
            this.focusBehaviorGoToLastRadioButton = new System.Windows.Forms.RadioButton();
            this.focusBehaviorGoToNextRadioButton = new System.Windows.Forms.RadioButton();
            this.focusBehaviorGoToPreviousRadioButton = new System.Windows.Forms.RadioButton();
            this.focusBehaviorGoToFirstRadioButton = new System.Windows.Forms.RadioButton();
            this.recentAchievementsMaxListLabel = new System.Windows.Forms.Label();
            this.recentAchievementsMaxListNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.achievementListScrollCheckBox = new System.Windows.Forms.CheckBox();
            this.webBrowserAutoOpenCheckbox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.userInfoRatioLabel = new System.Windows.Forms.Label();
            this.userInfoTruePointsLabel = new System.Windows.Forms.Label();
            this.userInfoPointsLabel = new System.Windows.Forms.Label();
            this.userInfoRankLabel = new System.Windows.Forms.Label();
            this.userInfoSimpleCheckBox = new System.Windows.Forms.CheckBox();
            this.userInfoBackgroundColorGroupBox = new System.Windows.Forms.GroupBox();
            this.userInfoSetBackgroundColorButton = new System.Windows.Forms.Button();
            this.userInfoBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.userInfoValuesGroupBox = new System.Windows.Forms.GroupBox();
            this.userInfoValuesFontOutlineColorBoxButton = new System.Windows.Forms.Button();
            this.userInfoValuesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.userInfoValuesFontColorBoxButton = new System.Windows.Forms.Button();
            this.userInfoValuesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.userInfoValuesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.userInfoValuesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.userInfoValuesFontComboBox = new System.Windows.Forms.ComboBox();
            this.userInfoNamesGroupBox = new System.Windows.Forms.GroupBox();
            this.userInfoNamesFontOutlineColorBoxButton = new System.Windows.Forms.Button();
            this.userInfoNamesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.userInfoNamesFontColorBoxButton = new System.Windows.Forms.Button();
            this.userInfoNamesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.userInfoNamesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.userInfoNamesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.userInfoNamesFontComboBox = new System.Windows.Forms.ComboBox();
            this.userInfoSimpleGroupBox = new System.Windows.Forms.GroupBox();
            this.userInfoSimpleFontOutlineColorBoxButton = new System.Windows.Forms.Button();
            this.userInfoSimpleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.userInfoSimpleFontColorBoxButton = new System.Windows.Forms.Button();
            this.userInfoSimpleOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.userInfoSimpleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.userInfoSimpleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.userInfoSimpleFontComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.focusAchievementIdLabel = new System.Windows.Forms.Label();
            this.focusSimpleCheckBox = new System.Windows.Forms.CheckBox();
            this.focusBorderCheckBox = new System.Windows.Forms.CheckBox();
            this.focusBackgroundColorGroupBox = new System.Windows.Forms.GroupBox();
            this.focusSetBackgroundColorButton = new System.Windows.Forms.Button();
            this.focusBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusBorderColorGroupBox = new System.Windows.Forms.GroupBox();
            this.focusSetBorderColorButton = new System.Windows.Forms.Button();
            this.focusBorderColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusLineGroupBox = new System.Windows.Forms.GroupBox();
            this.focusLineSetColorButton = new System.Windows.Forms.Button();
            this.focusLineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusLineOutlineSetColorButton = new System.Windows.Forms.Button();
            this.focusLineOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.focusLineOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusLineOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusPointsGroupBox = new System.Windows.Forms.GroupBox();
            this.focusPointsFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.focusPointsFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusPointsFontSetColorButton = new System.Windows.Forms.Button();
            this.focusPointsOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.focusPointsFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusPointsFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusPointsFontComboBox = new System.Windows.Forms.ComboBox();
            this.focusTitleGroupBox = new System.Windows.Forms.GroupBox();
            this.focusTitleFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.focusTitleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusTitleFontSetColorButton = new System.Windows.Forms.Button();
            this.focusTitleOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.focusTitleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusTitleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusTitleFontComboBox = new System.Windows.Forms.ComboBox();
            this.focusDescriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.focusDescriptionFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.focusDescriptionFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusDescriptionFontSetColorButton = new System.Windows.Forms.Button();
            this.focusDescriptionOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.focusDescriptionFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusDescriptionFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusDescriptionFontComboBox = new System.Windows.Forms.ComboBox();
            this.focusSimpleGroupBox = new System.Windows.Forms.GroupBox();
            this.focusSimpleFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.focusSimpleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusSimpleFontSetColorButton = new System.Windows.Forms.Button();
            this.focusSimpleOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.focusSimpleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusSimpleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.focusSimpleFontComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.notificationsSimpleCheckBox = new System.Windows.Forms.CheckBox();
            this.notificationsBorderCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.achievementEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.masteryEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.notificationsBackgroundColorGroupBox = new System.Windows.Forms.GroupBox();
            this.notificationsSetBackgroundColorButton = new System.Windows.Forms.Button();
            this.notificationsBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.notificationsSetBorderColorButton = new System.Windows.Forms.Button();
            this.notificationsBorderColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsLineGroupBox = new System.Windows.Forms.GroupBox();
            this.notificationsLineSetColorButton = new System.Windows.Forms.Button();
            this.notificationsLineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsLineOutlineSetColorButton = new System.Windows.Forms.Button();
            this.notificationsLineOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.notificationsLineOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsLineOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsPointsGroupBox = new System.Windows.Forms.GroupBox();
            this.notificationsPointsFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.notificationsPointsFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsPointsFontSetColorButton = new System.Windows.Forms.Button();
            this.notificationsPointsOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.notificationsPointsFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsPointsFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsPointsFontComboBox = new System.Windows.Forms.ComboBox();
            this.notificationsTitleGroupBox = new System.Windows.Forms.GroupBox();
            this.notificationsTitleFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.notificationsTitleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsTitleFontSetColorButton = new System.Windows.Forms.Button();
            this.notificationsTitleOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.notificationsTitleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsTitleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsTitleFontComboBox = new System.Windows.Forms.ComboBox();
            this.notificationsDescriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.notificationsDescriptionFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.notificationsDescriptionFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsDescriptionFontSetColorButton = new System.Windows.Forms.Button();
            this.notificationsDescriptionOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.notificationsDescriptionFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsDescriptionFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsDescriptionFontComboBox = new System.Windows.Forms.ComboBox();
            this.notificationsAllFontGroupBox = new System.Windows.Forms.GroupBox();
            this.notificationsSimpleFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.notificationsSimpleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsSimpleFontSetColorButton = new System.Windows.Forms.Button();
            this.notificationsSimpleOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.notificationsSimpleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationsSimpleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.notificationsSimpleFontComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.gameProgressRatioLabel = new System.Windows.Forms.Label();
            this.gameProgressCompletedLabel = new System.Windows.Forms.Label();
            this.gameProgressTruePointsLabel = new System.Windows.Forms.Label();
            this.gameProgressPointsLabel = new System.Windows.Forms.Label();
            this.gameProgressAchievementsLabel = new System.Windows.Forms.Label();
            this.gameProgressSimpleCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressBackgroundColorGroupBox = new System.Windows.Forms.GroupBox();
            this.gameProgressSetBackgroundColorButton = new System.Windows.Forms.Button();
            this.gameProgressBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressValuesGroupBox = new System.Windows.Forms.GroupBox();
            this.gameProgressValuesFontOutlineColorBoxButton = new System.Windows.Forms.Button();
            this.gameProgressValuesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressValuesFontColorBoxButton = new System.Windows.Forms.Button();
            this.gameProgressValuesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressValuesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameProgressValuesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressValuesFontComboBox = new System.Windows.Forms.ComboBox();
            this.gameProgressNamesGroupBox = new System.Windows.Forms.GroupBox();
            this.gameProgressNamesFontOutlineColorBoxButton = new System.Windows.Forms.Button();
            this.gameProgressNamesFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressNamesFontColorBoxButton = new System.Windows.Forms.Button();
            this.gameProgressNamesOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressNamesFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameProgressNamesFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressNamesFontComboBox = new System.Windows.Forms.ComboBox();
            this.gameProgressSimpleGroupBox = new System.Windows.Forms.GroupBox();
            this.gameProgressSimpleFontOutlineColorBoxButton = new System.Windows.Forms.Button();
            this.gameProgressSimpleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressSimpleFontColorBoxButton = new System.Windows.Forms.Button();
            this.gameProgressSimpleOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.gameProgressSimpleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameProgressSimpleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameProgressSimpleFontComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.gameInfoReleasedLabel = new System.Windows.Forms.Label();
            this.gameInfoGenreLabel = new System.Windows.Forms.Label();
            this.gameInfoConsoleLabel = new System.Windows.Forms.Label();
            this.gameInfoPublisherLabel = new System.Windows.Forms.Label();
            this.gameInfoDeveloperLabel = new System.Windows.Forms.Label();
            this.gameInfoSimpleCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoSimpleGroupBox = new System.Windows.Forms.GroupBox();
            this.gameInfoSimpleFontOutlineColorBoxButton = new System.Windows.Forms.Button();
            this.gameInfoSimpleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoSimpleFontColorBoxButton = new System.Windows.Forms.Button();
            this.gameInfoSimpleOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.gameInfoSimpleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameInfoSimpleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.gameInfoSimpleFontComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.recentAchievementsScrollCheckBox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsSimpleCheckBox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsBorderCheckBox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsBackgroundColorGroupBox = new System.Windows.Forms.GroupBox();
            this.recentAchievementsSetBackgroundColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.recentAchievementsSetBorderColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsBorderColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsLineGroupBox = new System.Windows.Forms.GroupBox();
            this.recentAchievementsLineSetColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsLineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsLineOutlineSetColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsLineOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsLineOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.recentAchievementsLineOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsPointsGroupBox = new System.Windows.Forms.GroupBox();
            this.recentAchievementsPointsFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsPointsFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsPointsFontSetColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsPointsFontOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsPointsFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.recentAchievementsPointsFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsPointsFontComboBox = new System.Windows.Forms.ComboBox();
            this.recentAchievementsTitleGroupBox = new System.Windows.Forms.GroupBox();
            this.recentAchievementsTitleFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsTitleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsTitleFontSetColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsTitleFontOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsTitleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.recentAchievementsTitleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsTitleFontComboBox = new System.Windows.Forms.ComboBox();
            this.recentAchievementsDescriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.recentAchievementsDescriptionFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsDescriptionFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsDescriptionFontSetColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsDescriptionFontOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsDescriptionFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.recentAchievementsDescriptionFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsDescriptionFontComboBox = new System.Windows.Forms.ComboBox();
            this.recentAchievementsSimpleGroupBox = new System.Windows.Forms.GroupBox();
            this.recentAchievementsSimpleFontOutlineSetColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsSimpleFontOutlineColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsSimpleFontSetColorButton = new System.Windows.Forms.Button();
            this.recentAchievementsSimpleFontOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.recentAchievementsSimpleFontOutlineNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.recentAchievementsSimpleFontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.recentAchievementsSimpleFontComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.achievementListBackgroundGroupBox = new System.Windows.Forms.GroupBox();
            this.achievementListSetBackgroundColorButton = new System.Windows.Forms.Button();
            this.achievementListBackgroundColorPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raConnectionStatusPictureBox)).BeginInit();
            this.achievementPositionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementScaleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementYNumericUpDown)).BeginInit();
            this.achievementOutAnimationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementOutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementOutSpeedUpDown)).BeginInit();
            this.achievementInAnimationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementInNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementInSpeedUpDown)).BeginInit();
            this.masteryPositionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryScaleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryYNumericUpDown)).BeginInit();
            this.masteryOutAnimationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryOutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryOutSpeedUpDown)).BeginInit();
            this.masteryInAnimationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryInNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryInSpeedUpDown)).BeginInit();
            this.groupBox17.SuspendLayout();
            this.gameInfoBackgroundColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoBackgroundColorPictureBox)).BeginInit();
            this.gameInfoValuesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontColorPictureBox)).BeginInit();
            this.gameInfoNamesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontColorPictureBox)).BeginInit();
            this.focusBehaviorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsMaxListNumericUpDown)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.userInfoBackgroundColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBackgroundColorPictureBox)).BeginInit();
            this.userInfoValuesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontColorPictureBox)).BeginInit();
            this.userInfoNamesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontColorPictureBox)).BeginInit();
            this.userInfoSimpleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoSimpleFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoSimpleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoSimpleFontColorPictureBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.focusBackgroundColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusBackgroundColorPictureBox)).BeginInit();
            this.focusBorderColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusBorderColorPictureBox)).BeginInit();
            this.focusLineGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusLineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusLineOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusLineOutlineColorPictureBox)).BeginInit();
            this.focusPointsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontColorPictureBox)).BeginInit();
            this.focusTitleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontColorPictureBox)).BeginInit();
            this.focusDescriptionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontColorPictureBox)).BeginInit();
            this.focusSimpleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusSimpleFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusSimpleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusSimpleFontColorPictureBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.notificationsBackgroundColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsBackgroundColorPictureBox)).BeginInit();
            this.groupBox28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsBorderColorPictureBox)).BeginInit();
            this.notificationsLineGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsLineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsLineOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsLineOutlineColorPictureBox)).BeginInit();
            this.notificationsPointsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsPointsFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsPointsFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsPointsFontColorPictureBox)).BeginInit();
            this.notificationsTitleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsTitleFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsTitleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsTitleFontColorPictureBox)).BeginInit();
            this.notificationsDescriptionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsDescriptionFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsDescriptionFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsDescriptionFontColorPictureBox)).BeginInit();
            this.notificationsAllFontGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsSimpleFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsSimpleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsSimpleFontColorPictureBox)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.gameProgressBackgroundColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressBackgroundColorPictureBox)).BeginInit();
            this.gameProgressValuesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontColorPictureBox)).BeginInit();
            this.gameProgressNamesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontColorPictureBox)).BeginInit();
            this.gameProgressSimpleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressSimpleFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressSimpleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressSimpleFontColorPictureBox)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.gameInfoSimpleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoSimpleFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoSimpleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoSimpleFontColorPictureBox)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.recentAchievementsBackgroundColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsBackgroundColorPictureBox)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsBorderColorPictureBox)).BeginInit();
            this.recentAchievementsLineGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineOutlineColorPictureBox)).BeginInit();
            this.recentAchievementsPointsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontColorPictureBox)).BeginInit();
            this.recentAchievementsTitleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontColorPictureBox)).BeginInit();
            this.recentAchievementsDescriptionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDescriptionFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDescriptionFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDescriptionFontColorPictureBox)).BeginInit();
            this.recentAchievementsSimpleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsSimpleFontOutlineColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsSimpleFontOutlineNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsSimpleFontColorPictureBox)).BeginInit();
            this.tabPage9.SuspendLayout();
            this.achievementListBackgroundGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.achievementListBackgroundColorPictureBox)).BeginInit();
            this.tabPage10.SuspendLayout();
            this.SuspendLayout();
            // 
            // apiKeyLabel
            // 
            this.apiKeyLabel.AutoSize = true;
            this.apiKeyLabel.BackColor = System.Drawing.Color.Transparent;
            this.apiKeyLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.apiKeyLabel.Location = new System.Drawing.Point(94, 55);
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(59, 16);
            this.apiKeyLabel.TabIndex = 31;
            this.apiKeyLabel.Text = "API Key";
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyTextBox.Location = new System.Drawing.Point(97, 72);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.PasswordChar = '*';
            this.apiKeyTextBox.Size = new System.Drawing.Size(155, 23);
            this.apiKeyTextBox.TabIndex = 1;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.usernameLabel.Location = new System.Drawing.Point(94, 10);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(72, 16);
            this.usernameLabel.TabIndex = 26;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(97, 29);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(155, 23);
            this.usernameTextBox.TabIndex = 0;
            // 
            // userProfilePictureBox
            // 
            this.userProfilePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.userProfilePictureBox.Location = new System.Drawing.Point(6, 6);
            this.userProfilePictureBox.Name = "userProfilePictureBox";
            this.userProfilePictureBox.Size = new System.Drawing.Size(85, 85);
            this.userProfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userProfilePictureBox.TabIndex = 20;
            this.userProfilePictureBox.TabStop = false;
            // 
            // autoStartCheckbox
            // 
            this.autoStartCheckbox.AutoSize = true;
            this.autoStartCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.autoStartCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoStartCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.autoStartCheckbox.Location = new System.Drawing.Point(221, 6);
            this.autoStartCheckbox.Name = "autoStartCheckbox";
            this.autoStartCheckbox.Size = new System.Drawing.Size(99, 20);
            this.autoStartCheckbox.TabIndex = 2;
            this.autoStartCheckbox.Text = "Auto-Start";
            this.autoStartCheckbox.UseVisualStyleBackColor = false;
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopButton.Location = new System.Drawing.Point(258, 69);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 28);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // timerStatusLabel
            // 
            this.timerStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.timerStatusLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.timerStatusLabel.Location = new System.Drawing.Point(6, 19);
            this.timerStatusLabel.Name = "timerStatusLabel";
            this.timerStatusLabel.Size = new System.Drawing.Size(731, 29);
            this.timerStatusLabel.TabIndex = 10024;
            this.timerStatusLabel.Text = "Offline";
            // 
            // userInfoAutoOpenWindowCheckbox
            // 
            this.userInfoAutoOpenWindowCheckbox.AutoSize = true;
            this.userInfoAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoAutoOpenWindowCheckbox.Location = new System.Drawing.Point(6, 260);
            this.userInfoAutoOpenWindowCheckbox.Name = "userInfoAutoOpenWindowCheckbox";
            this.userInfoAutoOpenWindowCheckbox.Size = new System.Drawing.Size(115, 22);
            this.userInfoAutoOpenWindowCheckbox.TabIndex = 10022;
            this.userInfoAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.userInfoAutoOpenWindowCheckbox.UseVisualStyleBackColor = true;
            // 
            // userInfoOpenWindowButton
            // 
            this.userInfoOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoOpenWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userInfoOpenWindowButton.Location = new System.Drawing.Point(245, 255);
            this.userInfoOpenWindowButton.Name = "userInfoOpenWindowButton";
            this.userInfoOpenWindowButton.Size = new System.Drawing.Size(85, 28);
            this.userInfoOpenWindowButton.TabIndex = 10021;
            this.userInfoOpenWindowButton.Text = "Open";
            this.userInfoOpenWindowButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(258, 28);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 28);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // focusAchievementPictureBox
            // 
            this.focusAchievementPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.focusAchievementPictureBox.InitialImage = null;
            this.focusAchievementPictureBox.Location = new System.Drawing.Point(20, 29);
            this.focusAchievementPictureBox.Name = "focusAchievementPictureBox";
            this.focusAchievementPictureBox.Size = new System.Drawing.Size(96, 96);
            this.focusAchievementPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.focusAchievementPictureBox.TabIndex = 10030;
            this.focusAchievementPictureBox.TabStop = false;
            // 
            // focusAchievementTitleLabel
            // 
            this.focusAchievementTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.focusAchievementTitleLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusAchievementTitleLabel.Location = new System.Drawing.Point(132, 6);
            this.focusAchievementTitleLabel.Name = "focusAchievementTitleLabel";
            this.focusAchievementTitleLabel.Size = new System.Drawing.Size(201, 95);
            this.focusAchievementTitleLabel.TabIndex = 10027;
            // 
            // focusAchievementDescriptionLabel
            // 
            this.focusAchievementDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.focusAchievementDescriptionLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusAchievementDescriptionLabel.Location = new System.Drawing.Point(132, 101);
            this.focusAchievementDescriptionLabel.Name = "focusAchievementDescriptionLabel";
            this.focusAchievementDescriptionLabel.Size = new System.Drawing.Size(201, 84);
            this.focusAchievementDescriptionLabel.TabIndex = 10026;
            // 
            // focusSetButton
            // 
            this.focusSetButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.focusSetButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusSetButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusSetButton.Location = new System.Drawing.Point(20, 157);
            this.focusSetButton.Name = "focusSetButton";
            this.focusSetButton.Size = new System.Drawing.Size(96, 28);
            this.focusSetButton.TabIndex = 10031;
            this.focusSetButton.Text = "Focus";
            this.focusSetButton.UseVisualStyleBackColor = false;
            // 
            // focusAchievementButtonPrevious
            // 
            this.focusAchievementButtonPrevious.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonPrevious.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonPrevious.Location = new System.Drawing.Point(6, 129);
            this.focusAchievementButtonPrevious.Name = "focusAchievementButtonPrevious";
            this.focusAchievementButtonPrevious.Size = new System.Drawing.Size(54, 22);
            this.focusAchievementButtonPrevious.TabIndex = 10028;
            this.focusAchievementButtonPrevious.Text = "<";
            this.focusAchievementButtonPrevious.UseVisualStyleBackColor = true;
            // 
            // focusAchievementButtonNext
            // 
            this.focusAchievementButtonNext.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonNext.Location = new System.Drawing.Point(77, 129);
            this.focusAchievementButtonNext.Name = "focusAchievementButtonNext";
            this.focusAchievementButtonNext.Size = new System.Drawing.Size(52, 22);
            this.focusAchievementButtonNext.TabIndex = 10029;
            this.focusAchievementButtonNext.Text = ">";
            this.focusAchievementButtonNext.UseVisualStyleBackColor = true;
            // 
            // focusAutoOpenWindowCheckBox
            // 
            this.focusAutoOpenWindowCheckBox.AutoSize = true;
            this.focusAutoOpenWindowCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAutoOpenWindowCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusAutoOpenWindowCheckBox.Location = new System.Drawing.Point(6, 260);
            this.focusAutoOpenWindowCheckBox.Name = "focusAutoOpenWindowCheckBox";
            this.focusAutoOpenWindowCheckBox.Size = new System.Drawing.Size(115, 22);
            this.focusAutoOpenWindowCheckBox.TabIndex = 10020;
            this.focusAutoOpenWindowCheckBox.Text = "Auto-Open";
            this.focusAutoOpenWindowCheckBox.UseVisualStyleBackColor = true;
            // 
            // focusOpenWindowButton
            // 
            this.focusOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusOpenWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusOpenWindowButton.Location = new System.Drawing.Point(245, 255);
            this.focusOpenWindowButton.Name = "focusOpenWindowButton";
            this.focusOpenWindowButton.Size = new System.Drawing.Size(85, 28);
            this.focusOpenWindowButton.TabIndex = 10014;
            this.focusOpenWindowButton.Text = "Open";
            this.focusOpenWindowButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoPictureBox
            // 
            this.gameInfoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoPictureBox.InitialImage = null;
            this.gameInfoPictureBox.Location = new System.Drawing.Point(3, 7);
            this.gameInfoPictureBox.Name = "gameInfoPictureBox";
            this.gameInfoPictureBox.Size = new System.Drawing.Size(83, 83);
            this.gameInfoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameInfoPictureBox.TabIndex = 10004;
            this.gameInfoPictureBox.TabStop = false;
            // 
            // gameInfoTitleLabel
            // 
            this.gameInfoTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoTitleLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoTitleLabel.Location = new System.Drawing.Point(422, 135);
            this.gameInfoTitleLabel.Name = "gameInfoTitleLabel";
            this.gameInfoTitleLabel.Size = new System.Drawing.Size(339, 32);
            this.gameInfoTitleLabel.TabIndex = 10007;
            // 
            // rssFeedFriendCheckBox
            // 
            this.rssFeedFriendCheckBox.AutoSize = true;
            this.rssFeedFriendCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedFriendCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedFriendCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.rssFeedFriendCheckBox.Location = new System.Drawing.Point(239, 6);
            this.rssFeedFriendCheckBox.Name = "rssFeedFriendCheckBox";
            this.rssFeedFriendCheckBox.Size = new System.Drawing.Size(83, 20);
            this.rssFeedFriendCheckBox.TabIndex = 10010;
            this.rssFeedFriendCheckBox.Text = "FRIENDS";
            this.rssFeedFriendCheckBox.UseVisualStyleBackColor = false;
            // 
            // rssFeedCheevoCheckBox
            // 
            this.rssFeedCheevoCheckBox.AutoSize = true;
            this.rssFeedCheevoCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedCheevoCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedCheevoCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.rssFeedCheevoCheckBox.Location = new System.Drawing.Point(153, 6);
            this.rssFeedCheevoCheckBox.Name = "rssFeedCheevoCheckBox";
            this.rssFeedCheevoCheckBox.Size = new System.Drawing.Size(80, 20);
            this.rssFeedCheevoCheckBox.TabIndex = 10011;
            this.rssFeedCheevoCheckBox.Text = "CHEEVO";
            this.rssFeedCheevoCheckBox.UseVisualStyleBackColor = false;
            // 
            // rssFeedNewsCheckBox
            // 
            this.rssFeedNewsCheckBox.AutoSize = true;
            this.rssFeedNewsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedNewsCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedNewsCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.rssFeedNewsCheckBox.Location = new System.Drawing.Point(4, 6);
            this.rssFeedNewsCheckBox.Name = "rssFeedNewsCheckBox";
            this.rssFeedNewsCheckBox.Size = new System.Drawing.Size(66, 20);
            this.rssFeedNewsCheckBox.TabIndex = 10012;
            this.rssFeedNewsCheckBox.Text = "NEWS";
            this.rssFeedNewsCheckBox.UseVisualStyleBackColor = false;
            // 
            // rssFeedForumCheckBox
            // 
            this.rssFeedForumCheckBox.AutoSize = true;
            this.rssFeedForumCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rssFeedForumCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssFeedForumCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.rssFeedForumCheckBox.Location = new System.Drawing.Point(74, 6);
            this.rssFeedForumCheckBox.Name = "rssFeedForumCheckBox";
            this.rssFeedForumCheckBox.Size = new System.Drawing.Size(73, 20);
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
            this.rssFeedListView.Location = new System.Drawing.Point(4, 32);
            this.rssFeedListView.Name = "rssFeedListView";
            this.rssFeedListView.Size = new System.Drawing.Size(324, 217);
            this.rssFeedListView.TabIndex = 10006;
            this.rssFeedListView.UseCompatibleStateImageBehavior = false;
            this.rssFeedListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 400;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.groupBox2.Controls.Add(this.raConnectionStatusPictureBox);
            this.groupBox2.Controls.Add(this.timerStatusLabel);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 339);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 55);
            this.groupBox2.TabIndex = 10027;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // raConnectionStatusPictureBox
            // 
            this.raConnectionStatusPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.raConnectionStatusPictureBox.Location = new System.Drawing.Point(743, 20);
            this.raConnectionStatusPictureBox.Name = "raConnectionStatusPictureBox";
            this.raConnectionStatusPictureBox.Size = new System.Drawing.Size(28, 28);
            this.raConnectionStatusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.raConnectionStatusPictureBox.TabIndex = 10025;
            this.raConnectionStatusPictureBox.TabStop = false;
            // 
            // notificationsAutoOpenWindowCheckbox
            // 
            this.notificationsAutoOpenWindowCheckbox.AutoSize = true;
            this.notificationsAutoOpenWindowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.notificationsAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.notificationsAutoOpenWindowCheckbox.Location = new System.Drawing.Point(6, 260);
            this.notificationsAutoOpenWindowCheckbox.Name = "notificationsAutoOpenWindowCheckbox";
            this.notificationsAutoOpenWindowCheckbox.Size = new System.Drawing.Size(115, 22);
            this.notificationsAutoOpenWindowCheckbox.TabIndex = 10022;
            this.notificationsAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.notificationsAutoOpenWindowCheckbox.UseVisualStyleBackColor = false;
            // 
            // notificationsOpenWindowButton
            // 
            this.notificationsOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsOpenWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsOpenWindowButton.Location = new System.Drawing.Point(245, 255);
            this.notificationsOpenWindowButton.Name = "notificationsOpenWindowButton";
            this.notificationsOpenWindowButton.Size = new System.Drawing.Size(85, 28);
            this.notificationsOpenWindowButton.TabIndex = 10021;
            this.notificationsOpenWindowButton.Text = "Open";
            this.notificationsOpenWindowButton.UseVisualStyleBackColor = true;
            // 
            // playAchievementButton
            // 
            this.playAchievementButton.BackColor = System.Drawing.SystemColors.Control;
            this.playAchievementButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAchievementButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playAchievementButton.Location = new System.Drawing.Point(6, 14);
            this.playAchievementButton.Name = "playAchievementButton";
            this.playAchievementButton.Size = new System.Drawing.Size(65, 25);
            this.playAchievementButton.TabIndex = 2;
            this.playAchievementButton.Text = "Play";
            this.playAchievementButton.UseVisualStyleBackColor = false;
            // 
            // selectCustomAchievementFileButton
            // 
            this.selectCustomAchievementFileButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomAchievementFileButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectCustomAchievementFileButton.Location = new System.Drawing.Point(84, 14);
            this.selectCustomAchievementFileButton.Name = "selectCustomAchievementFileButton";
            this.selectCustomAchievementFileButton.Size = new System.Drawing.Size(65, 25);
            this.selectCustomAchievementFileButton.TabIndex = 14;
            this.selectCustomAchievementFileButton.Text = "File";
            this.selectCustomAchievementFileButton.UseVisualStyleBackColor = true;
            // 
            // achievementPositionGroupBox
            // 
            this.achievementPositionGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.achievementPositionGroupBox.Controls.Add(this.label14);
            this.achievementPositionGroupBox.Controls.Add(this.notificationsCustomAchievementScaleNumericUpDown);
            this.achievementPositionGroupBox.Controls.Add(this.xPositionLabel1);
            this.achievementPositionGroupBox.Controls.Add(this.yPositionLabel1);
            this.achievementPositionGroupBox.Controls.Add(this.notificationsCustomAchievementXNumericUpDown);
            this.achievementPositionGroupBox.Controls.Add(this.notificationsCustomAchievementYNumericUpDown);
            this.achievementPositionGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementPositionGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.achievementPositionGroupBox.Location = new System.Drawing.Point(160, 3);
            this.achievementPositionGroupBox.Name = "achievementPositionGroupBox";
            this.achievementPositionGroupBox.Size = new System.Drawing.Size(150, 96);
            this.achievementPositionGroupBox.TabIndex = 50;
            this.achievementPositionGroupBox.TabStop = false;
            this.achievementPositionGroupBox.Text = "Position";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label14.Location = new System.Drawing.Point(12, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "Scale";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notificationsCustomAchievementScaleNumericUpDown
            // 
            this.notificationsCustomAchievementScaleNumericUpDown.DecimalPlaces = 2;
            this.notificationsCustomAchievementScaleNumericUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomAchievementScaleNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.notificationsCustomAchievementScaleNumericUpDown.Location = new System.Drawing.Point(78, 66);
            this.notificationsCustomAchievementScaleNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.notificationsCustomAchievementScaleNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.notificationsCustomAchievementScaleNumericUpDown.Name = "notificationsCustomAchievementScaleNumericUpDown";
            this.notificationsCustomAchievementScaleNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomAchievementScaleNumericUpDown.TabIndex = 20;
            this.notificationsCustomAchievementScaleNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // xPositionLabel1
            // 
            this.xPositionLabel1.AutoSize = true;
            this.xPositionLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPositionLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.xPositionLabel1.Location = new System.Drawing.Point(12, 21);
            this.xPositionLabel1.Name = "xPositionLabel1";
            this.xPositionLabel1.Size = new System.Drawing.Size(50, 16);
            this.xPositionLabel1.TabIndex = 18;
            this.xPositionLabel1.Text = "X pos.";
            // 
            // yPositionLabel1
            // 
            this.yPositionLabel1.AutoSize = true;
            this.yPositionLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yPositionLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.yPositionLabel1.Location = new System.Drawing.Point(12, 44);
            this.yPositionLabel1.Name = "yPositionLabel1";
            this.yPositionLabel1.Size = new System.Drawing.Size(50, 16);
            this.yPositionLabel1.TabIndex = 19;
            this.yPositionLabel1.Text = "Y pos.";
            this.yPositionLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notificationsCustomAchievementXNumericUpDown
            // 
            this.notificationsCustomAchievementXNumericUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomAchievementXNumericUpDown.Location = new System.Drawing.Point(78, 18);
            this.notificationsCustomAchievementXNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.notificationsCustomAchievementXNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.notificationsCustomAchievementXNumericUpDown.Name = "notificationsCustomAchievementXNumericUpDown";
            this.notificationsCustomAchievementXNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomAchievementXNumericUpDown.TabIndex = 15;
            // 
            // notificationsCustomAchievementYNumericUpDown
            // 
            this.notificationsCustomAchievementYNumericUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomAchievementYNumericUpDown.Location = new System.Drawing.Point(78, 42);
            this.notificationsCustomAchievementYNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.notificationsCustomAchievementYNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.notificationsCustomAchievementYNumericUpDown.Name = "notificationsCustomAchievementYNumericUpDown";
            this.notificationsCustomAchievementYNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomAchievementYNumericUpDown.TabIndex = 16;
            // 
            // acheivementEditOutlineCheckbox
            // 
            this.acheivementEditOutlineCheckbox.AutoSize = true;
            this.acheivementEditOutlineCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acheivementEditOutlineCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.acheivementEditOutlineCheckbox.Location = new System.Drawing.Point(6, 77);
            this.acheivementEditOutlineCheckbox.Name = "acheivementEditOutlineCheckbox";
            this.acheivementEditOutlineCheckbox.Size = new System.Drawing.Size(52, 20);
            this.acheivementEditOutlineCheckbox.TabIndex = 47;
            this.acheivementEditOutlineCheckbox.Text = "Edit";
            this.acheivementEditOutlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // achievementOutAnimationGroupBox
            // 
            this.achievementOutAnimationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.achievementOutAnimationGroupBox.Controls.Add(this.label11);
            this.achievementOutAnimationGroupBox.Controls.Add(this.label12);
            this.achievementOutAnimationGroupBox.Controls.Add(this.label13);
            this.achievementOutAnimationGroupBox.Controls.Add(this.notificationsCustomAchievementOutNumericUpDown);
            this.achievementOutAnimationGroupBox.Controls.Add(this.notificationsCustomAchievementAnimationOutComboBox);
            this.achievementOutAnimationGroupBox.Controls.Add(this.notificationsCustomAchievementOutSpeedUpDown);
            this.achievementOutAnimationGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementOutAnimationGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.achievementOutAnimationGroupBox.Location = new System.Drawing.Point(160, 102);
            this.achievementOutAnimationGroupBox.Name = "achievementOutAnimationGroupBox";
            this.achievementOutAnimationGroupBox.Size = new System.Drawing.Size(150, 96);
            this.achievementOutAnimationGroupBox.TabIndex = 53;
            this.achievementOutAnimationGroupBox.TabStop = false;
            this.achievementOutAnimationGroupBox.Text = "Out-Animation";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label11.Location = new System.Drawing.Point(12, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 16);
            this.label11.TabIndex = 49;
            this.label11.Text = "Duration";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label12.Location = new System.Drawing.Point(12, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 16);
            this.label12.TabIndex = 40;
            this.label12.Text = "Direction";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label13.Location = new System.Drawing.Point(12, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "Mark";
            // 
            // notificationsCustomAchievementOutNumericUpDown
            // 
            this.notificationsCustomAchievementOutNumericUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomAchievementOutNumericUpDown.Location = new System.Drawing.Point(78, 18);
            this.notificationsCustomAchievementOutNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.notificationsCustomAchievementOutNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.notificationsCustomAchievementOutNumericUpDown.Name = "notificationsCustomAchievementOutNumericUpDown";
            this.notificationsCustomAchievementOutNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomAchievementOutNumericUpDown.TabIndex = 26;
            this.notificationsCustomAchievementOutNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsCustomAchievementAnimationOutComboBox
            // 
            this.notificationsCustomAchievementAnimationOutComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomAchievementAnimationOutComboBox.FormattingEnabled = true;
            this.notificationsCustomAchievementAnimationOutComboBox.Location = new System.Drawing.Point(78, 66);
            this.notificationsCustomAchievementAnimationOutComboBox.Name = "notificationsCustomAchievementAnimationOutComboBox";
            this.notificationsCustomAchievementAnimationOutComboBox.Size = new System.Drawing.Size(65, 24);
            this.notificationsCustomAchievementAnimationOutComboBox.TabIndex = 39;
            // 
            // notificationsCustomAchievementOutSpeedUpDown
            // 
            this.notificationsCustomAchievementOutSpeedUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomAchievementOutSpeedUpDown.Location = new System.Drawing.Point(78, 42);
            this.notificationsCustomAchievementOutSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.notificationsCustomAchievementOutSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.notificationsCustomAchievementOutSpeedUpDown.Name = "notificationsCustomAchievementOutSpeedUpDown";
            this.notificationsCustomAchievementOutSpeedUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomAchievementOutSpeedUpDown.TabIndex = 48;
            this.notificationsCustomAchievementOutSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // achievementInAnimationGroupBox
            // 
            this.achievementInAnimationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.achievementInAnimationGroupBox.Controls.Add(this.label8);
            this.achievementInAnimationGroupBox.Controls.Add(this.label7);
            this.achievementInAnimationGroupBox.Controls.Add(this.label6);
            this.achievementInAnimationGroupBox.Controls.Add(this.notificationsCustomAchievementInNumericUpDown);
            this.achievementInAnimationGroupBox.Controls.Add(this.notificationsCustomAchievementAnimationInComboBox);
            this.achievementInAnimationGroupBox.Controls.Add(this.notificationsCustomAchievementInSpeedUpDown);
            this.achievementInAnimationGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementInAnimationGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.achievementInAnimationGroupBox.Location = new System.Drawing.Point(6, 102);
            this.achievementInAnimationGroupBox.Name = "achievementInAnimationGroupBox";
            this.achievementInAnimationGroupBox.Size = new System.Drawing.Size(150, 96);
            this.achievementInAnimationGroupBox.TabIndex = 52;
            this.achievementInAnimationGroupBox.TabStop = false;
            this.achievementInAnimationGroupBox.Text = "In-Animation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label8.Location = new System.Drawing.Point(12, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 49;
            this.label8.Text = "Duration";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label7.Location = new System.Drawing.Point(12, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 40;
            this.label7.Text = "Direction";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label6.Location = new System.Drawing.Point(12, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Mark";
            // 
            // notificationsCustomAchievementInNumericUpDown
            // 
            this.notificationsCustomAchievementInNumericUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomAchievementInNumericUpDown.Location = new System.Drawing.Point(78, 18);
            this.notificationsCustomAchievementInNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.notificationsCustomAchievementInNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.notificationsCustomAchievementInNumericUpDown.Name = "notificationsCustomAchievementInNumericUpDown";
            this.notificationsCustomAchievementInNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomAchievementInNumericUpDown.TabIndex = 26;
            this.notificationsCustomAchievementInNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsCustomAchievementAnimationInComboBox
            // 
            this.notificationsCustomAchievementAnimationInComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomAchievementAnimationInComboBox.FormattingEnabled = true;
            this.notificationsCustomAchievementAnimationInComboBox.Location = new System.Drawing.Point(78, 66);
            this.notificationsCustomAchievementAnimationInComboBox.Name = "notificationsCustomAchievementAnimationInComboBox";
            this.notificationsCustomAchievementAnimationInComboBox.Size = new System.Drawing.Size(65, 24);
            this.notificationsCustomAchievementAnimationInComboBox.TabIndex = 39;
            // 
            // notificationsCustomAchievementInSpeedUpDown
            // 
            this.notificationsCustomAchievementInSpeedUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomAchievementInSpeedUpDown.Location = new System.Drawing.Point(78, 42);
            this.notificationsCustomAchievementInSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.notificationsCustomAchievementInSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.notificationsCustomAchievementInSpeedUpDown.Name = "notificationsCustomAchievementInSpeedUpDown";
            this.notificationsCustomAchievementInSpeedUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomAchievementInSpeedUpDown.TabIndex = 48;
            this.notificationsCustomAchievementInSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // customAchievementEnableCheckbox
            // 
            this.customAchievementEnableCheckbox.AutoSize = true;
            this.customAchievementEnableCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementEnableCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.customAchievementEnableCheckbox.Location = new System.Drawing.Point(6, 60);
            this.customAchievementEnableCheckbox.Name = "customAchievementEnableCheckbox";
            this.customAchievementEnableCheckbox.Size = new System.Drawing.Size(76, 20);
            this.customAchievementEnableCheckbox.TabIndex = 13;
            this.customAchievementEnableCheckbox.Text = "Custom";
            this.customAchievementEnableCheckbox.UseVisualStyleBackColor = true;
            // 
            // playMasteryButton
            // 
            this.playMasteryButton.BackColor = System.Drawing.SystemColors.Control;
            this.playMasteryButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playMasteryButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playMasteryButton.Location = new System.Drawing.Point(6, 14);
            this.playMasteryButton.Name = "playMasteryButton";
            this.playMasteryButton.Size = new System.Drawing.Size(65, 25);
            this.playMasteryButton.TabIndex = 2;
            this.playMasteryButton.Text = "Play";
            this.playMasteryButton.UseVisualStyleBackColor = false;
            // 
            // selectCustomMasteryFileButton
            // 
            this.selectCustomMasteryFileButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomMasteryFileButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectCustomMasteryFileButton.Location = new System.Drawing.Point(84, 14);
            this.selectCustomMasteryFileButton.Name = "selectCustomMasteryFileButton";
            this.selectCustomMasteryFileButton.Size = new System.Drawing.Size(65, 25);
            this.selectCustomMasteryFileButton.TabIndex = 14;
            this.selectCustomMasteryFileButton.Text = "File";
            this.selectCustomMasteryFileButton.UseVisualStyleBackColor = true;
            // 
            // masteryPositionGroupBox
            // 
            this.masteryPositionGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.masteryPositionGroupBox.Controls.Add(this.label16);
            this.masteryPositionGroupBox.Controls.Add(this.notificationsCustomMasteryScaleNumericUpDown);
            this.masteryPositionGroupBox.Controls.Add(this.label17);
            this.masteryPositionGroupBox.Controls.Add(this.label18);
            this.masteryPositionGroupBox.Controls.Add(this.notificationsCustomMasteryXNumericUpDown);
            this.masteryPositionGroupBox.Controls.Add(this.notificationsCustomMasteryYNumericUpDown);
            this.masteryPositionGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masteryPositionGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.masteryPositionGroupBox.Location = new System.Drawing.Point(160, 3);
            this.masteryPositionGroupBox.Name = "masteryPositionGroupBox";
            this.masteryPositionGroupBox.Size = new System.Drawing.Size(150, 96);
            this.masteryPositionGroupBox.TabIndex = 50;
            this.masteryPositionGroupBox.TabStop = false;
            this.masteryPositionGroupBox.Text = "Position";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label16.Location = new System.Drawing.Point(12, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 16);
            this.label16.TabIndex = 21;
            this.label16.Text = "Scale";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notificationsCustomMasteryScaleNumericUpDown
            // 
            this.notificationsCustomMasteryScaleNumericUpDown.DecimalPlaces = 2;
            this.notificationsCustomMasteryScaleNumericUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomMasteryScaleNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.notificationsCustomMasteryScaleNumericUpDown.Location = new System.Drawing.Point(78, 66);
            this.notificationsCustomMasteryScaleNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.notificationsCustomMasteryScaleNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.notificationsCustomMasteryScaleNumericUpDown.Name = "notificationsCustomMasteryScaleNumericUpDown";
            this.notificationsCustomMasteryScaleNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomMasteryScaleNumericUpDown.TabIndex = 20;
            this.notificationsCustomMasteryScaleNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label17.Location = new System.Drawing.Point(12, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 16);
            this.label17.TabIndex = 18;
            this.label17.Text = "X pos.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label18.Location = new System.Drawing.Point(12, 44);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 16);
            this.label18.TabIndex = 19;
            this.label18.Text = "Y pos.";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notificationsCustomMasteryXNumericUpDown
            // 
            this.notificationsCustomMasteryXNumericUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomMasteryXNumericUpDown.Location = new System.Drawing.Point(78, 18);
            this.notificationsCustomMasteryXNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.notificationsCustomMasteryXNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.notificationsCustomMasteryXNumericUpDown.Name = "notificationsCustomMasteryXNumericUpDown";
            this.notificationsCustomMasteryXNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomMasteryXNumericUpDown.TabIndex = 15;
            // 
            // notificationsCustomMasteryYNumericUpDown
            // 
            this.notificationsCustomMasteryYNumericUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomMasteryYNumericUpDown.Location = new System.Drawing.Point(78, 42);
            this.notificationsCustomMasteryYNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.notificationsCustomMasteryYNumericUpDown.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.notificationsCustomMasteryYNumericUpDown.Name = "notificationsCustomMasteryYNumericUpDown";
            this.notificationsCustomMasteryYNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomMasteryYNumericUpDown.TabIndex = 16;
            // 
            // masteryEditOultineCheckbox
            // 
            this.masteryEditOultineCheckbox.AutoSize = true;
            this.masteryEditOultineCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masteryEditOultineCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.masteryEditOultineCheckbox.Location = new System.Drawing.Point(6, 77);
            this.masteryEditOultineCheckbox.Name = "masteryEditOultineCheckbox";
            this.masteryEditOultineCheckbox.Size = new System.Drawing.Size(52, 20);
            this.masteryEditOultineCheckbox.TabIndex = 47;
            this.masteryEditOultineCheckbox.Text = "Edit";
            this.masteryEditOultineCheckbox.UseVisualStyleBackColor = true;
            // 
            // masteryOutAnimationGroupBox
            // 
            this.masteryOutAnimationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.masteryOutAnimationGroupBox.Controls.Add(this.label19);
            this.masteryOutAnimationGroupBox.Controls.Add(this.label20);
            this.masteryOutAnimationGroupBox.Controls.Add(this.label21);
            this.masteryOutAnimationGroupBox.Controls.Add(this.notificationsCustomMasteryOutNumericUpDown);
            this.masteryOutAnimationGroupBox.Controls.Add(this.notificationsCustomMasteryAnimationOutComboBox);
            this.masteryOutAnimationGroupBox.Controls.Add(this.notificationsCustomMasteryOutSpeedUpDown);
            this.masteryOutAnimationGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masteryOutAnimationGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.masteryOutAnimationGroupBox.Location = new System.Drawing.Point(160, 102);
            this.masteryOutAnimationGroupBox.Name = "masteryOutAnimationGroupBox";
            this.masteryOutAnimationGroupBox.Size = new System.Drawing.Size(150, 96);
            this.masteryOutAnimationGroupBox.TabIndex = 53;
            this.masteryOutAnimationGroupBox.TabStop = false;
            this.masteryOutAnimationGroupBox.Text = "Out-Animation";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label19.Location = new System.Drawing.Point(12, 44);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 16);
            this.label19.TabIndex = 49;
            this.label19.Text = "Duration";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label20.Location = new System.Drawing.Point(12, 68);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 16);
            this.label20.TabIndex = 40;
            this.label20.Text = "Direction";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label21.Location = new System.Drawing.Point(12, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 16);
            this.label21.TabIndex = 20;
            this.label21.Text = "Mark";
            // 
            // notificationsCustomMasteryOutNumericUpDown
            // 
            this.notificationsCustomMasteryOutNumericUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomMasteryOutNumericUpDown.Location = new System.Drawing.Point(78, 18);
            this.notificationsCustomMasteryOutNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.notificationsCustomMasteryOutNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.notificationsCustomMasteryOutNumericUpDown.Name = "notificationsCustomMasteryOutNumericUpDown";
            this.notificationsCustomMasteryOutNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomMasteryOutNumericUpDown.TabIndex = 26;
            this.notificationsCustomMasteryOutNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsCustomMasteryAnimationOutComboBox
            // 
            this.notificationsCustomMasteryAnimationOutComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomMasteryAnimationOutComboBox.FormattingEnabled = true;
            this.notificationsCustomMasteryAnimationOutComboBox.Location = new System.Drawing.Point(78, 66);
            this.notificationsCustomMasteryAnimationOutComboBox.Name = "notificationsCustomMasteryAnimationOutComboBox";
            this.notificationsCustomMasteryAnimationOutComboBox.Size = new System.Drawing.Size(65, 24);
            this.notificationsCustomMasteryAnimationOutComboBox.TabIndex = 39;
            // 
            // notificationsCustomMasteryOutSpeedUpDown
            // 
            this.notificationsCustomMasteryOutSpeedUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomMasteryOutSpeedUpDown.Location = new System.Drawing.Point(78, 42);
            this.notificationsCustomMasteryOutSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.notificationsCustomMasteryOutSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.notificationsCustomMasteryOutSpeedUpDown.Name = "notificationsCustomMasteryOutSpeedUpDown";
            this.notificationsCustomMasteryOutSpeedUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomMasteryOutSpeedUpDown.TabIndex = 48;
            this.notificationsCustomMasteryOutSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // masteryInAnimationGroupBox
            // 
            this.masteryInAnimationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.masteryInAnimationGroupBox.Controls.Add(this.label22);
            this.masteryInAnimationGroupBox.Controls.Add(this.label23);
            this.masteryInAnimationGroupBox.Controls.Add(this.label24);
            this.masteryInAnimationGroupBox.Controls.Add(this.notificationsCustomMasteryInNumericUpDown);
            this.masteryInAnimationGroupBox.Controls.Add(this.notificationsCustomMasteryAnimationInComboBox);
            this.masteryInAnimationGroupBox.Controls.Add(this.notificationsCustomMasteryInSpeedUpDown);
            this.masteryInAnimationGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masteryInAnimationGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.masteryInAnimationGroupBox.Location = new System.Drawing.Point(6, 102);
            this.masteryInAnimationGroupBox.Name = "masteryInAnimationGroupBox";
            this.masteryInAnimationGroupBox.Size = new System.Drawing.Size(150, 96);
            this.masteryInAnimationGroupBox.TabIndex = 52;
            this.masteryInAnimationGroupBox.TabStop = false;
            this.masteryInAnimationGroupBox.Text = "In-Animation";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label22.Location = new System.Drawing.Point(12, 44);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 16);
            this.label22.TabIndex = 49;
            this.label22.Text = "Duration";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label23.Location = new System.Drawing.Point(12, 68);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 16);
            this.label23.TabIndex = 40;
            this.label23.Text = "Direction";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.label24.Location = new System.Drawing.Point(12, 21);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 16);
            this.label24.TabIndex = 20;
            this.label24.Text = "Mark";
            // 
            // notificationsCustomMasteryInNumericUpDown
            // 
            this.notificationsCustomMasteryInNumericUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomMasteryInNumericUpDown.Location = new System.Drawing.Point(78, 18);
            this.notificationsCustomMasteryInNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.notificationsCustomMasteryInNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.notificationsCustomMasteryInNumericUpDown.Name = "notificationsCustomMasteryInNumericUpDown";
            this.notificationsCustomMasteryInNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomMasteryInNumericUpDown.TabIndex = 26;
            this.notificationsCustomMasteryInNumericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // notificationsCustomMasteryAnimationInComboBox
            // 
            this.notificationsCustomMasteryAnimationInComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomMasteryAnimationInComboBox.FormattingEnabled = true;
            this.notificationsCustomMasteryAnimationInComboBox.Location = new System.Drawing.Point(78, 66);
            this.notificationsCustomMasteryAnimationInComboBox.Name = "notificationsCustomMasteryAnimationInComboBox";
            this.notificationsCustomMasteryAnimationInComboBox.Size = new System.Drawing.Size(65, 24);
            this.notificationsCustomMasteryAnimationInComboBox.TabIndex = 39;
            // 
            // notificationsCustomMasteryInSpeedUpDown
            // 
            this.notificationsCustomMasteryInSpeedUpDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsCustomMasteryInSpeedUpDown.Location = new System.Drawing.Point(78, 42);
            this.notificationsCustomMasteryInSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.notificationsCustomMasteryInSpeedUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.notificationsCustomMasteryInSpeedUpDown.Name = "notificationsCustomMasteryInSpeedUpDown";
            this.notificationsCustomMasteryInSpeedUpDown.Size = new System.Drawing.Size(65, 23);
            this.notificationsCustomMasteryInSpeedUpDown.TabIndex = 48;
            this.notificationsCustomMasteryInSpeedUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // customMasteryEnableCheckbox
            // 
            this.customMasteryEnableCheckbox.AutoSize = true;
            this.customMasteryEnableCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryEnableCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.customMasteryEnableCheckbox.Location = new System.Drawing.Point(6, 60);
            this.customMasteryEnableCheckbox.Name = "customMasteryEnableCheckbox";
            this.customMasteryEnableCheckbox.Size = new System.Drawing.Size(76, 20);
            this.customMasteryEnableCheckbox.TabIndex = 13;
            this.customMasteryEnableCheckbox.Text = "Custom";
            this.customMasteryEnableCheckbox.UseVisualStyleBackColor = true;
            // 
            // gameInfoAutoOpenWindowCheckbox
            // 
            this.gameInfoAutoOpenWindowCheckbox.AutoSize = true;
            this.gameInfoAutoOpenWindowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoAutoOpenWindowCheckbox.Location = new System.Drawing.Point(6, 260);
            this.gameInfoAutoOpenWindowCheckbox.Name = "gameInfoAutoOpenWindowCheckbox";
            this.gameInfoAutoOpenWindowCheckbox.Size = new System.Drawing.Size(115, 22);
            this.gameInfoAutoOpenWindowCheckbox.TabIndex = 10022;
            this.gameInfoAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.gameInfoAutoOpenWindowCheckbox.UseVisualStyleBackColor = false;
            // 
            // gameInfoOpenWindowButton
            // 
            this.gameInfoOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoOpenWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameInfoOpenWindowButton.Location = new System.Drawing.Point(245, 255);
            this.gameInfoOpenWindowButton.Name = "gameInfoOpenWindowButton";
            this.gameInfoOpenWindowButton.Size = new System.Drawing.Size(85, 28);
            this.gameInfoOpenWindowButton.TabIndex = 10021;
            this.gameInfoOpenWindowButton.Text = "Open";
            this.gameInfoOpenWindowButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsAutoOpenWindowCheckbox
            // 
            this.recentAchievementsAutoOpenWindowCheckbox.AutoSize = true;
            this.recentAchievementsAutoOpenWindowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsAutoOpenWindowCheckbox.Location = new System.Drawing.Point(6, 260);
            this.recentAchievementsAutoOpenWindowCheckbox.Name = "recentAchievementsAutoOpenWindowCheckbox";
            this.recentAchievementsAutoOpenWindowCheckbox.Size = new System.Drawing.Size(115, 22);
            this.recentAchievementsAutoOpenWindowCheckbox.TabIndex = 10022;
            this.recentAchievementsAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.recentAchievementsAutoOpenWindowCheckbox.UseVisualStyleBackColor = false;
            // 
            // recentAchievementsOpenWindowButton
            // 
            this.recentAchievementsOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsOpenWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsOpenWindowButton.Location = new System.Drawing.Point(245, 255);
            this.recentAchievementsOpenWindowButton.Name = "recentAchievementsOpenWindowButton";
            this.recentAchievementsOpenWindowButton.Size = new System.Drawing.Size(85, 28);
            this.recentAchievementsOpenWindowButton.TabIndex = 10021;
            this.recentAchievementsOpenWindowButton.Text = "Open";
            this.recentAchievementsOpenWindowButton.UseVisualStyleBackColor = true;
            // 
            // gameProgressRatioTextBox
            // 
            this.gameProgressRatioTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressRatioTextBox.Location = new System.Drawing.Point(185, 124);
            this.gameProgressRatioTextBox.Name = "gameProgressRatioTextBox";
            this.gameProgressRatioTextBox.Size = new System.Drawing.Size(140, 23);
            this.gameProgressRatioTextBox.TabIndex = 8;
            this.gameProgressRatioTextBox.Text = "Ratio";
            // 
            // userInfoTruePointsTextBox
            // 
            this.userInfoTruePointsTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoTruePointsTextBox.Location = new System.Drawing.Point(22, 150);
            this.userInfoTruePointsTextBox.Name = "userInfoTruePointsTextBox";
            this.userInfoTruePointsTextBox.Size = new System.Drawing.Size(140, 23);
            this.userInfoTruePointsTextBox.TabIndex = 7;
            this.userInfoTruePointsTextBox.Text = "T. Points";
            // 
            // userInfoPointsTextBox
            // 
            this.userInfoPointsTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoPointsTextBox.Location = new System.Drawing.Point(22, 124);
            this.userInfoPointsTextBox.Name = "userInfoPointsTextBox";
            this.userInfoPointsTextBox.Size = new System.Drawing.Size(140, 23);
            this.userInfoPointsTextBox.TabIndex = 6;
            this.userInfoPointsTextBox.Text = "Points";
            // 
            // userInfoRatioTextBox
            // 
            this.userInfoRatioTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRatioTextBox.Location = new System.Drawing.Point(22, 176);
            this.userInfoRatioTextBox.Name = "userInfoRatioTextBox";
            this.userInfoRatioTextBox.Size = new System.Drawing.Size(140, 23);
            this.userInfoRatioTextBox.TabIndex = 5;
            this.userInfoRatioTextBox.Text = "Ratio";
            // 
            // userInfoRankTextBox
            // 
            this.userInfoRankTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRankTextBox.Location = new System.Drawing.Point(22, 98);
            this.userInfoRankTextBox.Name = "userInfoRankTextBox";
            this.userInfoRankTextBox.Size = new System.Drawing.Size(140, 23);
            this.userInfoRankTextBox.TabIndex = 1;
            this.userInfoRankTextBox.Text = "Rank";
            // 
            // userInfoTruePointsCheckBox
            // 
            this.userInfoTruePointsCheckBox.AutoSize = true;
            this.userInfoTruePointsCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoTruePointsCheckBox.Location = new System.Drawing.Point(6, 153);
            this.userInfoTruePointsCheckBox.Name = "userInfoTruePointsCheckBox";
            this.userInfoTruePointsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.userInfoTruePointsCheckBox.TabIndex = 56;
            this.userInfoTruePointsCheckBox.UseVisualStyleBackColor = true;
            // 
            // userInfoRatioCheckBox
            // 
            this.userInfoRatioCheckBox.AutoSize = true;
            this.userInfoRatioCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRatioCheckBox.Location = new System.Drawing.Point(6, 179);
            this.userInfoRatioCheckBox.Name = "userInfoRatioCheckBox";
            this.userInfoRatioCheckBox.Size = new System.Drawing.Size(15, 14);
            this.userInfoRatioCheckBox.TabIndex = 55;
            this.userInfoRatioCheckBox.UseVisualStyleBackColor = true;
            // 
            // userInfoPointsCheckBox
            // 
            this.userInfoPointsCheckBox.AutoSize = true;
            this.userInfoPointsCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoPointsCheckBox.Location = new System.Drawing.Point(6, 128);
            this.userInfoPointsCheckBox.Name = "userInfoPointsCheckBox";
            this.userInfoPointsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.userInfoPointsCheckBox.TabIndex = 54;
            this.userInfoPointsCheckBox.UseVisualStyleBackColor = true;
            // 
            // userInfoDefaultButton
            // 
            this.userInfoDefaultButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoDefaultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userInfoDefaultButton.Location = new System.Drawing.Point(6, 210);
            this.userInfoDefaultButton.Name = "userInfoDefaultButton";
            this.userInfoDefaultButton.Size = new System.Drawing.Size(85, 28);
            this.userInfoDefaultButton.TabIndex = 39;
            this.userInfoDefaultButton.Text = "Default";
            this.userInfoDefaultButton.UseVisualStyleBackColor = true;
            // 
            // userInfoRankCheckBox
            // 
            this.userInfoRankCheckBox.AutoSize = true;
            this.userInfoRankCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRankCheckBox.Location = new System.Drawing.Point(6, 101);
            this.userInfoRankCheckBox.Name = "userInfoRankCheckBox";
            this.userInfoRankCheckBox.Size = new System.Drawing.Size(15, 14);
            this.userInfoRankCheckBox.TabIndex = 52;
            this.userInfoRankCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.Transparent;
            this.groupBox17.Controls.Add(this.gameProgressRadioButtonBackslash);
            this.groupBox17.Controls.Add(this.gameProgressRadioButtonSemicolon);
            this.groupBox17.Controls.Add(this.gameProgressRadioButtonDot);
            this.groupBox17.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.groupBox17.Location = new System.Drawing.Point(22, 6);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(140, 52);
            this.groupBox17.TabIndex = 57;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Separator";
            // 
            // gameProgressRadioButtonBackslash
            // 
            this.gameProgressRadioButtonBackslash.AutoSize = true;
            this.gameProgressRadioButtonBackslash.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressRadioButtonBackslash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressRadioButtonBackslash.Location = new System.Drawing.Point(6, 20);
            this.gameProgressRadioButtonBackslash.Name = "gameProgressRadioButtonBackslash";
            this.gameProgressRadioButtonBackslash.Size = new System.Drawing.Size(33, 22);
            this.gameProgressRadioButtonBackslash.TabIndex = 50;
            this.gameProgressRadioButtonBackslash.TabStop = true;
            this.gameProgressRadioButtonBackslash.Text = "/";
            this.gameProgressRadioButtonBackslash.UseVisualStyleBackColor = true;
            // 
            // gameProgressRadioButtonSemicolon
            // 
            this.gameProgressRadioButtonSemicolon.AutoSize = true;
            this.gameProgressRadioButtonSemicolon.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressRadioButtonSemicolon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressRadioButtonSemicolon.Location = new System.Drawing.Point(51, 20);
            this.gameProgressRadioButtonSemicolon.Name = "gameProgressRadioButtonSemicolon";
            this.gameProgressRadioButtonSemicolon.Size = new System.Drawing.Size(33, 22);
            this.gameProgressRadioButtonSemicolon.TabIndex = 53;
            this.gameProgressRadioButtonSemicolon.TabStop = true;
            this.gameProgressRadioButtonSemicolon.Text = ":";
            this.gameProgressRadioButtonSemicolon.UseVisualStyleBackColor = true;
            // 
            // gameProgressRadioButtonDot
            // 
            this.gameProgressRadioButtonDot.AutoSize = true;
            this.gameProgressRadioButtonDot.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressRadioButtonDot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressRadioButtonDot.Location = new System.Drawing.Point(102, 20);
            this.gameProgressRadioButtonDot.Name = "gameProgressRadioButtonDot";
            this.gameProgressRadioButtonDot.Size = new System.Drawing.Size(32, 22);
            this.gameProgressRadioButtonDot.TabIndex = 52;
            this.gameProgressRadioButtonDot.TabStop = true;
            this.gameProgressRadioButtonDot.Text = ".";
            this.gameProgressRadioButtonDot.UseVisualStyleBackColor = true;
            // 
            // gameProgressRatioCheckBox
            // 
            this.gameProgressRatioCheckBox.AutoSize = true;
            this.gameProgressRatioCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressRatioCheckBox.Location = new System.Drawing.Point(168, 127);
            this.gameProgressRatioCheckBox.Name = "gameProgressRatioCheckBox";
            this.gameProgressRatioCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressRatioCheckBox.TabIndex = 61;
            this.gameProgressRatioCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameProgressTruePointsCheckBox
            // 
            this.gameProgressTruePointsCheckBox.AutoSize = true;
            this.gameProgressTruePointsCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressTruePointsCheckBox.Location = new System.Drawing.Point(6, 153);
            this.gameProgressTruePointsCheckBox.Name = "gameProgressTruePointsCheckBox";
            this.gameProgressTruePointsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressTruePointsCheckBox.TabIndex = 60;
            this.gameProgressTruePointsCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameProgressPointsCheckBox
            // 
            this.gameProgressPointsCheckBox.AutoSize = true;
            this.gameProgressPointsCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressPointsCheckBox.Location = new System.Drawing.Point(6, 128);
            this.gameProgressPointsCheckBox.Name = "gameProgressPointsCheckBox";
            this.gameProgressPointsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressPointsCheckBox.TabIndex = 59;
            this.gameProgressPointsCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameProgressCompletedCheckBox
            // 
            this.gameProgressCompletedCheckBox.AutoSize = true;
            this.gameProgressCompletedCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressCompletedCheckBox.Location = new System.Drawing.Point(168, 101);
            this.gameProgressCompletedCheckBox.Name = "gameProgressCompletedCheckBox";
            this.gameProgressCompletedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressCompletedCheckBox.TabIndex = 58;
            this.gameProgressCompletedCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameProgressAchievementsCheckBox
            // 
            this.gameProgressAchievementsCheckBox.AutoSize = true;
            this.gameProgressAchievementsCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressAchievementsCheckBox.Location = new System.Drawing.Point(6, 101);
            this.gameProgressAchievementsCheckBox.Name = "gameProgressAchievementsCheckBox";
            this.gameProgressAchievementsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameProgressAchievementsCheckBox.TabIndex = 57;
            this.gameProgressAchievementsCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameProgressDefaultButton
            // 
            this.gameProgressDefaultButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressDefaultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameProgressDefaultButton.Location = new System.Drawing.Point(6, 210);
            this.gameProgressDefaultButton.Name = "gameProgressDefaultButton";
            this.gameProgressDefaultButton.Size = new System.Drawing.Size(85, 28);
            this.gameProgressDefaultButton.TabIndex = 44;
            this.gameProgressDefaultButton.Text = "Default";
            this.gameProgressDefaultButton.UseVisualStyleBackColor = true;
            // 
            // gameProgressAchievementsTextBox
            // 
            this.gameProgressAchievementsTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressAchievementsTextBox.Location = new System.Drawing.Point(22, 98);
            this.gameProgressAchievementsTextBox.Name = "gameProgressAchievementsTextBox";
            this.gameProgressAchievementsTextBox.Size = new System.Drawing.Size(140, 23);
            this.gameProgressAchievementsTextBox.TabIndex = 13;
            this.gameProgressAchievementsTextBox.Text = "Cheevos";
            // 
            // gameProgressPointsTextBox
            // 
            this.gameProgressPointsTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressPointsTextBox.Location = new System.Drawing.Point(22, 124);
            this.gameProgressPointsTextBox.Name = "gameProgressPointsTextBox";
            this.gameProgressPointsTextBox.Size = new System.Drawing.Size(140, 23);
            this.gameProgressPointsTextBox.TabIndex = 15;
            this.gameProgressPointsTextBox.Text = "Points";
            // 
            // gameProgressTruePointsTextBox
            // 
            this.gameProgressTruePointsTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressTruePointsTextBox.Location = new System.Drawing.Point(22, 150);
            this.gameProgressTruePointsTextBox.Name = "gameProgressTruePointsTextBox";
            this.gameProgressTruePointsTextBox.Size = new System.Drawing.Size(140, 23);
            this.gameProgressTruePointsTextBox.TabIndex = 16;
            this.gameProgressTruePointsTextBox.Text = "T. Points";
            // 
            // gameProgressCompletedTextBox
            // 
            this.gameProgressCompletedTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressCompletedTextBox.Location = new System.Drawing.Point(185, 98);
            this.gameProgressCompletedTextBox.Name = "gameProgressCompletedTextBox";
            this.gameProgressCompletedTextBox.Size = new System.Drawing.Size(140, 23);
            this.gameProgressCompletedTextBox.TabIndex = 48;
            this.gameProgressCompletedTextBox.Text = "Completed";
            // 
            // gameInfoReleasedCheckBox
            // 
            this.gameInfoReleasedCheckBox.AutoSize = true;
            this.gameInfoReleasedCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoReleasedCheckBox.Location = new System.Drawing.Point(168, 153);
            this.gameInfoReleasedCheckBox.Name = "gameInfoReleasedCheckBox";
            this.gameInfoReleasedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoReleasedCheckBox.TabIndex = 62;
            this.gameInfoReleasedCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameInfoConsoleCheckBox
            // 
            this.gameInfoConsoleCheckBox.AutoSize = true;
            this.gameInfoConsoleCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoConsoleCheckBox.Location = new System.Drawing.Point(168, 101);
            this.gameInfoConsoleCheckBox.Name = "gameInfoConsoleCheckBox";
            this.gameInfoConsoleCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoConsoleCheckBox.TabIndex = 61;
            this.gameInfoConsoleCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameInfoPublisherCheckBox
            // 
            this.gameInfoPublisherCheckBox.AutoSize = true;
            this.gameInfoPublisherCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoPublisherCheckBox.Location = new System.Drawing.Point(6, 153);
            this.gameInfoPublisherCheckBox.Name = "gameInfoPublisherCheckBox";
            this.gameInfoPublisherCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoPublisherCheckBox.TabIndex = 60;
            this.gameInfoPublisherCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameInfoGenreCheckBox
            // 
            this.gameInfoGenreCheckBox.AutoSize = true;
            this.gameInfoGenreCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoGenreCheckBox.Location = new System.Drawing.Point(168, 127);
            this.gameInfoGenreCheckBox.Name = "gameInfoGenreCheckBox";
            this.gameInfoGenreCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoGenreCheckBox.TabIndex = 59;
            this.gameInfoGenreCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameInfoDeveloperCheckBox
            // 
            this.gameInfoDeveloperCheckBox.AutoSize = true;
            this.gameInfoDeveloperCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDeveloperCheckBox.Location = new System.Drawing.Point(6, 128);
            this.gameInfoDeveloperCheckBox.Name = "gameInfoDeveloperCheckBox";
            this.gameInfoDeveloperCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoDeveloperCheckBox.TabIndex = 58;
            this.gameInfoDeveloperCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameInfoTitleCheckBox
            // 
            this.gameInfoTitleCheckBox.AutoSize = true;
            this.gameInfoTitleCheckBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoTitleCheckBox.Location = new System.Drawing.Point(6, 101);
            this.gameInfoTitleCheckBox.Name = "gameInfoTitleCheckBox";
            this.gameInfoTitleCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gameInfoTitleCheckBox.TabIndex = 57;
            this.gameInfoTitleCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameInfoTitleTextBox
            // 
            this.gameInfoTitleTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoTitleTextBox.Location = new System.Drawing.Point(22, 98);
            this.gameInfoTitleTextBox.Name = "gameInfoTitleTextBox";
            this.gameInfoTitleTextBox.Size = new System.Drawing.Size(140, 23);
            this.gameInfoTitleTextBox.TabIndex = 53;
            this.gameInfoTitleTextBox.Text = "Title";
            // 
            // gameInfoDefaultButton
            // 
            this.gameInfoDefaultButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDefaultButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameInfoDefaultButton.Location = new System.Drawing.Point(6, 210);
            this.gameInfoDefaultButton.Name = "gameInfoDefaultButton";
            this.gameInfoDefaultButton.Size = new System.Drawing.Size(85, 28);
            this.gameInfoDefaultButton.TabIndex = 40;
            this.gameInfoDefaultButton.Text = "Default";
            this.gameInfoDefaultButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoGenreTextBox
            // 
            this.gameInfoGenreTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoGenreTextBox.Location = new System.Drawing.Point(185, 124);
            this.gameInfoGenreTextBox.Name = "gameInfoGenreTextBox";
            this.gameInfoGenreTextBox.Size = new System.Drawing.Size(140, 23);
            this.gameInfoGenreTextBox.TabIndex = 25;
            this.gameInfoGenreTextBox.Text = "Genre";
            // 
            // gameInfoConsoleTextBox
            // 
            this.gameInfoConsoleTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoConsoleTextBox.Location = new System.Drawing.Point(185, 98);
            this.gameInfoConsoleTextBox.Name = "gameInfoConsoleTextBox";
            this.gameInfoConsoleTextBox.Size = new System.Drawing.Size(140, 23);
            this.gameInfoConsoleTextBox.TabIndex = 19;
            this.gameInfoConsoleTextBox.Text = "Console";
            // 
            // gameInfoPublisherTextBox
            // 
            this.gameInfoPublisherTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoPublisherTextBox.Location = new System.Drawing.Point(22, 150);
            this.gameInfoPublisherTextBox.Name = "gameInfoPublisherTextBox";
            this.gameInfoPublisherTextBox.Size = new System.Drawing.Size(140, 23);
            this.gameInfoPublisherTextBox.TabIndex = 24;
            this.gameInfoPublisherTextBox.Text = "Publisher";
            // 
            // gameInfoReleaseDateTextBox
            // 
            this.gameInfoReleaseDateTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoReleaseDateTextBox.Location = new System.Drawing.Point(185, 150);
            this.gameInfoReleaseDateTextBox.Name = "gameInfoReleaseDateTextBox";
            this.gameInfoReleaseDateTextBox.Size = new System.Drawing.Size(140, 23);
            this.gameInfoReleaseDateTextBox.TabIndex = 23;
            this.gameInfoReleaseDateTextBox.Text = "Released";
            // 
            // gameInfoDeveloperTextBox
            // 
            this.gameInfoDeveloperTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDeveloperTextBox.Location = new System.Drawing.Point(22, 124);
            this.gameInfoDeveloperTextBox.Name = "gameInfoDeveloperTextBox";
            this.gameInfoDeveloperTextBox.Size = new System.Drawing.Size(140, 23);
            this.gameInfoDeveloperTextBox.TabIndex = 21;
            this.gameInfoDeveloperTextBox.Text = "Developer";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gameInfoBackgroundColorGroupBox
            // 
            this.gameInfoBackgroundColorGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.gameInfoBackgroundColorGroupBox.Controls.Add(this.gameInfoSetBackgroundColorButton);
            this.gameInfoBackgroundColorGroupBox.Controls.Add(this.gameInfoBackgroundColorPictureBox);
            this.gameInfoBackgroundColorGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoBackgroundColorGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameInfoBackgroundColorGroupBox.Location = new System.Drawing.Point(339, 6);
            this.gameInfoBackgroundColorGroupBox.Name = "gameInfoBackgroundColorGroupBox";
            this.gameInfoBackgroundColorGroupBox.Size = new System.Drawing.Size(80, 49);
            this.gameInfoBackgroundColorGroupBox.TabIndex = 50;
            this.gameInfoBackgroundColorGroupBox.TabStop = false;
            this.gameInfoBackgroundColorGroupBox.Text = "Back";
            // 
            // gameInfoSetBackgroundColorButton
            // 
            this.gameInfoSetBackgroundColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoSetBackgroundColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameInfoSetBackgroundColorButton.Location = new System.Drawing.Point(6, 20);
            this.gameInfoSetBackgroundColorButton.Name = "gameInfoSetBackgroundColorButton";
            this.gameInfoSetBackgroundColorButton.Size = new System.Drawing.Size(36, 23);
            this.gameInfoSetBackgroundColorButton.TabIndex = 43;
            this.gameInfoSetBackgroundColorButton.Text = "Set";
            this.gameInfoSetBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoBackgroundColorPictureBox
            // 
            this.gameInfoBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoBackgroundColorPictureBox.Location = new System.Drawing.Point(48, 20);
            this.gameInfoBackgroundColorPictureBox.Name = "gameInfoBackgroundColorPictureBox";
            this.gameInfoBackgroundColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameInfoBackgroundColorPictureBox.TabIndex = 42;
            this.gameInfoBackgroundColorPictureBox.TabStop = false;
            // 
            // gameInfoValuesGroupBox
            // 
            this.gameInfoValuesGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoValuesGroupBox.Controls.Add(this.gameInfoValuesFontOutlineColorBoxButton);
            this.gameInfoValuesGroupBox.Controls.Add(this.gameInfoValuesFontOutlineColorPictureBox);
            this.gameInfoValuesGroupBox.Controls.Add(this.gameInfoValuesFontColorBoxButton);
            this.gameInfoValuesGroupBox.Controls.Add(this.gameInfoValuesOutlineCheckBox);
            this.gameInfoValuesGroupBox.Controls.Add(this.gameInfoValuesFontOutlineNumericUpDown);
            this.gameInfoValuesGroupBox.Controls.Add(this.gameInfoValuesFontColorPictureBox);
            this.gameInfoValuesGroupBox.Controls.Add(this.gameInfoValuesFontComboBox);
            this.gameInfoValuesGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoValuesGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameInfoValuesGroupBox.Location = new System.Drawing.Point(596, 6);
            this.gameInfoValuesGroupBox.Name = "gameInfoValuesGroupBox";
            this.gameInfoValuesGroupBox.Size = new System.Drawing.Size(165, 125);
            this.gameInfoValuesGroupBox.TabIndex = 47;
            this.gameInfoValuesGroupBox.TabStop = false;
            this.gameInfoValuesGroupBox.Text = "Values";
            // 
            // gameInfoValuesFontOutlineColorBoxButton
            // 
            this.gameInfoValuesFontOutlineColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoValuesFontOutlineColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameInfoValuesFontOutlineColorBoxButton.Location = new System.Drawing.Point(5, 95);
            this.gameInfoValuesFontOutlineColorBoxButton.Name = "gameInfoValuesFontOutlineColorBoxButton";
            this.gameInfoValuesFontOutlineColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameInfoValuesFontOutlineColorBoxButton.TabIndex = 45;
            this.gameInfoValuesFontOutlineColorBoxButton.Text = "Set";
            this.gameInfoValuesFontOutlineColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoValuesFontOutlineColorPictureBox
            // 
            this.gameInfoValuesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoValuesFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.gameInfoValuesFontOutlineColorPictureBox.Name = "gameInfoValuesFontOutlineColorPictureBox";
            this.gameInfoValuesFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameInfoValuesFontOutlineColorPictureBox.TabIndex = 45;
            this.gameInfoValuesFontOutlineColorPictureBox.TabStop = false;
            // 
            // gameInfoValuesFontColorBoxButton
            // 
            this.gameInfoValuesFontColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoValuesFontColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameInfoValuesFontColorBoxButton.Location = new System.Drawing.Point(5, 45);
            this.gameInfoValuesFontColorBoxButton.Name = "gameInfoValuesFontColorBoxButton";
            this.gameInfoValuesFontColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameInfoValuesFontColorBoxButton.TabIndex = 45;
            this.gameInfoValuesFontColorBoxButton.Text = "Set";
            this.gameInfoValuesFontColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoValuesOutlineCheckBox
            // 
            this.gameInfoValuesOutlineCheckBox.AutoSize = true;
            this.gameInfoValuesOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoValuesOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoValuesOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.gameInfoValuesOutlineCheckBox.Name = "gameInfoValuesOutlineCheckBox";
            this.gameInfoValuesOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.gameInfoValuesOutlineCheckBox.TabIndex = 45;
            this.gameInfoValuesOutlineCheckBox.Text = "Outline";
            this.gameInfoValuesOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameInfoValuesFontOutlineNumericUpDown
            // 
            this.gameInfoValuesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoValuesFontOutlineNumericUpDown.Location = new System.Drawing.Point(91, 97);
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
            this.gameInfoValuesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.gameInfoValuesFontOutlineNumericUpDown.TabIndex = 45;
            this.gameInfoValuesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gameInfoValuesFontColorPictureBox
            // 
            this.gameInfoValuesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoValuesFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.gameInfoValuesFontColorPictureBox.Name = "gameInfoValuesFontColorPictureBox";
            this.gameInfoValuesFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameInfoValuesFontColorPictureBox.TabIndex = 45;
            this.gameInfoValuesFontColorPictureBox.TabStop = false;
            // 
            // gameInfoValuesFontComboBox
            // 
            this.gameInfoValuesFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoValuesFontComboBox.FormattingEnabled = true;
            this.gameInfoValuesFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.gameInfoValuesFontComboBox.Name = "gameInfoValuesFontComboBox";
            this.gameInfoValuesFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.gameInfoValuesFontComboBox.TabIndex = 45;
            // 
            // gameInfoNamesGroupBox
            // 
            this.gameInfoNamesGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoNamesGroupBox.Controls.Add(this.gameInfoNamesFontOutlineColorBoxButton);
            this.gameInfoNamesGroupBox.Controls.Add(this.gameInfoNamesFontOutlineColorPictureBox);
            this.gameInfoNamesGroupBox.Controls.Add(this.gameInfoNamesFontColorBoxButton);
            this.gameInfoNamesGroupBox.Controls.Add(this.gameInfoNamesOutlineCheckBox);
            this.gameInfoNamesGroupBox.Controls.Add(this.gameInfoNamesFontOutlineNumericUpDown);
            this.gameInfoNamesGroupBox.Controls.Add(this.gameInfoNamesFontColorPictureBox);
            this.gameInfoNamesGroupBox.Controls.Add(this.gameInfoNamesFontComboBox);
            this.gameInfoNamesGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoNamesGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameInfoNamesGroupBox.Location = new System.Drawing.Point(425, 6);
            this.gameInfoNamesGroupBox.Name = "gameInfoNamesGroupBox";
            this.gameInfoNamesGroupBox.Size = new System.Drawing.Size(165, 125);
            this.gameInfoNamesGroupBox.TabIndex = 46;
            this.gameInfoNamesGroupBox.TabStop = false;
            this.gameInfoNamesGroupBox.Text = "Names";
            // 
            // gameInfoNamesFontOutlineColorBoxButton
            // 
            this.gameInfoNamesFontOutlineColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoNamesFontOutlineColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameInfoNamesFontOutlineColorBoxButton.Location = new System.Drawing.Point(5, 95);
            this.gameInfoNamesFontOutlineColorBoxButton.Name = "gameInfoNamesFontOutlineColorBoxButton";
            this.gameInfoNamesFontOutlineColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameInfoNamesFontOutlineColorBoxButton.TabIndex = 45;
            this.gameInfoNamesFontOutlineColorBoxButton.Text = "Set";
            this.gameInfoNamesFontOutlineColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoNamesFontOutlineColorPictureBox
            // 
            this.gameInfoNamesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoNamesFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.gameInfoNamesFontOutlineColorPictureBox.Name = "gameInfoNamesFontOutlineColorPictureBox";
            this.gameInfoNamesFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameInfoNamesFontOutlineColorPictureBox.TabIndex = 45;
            this.gameInfoNamesFontOutlineColorPictureBox.TabStop = false;
            // 
            // gameInfoNamesFontColorBoxButton
            // 
            this.gameInfoNamesFontColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoNamesFontColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameInfoNamesFontColorBoxButton.Location = new System.Drawing.Point(5, 45);
            this.gameInfoNamesFontColorBoxButton.Name = "gameInfoNamesFontColorBoxButton";
            this.gameInfoNamesFontColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameInfoNamesFontColorBoxButton.TabIndex = 45;
            this.gameInfoNamesFontColorBoxButton.Text = "Set";
            this.gameInfoNamesFontColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoNamesOutlineCheckBox
            // 
            this.gameInfoNamesOutlineCheckBox.AutoSize = true;
            this.gameInfoNamesOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoNamesOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoNamesOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.gameInfoNamesOutlineCheckBox.Name = "gameInfoNamesOutlineCheckBox";
            this.gameInfoNamesOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.gameInfoNamesOutlineCheckBox.TabIndex = 45;
            this.gameInfoNamesOutlineCheckBox.Text = "Outline";
            this.gameInfoNamesOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameInfoNamesFontOutlineNumericUpDown
            // 
            this.gameInfoNamesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoNamesFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
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
            this.gameInfoNamesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.gameInfoNamesFontOutlineNumericUpDown.TabIndex = 45;
            this.gameInfoNamesFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gameInfoNamesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gameInfoNamesFontColorPictureBox
            // 
            this.gameInfoNamesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoNamesFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.gameInfoNamesFontColorPictureBox.Name = "gameInfoNamesFontColorPictureBox";
            this.gameInfoNamesFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameInfoNamesFontColorPictureBox.TabIndex = 45;
            this.gameInfoNamesFontColorPictureBox.TabStop = false;
            // 
            // gameInfoNamesFontComboBox
            // 
            this.gameInfoNamesFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoNamesFontComboBox.FormattingEnabled = true;
            this.gameInfoNamesFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.gameInfoNamesFontComboBox.Name = "gameInfoNamesFontComboBox";
            this.gameInfoNamesFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.gameInfoNamesFontComboBox.TabIndex = 45;
            // 
            // achievementListAutoOpenWindowCheckbox
            // 
            this.achievementListAutoOpenWindowCheckbox.AutoSize = true;
            this.achievementListAutoOpenWindowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.achievementListAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementListAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.achievementListAutoOpenWindowCheckbox.Location = new System.Drawing.Point(6, 260);
            this.achievementListAutoOpenWindowCheckbox.Name = "achievementListAutoOpenWindowCheckbox";
            this.achievementListAutoOpenWindowCheckbox.Size = new System.Drawing.Size(115, 22);
            this.achievementListAutoOpenWindowCheckbox.TabIndex = 10022;
            this.achievementListAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.achievementListAutoOpenWindowCheckbox.UseVisualStyleBackColor = false;
            // 
            // achievementListOpenWindowButton
            // 
            this.achievementListOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementListOpenWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.achievementListOpenWindowButton.Location = new System.Drawing.Point(245, 255);
            this.achievementListOpenWindowButton.Name = "achievementListOpenWindowButton";
            this.achievementListOpenWindowButton.Size = new System.Drawing.Size(85, 28);
            this.achievementListOpenWindowButton.TabIndex = 10021;
            this.achievementListOpenWindowButton.Text = "Open";
            this.achievementListOpenWindowButton.UseVisualStyleBackColor = true;
            // 
            // gameProgressAutoOpenWindowCheckbox
            // 
            this.gameProgressAutoOpenWindowCheckbox.AutoSize = true;
            this.gameProgressAutoOpenWindowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressAutoOpenWindowCheckbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressAutoOpenWindowCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressAutoOpenWindowCheckbox.Location = new System.Drawing.Point(6, 260);
            this.gameProgressAutoOpenWindowCheckbox.Name = "gameProgressAutoOpenWindowCheckbox";
            this.gameProgressAutoOpenWindowCheckbox.Size = new System.Drawing.Size(115, 22);
            this.gameProgressAutoOpenWindowCheckbox.TabIndex = 10022;
            this.gameProgressAutoOpenWindowCheckbox.Text = "Auto-Open";
            this.gameProgressAutoOpenWindowCheckbox.UseVisualStyleBackColor = false;
            // 
            // gameProgressOpenWindowButton
            // 
            this.gameProgressOpenWindowButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressOpenWindowButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameProgressOpenWindowButton.Location = new System.Drawing.Point(245, 255);
            this.gameProgressOpenWindowButton.Name = "gameProgressOpenWindowButton";
            this.gameProgressOpenWindowButton.Size = new System.Drawing.Size(85, 28);
            this.gameProgressOpenWindowButton.TabIndex = 10021;
            this.gameProgressOpenWindowButton.Text = "Open";
            this.gameProgressOpenWindowButton.UseVisualStyleBackColor = true;
            // 
            // focusBehaviorGroupBox
            // 
            this.focusBehaviorGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.focusBehaviorGroupBox.Controls.Add(this.focusBehaviorGoToLastRadioButton);
            this.focusBehaviorGroupBox.Controls.Add(this.focusBehaviorGoToNextRadioButton);
            this.focusBehaviorGroupBox.Controls.Add(this.focusBehaviorGoToPreviousRadioButton);
            this.focusBehaviorGroupBox.Controls.Add(this.focusBehaviorGoToFirstRadioButton);
            this.focusBehaviorGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusBehaviorGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusBehaviorGroupBox.Location = new System.Drawing.Point(6, 192);
            this.focusBehaviorGroupBox.Name = "focusBehaviorGroupBox";
            this.focusBehaviorGroupBox.Size = new System.Drawing.Size(324, 63);
            this.focusBehaviorGroupBox.TabIndex = 10009;
            this.focusBehaviorGroupBox.TabStop = false;
            this.focusBehaviorGroupBox.Text = "Refocus Behavior";
            // 
            // focusBehaviorGoToLastRadioButton
            // 
            this.focusBehaviorGoToLastRadioButton.AutoSize = true;
            this.focusBehaviorGoToLastRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusBehaviorGoToLastRadioButton.Location = new System.Drawing.Point(176, 37);
            this.focusBehaviorGoToLastRadioButton.Name = "focusBehaviorGoToLastRadioButton";
            this.focusBehaviorGoToLastRadioButton.Size = new System.Drawing.Size(112, 22);
            this.focusBehaviorGoToLastRadioButton.TabIndex = 3;
            this.focusBehaviorGoToLastRadioButton.Text = "Go to Last";
            this.focusBehaviorGoToLastRadioButton.UseVisualStyleBackColor = true;
            // 
            // focusBehaviorGoToNextRadioButton
            // 
            this.focusBehaviorGoToNextRadioButton.AutoSize = true;
            this.focusBehaviorGoToNextRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusBehaviorGoToNextRadioButton.Location = new System.Drawing.Point(176, 16);
            this.focusBehaviorGoToNextRadioButton.Name = "focusBehaviorGoToNextRadioButton";
            this.focusBehaviorGoToNextRadioButton.Size = new System.Drawing.Size(115, 22);
            this.focusBehaviorGoToNextRadioButton.TabIndex = 2;
            this.focusBehaviorGoToNextRadioButton.Text = "Go to Next";
            this.focusBehaviorGoToNextRadioButton.UseVisualStyleBackColor = true;
            // 
            // focusBehaviorGoToPreviousRadioButton
            // 
            this.focusBehaviorGoToPreviousRadioButton.AutoSize = true;
            this.focusBehaviorGoToPreviousRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusBehaviorGoToPreviousRadioButton.Location = new System.Drawing.Point(6, 37);
            this.focusBehaviorGoToPreviousRadioButton.Name = "focusBehaviorGoToPreviousRadioButton";
            this.focusBehaviorGoToPreviousRadioButton.Size = new System.Drawing.Size(146, 22);
            this.focusBehaviorGoToPreviousRadioButton.TabIndex = 1;
            this.focusBehaviorGoToPreviousRadioButton.Text = "Go to Previous";
            this.focusBehaviorGoToPreviousRadioButton.UseVisualStyleBackColor = true;
            // 
            // focusBehaviorGoToFirstRadioButton
            // 
            this.focusBehaviorGoToFirstRadioButton.AutoSize = true;
            this.focusBehaviorGoToFirstRadioButton.Checked = true;
            this.focusBehaviorGoToFirstRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusBehaviorGoToFirstRadioButton.Location = new System.Drawing.Point(6, 16);
            this.focusBehaviorGoToFirstRadioButton.Name = "focusBehaviorGoToFirstRadioButton";
            this.focusBehaviorGoToFirstRadioButton.Size = new System.Drawing.Size(113, 22);
            this.focusBehaviorGoToFirstRadioButton.TabIndex = 0;
            this.focusBehaviorGoToFirstRadioButton.TabStop = true;
            this.focusBehaviorGoToFirstRadioButton.Text = "Go to First";
            this.focusBehaviorGoToFirstRadioButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsMaxListLabel
            // 
            this.recentAchievementsMaxListLabel.AutoSize = true;
            this.recentAchievementsMaxListLabel.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsMaxListLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsMaxListLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsMaxListLabel.Location = new System.Drawing.Point(3, 6);
            this.recentAchievementsMaxListLabel.Name = "recentAchievementsMaxListLabel";
            this.recentAchievementsMaxListLabel.Size = new System.Drawing.Size(116, 18);
            this.recentAchievementsMaxListLabel.TabIndex = 10015;
            this.recentAchievementsMaxListLabel.Text = "Max List Size";
            // 
            // recentAchievementsMaxListNumericUpDown
            // 
            this.recentAchievementsMaxListNumericUpDown.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsMaxListNumericUpDown.Location = new System.Drawing.Point(7, 30);
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
            // achievementListScrollCheckBox
            // 
            this.achievementListScrollCheckBox.AutoSize = true;
            this.achievementListScrollCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.achievementListScrollCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementListScrollCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.achievementListScrollCheckBox.Location = new System.Drawing.Point(343, 178);
            this.achievementListScrollCheckBox.Name = "achievementListScrollCheckBox";
            this.achievementListScrollCheckBox.Size = new System.Drawing.Size(71, 22);
            this.achievementListScrollCheckBox.TabIndex = 10013;
            this.achievementListScrollCheckBox.Text = "Scroll";
            this.achievementListScrollCheckBox.UseVisualStyleBackColor = false;
            // 
            // webBrowserAutoOpenCheckbox
            // 
            this.webBrowserAutoOpenCheckbox.AutoSize = true;
            this.webBrowserAutoOpenCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.webBrowserAutoOpenCheckbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webBrowserAutoOpenCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.webBrowserAutoOpenCheckbox.Location = new System.Drawing.Point(6, 260);
            this.webBrowserAutoOpenCheckbox.Name = "webBrowserAutoOpenCheckbox";
            this.webBrowserAutoOpenCheckbox.Size = new System.Drawing.Size(115, 22);
            this.webBrowserAutoOpenCheckbox.TabIndex = 10022;
            this.webBrowserAutoOpenCheckbox.Text = "Auto-Open";
            this.webBrowserAutoOpenCheckbox.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(777, 320);
            this.tabControl1.TabIndex = 10030;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tabPage1.Controls.Add(this.userInfoRatioLabel);
            this.tabPage1.Controls.Add(this.userInfoTruePointsLabel);
            this.tabPage1.Controls.Add(this.userInfoPointsLabel);
            this.tabPage1.Controls.Add(this.userInfoRankLabel);
            this.tabPage1.Controls.Add(this.userInfoSimpleCheckBox);
            this.tabPage1.Controls.Add(this.userInfoBackgroundColorGroupBox);
            this.tabPage1.Controls.Add(this.userInfoValuesGroupBox);
            this.tabPage1.Controls.Add(this.userProfilePictureBox);
            this.tabPage1.Controls.Add(this.userInfoDefaultButton);
            this.tabPage1.Controls.Add(this.usernameLabel);
            this.tabPage1.Controls.Add(this.userInfoTruePointsCheckBox);
            this.tabPage1.Controls.Add(this.apiKeyTextBox);
            this.tabPage1.Controls.Add(this.usernameTextBox);
            this.tabPage1.Controls.Add(this.userInfoRatioCheckBox);
            this.tabPage1.Controls.Add(this.startButton);
            this.tabPage1.Controls.Add(this.userInfoRankTextBox);
            this.tabPage1.Controls.Add(this.apiKeyLabel);
            this.tabPage1.Controls.Add(this.userInfoPointsCheckBox);
            this.tabPage1.Controls.Add(this.userInfoRatioTextBox);
            this.tabPage1.Controls.Add(this.userInfoPointsTextBox);
            this.tabPage1.Controls.Add(this.autoStartCheckbox);
            this.tabPage1.Controls.Add(this.userInfoAutoOpenWindowCheckbox);
            this.tabPage1.Controls.Add(this.userInfoTruePointsTextBox);
            this.tabPage1.Controls.Add(this.userInfoOpenWindowButton);
            this.tabPage1.Controls.Add(this.userInfoRankCheckBox);
            this.tabPage1.Controls.Add(this.stopButton);
            this.tabPage1.Controls.Add(this.userInfoNamesGroupBox);
            this.tabPage1.Controls.Add(this.userInfoSimpleGroupBox);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(769, 292);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User Info";
            // 
            // userInfoRatioLabel
            // 
            this.userInfoRatioLabel.BackColor = System.Drawing.Color.Transparent;
            this.userInfoRatioLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRatioLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoRatioLabel.Location = new System.Drawing.Point(422, 213);
            this.userInfoRatioLabel.Name = "userInfoRatioLabel";
            this.userInfoRatioLabel.Size = new System.Drawing.Size(339, 26);
            this.userInfoRatioLabel.TabIndex = 10057;
            // 
            // userInfoTruePointsLabel
            // 
            this.userInfoTruePointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.userInfoTruePointsLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoTruePointsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoTruePointsLabel.Location = new System.Drawing.Point(422, 186);
            this.userInfoTruePointsLabel.Name = "userInfoTruePointsLabel";
            this.userInfoTruePointsLabel.Size = new System.Drawing.Size(339, 26);
            this.userInfoTruePointsLabel.TabIndex = 10056;
            // 
            // userInfoPointsLabel
            // 
            this.userInfoPointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.userInfoPointsLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoPointsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoPointsLabel.Location = new System.Drawing.Point(422, 160);
            this.userInfoPointsLabel.Name = "userInfoPointsLabel";
            this.userInfoPointsLabel.Size = new System.Drawing.Size(339, 26);
            this.userInfoPointsLabel.TabIndex = 10055;
            // 
            // userInfoRankLabel
            // 
            this.userInfoRankLabel.BackColor = System.Drawing.Color.Transparent;
            this.userInfoRankLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoRankLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoRankLabel.Location = new System.Drawing.Point(422, 134);
            this.userInfoRankLabel.Name = "userInfoRankLabel";
            this.userInfoRankLabel.Size = new System.Drawing.Size(339, 26);
            this.userInfoRankLabel.TabIndex = 10054;
            // 
            // userInfoSimpleCheckBox
            // 
            this.userInfoSimpleCheckBox.AutoSize = true;
            this.userInfoSimpleCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.userInfoSimpleCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoSimpleCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoSimpleCheckBox.Location = new System.Drawing.Point(343, 120);
            this.userInfoSimpleCheckBox.Name = "userInfoSimpleCheckBox";
            this.userInfoSimpleCheckBox.Size = new System.Drawing.Size(82, 22);
            this.userInfoSimpleCheckBox.TabIndex = 10053;
            this.userInfoSimpleCheckBox.Text = "Simple";
            this.userInfoSimpleCheckBox.UseVisualStyleBackColor = false;
            // 
            // userInfoBackgroundColorGroupBox
            // 
            this.userInfoBackgroundColorGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.userInfoBackgroundColorGroupBox.Controls.Add(this.userInfoSetBackgroundColorButton);
            this.userInfoBackgroundColorGroupBox.Controls.Add(this.userInfoBackgroundColorPictureBox);
            this.userInfoBackgroundColorGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoBackgroundColorGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.userInfoBackgroundColorGroupBox.Location = new System.Drawing.Point(339, 6);
            this.userInfoBackgroundColorGroupBox.Name = "userInfoBackgroundColorGroupBox";
            this.userInfoBackgroundColorGroupBox.Size = new System.Drawing.Size(80, 49);
            this.userInfoBackgroundColorGroupBox.TabIndex = 10039;
            this.userInfoBackgroundColorGroupBox.TabStop = false;
            this.userInfoBackgroundColorGroupBox.Text = "Back";
            // 
            // userInfoSetBackgroundColorButton
            // 
            this.userInfoSetBackgroundColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoSetBackgroundColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userInfoSetBackgroundColorButton.Location = new System.Drawing.Point(6, 20);
            this.userInfoSetBackgroundColorButton.Name = "userInfoSetBackgroundColorButton";
            this.userInfoSetBackgroundColorButton.Size = new System.Drawing.Size(36, 23);
            this.userInfoSetBackgroundColorButton.TabIndex = 43;
            this.userInfoSetBackgroundColorButton.Text = "Set";
            this.userInfoSetBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // userInfoBackgroundColorPictureBox
            // 
            this.userInfoBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoBackgroundColorPictureBox.Location = new System.Drawing.Point(48, 20);
            this.userInfoBackgroundColorPictureBox.Name = "userInfoBackgroundColorPictureBox";
            this.userInfoBackgroundColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.userInfoBackgroundColorPictureBox.TabIndex = 42;
            this.userInfoBackgroundColorPictureBox.TabStop = false;
            // 
            // userInfoValuesGroupBox
            // 
            this.userInfoValuesGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.userInfoValuesGroupBox.Controls.Add(this.userInfoValuesFontOutlineColorBoxButton);
            this.userInfoValuesGroupBox.Controls.Add(this.userInfoValuesFontOutlineColorPictureBox);
            this.userInfoValuesGroupBox.Controls.Add(this.userInfoValuesFontColorBoxButton);
            this.userInfoValuesGroupBox.Controls.Add(this.userInfoValuesOutlineCheckBox);
            this.userInfoValuesGroupBox.Controls.Add(this.userInfoValuesFontOutlineNumericUpDown);
            this.userInfoValuesGroupBox.Controls.Add(this.userInfoValuesFontColorPictureBox);
            this.userInfoValuesGroupBox.Controls.Add(this.userInfoValuesFontComboBox);
            this.userInfoValuesGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoValuesGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.userInfoValuesGroupBox.Location = new System.Drawing.Point(596, 6);
            this.userInfoValuesGroupBox.Name = "userInfoValuesGroupBox";
            this.userInfoValuesGroupBox.Size = new System.Drawing.Size(165, 125);
            this.userInfoValuesGroupBox.TabIndex = 10036;
            this.userInfoValuesGroupBox.TabStop = false;
            this.userInfoValuesGroupBox.Text = "Values";
            // 
            // userInfoValuesFontOutlineColorBoxButton
            // 
            this.userInfoValuesFontOutlineColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoValuesFontOutlineColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userInfoValuesFontOutlineColorBoxButton.Location = new System.Drawing.Point(5, 95);
            this.userInfoValuesFontOutlineColorBoxButton.Name = "userInfoValuesFontOutlineColorBoxButton";
            this.userInfoValuesFontOutlineColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.userInfoValuesFontOutlineColorBoxButton.TabIndex = 45;
            this.userInfoValuesFontOutlineColorBoxButton.Text = "Set";
            this.userInfoValuesFontOutlineColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // userInfoValuesFontOutlineColorPictureBox
            // 
            this.userInfoValuesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoValuesFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.userInfoValuesFontOutlineColorPictureBox.Name = "userInfoValuesFontOutlineColorPictureBox";
            this.userInfoValuesFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.userInfoValuesFontOutlineColorPictureBox.TabIndex = 45;
            this.userInfoValuesFontOutlineColorPictureBox.TabStop = false;
            // 
            // userInfoValuesFontColorBoxButton
            // 
            this.userInfoValuesFontColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoValuesFontColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userInfoValuesFontColorBoxButton.Location = new System.Drawing.Point(5, 45);
            this.userInfoValuesFontColorBoxButton.Name = "userInfoValuesFontColorBoxButton";
            this.userInfoValuesFontColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.userInfoValuesFontColorBoxButton.TabIndex = 45;
            this.userInfoValuesFontColorBoxButton.Text = "Set";
            this.userInfoValuesFontColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // userInfoValuesOutlineCheckBox
            // 
            this.userInfoValuesOutlineCheckBox.AutoSize = true;
            this.userInfoValuesOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoValuesOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoValuesOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.userInfoValuesOutlineCheckBox.Name = "userInfoValuesOutlineCheckBox";
            this.userInfoValuesOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.userInfoValuesOutlineCheckBox.TabIndex = 45;
            this.userInfoValuesOutlineCheckBox.Text = "Outline";
            this.userInfoValuesOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // userInfoValuesFontOutlineNumericUpDown
            // 
            this.userInfoValuesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoValuesFontOutlineNumericUpDown.Location = new System.Drawing.Point(91, 97);
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
            this.userInfoValuesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.userInfoValuesFontOutlineNumericUpDown.TabIndex = 45;
            this.userInfoValuesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // userInfoValuesFontColorPictureBox
            // 
            this.userInfoValuesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoValuesFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.userInfoValuesFontColorPictureBox.Name = "userInfoValuesFontColorPictureBox";
            this.userInfoValuesFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.userInfoValuesFontColorPictureBox.TabIndex = 45;
            this.userInfoValuesFontColorPictureBox.TabStop = false;
            // 
            // userInfoValuesFontComboBox
            // 
            this.userInfoValuesFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoValuesFontComboBox.FormattingEnabled = true;
            this.userInfoValuesFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.userInfoValuesFontComboBox.Name = "userInfoValuesFontComboBox";
            this.userInfoValuesFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.userInfoValuesFontComboBox.TabIndex = 45;
            // 
            // userInfoNamesGroupBox
            // 
            this.userInfoNamesGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.userInfoNamesGroupBox.Controls.Add(this.userInfoNamesFontOutlineColorBoxButton);
            this.userInfoNamesGroupBox.Controls.Add(this.userInfoNamesFontOutlineColorPictureBox);
            this.userInfoNamesGroupBox.Controls.Add(this.userInfoNamesFontColorBoxButton);
            this.userInfoNamesGroupBox.Controls.Add(this.userInfoNamesOutlineCheckBox);
            this.userInfoNamesGroupBox.Controls.Add(this.userInfoNamesFontOutlineNumericUpDown);
            this.userInfoNamesGroupBox.Controls.Add(this.userInfoNamesFontColorPictureBox);
            this.userInfoNamesGroupBox.Controls.Add(this.userInfoNamesFontComboBox);
            this.userInfoNamesGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoNamesGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.userInfoNamesGroupBox.Location = new System.Drawing.Point(425, 6);
            this.userInfoNamesGroupBox.Name = "userInfoNamesGroupBox";
            this.userInfoNamesGroupBox.Size = new System.Drawing.Size(165, 125);
            this.userInfoNamesGroupBox.TabIndex = 10035;
            this.userInfoNamesGroupBox.TabStop = false;
            this.userInfoNamesGroupBox.Text = "Names";
            // 
            // userInfoNamesFontOutlineColorBoxButton
            // 
            this.userInfoNamesFontOutlineColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoNamesFontOutlineColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userInfoNamesFontOutlineColorBoxButton.Location = new System.Drawing.Point(5, 95);
            this.userInfoNamesFontOutlineColorBoxButton.Name = "userInfoNamesFontOutlineColorBoxButton";
            this.userInfoNamesFontOutlineColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.userInfoNamesFontOutlineColorBoxButton.TabIndex = 45;
            this.userInfoNamesFontOutlineColorBoxButton.Text = "Set";
            this.userInfoNamesFontOutlineColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // userInfoNamesFontOutlineColorPictureBox
            // 
            this.userInfoNamesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoNamesFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.userInfoNamesFontOutlineColorPictureBox.Name = "userInfoNamesFontOutlineColorPictureBox";
            this.userInfoNamesFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.userInfoNamesFontOutlineColorPictureBox.TabIndex = 45;
            this.userInfoNamesFontOutlineColorPictureBox.TabStop = false;
            // 
            // userInfoNamesFontColorBoxButton
            // 
            this.userInfoNamesFontColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoNamesFontColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userInfoNamesFontColorBoxButton.Location = new System.Drawing.Point(5, 45);
            this.userInfoNamesFontColorBoxButton.Name = "userInfoNamesFontColorBoxButton";
            this.userInfoNamesFontColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.userInfoNamesFontColorBoxButton.TabIndex = 45;
            this.userInfoNamesFontColorBoxButton.Text = "Set";
            this.userInfoNamesFontColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // userInfoNamesOutlineCheckBox
            // 
            this.userInfoNamesOutlineCheckBox.AutoSize = true;
            this.userInfoNamesOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoNamesOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoNamesOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.userInfoNamesOutlineCheckBox.Name = "userInfoNamesOutlineCheckBox";
            this.userInfoNamesOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.userInfoNamesOutlineCheckBox.TabIndex = 45;
            this.userInfoNamesOutlineCheckBox.Text = "Outline";
            this.userInfoNamesOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // userInfoNamesFontOutlineNumericUpDown
            // 
            this.userInfoNamesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoNamesFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
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
            this.userInfoNamesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.userInfoNamesFontOutlineNumericUpDown.TabIndex = 45;
            this.userInfoNamesFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.userInfoNamesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // userInfoNamesFontColorPictureBox
            // 
            this.userInfoNamesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoNamesFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.userInfoNamesFontColorPictureBox.Name = "userInfoNamesFontColorPictureBox";
            this.userInfoNamesFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.userInfoNamesFontColorPictureBox.TabIndex = 45;
            this.userInfoNamesFontColorPictureBox.TabStop = false;
            // 
            // userInfoNamesFontComboBox
            // 
            this.userInfoNamesFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoNamesFontComboBox.FormattingEnabled = true;
            this.userInfoNamesFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.userInfoNamesFontComboBox.Name = "userInfoNamesFontComboBox";
            this.userInfoNamesFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.userInfoNamesFontComboBox.TabIndex = 45;
            // 
            // userInfoSimpleGroupBox
            // 
            this.userInfoSimpleGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.userInfoSimpleGroupBox.Controls.Add(this.userInfoSimpleFontOutlineColorBoxButton);
            this.userInfoSimpleGroupBox.Controls.Add(this.userInfoSimpleFontOutlineColorPictureBox);
            this.userInfoSimpleGroupBox.Controls.Add(this.userInfoSimpleFontColorBoxButton);
            this.userInfoSimpleGroupBox.Controls.Add(this.userInfoSimpleOutlineCheckBox);
            this.userInfoSimpleGroupBox.Controls.Add(this.userInfoSimpleFontOutlineNumericUpDown);
            this.userInfoSimpleGroupBox.Controls.Add(this.userInfoSimpleFontColorPictureBox);
            this.userInfoSimpleGroupBox.Controls.Add(this.userInfoSimpleFontComboBox);
            this.userInfoSimpleGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoSimpleGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.userInfoSimpleGroupBox.Location = new System.Drawing.Point(425, 6);
            this.userInfoSimpleGroupBox.Name = "userInfoSimpleGroupBox";
            this.userInfoSimpleGroupBox.Size = new System.Drawing.Size(165, 125);
            this.userInfoSimpleGroupBox.TabIndex = 10036;
            this.userInfoSimpleGroupBox.TabStop = false;
            this.userInfoSimpleGroupBox.Text = "All";
            // 
            // userInfoSimpleFontOutlineColorBoxButton
            // 
            this.userInfoSimpleFontOutlineColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoSimpleFontOutlineColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userInfoSimpleFontOutlineColorBoxButton.Location = new System.Drawing.Point(5, 95);
            this.userInfoSimpleFontOutlineColorBoxButton.Name = "userInfoSimpleFontOutlineColorBoxButton";
            this.userInfoSimpleFontOutlineColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.userInfoSimpleFontOutlineColorBoxButton.TabIndex = 45;
            this.userInfoSimpleFontOutlineColorBoxButton.Text = "Set";
            this.userInfoSimpleFontOutlineColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // userInfoSimpleFontOutlineColorPictureBox
            // 
            this.userInfoSimpleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoSimpleFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.userInfoSimpleFontOutlineColorPictureBox.Name = "userInfoSimpleFontOutlineColorPictureBox";
            this.userInfoSimpleFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.userInfoSimpleFontOutlineColorPictureBox.TabIndex = 45;
            this.userInfoSimpleFontOutlineColorPictureBox.TabStop = false;
            // 
            // userInfoSimpleFontColorBoxButton
            // 
            this.userInfoSimpleFontColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoSimpleFontColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userInfoSimpleFontColorBoxButton.Location = new System.Drawing.Point(5, 45);
            this.userInfoSimpleFontColorBoxButton.Name = "userInfoSimpleFontColorBoxButton";
            this.userInfoSimpleFontColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.userInfoSimpleFontColorBoxButton.TabIndex = 45;
            this.userInfoSimpleFontColorBoxButton.Text = "Set";
            this.userInfoSimpleFontColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // userInfoSimpleOutlineCheckBox
            // 
            this.userInfoSimpleOutlineCheckBox.AutoSize = true;
            this.userInfoSimpleOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoSimpleOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.userInfoSimpleOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.userInfoSimpleOutlineCheckBox.Name = "userInfoSimpleOutlineCheckBox";
            this.userInfoSimpleOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.userInfoSimpleOutlineCheckBox.TabIndex = 45;
            this.userInfoSimpleOutlineCheckBox.Text = "Outline";
            this.userInfoSimpleOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // userInfoSimpleFontOutlineNumericUpDown
            // 
            this.userInfoSimpleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoSimpleFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
            this.userInfoSimpleFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.userInfoSimpleFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.userInfoSimpleFontOutlineNumericUpDown.Name = "userInfoSimpleFontOutlineNumericUpDown";
            this.userInfoSimpleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.userInfoSimpleFontOutlineNumericUpDown.TabIndex = 45;
            this.userInfoSimpleFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.userInfoSimpleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // userInfoSimpleFontColorPictureBox
            // 
            this.userInfoSimpleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userInfoSimpleFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.userInfoSimpleFontColorPictureBox.Name = "userInfoSimpleFontColorPictureBox";
            this.userInfoSimpleFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.userInfoSimpleFontColorPictureBox.TabIndex = 45;
            this.userInfoSimpleFontColorPictureBox.TabStop = false;
            // 
            // userInfoSimpleFontComboBox
            // 
            this.userInfoSimpleFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInfoSimpleFontComboBox.FormattingEnabled = true;
            this.userInfoSimpleFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.userInfoSimpleFontComboBox.Name = "userInfoSimpleFontComboBox";
            this.userInfoSimpleFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.userInfoSimpleFontComboBox.TabIndex = 45;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tabPage2.Controls.Add(this.focusAchievementIdLabel);
            this.tabPage2.Controls.Add(this.focusSimpleCheckBox);
            this.tabPage2.Controls.Add(this.focusBorderCheckBox);
            this.tabPage2.Controls.Add(this.focusBackgroundColorGroupBox);
            this.tabPage2.Controls.Add(this.focusBorderColorGroupBox);
            this.tabPage2.Controls.Add(this.focusLineGroupBox);
            this.tabPage2.Controls.Add(this.focusPointsGroupBox);
            this.tabPage2.Controls.Add(this.focusTitleGroupBox);
            this.tabPage2.Controls.Add(this.focusDescriptionGroupBox);
            this.tabPage2.Controls.Add(this.focusBehaviorGroupBox);
            this.tabPage2.Controls.Add(this.focusAchievementPictureBox);
            this.tabPage2.Controls.Add(this.focusOpenWindowButton);
            this.tabPage2.Controls.Add(this.focusAutoOpenWindowCheckBox);
            this.tabPage2.Controls.Add(this.focusAchievementTitleLabel);
            this.tabPage2.Controls.Add(this.focusAchievementButtonNext);
            this.tabPage2.Controls.Add(this.focusAchievementDescriptionLabel);
            this.tabPage2.Controls.Add(this.focusAchievementButtonPrevious);
            this.tabPage2.Controls.Add(this.focusSetButton);
            this.tabPage2.Controls.Add(this.focusSimpleGroupBox);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(769, 292);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Focus Cheevo";
            // 
            // focusAchievementIdLabel
            // 
            this.focusAchievementIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.focusAchievementIdLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementIdLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusAchievementIdLabel.Location = new System.Drawing.Point(6, 8);
            this.focusAchievementIdLabel.Name = "focusAchievementIdLabel";
            this.focusAchievementIdLabel.Size = new System.Drawing.Size(123, 18);
            this.focusAchievementIdLabel.TabIndex = 10053;
            this.focusAchievementIdLabel.Text = "[  ]";
            this.focusAchievementIdLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // focusSimpleCheckBox
            // 
            this.focusSimpleCheckBox.AutoSize = true;
            this.focusSimpleCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.focusSimpleCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusSimpleCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusSimpleCheckBox.Location = new System.Drawing.Point(343, 120);
            this.focusSimpleCheckBox.Name = "focusSimpleCheckBox";
            this.focusSimpleCheckBox.Size = new System.Drawing.Size(82, 22);
            this.focusSimpleCheckBox.TabIndex = 10052;
            this.focusSimpleCheckBox.Text = "Simple";
            this.focusSimpleCheckBox.UseVisualStyleBackColor = false;
            // 
            // focusBorderCheckBox
            // 
            this.focusBorderCheckBox.AutoSize = true;
            this.focusBorderCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.focusBorderCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusBorderCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusBorderCheckBox.Location = new System.Drawing.Point(343, 149);
            this.focusBorderCheckBox.Name = "focusBorderCheckBox";
            this.focusBorderCheckBox.Size = new System.Drawing.Size(80, 22);
            this.focusBorderCheckBox.TabIndex = 10051;
            this.focusBorderCheckBox.Text = "Border";
            this.focusBorderCheckBox.UseVisualStyleBackColor = false;
            // 
            // focusBackgroundColorGroupBox
            // 
            this.focusBackgroundColorGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.focusBackgroundColorGroupBox.Controls.Add(this.focusSetBackgroundColorButton);
            this.focusBackgroundColorGroupBox.Controls.Add(this.focusBackgroundColorPictureBox);
            this.focusBackgroundColorGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusBackgroundColorGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusBackgroundColorGroupBox.Location = new System.Drawing.Point(339, 6);
            this.focusBackgroundColorGroupBox.Name = "focusBackgroundColorGroupBox";
            this.focusBackgroundColorGroupBox.Size = new System.Drawing.Size(80, 49);
            this.focusBackgroundColorGroupBox.TabIndex = 10045;
            this.focusBackgroundColorGroupBox.TabStop = false;
            this.focusBackgroundColorGroupBox.Text = "Back";
            // 
            // focusSetBackgroundColorButton
            // 
            this.focusSetBackgroundColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusSetBackgroundColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusSetBackgroundColorButton.Location = new System.Drawing.Point(6, 20);
            this.focusSetBackgroundColorButton.Name = "focusSetBackgroundColorButton";
            this.focusSetBackgroundColorButton.Size = new System.Drawing.Size(36, 23);
            this.focusSetBackgroundColorButton.TabIndex = 43;
            this.focusSetBackgroundColorButton.Text = "Set";
            this.focusSetBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // focusBackgroundColorPictureBox
            // 
            this.focusBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusBackgroundColorPictureBox.Location = new System.Drawing.Point(48, 20);
            this.focusBackgroundColorPictureBox.Name = "focusBackgroundColorPictureBox";
            this.focusBackgroundColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusBackgroundColorPictureBox.TabIndex = 42;
            this.focusBackgroundColorPictureBox.TabStop = false;
            // 
            // focusBorderColorGroupBox
            // 
            this.focusBorderColorGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.focusBorderColorGroupBox.Controls.Add(this.focusSetBorderColorButton);
            this.focusBorderColorGroupBox.Controls.Add(this.focusBorderColorPictureBox);
            this.focusBorderColorGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusBorderColorGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusBorderColorGroupBox.Location = new System.Drawing.Point(339, 61);
            this.focusBorderColorGroupBox.Name = "focusBorderColorGroupBox";
            this.focusBorderColorGroupBox.Size = new System.Drawing.Size(80, 49);
            this.focusBorderColorGroupBox.TabIndex = 10046;
            this.focusBorderColorGroupBox.TabStop = false;
            this.focusBorderColorGroupBox.Text = "Border";
            // 
            // focusSetBorderColorButton
            // 
            this.focusSetBorderColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusSetBorderColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusSetBorderColorButton.Location = new System.Drawing.Point(6, 20);
            this.focusSetBorderColorButton.Name = "focusSetBorderColorButton";
            this.focusSetBorderColorButton.Size = new System.Drawing.Size(36, 23);
            this.focusSetBorderColorButton.TabIndex = 43;
            this.focusSetBorderColorButton.Text = "Set";
            this.focusSetBorderColorButton.UseVisualStyleBackColor = true;
            // 
            // focusBorderColorPictureBox
            // 
            this.focusBorderColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusBorderColorPictureBox.Location = new System.Drawing.Point(48, 20);
            this.focusBorderColorPictureBox.Name = "focusBorderColorPictureBox";
            this.focusBorderColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusBorderColorPictureBox.TabIndex = 42;
            this.focusBorderColorPictureBox.TabStop = false;
            // 
            // focusLineGroupBox
            // 
            this.focusLineGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.focusLineGroupBox.Controls.Add(this.focusLineSetColorButton);
            this.focusLineGroupBox.Controls.Add(this.focusLineColorPictureBox);
            this.focusLineGroupBox.Controls.Add(this.focusLineOutlineSetColorButton);
            this.focusLineGroupBox.Controls.Add(this.focusLineOutlineCheckBox);
            this.focusLineGroupBox.Controls.Add(this.focusLineOutlineNumericUpDown);
            this.focusLineGroupBox.Controls.Add(this.focusLineOutlineColorPictureBox);
            this.focusLineGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusLineGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusLineGroupBox.Location = new System.Drawing.Point(596, 137);
            this.focusLineGroupBox.Name = "focusLineGroupBox";
            this.focusLineGroupBox.Size = new System.Drawing.Size(165, 125);
            this.focusLineGroupBox.TabIndex = 10044;
            this.focusLineGroupBox.TabStop = false;
            this.focusLineGroupBox.Text = "Line";
            // 
            // focusLineSetColorButton
            // 
            this.focusLineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusLineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusLineSetColorButton.Location = new System.Drawing.Point(6, 46);
            this.focusLineSetColorButton.Name = "focusLineSetColorButton";
            this.focusLineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.focusLineSetColorButton.TabIndex = 45;
            this.focusLineSetColorButton.Text = "Set";
            this.focusLineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // focusLineColorPictureBox
            // 
            this.focusLineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusLineColorPictureBox.Location = new System.Drawing.Point(61, 46);
            this.focusLineColorPictureBox.Name = "focusLineColorPictureBox";
            this.focusLineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusLineColorPictureBox.TabIndex = 45;
            this.focusLineColorPictureBox.TabStop = false;
            // 
            // focusLineOutlineSetColorButton
            // 
            this.focusLineOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusLineOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusLineOutlineSetColorButton.Location = new System.Drawing.Point(6, 95);
            this.focusLineOutlineSetColorButton.Name = "focusLineOutlineSetColorButton";
            this.focusLineOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.focusLineOutlineSetColorButton.TabIndex = 45;
            this.focusLineOutlineSetColorButton.Text = "Set";
            this.focusLineOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // focusLineOutlineCheckBox
            // 
            this.focusLineOutlineCheckBox.AutoSize = true;
            this.focusLineOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusLineOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusLineOutlineCheckBox.Location = new System.Drawing.Point(7, 75);
            this.focusLineOutlineCheckBox.Name = "focusLineOutlineCheckBox";
            this.focusLineOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.focusLineOutlineCheckBox.TabIndex = 45;
            this.focusLineOutlineCheckBox.Text = "Outline";
            this.focusLineOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // focusLineOutlineNumericUpDown
            // 
            this.focusLineOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusLineOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
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
            this.focusLineOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.focusLineOutlineNumericUpDown.TabIndex = 45;
            this.focusLineOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // focusLineOutlineColorPictureBox
            // 
            this.focusLineOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusLineOutlineColorPictureBox.Location = new System.Drawing.Point(61, 95);
            this.focusLineOutlineColorPictureBox.Name = "focusLineOutlineColorPictureBox";
            this.focusLineOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusLineOutlineColorPictureBox.TabIndex = 45;
            this.focusLineOutlineColorPictureBox.TabStop = false;
            // 
            // focusPointsGroupBox
            // 
            this.focusPointsGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.focusPointsGroupBox.Controls.Add(this.focusPointsFontOutlineSetColorButton);
            this.focusPointsGroupBox.Controls.Add(this.focusPointsFontOutlineColorPictureBox);
            this.focusPointsGroupBox.Controls.Add(this.focusPointsFontSetColorButton);
            this.focusPointsGroupBox.Controls.Add(this.focusPointsOutlineCheckBox);
            this.focusPointsGroupBox.Controls.Add(this.focusPointsFontOutlineNumericUpDown);
            this.focusPointsGroupBox.Controls.Add(this.focusPointsFontColorPictureBox);
            this.focusPointsGroupBox.Controls.Add(this.focusPointsFontComboBox);
            this.focusPointsGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusPointsGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusPointsGroupBox.Location = new System.Drawing.Point(425, 137);
            this.focusPointsGroupBox.Name = "focusPointsGroupBox";
            this.focusPointsGroupBox.Size = new System.Drawing.Size(165, 125);
            this.focusPointsGroupBox.TabIndex = 10043;
            this.focusPointsGroupBox.TabStop = false;
            this.focusPointsGroupBox.Text = "Points";
            // 
            // focusPointsFontOutlineSetColorButton
            // 
            this.focusPointsFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusPointsFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusPointsFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.focusPointsFontOutlineSetColorButton.Name = "focusPointsFontOutlineSetColorButton";
            this.focusPointsFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.focusPointsFontOutlineSetColorButton.TabIndex = 45;
            this.focusPointsFontOutlineSetColorButton.Text = "Set";
            this.focusPointsFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // focusPointsFontOutlineColorPictureBox
            // 
            this.focusPointsFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusPointsFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.focusPointsFontOutlineColorPictureBox.Name = "focusPointsFontOutlineColorPictureBox";
            this.focusPointsFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusPointsFontOutlineColorPictureBox.TabIndex = 45;
            this.focusPointsFontOutlineColorPictureBox.TabStop = false;
            // 
            // focusPointsFontSetColorButton
            // 
            this.focusPointsFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusPointsFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusPointsFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.focusPointsFontSetColorButton.Name = "focusPointsFontSetColorButton";
            this.focusPointsFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.focusPointsFontSetColorButton.TabIndex = 45;
            this.focusPointsFontSetColorButton.Text = "Set";
            this.focusPointsFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // focusPointsOutlineCheckBox
            // 
            this.focusPointsOutlineCheckBox.AutoSize = true;
            this.focusPointsOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusPointsOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusPointsOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.focusPointsOutlineCheckBox.Name = "focusPointsOutlineCheckBox";
            this.focusPointsOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.focusPointsOutlineCheckBox.TabIndex = 45;
            this.focusPointsOutlineCheckBox.Text = "Outline";
            this.focusPointsOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // focusPointsFontOutlineNumericUpDown
            // 
            this.focusPointsFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusPointsFontOutlineNumericUpDown.Location = new System.Drawing.Point(90, 97);
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
            this.focusPointsFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.focusPointsFontOutlineNumericUpDown.TabIndex = 45;
            this.focusPointsFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // focusPointsFontColorPictureBox
            // 
            this.focusPointsFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusPointsFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.focusPointsFontColorPictureBox.Name = "focusPointsFontColorPictureBox";
            this.focusPointsFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusPointsFontColorPictureBox.TabIndex = 45;
            this.focusPointsFontColorPictureBox.TabStop = false;
            // 
            // focusPointsFontComboBox
            // 
            this.focusPointsFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusPointsFontComboBox.FormattingEnabled = true;
            this.focusPointsFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.focusPointsFontComboBox.Name = "focusPointsFontComboBox";
            this.focusPointsFontComboBox.Size = new System.Drawing.Size(157, 24);
            this.focusPointsFontComboBox.TabIndex = 45;
            // 
            // focusTitleGroupBox
            // 
            this.focusTitleGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.focusTitleGroupBox.Controls.Add(this.focusTitleFontOutlineSetColorButton);
            this.focusTitleGroupBox.Controls.Add(this.focusTitleFontOutlineColorPictureBox);
            this.focusTitleGroupBox.Controls.Add(this.focusTitleFontSetColorButton);
            this.focusTitleGroupBox.Controls.Add(this.focusTitleOutlineCheckBox);
            this.focusTitleGroupBox.Controls.Add(this.focusTitleFontOutlineNumericUpDown);
            this.focusTitleGroupBox.Controls.Add(this.focusTitleFontColorPictureBox);
            this.focusTitleGroupBox.Controls.Add(this.focusTitleFontComboBox);
            this.focusTitleGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusTitleGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusTitleGroupBox.Location = new System.Drawing.Point(425, 6);
            this.focusTitleGroupBox.Name = "focusTitleGroupBox";
            this.focusTitleGroupBox.Size = new System.Drawing.Size(165, 125);
            this.focusTitleGroupBox.TabIndex = 10041;
            this.focusTitleGroupBox.TabStop = false;
            this.focusTitleGroupBox.Text = "Title";
            // 
            // focusTitleFontOutlineSetColorButton
            // 
            this.focusTitleFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusTitleFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusTitleFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.focusTitleFontOutlineSetColorButton.Name = "focusTitleFontOutlineSetColorButton";
            this.focusTitleFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.focusTitleFontOutlineSetColorButton.TabIndex = 45;
            this.focusTitleFontOutlineSetColorButton.Text = "Set";
            this.focusTitleFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // focusTitleFontOutlineColorPictureBox
            // 
            this.focusTitleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusTitleFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.focusTitleFontOutlineColorPictureBox.Name = "focusTitleFontOutlineColorPictureBox";
            this.focusTitleFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusTitleFontOutlineColorPictureBox.TabIndex = 45;
            this.focusTitleFontOutlineColorPictureBox.TabStop = false;
            // 
            // focusTitleFontSetColorButton
            // 
            this.focusTitleFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusTitleFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusTitleFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.focusTitleFontSetColorButton.Name = "focusTitleFontSetColorButton";
            this.focusTitleFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.focusTitleFontSetColorButton.TabIndex = 45;
            this.focusTitleFontSetColorButton.Text = "Set";
            this.focusTitleFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // focusTitleOutlineCheckBox
            // 
            this.focusTitleOutlineCheckBox.AutoSize = true;
            this.focusTitleOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusTitleOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusTitleOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.focusTitleOutlineCheckBox.Name = "focusTitleOutlineCheckBox";
            this.focusTitleOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.focusTitleOutlineCheckBox.TabIndex = 45;
            this.focusTitleOutlineCheckBox.Text = "Outline";
            this.focusTitleOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // focusTitleFontOutlineNumericUpDown
            // 
            this.focusTitleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusTitleFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
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
            this.focusTitleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.focusTitleFontOutlineNumericUpDown.TabIndex = 45;
            this.focusTitleFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.focusTitleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // focusTitleFontColorPictureBox
            // 
            this.focusTitleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusTitleFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.focusTitleFontColorPictureBox.Name = "focusTitleFontColorPictureBox";
            this.focusTitleFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusTitleFontColorPictureBox.TabIndex = 45;
            this.focusTitleFontColorPictureBox.TabStop = false;
            // 
            // focusTitleFontComboBox
            // 
            this.focusTitleFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusTitleFontComboBox.FormattingEnabled = true;
            this.focusTitleFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.focusTitleFontComboBox.Name = "focusTitleFontComboBox";
            this.focusTitleFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.focusTitleFontComboBox.TabIndex = 45;
            // 
            // focusDescriptionGroupBox
            // 
            this.focusDescriptionGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.focusDescriptionGroupBox.Controls.Add(this.focusDescriptionFontOutlineSetColorButton);
            this.focusDescriptionGroupBox.Controls.Add(this.focusDescriptionFontOutlineColorPictureBox);
            this.focusDescriptionGroupBox.Controls.Add(this.focusDescriptionFontSetColorButton);
            this.focusDescriptionGroupBox.Controls.Add(this.focusDescriptionOutlineCheckBox);
            this.focusDescriptionGroupBox.Controls.Add(this.focusDescriptionFontOutlineNumericUpDown);
            this.focusDescriptionGroupBox.Controls.Add(this.focusDescriptionFontColorPictureBox);
            this.focusDescriptionGroupBox.Controls.Add(this.focusDescriptionFontComboBox);
            this.focusDescriptionGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusDescriptionGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusDescriptionGroupBox.Location = new System.Drawing.Point(596, 6);
            this.focusDescriptionGroupBox.Name = "focusDescriptionGroupBox";
            this.focusDescriptionGroupBox.Size = new System.Drawing.Size(165, 125);
            this.focusDescriptionGroupBox.TabIndex = 10042;
            this.focusDescriptionGroupBox.TabStop = false;
            this.focusDescriptionGroupBox.Text = "Description";
            // 
            // focusDescriptionFontOutlineSetColorButton
            // 
            this.focusDescriptionFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusDescriptionFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusDescriptionFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.focusDescriptionFontOutlineSetColorButton.Name = "focusDescriptionFontOutlineSetColorButton";
            this.focusDescriptionFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.focusDescriptionFontOutlineSetColorButton.TabIndex = 45;
            this.focusDescriptionFontOutlineSetColorButton.Text = "Set";
            this.focusDescriptionFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // focusDescriptionFontOutlineColorPictureBox
            // 
            this.focusDescriptionFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusDescriptionFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.focusDescriptionFontOutlineColorPictureBox.Name = "focusDescriptionFontOutlineColorPictureBox";
            this.focusDescriptionFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusDescriptionFontOutlineColorPictureBox.TabIndex = 45;
            this.focusDescriptionFontOutlineColorPictureBox.TabStop = false;
            // 
            // focusDescriptionFontSetColorButton
            // 
            this.focusDescriptionFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusDescriptionFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusDescriptionFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.focusDescriptionFontSetColorButton.Name = "focusDescriptionFontSetColorButton";
            this.focusDescriptionFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.focusDescriptionFontSetColorButton.TabIndex = 45;
            this.focusDescriptionFontSetColorButton.Text = "Set";
            this.focusDescriptionFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // focusDescriptionOutlineCheckBox
            // 
            this.focusDescriptionOutlineCheckBox.AutoSize = true;
            this.focusDescriptionOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusDescriptionOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusDescriptionOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.focusDescriptionOutlineCheckBox.Name = "focusDescriptionOutlineCheckBox";
            this.focusDescriptionOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.focusDescriptionOutlineCheckBox.TabIndex = 45;
            this.focusDescriptionOutlineCheckBox.Text = "Outline";
            this.focusDescriptionOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // focusDescriptionFontOutlineNumericUpDown
            // 
            this.focusDescriptionFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusDescriptionFontOutlineNumericUpDown.Location = new System.Drawing.Point(91, 97);
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
            this.focusDescriptionFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.focusDescriptionFontOutlineNumericUpDown.TabIndex = 45;
            this.focusDescriptionFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // focusDescriptionFontColorPictureBox
            // 
            this.focusDescriptionFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusDescriptionFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.focusDescriptionFontColorPictureBox.Name = "focusDescriptionFontColorPictureBox";
            this.focusDescriptionFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusDescriptionFontColorPictureBox.TabIndex = 45;
            this.focusDescriptionFontColorPictureBox.TabStop = false;
            // 
            // focusDescriptionFontComboBox
            // 
            this.focusDescriptionFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusDescriptionFontComboBox.FormattingEnabled = true;
            this.focusDescriptionFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.focusDescriptionFontComboBox.Name = "focusDescriptionFontComboBox";
            this.focusDescriptionFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.focusDescriptionFontComboBox.TabIndex = 45;
            // 
            // focusSimpleGroupBox
            // 
            this.focusSimpleGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.focusSimpleGroupBox.Controls.Add(this.focusSimpleFontOutlineSetColorButton);
            this.focusSimpleGroupBox.Controls.Add(this.focusSimpleFontOutlineColorPictureBox);
            this.focusSimpleGroupBox.Controls.Add(this.focusSimpleFontSetColorButton);
            this.focusSimpleGroupBox.Controls.Add(this.focusSimpleOutlineCheckBox);
            this.focusSimpleGroupBox.Controls.Add(this.focusSimpleFontOutlineNumericUpDown);
            this.focusSimpleGroupBox.Controls.Add(this.focusSimpleFontColorPictureBox);
            this.focusSimpleGroupBox.Controls.Add(this.focusSimpleFontComboBox);
            this.focusSimpleGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusSimpleGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.focusSimpleGroupBox.Location = new System.Drawing.Point(425, 6);
            this.focusSimpleGroupBox.Name = "focusSimpleGroupBox";
            this.focusSimpleGroupBox.Size = new System.Drawing.Size(165, 125);
            this.focusSimpleGroupBox.TabIndex = 10042;
            this.focusSimpleGroupBox.TabStop = false;
            this.focusSimpleGroupBox.Text = "All";
            // 
            // focusSimpleFontOutlineSetColorButton
            // 
            this.focusSimpleFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusSimpleFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusSimpleFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.focusSimpleFontOutlineSetColorButton.Name = "focusSimpleFontOutlineSetColorButton";
            this.focusSimpleFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.focusSimpleFontOutlineSetColorButton.TabIndex = 45;
            this.focusSimpleFontOutlineSetColorButton.Text = "Set";
            this.focusSimpleFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // focusSimpleFontOutlineColorPictureBox
            // 
            this.focusSimpleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusSimpleFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.focusSimpleFontOutlineColorPictureBox.Name = "focusSimpleFontOutlineColorPictureBox";
            this.focusSimpleFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusSimpleFontOutlineColorPictureBox.TabIndex = 45;
            this.focusSimpleFontOutlineColorPictureBox.TabStop = false;
            // 
            // focusSimpleFontSetColorButton
            // 
            this.focusSimpleFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusSimpleFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusSimpleFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.focusSimpleFontSetColorButton.Name = "focusSimpleFontSetColorButton";
            this.focusSimpleFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.focusSimpleFontSetColorButton.TabIndex = 45;
            this.focusSimpleFontSetColorButton.Text = "Set";
            this.focusSimpleFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // focusSimpleOutlineCheckBox
            // 
            this.focusSimpleOutlineCheckBox.AutoSize = true;
            this.focusSimpleOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusSimpleOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.focusSimpleOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.focusSimpleOutlineCheckBox.Name = "focusSimpleOutlineCheckBox";
            this.focusSimpleOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.focusSimpleOutlineCheckBox.TabIndex = 45;
            this.focusSimpleOutlineCheckBox.Text = "Outline";
            this.focusSimpleOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // focusSimpleFontOutlineNumericUpDown
            // 
            this.focusSimpleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusSimpleFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
            this.focusSimpleFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.focusSimpleFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.focusSimpleFontOutlineNumericUpDown.Name = "focusSimpleFontOutlineNumericUpDown";
            this.focusSimpleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.focusSimpleFontOutlineNumericUpDown.TabIndex = 45;
            this.focusSimpleFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.focusSimpleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // focusSimpleFontColorPictureBox
            // 
            this.focusSimpleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.focusSimpleFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.focusSimpleFontColorPictureBox.Name = "focusSimpleFontColorPictureBox";
            this.focusSimpleFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.focusSimpleFontColorPictureBox.TabIndex = 45;
            this.focusSimpleFontColorPictureBox.TabStop = false;
            // 
            // focusSimpleFontComboBox
            // 
            this.focusSimpleFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusSimpleFontComboBox.FormattingEnabled = true;
            this.focusSimpleFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.focusSimpleFontComboBox.Name = "focusSimpleFontComboBox";
            this.focusSimpleFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.focusSimpleFontComboBox.TabIndex = 45;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tabPage3.Controls.Add(this.notificationsSimpleCheckBox);
            this.tabPage3.Controls.Add(this.notificationsBorderCheckBox);
            this.tabPage3.Controls.Add(this.tabControl2);
            this.tabPage3.Controls.Add(this.notificationsBackgroundColorGroupBox);
            this.tabPage3.Controls.Add(this.groupBox28);
            this.tabPage3.Controls.Add(this.notificationsLineGroupBox);
            this.tabPage3.Controls.Add(this.notificationsPointsGroupBox);
            this.tabPage3.Controls.Add(this.notificationsDescriptionGroupBox);
            this.tabPage3.Controls.Add(this.notificationsAutoOpenWindowCheckbox);
            this.tabPage3.Controls.Add(this.notificationsOpenWindowButton);
            this.tabPage3.Controls.Add(this.notificationsTitleGroupBox);
            this.tabPage3.Controls.Add(this.notificationsAllFontGroupBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(769, 292);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cheevo Alerts";
            // 
            // notificationsSimpleCheckBox
            // 
            this.notificationsSimpleCheckBox.AutoSize = true;
            this.notificationsSimpleCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.notificationsSimpleCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsSimpleCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.notificationsSimpleCheckBox.Location = new System.Drawing.Point(343, 120);
            this.notificationsSimpleCheckBox.Name = "notificationsSimpleCheckBox";
            this.notificationsSimpleCheckBox.Size = new System.Drawing.Size(82, 22);
            this.notificationsSimpleCheckBox.TabIndex = 10050;
            this.notificationsSimpleCheckBox.Text = "Simple";
            this.notificationsSimpleCheckBox.UseVisualStyleBackColor = false;
            // 
            // notificationsBorderCheckBox
            // 
            this.notificationsBorderCheckBox.AutoSize = true;
            this.notificationsBorderCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.notificationsBorderCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsBorderCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.notificationsBorderCheckBox.Location = new System.Drawing.Point(343, 149);
            this.notificationsBorderCheckBox.Name = "notificationsBorderCheckBox";
            this.notificationsBorderCheckBox.Size = new System.Drawing.Size(80, 22);
            this.notificationsBorderCheckBox.TabIndex = 10048;
            this.notificationsBorderCheckBox.Text = "Border";
            this.notificationsBorderCheckBox.UseVisualStyleBackColor = false;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(3, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(326, 232);
            this.tabControl2.TabIndex = 10047;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tabPage4.Controls.Add(this.achievementEnableCheckbox);
            this.tabPage4.Controls.Add(this.playAchievementButton);
            this.tabPage4.Controls.Add(this.selectCustomAchievementFileButton);
            this.tabPage4.Controls.Add(this.customAchievementEnableCheckbox);
            this.tabPage4.Controls.Add(this.achievementPositionGroupBox);
            this.tabPage4.Controls.Add(this.achievementInAnimationGroupBox);
            this.tabPage4.Controls.Add(this.acheivementEditOutlineCheckbox);
            this.tabPage4.Controls.Add(this.achievementOutAnimationGroupBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(318, 204);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Achievement";
            // 
            // achievementEnableCheckbox
            // 
            this.achievementEnableCheckbox.AutoSize = true;
            this.achievementEnableCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementEnableCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.achievementEnableCheckbox.Location = new System.Drawing.Point(6, 43);
            this.achievementEnableCheckbox.Name = "achievementEnableCheckbox";
            this.achievementEnableCheckbox.Size = new System.Drawing.Size(70, 20);
            this.achievementEnableCheckbox.TabIndex = 54;
            this.achievementEnableCheckbox.Text = "Enable";
            this.achievementEnableCheckbox.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tabPage5.Controls.Add(this.masteryEnableCheckbox);
            this.tabPage5.Controls.Add(this.masteryOutAnimationGroupBox);
            this.tabPage5.Controls.Add(this.masteryPositionGroupBox);
            this.tabPage5.Controls.Add(this.masteryInAnimationGroupBox);
            this.tabPage5.Controls.Add(this.playMasteryButton);
            this.tabPage5.Controls.Add(this.selectCustomMasteryFileButton);
            this.tabPage5.Controls.Add(this.customMasteryEnableCheckbox);
            this.tabPage5.Controls.Add(this.masteryEditOultineCheckbox);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(318, 204);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Mastery";
            // 
            // masteryEnableCheckbox
            // 
            this.masteryEnableCheckbox.AutoSize = true;
            this.masteryEnableCheckbox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masteryEnableCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.masteryEnableCheckbox.Location = new System.Drawing.Point(6, 43);
            this.masteryEnableCheckbox.Name = "masteryEnableCheckbox";
            this.masteryEnableCheckbox.Size = new System.Drawing.Size(70, 20);
            this.masteryEnableCheckbox.TabIndex = 54;
            this.masteryEnableCheckbox.Text = "Enable";
            this.masteryEnableCheckbox.UseVisualStyleBackColor = true;
            // 
            // notificationsBackgroundColorGroupBox
            // 
            this.notificationsBackgroundColorGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.notificationsBackgroundColorGroupBox.Controls.Add(this.notificationsSetBackgroundColorButton);
            this.notificationsBackgroundColorGroupBox.Controls.Add(this.notificationsBackgroundColorPictureBox);
            this.notificationsBackgroundColorGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsBackgroundColorGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.notificationsBackgroundColorGroupBox.Location = new System.Drawing.Point(339, 6);
            this.notificationsBackgroundColorGroupBox.Name = "notificationsBackgroundColorGroupBox";
            this.notificationsBackgroundColorGroupBox.Size = new System.Drawing.Size(80, 49);
            this.notificationsBackgroundColorGroupBox.TabIndex = 10045;
            this.notificationsBackgroundColorGroupBox.TabStop = false;
            this.notificationsBackgroundColorGroupBox.Text = "Back";
            // 
            // notificationsSetBackgroundColorButton
            // 
            this.notificationsSetBackgroundColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsSetBackgroundColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsSetBackgroundColorButton.Location = new System.Drawing.Point(6, 20);
            this.notificationsSetBackgroundColorButton.Name = "notificationsSetBackgroundColorButton";
            this.notificationsSetBackgroundColorButton.Size = new System.Drawing.Size(36, 23);
            this.notificationsSetBackgroundColorButton.TabIndex = 43;
            this.notificationsSetBackgroundColorButton.Text = "Set";
            this.notificationsSetBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsBackgroundColorPictureBox
            // 
            this.notificationsBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsBackgroundColorPictureBox.Location = new System.Drawing.Point(48, 20);
            this.notificationsBackgroundColorPictureBox.Name = "notificationsBackgroundColorPictureBox";
            this.notificationsBackgroundColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsBackgroundColorPictureBox.TabIndex = 42;
            this.notificationsBackgroundColorPictureBox.TabStop = false;
            // 
            // groupBox28
            // 
            this.groupBox28.BackColor = System.Drawing.Color.Transparent;
            this.groupBox28.Controls.Add(this.notificationsSetBorderColorButton);
            this.groupBox28.Controls.Add(this.notificationsBorderColorPictureBox);
            this.groupBox28.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.groupBox28.Location = new System.Drawing.Point(339, 61);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(80, 49);
            this.groupBox28.TabIndex = 10046;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Border";
            // 
            // notificationsSetBorderColorButton
            // 
            this.notificationsSetBorderColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsSetBorderColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsSetBorderColorButton.Location = new System.Drawing.Point(6, 20);
            this.notificationsSetBorderColorButton.Name = "notificationsSetBorderColorButton";
            this.notificationsSetBorderColorButton.Size = new System.Drawing.Size(36, 23);
            this.notificationsSetBorderColorButton.TabIndex = 43;
            this.notificationsSetBorderColorButton.Text = "Set";
            this.notificationsSetBorderColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsBorderColorPictureBox
            // 
            this.notificationsBorderColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsBorderColorPictureBox.Location = new System.Drawing.Point(48, 20);
            this.notificationsBorderColorPictureBox.Name = "notificationsBorderColorPictureBox";
            this.notificationsBorderColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsBorderColorPictureBox.TabIndex = 42;
            this.notificationsBorderColorPictureBox.TabStop = false;
            // 
            // notificationsLineGroupBox
            // 
            this.notificationsLineGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.notificationsLineGroupBox.Controls.Add(this.notificationsLineSetColorButton);
            this.notificationsLineGroupBox.Controls.Add(this.notificationsLineColorPictureBox);
            this.notificationsLineGroupBox.Controls.Add(this.notificationsLineOutlineSetColorButton);
            this.notificationsLineGroupBox.Controls.Add(this.notificationsLineOutlineCheckBox);
            this.notificationsLineGroupBox.Controls.Add(this.notificationsLineOutlineNumericUpDown);
            this.notificationsLineGroupBox.Controls.Add(this.notificationsLineOutlineColorPictureBox);
            this.notificationsLineGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsLineGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.notificationsLineGroupBox.Location = new System.Drawing.Point(596, 137);
            this.notificationsLineGroupBox.Name = "notificationsLineGroupBox";
            this.notificationsLineGroupBox.Size = new System.Drawing.Size(165, 125);
            this.notificationsLineGroupBox.TabIndex = 10044;
            this.notificationsLineGroupBox.TabStop = false;
            this.notificationsLineGroupBox.Text = "Line";
            // 
            // notificationsLineSetColorButton
            // 
            this.notificationsLineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsLineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsLineSetColorButton.Location = new System.Drawing.Point(6, 46);
            this.notificationsLineSetColorButton.Name = "notificationsLineSetColorButton";
            this.notificationsLineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsLineSetColorButton.TabIndex = 45;
            this.notificationsLineSetColorButton.Text = "Set";
            this.notificationsLineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsLineColorPictureBox
            // 
            this.notificationsLineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsLineColorPictureBox.Location = new System.Drawing.Point(61, 46);
            this.notificationsLineColorPictureBox.Name = "notificationsLineColorPictureBox";
            this.notificationsLineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsLineColorPictureBox.TabIndex = 45;
            this.notificationsLineColorPictureBox.TabStop = false;
            // 
            // notificationsLineOutlineSetColorButton
            // 
            this.notificationsLineOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsLineOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsLineOutlineSetColorButton.Location = new System.Drawing.Point(6, 95);
            this.notificationsLineOutlineSetColorButton.Name = "notificationsLineOutlineSetColorButton";
            this.notificationsLineOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsLineOutlineSetColorButton.TabIndex = 45;
            this.notificationsLineOutlineSetColorButton.Text = "Set";
            this.notificationsLineOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsLineOutlineCheckBox
            // 
            this.notificationsLineOutlineCheckBox.AutoSize = true;
            this.notificationsLineOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsLineOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.notificationsLineOutlineCheckBox.Location = new System.Drawing.Point(7, 75);
            this.notificationsLineOutlineCheckBox.Name = "notificationsLineOutlineCheckBox";
            this.notificationsLineOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.notificationsLineOutlineCheckBox.TabIndex = 45;
            this.notificationsLineOutlineCheckBox.Text = "Outline";
            this.notificationsLineOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // notificationsLineOutlineNumericUpDown
            // 
            this.notificationsLineOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsLineOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
            this.notificationsLineOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.notificationsLineOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.notificationsLineOutlineNumericUpDown.Name = "notificationsLineOutlineNumericUpDown";
            this.notificationsLineOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.notificationsLineOutlineNumericUpDown.TabIndex = 45;
            this.notificationsLineOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // notificationsLineOutlineColorPictureBox
            // 
            this.notificationsLineOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsLineOutlineColorPictureBox.Location = new System.Drawing.Point(61, 95);
            this.notificationsLineOutlineColorPictureBox.Name = "notificationsLineOutlineColorPictureBox";
            this.notificationsLineOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsLineOutlineColorPictureBox.TabIndex = 45;
            this.notificationsLineOutlineColorPictureBox.TabStop = false;
            // 
            // notificationsPointsGroupBox
            // 
            this.notificationsPointsGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.notificationsPointsGroupBox.Controls.Add(this.notificationsPointsFontOutlineSetColorButton);
            this.notificationsPointsGroupBox.Controls.Add(this.notificationsPointsFontOutlineColorPictureBox);
            this.notificationsPointsGroupBox.Controls.Add(this.notificationsPointsFontSetColorButton);
            this.notificationsPointsGroupBox.Controls.Add(this.notificationsPointsOutlineCheckBox);
            this.notificationsPointsGroupBox.Controls.Add(this.notificationsPointsFontOutlineNumericUpDown);
            this.notificationsPointsGroupBox.Controls.Add(this.notificationsPointsFontColorPictureBox);
            this.notificationsPointsGroupBox.Controls.Add(this.notificationsPointsFontComboBox);
            this.notificationsPointsGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsPointsGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.notificationsPointsGroupBox.Location = new System.Drawing.Point(425, 137);
            this.notificationsPointsGroupBox.Name = "notificationsPointsGroupBox";
            this.notificationsPointsGroupBox.Size = new System.Drawing.Size(165, 125);
            this.notificationsPointsGroupBox.TabIndex = 10043;
            this.notificationsPointsGroupBox.TabStop = false;
            this.notificationsPointsGroupBox.Text = "Points";
            // 
            // notificationsPointsFontOutlineSetColorButton
            // 
            this.notificationsPointsFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsPointsFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsPointsFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.notificationsPointsFontOutlineSetColorButton.Name = "notificationsPointsFontOutlineSetColorButton";
            this.notificationsPointsFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsPointsFontOutlineSetColorButton.TabIndex = 45;
            this.notificationsPointsFontOutlineSetColorButton.Text = "Set";
            this.notificationsPointsFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsPointsFontOutlineColorPictureBox
            // 
            this.notificationsPointsFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsPointsFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.notificationsPointsFontOutlineColorPictureBox.Name = "notificationsPointsFontOutlineColorPictureBox";
            this.notificationsPointsFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsPointsFontOutlineColorPictureBox.TabIndex = 45;
            this.notificationsPointsFontOutlineColorPictureBox.TabStop = false;
            // 
            // notificationsPointsFontSetColorButton
            // 
            this.notificationsPointsFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsPointsFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsPointsFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.notificationsPointsFontSetColorButton.Name = "notificationsPointsFontSetColorButton";
            this.notificationsPointsFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsPointsFontSetColorButton.TabIndex = 45;
            this.notificationsPointsFontSetColorButton.Text = "Set";
            this.notificationsPointsFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsPointsOutlineCheckBox
            // 
            this.notificationsPointsOutlineCheckBox.AutoSize = true;
            this.notificationsPointsOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsPointsOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.notificationsPointsOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.notificationsPointsOutlineCheckBox.Name = "notificationsPointsOutlineCheckBox";
            this.notificationsPointsOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.notificationsPointsOutlineCheckBox.TabIndex = 45;
            this.notificationsPointsOutlineCheckBox.Text = "Outline";
            this.notificationsPointsOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // notificationsPointsFontOutlineNumericUpDown
            // 
            this.notificationsPointsFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsPointsFontOutlineNumericUpDown.Location = new System.Drawing.Point(90, 97);
            this.notificationsPointsFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.notificationsPointsFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.notificationsPointsFontOutlineNumericUpDown.Name = "notificationsPointsFontOutlineNumericUpDown";
            this.notificationsPointsFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.notificationsPointsFontOutlineNumericUpDown.TabIndex = 45;
            this.notificationsPointsFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // notificationsPointsFontColorPictureBox
            // 
            this.notificationsPointsFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsPointsFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.notificationsPointsFontColorPictureBox.Name = "notificationsPointsFontColorPictureBox";
            this.notificationsPointsFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsPointsFontColorPictureBox.TabIndex = 45;
            this.notificationsPointsFontColorPictureBox.TabStop = false;
            // 
            // notificationsPointsFontComboBox
            // 
            this.notificationsPointsFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsPointsFontComboBox.FormattingEnabled = true;
            this.notificationsPointsFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.notificationsPointsFontComboBox.Name = "notificationsPointsFontComboBox";
            this.notificationsPointsFontComboBox.Size = new System.Drawing.Size(157, 24);
            this.notificationsPointsFontComboBox.TabIndex = 45;
            // 
            // notificationsTitleGroupBox
            // 
            this.notificationsTitleGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.notificationsTitleGroupBox.Controls.Add(this.notificationsTitleFontOutlineSetColorButton);
            this.notificationsTitleGroupBox.Controls.Add(this.notificationsTitleFontOutlineColorPictureBox);
            this.notificationsTitleGroupBox.Controls.Add(this.notificationsTitleFontSetColorButton);
            this.notificationsTitleGroupBox.Controls.Add(this.notificationsTitleOutlineCheckBox);
            this.notificationsTitleGroupBox.Controls.Add(this.notificationsTitleFontOutlineNumericUpDown);
            this.notificationsTitleGroupBox.Controls.Add(this.notificationsTitleFontColorPictureBox);
            this.notificationsTitleGroupBox.Controls.Add(this.notificationsTitleFontComboBox);
            this.notificationsTitleGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsTitleGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.notificationsTitleGroupBox.Location = new System.Drawing.Point(425, 6);
            this.notificationsTitleGroupBox.Name = "notificationsTitleGroupBox";
            this.notificationsTitleGroupBox.Size = new System.Drawing.Size(165, 125);
            this.notificationsTitleGroupBox.TabIndex = 10041;
            this.notificationsTitleGroupBox.TabStop = false;
            this.notificationsTitleGroupBox.Text = "Title";
            // 
            // notificationsTitleFontOutlineSetColorButton
            // 
            this.notificationsTitleFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsTitleFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsTitleFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.notificationsTitleFontOutlineSetColorButton.Name = "notificationsTitleFontOutlineSetColorButton";
            this.notificationsTitleFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsTitleFontOutlineSetColorButton.TabIndex = 45;
            this.notificationsTitleFontOutlineSetColorButton.Text = "Set";
            this.notificationsTitleFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsTitleFontOutlineColorPictureBox
            // 
            this.notificationsTitleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsTitleFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.notificationsTitleFontOutlineColorPictureBox.Name = "notificationsTitleFontOutlineColorPictureBox";
            this.notificationsTitleFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsTitleFontOutlineColorPictureBox.TabIndex = 45;
            this.notificationsTitleFontOutlineColorPictureBox.TabStop = false;
            // 
            // notificationsTitleFontSetColorButton
            // 
            this.notificationsTitleFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsTitleFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsTitleFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.notificationsTitleFontSetColorButton.Name = "notificationsTitleFontSetColorButton";
            this.notificationsTitleFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsTitleFontSetColorButton.TabIndex = 45;
            this.notificationsTitleFontSetColorButton.Text = "Set";
            this.notificationsTitleFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsTitleOutlineCheckBox
            // 
            this.notificationsTitleOutlineCheckBox.AutoSize = true;
            this.notificationsTitleOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsTitleOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.notificationsTitleOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.notificationsTitleOutlineCheckBox.Name = "notificationsTitleOutlineCheckBox";
            this.notificationsTitleOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.notificationsTitleOutlineCheckBox.TabIndex = 45;
            this.notificationsTitleOutlineCheckBox.Text = "Outline";
            this.notificationsTitleOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // notificationsTitleFontOutlineNumericUpDown
            // 
            this.notificationsTitleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsTitleFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
            this.notificationsTitleFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.notificationsTitleFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.notificationsTitleFontOutlineNumericUpDown.Name = "notificationsTitleFontOutlineNumericUpDown";
            this.notificationsTitleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.notificationsTitleFontOutlineNumericUpDown.TabIndex = 45;
            this.notificationsTitleFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.notificationsTitleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // notificationsTitleFontColorPictureBox
            // 
            this.notificationsTitleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsTitleFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.notificationsTitleFontColorPictureBox.Name = "notificationsTitleFontColorPictureBox";
            this.notificationsTitleFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsTitleFontColorPictureBox.TabIndex = 45;
            this.notificationsTitleFontColorPictureBox.TabStop = false;
            // 
            // notificationsTitleFontComboBox
            // 
            this.notificationsTitleFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsTitleFontComboBox.FormattingEnabled = true;
            this.notificationsTitleFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.notificationsTitleFontComboBox.Name = "notificationsTitleFontComboBox";
            this.notificationsTitleFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.notificationsTitleFontComboBox.TabIndex = 45;
            // 
            // notificationsDescriptionGroupBox
            // 
            this.notificationsDescriptionGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.notificationsDescriptionGroupBox.Controls.Add(this.notificationsDescriptionFontOutlineSetColorButton);
            this.notificationsDescriptionGroupBox.Controls.Add(this.notificationsDescriptionFontOutlineColorPictureBox);
            this.notificationsDescriptionGroupBox.Controls.Add(this.notificationsDescriptionFontSetColorButton);
            this.notificationsDescriptionGroupBox.Controls.Add(this.notificationsDescriptionOutlineCheckBox);
            this.notificationsDescriptionGroupBox.Controls.Add(this.notificationsDescriptionFontOutlineNumericUpDown);
            this.notificationsDescriptionGroupBox.Controls.Add(this.notificationsDescriptionFontColorPictureBox);
            this.notificationsDescriptionGroupBox.Controls.Add(this.notificationsDescriptionFontComboBox);
            this.notificationsDescriptionGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsDescriptionGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.notificationsDescriptionGroupBox.Location = new System.Drawing.Point(596, 6);
            this.notificationsDescriptionGroupBox.Name = "notificationsDescriptionGroupBox";
            this.notificationsDescriptionGroupBox.Size = new System.Drawing.Size(165, 125);
            this.notificationsDescriptionGroupBox.TabIndex = 10042;
            this.notificationsDescriptionGroupBox.TabStop = false;
            this.notificationsDescriptionGroupBox.Text = "Description";
            // 
            // notificationsDescriptionFontOutlineSetColorButton
            // 
            this.notificationsDescriptionFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsDescriptionFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsDescriptionFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.notificationsDescriptionFontOutlineSetColorButton.Name = "notificationsDescriptionFontOutlineSetColorButton";
            this.notificationsDescriptionFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsDescriptionFontOutlineSetColorButton.TabIndex = 45;
            this.notificationsDescriptionFontOutlineSetColorButton.Text = "Set";
            this.notificationsDescriptionFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsDescriptionFontOutlineColorPictureBox
            // 
            this.notificationsDescriptionFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsDescriptionFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.notificationsDescriptionFontOutlineColorPictureBox.Name = "notificationsDescriptionFontOutlineColorPictureBox";
            this.notificationsDescriptionFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsDescriptionFontOutlineColorPictureBox.TabIndex = 45;
            this.notificationsDescriptionFontOutlineColorPictureBox.TabStop = false;
            // 
            // notificationsDescriptionFontSetColorButton
            // 
            this.notificationsDescriptionFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsDescriptionFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsDescriptionFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.notificationsDescriptionFontSetColorButton.Name = "notificationsDescriptionFontSetColorButton";
            this.notificationsDescriptionFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsDescriptionFontSetColorButton.TabIndex = 45;
            this.notificationsDescriptionFontSetColorButton.Text = "Set";
            this.notificationsDescriptionFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsDescriptionOutlineCheckBox
            // 
            this.notificationsDescriptionOutlineCheckBox.AutoSize = true;
            this.notificationsDescriptionOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsDescriptionOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.notificationsDescriptionOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.notificationsDescriptionOutlineCheckBox.Name = "notificationsDescriptionOutlineCheckBox";
            this.notificationsDescriptionOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.notificationsDescriptionOutlineCheckBox.TabIndex = 45;
            this.notificationsDescriptionOutlineCheckBox.Text = "Outline";
            this.notificationsDescriptionOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // notificationsDescriptionFontOutlineNumericUpDown
            // 
            this.notificationsDescriptionFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsDescriptionFontOutlineNumericUpDown.Location = new System.Drawing.Point(91, 97);
            this.notificationsDescriptionFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.notificationsDescriptionFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.notificationsDescriptionFontOutlineNumericUpDown.Name = "notificationsDescriptionFontOutlineNumericUpDown";
            this.notificationsDescriptionFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.notificationsDescriptionFontOutlineNumericUpDown.TabIndex = 45;
            this.notificationsDescriptionFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // notificationsDescriptionFontColorPictureBox
            // 
            this.notificationsDescriptionFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsDescriptionFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.notificationsDescriptionFontColorPictureBox.Name = "notificationsDescriptionFontColorPictureBox";
            this.notificationsDescriptionFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsDescriptionFontColorPictureBox.TabIndex = 45;
            this.notificationsDescriptionFontColorPictureBox.TabStop = false;
            // 
            // notificationsDescriptionFontComboBox
            // 
            this.notificationsDescriptionFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsDescriptionFontComboBox.FormattingEnabled = true;
            this.notificationsDescriptionFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.notificationsDescriptionFontComboBox.Name = "notificationsDescriptionFontComboBox";
            this.notificationsDescriptionFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.notificationsDescriptionFontComboBox.TabIndex = 45;
            // 
            // notificationsAllFontGroupBox
            // 
            this.notificationsAllFontGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.notificationsAllFontGroupBox.Controls.Add(this.notificationsSimpleFontOutlineSetColorButton);
            this.notificationsAllFontGroupBox.Controls.Add(this.notificationsSimpleFontOutlineColorPictureBox);
            this.notificationsAllFontGroupBox.Controls.Add(this.notificationsSimpleFontSetColorButton);
            this.notificationsAllFontGroupBox.Controls.Add(this.notificationsSimpleOutlineCheckBox);
            this.notificationsAllFontGroupBox.Controls.Add(this.notificationsSimpleFontOutlineNumericUpDown);
            this.notificationsAllFontGroupBox.Controls.Add(this.notificationsSimpleFontColorPictureBox);
            this.notificationsAllFontGroupBox.Controls.Add(this.notificationsSimpleFontComboBox);
            this.notificationsAllFontGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsAllFontGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.notificationsAllFontGroupBox.Location = new System.Drawing.Point(425, 6);
            this.notificationsAllFontGroupBox.Name = "notificationsAllFontGroupBox";
            this.notificationsAllFontGroupBox.Size = new System.Drawing.Size(165, 125);
            this.notificationsAllFontGroupBox.TabIndex = 10042;
            this.notificationsAllFontGroupBox.TabStop = false;
            this.notificationsAllFontGroupBox.Text = "All";
            // 
            // notificationsSimpleFontOutlineSetColorButton
            // 
            this.notificationsSimpleFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsSimpleFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsSimpleFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.notificationsSimpleFontOutlineSetColorButton.Name = "notificationsSimpleFontOutlineSetColorButton";
            this.notificationsSimpleFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsSimpleFontOutlineSetColorButton.TabIndex = 45;
            this.notificationsSimpleFontOutlineSetColorButton.Text = "Set";
            this.notificationsSimpleFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsSimpleFontOutlineColorPictureBox
            // 
            this.notificationsSimpleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsSimpleFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.notificationsSimpleFontOutlineColorPictureBox.Name = "notificationsSimpleFontOutlineColorPictureBox";
            this.notificationsSimpleFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsSimpleFontOutlineColorPictureBox.TabIndex = 45;
            this.notificationsSimpleFontOutlineColorPictureBox.TabStop = false;
            // 
            // notificationsSimpleFontSetColorButton
            // 
            this.notificationsSimpleFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsSimpleFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationsSimpleFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.notificationsSimpleFontSetColorButton.Name = "notificationsSimpleFontSetColorButton";
            this.notificationsSimpleFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.notificationsSimpleFontSetColorButton.TabIndex = 45;
            this.notificationsSimpleFontSetColorButton.Text = "Set";
            this.notificationsSimpleFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // notificationsSimpleOutlineCheckBox
            // 
            this.notificationsSimpleOutlineCheckBox.AutoSize = true;
            this.notificationsSimpleOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsSimpleOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.notificationsSimpleOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.notificationsSimpleOutlineCheckBox.Name = "notificationsSimpleOutlineCheckBox";
            this.notificationsSimpleOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.notificationsSimpleOutlineCheckBox.TabIndex = 45;
            this.notificationsSimpleOutlineCheckBox.Text = "Outline";
            this.notificationsSimpleOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // notificationsSimpleFontOutlineNumericUpDown
            // 
            this.notificationsSimpleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsSimpleFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
            this.notificationsSimpleFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.notificationsSimpleFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.notificationsSimpleFontOutlineNumericUpDown.Name = "notificationsSimpleFontOutlineNumericUpDown";
            this.notificationsSimpleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.notificationsSimpleFontOutlineNumericUpDown.TabIndex = 45;
            this.notificationsSimpleFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.notificationsSimpleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // notificationsSimpleFontColorPictureBox
            // 
            this.notificationsSimpleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.notificationsSimpleFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.notificationsSimpleFontColorPictureBox.Name = "notificationsSimpleFontColorPictureBox";
            this.notificationsSimpleFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.notificationsSimpleFontColorPictureBox.TabIndex = 45;
            this.notificationsSimpleFontColorPictureBox.TabStop = false;
            // 
            // notificationsSimpleFontComboBox
            // 
            this.notificationsSimpleFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsSimpleFontComboBox.FormattingEnabled = true;
            this.notificationsSimpleFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.notificationsSimpleFontComboBox.Name = "notificationsSimpleFontComboBox";
            this.notificationsSimpleFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.notificationsSimpleFontComboBox.TabIndex = 45;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tabPage6.Controls.Add(this.gameProgressRatioLabel);
            this.tabPage6.Controls.Add(this.gameProgressCompletedLabel);
            this.tabPage6.Controls.Add(this.gameProgressTruePointsLabel);
            this.tabPage6.Controls.Add(this.gameProgressPointsLabel);
            this.tabPage6.Controls.Add(this.gameProgressAchievementsLabel);
            this.tabPage6.Controls.Add(this.gameProgressSimpleCheckBox);
            this.tabPage6.Controls.Add(this.gameProgressBackgroundColorGroupBox);
            this.tabPage6.Controls.Add(this.gameProgressValuesGroupBox);
            this.tabPage6.Controls.Add(this.gameProgressDefaultButton);
            this.tabPage6.Controls.Add(this.groupBox17);
            this.tabPage6.Controls.Add(this.gameProgressAutoOpenWindowCheckbox);
            this.tabPage6.Controls.Add(this.gameProgressAchievementsTextBox);
            this.tabPage6.Controls.Add(this.gameProgressPointsCheckBox);
            this.tabPage6.Controls.Add(this.gameProgressRatioCheckBox);
            this.tabPage6.Controls.Add(this.gameProgressTruePointsCheckBox);
            this.tabPage6.Controls.Add(this.gameProgressOpenWindowButton);
            this.tabPage6.Controls.Add(this.gameProgressPointsTextBox);
            this.tabPage6.Controls.Add(this.gameProgressCompletedCheckBox);
            this.tabPage6.Controls.Add(this.gameProgressTruePointsTextBox);
            this.tabPage6.Controls.Add(this.gameProgressCompletedTextBox);
            this.tabPage6.Controls.Add(this.gameProgressRatioTextBox);
            this.tabPage6.Controls.Add(this.gameProgressAchievementsCheckBox);
            this.tabPage6.Controls.Add(this.gameProgressNamesGroupBox);
            this.tabPage6.Controls.Add(this.gameProgressSimpleGroupBox);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(769, 292);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Game Progress";
            // 
            // gameProgressRatioLabel
            // 
            this.gameProgressRatioLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressRatioLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressRatioLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressRatioLabel.Location = new System.Drawing.Point(422, 238);
            this.gameProgressRatioLabel.Name = "gameProgressRatioLabel";
            this.gameProgressRatioLabel.Size = new System.Drawing.Size(339, 26);
            this.gameProgressRatioLabel.TabIndex = 10062;
            // 
            // gameProgressCompletedLabel
            // 
            this.gameProgressCompletedLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressCompletedLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressCompletedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressCompletedLabel.Location = new System.Drawing.Point(422, 212);
            this.gameProgressCompletedLabel.Name = "gameProgressCompletedLabel";
            this.gameProgressCompletedLabel.Size = new System.Drawing.Size(339, 26);
            this.gameProgressCompletedLabel.TabIndex = 10061;
            // 
            // gameProgressTruePointsLabel
            // 
            this.gameProgressTruePointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressTruePointsLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressTruePointsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressTruePointsLabel.Location = new System.Drawing.Point(422, 186);
            this.gameProgressTruePointsLabel.Name = "gameProgressTruePointsLabel";
            this.gameProgressTruePointsLabel.Size = new System.Drawing.Size(339, 26);
            this.gameProgressTruePointsLabel.TabIndex = 10060;
            // 
            // gameProgressPointsLabel
            // 
            this.gameProgressPointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressPointsLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressPointsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressPointsLabel.Location = new System.Drawing.Point(422, 160);
            this.gameProgressPointsLabel.Name = "gameProgressPointsLabel";
            this.gameProgressPointsLabel.Size = new System.Drawing.Size(339, 26);
            this.gameProgressPointsLabel.TabIndex = 10059;
            // 
            // gameProgressAchievementsLabel
            // 
            this.gameProgressAchievementsLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressAchievementsLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressAchievementsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressAchievementsLabel.Location = new System.Drawing.Point(422, 134);
            this.gameProgressAchievementsLabel.Name = "gameProgressAchievementsLabel";
            this.gameProgressAchievementsLabel.Size = new System.Drawing.Size(339, 26);
            this.gameProgressAchievementsLabel.TabIndex = 10058;
            // 
            // gameProgressSimpleCheckBox
            // 
            this.gameProgressSimpleCheckBox.AutoSize = true;
            this.gameProgressSimpleCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressSimpleCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressSimpleCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressSimpleCheckBox.Location = new System.Drawing.Point(343, 120);
            this.gameProgressSimpleCheckBox.Name = "gameProgressSimpleCheckBox";
            this.gameProgressSimpleCheckBox.Size = new System.Drawing.Size(82, 22);
            this.gameProgressSimpleCheckBox.TabIndex = 10054;
            this.gameProgressSimpleCheckBox.Text = "Simple";
            this.gameProgressSimpleCheckBox.UseVisualStyleBackColor = false;
            // 
            // gameProgressBackgroundColorGroupBox
            // 
            this.gameProgressBackgroundColorGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.gameProgressBackgroundColorGroupBox.Controls.Add(this.gameProgressSetBackgroundColorButton);
            this.gameProgressBackgroundColorGroupBox.Controls.Add(this.gameProgressBackgroundColorPictureBox);
            this.gameProgressBackgroundColorGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressBackgroundColorGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameProgressBackgroundColorGroupBox.Location = new System.Drawing.Point(339, 6);
            this.gameProgressBackgroundColorGroupBox.Name = "gameProgressBackgroundColorGroupBox";
            this.gameProgressBackgroundColorGroupBox.Size = new System.Drawing.Size(80, 49);
            this.gameProgressBackgroundColorGroupBox.TabIndex = 10051;
            this.gameProgressBackgroundColorGroupBox.TabStop = false;
            this.gameProgressBackgroundColorGroupBox.Text = "Back";
            // 
            // gameProgressSetBackgroundColorButton
            // 
            this.gameProgressSetBackgroundColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressSetBackgroundColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameProgressSetBackgroundColorButton.Location = new System.Drawing.Point(6, 20);
            this.gameProgressSetBackgroundColorButton.Name = "gameProgressSetBackgroundColorButton";
            this.gameProgressSetBackgroundColorButton.Size = new System.Drawing.Size(36, 23);
            this.gameProgressSetBackgroundColorButton.TabIndex = 43;
            this.gameProgressSetBackgroundColorButton.Text = "Set";
            this.gameProgressSetBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // gameProgressBackgroundColorPictureBox
            // 
            this.gameProgressBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressBackgroundColorPictureBox.Location = new System.Drawing.Point(48, 20);
            this.gameProgressBackgroundColorPictureBox.Name = "gameProgressBackgroundColorPictureBox";
            this.gameProgressBackgroundColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameProgressBackgroundColorPictureBox.TabIndex = 42;
            this.gameProgressBackgroundColorPictureBox.TabStop = false;
            // 
            // gameProgressValuesGroupBox
            // 
            this.gameProgressValuesGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressValuesGroupBox.Controls.Add(this.gameProgressValuesFontOutlineColorBoxButton);
            this.gameProgressValuesGroupBox.Controls.Add(this.gameProgressValuesFontOutlineColorPictureBox);
            this.gameProgressValuesGroupBox.Controls.Add(this.gameProgressValuesFontColorBoxButton);
            this.gameProgressValuesGroupBox.Controls.Add(this.gameProgressValuesOutlineCheckBox);
            this.gameProgressValuesGroupBox.Controls.Add(this.gameProgressValuesFontOutlineNumericUpDown);
            this.gameProgressValuesGroupBox.Controls.Add(this.gameProgressValuesFontColorPictureBox);
            this.gameProgressValuesGroupBox.Controls.Add(this.gameProgressValuesFontComboBox);
            this.gameProgressValuesGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressValuesGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameProgressValuesGroupBox.Location = new System.Drawing.Point(596, 6);
            this.gameProgressValuesGroupBox.Name = "gameProgressValuesGroupBox";
            this.gameProgressValuesGroupBox.Size = new System.Drawing.Size(165, 125);
            this.gameProgressValuesGroupBox.TabIndex = 10048;
            this.gameProgressValuesGroupBox.TabStop = false;
            this.gameProgressValuesGroupBox.Text = "Values";
            // 
            // gameProgressValuesFontOutlineColorBoxButton
            // 
            this.gameProgressValuesFontOutlineColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressValuesFontOutlineColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameProgressValuesFontOutlineColorBoxButton.Location = new System.Drawing.Point(5, 95);
            this.gameProgressValuesFontOutlineColorBoxButton.Name = "gameProgressValuesFontOutlineColorBoxButton";
            this.gameProgressValuesFontOutlineColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameProgressValuesFontOutlineColorBoxButton.TabIndex = 45;
            this.gameProgressValuesFontOutlineColorBoxButton.Text = "Set";
            this.gameProgressValuesFontOutlineColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameProgressValuesFontOutlineColorPictureBox
            // 
            this.gameProgressValuesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressValuesFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.gameProgressValuesFontOutlineColorPictureBox.Name = "gameProgressValuesFontOutlineColorPictureBox";
            this.gameProgressValuesFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameProgressValuesFontOutlineColorPictureBox.TabIndex = 45;
            this.gameProgressValuesFontOutlineColorPictureBox.TabStop = false;
            // 
            // gameProgressValuesFontColorBoxButton
            // 
            this.gameProgressValuesFontColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressValuesFontColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameProgressValuesFontColorBoxButton.Location = new System.Drawing.Point(5, 45);
            this.gameProgressValuesFontColorBoxButton.Name = "gameProgressValuesFontColorBoxButton";
            this.gameProgressValuesFontColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameProgressValuesFontColorBoxButton.TabIndex = 45;
            this.gameProgressValuesFontColorBoxButton.Text = "Set";
            this.gameProgressValuesFontColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameProgressValuesOutlineCheckBox
            // 
            this.gameProgressValuesOutlineCheckBox.AutoSize = true;
            this.gameProgressValuesOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressValuesOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressValuesOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.gameProgressValuesOutlineCheckBox.Name = "gameProgressValuesOutlineCheckBox";
            this.gameProgressValuesOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.gameProgressValuesOutlineCheckBox.TabIndex = 45;
            this.gameProgressValuesOutlineCheckBox.Text = "Outline";
            this.gameProgressValuesOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameProgressValuesFontOutlineNumericUpDown
            // 
            this.gameProgressValuesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressValuesFontOutlineNumericUpDown.Location = new System.Drawing.Point(91, 97);
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
            this.gameProgressValuesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.gameProgressValuesFontOutlineNumericUpDown.TabIndex = 45;
            this.gameProgressValuesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gameProgressValuesFontColorPictureBox
            // 
            this.gameProgressValuesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressValuesFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.gameProgressValuesFontColorPictureBox.Name = "gameProgressValuesFontColorPictureBox";
            this.gameProgressValuesFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameProgressValuesFontColorPictureBox.TabIndex = 45;
            this.gameProgressValuesFontColorPictureBox.TabStop = false;
            // 
            // gameProgressValuesFontComboBox
            // 
            this.gameProgressValuesFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressValuesFontComboBox.FormattingEnabled = true;
            this.gameProgressValuesFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.gameProgressValuesFontComboBox.Name = "gameProgressValuesFontComboBox";
            this.gameProgressValuesFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.gameProgressValuesFontComboBox.TabIndex = 45;
            // 
            // gameProgressNamesGroupBox
            // 
            this.gameProgressNamesGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressNamesGroupBox.Controls.Add(this.gameProgressNamesFontOutlineColorBoxButton);
            this.gameProgressNamesGroupBox.Controls.Add(this.gameProgressNamesFontOutlineColorPictureBox);
            this.gameProgressNamesGroupBox.Controls.Add(this.gameProgressNamesFontColorBoxButton);
            this.gameProgressNamesGroupBox.Controls.Add(this.gameProgressNamesOutlineCheckBox);
            this.gameProgressNamesGroupBox.Controls.Add(this.gameProgressNamesFontOutlineNumericUpDown);
            this.gameProgressNamesGroupBox.Controls.Add(this.gameProgressNamesFontColorPictureBox);
            this.gameProgressNamesGroupBox.Controls.Add(this.gameProgressNamesFontComboBox);
            this.gameProgressNamesGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressNamesGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameProgressNamesGroupBox.Location = new System.Drawing.Point(425, 6);
            this.gameProgressNamesGroupBox.Name = "gameProgressNamesGroupBox";
            this.gameProgressNamesGroupBox.Size = new System.Drawing.Size(165, 125);
            this.gameProgressNamesGroupBox.TabIndex = 10047;
            this.gameProgressNamesGroupBox.TabStop = false;
            this.gameProgressNamesGroupBox.Text = "Names";
            // 
            // gameProgressNamesFontOutlineColorBoxButton
            // 
            this.gameProgressNamesFontOutlineColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressNamesFontOutlineColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameProgressNamesFontOutlineColorBoxButton.Location = new System.Drawing.Point(5, 95);
            this.gameProgressNamesFontOutlineColorBoxButton.Name = "gameProgressNamesFontOutlineColorBoxButton";
            this.gameProgressNamesFontOutlineColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameProgressNamesFontOutlineColorBoxButton.TabIndex = 45;
            this.gameProgressNamesFontOutlineColorBoxButton.Text = "Set";
            this.gameProgressNamesFontOutlineColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameProgressNamesFontOutlineColorPictureBox
            // 
            this.gameProgressNamesFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressNamesFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.gameProgressNamesFontOutlineColorPictureBox.Name = "gameProgressNamesFontOutlineColorPictureBox";
            this.gameProgressNamesFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameProgressNamesFontOutlineColorPictureBox.TabIndex = 45;
            this.gameProgressNamesFontOutlineColorPictureBox.TabStop = false;
            // 
            // gameProgressNamesFontColorBoxButton
            // 
            this.gameProgressNamesFontColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressNamesFontColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameProgressNamesFontColorBoxButton.Location = new System.Drawing.Point(5, 45);
            this.gameProgressNamesFontColorBoxButton.Name = "gameProgressNamesFontColorBoxButton";
            this.gameProgressNamesFontColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameProgressNamesFontColorBoxButton.TabIndex = 45;
            this.gameProgressNamesFontColorBoxButton.Text = "Set";
            this.gameProgressNamesFontColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameProgressNamesOutlineCheckBox
            // 
            this.gameProgressNamesOutlineCheckBox.AutoSize = true;
            this.gameProgressNamesOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressNamesOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressNamesOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.gameProgressNamesOutlineCheckBox.Name = "gameProgressNamesOutlineCheckBox";
            this.gameProgressNamesOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.gameProgressNamesOutlineCheckBox.TabIndex = 45;
            this.gameProgressNamesOutlineCheckBox.Text = "Outline";
            this.gameProgressNamesOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameProgressNamesFontOutlineNumericUpDown
            // 
            this.gameProgressNamesFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressNamesFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
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
            this.gameProgressNamesFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.gameProgressNamesFontOutlineNumericUpDown.TabIndex = 45;
            this.gameProgressNamesFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gameProgressNamesFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gameProgressNamesFontColorPictureBox
            // 
            this.gameProgressNamesFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressNamesFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.gameProgressNamesFontColorPictureBox.Name = "gameProgressNamesFontColorPictureBox";
            this.gameProgressNamesFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameProgressNamesFontColorPictureBox.TabIndex = 45;
            this.gameProgressNamesFontColorPictureBox.TabStop = false;
            // 
            // gameProgressNamesFontComboBox
            // 
            this.gameProgressNamesFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressNamesFontComboBox.FormattingEnabled = true;
            this.gameProgressNamesFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.gameProgressNamesFontComboBox.Name = "gameProgressNamesFontComboBox";
            this.gameProgressNamesFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.gameProgressNamesFontComboBox.TabIndex = 45;
            // 
            // gameProgressSimpleGroupBox
            // 
            this.gameProgressSimpleGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.gameProgressSimpleGroupBox.Controls.Add(this.gameProgressSimpleFontOutlineColorBoxButton);
            this.gameProgressSimpleGroupBox.Controls.Add(this.gameProgressSimpleFontOutlineColorPictureBox);
            this.gameProgressSimpleGroupBox.Controls.Add(this.gameProgressSimpleFontColorBoxButton);
            this.gameProgressSimpleGroupBox.Controls.Add(this.gameProgressSimpleOutlineCheckBox);
            this.gameProgressSimpleGroupBox.Controls.Add(this.gameProgressSimpleFontOutlineNumericUpDown);
            this.gameProgressSimpleGroupBox.Controls.Add(this.gameProgressSimpleFontColorPictureBox);
            this.gameProgressSimpleGroupBox.Controls.Add(this.gameProgressSimpleFontComboBox);
            this.gameProgressSimpleGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressSimpleGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameProgressSimpleGroupBox.Location = new System.Drawing.Point(425, 6);
            this.gameProgressSimpleGroupBox.Name = "gameProgressSimpleGroupBox";
            this.gameProgressSimpleGroupBox.Size = new System.Drawing.Size(165, 125);
            this.gameProgressSimpleGroupBox.TabIndex = 10048;
            this.gameProgressSimpleGroupBox.TabStop = false;
            this.gameProgressSimpleGroupBox.Text = "All";
            // 
            // gameProgressSimpleFontOutlineColorBoxButton
            // 
            this.gameProgressSimpleFontOutlineColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressSimpleFontOutlineColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameProgressSimpleFontOutlineColorBoxButton.Location = new System.Drawing.Point(5, 95);
            this.gameProgressSimpleFontOutlineColorBoxButton.Name = "gameProgressSimpleFontOutlineColorBoxButton";
            this.gameProgressSimpleFontOutlineColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameProgressSimpleFontOutlineColorBoxButton.TabIndex = 45;
            this.gameProgressSimpleFontOutlineColorBoxButton.Text = "Set";
            this.gameProgressSimpleFontOutlineColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameProgressSimpleFontOutlineColorPictureBox
            // 
            this.gameProgressSimpleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressSimpleFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.gameProgressSimpleFontOutlineColorPictureBox.Name = "gameProgressSimpleFontOutlineColorPictureBox";
            this.gameProgressSimpleFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameProgressSimpleFontOutlineColorPictureBox.TabIndex = 45;
            this.gameProgressSimpleFontOutlineColorPictureBox.TabStop = false;
            // 
            // gameProgressSimpleFontColorBoxButton
            // 
            this.gameProgressSimpleFontColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressSimpleFontColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameProgressSimpleFontColorBoxButton.Location = new System.Drawing.Point(5, 45);
            this.gameProgressSimpleFontColorBoxButton.Name = "gameProgressSimpleFontColorBoxButton";
            this.gameProgressSimpleFontColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameProgressSimpleFontColorBoxButton.TabIndex = 45;
            this.gameProgressSimpleFontColorBoxButton.Text = "Set";
            this.gameProgressSimpleFontColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameProgressSimpleOutlineCheckBox
            // 
            this.gameProgressSimpleOutlineCheckBox.AutoSize = true;
            this.gameProgressSimpleOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressSimpleOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameProgressSimpleOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.gameProgressSimpleOutlineCheckBox.Name = "gameProgressSimpleOutlineCheckBox";
            this.gameProgressSimpleOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.gameProgressSimpleOutlineCheckBox.TabIndex = 45;
            this.gameProgressSimpleOutlineCheckBox.Text = "Outline";
            this.gameProgressSimpleOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameProgressSimpleFontOutlineNumericUpDown
            // 
            this.gameProgressSimpleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressSimpleFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
            this.gameProgressSimpleFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.gameProgressSimpleFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gameProgressSimpleFontOutlineNumericUpDown.Name = "gameProgressSimpleFontOutlineNumericUpDown";
            this.gameProgressSimpleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.gameProgressSimpleFontOutlineNumericUpDown.TabIndex = 45;
            this.gameProgressSimpleFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gameProgressSimpleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gameProgressSimpleFontColorPictureBox
            // 
            this.gameProgressSimpleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameProgressSimpleFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.gameProgressSimpleFontColorPictureBox.Name = "gameProgressSimpleFontColorPictureBox";
            this.gameProgressSimpleFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameProgressSimpleFontColorPictureBox.TabIndex = 45;
            this.gameProgressSimpleFontColorPictureBox.TabStop = false;
            // 
            // gameProgressSimpleFontComboBox
            // 
            this.gameProgressSimpleFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProgressSimpleFontComboBox.FormattingEnabled = true;
            this.gameProgressSimpleFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.gameProgressSimpleFontComboBox.Name = "gameProgressSimpleFontComboBox";
            this.gameProgressSimpleFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.gameProgressSimpleFontComboBox.TabIndex = 45;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tabPage7.Controls.Add(this.gameInfoReleasedLabel);
            this.tabPage7.Controls.Add(this.gameInfoGenreLabel);
            this.tabPage7.Controls.Add(this.gameInfoConsoleLabel);
            this.tabPage7.Controls.Add(this.gameInfoPublisherLabel);
            this.tabPage7.Controls.Add(this.gameInfoDeveloperLabel);
            this.tabPage7.Controls.Add(this.gameInfoSimpleCheckBox);
            this.tabPage7.Controls.Add(this.gameInfoBackgroundColorGroupBox);
            this.tabPage7.Controls.Add(this.gameInfoValuesGroupBox);
            this.tabPage7.Controls.Add(this.gameInfoNamesGroupBox);
            this.tabPage7.Controls.Add(this.gameInfoGenreTextBox);
            this.tabPage7.Controls.Add(this.gameInfoDefaultButton);
            this.tabPage7.Controls.Add(this.gameInfoPictureBox);
            this.tabPage7.Controls.Add(this.gameInfoAutoOpenWindowCheckbox);
            this.tabPage7.Controls.Add(this.gameInfoConsoleTextBox);
            this.tabPage7.Controls.Add(this.gameInfoOpenWindowButton);
            this.tabPage7.Controls.Add(this.gameInfoPublisherTextBox);
            this.tabPage7.Controls.Add(this.gameInfoReleasedCheckBox);
            this.tabPage7.Controls.Add(this.gameInfoDeveloperTextBox);
            this.tabPage7.Controls.Add(this.gameInfoReleaseDateTextBox);
            this.tabPage7.Controls.Add(this.gameInfoTitleTextBox);
            this.tabPage7.Controls.Add(this.gameInfoTitleCheckBox);
            this.tabPage7.Controls.Add(this.gameInfoConsoleCheckBox);
            this.tabPage7.Controls.Add(this.gameInfoDeveloperCheckBox);
            this.tabPage7.Controls.Add(this.gameInfoGenreCheckBox);
            this.tabPage7.Controls.Add(this.gameInfoTitleLabel);
            this.tabPage7.Controls.Add(this.gameInfoPublisherCheckBox);
            this.tabPage7.Controls.Add(this.gameInfoSimpleGroupBox);
            this.tabPage7.Location = new System.Drawing.Point(4, 24);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(769, 292);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "Game Info";
            // 
            // gameInfoReleasedLabel
            // 
            this.gameInfoReleasedLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoReleasedLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoReleasedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoReleasedLabel.Location = new System.Drawing.Point(422, 263);
            this.gameInfoReleasedLabel.Name = "gameInfoReleasedLabel";
            this.gameInfoReleasedLabel.Size = new System.Drawing.Size(339, 16);
            this.gameInfoReleasedLabel.TabIndex = 10067;
            // 
            // gameInfoGenreLabel
            // 
            this.gameInfoGenreLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoGenreLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoGenreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoGenreLabel.Location = new System.Drawing.Point(422, 247);
            this.gameInfoGenreLabel.Name = "gameInfoGenreLabel";
            this.gameInfoGenreLabel.Size = new System.Drawing.Size(339, 16);
            this.gameInfoGenreLabel.TabIndex = 10066;
            // 
            // gameInfoConsoleLabel
            // 
            this.gameInfoConsoleLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoConsoleLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoConsoleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoConsoleLabel.Location = new System.Drawing.Point(422, 231);
            this.gameInfoConsoleLabel.Name = "gameInfoConsoleLabel";
            this.gameInfoConsoleLabel.Size = new System.Drawing.Size(339, 16);
            this.gameInfoConsoleLabel.TabIndex = 10065;
            // 
            // gameInfoPublisherLabel
            // 
            this.gameInfoPublisherLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoPublisherLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoPublisherLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoPublisherLabel.Location = new System.Drawing.Point(422, 199);
            this.gameInfoPublisherLabel.Name = "gameInfoPublisherLabel";
            this.gameInfoPublisherLabel.Size = new System.Drawing.Size(339, 32);
            this.gameInfoPublisherLabel.TabIndex = 10064;
            // 
            // gameInfoDeveloperLabel
            // 
            this.gameInfoDeveloperLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoDeveloperLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoDeveloperLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoDeveloperLabel.Location = new System.Drawing.Point(422, 167);
            this.gameInfoDeveloperLabel.Name = "gameInfoDeveloperLabel";
            this.gameInfoDeveloperLabel.Size = new System.Drawing.Size(339, 32);
            this.gameInfoDeveloperLabel.TabIndex = 10063;
            // 
            // gameInfoSimpleCheckBox
            // 
            this.gameInfoSimpleCheckBox.AutoSize = true;
            this.gameInfoSimpleCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoSimpleCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoSimpleCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoSimpleCheckBox.Location = new System.Drawing.Point(343, 120);
            this.gameInfoSimpleCheckBox.Name = "gameInfoSimpleCheckBox";
            this.gameInfoSimpleCheckBox.Size = new System.Drawing.Size(82, 22);
            this.gameInfoSimpleCheckBox.TabIndex = 10055;
            this.gameInfoSimpleCheckBox.Text = "Simple";
            this.gameInfoSimpleCheckBox.UseVisualStyleBackColor = false;
            // 
            // gameInfoSimpleGroupBox
            // 
            this.gameInfoSimpleGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoSimpleGroupBox.Controls.Add(this.gameInfoSimpleFontOutlineColorBoxButton);
            this.gameInfoSimpleGroupBox.Controls.Add(this.gameInfoSimpleFontOutlineColorPictureBox);
            this.gameInfoSimpleGroupBox.Controls.Add(this.gameInfoSimpleFontColorBoxButton);
            this.gameInfoSimpleGroupBox.Controls.Add(this.gameInfoSimpleOutlineCheckBox);
            this.gameInfoSimpleGroupBox.Controls.Add(this.gameInfoSimpleFontOutlineNumericUpDown);
            this.gameInfoSimpleGroupBox.Controls.Add(this.gameInfoSimpleFontColorPictureBox);
            this.gameInfoSimpleGroupBox.Controls.Add(this.gameInfoSimpleFontComboBox);
            this.gameInfoSimpleGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoSimpleGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.gameInfoSimpleGroupBox.Location = new System.Drawing.Point(425, 6);
            this.gameInfoSimpleGroupBox.Name = "gameInfoSimpleGroupBox";
            this.gameInfoSimpleGroupBox.Size = new System.Drawing.Size(165, 125);
            this.gameInfoSimpleGroupBox.TabIndex = 47;
            this.gameInfoSimpleGroupBox.TabStop = false;
            this.gameInfoSimpleGroupBox.Text = "All";
            // 
            // gameInfoSimpleFontOutlineColorBoxButton
            // 
            this.gameInfoSimpleFontOutlineColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoSimpleFontOutlineColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameInfoSimpleFontOutlineColorBoxButton.Location = new System.Drawing.Point(5, 95);
            this.gameInfoSimpleFontOutlineColorBoxButton.Name = "gameInfoSimpleFontOutlineColorBoxButton";
            this.gameInfoSimpleFontOutlineColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameInfoSimpleFontOutlineColorBoxButton.TabIndex = 45;
            this.gameInfoSimpleFontOutlineColorBoxButton.Text = "Set";
            this.gameInfoSimpleFontOutlineColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoSimpleFontOutlineColorPictureBox
            // 
            this.gameInfoSimpleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoSimpleFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.gameInfoSimpleFontOutlineColorPictureBox.Name = "gameInfoSimpleFontOutlineColorPictureBox";
            this.gameInfoSimpleFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameInfoSimpleFontOutlineColorPictureBox.TabIndex = 45;
            this.gameInfoSimpleFontOutlineColorPictureBox.TabStop = false;
            // 
            // gameInfoSimpleFontColorBoxButton
            // 
            this.gameInfoSimpleFontColorBoxButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoSimpleFontColorBoxButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameInfoSimpleFontColorBoxButton.Location = new System.Drawing.Point(5, 45);
            this.gameInfoSimpleFontColorBoxButton.Name = "gameInfoSimpleFontColorBoxButton";
            this.gameInfoSimpleFontColorBoxButton.Size = new System.Drawing.Size(49, 23);
            this.gameInfoSimpleFontColorBoxButton.TabIndex = 45;
            this.gameInfoSimpleFontColorBoxButton.Text = "Set";
            this.gameInfoSimpleFontColorBoxButton.UseVisualStyleBackColor = true;
            // 
            // gameInfoSimpleOutlineCheckBox
            // 
            this.gameInfoSimpleOutlineCheckBox.AutoSize = true;
            this.gameInfoSimpleOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoSimpleOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.gameInfoSimpleOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.gameInfoSimpleOutlineCheckBox.Name = "gameInfoSimpleOutlineCheckBox";
            this.gameInfoSimpleOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.gameInfoSimpleOutlineCheckBox.TabIndex = 45;
            this.gameInfoSimpleOutlineCheckBox.Text = "Outline";
            this.gameInfoSimpleOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameInfoSimpleFontOutlineNumericUpDown
            // 
            this.gameInfoSimpleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoSimpleFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
            this.gameInfoSimpleFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.gameInfoSimpleFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gameInfoSimpleFontOutlineNumericUpDown.Name = "gameInfoSimpleFontOutlineNumericUpDown";
            this.gameInfoSimpleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.gameInfoSimpleFontOutlineNumericUpDown.TabIndex = 45;
            this.gameInfoSimpleFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gameInfoSimpleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gameInfoSimpleFontColorPictureBox
            // 
            this.gameInfoSimpleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameInfoSimpleFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.gameInfoSimpleFontColorPictureBox.Name = "gameInfoSimpleFontColorPictureBox";
            this.gameInfoSimpleFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.gameInfoSimpleFontColorPictureBox.TabIndex = 45;
            this.gameInfoSimpleFontColorPictureBox.TabStop = false;
            // 
            // gameInfoSimpleFontComboBox
            // 
            this.gameInfoSimpleFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoSimpleFontComboBox.FormattingEnabled = true;
            this.gameInfoSimpleFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.gameInfoSimpleFontComboBox.Name = "gameInfoSimpleFontComboBox";
            this.gameInfoSimpleFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.gameInfoSimpleFontComboBox.TabIndex = 45;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tabPage8.Controls.Add(this.recentAchievementsScrollCheckBox);
            this.tabPage8.Controls.Add(this.recentAchievementsSimpleCheckBox);
            this.tabPage8.Controls.Add(this.recentAchievementsBorderCheckBox);
            this.tabPage8.Controls.Add(this.recentAchievementsBackgroundColorGroupBox);
            this.tabPage8.Controls.Add(this.groupBox5);
            this.tabPage8.Controls.Add(this.recentAchievementsLineGroupBox);
            this.tabPage8.Controls.Add(this.recentAchievementsPointsGroupBox);
            this.tabPage8.Controls.Add(this.recentAchievementsTitleGroupBox);
            this.tabPage8.Controls.Add(this.recentAchievementsDescriptionGroupBox);
            this.tabPage8.Controls.Add(this.recentAchievementsOpenWindowButton);
            this.tabPage8.Controls.Add(this.recentAchievementsAutoOpenWindowCheckbox);
            this.tabPage8.Controls.Add(this.recentAchievementsMaxListNumericUpDown);
            this.tabPage8.Controls.Add(this.recentAchievementsMaxListLabel);
            this.tabPage8.Controls.Add(this.recentAchievementsSimpleGroupBox);
            this.tabPage8.Location = new System.Drawing.Point(4, 24);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(769, 292);
            this.tabPage8.TabIndex = 5;
            this.tabPage8.Text = "Recent Unlocks";
            // 
            // recentAchievementsScrollCheckBox
            // 
            this.recentAchievementsScrollCheckBox.AutoSize = true;
            this.recentAchievementsScrollCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsScrollCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsScrollCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsScrollCheckBox.Location = new System.Drawing.Point(343, 178);
            this.recentAchievementsScrollCheckBox.Name = "recentAchievementsScrollCheckBox";
            this.recentAchievementsScrollCheckBox.Size = new System.Drawing.Size(71, 22);
            this.recentAchievementsScrollCheckBox.TabIndex = 10055;
            this.recentAchievementsScrollCheckBox.Text = "Scroll";
            this.recentAchievementsScrollCheckBox.UseVisualStyleBackColor = false;
            // 
            // recentAchievementsSimpleCheckBox
            // 
            this.recentAchievementsSimpleCheckBox.AutoSize = true;
            this.recentAchievementsSimpleCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsSimpleCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsSimpleCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsSimpleCheckBox.Location = new System.Drawing.Point(343, 120);
            this.recentAchievementsSimpleCheckBox.Name = "recentAchievementsSimpleCheckBox";
            this.recentAchievementsSimpleCheckBox.Size = new System.Drawing.Size(82, 22);
            this.recentAchievementsSimpleCheckBox.TabIndex = 10054;
            this.recentAchievementsSimpleCheckBox.Text = "Simple";
            this.recentAchievementsSimpleCheckBox.UseVisualStyleBackColor = false;
            // 
            // recentAchievementsBorderCheckBox
            // 
            this.recentAchievementsBorderCheckBox.AutoSize = true;
            this.recentAchievementsBorderCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsBorderCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsBorderCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsBorderCheckBox.Location = new System.Drawing.Point(343, 149);
            this.recentAchievementsBorderCheckBox.Name = "recentAchievementsBorderCheckBox";
            this.recentAchievementsBorderCheckBox.Size = new System.Drawing.Size(80, 22);
            this.recentAchievementsBorderCheckBox.TabIndex = 10053;
            this.recentAchievementsBorderCheckBox.Text = "Border";
            this.recentAchievementsBorderCheckBox.UseVisualStyleBackColor = false;
            // 
            // recentAchievementsBackgroundColorGroupBox
            // 
            this.recentAchievementsBackgroundColorGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.recentAchievementsBackgroundColorGroupBox.Controls.Add(this.recentAchievementsSetBackgroundColorButton);
            this.recentAchievementsBackgroundColorGroupBox.Controls.Add(this.recentAchievementsBackgroundColorPictureBox);
            this.recentAchievementsBackgroundColorGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsBackgroundColorGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.recentAchievementsBackgroundColorGroupBox.Location = new System.Drawing.Point(339, 6);
            this.recentAchievementsBackgroundColorGroupBox.Name = "recentAchievementsBackgroundColorGroupBox";
            this.recentAchievementsBackgroundColorGroupBox.Size = new System.Drawing.Size(80, 49);
            this.recentAchievementsBackgroundColorGroupBox.TabIndex = 10051;
            this.recentAchievementsBackgroundColorGroupBox.TabStop = false;
            this.recentAchievementsBackgroundColorGroupBox.Text = "Back";
            // 
            // recentAchievementsSetBackgroundColorButton
            // 
            this.recentAchievementsSetBackgroundColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsSetBackgroundColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsSetBackgroundColorButton.Location = new System.Drawing.Point(6, 20);
            this.recentAchievementsSetBackgroundColorButton.Name = "recentAchievementsSetBackgroundColorButton";
            this.recentAchievementsSetBackgroundColorButton.Size = new System.Drawing.Size(36, 23);
            this.recentAchievementsSetBackgroundColorButton.TabIndex = 43;
            this.recentAchievementsSetBackgroundColorButton.Text = "Set";
            this.recentAchievementsSetBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsBackgroundColorPictureBox
            // 
            this.recentAchievementsBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsBackgroundColorPictureBox.Location = new System.Drawing.Point(48, 20);
            this.recentAchievementsBackgroundColorPictureBox.Name = "recentAchievementsBackgroundColorPictureBox";
            this.recentAchievementsBackgroundColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsBackgroundColorPictureBox.TabIndex = 42;
            this.recentAchievementsBackgroundColorPictureBox.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.recentAchievementsSetBorderColorButton);
            this.groupBox5.Controls.Add(this.recentAchievementsBorderColorPictureBox);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.groupBox5.Location = new System.Drawing.Point(339, 61);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(80, 49);
            this.groupBox5.TabIndex = 10052;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Border";
            // 
            // recentAchievementsSetBorderColorButton
            // 
            this.recentAchievementsSetBorderColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsSetBorderColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsSetBorderColorButton.Location = new System.Drawing.Point(6, 20);
            this.recentAchievementsSetBorderColorButton.Name = "recentAchievementsSetBorderColorButton";
            this.recentAchievementsSetBorderColorButton.Size = new System.Drawing.Size(36, 23);
            this.recentAchievementsSetBorderColorButton.TabIndex = 43;
            this.recentAchievementsSetBorderColorButton.Text = "Set";
            this.recentAchievementsSetBorderColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsBorderColorPictureBox
            // 
            this.recentAchievementsBorderColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsBorderColorPictureBox.Location = new System.Drawing.Point(48, 20);
            this.recentAchievementsBorderColorPictureBox.Name = "recentAchievementsBorderColorPictureBox";
            this.recentAchievementsBorderColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsBorderColorPictureBox.TabIndex = 42;
            this.recentAchievementsBorderColorPictureBox.TabStop = false;
            // 
            // recentAchievementsLineGroupBox
            // 
            this.recentAchievementsLineGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsLineGroupBox.Controls.Add(this.recentAchievementsLineSetColorButton);
            this.recentAchievementsLineGroupBox.Controls.Add(this.recentAchievementsLineColorPictureBox);
            this.recentAchievementsLineGroupBox.Controls.Add(this.recentAchievementsLineOutlineSetColorButton);
            this.recentAchievementsLineGroupBox.Controls.Add(this.recentAchievementsLineOutlineCheckBox);
            this.recentAchievementsLineGroupBox.Controls.Add(this.recentAchievementsLineOutlineNumericUpDown);
            this.recentAchievementsLineGroupBox.Controls.Add(this.recentAchievementsLineOutlineColorPictureBox);
            this.recentAchievementsLineGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsLineGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.recentAchievementsLineGroupBox.Location = new System.Drawing.Point(596, 137);
            this.recentAchievementsLineGroupBox.Name = "recentAchievementsLineGroupBox";
            this.recentAchievementsLineGroupBox.Size = new System.Drawing.Size(165, 125);
            this.recentAchievementsLineGroupBox.TabIndex = 10050;
            this.recentAchievementsLineGroupBox.TabStop = false;
            this.recentAchievementsLineGroupBox.Text = "Line";
            // 
            // recentAchievementsLineSetColorButton
            // 
            this.recentAchievementsLineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsLineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsLineSetColorButton.Location = new System.Drawing.Point(6, 46);
            this.recentAchievementsLineSetColorButton.Name = "recentAchievementsLineSetColorButton";
            this.recentAchievementsLineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.recentAchievementsLineSetColorButton.TabIndex = 45;
            this.recentAchievementsLineSetColorButton.Text = "Set";
            this.recentAchievementsLineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsLineColorPictureBox
            // 
            this.recentAchievementsLineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsLineColorPictureBox.Location = new System.Drawing.Point(61, 46);
            this.recentAchievementsLineColorPictureBox.Name = "recentAchievementsLineColorPictureBox";
            this.recentAchievementsLineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsLineColorPictureBox.TabIndex = 45;
            this.recentAchievementsLineColorPictureBox.TabStop = false;
            // 
            // recentAchievementsLineOutlineSetColorButton
            // 
            this.recentAchievementsLineOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsLineOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsLineOutlineSetColorButton.Location = new System.Drawing.Point(6, 95);
            this.recentAchievementsLineOutlineSetColorButton.Name = "recentAchievementsLineOutlineSetColorButton";
            this.recentAchievementsLineOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.recentAchievementsLineOutlineSetColorButton.TabIndex = 45;
            this.recentAchievementsLineOutlineSetColorButton.Text = "Set";
            this.recentAchievementsLineOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsLineOutlineCheckBox
            // 
            this.recentAchievementsLineOutlineCheckBox.AutoSize = true;
            this.recentAchievementsLineOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsLineOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsLineOutlineCheckBox.Location = new System.Drawing.Point(7, 75);
            this.recentAchievementsLineOutlineCheckBox.Name = "recentAchievementsLineOutlineCheckBox";
            this.recentAchievementsLineOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.recentAchievementsLineOutlineCheckBox.TabIndex = 45;
            this.recentAchievementsLineOutlineCheckBox.Text = "Outline";
            this.recentAchievementsLineOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsLineOutlineNumericUpDown
            // 
            this.recentAchievementsLineOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsLineOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
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
            this.recentAchievementsLineOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.recentAchievementsLineOutlineNumericUpDown.TabIndex = 45;
            this.recentAchievementsLineOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // recentAchievementsLineOutlineColorPictureBox
            // 
            this.recentAchievementsLineOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsLineOutlineColorPictureBox.Location = new System.Drawing.Point(61, 95);
            this.recentAchievementsLineOutlineColorPictureBox.Name = "recentAchievementsLineOutlineColorPictureBox";
            this.recentAchievementsLineOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsLineOutlineColorPictureBox.TabIndex = 45;
            this.recentAchievementsLineOutlineColorPictureBox.TabStop = false;
            // 
            // recentAchievementsPointsGroupBox
            // 
            this.recentAchievementsPointsGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsPointsGroupBox.Controls.Add(this.recentAchievementsPointsFontOutlineSetColorButton);
            this.recentAchievementsPointsGroupBox.Controls.Add(this.recentAchievementsPointsFontOutlineColorPictureBox);
            this.recentAchievementsPointsGroupBox.Controls.Add(this.recentAchievementsPointsFontSetColorButton);
            this.recentAchievementsPointsGroupBox.Controls.Add(this.recentAchievementsPointsFontOutlineCheckBox);
            this.recentAchievementsPointsGroupBox.Controls.Add(this.recentAchievementsPointsFontOutlineNumericUpDown);
            this.recentAchievementsPointsGroupBox.Controls.Add(this.recentAchievementsPointsFontColorPictureBox);
            this.recentAchievementsPointsGroupBox.Controls.Add(this.recentAchievementsPointsFontComboBox);
            this.recentAchievementsPointsGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsPointsGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.recentAchievementsPointsGroupBox.Location = new System.Drawing.Point(425, 137);
            this.recentAchievementsPointsGroupBox.Name = "recentAchievementsPointsGroupBox";
            this.recentAchievementsPointsGroupBox.Size = new System.Drawing.Size(165, 125);
            this.recentAchievementsPointsGroupBox.TabIndex = 10049;
            this.recentAchievementsPointsGroupBox.TabStop = false;
            this.recentAchievementsPointsGroupBox.Text = "Points";
            // 
            // recentAchievementsPointsFontOutlineSetColorButton
            // 
            this.recentAchievementsPointsFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsPointsFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsPointsFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.recentAchievementsPointsFontOutlineSetColorButton.Name = "recentAchievementsPointsFontOutlineSetColorButton";
            this.recentAchievementsPointsFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.recentAchievementsPointsFontOutlineSetColorButton.TabIndex = 45;
            this.recentAchievementsPointsFontOutlineSetColorButton.Text = "Set";
            this.recentAchievementsPointsFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsPointsFontOutlineColorPictureBox
            // 
            this.recentAchievementsPointsFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsPointsFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.recentAchievementsPointsFontOutlineColorPictureBox.Name = "recentAchievementsPointsFontOutlineColorPictureBox";
            this.recentAchievementsPointsFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsPointsFontOutlineColorPictureBox.TabIndex = 45;
            this.recentAchievementsPointsFontOutlineColorPictureBox.TabStop = false;
            // 
            // recentAchievementsPointsFontSetColorButton
            // 
            this.recentAchievementsPointsFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsPointsFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsPointsFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.recentAchievementsPointsFontSetColorButton.Name = "recentAchievementsPointsFontSetColorButton";
            this.recentAchievementsPointsFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.recentAchievementsPointsFontSetColorButton.TabIndex = 45;
            this.recentAchievementsPointsFontSetColorButton.Text = "Set";
            this.recentAchievementsPointsFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsPointsFontOutlineCheckBox
            // 
            this.recentAchievementsPointsFontOutlineCheckBox.AutoSize = true;
            this.recentAchievementsPointsFontOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsPointsFontOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsPointsFontOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.recentAchievementsPointsFontOutlineCheckBox.Name = "recentAchievementsPointsFontOutlineCheckBox";
            this.recentAchievementsPointsFontOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.recentAchievementsPointsFontOutlineCheckBox.TabIndex = 45;
            this.recentAchievementsPointsFontOutlineCheckBox.Text = "Outline";
            this.recentAchievementsPointsFontOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsPointsFontOutlineNumericUpDown
            // 
            this.recentAchievementsPointsFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsPointsFontOutlineNumericUpDown.Location = new System.Drawing.Point(90, 97);
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
            this.recentAchievementsPointsFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.recentAchievementsPointsFontOutlineNumericUpDown.TabIndex = 45;
            this.recentAchievementsPointsFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // recentAchievementsPointsFontColorPictureBox
            // 
            this.recentAchievementsPointsFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsPointsFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.recentAchievementsPointsFontColorPictureBox.Name = "recentAchievementsPointsFontColorPictureBox";
            this.recentAchievementsPointsFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsPointsFontColorPictureBox.TabIndex = 45;
            this.recentAchievementsPointsFontColorPictureBox.TabStop = false;
            // 
            // recentAchievementsPointsFontComboBox
            // 
            this.recentAchievementsPointsFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsPointsFontComboBox.FormattingEnabled = true;
            this.recentAchievementsPointsFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.recentAchievementsPointsFontComboBox.Name = "recentAchievementsPointsFontComboBox";
            this.recentAchievementsPointsFontComboBox.Size = new System.Drawing.Size(157, 24);
            this.recentAchievementsPointsFontComboBox.TabIndex = 45;
            // 
            // recentAchievementsTitleGroupBox
            // 
            this.recentAchievementsTitleGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsTitleGroupBox.Controls.Add(this.recentAchievementsTitleFontOutlineSetColorButton);
            this.recentAchievementsTitleGroupBox.Controls.Add(this.recentAchievementsTitleFontOutlineColorPictureBox);
            this.recentAchievementsTitleGroupBox.Controls.Add(this.recentAchievementsTitleFontSetColorButton);
            this.recentAchievementsTitleGroupBox.Controls.Add(this.recentAchievementsTitleFontOutlineCheckBox);
            this.recentAchievementsTitleGroupBox.Controls.Add(this.recentAchievementsTitleFontOutlineNumericUpDown);
            this.recentAchievementsTitleGroupBox.Controls.Add(this.recentAchievementsTitleFontColorPictureBox);
            this.recentAchievementsTitleGroupBox.Controls.Add(this.recentAchievementsTitleFontComboBox);
            this.recentAchievementsTitleGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsTitleGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.recentAchievementsTitleGroupBox.Location = new System.Drawing.Point(425, 6);
            this.recentAchievementsTitleGroupBox.Name = "recentAchievementsTitleGroupBox";
            this.recentAchievementsTitleGroupBox.Size = new System.Drawing.Size(165, 125);
            this.recentAchievementsTitleGroupBox.TabIndex = 10047;
            this.recentAchievementsTitleGroupBox.TabStop = false;
            this.recentAchievementsTitleGroupBox.Text = "Title";
            // 
            // recentAchievementsTitleFontOutlineSetColorButton
            // 
            this.recentAchievementsTitleFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsTitleFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsTitleFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.recentAchievementsTitleFontOutlineSetColorButton.Name = "recentAchievementsTitleFontOutlineSetColorButton";
            this.recentAchievementsTitleFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.recentAchievementsTitleFontOutlineSetColorButton.TabIndex = 45;
            this.recentAchievementsTitleFontOutlineSetColorButton.Text = "Set";
            this.recentAchievementsTitleFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsTitleFontOutlineColorPictureBox
            // 
            this.recentAchievementsTitleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsTitleFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.recentAchievementsTitleFontOutlineColorPictureBox.Name = "recentAchievementsTitleFontOutlineColorPictureBox";
            this.recentAchievementsTitleFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsTitleFontOutlineColorPictureBox.TabIndex = 45;
            this.recentAchievementsTitleFontOutlineColorPictureBox.TabStop = false;
            // 
            // recentAchievementsTitleFontSetColorButton
            // 
            this.recentAchievementsTitleFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsTitleFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsTitleFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.recentAchievementsTitleFontSetColorButton.Name = "recentAchievementsTitleFontSetColorButton";
            this.recentAchievementsTitleFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.recentAchievementsTitleFontSetColorButton.TabIndex = 45;
            this.recentAchievementsTitleFontSetColorButton.Text = "Set";
            this.recentAchievementsTitleFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsTitleFontOutlineCheckBox
            // 
            this.recentAchievementsTitleFontOutlineCheckBox.AutoSize = true;
            this.recentAchievementsTitleFontOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsTitleFontOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsTitleFontOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.recentAchievementsTitleFontOutlineCheckBox.Name = "recentAchievementsTitleFontOutlineCheckBox";
            this.recentAchievementsTitleFontOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.recentAchievementsTitleFontOutlineCheckBox.TabIndex = 45;
            this.recentAchievementsTitleFontOutlineCheckBox.Text = "Outline";
            this.recentAchievementsTitleFontOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsTitleFontOutlineNumericUpDown
            // 
            this.recentAchievementsTitleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsTitleFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
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
            this.recentAchievementsTitleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.recentAchievementsTitleFontOutlineNumericUpDown.TabIndex = 45;
            this.recentAchievementsTitleFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.recentAchievementsTitleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // recentAchievementsTitleFontColorPictureBox
            // 
            this.recentAchievementsTitleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsTitleFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.recentAchievementsTitleFontColorPictureBox.Name = "recentAchievementsTitleFontColorPictureBox";
            this.recentAchievementsTitleFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsTitleFontColorPictureBox.TabIndex = 45;
            this.recentAchievementsTitleFontColorPictureBox.TabStop = false;
            // 
            // recentAchievementsTitleFontComboBox
            // 
            this.recentAchievementsTitleFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsTitleFontComboBox.FormattingEnabled = true;
            this.recentAchievementsTitleFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.recentAchievementsTitleFontComboBox.Name = "recentAchievementsTitleFontComboBox";
            this.recentAchievementsTitleFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.recentAchievementsTitleFontComboBox.TabIndex = 45;
            // 
            // recentAchievementsDescriptionGroupBox
            // 
            this.recentAchievementsDescriptionGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsDescriptionGroupBox.Controls.Add(this.recentAchievementsDescriptionFontOutlineSetColorButton);
            this.recentAchievementsDescriptionGroupBox.Controls.Add(this.recentAchievementsDescriptionFontOutlineColorPictureBox);
            this.recentAchievementsDescriptionGroupBox.Controls.Add(this.recentAchievementsDescriptionFontSetColorButton);
            this.recentAchievementsDescriptionGroupBox.Controls.Add(this.recentAchievementsDescriptionFontOutlineCheckBox);
            this.recentAchievementsDescriptionGroupBox.Controls.Add(this.recentAchievementsDescriptionFontOutlineNumericUpDown);
            this.recentAchievementsDescriptionGroupBox.Controls.Add(this.recentAchievementsDescriptionFontColorPictureBox);
            this.recentAchievementsDescriptionGroupBox.Controls.Add(this.recentAchievementsDescriptionFontComboBox);
            this.recentAchievementsDescriptionGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsDescriptionGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.recentAchievementsDescriptionGroupBox.Location = new System.Drawing.Point(596, 6);
            this.recentAchievementsDescriptionGroupBox.Name = "recentAchievementsDescriptionGroupBox";
            this.recentAchievementsDescriptionGroupBox.Size = new System.Drawing.Size(165, 125);
            this.recentAchievementsDescriptionGroupBox.TabIndex = 10048;
            this.recentAchievementsDescriptionGroupBox.TabStop = false;
            this.recentAchievementsDescriptionGroupBox.Text = "Description";
            // 
            // recentAchievementsDescriptionFontOutlineSetColorButton
            // 
            this.recentAchievementsDescriptionFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsDescriptionFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsDescriptionFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.recentAchievementsDescriptionFontOutlineSetColorButton.Name = "recentAchievementsDescriptionFontOutlineSetColorButton";
            this.recentAchievementsDescriptionFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.recentAchievementsDescriptionFontOutlineSetColorButton.TabIndex = 45;
            this.recentAchievementsDescriptionFontOutlineSetColorButton.Text = "Set";
            this.recentAchievementsDescriptionFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsDescriptionFontOutlineColorPictureBox
            // 
            this.recentAchievementsDescriptionFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsDescriptionFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.recentAchievementsDescriptionFontOutlineColorPictureBox.Name = "recentAchievementsDescriptionFontOutlineColorPictureBox";
            this.recentAchievementsDescriptionFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsDescriptionFontOutlineColorPictureBox.TabIndex = 45;
            this.recentAchievementsDescriptionFontOutlineColorPictureBox.TabStop = false;
            // 
            // recentAchievementsDescriptionFontSetColorButton
            // 
            this.recentAchievementsDescriptionFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsDescriptionFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsDescriptionFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.recentAchievementsDescriptionFontSetColorButton.Name = "recentAchievementsDescriptionFontSetColorButton";
            this.recentAchievementsDescriptionFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.recentAchievementsDescriptionFontSetColorButton.TabIndex = 45;
            this.recentAchievementsDescriptionFontSetColorButton.Text = "Set";
            this.recentAchievementsDescriptionFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsDescriptionFontOutlineCheckBox
            // 
            this.recentAchievementsDescriptionFontOutlineCheckBox.AutoSize = true;
            this.recentAchievementsDescriptionFontOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsDescriptionFontOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsDescriptionFontOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.recentAchievementsDescriptionFontOutlineCheckBox.Name = "recentAchievementsDescriptionFontOutlineCheckBox";
            this.recentAchievementsDescriptionFontOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.recentAchievementsDescriptionFontOutlineCheckBox.TabIndex = 45;
            this.recentAchievementsDescriptionFontOutlineCheckBox.Text = "Outline";
            this.recentAchievementsDescriptionFontOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsDescriptionFontOutlineNumericUpDown
            // 
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.Location = new System.Drawing.Point(91, 97);
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
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.TabIndex = 45;
            this.recentAchievementsDescriptionFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // recentAchievementsDescriptionFontColorPictureBox
            // 
            this.recentAchievementsDescriptionFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsDescriptionFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.recentAchievementsDescriptionFontColorPictureBox.Name = "recentAchievementsDescriptionFontColorPictureBox";
            this.recentAchievementsDescriptionFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsDescriptionFontColorPictureBox.TabIndex = 45;
            this.recentAchievementsDescriptionFontColorPictureBox.TabStop = false;
            // 
            // recentAchievementsDescriptionFontComboBox
            // 
            this.recentAchievementsDescriptionFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsDescriptionFontComboBox.FormattingEnabled = true;
            this.recentAchievementsDescriptionFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.recentAchievementsDescriptionFontComboBox.Name = "recentAchievementsDescriptionFontComboBox";
            this.recentAchievementsDescriptionFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.recentAchievementsDescriptionFontComboBox.TabIndex = 45;
            // 
            // recentAchievementsSimpleGroupBox
            // 
            this.recentAchievementsSimpleGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.recentAchievementsSimpleGroupBox.Controls.Add(this.recentAchievementsSimpleFontOutlineSetColorButton);
            this.recentAchievementsSimpleGroupBox.Controls.Add(this.recentAchievementsSimpleFontOutlineColorPictureBox);
            this.recentAchievementsSimpleGroupBox.Controls.Add(this.recentAchievementsSimpleFontSetColorButton);
            this.recentAchievementsSimpleGroupBox.Controls.Add(this.recentAchievementsSimpleFontOutlineCheckBox);
            this.recentAchievementsSimpleGroupBox.Controls.Add(this.recentAchievementsSimpleFontOutlineNumericUpDown);
            this.recentAchievementsSimpleGroupBox.Controls.Add(this.recentAchievementsSimpleFontColorPictureBox);
            this.recentAchievementsSimpleGroupBox.Controls.Add(this.recentAchievementsSimpleFontComboBox);
            this.recentAchievementsSimpleGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsSimpleGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.recentAchievementsSimpleGroupBox.Location = new System.Drawing.Point(425, 6);
            this.recentAchievementsSimpleGroupBox.Name = "recentAchievementsSimpleGroupBox";
            this.recentAchievementsSimpleGroupBox.Size = new System.Drawing.Size(165, 125);
            this.recentAchievementsSimpleGroupBox.TabIndex = 10048;
            this.recentAchievementsSimpleGroupBox.TabStop = false;
            this.recentAchievementsSimpleGroupBox.Text = "All";
            // 
            // recentAchievementsSimpleFontOutlineSetColorButton
            // 
            this.recentAchievementsSimpleFontOutlineSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsSimpleFontOutlineSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsSimpleFontOutlineSetColorButton.Location = new System.Drawing.Point(5, 95);
            this.recentAchievementsSimpleFontOutlineSetColorButton.Name = "recentAchievementsSimpleFontOutlineSetColorButton";
            this.recentAchievementsSimpleFontOutlineSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.recentAchievementsSimpleFontOutlineSetColorButton.TabIndex = 45;
            this.recentAchievementsSimpleFontOutlineSetColorButton.Text = "Set";
            this.recentAchievementsSimpleFontOutlineSetColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsSimpleFontOutlineColorPictureBox
            // 
            this.recentAchievementsSimpleFontOutlineColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsSimpleFontOutlineColorPictureBox.Location = new System.Drawing.Point(60, 95);
            this.recentAchievementsSimpleFontOutlineColorPictureBox.Name = "recentAchievementsSimpleFontOutlineColorPictureBox";
            this.recentAchievementsSimpleFontOutlineColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsSimpleFontOutlineColorPictureBox.TabIndex = 45;
            this.recentAchievementsSimpleFontOutlineColorPictureBox.TabStop = false;
            // 
            // recentAchievementsSimpleFontSetColorButton
            // 
            this.recentAchievementsSimpleFontSetColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsSimpleFontSetColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recentAchievementsSimpleFontSetColorButton.Location = new System.Drawing.Point(5, 45);
            this.recentAchievementsSimpleFontSetColorButton.Name = "recentAchievementsSimpleFontSetColorButton";
            this.recentAchievementsSimpleFontSetColorButton.Size = new System.Drawing.Size(49, 23);
            this.recentAchievementsSimpleFontSetColorButton.TabIndex = 45;
            this.recentAchievementsSimpleFontSetColorButton.Text = "Set";
            this.recentAchievementsSimpleFontSetColorButton.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsSimpleFontOutlineCheckBox
            // 
            this.recentAchievementsSimpleFontOutlineCheckBox.AutoSize = true;
            this.recentAchievementsSimpleFontOutlineCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsSimpleFontOutlineCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(250)))));
            this.recentAchievementsSimpleFontOutlineCheckBox.Location = new System.Drawing.Point(5, 75);
            this.recentAchievementsSimpleFontOutlineCheckBox.Name = "recentAchievementsSimpleFontOutlineCheckBox";
            this.recentAchievementsSimpleFontOutlineCheckBox.Size = new System.Drawing.Size(73, 20);
            this.recentAchievementsSimpleFontOutlineCheckBox.TabIndex = 45;
            this.recentAchievementsSimpleFontOutlineCheckBox.Text = "Outline";
            this.recentAchievementsSimpleFontOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // recentAchievementsSimpleFontOutlineNumericUpDown
            // 
            this.recentAchievementsSimpleFontOutlineNumericUpDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsSimpleFontOutlineNumericUpDown.Location = new System.Drawing.Point(89, 97);
            this.recentAchievementsSimpleFontOutlineNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.recentAchievementsSimpleFontOutlineNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recentAchievementsSimpleFontOutlineNumericUpDown.Name = "recentAchievementsSimpleFontOutlineNumericUpDown";
            this.recentAchievementsSimpleFontOutlineNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.recentAchievementsSimpleFontOutlineNumericUpDown.TabIndex = 45;
            this.recentAchievementsSimpleFontOutlineNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.recentAchievementsSimpleFontOutlineNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // recentAchievementsSimpleFontColorPictureBox
            // 
            this.recentAchievementsSimpleFontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.recentAchievementsSimpleFontColorPictureBox.Location = new System.Drawing.Point(60, 45);
            this.recentAchievementsSimpleFontColorPictureBox.Name = "recentAchievementsSimpleFontColorPictureBox";
            this.recentAchievementsSimpleFontColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.recentAchievementsSimpleFontColorPictureBox.TabIndex = 45;
            this.recentAchievementsSimpleFontColorPictureBox.TabStop = false;
            // 
            // recentAchievementsSimpleFontComboBox
            // 
            this.recentAchievementsSimpleFontComboBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentAchievementsSimpleFontComboBox.FormattingEnabled = true;
            this.recentAchievementsSimpleFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.recentAchievementsSimpleFontComboBox.Name = "recentAchievementsSimpleFontComboBox";
            this.recentAchievementsSimpleFontComboBox.Size = new System.Drawing.Size(155, 24);
            this.recentAchievementsSimpleFontComboBox.TabIndex = 45;
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tabPage9.Controls.Add(this.achievementListBackgroundGroupBox);
            this.tabPage9.Controls.Add(this.achievementListAutoOpenWindowCheckbox);
            this.tabPage9.Controls.Add(this.achievementListScrollCheckBox);
            this.tabPage9.Controls.Add(this.achievementListOpenWindowButton);
            this.tabPage9.Location = new System.Drawing.Point(4, 24);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(769, 292);
            this.tabPage9.TabIndex = 6;
            this.tabPage9.Text = "Cheevo List";
            // 
            // achievementListBackgroundGroupBox
            // 
            this.achievementListBackgroundGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.achievementListBackgroundGroupBox.Controls.Add(this.achievementListSetBackgroundColorButton);
            this.achievementListBackgroundGroupBox.Controls.Add(this.achievementListBackgroundColorPictureBox);
            this.achievementListBackgroundGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementListBackgroundGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.achievementListBackgroundGroupBox.Location = new System.Drawing.Point(339, 6);
            this.achievementListBackgroundGroupBox.Name = "achievementListBackgroundGroupBox";
            this.achievementListBackgroundGroupBox.Size = new System.Drawing.Size(80, 49);
            this.achievementListBackgroundGroupBox.TabIndex = 10052;
            this.achievementListBackgroundGroupBox.TabStop = false;
            this.achievementListBackgroundGroupBox.Text = "Back";
            // 
            // achievementListSetBackgroundColorButton
            // 
            this.achievementListSetBackgroundColorButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achievementListSetBackgroundColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.achievementListSetBackgroundColorButton.Location = new System.Drawing.Point(6, 20);
            this.achievementListSetBackgroundColorButton.Name = "achievementListSetBackgroundColorButton";
            this.achievementListSetBackgroundColorButton.Size = new System.Drawing.Size(36, 23);
            this.achievementListSetBackgroundColorButton.TabIndex = 43;
            this.achievementListSetBackgroundColorButton.Text = "Set";
            this.achievementListSetBackgroundColorButton.UseVisualStyleBackColor = true;
            // 
            // achievementListBackgroundColorPictureBox
            // 
            this.achievementListBackgroundColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.achievementListBackgroundColorPictureBox.Location = new System.Drawing.Point(48, 20);
            this.achievementListBackgroundColorPictureBox.Name = "achievementListBackgroundColorPictureBox";
            this.achievementListBackgroundColorPictureBox.Size = new System.Drawing.Size(22, 22);
            this.achievementListBackgroundColorPictureBox.TabIndex = 42;
            this.achievementListBackgroundColorPictureBox.TabStop = false;
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tabPage10.Controls.Add(this.webBrowserAutoOpenCheckbox);
            this.tabPage10.Controls.Add(this.rssFeedFriendCheckBox);
            this.tabPage10.Controls.Add(this.rssFeedForumCheckBox);
            this.tabPage10.Controls.Add(this.rssFeedListView);
            this.tabPage10.Controls.Add(this.rssFeedNewsCheckBox);
            this.tabPage10.Controls.Add(this.rssFeedCheevoCheckBox);
            this.tabPage10.Location = new System.Drawing.Point(4, 24);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(769, 292);
            this.tabPage10.TabIndex = 7;
            this.tabPage10.Text = "Browser";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(800, 406);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.Text = "Retro Achievements Tracker";
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.raConnectionStatusPictureBox)).EndInit();
            this.achievementPositionGroupBox.ResumeLayout(false);
            this.achievementPositionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementScaleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementYNumericUpDown)).EndInit();
            this.achievementOutAnimationGroupBox.ResumeLayout(false);
            this.achievementOutAnimationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementOutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementOutSpeedUpDown)).EndInit();
            this.achievementInAnimationGroupBox.ResumeLayout(false);
            this.achievementInAnimationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementInNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomAchievementInSpeedUpDown)).EndInit();
            this.masteryPositionGroupBox.ResumeLayout(false);
            this.masteryPositionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryScaleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryYNumericUpDown)).EndInit();
            this.masteryOutAnimationGroupBox.ResumeLayout(false);
            this.masteryOutAnimationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryOutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryOutSpeedUpDown)).EndInit();
            this.masteryInAnimationGroupBox.ResumeLayout(false);
            this.masteryInAnimationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryInNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsCustomMasteryInSpeedUpDown)).EndInit();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.gameInfoBackgroundColorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoBackgroundColorPictureBox)).EndInit();
            this.gameInfoValuesGroupBox.ResumeLayout(false);
            this.gameInfoValuesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoValuesFontColorPictureBox)).EndInit();
            this.gameInfoNamesGroupBox.ResumeLayout(false);
            this.gameInfoNamesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoNamesFontColorPictureBox)).EndInit();
            this.focusBehaviorGroupBox.ResumeLayout(false);
            this.focusBehaviorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsMaxListNumericUpDown)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.userInfoBackgroundColorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userInfoBackgroundColorPictureBox)).EndInit();
            this.userInfoValuesGroupBox.ResumeLayout(false);
            this.userInfoValuesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoValuesFontColorPictureBox)).EndInit();
            this.userInfoNamesGroupBox.ResumeLayout(false);
            this.userInfoNamesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoNamesFontColorPictureBox)).EndInit();
            this.userInfoSimpleGroupBox.ResumeLayout(false);
            this.userInfoSimpleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoSimpleFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoSimpleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoSimpleFontColorPictureBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.focusBackgroundColorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.focusBackgroundColorPictureBox)).EndInit();
            this.focusBorderColorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.focusBorderColorPictureBox)).EndInit();
            this.focusLineGroupBox.ResumeLayout(false);
            this.focusLineGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusLineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusLineOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusLineOutlineColorPictureBox)).EndInit();
            this.focusPointsGroupBox.ResumeLayout(false);
            this.focusPointsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusPointsFontColorPictureBox)).EndInit();
            this.focusTitleGroupBox.ResumeLayout(false);
            this.focusTitleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusTitleFontColorPictureBox)).EndInit();
            this.focusDescriptionGroupBox.ResumeLayout(false);
            this.focusDescriptionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusDescriptionFontColorPictureBox)).EndInit();
            this.focusSimpleGroupBox.ResumeLayout(false);
            this.focusSimpleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.focusSimpleFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusSimpleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusSimpleFontColorPictureBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.notificationsBackgroundColorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.notificationsBackgroundColorPictureBox)).EndInit();
            this.groupBox28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.notificationsBorderColorPictureBox)).EndInit();
            this.notificationsLineGroupBox.ResumeLayout(false);
            this.notificationsLineGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsLineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsLineOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsLineOutlineColorPictureBox)).EndInit();
            this.notificationsPointsGroupBox.ResumeLayout(false);
            this.notificationsPointsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsPointsFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsPointsFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsPointsFontColorPictureBox)).EndInit();
            this.notificationsTitleGroupBox.ResumeLayout(false);
            this.notificationsTitleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsTitleFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsTitleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsTitleFontColorPictureBox)).EndInit();
            this.notificationsDescriptionGroupBox.ResumeLayout(false);
            this.notificationsDescriptionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsDescriptionFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsDescriptionFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsDescriptionFontColorPictureBox)).EndInit();
            this.notificationsAllFontGroupBox.ResumeLayout(false);
            this.notificationsAllFontGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsSimpleFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsSimpleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsSimpleFontColorPictureBox)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.gameProgressBackgroundColorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressBackgroundColorPictureBox)).EndInit();
            this.gameProgressValuesGroupBox.ResumeLayout(false);
            this.gameProgressValuesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressValuesFontColorPictureBox)).EndInit();
            this.gameProgressNamesGroupBox.ResumeLayout(false);
            this.gameProgressNamesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressNamesFontColorPictureBox)).EndInit();
            this.gameProgressSimpleGroupBox.ResumeLayout(false);
            this.gameProgressSimpleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressSimpleFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressSimpleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameProgressSimpleFontColorPictureBox)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.gameInfoSimpleGroupBox.ResumeLayout(false);
            this.gameInfoSimpleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoSimpleFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoSimpleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameInfoSimpleFontColorPictureBox)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.recentAchievementsBackgroundColorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsBackgroundColorPictureBox)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsBorderColorPictureBox)).EndInit();
            this.recentAchievementsLineGroupBox.ResumeLayout(false);
            this.recentAchievementsLineGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsLineOutlineColorPictureBox)).EndInit();
            this.recentAchievementsPointsGroupBox.ResumeLayout(false);
            this.recentAchievementsPointsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsPointsFontColorPictureBox)).EndInit();
            this.recentAchievementsTitleGroupBox.ResumeLayout(false);
            this.recentAchievementsTitleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsTitleFontColorPictureBox)).EndInit();
            this.recentAchievementsDescriptionGroupBox.ResumeLayout(false);
            this.recentAchievementsDescriptionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDescriptionFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDescriptionFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsDescriptionFontColorPictureBox)).EndInit();
            this.recentAchievementsSimpleGroupBox.ResumeLayout(false);
            this.recentAchievementsSimpleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsSimpleFontOutlineColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsSimpleFontOutlineNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentAchievementsSimpleFontColorPictureBox)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.achievementListBackgroundGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.achievementListBackgroundColorPictureBox)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
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
        private Button focusOpenWindowButton;
        private CheckBox autoStartCheckbox;
        private CheckBox focusAutoOpenWindowCheckBox;
        private CheckBox userInfoAutoOpenWindowCheckbox;
        private Button userInfoOpenWindowButton;
        private CheckBox notificationsAutoOpenWindowCheckbox;
        private Button notificationsOpenWindowButton;
        private Label timerStatusLabel;
        private PictureBox raConnectionStatusPictureBox;
        private CheckBox gameInfoAutoOpenWindowCheckbox;
        private Button gameInfoOpenWindowButton;
        private GroupBox groupBox2;
        private CheckBox recentAchievementsAutoOpenWindowCheckbox;
        private Button recentAchievementsOpenWindowButton;
        private TextBox gameProgressRatioTextBox;
        private TextBox userInfoTruePointsTextBox;
        private TextBox userInfoPointsTextBox;
        private TextBox userInfoRatioTextBox;
        private TextBox userInfoRankTextBox;
        private TextBox gameProgressTruePointsTextBox;
        private TextBox gameProgressPointsTextBox;
        private TextBox gameProgressAchievementsTextBox;
        private OpenFileDialog openFileDialog1;
        private ColorDialog colorDialog1;
        private TextBox gameInfoGenreTextBox;
        private TextBox gameInfoConsoleTextBox;
        private TextBox gameInfoPublisherTextBox;
        private TextBox gameInfoReleaseDateTextBox;
        private TextBox gameInfoDeveloperTextBox;
        private Button userInfoDefaultButton;
        private Button gameInfoDefaultButton;
        private TextBox gameInfoTitleTextBox;
        private TextBox gameProgressCompletedTextBox;
        private RadioButton gameProgressRadioButtonDot;
        private RadioButton gameProgressRadioButtonBackslash;
        private RadioButton gameProgressRadioButtonSemicolon;
        private GroupBox gameInfoNamesGroupBox;
        private Button gameInfoNamesFontOutlineColorBoxButton;
        private PictureBox gameInfoNamesFontOutlineColorPictureBox;
        private Button gameInfoNamesFontColorBoxButton;
        private PictureBox gameInfoNamesFontColorPictureBox;
        private NumericUpDown gameInfoNamesFontOutlineNumericUpDown;
        private CheckBox gameInfoNamesOutlineCheckBox;
        private ComboBox gameInfoNamesFontComboBox;
        private GroupBox gameInfoValuesGroupBox;
        private Button gameInfoValuesFontOutlineColorBoxButton;
        private PictureBox gameInfoValuesFontOutlineColorPictureBox;
        private Button gameInfoValuesFontColorBoxButton;
        private CheckBox gameInfoValuesOutlineCheckBox;
        private NumericUpDown gameInfoValuesFontOutlineNumericUpDown;
        private PictureBox gameInfoValuesFontColorPictureBox;
        private ComboBox gameInfoValuesFontComboBox;
        private Button playAchievementButton;
        private CheckBox customAchievementEnableCheckbox;
        private Button selectCustomAchievementFileButton;
        private CheckBox acheivementEditOutlineCheckbox;
        private GroupBox achievementPositionGroupBox;
        private Label label14;
        private NumericUpDown notificationsCustomAchievementScaleNumericUpDown;
        private Label xPositionLabel1;
        private Label yPositionLabel1;
        private NumericUpDown notificationsCustomAchievementYNumericUpDown;
        private GroupBox achievementInAnimationGroupBox;
        private Label label8;
        private Label label7;
        private Label label6;
        private ComboBox notificationsCustomAchievementAnimationInComboBox;
        private NumericUpDown notificationsCustomAchievementInSpeedUpDown;
        private GroupBox achievementOutAnimationGroupBox;
        private Label label11;
        private Label label12;
        private Label label13;
        private ComboBox notificationsCustomAchievementAnimationOutComboBox;
        private NumericUpDown notificationsCustomAchievementOutSpeedUpDown;
        private GroupBox groupBox17;
        private GroupBox masteryPositionGroupBox;
        private Label label16;
        private NumericUpDown notificationsCustomMasteryScaleNumericUpDown;
        private Label label17;
        private Label label18;
        private NumericUpDown notificationsCustomMasteryYNumericUpDown;
        private CheckBox masteryEditOultineCheckbox;
        private GroupBox masteryOutAnimationGroupBox;
        private Label label19;
        private Label label20;
        private Label label21;
        private ComboBox notificationsCustomMasteryAnimationOutComboBox;
        private NumericUpDown notificationsCustomMasteryOutSpeedUpDown;
        private GroupBox masteryInAnimationGroupBox;
        private Label label22;
        private Label label23;
        private Label label24;
        private ComboBox notificationsCustomMasteryAnimationInComboBox;
        private NumericUpDown notificationsCustomMasteryInSpeedUpDown;
        private CheckBox customMasteryEnableCheckbox;
        private Button selectCustomMasteryFileButton;
        private Button playMasteryButton;
        private Button gameProgressDefaultButton;
        private CheckBox gameProgressRatioCheckBox;
        private CheckBox gameProgressTruePointsCheckBox;
        private CheckBox gameProgressPointsCheckBox;
        private CheckBox gameProgressCompletedCheckBox;
        private CheckBox gameProgressAchievementsCheckBox;
        private CheckBox userInfoTruePointsCheckBox;
        private CheckBox userInfoRatioCheckBox;
        private CheckBox userInfoPointsCheckBox;
        private CheckBox userInfoRankCheckBox;
        private CheckBox gameInfoReleasedCheckBox;
        private CheckBox gameInfoConsoleCheckBox;
        private CheckBox gameInfoPublisherCheckBox;
        private CheckBox gameInfoGenreCheckBox;
        private CheckBox gameInfoDeveloperCheckBox;
        private CheckBox gameInfoTitleCheckBox;
        private GroupBox gameInfoBackgroundColorGroupBox;
        private Button gameInfoSetBackgroundColorButton;
        private PictureBox gameInfoBackgroundColorPictureBox;
        private CheckBox achievementListAutoOpenWindowCheckbox;
        private Button achievementListOpenWindowButton;
        private CheckBox gameProgressAutoOpenWindowCheckbox;
        private Button gameProgressOpenWindowButton;
        private PictureBox gameInfoPictureBox;
        private ListView rssFeedListView;
        private Label gameInfoTitleLabel;
        private CheckBox rssFeedNewsCheckBox;
        private CheckBox rssFeedCheevoCheckBox;
        private CheckBox rssFeedFriendCheckBox;
        private CheckBox rssFeedForumCheckBox;
        private CheckBox webBrowserAutoOpenCheckbox;
        private CheckBox achievementListScrollCheckBox;
        private ColumnHeader columnHeader1;
        private Label recentAchievementsMaxListLabel;
        private NumericUpDown recentAchievementsMaxListNumericUpDown;
        private GroupBox focusBehaviorGroupBox;
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
        private NumericUpDown notificationsCustomAchievementXNumericUpDown;
        private NumericUpDown notificationsCustomAchievementOutNumericUpDown;
        private NumericUpDown notificationsCustomAchievementInNumericUpDown;
        private NumericUpDown notificationsCustomMasteryXNumericUpDown;
        private NumericUpDown notificationsCustomMasteryOutNumericUpDown;
        private NumericUpDown notificationsCustomMasteryInNumericUpDown;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox focusBackgroundColorGroupBox;
        private Button focusSetBackgroundColorButton;
        private PictureBox focusBackgroundColorPictureBox;
        private GroupBox focusBorderColorGroupBox;
        private Button focusSetBorderColorButton;
        private PictureBox focusBorderColorPictureBox;
        private GroupBox focusLineGroupBox;
        private Button focusLineSetColorButton;
        private PictureBox focusLineColorPictureBox;
        private Button focusLineOutlineSetColorButton;
        private CheckBox focusLineOutlineCheckBox;
        private NumericUpDown focusLineOutlineNumericUpDown;
        private PictureBox focusLineOutlineColorPictureBox;
        private GroupBox focusPointsGroupBox;
        private Button focusPointsFontOutlineSetColorButton;
        private PictureBox focusPointsFontOutlineColorPictureBox;
        private Button focusPointsFontSetColorButton;
        private CheckBox focusPointsOutlineCheckBox;
        private NumericUpDown focusPointsFontOutlineNumericUpDown;
        private PictureBox focusPointsFontColorPictureBox;
        private ComboBox focusPointsFontComboBox;
        private GroupBox focusTitleGroupBox;
        private Button focusTitleFontOutlineSetColorButton;
        private PictureBox focusTitleFontOutlineColorPictureBox;
        private Button focusTitleFontSetColorButton;
        private CheckBox focusTitleOutlineCheckBox;
        private NumericUpDown focusTitleFontOutlineNumericUpDown;
        private PictureBox focusTitleFontColorPictureBox;
        private ComboBox focusTitleFontComboBox;
        private GroupBox focusDescriptionGroupBox;
        private Button focusDescriptionFontOutlineSetColorButton;
        private PictureBox focusDescriptionFontOutlineColorPictureBox;
        private Button focusDescriptionFontSetColorButton;
        private CheckBox focusDescriptionOutlineCheckBox;
        private NumericUpDown focusDescriptionFontOutlineNumericUpDown;
        private PictureBox focusDescriptionFontColorPictureBox;
        private ComboBox focusDescriptionFontComboBox;
        private GroupBox userInfoBackgroundColorGroupBox;
        private Button userInfoSetBackgroundColorButton;
        private PictureBox userInfoBackgroundColorPictureBox;
        private GroupBox userInfoNamesGroupBox;
        private Button userInfoNamesFontOutlineColorBoxButton;
        private PictureBox userInfoNamesFontOutlineColorPictureBox;
        private Button userInfoNamesFontColorBoxButton;
        private CheckBox userInfoNamesOutlineCheckBox;
        private NumericUpDown userInfoNamesFontOutlineNumericUpDown;
        private PictureBox userInfoNamesFontColorPictureBox;
        private ComboBox userInfoNamesFontComboBox;
        private GroupBox userInfoValuesGroupBox;
        private Button userInfoValuesFontOutlineColorBoxButton;
        private PictureBox userInfoValuesFontOutlineColorPictureBox;
        private Button userInfoValuesFontColorBoxButton;
        private CheckBox userInfoValuesOutlineCheckBox;
        private NumericUpDown userInfoValuesFontOutlineNumericUpDown;
        private PictureBox userInfoValuesFontColorPictureBox;
        private ComboBox userInfoValuesFontComboBox;
        private TabPage tabPage3;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private GroupBox notificationsBackgroundColorGroupBox;
        private Button notificationsSetBackgroundColorButton;
        private PictureBox notificationsBackgroundColorPictureBox;
        private GroupBox groupBox28;
        private Button notificationsSetBorderColorButton;
        private PictureBox notificationsBorderColorPictureBox;
        private GroupBox notificationsLineGroupBox;
        private Button notificationsLineSetColorButton;
        private PictureBox notificationsLineColorPictureBox;
        private Button notificationsLineOutlineSetColorButton;
        private CheckBox notificationsLineOutlineCheckBox;
        private NumericUpDown notificationsLineOutlineNumericUpDown;
        private PictureBox notificationsLineOutlineColorPictureBox;
        private GroupBox notificationsPointsGroupBox;
        private Button notificationsPointsFontOutlineSetColorButton;
        private PictureBox notificationsPointsFontOutlineColorPictureBox;
        private Button notificationsPointsFontSetColorButton;
        private CheckBox notificationsPointsOutlineCheckBox;
        private NumericUpDown notificationsPointsFontOutlineNumericUpDown;
        private PictureBox notificationsPointsFontColorPictureBox;
        private ComboBox notificationsPointsFontComboBox;
        private GroupBox notificationsTitleGroupBox;
        private Button notificationsTitleFontOutlineSetColorButton;
        private PictureBox notificationsTitleFontOutlineColorPictureBox;
        private Button notificationsTitleFontSetColorButton;
        private CheckBox notificationsTitleOutlineCheckBox;
        private NumericUpDown notificationsTitleFontOutlineNumericUpDown;
        private PictureBox notificationsTitleFontColorPictureBox;
        private ComboBox notificationsTitleFontComboBox;
        private GroupBox notificationsDescriptionGroupBox;
        private Button notificationsDescriptionFontOutlineSetColorButton;
        private PictureBox notificationsDescriptionFontOutlineColorPictureBox;
        private Button notificationsDescriptionFontSetColorButton;
        private CheckBox notificationsDescriptionOutlineCheckBox;
        private NumericUpDown notificationsDescriptionFontOutlineNumericUpDown;
        private PictureBox notificationsDescriptionFontColorPictureBox;
        private ComboBox notificationsDescriptionFontComboBox;
        private TabPage tabPage6;
        private GroupBox gameProgressBackgroundColorGroupBox;
        private Button gameProgressSetBackgroundColorButton;
        private PictureBox gameProgressBackgroundColorPictureBox;
        private GroupBox gameProgressNamesGroupBox;
        private Button gameProgressNamesFontOutlineColorBoxButton;
        private PictureBox gameProgressNamesFontOutlineColorPictureBox;
        private Button gameProgressNamesFontColorBoxButton;
        private CheckBox gameProgressNamesOutlineCheckBox;
        private NumericUpDown gameProgressNamesFontOutlineNumericUpDown;
        private PictureBox gameProgressNamesFontColorPictureBox;
        private ComboBox gameProgressNamesFontComboBox;
        private GroupBox gameProgressValuesGroupBox;
        private Button gameProgressValuesFontOutlineColorBoxButton;
        private PictureBox gameProgressValuesFontOutlineColorPictureBox;
        private Button gameProgressValuesFontColorBoxButton;
        private CheckBox gameProgressValuesOutlineCheckBox;
        private NumericUpDown gameProgressValuesFontOutlineNumericUpDown;
        private PictureBox gameProgressValuesFontColorPictureBox;
        private ComboBox gameProgressValuesFontComboBox;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private TabPage tabPage10;
        private GroupBox recentAchievementsBackgroundColorGroupBox;
        private Button recentAchievementsSetBackgroundColorButton;
        private PictureBox recentAchievementsBackgroundColorPictureBox;
        private GroupBox groupBox5;
        private Button recentAchievementsSetBorderColorButton;
        private PictureBox recentAchievementsBorderColorPictureBox;
        private GroupBox recentAchievementsLineGroupBox;
        private Button recentAchievementsLineSetColorButton;
        private PictureBox recentAchievementsLineColorPictureBox;
        private Button recentAchievementsLineOutlineSetColorButton;
        private CheckBox recentAchievementsLineOutlineCheckBox;
        private NumericUpDown recentAchievementsLineOutlineNumericUpDown;
        private PictureBox recentAchievementsLineOutlineColorPictureBox;
        private GroupBox recentAchievementsPointsGroupBox;
        private Button recentAchievementsPointsFontOutlineSetColorButton;
        private PictureBox recentAchievementsPointsFontOutlineColorPictureBox;
        private Button recentAchievementsPointsFontSetColorButton;
        private CheckBox recentAchievementsPointsFontOutlineCheckBox;
        private NumericUpDown recentAchievementsPointsFontOutlineNumericUpDown;
        private PictureBox recentAchievementsPointsFontColorPictureBox;
        private ComboBox recentAchievementsPointsFontComboBox;
        private GroupBox recentAchievementsTitleGroupBox;
        private Button recentAchievementsTitleFontOutlineSetColorButton;
        private PictureBox recentAchievementsTitleFontOutlineColorPictureBox;
        private Button recentAchievementsTitleFontSetColorButton;
        private CheckBox recentAchievementsTitleFontOutlineCheckBox;
        private NumericUpDown recentAchievementsTitleFontOutlineNumericUpDown;
        private PictureBox recentAchievementsTitleFontColorPictureBox;
        private ComboBox recentAchievementsTitleFontComboBox;
        private GroupBox recentAchievementsDescriptionGroupBox;
        private Button recentAchievementsDescriptionFontOutlineSetColorButton;
        private PictureBox recentAchievementsDescriptionFontOutlineColorPictureBox;
        private Button recentAchievementsDescriptionFontSetColorButton;
        private CheckBox recentAchievementsDescriptionFontOutlineCheckBox;
        private NumericUpDown recentAchievementsDescriptionFontOutlineNumericUpDown;
        private PictureBox recentAchievementsDescriptionFontColorPictureBox;
        private ComboBox recentAchievementsDescriptionFontComboBox;
        private GroupBox achievementListBackgroundGroupBox;
        private Button achievementListSetBackgroundColorButton;
        private PictureBox achievementListBackgroundColorPictureBox;
        private CheckBox notificationsSimpleCheckBox;
        private CheckBox notificationsBorderCheckBox;
        private CheckBox focusSimpleCheckBox;
        private CheckBox focusBorderCheckBox;
        private CheckBox recentAchievementsSimpleCheckBox;
        private CheckBox recentAchievementsBorderCheckBox;
        private CheckBox recentAchievementsScrollCheckBox;
        private CheckBox userInfoSimpleCheckBox;
        private CheckBox gameProgressSimpleCheckBox;
        private CheckBox gameInfoSimpleCheckBox;
        private Label focusAchievementIdLabel;
        private Label userInfoRatioLabel;
        private Label userInfoTruePointsLabel;
        private Label userInfoPointsLabel;
        private Label userInfoRankLabel;
        private Label gameProgressRatioLabel;
        private Label gameProgressCompletedLabel;
        private Label gameProgressTruePointsLabel;
        private Label gameProgressPointsLabel;
        private Label gameProgressAchievementsLabel;
        private Label gameInfoReleasedLabel;
        private Label gameInfoGenreLabel;
        private Label gameInfoConsoleLabel;
        private Label gameInfoPublisherLabel;
        private Label gameInfoDeveloperLabel;
        private GroupBox userInfoSimpleGroupBox;
        private Button userInfoSimpleFontOutlineColorBoxButton;
        private PictureBox userInfoSimpleFontOutlineColorPictureBox;
        private Button userInfoSimpleFontColorBoxButton;
        private CheckBox userInfoSimpleOutlineCheckBox;
        private NumericUpDown userInfoSimpleFontOutlineNumericUpDown;
        private PictureBox userInfoSimpleFontColorPictureBox;
        private ComboBox userInfoSimpleFontComboBox;
        private GroupBox focusSimpleGroupBox;
        private Button focusSimpleFontOutlineSetColorButton;
        private PictureBox focusSimpleFontOutlineColorPictureBox;
        private Button focusSimpleFontSetColorButton;
        private CheckBox focusSimpleOutlineCheckBox;
        private NumericUpDown focusSimpleFontOutlineNumericUpDown;
        private PictureBox focusSimpleFontColorPictureBox;
        private ComboBox focusSimpleFontComboBox;
        private GroupBox notificationsAllFontGroupBox;
        private Button notificationsSimpleFontOutlineSetColorButton;
        private PictureBox notificationsSimpleFontOutlineColorPictureBox;
        private Button notificationsSimpleFontSetColorButton;
        private CheckBox notificationsSimpleOutlineCheckBox;
        private NumericUpDown notificationsSimpleFontOutlineNumericUpDown;
        private PictureBox notificationsSimpleFontColorPictureBox;
        private ComboBox notificationsSimpleFontComboBox;
        private GroupBox gameProgressSimpleGroupBox;
        private Button gameProgressSimpleFontOutlineColorBoxButton;
        private PictureBox gameProgressSimpleFontOutlineColorPictureBox;
        private Button gameProgressSimpleFontColorBoxButton;
        private CheckBox gameProgressSimpleOutlineCheckBox;
        private NumericUpDown gameProgressSimpleFontOutlineNumericUpDown;
        private PictureBox gameProgressSimpleFontColorPictureBox;
        private ComboBox gameProgressSimpleFontComboBox;
        private GroupBox gameInfoSimpleGroupBox;
        private Button gameInfoSimpleFontOutlineColorBoxButton;
        private PictureBox gameInfoSimpleFontOutlineColorPictureBox;
        private Button gameInfoSimpleFontColorBoxButton;
        private CheckBox gameInfoSimpleOutlineCheckBox;
        private NumericUpDown gameInfoSimpleFontOutlineNumericUpDown;
        private PictureBox gameInfoSimpleFontColorPictureBox;
        private ComboBox gameInfoSimpleFontComboBox;
        private GroupBox recentAchievementsSimpleGroupBox;
        private Button recentAchievementsSimpleFontOutlineSetColorButton;
        private PictureBox recentAchievementsSimpleFontOutlineColorPictureBox;
        private Button recentAchievementsSimpleFontSetColorButton;
        private CheckBox recentAchievementsSimpleFontOutlineCheckBox;
        private NumericUpDown recentAchievementsSimpleFontOutlineNumericUpDown;
        private PictureBox recentAchievementsSimpleFontColorPictureBox;
        private ComboBox recentAchievementsSimpleFontComboBox;
        private CheckBox achievementEnableCheckbox;
        private CheckBox masteryEnableCheckbox;
    }
}

