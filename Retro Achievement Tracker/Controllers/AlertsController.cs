using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class AlertsController
    {
        private static readonly AlertsController instance = new AlertsController();
        private static AlertsWindow AlertsWindow;
        public bool IsOpen;
        private Stopwatch NotificationsStopwatch;
        private Task NotificationsTask;
        private readonly ConcurrentQueue<NotificationRequest> NotificationRequests;
        private readonly CancellationTokenSource tokenSource2 = new CancellationTokenSource();
        private bool IsPlaying;
        private bool AnimationInPlayed;
        private bool AnimationOutPlayed;
        private bool PlayingAchievement;
        private bool IsEditingAchievement;

        public float AchievementPlayingTime;
        public float MasteryPlayingTime;

        private AlertsController()
        {
            AlertsWindow = new AlertsWindow();

            if (CustomAchievementEnabled && !File.Exists(CustomAchievementFile))
            {
                CustomAchievementEnabled = false;
            }

            if (CustomMasteryEnabled && !File.Exists(CustomMasteryFile))
            {
                CustomMasteryEnabled = false;
            }

            NotificationRequests = new ConcurrentQueue<NotificationRequest>();

            NotificationsStopwatch = new Stopwatch();

            NotificationsTask = Task.Factory.StartNew(() => { });
        }
        public void EnqueueAchievementNotifications(List<Achievement> achievements)
        {
            if (!AlertsWindow.IsDisposed)
            {
                if (CustomAchievementEnabled && string.IsNullOrEmpty(CustomAchievementFile))
                {
                    CustomAchievementEnabled = false;
                }

                foreach (Achievement achievement in achievements)
                {
                    NotificationRequest notificationRequest = new NotificationRequest
                    {
                        Achievement = achievement
                    };

                    NotificationRequests.Enqueue(notificationRequest);
                }
            }
        }

        public void EnqueueMasteryNotification(GameInfo gameInfoAndProgress)
        {

            NotificationRequest notificationRequest = new NotificationRequest
            {
                GameInfoAndProgress = gameInfoAndProgress
            };

            if (!AlertsWindow.IsDisposed)
            {
                if (CustomMasteryEnabled && string.IsNullOrEmpty(CustomMasteryFile))
                {
                    CustomMasteryEnabled = false;
                }

                NotificationRequests.Enqueue(notificationRequest);
            }
        }
        private NotificationRequest NotificationRequestDequeue()
        {
            NotificationRequests.TryDequeue(out NotificationRequest notificationRequest);

            return notificationRequest;
        }

        public void RunNotifications()
        {
            if (NotificationRequests.Count > 0 && !IsPlaying && !NotificationsStopwatch.IsRunning)
            {
                NotificationRequest notificationRequest = NotificationRequestDequeue();

                if (tokenSource2.Token.IsCancellationRequested)
                {
                    tokenSource2.Token.ThrowIfCancellationRequested();
                }

                if (notificationRequest != null)
                {
                    if (notificationRequest.Achievement != null)
                    {
                        PlayingAchievement = true;
                        AlertsWindow.StartAchievementAlert(notificationRequest.Achievement);
                    }
                    else if (notificationRequest.GameInfoAndProgress != null)
                    {
                        PlayingAchievement = false;
                        AlertsWindow.StartMasteryAlert(notificationRequest.GameInfoAndProgress);
                    }
                }
                NotificationsTask = Task.Factory.StartNew(RunNotificationTask, tokenSource2.Token);
            }
        }
        private async void RunNotificationTask()
        {
            NotificationsStopwatch = Stopwatch.StartNew();

            AnimationInPlayed = false;
            AnimationOutPlayed = false;

            while (NotificationsStopwatch.IsRunning)
            {
                if (tokenSource2.Token.IsCancellationRequested)
                {
                    tokenSource2.Token.ThrowIfCancellationRequested();
                }

                if (IsPlaying)
                {
                    if (PlayingAchievement)
                    {
                        AlertsWindow.GetAchievementPlayingTime();

                        if (!AnimationInPlayed && (AchievementPlayingTime * 1000) > (CustomAchievementEnabled ? CustomAchievementIn : 0))
                        {
                            AlertsWindow.SetAchievementIn(CustomAchievementEnabled ? CustomAchievementInSpeed : 0, CustomAchievementEnabled ? AchievementAnimationIn : AnimationDirection.STATIC);
                            AnimationInPlayed = true;
                        }
                        else if (!AnimationOutPlayed && (AchievementPlayingTime * 1000) > (CustomAchievementEnabled ? CustomAchievementOut : 5400))
                        {
                            AlertsWindow.SetAchievementOut(CustomAchievementEnabled ? CustomAchievementOutSpeed : 700, CustomAchievementEnabled ? AchievementAnimationOut : AnimationDirection.UP);
                            AnimationOutPlayed = true;
                        }
                    }
                    else
                    {
                        AlertsWindow.GetMasteryPlayingTime();

                        if (!AnimationInPlayed && (MasteryPlayingTime * 1000) > (CustomMasteryEnabled ? CustomMasteryIn : 0))
                        {
                            AlertsWindow.SetMasteryIn(CustomMasteryEnabled ? CustomMasteryInSpeed : 0, CustomMasteryEnabled ? MasteryAnimationIn : AnimationDirection.STATIC);
                            AnimationInPlayed = true;
                        }
                        else if (!AnimationOutPlayed && (MasteryPlayingTime * 1000) > (CustomMasteryEnabled ? CustomMasteryOut : 5400))
                        {
                            AlertsWindow.SetMasteryOut(CustomMasteryEnabled ? CustomMasteryOutSpeed : 700, CustomMasteryEnabled ? MasteryAnimationOut : AnimationDirection.UP);
                            AnimationOutPlayed = true;
                        }
                    }
                    if (AnimationOutPlayed && AnimationInPlayed)
                    {
                        NotificationsStopwatch.Stop();
                    }
                    await Task.Delay(10);
                }
            }
        }

        public async void SetIsPlaying(bool isPlaying)
        {
            IsPlaying = isPlaying;

            if (!IsPlaying)
            {
                NotificationsStopwatch.Stop();

                if (!(AnimationInPlayed && AnimationOutPlayed))
                {
                    AlertsWindow.SetAchievementOut(100, AnimationDirection.STATIC);
                    AlertsWindow.SetMasteryOut(100, AnimationDirection.STATIC);
                }

                if (!IsEditingAchievement)
                {
                    AlertsWindow.HideNotifications();

                    if (NotificationRequests.Count > 0)
                    {
                        await Task.Delay(200);

                        RunNotifications();
                    }
                }
            }
        }
        public static AlertsController Instance
        {
            get
            {
                return instance;
            }
        }
        public void Close()
        {
            AlertsWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                if (AlertsWindow == null || AlertsWindow.IsDisposed)
                {
                    AlertsWindow = new AlertsWindow();
                }
                AlertsWindow.Show();
            }
            else
            {
                AlertsWindow.BringToFront();
            }
        }
        public void SetAllSettings()
        {
            if (IsOpen)
            {
                AlertsWindow.AssignJavaScriptVariables();

                AlertsWindow.SetBorderBackgroundColor(BorderBackgroundColor);
                AlertsWindow.SetWindowBackgroundColor(WindowBackgroundColor);

                if (BorderEnabled)
                {
                    AlertsWindow.EnableBorder();
                }
                else
                {
                    AlertsWindow.DisableBorder();
                }

                if (AdvancedSettingsEnabled)
                {
                    SetAdvancedSettings();
                }
                else
                {
                    SetSimpleSettings();
                }

                SetAchievementSettings();
                SetMasterySettings();

                AlertsWindow.SetClientSize();
            }
        }
        private void SetSimpleSettings()
        {
            AlertsWindow.SetSimpleFontFamily(SimpleFontFamily);
            AlertsWindow.SetSimpleFontColor(SimpleFontColor);
            AlertsWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px", SimpleFontOutlineEnabled ? SimpleFontOutlineSize + "px solid " + SimpleFontOutlineColor : "0px");
        }
        private void SetAdvancedSettings()
        {
            AlertsWindow.SetTitleFontFamily(TitleFontFamily);
            AlertsWindow.SetTitleColor(TitleColor);
            AlertsWindow.SetTitleOutline(TitleOutlineEnabled ? TitleOutlineColor + " " + TitleOutlineSize + "px" : "0px");

            AlertsWindow.SetDescriptionFontFamily(DescriptionFontFamily);
            AlertsWindow.SetDescriptionColor(DescriptionColor);
            AlertsWindow.SetDescriptionOutline(DescriptionOutlineEnabled ? DescriptionOutlineColor + " " + DescriptionOutlineSize + "px" : "0px");

            AlertsWindow.SetPointsFontFamily(PointsFontFamily);
            AlertsWindow.SetPointsColor(PointsColor);
            AlertsWindow.SetPointsOutline(PointsOutlineEnabled ? PointsOutlineColor + " " + PointsOutlineSize + "px" : "0px");

            AlertsWindow.SetLineColor(LineColor);
            AlertsWindow.SetLineOutline(LineOutlineEnabled ? LineOutlineSize + "px solid " + LineOutlineColor : "0px");
        }
        public void SetAchievementSettings()
        {
            AlertsWindow.SetAchievementVideo(CustomAchievementEnabled ? "https://appassets.customachievement/" + new FileInfo(CustomAchievementFile).Name : "https://appassets.video/achievement-notification.webm");
            AlertsWindow.SetAchievementLeft(CustomAchievementEnabled ? CustomAchievementX : -25);
            AlertsWindow.SetAchievementTop(CustomAchievementEnabled ? CustomAchievementY : 5);
            AlertsWindow.SetAchievementWidth(CustomAchievementEnabled ? Convert.ToInt32(CustomAchievementScale * MediaHelper.GetVideoWidth(CustomAchievementFile)) : 1028);
        }
        public void SetMasterySettings()
        {
            AlertsWindow.SetMasteryVideo(CustomMasteryEnabled ? "https://appassets.custommastery/" + new FileInfo(CustomMasteryFile).Name : "https://appassets.video/mastery-notification.webm");
            AlertsWindow.SetMasteryLeft(CustomMasteryEnabled ? CustomMasteryX : -25);
            AlertsWindow.SetMasteryTop(CustomMasteryEnabled ? CustomMasteryY : 5);
            AlertsWindow.SetMasteryWidth(CustomMasteryEnabled ? Convert.ToInt32(CustomMasteryScale * MediaHelper.GetVideoWidth(CustomMasteryFile)) : 1028);
        }
        public void SendAchievementNotification(Achievement achievement)
        {
            if (IsOpen)
            {
                AlertsWindow.StartAchievementAlert(achievement);
            }
        }
        public void SendMasteryNotification(GameInfo gameInfo)
        {
            if (IsOpen)
            {
                AlertsWindow.StartMasteryAlert(gameInfo);
            }
        }
        public void EnableAchievementEdit()
        {
            if (IsOpen)
            {
                AlertsWindow.EnableAchievementEdit();
                IsEditingAchievement = true;
            }
        }
        public void DisableAchievementEdit()
        {
            if (IsOpen)
            {
                AlertsWindow.DisableAchievementEdit();
                IsEditingAchievement = false;
                IsPlaying = false;
            }
        }
        public void EnableMasteryEdit()
        {
            if (IsOpen)
            {
                AlertsWindow.EnableMasteryEdit();
                IsEditingAchievement = true;
            }
        }
        public void DisableMasteryEdit()
        {
            if (IsOpen)
            {
                AlertsWindow.DisableMasteryEdit();
                IsEditingAchievement = false;
                IsPlaying = false;
            }
        }
        /**
         * Variables
         */
        public bool AchievementAlertEnable
        {
            get
            {
                return Settings.Default.alerts_achievement_enable;
            }
            set
            {
                Settings.Default.alerts_achievement_enable = value;
                Settings.Default.Save();
            }
        }
        public bool MasteryAlertEnable
        {
            get
            {
                return Settings.Default.alerts_mastery_enable;
            }
            set
            {
                Settings.Default.alerts_mastery_enable = value;
                Settings.Default.Save();
            }
        }
        public bool AdvancedSettingsEnabled
        {
            get
            {
                return Settings.Default.alerts_advanced_options_enabled;
            }
            set
            {
                Settings.Default.alerts_advanced_options_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public FontFamily SimpleFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.notification_font_family_name))
                    {
                        return font;
                    }
                }

                Settings.Default.notification_font_family_name = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.notification_font_family_name = value.Name;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string SimpleFontColor
        {
            get
            {
                return Settings.Default.notification_font_color_hex_code;
            }
            set
            {
                Settings.Default.notification_font_color_hex_code = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string SimpleFontOutlineColor
        {
            get
            {
                return Settings.Default.notification_font_outline_color_hex;
            }
            set
            {
                Settings.Default.notification_font_outline_color_hex = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int SimpleFontOutlineSize
        {
            get
            {
                return Settings.Default.notification_font_outline_size;
            }
            set
            {
                Settings.Default.notification_font_outline_size = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool SimpleFontOutlineEnabled
        {
            get
            {
                return Settings.Default.notification_font_outline_enabled;
            }
            set
            {
                Settings.Default.notification_font_outline_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public FontFamily TitleFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.alerts_title_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.alerts_title_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.alerts_title_font_family = value.Name;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public FontFamily DescriptionFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.alerts_description_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.alerts_description_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.alerts_description_font_family = value.Name;
                Settings.Default.Save();

                SetAllSettings();
            }
        }

        public FontFamily PointsFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.alerts_points_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.alerts_points_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.alerts_points_font_family = value.Name;
                Settings.Default.Save();

                SetAllSettings();
            }
        }

        public string TitleColor
        {
            get
            {
                return Settings.Default.alerts_title_color;
            }
            set
            {
                Settings.Default.alerts_title_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string DescriptionColor
        {
            get
            {
                return Settings.Default.alerts_description_color;
            }
            set
            {
                Settings.Default.alerts_description_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string PointsColor
        {
            get
            {
                return Settings.Default.alerts_points_color;
            }
            set
            {
                Settings.Default.alerts_points_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string LineColor
        {
            get
            {
                return Settings.Default.alerts_line_color;
            }
            set
            {
                Settings.Default.alerts_line_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool TitleOutlineEnabled
        {
            get
            {
                return Settings.Default.alerts_title_outline_enabled;
            }
            set
            {
                Settings.Default.alerts_title_outline_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool DescriptionOutlineEnabled
        {
            get
            {
                return Settings.Default.alerts_description_outline_enabled;
            }
            set
            {
                Settings.Default.alerts_description_outline_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool PointsOutlineEnabled
        {
            get
            {
                return Settings.Default.alerts_points_outline_enabled;
            }
            set
            {
                Settings.Default.alerts_points_outline_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool LineOutlineEnabled
        {
            get
            {
                return Settings.Default.alerts_line_outline_enabled;
            }
            set
            {
                Settings.Default.alerts_line_outline_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string TitleOutlineColor
        {
            get
            {
                return Settings.Default.alerts_title_outline_color;
            }
            set
            {
                Settings.Default.alerts_title_outline_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string DescriptionOutlineColor
        {
            get
            {
                return Settings.Default.alerts_description_outline_color;
            }
            set
            {
                Settings.Default.alerts_description_outline_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string PointsOutlineColor
        {
            get
            {
                return Settings.Default.alerts_points_outline_color;
            }
            set
            {
                Settings.Default.alerts_points_outline_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string LineOutlineColor
        {
            get
            {
                return Settings.Default.alerts_line_outline_color;
            }
            set
            {
                Settings.Default.alerts_line_outline_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int TitleOutlineSize
        {
            get
            {
                return Settings.Default.alerts_title_outline_size;
            }
            set
            {
                Settings.Default.alerts_title_outline_size = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int DescriptionOutlineSize
        {
            get
            {
                return Settings.Default.alerts_description_outline_size;
            }
            set
            {
                Settings.Default.alerts_description_outline_size = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int PointsOutlineSize
        {
            get
            {
                return Settings.Default.alerts_points_outline_size;
            }
            set
            {
                Settings.Default.alerts_points_outline_size = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int LineOutlineSize
        {
            get
            {
                return Settings.Default.alerts_line_outline_size;
            }
            set
            {
                Settings.Default.alerts_line_outline_size = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool BorderEnabled
        {
            get
            {
                return Settings.Default.notifications_border_enable;
            }
            set
            {
                Settings.Default.notifications_border_enable = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string BorderBackgroundColor
        {
            get
            {
                return Settings.Default.notifications_background_color;
            }
            set
            {
                Settings.Default.notifications_background_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string WindowBackgroundColor
        {
            get
            {
                return Settings.Default.alerts_window_background_color;
            }
            set
            {
                Settings.Default.alerts_window_background_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool CustomAchievementEnabled
        {
            get
            {
                return Settings.Default.notification_custom_achievement_enable;
            }
            set
            {
                Settings.Default.notification_custom_achievement_enable = value;
                Settings.Default.Save();

                if (IsOpen && value)
                {
                    AlertsWindow.SetCustomAchievementDirectorMapping();
                }
                else
                {
                    SetAllSettings();
                }
            }
        }
        public bool CustomMasteryEnabled
        {
            get
            {
                return Settings.Default.notification_custom_mastery_enable;
            }
            set
            {
                Settings.Default.notification_custom_mastery_enable = value;
                Settings.Default.Save();

                if (IsOpen && value)
                {
                    AlertsWindow.SetCustomMasteryDirectorMapping();
                }
                else
                {
                    SetAllSettings();
                }
            }
        }
        public int CustomAchievementX
        {
            get
            {
                return Settings.Default.notification_custom_achievement_x;
            }
            set
            {
                Settings.Default.notification_custom_achievement_x = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int CustomAchievementY
        {
            get
            {
                return Settings.Default.notification_custom_achievement_y;
            }
            set
            {
                Settings.Default.notification_custom_achievement_y = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int CustomMasteryX
        {
            get
            {
                return Settings.Default.notification_custom_mastery_x;
            }
            set
            {
                Settings.Default.notification_custom_mastery_x = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int CustomMasteryY
        {
            get
            {
                return Settings.Default.notification_custom_mastery_y;
            }
            set
            {
                Settings.Default.notification_custom_mastery_y = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public decimal CustomAchievementScale
        {
            get
            {
                return Settings.Default.notification_custom_achievement_scale;
            }
            set
            {
                Settings.Default.notification_custom_achievement_scale = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public decimal CustomMasteryScale
        {
            get
            {
                return Settings.Default.notification_custom_mastery_scale;
            }
            set
            {
                Settings.Default.notification_custom_mastery_scale = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public int CustomAchievementIn
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
        public int CustomAchievementOut
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
        public int CustomMasteryIn
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
        public int CustomMasteryOut
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
        public int CustomAchievementInSpeed
        {
            get
            {
                return Settings.Default.alerts_custom_achievement_in_speed;
            }
            set
            {
                Settings.Default.alerts_custom_achievement_in_speed = value;
                Settings.Default.Save();
            }
        }
        public int CustomAchievementOutSpeed
        {
            get
            {
                return Settings.Default.alerts_custom_achievement_out_speed;
            }
            set
            {
                Settings.Default.alerts_custom_achievement_out_speed = value;
                Settings.Default.Save();
            }
        }
        public int CustomMasteryInSpeed
        {
            get
            {
                return Settings.Default.alerts_custom_mastery_in_speed;
            }
            set
            {
                Settings.Default.alerts_custom_mastery_in_speed = value;
                Settings.Default.Save();
            }
        }
        public int CustomMasteryOutSpeed
        {
            get
            {
                return Settings.Default.alerts_custom_mastery_out_speed;
            }
            set
            {
                Settings.Default.alerts_custom_mastery_out_speed = value;
                Settings.Default.Save();
            }
        }
        public AnimationDirection AchievementAnimationIn
        {
            get
            {
                switch (Settings.Default.notifications_achievement_in_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                Settings.Default.notifications_achievement_in_animation = value.ToString();
                Settings.Default.Save();
            }
        }
        public AnimationDirection AchievementAnimationOut
        {
            get
            {
                switch (Settings.Default.notifications_achievement_out_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                Settings.Default.notifications_achievement_out_animation = value.ToString();
                Settings.Default.Save();
            }
        }
        public AnimationDirection MasteryAnimationIn
        {
            get
            {
                switch (Settings.Default.notifications_mastery_in_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                Settings.Default.notifications_mastery_in_animation = value.ToString();
                Settings.Default.Save();
            }
        }
        public AnimationDirection MasteryAnimationOut
        {
            get
            {
                switch (Settings.Default.notifications_mastery_out_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                Settings.Default.notifications_mastery_out_animation = value.ToString();
                Settings.Default.Save();
            }
        }
        public string CustomAchievementFile
        {
            get
            {
                return Settings.Default.notification_custom_achievement_file;
            }
            set
            {
                Settings.Default.notification_custom_achievement_file = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public string CustomMasteryFile
        {
            get
            {
                return Settings.Default.notification_custom_mastery_file;
            }
            set
            {
                Settings.Default.notification_custom_mastery_file = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public bool AutoLaunch
        {
            get
            {
                return Settings.Default.auto_notifications;
            }
            set
            {
                Settings.Default.auto_notifications = value;
                Settings.Default.Save();
            }
        }
    }
}
