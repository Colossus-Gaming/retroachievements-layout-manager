using CefSharp;
using MediaToolkit;
using MediaToolkit.Model;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class NotificationLayoutWindow : Form
    {
        private static readonly string CALLER_ID = "NotificationWindow";
        public Action<string> LogCallback { get; internal set; }
        public Achievement MostRecentAchievement { get; set; }

        private Task NotificationsTask;

        private readonly ObservableCollection<NotificationRequest> NotificationRequests;

        private Stopwatch stopwatch;

        private CancellationTokenSource tokenSource2 = new CancellationTokenSource();

        private GameSummary CurrentGame;
        private GameAchievementSummary CurrentAchievementSummary;

        private string FontColorHexCode
        {
            set
            {
                Settings.Default.notification_font_color_hex_code = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_font_color_hex_code;
            }
        }
        private string FontOutlineColorHexCode
        {
            set
            {
                Settings.Default.notification_font_outline_color_hex = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_font_outline_color_hex;
            }
        }
        private string FontFamilyName
        {
            set
            {
                Settings.Default.notification_font_family_name = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_font_family_name;
            }
        }
        private int FontOutlineSize
        {
            set
            {
                Settings.Default.notification_font_outline_size = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_font_outline_size;
            }
        }
        private string BackgroundColorHexCode
        {
            set
            {
                Settings.Default.notification_background_color = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_background_color;
            }
        }
        private bool CustomAchievementEnabled
        {
            set
            {
                Settings.Default.notification_custom_achievement_enable = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_achievement_enable;
            }
        }
        private bool CustomMasteryEnabled
        {
            set
            {
                Settings.Default.notification_custom_mastery_enable = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_mastery_enable;
            }
        }
        private int CustomAchievementX
        {
            set
            {
                Settings.Default.notification_custom_achievement_x = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_achievement_x;
            }
        }
        private int CustomAchievementY
        {
            set
            {
                Settings.Default.notification_custom_achievement_y = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_achievement_y;
            }
        }
        private int CustomMasteryX
        {
            set
            {
                Settings.Default.notification_custom_mastery_x = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_mastery_x;
            }
        }
        private int CustomMasteryY
        {
            set
            {
                Settings.Default.notification_custom_mastery_y = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_mastery_y;
            }
        }
        private decimal CustomAchievementScale
        {
            set
            {
                Settings.Default.notification_custom_achievement_scale = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_achievement_scale;
            }
        }
        private decimal CustomMasteryScale
        {
            set
            {
                Settings.Default.notification_custom_mastery_scale = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_mastery_scale;
            }
        }
        private int CustomAchievementIn
        {
            get
            {
                return Settings.Default.notification_custom_achievement_fade_in;
            }
            set
            {
                Settings.Default.notification_custom_achievement_fade_in = value;
                Settings.Default.Save();
            }
        }
        private int CustomAchievementOut
        {
            get
            {
                return Settings.Default.notification_custom_achievement_fade_out;
            }
            set
            {
                Settings.Default.notification_custom_achievement_fade_out = value;
                Settings.Default.Save();
            }
        }
        private int CustomMasteryIn
        {
            get
            {
                return Settings.Default.notification_custom_mastery_fade_in;
            }
            set
            {
                Settings.Default.notification_custom_mastery_fade_in = value;
                Settings.Default.Save();
            }
        }
        private int CustomMasteryOut
        {
            get
            {
                return Settings.Default.notification_custom_mastery_fade_out;
            }
            set
            {
                Settings.Default.notification_custom_mastery_fade_out = value;
                Settings.Default.Save();
            }
        }
        private string CustomAchievementFile
        {
            set
            {
                Settings.Default.notification_custom_achievement_file = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_achievement_file;
            }
        }
        private string CustomMasteryFile
        {
            set
            {
                Settings.Default.notification_custom_mastery_file = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_mastery_file;
            }
        }

        public NotificationLayoutWindow()
        {
            InitializeComponent();
            SetupBrowser();
            SetCustomFont();
            LoadProperties();
            AttachEvents();
            SetLabels();
            ToggleOutline();

            NotificationRequests = new ObservableCollection<NotificationRequest>();
            NotificationRequests.CollectionChanged += NotificationRequests_CollectionChanged;

            stopwatch = new Stopwatch();

            RunNotificationTask();
        }

        private void SetCustomFont()
        {
            this.achievementCustomizationGroupbox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 13.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.masteryCustomizationGroupbox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 13.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontCustomizationGroupBox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 13.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.showAchievementButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.replayAchievementButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.showGameMasteryButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.selectCustomAchievementButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomMasteryNotificationButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.scaleAchievementNumericUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.scaleMasteryNumericUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.useCustomAchievementCheckbox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.useCustomMasteryCheckbox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.acheivementEditOutlineCheckbox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.masteryEditOultineCheckbox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 7.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.customAchievementXNumericUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.customAchievementYNumericUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryXNumericUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.customMasteryYNumericUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.outAchievementNumericUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.inAchievementNumericUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.outMasteryNumericUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.inMasteryNumericUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.scaleLabel1.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.scaleLabel2.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.xPositionLabel1.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.xPositionLabel2.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.yPositionLabel1.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.yPositionLabel2.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.inLabel1.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.inLabel2.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.outLabel1.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.outLabel2.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.backgroundColorPickerButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.fontOutlineCheckbox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineColorPickerButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.fontOutlineColorHexCodeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.backgroundColorHexCodeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorHexCodeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.fontFamilyNameLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorPickerButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontSelectionButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontFamilyLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.backgroundColorLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineSizeUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        private void AttachEvents()
        {
            this.showAchievementButton.Click += ShowAchievementButton_Click;
            this.replayAchievementButton.Click += ReplayAchievementButton_Click;
            this.showGameMasteryButton.Click += ShowGameMasteryButton_Click;

            this.selectCustomAchievementButton.Click += SelectCustomAchievementButton_Click;
            this.selectCustomMasteryNotificationButton.Click += SelectCustomMasteryNotificationButton_Click;
            this.scaleAchievementNumericUpDown.ValueChanged += ScaleAchievementNumericUpDown_ValueChanged;
            this.scaleMasteryNumericUpDown.ValueChanged += ScaleMasteryNumericUpDown_ValueChanged;

            this.useCustomAchievementCheckbox.CheckedChanged += UseCustomAchievementCheckbox_CheckedChanged;
            this.useCustomMasteryCheckbox.CheckedChanged += UseCustomMasteryCheckbox_CheckedChanged;
            this.acheivementEditOutlineCheckbox.CheckedChanged += AcheivementEditOutlineCheckbox_CheckedChanged;
            this.masteryEditOultineCheckbox.CheckedChanged += MasteryEditOultineCheckbox_CheckedChanged;

            this.customAchievementXNumericUpDown.ValueChanged += CustomAchievementXNumericUpDown_ValueChanged;
            this.customAchievementYNumericUpDown.ValueChanged += CustomAchievementYNumericUpDown_ValueChanged;
            this.customMasteryXNumericUpDown.ValueChanged += CustomMasteryXNumericUpDown_ValueChanged;
            this.customMasteryYNumericUpDown.ValueChanged += CustomMasteryYNumericUpDown_ValueChanged;
            this.outAchievementNumericUpDown.ValueChanged += OutAchievementNumericUpDown_ValueChanged;
            this.inAchievementNumericUpDown.ValueChanged += InAchievementNumericUpDown_ValueChanged;
            this.outMasteryNumericUpDown.ValueChanged += OutMasteryNumericUpDown_ValueChanged;
            this.inMasteryNumericUpDown.ValueChanged += InMasteryNumericUpDown_ValueChanged;

            this.backgroundColorPickerButton.Click += BackgroundColorPickerButton_Click;

            this.fontSelectionButton.Click += FontSelectionButton_Click;
            this.fontColorPickerButton.Click += FontColorPickerButton_Click;
            this.fontOutlineCheckbox.CheckedChanged += FontOutlineCheckbox_CheckedChanged;
            this.fontOutlineColorPickerButton.Click += FontOutlineColorPickerButton_Click;
            this.fontOutlineSizeUpDown.ValueChanged += FontOutlineSizeUpDown_ValueChanged;
        }

        private void SetLabels()
        {
            this.fontColorHexCodeLabel.Text = FontColorHexCode;
            this.fontColorDisplayBox.BackColor = ColorTranslator.FromHtml(FontColorHexCode);

            this.backgroundColorHexCodeLabel.Text = BackgroundColorHexCode;
            this.backgroundColorDisplayBox.BackColor = ColorTranslator.FromHtml(BackgroundColorHexCode);

            this.fontFamilyNameLabel.Text = "Name: " + FontFamilyName;
        }

        private void LoadProperties()
        {
            this.useCustomAchievementCheckbox.Checked = CustomAchievementEnabled;
            this.selectCustomAchievementButton.Enabled = CustomAchievementEnabled;
            this.customAchievementXNumericUpDown.Enabled = false;
            this.customAchievementYNumericUpDown.Enabled = false;
            this.scaleAchievementNumericUpDown.Enabled = false;
            this.acheivementEditOutlineCheckbox.Enabled = CustomAchievementEnabled;
            this.inAchievementNumericUpDown.Enabled = false;
            this.outAchievementNumericUpDown.Enabled = false;
            this.xPositionLabel1.Enabled = false;
            this.yPositionLabel1.Enabled = false;
            this.scaleLabel1.Enabled = false;
            this.inLabel1.Enabled = false;
            this.outLabel1.Enabled = false;

            this.useCustomMasteryCheckbox.Checked = CustomMasteryEnabled;
            this.selectCustomMasteryNotificationButton.Enabled = CustomMasteryEnabled;
            this.customMasteryXNumericUpDown.Enabled = false;
            this.customMasteryYNumericUpDown.Enabled = false;
            this.scaleMasteryNumericUpDown.Enabled = false;
            this.masteryEditOultineCheckbox.Enabled = CustomMasteryEnabled;
            this.inMasteryNumericUpDown.Enabled = false;
            this.outMasteryNumericUpDown.Enabled = false;
            this.xPositionLabel2.Enabled = false;
            this.yPositionLabel2.Enabled = false;
            this.scaleLabel2.Enabled = false;
            this.inLabel2.Enabled = false;
            this.outLabel2.Enabled = false;

            this.customAchievementXNumericUpDown.Value = CustomAchievementX;
            this.customAchievementYNumericUpDown.Value = CustomAchievementY;

            this.customMasteryXNumericUpDown.Value = CustomMasteryX;
            this.customMasteryYNumericUpDown.Value = CustomMasteryY;

            this.scaleAchievementNumericUpDown.Value = CustomAchievementScale;
            this.scaleMasteryNumericUpDown.Value = CustomMasteryScale;

            this.inAchievementNumericUpDown.Value = CustomAchievementIn;
            this.outAchievementNumericUpDown.Value = CustomAchievementOut;
            this.inMasteryNumericUpDown.Value = CustomMasteryIn;
            this.outMasteryNumericUpDown.Value = CustomMasteryOut;

            this.fontOutlineCheckbox.Checked = Settings.Default.notification_font_outline_enabled;
        }

        private void ChromiumWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            SetFontColor();
            SetFontFamily();
            SetFontOutline();
            SetBackgroundColor();

            SetAchievementLeft();
            SetAchievementTop();
            SetAchievementWidth();

            SetMasteryLeft();
            SetMasteryTop();
            SetMasteryWidth();

            PromptUserInput();
        }

        private void NotificationRequests_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && NotificationRequests.Count > 0 && !stopwatch.IsRunning && NotificationsTask.Status != TaskStatus.Running)
            {
                RunNotificationTask();
            }
        }

        public bool UsingCustomAchievement()
        {
            return this.useCustomAchievementCheckbox.Checked;
        }

        public bool UsingCustomMastery()
        {
            return this.useCustomMasteryCheckbox.Checked;
        }

        private void RunNotificationTask()
        {
            NotificationsTask = Task.Factory.StartNew(async () =>
            {
                long delayInMilli = 0;

                while (NotificationRequests.Count > 0 || stopwatch.IsRunning)
                {
                    if (tokenSource2.Token.IsCancellationRequested)
                    {
                        EnableUserInput();
                        tokenSource2.Token.ThrowIfCancellationRequested();
                    }

                    DisableUserInput();

                    if (!stopwatch.IsRunning)
                    {
                        if (!this.IsDisposed)
                        {
                            if (NotificationRequests.Count > 0)
                            {
                                NotificationRequest notificationRequest = NotificationRequestDequeue();

                                if (tokenSource2.Token.IsCancellationRequested)
                                {
                                    EnableUserInput();
                                    tokenSource2.Token.ThrowIfCancellationRequested();
                                }

                                if (notificationRequest != null)
                                {
                                    if (notificationRequest.Achievement != null)
                                    {
                                        SendAchievementNotification(notificationRequest.Achievement);

                                        stopwatch = Stopwatch.StartNew();
                                        SetAchievementIn();
                                        SetAchievementOut();

                                        delayInMilli = this.useCustomAchievementCheckbox.Checked ? GetVideoDuration(CustomAchievementFile) : 7000;
                                    }
                                    else if (notificationRequest.GameAchievementSummary != null && notificationRequest.GameSummary != null)
                                    {
                                        SendMasteryNotification();
                                        stopwatch = Stopwatch.StartNew();
                                        SetMasteryIn();
                                        SetMasteryOut();

                                        delayInMilli = this.useCustomMasteryCheckbox.Checked ? GetVideoDuration(CustomMasteryFile) : 11000;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (stopwatch.ElapsedMilliseconds > delayInMilli)
                        {
                            HideNotifications();
                            stopwatch.Stop();
                            delayInMilli = 0;
                        }
                        else
                        {
                            await Task.Delay(100);
                        }
                    }
                }
                EnableUserInput();
            }, tokenSource2.Token);
        }

        private void DisableUserInput()
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    this.showAchievementButton.Enabled = false;
                    this.replayAchievementButton.Enabled = false;
                    this.showGameMasteryButton.Enabled = false;
                });
            }
            catch
            {
                tokenSource2.Cancel();
            }
        }

        public void SetCurrentGame(GameSummary gameSummary, GameAchievementSummary gameAchievementSummary)
        {
            CurrentGame = gameSummary;
            CurrentAchievementSummary = gameAchievementSummary;
        }

        private NotificationRequest NotificationRequestDequeue()
        {
            try
            {
                lock (NotificationRequests)
                {
                    NotificationRequest notificationRequest = NotificationRequests[0];

                    NotificationRequests.Remove(notificationRequest);

                    return notificationRequest;
                }
            }
            catch
            {
                return null;
            }
        }

        private void EnableUserInput()
        {
            if (!this.IsDisposed)
            {
                Invoke((MethodInvoker)delegate
                {
                    this.showAchievementButton.Enabled = true;
                    this.replayAchievementButton.Enabled = true;
                    this.showGameMasteryButton.Enabled = true;
                });
            }
        }

        public void EnqueueAchievementNotification(Achievement achievement)
        {
            NotificationRequest notificationRequest = new NotificationRequest
            {
                Achievement = achievement
            };

            lock (NotificationRequests)
            {
                NotificationRequests.Add(notificationRequest);
            }
        }

        public void EnqueueMasteryNotification()
        {
            NotificationRequest notificationRequest = new NotificationRequest
            {
                GameSummary = CurrentGame,
                GameAchievementSummary = CurrentAchievementSummary
            };

            lock (NotificationRequests)
            {
                NotificationRequests.Add(notificationRequest);
            }
        }

        private void SendAchievementNotification(Achievement achievement)
        {
            Invoke((MethodInvoker)delegate
            {
                if (this.Visible && achievement != null)
                {
                    string script = "achievementNotification(\"" + achievement.Title + "\"," +
                                       "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\",\"" +
                                       achievement.Description + "\",\"" + achievement.Points + "\");";

                    LogCallback(CALLER_ID + "[achievementNotification] Sending: [" + script + "]");

                    try
                    {
                        chromiumWebBrowser.ExecuteScriptAsync(script, TimeSpan.FromSeconds(2));
                    }
                    catch (Exception ex)
                    {
                        LogCallback(CALLER_ID + "[achievementNotification]" + ex.Message);
                    }
                }
            });
        }

        private void SendMasteryNotification()
        {
            Invoke((MethodInvoker)delegate
            {
                if (this.Visible)
                {
                    string script = "masteryNotification(\"" + CurrentGame.Title + "\"," +
                                                "\"https://retroachievements.org" + CurrentGame.ImageIcon + "\"," +
                                                "\"" + CurrentAchievementSummary.NumPossibleAchievements + "\"," +
                                                "\"" + CurrentAchievementSummary.PossibleScore + "\");";

                    LogCallback(CALLER_ID + "[masteryNotification] Sending: [" + script + "]");

                    try
                    {
                        chromiumWebBrowser.ExecuteScriptAsync(script, TimeSpan.FromSeconds(2));
                    }
                    catch (Exception ex)
                    {
                        LogCallback(CALLER_ID + "[masteryNotification]" + ex.Message);
                    }
                }
            });
        }

        private void ShowAchievementButton_Click(object sender, EventArgs eventArgs)
        {
            this.EnqueueAchievementNotification(
                new Achievement()
                {
                    Title = "Thrilling!!!!",
                    Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                    BadgeNumber = "49987",
                    Points = 1
                });
        }

        private void ReplayAchievementButton_Click(object sender, EventArgs eventArgs)
        {
            this.EnqueueAchievementNotification(MostRecentAchievement);
        }


        private void ShowGameMasteryButton_Click(object sender, EventArgs eventArgs)
        {
            this.EnqueueMasteryNotification();
        }

        private async void PromptUserInput()
        {
            if (this.Visible)
            {
                string script = "promptUser();";

                LogCallback(CALLER_ID + "[promptUser] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[promptUser]" + ex.Message);
                }
            }
        }

        private async void SetBackgroundColor()
        {
            if (this.Visible)
            {
                string script = "setBackgroundColor('" + BackgroundColorHexCode + "');";

                LogCallback(CALLER_ID + "[setBackgroundColor] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setBackgroundColor]" + ex.Message);
                }
            }
        }

        public async void SetFontColor()
        {
            if (this.Visible)
            {
                string script = "setFontColor('" + FontColorHexCode + "');";

                LogCallback(CALLER_ID + "[setFontColor] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setFontColor]" + ex.Message);
                }
            }
        }

        public async void SetFontFamily()
        {
            if (this.Visible)
            {
                string script = "setFontFamily(\"" + FontFamilyName + "\");";

                LogCallback(CALLER_ID + "[setFontFamily] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setFontFamily]" + ex.Message);
                }
            }
        }

        public async void SetFontOutline()
        {
            if (this.Visible)
            {
                string script = "setFontOutline('" + FontOutlineColorHexCode + " " + FontOutlineSize + "px');";

                LogCallback(CALLER_ID + "[setFontOutline] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setFontOutline]" + ex.Message);
                }
            }
        }

        private async void EnableAchievementEdit()
        {
            if (this.Visible)
            {
                string script = "enableEditModeAchievement();";

                LogCallback(CALLER_ID + "[enableEditModeAchievement] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[enableEditModeAchievement]" + ex.Message);
                }
            }
        }

        private async void DisableAchievementEdit()
        {
            if (this.Visible)
            {
                string script = "disableEditModeAchievement();";

                LogCallback(CALLER_ID + "[disableEditModeAchievement] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[disableEditModeAchievement]" + ex.Message);
                }
            }
        }

        private async void EnableMasteryEdit()
        {
            if (this.Visible)
            {
                string script = "enableEditModeMastery();";

                LogCallback(CALLER_ID + "[enableEditModeMastery] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[enableEditModeMastery]" + ex.Message);
                }
            }
        }

        private async void DisableMasteryEdit()
        {
            if (this.Visible)
            {
                string script = "disableEditModeMastery();";

                LogCallback(CALLER_ID + "[disableEditModeMastery] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[disableEditModeMastery]" + ex.Message);
                }
            }
        }

        private async void SetAchievementLeft()
        {
            var left = this.useCustomAchievementCheckbox.Checked ? CustomAchievementX : -15;

            if (this.Visible)
            {
                string script = "setAchievementLeft('" + left + "px');";

                LogCallback(CALLER_ID + "[setAchievementLeft] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setAchievementLeft]" + ex.Message);
                }
            }
        }

        private async void SetAchievementTop()
        {
            var top = this.useCustomAchievementCheckbox.Checked ? CustomAchievementY : 50;

            if (this.Visible)
            {
                string script = "setAchievementTop('" + top + "px');";

                LogCallback(CALLER_ID + "[setAchievementTop] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setAchievementTop]" + ex.Message);
                }
            }
        }

        private async void SetMasteryLeft()
        {
            var left = this.useCustomMasteryCheckbox.Checked ? CustomMasteryX : -15;

            if (this.Visible)
            {
                string script = "setMasteryLeft('" + left + "px');";

                LogCallback(CALLER_ID + "[setMasteryLeft] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setMasteryLeft]" + ex.Message);
                }
            }
        }

        private async void SetMasteryTop()
        {
            var top = this.useCustomMasteryCheckbox.Checked ? CustomMasteryY : 50;

            if (this.Visible)
            {
                string script = "setMasteryTop('" + top + "px');";

                LogCallback(CALLER_ID + "[setMasteryTop] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setMasteryTop]" + ex.Message);
                }
            }
        }

        private async void SetAchievementWidth()
        {
            var width = this.useCustomAchievementCheckbox.Checked ? GetVideoWidth(CustomAchievementFile) : 1200;

            if (this.useCustomAchievementCheckbox.Checked)
            {
                width = Convert.ToInt32(width * CustomAchievementScale);
            }
            if (this.Visible)
            {
                string script = "setAchievementWidth('" + width + "px');";

                LogCallback(CALLER_ID + "[setAchievementWidth] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setAchievementWidth]" + ex.Message);
                }
            }
        }

        private async void SetMasteryWidth()
        {
            var width = this.useCustomMasteryCheckbox.Checked ? GetVideoWidth(CustomMasteryFile) : 1200;

            if (this.useCustomMasteryCheckbox.Checked)
            {
                width = Convert.ToInt32(width * CustomMasteryScale);
            }

            if (this.Visible)
            {
                string script = "setMasteryWidth('" + width + "px');";

                LogCallback(CALLER_ID + "[setMasteryWidth] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setMasteryWidth]" + ex.Message);
                }
            }
        }

        private async void SetAchievementIn()
        {
            if (this.Visible)
            {
                string script = "setAchievementIn(" + (this.useCustomAchievementCheckbox.Checked ? CustomAchievementIn : 0) + ");";

                LogCallback(CALLER_ID + "[setAchievementIn] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setAchievementIn]" + ex.Message);
                }
            }
        }

        private async void SetAchievementOut()
        {
            if (this.Visible)
            {
                string script = "setAchievementOut(" + (this.useCustomAchievementCheckbox.Checked ? CustomAchievementOut : 5600) + ");";

                LogCallback(CALLER_ID + "[setAchievementOut] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setAchievementOut]" + ex.Message);
                }
            }
        }
        private async void SetMasteryIn()
        {
            if (this.Visible)
            {
                string script = "setMasteryIn(" + (this.useCustomMasteryCheckbox.Checked ? CustomMasteryIn : 0) + ");";

                LogCallback(CALLER_ID + "[setMasteryIn] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setMasteryIn]" + ex.Message);
                }
            }
        }

        private async void SetMasteryOut()
        {
            if (this.Visible)
            {
                string script = "setMasteryOut(" + (this.useCustomMasteryCheckbox.Checked ? CustomMasteryOut : 5600) + ");";

                LogCallback(CALLER_ID + "[setMasteryOut] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[setMasteryOut]" + ex.Message);
                }
            }
        }

        private async void HideNotifications()
        {
            if (this.Visible)
            {
                string script = "hideNotifications();";

                LogCallback(CALLER_ID + "[hideNotifications] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID + "[hideNotifications]" + ex.Message);
                }
            }
        }

        private void UseCustomAchievementCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            CustomAchievementEnabled = ((CheckBox)sender).Checked;

            this.useCustomAchievementCheckbox.Checked = CustomAchievementEnabled;
            this.selectCustomAchievementButton.Enabled = CustomAchievementEnabled;
            this.acheivementEditOutlineCheckbox.Enabled = CustomAchievementEnabled;

            this.customAchievementXNumericUpDown.Enabled = false;
            this.customAchievementYNumericUpDown.Enabled = false;
            this.scaleAchievementNumericUpDown.Enabled = false;
            this.inAchievementNumericUpDown.Enabled = false;
            this.outAchievementNumericUpDown.Enabled = false;

            this.masteryEditOultineCheckbox.Checked = false;

            this.xPositionLabel1.Enabled = false;
            this.yPositionLabel1.Enabled = false;
            this.scaleLabel1.Enabled = false;
            this.inLabel1.Enabled = false;
            this.outLabel1.Enabled = false;

            if (!CustomAchievementEnabled)
            {
                DisableAchievementEdit();

                this.acheivementEditOutlineCheckbox.Checked = false;
            }
            else if (string.IsNullOrEmpty(CustomAchievementFile))
            {
                SelectCustomAchievementButton_Click(null, null);
            }

            SetupBrowser();
        }

        private void UseCustomMasteryCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            CustomMasteryEnabled = ((CheckBox)sender).Checked;

            this.useCustomMasteryCheckbox.Checked = CustomMasteryEnabled;
            this.selectCustomMasteryNotificationButton.Enabled = CustomMasteryEnabled;
            this.masteryEditOultineCheckbox.Enabled = CustomMasteryEnabled;

            this.customMasteryXNumericUpDown.Enabled = false;
            this.customMasteryYNumericUpDown.Enabled = false;
            this.scaleMasteryNumericUpDown.Enabled = false;
            this.inMasteryNumericUpDown.Enabled = false;
            this.outMasteryNumericUpDown.Enabled = false;

            this.masteryEditOultineCheckbox.Checked = false;

            this.xPositionLabel2.Enabled = false;
            this.yPositionLabel2.Enabled = false;
            this.scaleLabel2.Enabled = false;
            this.inLabel2.Enabled = false;
            this.outLabel2.Enabled = false;

            if (!CustomMasteryEnabled)
            {
                DisableMasteryEdit();

                this.masteryEditOultineCheckbox.Checked = false;
            }
            else if (string.IsNullOrEmpty(CustomMasteryFile))
            {
                SelectCustomMasteryNotificationButton_Click(null, null);
            }

            SetupBrowser();
        }

        private void AcheivementEditOutlineCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            if (((CheckBox)sender).Checked)
            {
                EnableAchievementEdit();
                SendAchievementNotification(new Achievement()
                {
                    Title = "Thrilling!!!!",
                    Description = "Color every bit of Dinosaur 2. [Must color white if leaving white]",
                    BadgeNumber = "49987",
                    Points = 1
                });

                this.customAchievementXNumericUpDown.Enabled = true;
                this.customAchievementYNumericUpDown.Enabled = true;
                this.scaleAchievementNumericUpDown.Enabled = true;
                this.inAchievementNumericUpDown.Enabled = true;
                this.outAchievementNumericUpDown.Enabled = true;

                this.xPositionLabel1.Enabled = true;
                this.yPositionLabel1.Enabled = true;
                this.scaleLabel1.Enabled = true;
                this.inLabel1.Enabled = true;
                this.outLabel1.Enabled = true;
            }
            else
            {
                DisableAchievementEdit();

                this.customAchievementXNumericUpDown.Enabled = false;
                this.customAchievementYNumericUpDown.Enabled = false;
                this.scaleAchievementNumericUpDown.Enabled = false;
                this.inAchievementNumericUpDown.Enabled = false;
                this.outAchievementNumericUpDown.Enabled = false;

                this.xPositionLabel1.Enabled = false;
                this.yPositionLabel1.Enabled = false;
                this.scaleLabel1.Enabled = false;
                this.inLabel1.Enabled = false;
                this.outLabel1.Enabled = false;
            }

            SetAchievementLeft();
            SetAchievementTop();
            SetAchievementWidth();
        }

        private void MasteryEditOultineCheckbox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            if (((CheckBox)sender).Checked)
            {
                EnableMasteryEdit();
                SendMasteryNotification();

                this.customMasteryXNumericUpDown.Enabled = true;
                this.customMasteryYNumericUpDown.Enabled = true;
                this.scaleMasteryNumericUpDown.Enabled = true;
                this.inMasteryNumericUpDown.Enabled = true;
                this.outMasteryNumericUpDown.Enabled = true;

                this.xPositionLabel2.Enabled = true;
                this.yPositionLabel2.Enabled = true;
                this.scaleLabel2.Enabled = true;
                this.inLabel2.Enabled = true;
                this.outLabel2.Enabled = true;
            }
            else
            {
                DisableMasteryEdit();

                this.customMasteryXNumericUpDown.Enabled = false;
                this.customMasteryYNumericUpDown.Enabled = false;
                this.scaleMasteryNumericUpDown.Enabled = false;
                this.inMasteryNumericUpDown.Enabled = false;
                this.outMasteryNumericUpDown.Enabled = false;

                this.xPositionLabel2.Enabled = false;
                this.yPositionLabel2.Enabled = false;
                this.scaleLabel2.Enabled = false;
                this.inLabel2.Enabled = false;
                this.outLabel2.Enabled = false;
            }

            SetMasteryLeft();
            SetMasteryTop();
            SetMasteryWidth();
        }

        private void CustomAchievementXNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomAchievementX = Convert.ToInt32(((NumericUpDown)sender).Value);
            SetAchievementLeft();
        }

        private void CustomAchievementYNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomAchievementY = Convert.ToInt32(((NumericUpDown)sender).Value);
            SetAchievementTop();
        }

        private void CustomMasteryXNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomMasteryX = Convert.ToInt32(((NumericUpDown)sender).Value);
            SetMasteryLeft();
        }

        private void CustomMasteryYNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomMasteryY = Convert.ToInt32(((NumericUpDown)sender).Value);
            SetMasteryTop();
        }

        private void ScaleAchievementNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomAchievementScale = this.scaleAchievementNumericUpDown.Value;
            SetAchievementWidth();
        }

        private void ScaleMasteryNumericUpDown_ValueChanged(object sender, EventArgs eventArgs)
        {
            CustomAchievementScale = this.scaleMasteryNumericUpDown.Value;
            SetMasteryWidth();
        }

        private void OutAchievementNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            CustomAchievementOut = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void InAchievementNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            CustomAchievementIn = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void OutMasteryNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            CustomMasteryOut = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void InMasteryNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            CustomMasteryIn = Convert.ToInt32(((NumericUpDown)sender).Value);
        }
        private void FontSelectionButton_Click(object sender, System.EventArgs e)
        {
            fontDialog1.ShowColor = false;
            fontDialog1.ShowApply = false;
            fontDialog1.ShowEffects = false;
            fontDialog1.ShowHelp = false;

            fontDialog1.Font = new Font(FontFamilyName, 72f);

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Font font = fontDialog1.Font;

                FontFamilyName = font.FontFamily.Name;

                this.fontFamilyNameLabel.Text = "Name: " + FontFamilyName;

                SetFontFamily();
            }
        }

        private void FontColorPickerButton_Click(object sender, System.EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fontColorDisplayBox.BackColor = colorDialog1.Color;

                FontColorHexCode = HexConverter(colorDialog1.Color);
                fontColorHexCodeLabel.Text = FontColorHexCode;

                SetFontColor();
            }
        }

        private void FontOutlineColorPickerButton_Click(object sender, System.EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fontOutlineColorDisplayBox.BackColor = colorDialog1.Color;

                FontOutlineColorHexCode = HexConverter(colorDialog1.Color);
                fontOutlineColorHexCodeLabel.Text = FontOutlineColorHexCode;

                SetFontOutline();
            }
        }

        private void BackgroundColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                backgroundColorDisplayBox.BackColor = colorDialog1.Color;

                BackgroundColorHexCode = HexConverter(colorDialog1.Color);
                backgroundColorHexCodeLabel.Text = BackgroundColorHexCode;

                SetBackgroundColor();
            }
        }

        private void FontOutlineCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ToggleOutline();

            SetFontOutline();

            Settings.Default.notification_font_outline_enabled = ((CheckBox)sender).Checked;
            Settings.Default.Save();
        }

        private void FontOutlineSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            FontOutlineSize = Convert.ToInt32(((NumericUpDown)sender).Value.ToString());

            SetFontOutline();

            Settings.Default.notification_font_outline_size = FontOutlineSize;
            Settings.Default.Save();
        }

        private void ToggleOutline()
        {
            bool isChecked = this.fontOutlineCheckbox.Checked;

            this.fontOutlineColorDisplayBox.Enabled = isChecked;
            this.fontOutlineColorHexCodeLabel.Enabled = isChecked;
            this.fontOutlineColorPickerButton.Enabled = isChecked;
            this.fontOutlineSizeUpDown.Enabled = isChecked;

            if (!isChecked)
            {
                FontOutlineColorHexCode = "";
                FontOutlineSize = 0;
            }
            else
            {
                FontOutlineColorHexCode = Settings.Default.notification_font_outline_color_hex;
                FontOutlineSize = Settings.Default.notification_font_outline_size;

                this.fontOutlineColorHexCodeLabel.Text = Settings.Default.notification_font_outline_color_hex;
                this.fontOutlineColorDisplayBox.BackColor = ColorTranslator.FromHtml(FontOutlineColorHexCode);
                this.fontOutlineSizeUpDown.Value = Settings.Default.notification_font_outline_size;
            }
        }

        private String HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private void SelectCustomAchievementButton_Click(object sender, EventArgs eventArgs)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CustomAchievementFile = this.openFileDialog1.FileName;
            }
            else
            {
                this.useCustomAchievementCheckbox.Checked = !string.IsNullOrEmpty(CustomAchievementFile);
            }
        }

        private void SelectCustomMasteryNotificationButton_Click(object sender, EventArgs eventArgs)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CustomMasteryFile = this.openFileDialog1.FileName;
            }
            else
            {
                this.useCustomMasteryCheckbox.Checked = !string.IsNullOrEmpty(CustomMasteryFile);
            }
        }

        public int GetVideoWidth(string input)
        {
            var inputFile = new MediaFile { Filename = input };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }

            var frameSize = inputFile.Metadata.VideoData.FrameSize;

            return Convert.ToInt32(frameSize.Substring(0, frameSize.IndexOf("x")));
        }

        private int GetVideoDuration(string input)
        {
            var inputFile = new MediaFile { Filename = input };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }

            return Convert.ToInt32(inputFile.Metadata.Duration.TotalMilliseconds);
        }


        private void SetupBrowser()
        {
            if (this.chromiumWebBrowser != null)
            {
                this.Controls.Remove(this.chromiumWebBrowser);
            }
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            // 
            // chromiumWebBrowser
            // 
            this.chromiumWebBrowser.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser.Location = new System.Drawing.Point(240, 0);
            this.chromiumWebBrowser.Name = "chromiumWebBrowser";
            this.chromiumWebBrowser.Size = new System.Drawing.Size(1920, 1080);
            this.chromiumWebBrowser.TabIndex = 1;
            this.chromiumWebBrowser.Dock = DockStyle.None;
            this.chromiumWebBrowser.FrameLoadEnd += ChromiumWebBrowser_FrameLoadEnd;
            this.chromiumWebBrowser.LoadHtml(Resources.NotificationWindow);
            this.chromiumWebBrowser.RequestHandler = new CustomRequestHandler()
            {
                customAchievementEnabled = CustomAchievementEnabled,
                customMasteryEnabled = CustomMasteryEnabled
            };

            if (!this.Controls.Contains(this.chromiumWebBrowser))
            {
                this.Controls.Add(this.chromiumWebBrowser);
            }
        }

        public class NotificationRequest
        {
            public Achievement Achievement { get; set; }
            public GameSummary GameSummary { get; set; }
            public GameAchievementSummary GameAchievementSummary { get; set; }
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}
