using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class FocusWindow : Form
    {
        public FocusWindow()
        {
            ClientSize = new Size(0, 0);

            Name = "RA Tracker - Focus";
            Text = "RA Tracker - Focus";

            Shown += FocusWindow_Shown;
            FormClosed += FocusWindow_FormClosed;

            SetupBrowser();
        }

        private void FocusWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            FocusController.Instance.IsOpen = false;
        }

        private void FocusWindow_Shown(object sender, EventArgs e)
        {
            FocusController.Instance.IsOpen = true;
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
                "focus = document.getElementById(\"focus\");" +
                "titleElement = document.getElementById(\"title\");" +
                "descriptionElement = document.getElementById(\"description\");" +
                "masteryDescriptionElement = document.getElementById(\"mastery-description\");" +
                "masteryAchievementsElement = document.getElementById(\"mastery-achievements\");" +
                "masteryPointsElement = document.getElementById(\"mastery-points\");" +
                "pointsElement = document.getElementById(\"points\");" +
                "badgeElement = document.getElementById(\"badge\");" +
                "lineElement = document.getElementById(\"line\");");
        }
        public void SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                  "titleElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "titleElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(titleElement, { alignVert: true, alignHoriz: true, multiLine: true });" +
                  "descriptionElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "descriptionElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(descriptionElement, { alignVert: true, alignHoriz: true, multiLine: true });" +
                  "pointsElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "pointsElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(pointsElement);" +
                  "masteryAchievementsElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "masteryAchievementsElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(masteryAchievementsElement);" +
                  "masteryPointsElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "masteryPointsElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(masteryPointsElement);");
        }

        public void SetSimpleFontOutline(string fontOutline, string borderOutline)
        {
            ExecuteScript(
                 "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; }" +
                 "lineElement.style.border = \"" + borderOutline + "\";");
        }

        public void SetSimpleFontColor(string value)
        {
            ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }" +
                "lineElement.style.color = \"" + value + "\";" +
                "lineElement.style.backgroundColor = \"" + value + "\";");
        }

        public void SetBorderBackgroundColor(string value)
        {
            ExecuteScript(
                "focus.style.backgroundColor = \"" + value + "\";");
        }
        public void SetWindowBackgroundColor(string value)
        {
            ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }

        public void SetDescriptionOutline(string value)
        {
            ExecuteScript(
                  "descriptionElement.style.webkitTextStroke = \"" + value + "\";" +
                  "masteryAchievementsElement.style.webkitTextStroke = \"" + value + "\";" +
                  "masteryPointsElement.style.webkitTextStroke = \"" + value + "\";" +
                  "textFit(descriptionElement, { alignVert: true, alignHoriz: true, multiLine: true });" +
                  "textFit(masteryAchievementsElement, { alignVert: true, alignHoriz: true });" +
                  "textFit(masteryPointsElement, { alignVert: true, alignHoriz: true });");
        }

        public void SetDescriptionColor(string value)
        {
            ExecuteScript(
                "descriptionElement.style.color = \"" + value + "\";" +
                "masteryAchievementsElement.style.color = \"" + value + "\";" +
                "masteryPointsElement.style.color = \"" + value + "\";");
        }

        public void SetDescriptionFontFamily(System.Drawing.FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                  "descriptionElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "descriptionElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "masteryAchievementsElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "masteryAchievementsElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "masteryPointsElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "masteryPointsElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(descriptionElement, { alignVert: true, alignHoriz: true, multiLine: true });" +
                  "textFit(masteryAchievementsElement, { alignVert: true, alignHoriz: true });" +
                  "textFit(masteryPointsElement, { alignVert: true, alignHoriz: true });");
        }

        public void SetTitleOutline(string value)
        {
            ExecuteScript(
                 "titleElement.style.webkitTextStroke = \"" + value + "\";");
        }

        public void SetTitleColor(string value)
        {
            ExecuteScript(
                "titleElement.style.color = \"" + value + "\";");
        }

        public void SetTitleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                  "titleElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "titleElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(titleElement, { alignVert: true, alignHoriz: true, multiLine: true });");
        }

        public async void SetFocus(Achievement achievement)
        {
            if (achievement != null)
            {
                ExecuteScript("$(\"#badge\").fadeOut(\"fast\");" +
                    "$(\"#title\").fadeOut(\"fast\");" +
                    "$(\"#description\").fadeOut(\"fast\");" +
                    "$(\"#points\").fadeOut(\"fast\");" +
                    "$(\"#line\").fadeOut(\"fast\");" +
                    "$(\"#mastery-description\").fadeOut(\"fast\");");

                await Task.Delay(200).ContinueWith(async task =>
                {
                    ExecuteScript("titleElement.innerHTML = \"" + achievement.Title.Replace("\"", "\\\"") + "\";");
                    ExecuteScript("descriptionElement.innerHTML = \"" + achievement.Description.Replace("\"", "\\\"") + "\";");
                    ExecuteScript("$(\"#badge\").attr('src', \"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\"); badgeElement.style.border = \"\";");
                    ExecuteScript("pointsElement.innerHTML = \"" + achievement.Points + "\";");

                    await Task.Delay(200).ContinueWith(task1 =>
                    {
                        ExecuteScript("$(\"#focus\").fadeIn();");
                        ExecuteScript("$(\"#badge\").fadeIn(); badgeElement.animate([ { left: '1940px', top: '14px' }, { left: '15px', top: '14px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" });");
                        ExecuteScript("setTimeout(function() { $(\"#points\").fadeIn(); textFit(pointsElement); pointsElement.animate([ { left: '1922px', bottom: '10px' }, { left: '25px', bottom: '10px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 200);");
                        ExecuteScript("setTimeout(function() { $(\"#title\").fadeIn(); textFit(titleElement, { alignVert: true, alignHoriz: true, multiLine: true }); titleElement.animate([ { right: '-800px', top: '10px' }, { right: '5px', top: '10px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 400);");
                        ExecuteScript("setTimeout(function() { $(\"#line\").fadeIn(); lineElement.animate([ { right: '-800px', top: '65px' }, { right: '10px', top: '65px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 600);");
                        ExecuteScript("setTimeout(function() { $(\"#description\").fadeIn(); textFit(descriptionElement, { alignVert: true, alignHoriz: true, multiLine: true }); descriptionElement.animate([ { right: '-800px', top: '78px' }, { right: '5px', top: '78px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 800);");
                    });
                });
            }
            else
            {
                HideFocus();
            }
        }
        public async void SetFocus(GameInfo gameInfo)
        {
            ExecuteScript("$(\"#badge\").fadeOut(\"fast\");" +
                    "$(\"#title\").fadeOut(\"fast\");" +
                    "$(\"#description\").fadeOut(\"fast\");" +
                    "$(\"#points\").fadeOut(\"fast\");" +
                    "$(\"#line\").fadeOut(\"fast\");" +
                    "$(\"#mastery-description\").fadeOut(\"fast\");");

            await Task.Delay(200).ContinueWith(async task =>
            {
                ExecuteScript("titleElement.innerHTML = \"" + gameInfo.Title.Replace("\"", "\\\"") + "\";");
                ExecuteScript("masteryAchievementsElement.innerHTML = \"Cheevos:<br/>" + gameInfo.Achievements.Count + " / " + gameInfo.Achievements.Count + "\";");
                ExecuteScript("masteryPointsElement.innerHTML = \"Points:<br/>" + gameInfo.GamePointsEarned + " / " + gameInfo.GamePointsPossible + "\";");
                ExecuteScript("$(\"#badge\").attr('src', \"https://retroachievements.org" + gameInfo.ImageIcon + "\"); badgeElement.style.border = \"4px solid gold\";");

                await Task.Delay(200).ContinueWith(task1 =>
                {
                    ExecuteScript("focusElement.style.display = \"inline-block\";");
                    ExecuteScript("$(\"#badge\").fadeIn(); badgeElement.animate([ { left: '1940px', top: '10px' }, { left: '10px', top: '10px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" });");
                    ExecuteScript("setTimeout(function() { $(\"#title\").fadeIn(); textFit(titleElement, { alignVert: true, alignHoriz: true, multiLine: true }); titleElement.animate([ { right: '-1922px', top: '5px' }, { right: '5px', top: '5px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 200);");
                    ExecuteScript("setTimeout(function() { $(\"#line\").fadeIn(); lineElement.animate([ { right: '-1922px', top: '65px' }, { right: '10px', top: '65px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 400);");
                    ExecuteScript("setTimeout(function() { $(\"#mastery-description\").fadeIn(); textFit(masteryAchievementsElement, { alignVert: true, alignHoriz: true, multiLine: true }); textFit(masteryPointsElement, { alignVert: true, alignHoriz: true, multiLine: true }); masteryDescriptionElement.animate([ { right: '-1922px', top: '78px' }, { right: '5px', top: '78px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 600);");
                });
            });
        }
        public void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                  "pointsElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "pointsElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(pointsElement, { alignVert: true, alignHoriz: true });");
        }

        public void HideFocus()
        {
            ExecuteScript("$(\"#focus\").fadeOut();");
        }
        public void EnableBorder()
        {
            ExecuteScript("focus.style.backgroundImage = \"url('disk://background')\";");
        }
        public void DisableBorder()
        {
            ExecuteScript("focus.style.backgroundImage = \"\";");
        }
        public void SetPointsColor(string value)
        {
            ExecuteScript(
                 "pointsElement.style.color = \"" + value + "\";");
        }
        public void SetPointsOutline(string fontOutline)
        {
            ExecuteScript(
                "pointsElement.style.webkitTextStroke = \"" + fontOutline + "\";");
        }
        public void SetLineColor(string value)
        {
            ExecuteScript(
                 "lineElement.style.color = \"" + value + "\";" +
                 "lineElement.style.backgroundColor = \"" + value + "\";");
        }

        public void SetLineOutline(string borderOutline)
        {
            ExecuteScript(
                "lineElement.style.border = \"" + borderOutline + "\";");
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
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.FocusWindow))
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
                    ClientSize = new Size(700, 165);

                    FocusController.Instance.SetAllSettings();
                    FocusController.Instance.UpdateFocus();
                });
            });
            chromiumWebBrowser.LoadHtml(Resources.FocusWindow);

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}