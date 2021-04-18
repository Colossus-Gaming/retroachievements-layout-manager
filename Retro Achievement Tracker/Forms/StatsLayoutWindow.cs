using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class StatsLayoutWindow : Form
    {
        private bool isReady = false;

        private string rank;
        private string awards;
        private string ratio;
        private string points;
        private string truePoints;

        private string completed;
        private string cheevosEarned;
        private string cheevosPossible;
        private string gamePointsEarned;
        private string gamePointsPossible;
        private string gameTruePointsEarned;
        private string gameTruePointsPossible;
        public StatsLayoutWindow()
        {
            this.ClientSize = new Size(0, 0);

            FontFamily[] familyArray = FontFamily.Families.ToArray();
            FontFamily[] statsFontFamily = familyArray.Where(fontFamily => fontFamily.Name.Equals(Settings.Default.stats_font_family_name)).ToArray();
            FontFamily = statsFontFamily[0];

            SetupBrowser();

            this.Name = "RA Tracker - Stats";
            this.Text = "RA Tracker - Stats";
        }
        //Rank
        public FontFamily FontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.stats_font_family_name))
                    {
                        return font;
                    }
                }
                Settings.Default.stats_font_family_name = familyArray[0].Name;
                Settings.Default.Save();

                return familyArray[0];
            }
            set
            {
                Settings.Default.stats_font_family_name = value.Name;
                Settings.Default.Save();

                SetFontFamily();
            }
        }
        public string FontColor
        {
            get
            {
                return Settings.Default.stats_font_color_hex_code;
            }
            set
            {
                Settings.Default.stats_font_color_hex_code = value;
                Settings.Default.Save();

                SetFontColor();
            }
        }
        public string FontOutlineColor
        {
            get
            {
                return Settings.Default.stats_font_outline_color_hex;
            }
            set
            {
                Settings.Default.stats_font_outline_color_hex = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public int FontOutlineSize
        {
            get
            {
                return Settings.Default.stats_font_outline_size;
            }
            set
            {
                Settings.Default.stats_font_outline_size = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public bool FontOutlineEnable
        {
            get
            {
                return Settings.Default.stats_font_outline_enabled;
            }
            set
            {
                Settings.Default.stats_font_outline_enabled = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public string CompletedName
        {
            get
            {
                return Settings.Default.stats_completed_name;
            }
            set
            {
                Settings.Default.stats_completed_name = value;
                Settings.Default.Save();

                SetCompletedName();
            }
        }
        public bool RankEnable
        {
            get
            {
                return Settings.Default.stats_rank_enable;
            }
            set
            {
                Settings.Default.stats_rank_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowRank();
                }
                else
                {
                    HideRank();
                }
            }
        }
        public bool AwardsEnable
        {
            get
            {
                return Settings.Default.stats_awards_enable;
            }
            set
            {
                Settings.Default.stats_awards_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowAwards();
                }
                else
                {
                    HideAwards();
                }
            }
        }
        public bool PointsEnable
        {
            get
            {
                return Settings.Default.stats_points_enable;
            }
            set
            {
                Settings.Default.stats_points_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowPoints();
                }
                else
                {
                    HidePoints();
                }
            }
        }
        public bool TruePointsEnable
        {
            get
            {
                return Settings.Default.stats_true_points_enable;
            }
            set
            {
                Settings.Default.stats_true_points_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowTruePoints();
                }
                else
                {
                    HideTruePoints();
                }
            }
        }
        public bool CompletedEnable
        {
            get
            {
                return Settings.Default.stats_completed_enable;
            }
            set
            {
                Settings.Default.stats_completed_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowCompleted();
                }
                else
                {
                    HideCompleted();
                }
            }
        }
        public bool RatioEnable
        {
            get
            {
                return Settings.Default.stats_ratio_enable;
            }
            set
            {
                Settings.Default.stats_ratio_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowRatio();
                }
                else
                {
                    HideRatio();
                }
            }
        }
        public bool GameRatioEnable
        {
            get
            {
                return Settings.Default.stats_game_ratio_enable;
            }
            set
            {
                Settings.Default.stats_game_ratio_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowGameRatio();
                }
                else
                {
                    HideGameRatio();
                }
            }
        }
        public bool GamePointsEnable
        {
            get
            {
                return Settings.Default.stats_game_points_enable;
            }
            set
            {
                Settings.Default.stats_game_points_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowGamePoints();
                }
                else
                {
                    HideGamePoints();
                }
            }
        }
        public bool GameTruePointsEnable
        {
            get
            {
                return Settings.Default.stats_game_true_points_enable;
            }
            set
            {
                Settings.Default.stats_game_true_points_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowGameTruePoints();
                }
                else
                {
                    HideGameTruePoints();
                }
            }
        }
        public bool GameAchievementsEnable
        {
            get
            {
                return Settings.Default.stats_game_achievements_enable;
            }
            set
            {
                Settings.Default.stats_game_achievements_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowGameAchievements();
                }
                else
                {
                    HideGameAchievements();
                }
            }
        }
        public string RankName
        {
            get
            {
                return Settings.Default.stats_rank_name;
            }
            set
            {
                Settings.Default.stats_rank_name = value;
                Settings.Default.Save();

                SetRankName();
            }
        }
        public string AwardsName
        {
            get
            {
                return Settings.Default.stats_awards_name;
            }
            set
            {
                Settings.Default.stats_awards_name = value;
                Settings.Default.Save();

                SetAwardsName();
            }
        }
        public string PointsName
        {
            get
            {
                return Settings.Default.stats_points_name;
            }
            set
            {
                Settings.Default.stats_points_name = value;
                Settings.Default.Save();

                SetPointsName();
            }
        }
        public string TruePointsName
        {
            get
            {
                return Settings.Default.stats_game_true_points_name;
            }
            set
            {
                Settings.Default.stats_game_true_points_name = value;
                Settings.Default.Save();

                SetTruePointsName();
            }
        }
        public string RatioName
        {
            get
            {
                return Settings.Default.stats_ratio_name;
            }
            set
            {
                Settings.Default.stats_ratio_name = value;
                Settings.Default.Save();

                SetRatioName();
            }
        }
        public string GameRatioName
        {
            get
            {
                return Settings.Default.stats_game_ratio_name;
            }
            set
            {
                Settings.Default.stats_game_ratio_name = value;
                Settings.Default.Save();

                SetGameRatioName();
            }
        }
        public string GamePointsName
        {
            get
            {
                return Settings.Default.stats_game_points_name;
            }
            set
            {
                Settings.Default.stats_game_points_name = value;
                Settings.Default.Save();

                SetGamePointsName();
            }
        }
        public string GameTruePointsName
        {
            get
            {
                return Settings.Default.stats_game_true_points_name;
            }
            set
            {
                Settings.Default.stats_game_true_points_name = value;
                Settings.Default.Save();

                SetGameTruePointsName();
            }
        }
        public string GameAchievementsName
        {
            get
            {
                return Settings.Default.stats_game_achievements_name;
            }
            set
            {
                Settings.Default.stats_game_achievements_name = value;
                Settings.Default.Save();

                SetGameAchievementsName();
            }
        }
        public bool AutoLaunch
        {
            get
            {
                return Settings.Default.auto_stats;
            }
            set
            {
                Settings.Default.auto_stats = value;
            }
        }
        public async void SetRank(string newRank)
        {
            if (newRank != null)
            {
                rank = newRank;

                await ExecuteScript("setRank('" + rank + "');");

                if (RankEnable)
                {
                    ShowRank();
                }
                else
                {
                    HideRank();
                }
            }
        }
        public async void SetRankName()
        {
            await ExecuteScript("setRankName('" + RankName.Replace("'", "\\'") + ":');");
        }
        public async void HideRank()
        {
            await ExecuteScript("hideRank();");
        }
        public async void ShowRank()
        {
            await ExecuteScript("showRank();");
        }
        //Awards
        public async void SetAwards(string newAwards)
        {
            if (newAwards != null)
            {
                awards = newAwards;

                await ExecuteScript("setAwards('" + awards + "');");

                if (AwardsEnable)
                {
                    ShowAwards();
                }
                else
                {
                    HideAwards();
                }
            }
        }
        public async void SetAwardsName()
        {
            await ExecuteScript("setAwardsName('" + AwardsName.Replace("'", "\\'") + ":');");
        }
        public async void HideAwards()
        {
            await ExecuteScript("hideAwards();");
        }
        public async void ShowAwards()
        {
            await ExecuteScript("showAwards();");
        }
        //Points
        public async void SetPoints(string newPoints)
        {
            if (newPoints != null)
            {
                points = newPoints;

                await ExecuteScript("setPoints('" + points + "');");

                if (PointsEnable)
                {
                    ShowPoints();
                }
                else
                {
                    HidePoints();
                }
            }
        }
        public async void SetPointsName()
        {
            await ExecuteScript("setPointsName('" + PointsName.Replace("'", "\\'") + ":');");
        }
        public async void HidePoints()
        {
            await ExecuteScript("hidePoints();");
        }
        public async void ShowPoints()
        {
            await ExecuteScript("showPoints();");
        }
        //True Points
        public async void SetTruePoints(string newTruePoints)
        {
            if (newTruePoints != null)
            {
                truePoints = newTruePoints;

                await ExecuteScript("setTruePoints('" + truePoints + "');");

                if (TruePointsEnable)
                {
                    ShowTruePoints();
                }
                else
                {
                    HideTruePoints();
                }
            }
        }
        public async void SetTruePointsName()
        {
            await ExecuteScript("setTruePointsName('" + TruePointsName.Replace("'", "\\'") + ":');");
        }
        public async void HideTruePoints()
        {
            await ExecuteScript("hideTruePoints();");
        }
        public async void ShowTruePoints()
        {
            await ExecuteScript("showTruePoints();");
        }
        //Ratio
        public async void SetRatio(string newRatio)
        {
            if (newRatio != null)
            {
                ratio = newRatio;

                await ExecuteScript("setRatio('" + ratio + "');");

                if (RatioEnable)
                {
                    ShowRatio();
                }
                else
                {
                    HideRatio();
                }
            }
        }
        public async void SetRatioName()
        {
            await ExecuteScript("setRatioName('" + RatioName.Replace("'", "\\'") + ":');");
        }
        public async void HideRatio()
        {
            await ExecuteScript("hideRatio();");
        }
        public async void ShowRatio()
        {
            await ExecuteScript("showRatio();");
        }
        //Game Ratio
        public async void SetGameRatio()
        {
            if (gameTruePointsPossible != null && gamePointsPossible != null)
            {
                await ExecuteScript("setGameRatio('" + (Convert.ToDouble(gameTruePointsPossible) / Convert.ToDouble(gamePointsPossible)).ToString("0.00") + "%');");

                if (GameRatioEnable)
                {
                    ShowGameRatio();
                }
                else
                {
                    HideGameRatio();
                }
            }
        }
        public async void SetGameRatioName()
        {
            await ExecuteScript("setGameRatioName('" + GameRatioName.Replace("'", "\\'") + ":');");
        }
        public async void HideGameRatio()
        {
            await ExecuteScript("hideGameRatio();");
        }
        public async void ShowGameRatio()
        {
            await ExecuteScript("showGameRatio();");
        }
        //Game Points
        public async void SetGamePoints(string newGamePointsEarned, string newGamePointsPossible)
        {
            if (newGamePointsEarned != null && newGamePointsPossible != null)
            {
                gamePointsEarned = newGamePointsEarned;
                gamePointsPossible = newGamePointsPossible;

                await ExecuteScript("setGamePoints('" + gamePointsEarned + "', '" + gamePointsPossible + "');");

                if (GamePointsEnable)
                {
                    ShowGamePoints();
                }
                else
                {
                    HideGamePoints();
                }
            }
        }
        public async void SetGamePointsName()
        {
            await ExecuteScript("setGamePointsName('" + GamePointsName.Replace("'", "\\'") + ":');");
        }
        public async void HideGamePoints()
        {
            await ExecuteScript("hideGamePoints();");
        }
        public async void ShowGamePoints()
        {
            await ExecuteScript("showGamePoints();");
        }
        //Game Achievements
        public async void SetGameAchievements(string newCheevosEarned, string newCheevosPossible)
        {
            if (newCheevosEarned != null && newCheevosPossible != null)
            {
                cheevosEarned = newCheevosEarned;
                cheevosPossible = newCheevosPossible;

                await ExecuteScript("setGameAchievements('" + cheevosEarned + "', '" + cheevosPossible + "');");

                if (GameAchievementsEnable)
                {
                    ShowGameAchievements();
                }
                else
                {
                    HideGameAchievements();
                }
            }
        }
        public async void SetGameAchievementsName()
        {
            await ExecuteScript("setGameAchievementsName('" + GameAchievementsName.Replace("'", "\\'") + ":');");
        }
        public async void HideGameAchievements()
        {
            await ExecuteScript("hideGameAchievements();");
        }
        public async void ShowGameAchievements()
        {
            await ExecuteScript("showGameAchievements();");
        }
        //Game True Points
        public async void SetGameTruePoints(string newGameTruePointsEarned, string newGameTruePointsPossible)
        {
            if (newGameTruePointsEarned != null && newGameTruePointsPossible != null)
            {
                gameTruePointsEarned = newGameTruePointsEarned;
                gameTruePointsPossible = newGameTruePointsPossible;

                await ExecuteScript("setGameTruePoints('" + gameTruePointsEarned + "', '" + gameTruePointsPossible + "');");

                if (GameTruePointsEnable)
                {
                    ShowGameTruePoints();
                }
                else
                {
                    HideGameTruePoints();
                }
            }
        }
        public async void SetGameTruePointsName()
        {
            await ExecuteScript("setGameTruePointsName('" + GameTruePointsName.Replace("'", "\\'") + ":');");
        }
        public async void HideGameTruePoints()
        {
            await ExecuteScript("hideGameTruePoints();");
        }
        public async void ShowGameTruePoints()
        {
            await ExecuteScript("showGameTruePoints();");
        }
        //Completed
        public async void SetCompletedName()
        {
            await ExecuteScript("setCompletedName('" + CompletedName.Replace("'", "\\'") + ":');");
        }
        public async void SetCompleted(string newCompleted)
        {
            if (newCompleted != null)
            {
                completed = newCompleted;

                await ExecuteScript("setCompletedValue('" + completed + "');");

                if (CompletedEnable)
                {
                    ShowCompleted();
                }
                else
                {
                    HideCompleted();
                }
            }
        }
        public async void ShowCompleted()
        {
            await ExecuteScript("showCompleted();");
        }
        public async void HideCompleted()
        {
            await ExecuteScript("hideCompleted();");
        }
        //Fonts
        public async void SetFontColor()
        {
            await ExecuteScript("setFontColor(\"" + FontColor + "\");");
        }
        public async void SetFontFamily()
        {
            await ExecuteScript("setFontFamily(\"" + FontFamily.Name.Replace("'", "\\'") + "\");");
        }
        public async void SetFontOutline()
        {
            if (FontOutlineEnable)
            {
                await ExecuteScript("setFontOutline(\"" + FontOutlineColor + " " + FontOutlineSize + "px\");");
            }
            else
            {
                await ExecuteScript("setFontOutline(\"0px\");");
            }
        }
        protected async Task ExecuteScript(string script)
        {
            if (this.Visible && this.isReady)
            {
                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception)
                {
                }
            }
        }
        protected void SetupBrowser()
        {
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.StatsWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(1366, 768),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    this.isReady = true;
                    this.ClientSize = new Size(500, 500);
                });

                SetFontFamily();
                SetFontColor();
                SetFontOutline();

                SetRankName();
                SetRank(rank);

                SetAwardsName();
                SetAwards(awards);


                SetPointsName();
                SetPoints(points);

                SetTruePointsName();
                SetTruePoints(truePoints);

                SetRatioName();
                SetRatio(ratio);

                SetGameRatioName();
                SetGameRatio();

                SetCompletedName();
                SetCompleted(completed);

                SetGameAchievementsName();
                SetGameAchievements(cheevosEarned, cheevosPossible);

                SetGamePointsName();
                SetGamePoints(gamePointsEarned, gamePointsPossible);

                SetGameTruePointsName();
                SetGameTruePoints(gameTruePointsEarned, gameTruePointsPossible);
            });

            chromiumWebBrowser.LoadHtml(Resources.StatsWindow);

            this.Controls.Add(this.chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsLayoutWindow));
            this.SuspendLayout();
            // 
            // StatsLayoutWindow
            // 
            this.ClientSize = new Size(284, 261);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatsLayoutWindow";
            this.ResumeLayout(false);
        }
    }
}