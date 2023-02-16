using CefSharp;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class FocusWindow : DisplayForm
    {
        public FocusWindow() : base()
        {
            Name = "RA Tracker - Focus";
            Text = "RA Tracker - Focus";
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            SetupBrowser();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            FocusController.Instance.IsOpen = false;
        }

        public override async void AssignJavaScriptVariables()
        {
            await ExecuteScript(
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

            ExecutionScripts.Enqueue(
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
            ExecutionScripts.Enqueue(
                 "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; }" +
                 "lineElement.style.border = \"" + borderOutline + "\";");
        }

        public void SetSimpleFontColor(string value)
        {
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }" +
                "lineElement.style.color = \"" + value + "\";" +
                "lineElement.style.backgroundColor = \"" + value + "\";");
        }

        public void SetBorderBackgroundColor(string value)
        {
            ExecutionScripts.Enqueue(
                "focus.style.backgroundColor = \"" + value + "\";");
        }
        public void SetDescriptionOutline(string value)
        {
            ExecutionScripts.Enqueue(
                  "descriptionElement.style.webkitTextStroke = \"" + value + "\";" +
                  "masteryAchievementsElement.style.webkitTextStroke = \"" + value + "\";" +
                  "masteryPointsElement.style.webkitTextStroke = \"" + value + "\";" +

                  "textFit(descriptionElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                  "textFit(masteryAchievementsElement, { alignVert: true, alignHoriz: true, reProcess: true });" +
                  "textFit(masteryPointsElement, { alignVert: true, alignHoriz: true, reProcess: true });");
        }

        public void SetDescriptionColor(string value)
        {
            ExecutionScripts.Enqueue(
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

            ExecutionScripts.Enqueue(
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
            ExecutionScripts.Enqueue("titleElement.style.webkitTextStroke = \"" + value + "\";");
        }

        public void SetTitleColor(string value)
        {
            ExecutionScripts.Enqueue("titleElement.style.color = \"" + value + "\";");
        }

        public void SetTitleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecutionScripts.Enqueue(
                  "titleElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "titleElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +

                  "textFit(titleElement, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });");
        }

        public async void SetFocus(Achievement achievement)
        {
            if (achievement != null)
            {
                ExecutionScripts.Enqueue(
                    "$(\"#badge\").fadeOut(\"fast\");" +
                    "$(\"#title\").fadeOut(\"fast\");" +
                    "$(\"#description\").fadeOut(\"fast\");" +
                    "$(\"#points\").fadeOut(\"fast\");" +
                    "$(\"#line\").fadeOut(\"fast\");" +
                    "$(\"#mastery-description\").fadeOut(\"fast\");");

                await Task.Delay(200).ContinueWith(async task =>
                {
                    ExecutionScripts.Enqueue(
                        "titleElement.innerHTML = \"" + achievement.Title.Replace("\"", "\\\"") + "\";" +
                        "descriptionElement.innerHTML = \"" + achievement.Description.Replace("\"", "\\\"") + "\";" +
                        "$(\"#badge\").attr('src', \"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\"); badgeElement.style.border = \"\";" +
                        "pointsElement.innerHTML = \"" + achievement.Points + "\";");

                    await Task.Delay(200).ContinueWith(task1 =>
                    {
                        ExecutionScripts.Enqueue(
                            "$(\"#focus\").fadeIn();" +
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
            ExecutionScripts.Enqueue(
                "$(\"#badge\").fadeOut(\"fast\");" +
                    "$(\"#title\").fadeOut(\"fast\");" +
                    "$(\"#description\").fadeOut(\"fast\");" +
                    "$(\"#points\").fadeOut(\"fast\");" +
                    "$(\"#line\").fadeOut(\"fast\");" +
                    "$(\"#mastery-description\").fadeOut(\"fast\");");

            await Task.Delay(200).ContinueWith(async task =>
            {
                ExecutionScripts.Enqueue(
                    "titleElement.innerHTML = \"" + gameInfo.Title.Replace("\"", "\\\"") + "\";" +
                    "masteryAchievementsElement.innerHTML = \"Cheevos:<br/>" + gameInfo.Achievements.Count + " / " + gameInfo.Achievements.Count + "\";" +
                    "masteryPointsElement.innerHTML = \"Points:<br/>" + gameInfo.GamePointsEarned + " / " + gameInfo.GamePointsPossible + "\";" +
                    "$(\"#badge\").attr('src', \"https://retroachievements.org" + gameInfo.ImageIcon + "\");" +
                    "badgeElement.style.border = \"4px solid gold\";");

                await Task.Delay(200).ContinueWith(task1 =>
                {
                    ExecutionScripts.Enqueue(
                        "$(\"#focus\").fadeIn();" +
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
            ExecutionScripts.Enqueue(
                  "pointsElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "pointsElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(pointsElement, { reProcess: true });");
        }

        public void HideFocus()
        {
            ExecutionScripts.Enqueue("$(\"#focus\").fadeOut();");
        }
        public void EnableBorder()
        {
            ExecutionScripts.Enqueue("focus.style.backgroundImage = \"url('disk://background')\";");
        }
        public void DisableBorder()
        {
            ExecutionScripts.Enqueue("focus.style.backgroundImage = \"\";");
        }
        public void SetPointsColor(string value)
        {
            ExecutionScripts.Enqueue("pointsElement.style.color = \"" + value + "\";");
        }
        public void SetPointsOutline(string fontOutline)
        {
            ExecutionScripts.Enqueue("pointsElement.style.webkitTextStroke = \"" + fontOutline + "\";");
        }
        public void SetLineColor(string value)
        {
            ExecutionScripts.Enqueue(
                "lineElement.style.color = \"" + value + "\";" +
                 "lineElement.style.backgroundColor = \"" + value + "\";");
        }

        public void SetLineOutline(string borderOutline)
        {
            ExecutionScripts.Enqueue("lineElement.style.border = \"" + borderOutline + "\";");
        }
        public void SetClientSize()
        {
            Invoke(new Action(() => {
                ClientSize = new Size(700, 165);
            }));
        }
        public override void SetupBrowser()
        {
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser()
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "focusBrowser",
                Size = new Size(700, 165),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.LoadingStateChanged += new EventHandler<LoadingStateChangedEventArgs>((sender, loadingStateChangedEventArgs) =>
            {
                if (!loadingStateChangedEventArgs.IsLoading)
                {
                    FocusController.Instance.IsOpen = true;

                    FocusController.Instance.UpdateFocus();
                }
            });

            chromiumWebBrowser.LoadHtml(Resources.focus_window);

            Controls.Add(chromiumWebBrowser);
        }
    }
}