using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class LastFiveWindow : Form
    {
        public LastFiveWindow()
        {
            ClientSize = new Size(0, 0);

            Name = "RA Tracker - Last Five Achievements";
            Text = "RA Tracker - Last Five Achievements";

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            Shown += LastFiveWindow_Shown;
            FormClosed += LastFiveWindow_FormClosed;

            SetupBrowser();
        }

        private void LastFiveWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastFiveController.Instance.IsOpen = false;
        }

        private void LastFiveWindow_Shown(object sender, EventArgs e)
        {
            LastFiveController.Instance.IsOpen = true;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public void AssignJavaScriptVariables()
        {
            ExecuteScript(
                "container = document.getElementById(\"container\");" +
                "allElements = document.getElementsByClassName(\"has-font\");" +
                "allTitles = document.getElementsByClassName(\"title\");" +
                "allDates = document.getElementsByClassName(\"date\");" +
                "allLines = document.getElementsByClassName(\"line\");" +
                "allPoints = document.getElementsByClassName(\"points\");" +
                "allAchievements = document.getElementsByClassName(\"focus-achievement\");");
        }
        public void SetSimpleFontColor(string value)
        {
            ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }" +
                "for (var i = 0; i < allLines.length; i++) { allLines[i].style.color = \"" + value + "\"; }" +
                "for (var i = 0; i < allLines.length; i++) { allLines[i].style.backgroundColor = \"" + value + "\"; }");
        }
        public void SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            string script = "for (var i = 0; i < allElements.length; i++) { " +
                "   allElements[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allElements[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "}" +
                "for (var i = 0; i < allTitles.length; i++) { " +
                "   textFit(allTitles[i], { alignVert: true , alignHoriz: true, multiLine: true });" +
                "}" +
                "for (var i = 0; i < allDates.length; i++) { " +
                "   textFit(allDates[i], { alignVert: true , alignHoriz: true, multiLine: true });" +
                "}" +
                "for (var i = 0; i < allPoints.length; i++) { " +
                "   textFit(allPoints[i]);" +
                "}";

            ExecuteScript(script);
        }

        public void SetSimpleFontOutline(string fontOutline, string borderOutline)
        {
            ExecuteScript(
                 "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; }" +
                 "for (var i = 0; i < allLines.length; i++) { allLines[i].style.border = \"" + borderOutline + "\"; }");
        }

        public void SetBackgroundColor(string value)
        {
            ExecuteScript(
                "for (var i = 0; i < allAchievements.length; i++) { allAchievements[i].style.backgroundColor = \"" + value + "\"; }");
        }
        public void SetWindowBackgroundColor(string value)
        {
            ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }
        public void EnableBorder()
        {
            ExecuteScript("for (var i = 0; i < allAchievements.length; i++) { allAchievements[i].style.backgroundImage = \"url('disk://background')\"; }");
        }
        public void DisableBorder()
        {
            ExecuteScript("for (var i = 0; i < allAchievements.length; i++) { allAchievements[i].style.backgroundImage = \"\"; }");
        }
        public void SetTitleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allTitles.length; i++) { " +
                "   allTitles[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allTitles[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allTitles[i], { alignVert: true, alignHoriz: true, multiLine: true });" +
                "}");
        }
        public void SetDateFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allDates.length; i++) { " +
                "   allDates[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allDates[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allDates[i], { alignVert: true, alignHoriz: true, multiLine: true });" +
                "}");
        }

        public void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allPoints.length; i++) { " +
                "   allPoints[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allPoints[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allPoints[i]);" +
                "}");
        }

        public void SetTitleColor(string value)
        {
            ExecuteScript(
                "for (var i = 0; i < allTitles.length; i++) { allTitles[i].style.color = \"" + value + "\"; }");
        }

        public void SetDateColor(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allDates.length; i++) { allDates[i].style.color = \"" + value + "\"; }");
        }

        public void SetPointsColor(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allPoints.length; i++) { allPoints[i].style.color = \"" + value + "\"; }");
        }
        public void SetLineColor(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allLines.length; i++) { allLines[i].style.color = \"" + value + "\"; allLines[i].style.backgroundColor = \"" + value + "\"; }");
        }
        public void SetTitleOutline(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allTitles.length; i++) { allTitles[i].style.webkitTextStroke = \"" + value + "\"; textFit(allTitles[i], { alignVert: true, alignHoriz: true, multiLine: true }); }");
        }
        public void SetDateOutline(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allDates.length; i++) { allDates[i].style.webkitTextStroke = \"" + value + "\"; textFit(allDates[i], { alignVert: true, alignHoriz: true, multiLine: true }); }");
        }
        public void SetPointsOutline(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allPoints.length; i++) { allPoints[i].style.webkitTextStroke = \"" + value + "\"; textFit(allPoints[i], { alignVert: true, alignHoriz: true, multiLine: true }); }");
        }
        public void SetLineOutline(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allLines.length; i++) { allLines[i].style.border = \"" + value + "\"; }");
        }
        public void AddAchievement(Achievement achievement)
        {
            ExecuteScript("addToList(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                                       "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\"," +
                                       "\"" + achievement.Points + "\"," +
                                       "\"" + achievement.DateEarned.Value.ToLocalTime().ToString() + "\", " +
                                       "\"" + achievement.Id + "\");");
        }

        public void SetAchievementPositions(List<ValueTuple<int, int, int>> achievementSpecs)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach(ValueTuple<int, int, int> value in achievementSpecs)
            {
                string newOffset;

                switch (value.Item2)
                {
                    case 0:
                        newOffset = "'5px'";
                        break;
                    case 1:
                        newOffset = "'150px'";
                        break;
                    case 2:
                        newOffset = "'295px'";
                        break;
                    case 3:
                        newOffset = "'440px'";
                        break;
                    case 4:
                        newOffset = "'585px'";
                        break;
                    default:
                        stringBuilder.Append("var achievement" + value.Item1 + "OffsetTop = document.getElementById(\"achievement-" + value.Item1 + "\").offsetTop;" +
                            "var achievement" + value.Item1 + "OffsetTopNew = achievement" + value.Item1 + "OffsetTop + 1048;");
                        newOffset = "`${ achievement" + value.Item1 + "OffsetTopNew }px`";
                        break;
                }

                stringBuilder.Append("setTimeout(function() { " +
                    "   $(\"#achievement-" + value.Item1 + "\").animate( { left: '5px', top: " + newOffset + " }, 500, 'easeInOutQuint'); }" +
                    "," + value.Item3 + ");");
            }

            ExecuteScript(stringBuilder.ToString());
        }

        protected async void ExecuteScript(string script)
        {
            if (chromiumWebBrowser != null)
            {
                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        public void SetupBrowser()
        {
            Controls.Remove(chromiumWebBrowser);

            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.LastFiveWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(700, 772),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    ClientSize = new Size(616, 725);
                    LastFiveController.Instance.SetAllSettings();
                });
            });

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}