using CefSharp;
using CefSharp.JavascriptBinding;
using CefSharp.Web;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class AlertsWindow : Form
    {
        public AlertsWindow()
        {
            ClientSize = new Size(0, 0);

            Name = "RA Tracker - Alerts";
            Text = "RA Tracker - Alerts";

            Shown += AlertsWindow_Shown;
            FormClosed += AlertsWindow_FormClosed; ;

            SetupBrowser();
        }

        private void AlertsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            AlertsController.IsOpen = false;
        }

        private void AlertsWindow_Shown(object sender, EventArgs e)
        {
            AlertsController.IsOpen = true;
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
                "allAchievements = document.getElementsByClassName(\"achievement\");" +
                "allMastery = document.getElementsByClassName(\"mastery\");" +
                "achievementElement = document.getElementById(\"achievement\");" +
                "achievementTitle = document.getElementById(\"achievement-title\");" +
                "achievementDescription = document.getElementById(\"achievement-description\");" +
                "achievementPoints = document.getElementById(\"achievement-points\");" +
                "masteryElement = document.getElementById(\"mastery\");" +
                "masteryTitle = document.getElementById(\"mastery-title\");" +
                "masteryAchievements = document.getElementById(\"mastery-achievements\");" +
                "masteryPoints = document.getElementById(\"mastery-points\");" +
                "achievementLine = document.getElementById(\"achievement-line\");" +
                "masteryLine = document.getElementById(\"mastery-line\");" +
                "achievementVideoElement = document.getElementById(\"achievement-video\");" +
                "masteryVideoElement = document.getElementById(\"mastery-video\");");
        }
        public void StartAchievementAlert(Achievement achievement)
        {
            ExecuteScript(
                "achievementTitle.innerHTML = \"" + achievement.Title.Replace("\"", "\\\"") + "\";" +
                "achievementDescription.innerHTML = \"" + BreakString(achievement.Description.Length, achievement.Description.Split(new string[] { " " }, StringSplitOptions.None)).Replace("\"", "\\\"") + "\";" +
                "achievementPoints.innerHTML = \"" + achievement.Points + "\";" +
                "$(\"#achievement-badge\").attr(\"src\", \"https:retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\");" +
                "$(\"#achievement-video\").attr(\"src\", \"disk://achievement-notification\");" +
                "achievementVideoElement.style.display = \"block\";" +
                "achievementElement.style.display = \"block\";" +
                "textFit(achievementTitle, { alignVert: true, alignHoriz: true });" +
                "textFit(achievementDescription, { alignVert: true, alignHoriz: true });" +
                "textFit(achievementPoints);");
        }

        public void StartMasteryAlert(UserSummary userSummary, GameInfoAndProgress gameInfoAndProgress)
        {
            ExecuteScript(
                "masteryTitle.innerHTML = \"" + gameInfoAndProgress.Title.Replace("\"", "\\\"") + "\";" +
                "masteryAchievements.innerHTML = \"Cheevos: " + gameInfoAndProgress.Achievements.Count + "\";" +
                "masteryPoints.innerHTML = \"Points: " + gameInfoAndProgress.GamePointsPossible + "\";" +
                "$(\"#mastery-badge\").attr(\"src\", \"https:retroachievements.org" + gameInfoAndProgress.ImageIcon + "\");" +
                "$(\"#mastery-video\").attr(\"src\", \"disk://mastery-notification\");" +
                "masteryVideoElement.style.display = \"block\";" +
                "masteryElement.style.display = \"block\";" +
                "textFit(masteryTitle, { alignVert: true, alignHoriz: true });" +
                "textFit(masteryPoints, { alignVert: true, alignHoriz: true });" +
                "textFit(masteryAchievements, { alignVert: true, alignHoriz: true });");
        }

        public void PromptUserInput()
        {
            ExecuteScript(
                "$(\"#user-prompt\").fadeIn();" +
                "document.getElementById(\"ready-message\").style.fontSize = \"42px\"; " +
                "document.getElementById(\"confirm-button\").style.fontSize = \"42px\";" +
                "textFit(document.getElementById(\"ready-message\"), { alignVert: true, alignHoriz: true });" +
                "textFit(document.getElementById(\"confirm-button\"), { alignVert: true, alignHoriz: true });");
        }
        public void EnableBorder()
        {
            ExecuteScript(
                "achievementElement.style.backgroundImage = \"url('disk://background')\"; " +
                "masteryElement.style.backgroundImage = \"url('disk://background')\";");
        }

        public void DisableBorder()
        {
            ExecuteScript(
                "achievementElement.style.backgroundImage = \"\"; " +
                "masteryElement.style.backgroundImage = \"\";");
        }
        public void EnableAchievementEdit()
        {
            ExecuteScript(
                "achievementVideoElement.controls = true;");
            SetAchievementIn(0, AnimationDirection.STATIC);
        }

        public void DisableAchievementEdit()
        {
            ExecuteScript(
                "achievementVideoElement.controls = false; " +
                "achievementVideoElement.style.border = \"\";  " +
                "$(\"#achievement-video\").fadeOut();");
            SetAchievementOut(0, AnimationDirection.STATIC);
        }

        public void EnableMasteryEdit()
        {
            ExecuteScript(
                "masteryVideoElement.controls = true;");
            SetMasteryIn(0, AnimationDirection.STATIC);
        }

        public void DisableMasteryEdit()
        {
            ExecuteScript(
                "masteryVideoElement.controls = false; " +
                "masteryVideoElement.style.border = \"\"; " +
                "$(\"#mastery-video\").fadeOut(); ");
            SetMasteryOut(0, AnimationDirection.STATIC);
        }

        public void SetAchievementLeft(int value)
        {
            ExecuteScript("achievementVideoElement.style.left = \"" + value + "px\";");
        }

        public void SetAchievementTop(int value)
        {
            ExecuteScript("achievementVideoElement.style.top = \"" + value + "px\";");
        }

        public void SetMasteryLeft(int value)
        {
            ExecuteScript("masteryVideoElement.style.left = \"" + value + "px\";");
        }

        public void SetMasteryTop(int value)
        {
            ExecuteScript("masteryVideoElement.style.top = \"" + value + "px\";");
        }

        public void SetAchievementWidth(int value)
        {
            ExecuteScript("achievementVideoElement.style.width = \"" + value + "px\";");
        }

        public void SetMasteryWidth(int value)
        {
            ExecuteScript("masteryVideoElement.style.width = \"" + value + "px\";");
        }

        public void SetAchievementIn(int value, AnimationDirection animationDirection)
        {
            string animationScript;
            switch (animationDirection)
            {
                case AnimationDirection.UP:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '-310px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.DOWN:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '600px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.LEFT:
                    animationScript = "achievementElement.animate([ { left: '-300px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.RIGHT:
                    animationScript = "achievementElement.animate([ { left: '1034px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                default:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
            }

            ExecuteScript(animationScript);
        }

        public void SetAchievementOut(int value, AnimationDirection animationDirection)
        {
            string animationScript;
            switch (animationDirection)
            {
                case AnimationDirection.UP:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '-310px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.DOWN:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '600px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.LEFT:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '220px' }, { left: '-300px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.RIGHT:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '220px' }, { left: '1034px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                default:
                    animationScript = "achievementElement.style.display = \"none\";";
                    break;
            }

            ExecuteScript(animationScript);
        }

        public void SetMasteryIn(int value, AnimationDirection animationDirection)
        {
            string animationScript;
            switch (animationDirection)
            {
                case AnimationDirection.UP:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '-310px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.DOWN:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '600px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.LEFT:
                    animationScript = "masteryElement.animate([ { left: '-300px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.RIGHT:
                    animationScript = "masteryElement.animate([ { left: '1034px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                default:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
            }

            ExecuteScript(animationScript);
        }

        public void SetMasteryOut(int value, AnimationDirection animationDirection)
        {
            string animationScript;
            switch (animationDirection)
            {
                case AnimationDirection.UP:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '-310px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.DOWN:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '600px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.LEFT:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '220px' }, { left: '-300px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                case AnimationDirection.RIGHT:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '220px' }, { left: '1034px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
                    break;
                default:
                    animationScript = "masteryElement.style.display = \"none\";";
                    break;
            }

            ExecuteScript(animationScript);
        }

        public void HideNotifications()
        {
            ExecuteScript(
                "achievementElement.style.display = \"none\";" +
                "masteryElement.style.display = \"none\";" +
                "achievementVideoElement.style.display = \"none\";" +
                "masteryVideoElement.style.display = \"none\";");
        }

        public void SetSimpleFontColor(string value)
        {
            ExecuteScript(
                "achievementLine.style.color = \"" + value + "\";" +
                "masteryLine.style.color = \"" + value + "\";" +
                "achievementLine.style.backgroundColor = \"" + value + "\";" +
                "masteryLine.style.backgroundColor = \"" + value + "\";" +
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }" +
                "document.getElementById(\"ready-message\").style.color = \"#0000ff\";" +
                "document.getElementById(\"confirm-button\").style.color = \"#0000ff\";");
        }

        public void SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { " +
                "   allElements[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allElements[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allElements[i], { alignVert: true, alignHoriz: true });" +
                "}");
        }

        public void SetSimpleFontOutline(string fontOutline, string borderOutline)
        {
            ExecuteScript(
                "achievementLine.style.border = \"" + borderOutline + "\";" +
                "masteryLine.style.border = \"" + borderOutline + "\";" +
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; }");
        }
        public void SetBorderBackgroundColor(string value)
        {
            ExecuteScript(
                "achievementElement.style.backgroundColor = \"" + value + "\";" +
                "masteryElement.style.backgroundColor = \"" + value + "\";");
        }
        public void SetWindowBackgroundColor(string value)
        {
            ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }

        public void SetDescriptionOutline(string value)
        {
            ExecuteScript(
                "achievementDescription.style.webkitTextStroke = \"" + value + "\";" +
                "masteryAchievements.style.webkitTextStroke = \"" + value + "\";" +
                "masteryPoints.style.webkitTextStroke = \"" + value + "\";");
        }

        public void SetDescriptionColor(string value)
        {
            ExecuteScript(
                "achievementDescription.style.color = \"" + value + "\";" +
                "masteryAchievements.style.color = \"" + value + "\";" +
                "masteryPoints.style.color = \"" + value + "\";");
        }

        public void SetDescriptionFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                 "achievementDescription.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                 "achievementDescription.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                 "textFit(achievementDescription, { alignVert: true, alignHoriz: true });" +
                 "masteryAchievements.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                 "masteryAchievements.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                 "textFit(masteryAchievements, { alignVert: true, alignHoriz: true });" +
                 "masteryPoints.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                 "masteryPoints.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                 "textFit(masteryPoints, { alignVert: true, alignHoriz: true });");
        }

        public void SetTitleOutline(string value)
        {
            ExecuteScript(
                 "achievementTitle.style.webkitTextStroke = \"" + value + "\";" +
                 "masteryTitle.style.webkitTextStroke = \"" + value + "\";");
        }

        public void SetTitleColor(string value)
        {
            ExecuteScript(
                "achievementTitle.style.color = \"" + value + "\";" +
                "masteryTitle.style.color = \"" + value + "\";");
        }

        public void SetTitleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                  "achievementTitle.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "achievementTitle.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(achievementTitle, { alignVert: true, alignHoriz: true });" +
                  "masteryTitle.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "masteryTitle.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(masteryTitle, { alignVert: true, alignHoriz: true });");
        }
        public void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                  "achievementPoints.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "achievementPoints.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(achievementPoints, { alignVert: true, alignHoriz: true });");
        }
        public void SetPointsColor(string value)
        {
            ExecuteScript(
                 "achievementPoints.style.color = \"" + value + "\";" +
                 "masteryAchievements.style.color = \"" + value + "\";" +
                 "masteryPoints.style.color = \"" + value + "\";");
        }
        public void SetPointsOutline(string fontOutline)
        {
            ExecuteScript(
                "achievementPoints.style.webkitTextStroke = \"" + fontOutline + "\";" +
                "masteryAchievements.style.webkitTextStroke = \"" + fontOutline + "\";" +
                "masteryPoints.style.webkitTextStroke = \"" + fontOutline + "\";");
        }
        public void SetLineColor(string value)
        {
            ExecuteScript(
                 "achievementLine.style.color = \"" + value + "\";" +
                 "achievementLine.style.backgroundColor = \"" + value + "\";" +
                 "masteryLine.style.color = \"" + value + "\";" +
                 "masteryLine.style.backgroundColor = \"" + value + "\";");
        }

        public void SetLineOutline(string borderOutline)
        {
            ExecuteScript(
                "achievementLine.style.border = \"" + borderOutline + "\";" +
                "masteryLine.style.border = \"" + borderOutline + "\";");
        }
        public async Task<float> GetAchievementPlayingTime()
        {
            JavascriptResponse javascriptResponse = await chromiumWebBrowser.EvaluateScriptAsync("achievementVideoElement.currentTime");
            return float.Parse(javascriptResponse.Result.ToString());
        }
        public async Task<float> GetMasteryPlayingTime()
        {
            JavascriptResponse javascriptResponse = await chromiumWebBrowser.EvaluateScriptAsync("masteryVideoElement.currentTime");
            return float.Parse(javascriptResponse.Result.ToString());
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
        private static StringBuilder BreakString(int originalLength, string[] originalLines)
        {
            int threshold = 48;

            if (originalLength > 48 && originalLength < 96)
            {
                threshold = originalLines.Length / 2;
            }
            else if (originalLength >= 96)
            {
                threshold = originalLines.Length / 3;
            }

            StringBuilder actualLine = new StringBuilder();
            StringBuilder tempLine = new StringBuilder();

            double actualWidth = 0;

            foreach (var item in originalLines)
            {
                tempLine.Append(item + " ");
                actualWidth++;

                if (actualWidth > threshold)
                {
                    tempLine.Append("<br>");
                    actualLine.Append(tempLine);
                    tempLine.Clear();

                    actualWidth = 0;
                }
            }

            if (tempLine.Length > 0)
            {
                actualLine.Append(tempLine);
            }

            return actualLine;
        }
        public void SetupBrowser()
        {
            Controls.Remove(chromiumWebBrowser);

            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.AlertsWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(1034, 778),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    ClientSize = new Size(1024, 768);

                    AlertsController.Instance.SetAllSettings();
                    PromptUserInput();
                });
            });

            chromiumWebBrowser.JavascriptObjectRepository.ResolveObject += (sender, e) =>
            {
                var repo = e.ObjectRepository;
                if (e.ObjectName == "alertControllerAsync")
                {
                    BindingOptions bindingOptions = null; //Binding options is an optional param, defaults to null
                    bindingOptions = BindingOptions.DefaultBinder; //Use the default binder to serialize values into complex objects
                    repo.NameConverter = new CamelCaseJavascriptNameConverter();
                    repo.Register("alertControllerAsync", AlertsController.Instance, isAsync: true, options: bindingOptions);
                }
            };

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
    }
}
