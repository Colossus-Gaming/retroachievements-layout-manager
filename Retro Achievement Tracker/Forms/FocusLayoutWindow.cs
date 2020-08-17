using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class FocusLayoutWindow : Form
    {
        private List<Achievement> LockedAchievements;
        public Achievement FocusedAchievement;
        public int CurrentlyFocusedIndex;
        public Action<string> LogCallback { get; internal set; }

        public FocusLayoutWindow()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.chromiumWebBrowser.LoadHtml(Resources.DefaultFocusWindow);
        }

        public void SetLockedAchievements(List<Achievement> achievements)
        {
            if (achievements != null && achievements.Count > 0)
            {
                int gameId = achievements[0].GameId;
                if (LockedAchievements == null || (LockedAchievements.Count > 0 && gameId != LockedAchievements[0].GameId))
                {
                    CurrentlyFocusedIndex = 0;
                    FocusedAchievement = null;
                }
            }
            else
            {
                CurrentlyFocusedIndex = 0;
                FocusedAchievement = null;
            }

            LockedAchievements = achievements;

            UpdateFocusAchievement();
        }

        public void UpdateFocusAchievement()
        {
            if (this.Visible)
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateFocusButtons();

                    if (LockedAchievements.Count > 0)
                    {
                        if (CurrentlyFocusedIndex >= LockedAchievements.Count)
                        {
                            CurrentlyFocusedIndex = LockedAchievements.Count - 1;
                        }
                        else if (CurrentlyFocusedIndex < 0)
                        {
                            CurrentlyFocusedIndex = 0;
                        }

                        FocusedAchievement = LockedAchievements[CurrentlyFocusedIndex];

                        this.focusAchievementPictureBox.ImageLocation = "https://retroachievements.org/Badge/" + FocusedAchievement.BadgeNumber + ".png";
                        this.focusAchievementTitleLabel.Text = FocusedAchievement.Title;
                        this.focusAchievementDescriptionLabel.Text = FocusedAchievement.Description;
                    }
                    else
                    {
                        CurrentlyFocusedIndex = 0;

                        this.focusAchievementPictureBox.ImageLocation = string.Empty;
                        this.focusAchievementTitleLabel.Text = string.Empty;
                        this.focusAchievementDescriptionLabel.Text = string.Empty;

                        HideFocus();
                    }
                });
            }
        }

        private void SetFocusButton_Click(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void HideFocusButton_Click(object sender, EventArgs e)
        {
            HideFocus();
        }

        public async void SetFocus()
        {
            if (this.Visible && LockedAchievements != null && FocusedAchievement != null)
            {
                string script = "setFocus(\"" + FocusedAchievement.Title + "\"," +
                           "\"https://retroachievements.org/Badge/" + FocusedAchievement.BadgeNumber + ".png\"," +
                           "\"" + FocusedAchievement.Description + "\"," +
                           "\"" + FocusedAchievement.Points + "\");";

                LogCallback("[setFocus] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    LogCallback("[setFocus]" + ex.Message);
                }
            }
        }

        public async void HideFocus()
        {
            if (this.Visible)
            {
                string script = "hideFocus();";

                LogCallback("[hideFocus] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(2));
                }
                catch (Exception ex)
                {
                    LogCallback("[hideFocus]" + ex.Message);
                }
            }
        }

        private void MoveHuntIndexLeft(object sender, EventArgs e)
        {
            CurrentlyFocusedIndex--;

            if (CurrentlyFocusedIndex < 0)
            {
                CurrentlyFocusedIndex = 0;
            }

            UpdateFocusAchievement();
        }

        private void MoveHuntIndexRight(object sender, EventArgs e)
        {
            CurrentlyFocusedIndex++;

            if (CurrentlyFocusedIndex >= LockedAchievements.Count)
            {
                CurrentlyFocusedIndex = LockedAchievements.Count - 1;
            }

            UpdateFocusAchievement();
        }

        private void UpdateFocusButtons()
        {
            if (LockedAchievements.Count == 0)
            {
                this.focusAchievementButtonLeft.Enabled = false;
                this.focusAchievementButtonRight.Enabled = false;
                this.setFocusButton.Enabled = false;
                this.hideFocusButton.Enabled = false;
            }
            else
            {
                this.setFocusButton.Enabled = true;
                this.hideFocusButton.Enabled = true;

                if (CurrentlyFocusedIndex == 0)
                {
                    this.focusAchievementButtonLeft.Enabled = false;
                    this.focusAchievementButtonRight.Enabled = true;
                }
                else if (CurrentlyFocusedIndex == LockedAchievements.Count - 1)
                {
                    this.focusAchievementButtonLeft.Enabled = true;
                    this.focusAchievementButtonRight.Enabled = false;
                }
                else
                {
                    this.focusAchievementButtonLeft.Enabled = true;
                    this.focusAchievementButtonRight.Enabled = true;
                }
            }
        }
    }
}