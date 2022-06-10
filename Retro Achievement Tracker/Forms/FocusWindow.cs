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
    public partial class FocusWindow : Form
    {
        public FocusWindow()
        {
            ClientSize = new Size(0, 0);

            Name = "RA Tracker - Focus";
            Text = "RA Tracker - Focus";
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));

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
            if (lineSpacing == 0)
            {
                lineSpacing = 1;
            }

            string fontFamily = value.Name.Replace(":", "\\:");

            ExecuteScript(
                  "titleElement.style.lineHeight = " + lineSpacing + ";" +
                  "titleElement.style.fontFamily = \"" + fontFamily + "\";" +

                  "descriptionElement.style.lineHeight = " + lineSpacing + ";" +
                  "descriptionElement.style.fontFamily = \"" + fontFamily + "\";" +

                  "masteryAchievementsElement.style.lineHeight = " + lineSpacing + ";" +
                  "masteryAchievementsElement.style.fontFamily = \"" + fontFamily + "\";" +

                  "masteryPointsElement.style.lineHeight = " + lineSpacing + ";" +
                  "masteryPointsElement.style.fontFamily = \"" + fontFamily + "\";" +

                  "pointsElement.style.lineHeight = " + lineSpacing + ";" +
                  "pointsElement.style.fontFamily = \"" + fontFamily + "\";" +

                  "setTimeout(function() { textFit(titleElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }, 100);" +
                  "setTimeout(function() { textFit(descriptionElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }, 200);" +
                  "setTimeout(function() { textFit(masteryAchievementsElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }, 300);" +
                  "setTimeout(function() { textFit(masteryPointsElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }, 400);" +
                  "setTimeout(function() { textFit(pointsElement); }, 500);");
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

                  "textFit(descriptionElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                  "textFit(masteryAchievementsElement, { alignVert: true, alignHoriz: true, reProcess: true });" +
                  "textFit(masteryPointsElement, { alignVert: true, alignHoriz: true, reProcess: true });");
        }

        public void SetDescriptionColor(string value)
        {
            ExecuteScript(
                "descriptionElement.style.color = \"" + value + "\";" +
                "masteryAchievementsElement.style.color = \"" + value + "\";" +
                "masteryPointsElement.style.color = \"" + value + "\";");
        }

        public void SetDescriptionFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            if (lineSpacing == 0)
            {
                lineSpacing = 1;
            }

            string fontFamily = value.Name.Replace(":", "\\:");

            ExecuteScript(
                  "masteryAchievementsElement.style.lineHeight = " + lineSpacing + ";" +
                  "masteryAchievementsElement.style.fontFamily = \"" + fontFamily + "\";" +

                  "masteryPointsElement.style.lineHeight = " + lineSpacing + ";" +
                  "masteryPointsElement.style.fontFamily = \"" + fontFamily + "\";" +

                  "descriptionElement.style.lineHeight = " + lineSpacing + ";" +
                  "descriptionElement.style.fontFamily = \"" + fontFamily + "\";" +

                  "textFit(descriptionElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                  "textFit(masteryAchievementsElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                  "textFit(masteryPointsElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });");
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

                  "textFit(titleElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });");
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
                    ExecuteScript("titleElement.innerHTML = \"" + achievement.Title.Replace("\"", "\\\"") + "\";" +
                        "descriptionElement.innerHTML = \"" + achievement.Description.Replace("\"", "\\\"") + "\";" +
                        "$(\"#badge\").attr('src', \"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\"); badgeElement.style.border = \"\";" +
                        "pointsElement.innerHTML = \"" + achievement.Points + "\";");

                    await Task.Delay(200).ContinueWith(task1 =>
                    {
                        ExecuteScript("$(\"#focus\").fadeIn();" +
                            "$(\"#badge\").fadeIn();" +
                            "badgeElement.animate([ { left: '1940px', top: '14px' }, { left: '15px', top: '14px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" });" +
                            "setTimeout(function() { $(\"#points\").fadeIn(); textFit(pointsElement, { reProcess: true }); pointsElement.style.textAlign = \"left\"; pointsElement.style.alignContent = \"end\"; pointsElement.animate([ { left: '1922px', bottom: '10px' }, { left: '20px', bottom: '10px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 200);" +
                            "setTimeout(function() { $(\"#title\").fadeIn(); textFit(titleElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); titleElement.animate([ { right: '-800px', top: '10px' }, { right: '5px', top: '10px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 400);" +
                            "setTimeout(function() { $(\"#line\").fadeIn(); lineElement.animate([ { right: '-800px', top: '65px' }, { right: '10px', top: '65px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 600);" +
                            "setTimeout(function() { $(\"#description\").fadeIn(); textFit(descriptionElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); descriptionElement.animate([ { right: '-800px', bottom: '10px' }, { right: '5px', bottom: '10px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 800);");
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
                ExecuteScript("titleElement.innerHTML = \"" + gameInfo.Title.Replace("\"", "\\\"") + "\";" +
                    "masteryAchievementsElement.innerHTML = \"Cheevos:<br/>" + gameInfo.Achievements.Count + " / " + gameInfo.Achievements.Count + "\";" +
                    "masteryPointsElement.innerHTML = \"Points:<br/>" + gameInfo.GamePointsEarned + " / " + gameInfo.GamePointsPossible + "\";" +
                    "$(\"#badge\").attr('src', \"https://retroachievements.org" + gameInfo.ImageIcon + "\");" +
                    "badgeElement.style.border = \"4px solid gold\";");

                await Task.Delay(200).ContinueWith(task1 =>
                {
                    ExecuteScript("$(\"#focus\").fadeIn();" +
                        "$(\"#badge\").fadeIn();" +
                        "badgeElement.animate([ { left: '1940px', top: '10px' }, { left: '10px', top: '10px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" });" +
                        "setTimeout(function() { $(\"#title\").fadeIn(); textFit(titleElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); titleElement.animate([ { right: '-1922px', top: '5px' }, { right: '5px', top: '5px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 200);" +
                        "setTimeout(function() { $(\"#line\").fadeIn(); lineElement.animate([ { right: '-1922px', top: '65px' }, { right: '10px', top: '65px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 400);" +
                        "setTimeout(function() { $(\"#mastery-description\").fadeIn(); textFit(masteryAchievementsElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); textFit(masteryPointsElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); masteryDescriptionElement.animate([ { right: '-1922px', bottom: '10px' }, { right: '5px', bottom: '10px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 600);");
                });
            });
        }
        public void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                  "pointsElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "pointsElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(pointsElement, { reProcess: true });");
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