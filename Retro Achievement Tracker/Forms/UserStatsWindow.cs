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
    public partial class UserStatsWindow : Form
    {
        public UserStatsWindow()
        {
            ClientSize = new Size(0, 0);

            Name = "RA Tracker - User Stats";
            Text = "RA Tracker - User Stats";

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            Shown += UserStatsWindow_Shown;
            FormClosed += UserStatsWindow_FormClosed;

            SetupBrowser();
        }

        private void UserStatsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            UserStatsController.IsOpen = false;
        }

        private void UserStatsWindow_Shown(object sender, EventArgs e)
        {
            UserStatsController.IsOpen = true;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public void AssignJavaScriptVariables()
        {

            ExecuteScript(
                "container = document.getElementById(\"container\");" +
                "rankName = document.getElementById(\"rank-name\");" +
                "rankValue = document.getElementById(\"rank-value\");" +
                "ratioName = document.getElementById(\"ratio-name\");" +
                "ratioValue = document.getElementById(\"ratio-value\");" +
                "pointsName = document.getElementById(\"points-name\");" +
                "pointsValue = document.getElementById(\"points-value\");" +
                "truePointsName = document.getElementById(\"true-points-name\");" +
                "truePointsValue = document.getElementById(\"true-points-value\");" +
                "allElements = document.getElementsByClassName(\"has-font\");" +
                "allNames = document.getElementsByClassName(\"name\");" +
                "allValues = document.getElementsByClassName(\"value\");");
        }
        public void SetWindowBackgroundColor(string value)
        {
            ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
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
                "for (var i = 0; i < allNames.length; i++) { " +
                "   textFit(allNames[i], { alignVert: true, reProcess: true });" +
                "}");
            ExecuteScript(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   textFit(allValues[i], { alignVert: true, reProcess: true });" +
                "}");
        }
        public void SetSimpleFontColor(string value)
        {
            ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }");
        }

        public void SetSimpleFontOutline(string value)
        {
            ExecuteScript(
               "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + value + "\"; }");
        }

        public void SetNameFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allNames.length; i++) { " +
                "   allNames[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allNames[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allNames[i], { alignVert: true, reProcess: true });" +
                "}");
        }

        public void SetValueFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   allValues[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allValues[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allValues[i], { alignVert: true, reProcess: true });" +
                "}");
        }

        public void SetNameColor(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allNames.length; i++) { allNames[i].style.color = \"" + value + "\"; }");
        }

        public void SetValueColor(string value)
        {
            ExecuteScript(
                 "for (var i = 0; i < allValues.length; i++) { allValues[i].style.color = \"" + value + "\"; }");
        }

        public void SetNameOutline(string value)
        {
            ExecuteScript(
                  "for (var i = 0; i < allNames.length; i++) { allNames[i].style.webkitTextStroke = \"" + value + "\"; }");
        }

        public void SetValueOutline(string value)
        {
            ExecuteScript(
                  "for (var i = 0; i < allValues.length; i++) { allValues[i].style.webkitTextStroke = \"" + value + "\"; }");
        }
        public void SetRankName(string value)
        {
            ExecuteScript("rankName.innerHTML = \"" + value + ":\";" +
                "textFit(rankName, { alignVert: true, reProcess: true });");
        }
        public void SetRankValue(string value)
        {
            ExecuteScript("rankValue.innerHTML = \"" + value + "\";" +
                "textFit(rankValue, { alignVert: true, reProcess: true });");
        }
        public void SetRankVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#rank\").fadeIn();" : "$(\"#rank\").fadeOut();");
        }
        //Points
        public void SetPointsName(string value)
        {
            ExecuteScript("pointsName.innerHTML = \"" + value + ":\";" +
                "textFit(pointsName, { alignVert: true, reProcess: true });");
        }
        public void SetPointsValue(string value)
        {
            ExecuteScript("pointsValue.innerHTML = \"" + value + "\";" +
                "textFit(pointsValue, { alignVert: true, reProcess: true });");
        }
        public void SetPointsVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#points\").fadeIn();" : "$(\"#points\").fadeOut();");
        }
        //True Points
        public void SetTruePointsName(string value)
        {
            ExecuteScript("truePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(truePointsName, { alignVert: true, reProcess: true });");
        }
        public void SetTruePointsValue(string value)
        {
            ExecuteScript("truePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(truePointsValue, { alignVert: true, reProcess: true });");
        }
        public void SetTruePointsVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#true-points\").fadeIn();" : "$(\"#true-points\").fadeOut();");
        }
        //Ratio
        public void SetRatioName(string value)
        {
            ExecuteScript("ratioName.innerHTML = \"" + value + ":\";" +
                "textFit(ratioName, { alignVert: true, reProcess: true });");
        }
        public void SetRatioValue(string value)
        {
            ExecuteScript("ratioValue.innerHTML = \"" + value + "\";" +
                "textFit(ratioValue, { alignVert: true, reProcess: true });");
        }
        public void SetRatioVisibility(bool isVisible)
        {
            ExecuteScript(isVisible ? "$(\"#ratio\").fadeIn();" : "$(\"#ratio\").fadeOut();");
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
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.UserStatsWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(805, 300),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    ClientSize = new Size(805, 290);
                });

                UserStatsController.Instance.SetAllSettings();
            });

            chromiumWebBrowser.LoadHtml(Resources.UserStatsWindow);

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}