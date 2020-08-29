using CefSharp;
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
        private bool HasMasteredGame;
        private Task NotificationsTask;
        private readonly ObservableCollection<NotificationRequest> NotificationRequests;
        private Stopwatch stopwatch;

        private CancellationTokenSource tokenSource2 = new CancellationTokenSource();

        private string FontColorHexCode;
        private string FontOutlineColorHexCode;
        private string FontFamilyName;
        private bool FontBolded;
        private int FontOutlineSize;

        private string BackgroundColorHexCode;

        public NotificationLayoutWindow()
        {
            InitializeComponent();
            SetupBrowser();
            SetCustomFont();
            LoadProperties();
            SetLabels();
            ToggleOutline();

            NotificationRequests = new ObservableCollection<NotificationRequest>();
            NotificationRequests.CollectionChanged += NotificationRequests_CollectionChanged;

            stopwatch = new Stopwatch();

            SetupNotificationsTask();
        }
        private void SetCustomFont()
        {
            this.backgroundColorPickerButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.customizationGroupBox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 13.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineCheckbox.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineColorPickerButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.fontOutlineColorHexCodeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.backgroundColorHexCodeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorHexCodeLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.fontFamilyNameLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorPicker.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontColorLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontSelectionButton.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontFamilyLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.backgroundColorLabel.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineSizeUpDown.Font = new Font(FontManager.GetFontFamilyByName("Eight Bit Dragon"), 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
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
            FontColorHexCode = Settings.Default.notification_font_color_hex_code;
            FontFamilyName = Settings.Default.notification_font_family_name;

            FontOutlineColorHexCode = Settings.Default.notification_font_outline_color_hex;
            FontOutlineSize = Settings.Default.notification_font_outline_size;

            BackgroundColorHexCode = Settings.Default.notification_background_color;

            this.fontOutlineCheckbox.Checked = Settings.Default.notification_font_outline_enabled;
        }

        private void ChromiumWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            SetFontColor();
            SetFontFamily();
            SetFontOutline();
            SetBackgroundColor();
        }

        private void NotificationRequests_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && NotificationRequests.Count > 0 && !stopwatch.IsRunning && NotificationsTask.Status != TaskStatus.Running)
            {
                SetupNotificationsTask();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.chromiumWebBrowser.LoadHtml(Resources.DefaultNotificationWindow);
            this.chromiumWebBrowser.FrameLoadEnd += PromptUserInput; 
            this.chromiumWebBrowser.FrameLoadEnd += ChromiumWebBrowser_FrameLoadEnd;

            this.chromiumWebBrowser.LoadHtml(Resources.DefaultNotificationWindow);
        }

        private void SetupNotificationsTask()
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
                                        delayInMilli = 7000;
                                    }
                                    else if (notificationRequest.GameAchievementSummary != null && notificationRequest.GameSummary != null)
                                    {
                                        SendMasteryNotification(notificationRequest.GameSummary, notificationRequest.GameAchievementSummary);
                                        stopwatch = Stopwatch.StartNew();
                                        delayInMilli = 11000;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (stopwatch.ElapsedMilliseconds > delayInMilli)
                        {
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
                    this.showRecentAchievementButton.Enabled = false;
                    this.showGameMasteryButton.Enabled = false;
                    this.replayAchievementButton.Enabled = false;
                    this.replayGameMasteryButton.Enabled = false;
                });
            }
            catch
            {
                tokenSource2.Cancel();
            }
        }

        private NotificationRequest NotificationRequestDequeue()
        {
            try
            {
                NotificationRequest notificationRequest = NotificationRequests[0];

                NotificationRequests.Remove(notificationRequest);

                return notificationRequest;
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
                    this.showRecentAchievementButton.Enabled = true;
                    this.showGameMasteryButton.Enabled = true;
                    this.replayAchievementButton.Enabled = true;
                    this.replayGameMasteryButton.Enabled = HasMasteredGame;
                });
            }
        }

        public void EnqueueAchievementNotification(Achievement achievement)
        {
            NotificationRequest notificationRequest = new NotificationRequest
            {
                Achievement = achievement
            };

            NotificationRequests.Add(notificationRequest);
            StartNotificationTask();
        }

        public void EnqueueMasteryNotification(GameSummary currentGame, GameAchievementSummary currentAchievementSummary)
        {
            NotificationRequest notificationRequest = new NotificationRequest
            {
                GameSummary = currentGame,
                GameAchievementSummary = currentAchievementSummary
            };

            NotificationRequests.Add(notificationRequest);
            StartNotificationTask();
        }

        private void StartNotificationTask()
        {
            if (NotificationsTask.Status != TaskStatus.Running)
            {
                SetupNotificationsTask();
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

                    LogCallback(CALLER_ID +"[achievementNotification] Sending: [" + script + "]");

                    try
                    {
                        chromiumWebBrowser.ExecuteScriptAsync(script, TimeSpan.FromSeconds(2));
                    }
                    catch (Exception ex)
                    {
                        LogCallback(CALLER_ID +"[achievementNotification]" + ex.Message);
                    }
                }
            });
        }

        private void SendMasteryNotification(GameSummary currentGame, GameAchievementSummary currentAchievementSummary)
        {
            Invoke((MethodInvoker)delegate
            {
                if (this.Visible)
                {
                    string script = "masteryNotification(\"" + currentGame.Title + "\"," +
                                                "\"https://retroachievements.org" + currentGame.ImageIcon + "\"," +
                                                "\"" + currentAchievementSummary.NumPossibleAchievements + "\"," +
                                                "\"" + currentAchievementSummary.PossibleScore + "\");";

                    LogCallback(CALLER_ID +"[masteryNotification] Sending: [" + script + "]");

                    try
                    {
                        chromiumWebBrowser.ExecuteScriptAsync(script, TimeSpan.FromSeconds(2));
                    }
                    catch (Exception ex)
                    {
                        LogCallback(CALLER_ID +"[masteryNotification]" + ex.Message);
                    }
                }
            });
        }

        private void ShowAchievementNotification(object sender, EventArgs eventArgs)
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

        private void ReplayRecentAchievement(object sender, EventArgs eventArgs)
        {
            this.EnqueueAchievementNotification(MostRecentAchievement);
        }

        private void ShowGameMasteryNotification(object sender, EventArgs eventArgs)
        {
            this.EnqueueMasteryNotification(new GameSummary()
            {
                Title = "Color a Dinosaur",
                ImageIcon = "/Images/011853.png"
            },
                new GameAchievementSummary()
                {
                    NumPossibleAchievements = 19,
                    PossibleScore = 19
                });
        }

        private async void PromptUserInput(object sender, EventArgs eventArgs)
        {
            if (this.Visible)
            {
                string script = "promptUser();";

                LogCallback(CALLER_ID +"[promptUser] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    LogCallback(CALLER_ID +"[promptUser]" + ex.Message);
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
                string script = "setFontFamily(\"" + FontFamilyName + "\", \"" + FontBolded + "\");";

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

        private void fontSelectionButton_Click(object sender, EventArgs e)
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
                FontBolded = font.Bold;

                this.fontFamilyNameLabel.Text = "Name: " + FontFamilyName;

                Settings.Default.notification_font_family_name = FontFamilyName;
                Settings.Default.Save();

                SetFontFamily();
            }
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fontColorDisplayBox.BackColor = colorDialog1.Color;

                FontColorHexCode = HexConverter(colorDialog1.Color);
                fontColorHexCodeLabel.Text = FontColorHexCode;

                Settings.Default.notification_font_color_hex_code = FontColorHexCode;
                Settings.Default.Save();

                SetFontColor();
            }
        }

        private void fontOutlineColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fontOutlineColorDisplayBox.BackColor = colorDialog1.Color;

                FontOutlineColorHexCode = HexConverter(colorDialog1.Color);
                fontOutlineColorHexCodeLabel.Text = FontOutlineColorHexCode;

                Settings.Default.notification_font_outline_color_hex = FontOutlineColorHexCode;
                Settings.Default.Save();

                SetFontOutline();
            }
        }


        private void backgroundColorPickerButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                backgroundColorDisplayBox.BackColor = colorDialog1.Color;

                BackgroundColorHexCode = HexConverter(colorDialog1.Color);
                backgroundColorHexCodeLabel.Text = BackgroundColorHexCode;

                Settings.Default.notification_background_color = BackgroundColorHexCode;
                Settings.Default.Save();

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

            Settings.Default.notification_font_outline_size = FontOutlineSize;
            Settings.Default.Save();

            SetFontOutline();
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

        public void SetHasMasteredGame(bool mastered)
        {
            HasMasteredGame = mastered;
        }

        public partial class NotificationRequest
        {
            public Achievement Achievement { get; set; }
            public GameSummary GameSummary { get; set; }
            public GameAchievementSummary GameAchievementSummary { get; set; }
        }

        private void SetupBrowser()
        {
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

            this.Controls.Add(this.chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}
