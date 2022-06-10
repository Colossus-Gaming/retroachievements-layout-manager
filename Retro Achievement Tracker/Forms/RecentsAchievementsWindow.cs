using CefSharp;
using CefSharp.Web;
using Newtonsoft.Json;
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
    public partial class RecentAchievementsWindow : Form
    {
        public RecentAchievementsWindow()
        {
            ClientSize = new Size(0, 0);

            Name = "RA Tracker - Recent Achievements";
            Text = "RA Tracker - Recent Achievements";

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            Shown += LastFiveWindow_Shown;
            FormClosed += LastFiveWindow_FormClosed;

            SetupBrowser();
        }

        private void LastFiveWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            RecentAchievementsController.Instance.IsOpen = false;
        }

        private void LastFiveWindow_Shown(object sender, EventArgs e)
        {
            RecentAchievementsController.Instance.IsOpen = true;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public void AssignJavaScriptVariables()
        {
            ExecuteScript(
                "container = document.getElementById(\"container\");" +
                "achievementList = document.getElementById(\"achievement-list\");" +
                "allElements = document.getElementsByClassName(\"has-font\");" +
                "allTitles = document.getElementsByClassName(\"title\");" +
                "allDates = document.getElementsByClassName(\"date\");" +
                "allLines = document.getElementsByClassName(\"line\");" +
                "allPoints = document.getElementsByClassName(\"points\");" +
                "allAchievements = document.getElementsByClassName(\"achievement\");");
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
                "   textFit(allTitles[i], { alignVert: true , alignHoriz: true, multiLine: true, reProcess: true });" +
                "}" +
                "for (var i = 0; i < allDates.length; i++) { " +
                "   textFit(allDates[i], { alignVert: true , alignHoriz: true, multiLine: true, reProcess: true });" +
                "}" +
                "for (var i = 0; i < allPoints.length; i++) { " +
                "   textFit(allPoints[i], { reProcess: true });" +
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
                "   textFit(allTitles[i], { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                "}");
        }
        public void SetDateFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allDates.length; i++) { " +
                "   allDates[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allDates[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allDates[i], { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                "}");
        }

        public void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allPoints.length; i++) { " +
                "   allPoints[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allPoints[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allPoints[i], { reProcess: true });" +
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
                 "for (var i = 0; i < allTitles.length; i++) { allTitles[i].style.webkitTextStroke = \"" + value + "\"; textFit(allTitles[i], { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }");
        }
        public void SetDateOutline(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allDates.length; i++) { allDates[i].style.webkitTextStroke = \"" + value + "\"; textFit(allDates[i], { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }");
        }
        public void SetPointsOutline(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allPoints.length; i++) { allPoints[i].style.webkitTextStroke = \"" + value + "\"; textFit(allPoints[i], { reProcess: true }); }");
        }
        public void SetLineOutline(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allLines.length; i++) { allLines[i].style.border = \"" + value + "\"; }");
        }
        public void StartScrolling(int timeout)
        {
            ExecuteScript("setTimeout(function() { startScrolling(); }, " + (timeout + 1000) + "); ");
        }
        public void AddAchievements(List<Achievement> achievements)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < achievements.Count; i++)
            {
                stringBuilder.Append("setTimeout(function() { addAchievement(" + JsonConvert.SerializeObject(achievements[i]) + "); }, 50 * " + (i + 1) + ");");
            }
            ExecuteScript(stringBuilder.ToString());
        }
        public void ShowRecentAchievements()
        {
            ExecuteScript("$(\"#achievement-list\").animate( { left: '0px', top: '0px' }, 500, 'easeInOutQuint');");
        }
        public void HideRecentAchievements()
        {
            ExecuteScript("stopScrolling();" + 
                "$(\"#achievement-list\").animate( { left: '535px', top: '0px' }, 200, 'easeInOutQuint');");
        }
        public void ClearRecentAchievements()
        {
            ExecuteScript("setTimeout(function() { document.getElementById(\"achievement-list\").innerHTML = \"\"; }, 210);");
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

            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.RecentAchievementsWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(516, 608),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    ClientSize = new Size(516, 600);
                    RecentAchievementsController.Instance.SetAllSettings();
                });
            });

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}