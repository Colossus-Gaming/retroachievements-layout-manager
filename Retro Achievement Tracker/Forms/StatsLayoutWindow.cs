using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class StatsLayoutWindow : Form
    {
        public Action<string> LogCallback { get; internal set; }

        public StatsLayoutWindow()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.chromiumWebBrowser.LoadHtml(Resources.DefaultStatsWindow);
        }

        public async void SetAwards(int awards)
        {
            if (this.Visible)
            {
                string script = "setAwards(" + awards + ");";

                LogCallback("[setAwards] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setAwards]" + ex.Message);
                }
            }
        }

        public async void SetPoints(int score)
        {
            if (this.Visible)
            {
                string script = "setPoints(" + score + ");";

                LogCallback("[setPoints] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setPoints]" + ex.Message);
                }
            }
        }

        public async void SetRank(int rank)
        {
            if (this.Visible)
            {
                string script = "setRank(" + rank + ");";

                LogCallback("[setRank] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setRank]" + ex.Message);
                }
            }
        }

        public async void SetGamePoints(int gameEarnedPoints, int gameTotalPoints)
        {
            if (this.Visible)
            {
                string script = "setGamePoints(" + gameEarnedPoints + ", " + gameTotalPoints + ");";

                LogCallback("[setGamePoints] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setGamePoints]" + ex.Message);
                }
            }
        }

        public async void SetGameAchievements(int gameEarnedAchievements, int gameTotalAchievements)
        {
            if (this.Visible)
            {
                string script = "setGameAchievements(" + gameEarnedAchievements + ", " + gameTotalAchievements + ");";

                LogCallback("[setGameAchievements] Sending: [" + script + "]");

                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    LogCallback("[setGameAchievements]" + ex.Message);
                }
            }
        }
    }
}