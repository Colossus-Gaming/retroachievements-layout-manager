using CefSharp;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class RecentAchievementsWindow : DisplayForm
    {
        public RecentAchievementsWindow() : base()
        {
            Name = "RA Tracker - Recent Achievements";
            Text = "RA Tracker - Recent Achievements";
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            SetupBrowser();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            RecentAchievementsController.Instance.IsOpen = false;
        }

        public override async void AssignJavaScriptVariables()
        {
            await ExecuteScript(
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
            ExecutionScripts.Enqueue(
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

            ExecutionScripts.Enqueue(script);
        }

        public void SetSimpleFontOutline(string fontOutline, string borderOutline)
        {
            ExecutionScripts.Enqueue(
                 "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; }" +
                 "for (var i = 0; i < allLines.length; i++) { allLines[i].style.border = \"" + borderOutline + "\"; }");
        }

        public void SetBackgroundColor(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allAchievements.length; i++) { allAchievements[i].style.backgroundColor = \"" + value + "\"; }");
        }
        public void EnableBorder()
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allAchievements.length; i++) { allAchievements[i].style.backgroundImage = \"url('disk://background')\"; }");
        }
        public void DisableBorder()
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allAchievements.length; i++) { allAchievements[i].style.backgroundImage = \"\"; }");
        }
        public void SetTitleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allTitles.length; i++) { " +
                "   allTitles[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allTitles[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allTitles[i], { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                "}");
        }
        public void SetDateFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allDates.length; i++) { " +
                "   allDates[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allDates[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allDates[i], { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                "}");
        }

        public void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allPoints.length; i++) { " +
                "   allPoints[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allPoints[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allPoints[i], { reProcess: true });" +
                "}");
        }

        public void SetTitleColor(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allTitles.length; i++) { allTitles[i].style.color = \"" + value + "\"; }");
        }

        public void SetDateColor(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allDates.length; i++) { allDates[i].style.color = \"" + value + "\"; }");
        }

        public void SetPointsColor(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allPoints.length; i++) { allPoints[i].style.color = \"" + value + "\"; }");
        }
        public void SetLineColor(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allLines.length; i++) { allLines[i].style.color = \"" + value + "\"; allLines[i].style.backgroundColor = \"" + value + "\"; }");
        }
        public void SetTitleOutline(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allTitles.length; i++) { allTitles[i].style.webkitTextStroke = \"" + value + "\"; textFit(allTitles[i], { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }");
        }
        public void SetDateOutline(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allDates.length; i++) { allDates[i].style.webkitTextStroke = \"" + value + "\"; textFit(allDates[i], { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }");
        }
        public void SetPointsOutline(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allPoints.length; i++) { allPoints[i].style.webkitTextStroke = \"" + value + "\"; textFit(allPoints[i], { reProcess: true }); }");
        }
        public void SetLineOutline(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allLines.length; i++) { allLines[i].style.border = \"" + value + "\"; }");
        }
        public void StartScrolling()
        {
            ExecutionScripts.Enqueue("startScrolling();");
        }
        public void StopScrolling()
        {
            ExecutionScripts.Enqueue("stopScrolling();");
        }
        public void AddAchievements(List<Achievement> achievements)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < achievements.Count; i++)
            {
                stringBuilder.Append(
                    "var achievementBlock = document.createElement('div');" +
                    "achievementBlock.classList.add(\"achievement\");" +
                    "achievementBlock.id = \"achievement-" + achievements[i].Id + "\";" +
                    "if (achievementList.childNodes.length > 0) { achievementList.insertBefore(achievementBlock, achievementList.childNodes[0]); } else { achievementList.appendChild(achievementBlock); }" +

                    "var achievementImage = document.createElement('img');" +
                    "achievementImage.id = \"achievement-" + achievements[i].Id + "-image\";" +
                    "achievementImage.classList.add(\"badge\");" +
                    "achievementImage.src = \"http://media.retroachievements.org/Badge/" + achievements[i].BadgeNumber + ".png\";" +
                    "achievementImage.style.border = \"2px solid gold\";" +
                    "achievementBlock.appendChild(achievementImage);" +

                    "var achievementTitleBlock = document.createElement('div');" +
                    "achievementTitleBlock.innerHTML = \"" + achievements[i].Title + "\";" +
                    "achievementTitleBlock.classList.add(\"title\");" +
                    "achievementTitleBlock.classList.add(\"has-font\");" +
                    "achievementTitleBlock.style.zIndex = 1;" +
                    "achievementBlock.appendChild(achievementTitleBlock);" +

                    "var achievementLineBlock = document.createElement('hr');" +
                    "achievementLineBlock.classList.add(\"line\");" +
                    "achievementBlock.appendChild(achievementLineBlock);" +

                    "var achievementDateBlock = document.createElement('div');" +
                    "achievementDateBlock.innerHTML = \"" + (achievements[i].DateEarned.HasValue ? achievements[i].DateEarned.Value.ToString() : "") + "\";" +
                    "achievementDateBlock.classList.add(\"date\");" +
                    "achievementDateBlock.classList.add(\"has-font\");" +
                    "achievementBlock.appendChild(achievementDateBlock);" +

                    "var achievementPointsBlock = document.createElement('div');" +
                    "achievementPointsBlock.innerHTML = \"" + achievements[i].Points + "\";" +
                    "achievementPointsBlock.classList.add(\"points\");" +
                    "achievementPointsBlock.classList.add(\"has-font\");" +
                    "achievementBlock.appendChild(achievementPointsBlock);");
            }

            ExecutionScripts.Enqueue(stringBuilder.ToString());
        }
        public void ShowRecentAchievements()
        {
            ExecutionScripts.Enqueue("$(\"#achievement-list\").animate( { left: '0px', top: '0px' }, 500, 'easeInOutQuint');");
        }
        public void HideRecentAchievements()
        {
            ExecutionScripts.Enqueue("stopScrolling(); $(\"#achievement-list\").animate( { left: '535px', top: '0px' }, 500, 'easeInOutQuint');");
        }
        public void ClearRecentAchievements()
        {
            ExecutionScripts.Enqueue("document.getElementById(\"achievement-list\").innerHTML = \"\";");
        }
        public void SetClientSize()
        {
            Invoke(new Action(() => {
                ClientSize = new Size(516, 600);
            }));
        }
        public override void SetupBrowser()
        {
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser()
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(516, 608),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.LoadingStateChanged += new EventHandler<LoadingStateChangedEventArgs>((sender, loadingStateChangedEventArgs) =>
            {
                if (!loadingStateChangedEventArgs.IsLoading)
                {
                    RecentAchievementsController.Instance.IsOpen = true;

                    RecentAchievementsController.Instance.SetAchievements();
                }
            });

            chromiumWebBrowser.LoadHtml(Resources.recent_achievements_window);

            Controls.Add(chromiumWebBrowser);
        }
    }
}