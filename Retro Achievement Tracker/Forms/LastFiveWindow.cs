using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
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

            Shown += LastFiveWindow_Shown;
            FormClosed += LastFiveWindow_FormClosed;

            SetupBrowser();
        }

        private void LastFiveWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastFiveController.IsOpen = false;
        }

        private void LastFiveWindow_Shown(object sender, EventArgs e)
        {
            LastFiveController.IsOpen = true;
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
            ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { " +
                "   allElements[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allElements[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "}");
            ExecuteScript(
                "for (var i = 0; i < allTitles.length; i++) { " +
                "   textFit(allTitles[i], { alignVert: true , alignHoriz: true });" +
                "}");
            ExecuteScript(
                "for (var i = 0; i < allDates.length; i++) { " +
                "   textFit(allDates[i], { alignVert: true , alignHoriz: true });" +
                "}");
            ExecuteScript(
                "for (var i = 0; i < allPoints.length; i++) { " +
                "   textFit(allPoints[i], { alignVert: true });" +
                "}");
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
                "   textFit(allTitles[i], { alignVert: true, alignHoriz: true });" +
                "}");
        }
        public void SetDateFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allDates.length; i++) { " +
                "   allDates[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allDates[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allDates[i], { alignVert: true, alignHoriz: true });" +
                "}");
        }

        public void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allPoints.length; i++) { " +
                "   allPoints[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allPoints[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allPoints[i], { alignVert: true });" +
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
                 "for (var i = 0; i < allTitles.length; i++) { allTitles[i].style.webkitTextStroke = \"" + value + "\"; textFit(allTitles[i], { alignVert: true, alignHoriz: true }); }");
        }
        public void SetDateOutline(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allDates.length; i++) { allDates[i].style.webkitTextStroke = \"" + value + "\"; textFit(allDates[i], { alignVert: true, alignHoriz: true }); }");
        }
        public void SetPointsOutline(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allPoints.length; i++) { allPoints[i].style.webkitTextStroke = \"" + value + "\"; textFit(allPoints[i], { alignVert: true, alignHoriz: true }); }");
        }
        public void SetLineOutline(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allLines.length; i++) { allLines[i].style.border = \"" + value + "\"; }");
        }
        public void CleanupList()
        {
            ExecuteScript("allAchievements = document.getElementsByClassName(\"focus-achievement\");" +
                "while (allAchievements.length > 5) { allAchievements[allAchievements.length - 1].remove(); allAchievements = document.getElementsByClassName(\"focus-achievement\"); }");
        }
        public void ClearList()
        {
            ExecuteScript("allAchievements = document.getElementsByClassName(\"focus-achievement\");" +
                "while (allAchievements.length > 0) { allAchievements[allAchievements.length - 1].remove(); allAchievements = document.getElementsByClassName(\"focus-achievement\"); }");
        }

        public void AddAchievement(Achievement achievement)
        {
            ExecuteScript("addToList(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                                       "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\"," +
                                       "\"" + achievement.Description.Replace("\"", "\\\"") + "\"," +
                                       "\"" + achievement.Points + "\"," +
                                       "\"" + achievement.DateEarned.ToString() + "\", " +
                                       "\"" + achievement.Id + "\");");

        }
        public async Task<int> GetAchievementPosition(int id)
        {
            try
            {
                JavascriptResponse javascriptResponse = await chromiumWebBrowser.EvaluateScriptAsync("document.getElementById(\"achievement-" + id + "\").offsetTop", TimeSpan.FromSeconds(5));

                return int.Parse(javascriptResponse.Result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return 800;
        }

        public async void SetAchievementPosition(int id, int position)
        {
            int newOffset;
            switch (position)
            {
                case 0:
                    newOffset = 5;
                    break;
                case 1:
                    newOffset = 150;
                    break;
                case 2:
                    newOffset = 295;
                    break;
                case 3:
                    newOffset = 440;
                    break;
                case 4:
                    newOffset = 585;
                    break;
                default:
                    newOffset = 800;
                    break;
            }

            await GetAchievementPosition(id).ContinueWith((result) =>
            {
                ExecuteScript("document.getElementById(\"achievement-" + id + "\")" +
                ".animate([ { left: '5px', top: '" + result.Result + "px' }, { left: '5px', top: '" + newOffset + "px' } ], { interations: 1, duration: 200, fill: \"forwards\", easing: \"ease-out\" });");
            });
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