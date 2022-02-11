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
        }
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public async Task AssignJavaScriptVariables()
        {
            await ExecuteScript(
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
        public async Task StartAchievementAlert(Achievement achievement)
        {
            await ExecuteScript(
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

        public async Task StartMasteryAlert(UserSummary userSummary, GameInfoAndProgress gameInfo)
        {
            await ExecuteScript(
                "masteryTitle.innerHTML = \"" + gameInfo.Title.Replace("\"", "\\\"") + "\";" +
                "masteryAchievements.innerHTML = \"Cheevos: " + userSummary.AchievmentsPossible + "\";" +
                "masteryPoints.innerHTML = \"Points: " + userSummary.GamePointsPossible + "\";" +
                "$(\"#mastery-badge\").attr(\"src\", \"https:retroachievements.org" + gameInfo.ImageIcon + "\");" +
                "$(\"#mastery-video\").attr(\"src\", \"disk://mastery-notification\");" +
                "masteryVideoElement.style.display = \"block\";" +
                "masteryElement.style.display = \"block\";" +
                "textFit(masteryTitle, { alignVert: true, alignHoriz: true });" +
                "textFit(masteryPoints, { alignVert: true, alignHoriz: true });" +
                "textFit(masteryAchievements, { alignVert: true, alignHoriz: true });");
        }

        public async void PromptUserInput()
        {
            await ExecuteScript(
                "$(\"#user-prompt\").fadeIn();" +
                "document.getElementById(\"ready-message\").style.fontSize = \"42px\"; " +
                "document.getElementById(\"confirm-button\").style.fontSize = \"42px\";" +
                "textFit(document.getElementById(\"ready-message\"), { alignVert: true, alignHoriz: true });" +
                "textFit(document.getElementById(\"confirm-button\"), { alignVert: true, alignHoriz: true });");
        }
        public async Task EnableBorder()
        {
            await ExecuteScript(
                "achievementElement.style.backgroundImage = \"url('disk://background')\"; " +
                "masteryElement.style.backgroundImage = \"url('disk://background')\";");
        }

        public async Task DisableBorder()
        {
            await ExecuteScript(
                "achievementElement.style.backgroundImage = \"\"; " +
                "masteryElement.style.backgroundImage = \"\";");
        }
        public async Task EnableAchievementEdit()
        {
            await ExecuteScript(
                "achievementVideoElement.controls = true;");
            await SetAchievementIn(0, AnimationDirection.STATIC);
        }

        public async Task DisableAchievementEdit()
        {
            await ExecuteScript(
                "achievementVideoElement.controls = false; " +
                "achievementVideoElement.style.border = \"\";  " +
                "$(\"#achievement-video\").fadeOut();");
            await SetAchievementOut(0, AnimationDirection.STATIC);
        }

        public async Task EnableMasteryEdit()
        {
            await ExecuteScript(
                "masteryVideoElement.controls = true;");
            await SetMasteryIn(0, AnimationDirection.STATIC);
        }

        public async Task DisableMasteryEdit()
        {
            await ExecuteScript(
                "masteryVideoElement.controls = false; " +
                "masteryVideoElement.style.border = \"\"; " +
                "$(\"#mastery-video\").fadeOut(); ");
            await SetMasteryOut(0, AnimationDirection.STATIC);
        }

        public async void SetAchievementLeft(int value)
        {
            await ExecuteScript("achievementVideoElement.style.left = \"" + value + "px\";");
        }

        public async void SetAchievementTop(int value)
        {
            await ExecuteScript("achievementVideoElement.style.top = \"" + value + "px\";");
        }

        public async void SetMasteryLeft(int value)
        {
            await ExecuteScript("masteryVideoElement.style.left = \"" + value + "px\";");
        }

        public async void SetMasteryTop(int value)
        {
            await ExecuteScript("masteryVideoElement.style.top = \"" + value + "px\";");
        }

        public async void SetAchievementWidth(int value)
        {
            await ExecuteScript("achievementVideoElement.style.width = \"" + value + "px\";");
        }

        public async void SetMasteryWidth(int value)
        {
            await ExecuteScript("masteryVideoElement.style.width = \"" + value + "px\";");
        }

        public async Task SetAchievementIn(int value, AnimationDirection animationDirection)
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

            await ExecuteScript(animationScript);
        }

        public async Task SetAchievementOut(int value, AnimationDirection animationDirection)
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

            await ExecuteScript(animationScript);
        }

        public async Task SetMasteryIn(int value, AnimationDirection animationDirection)
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

            await ExecuteScript(animationScript);
        }

        public async Task SetMasteryOut(int value, AnimationDirection animationDirection)
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

            await ExecuteScript(animationScript);
        }

        public async Task HideNotifications()
        {
            await ExecuteScript(
                "achievementElement.style.display = \"none\";" +
                "masteryElement.style.display = \"none\";" +
                "achievementVideoElement.style.display = \"none\";" +
                "masteryVideoElement.style.display = \"none\";");
        }

        public async Task SetSimpleFontColor(string value)
        {
            await ExecuteScript(
                "achievementLine.style.color = \"" + value + "\";" +
                "masteryLine.style.color = \"" + value + "\";" +
                "achievementLine.style.backgroundColor = \"" + value + "\";" +
                "masteryLine.style.backgroundColor = \"" + value + "\";" +
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }" +
                "document.getElementById(\"ready-message\").style.color = \"#0000ff\";" +
                "document.getElementById(\"confirm-button\").style.color = \"#0000ff\";");
        }

        public async Task SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { " +
                "   allElements[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allElements[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allElements[i], { alignVert: true, alignHoriz: true });" +
                "}");
        }

        public async Task SetSimpleFontOutline(string fontOutline, string borderOutline)
        {
            await ExecuteScript(
                "achievementLine.style.border = \"" + borderOutline + "\";" +
                "masteryLine.style.border = \"" + borderOutline + "\";" +
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; }");
        }
        public async Task SetBorderBackgroundColor(string value)
        {
            await ExecuteScript(
                "achievementElement.style.backgroundColor = \"" + value + "\";" +
                "masteryElement.style.backgroundColor = \"" + value + "\";");
        }
        public async Task SetWindowBackgroundColor(string value)
        {
            await ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }

        public async Task SetDescriptionOutline(string value)
        {
            await ExecuteScript(
                "achievementDescription.style.webkitTextStroke = \"" + value + "\";" +
                "masteryAchievements.style.webkitTextStroke = \"" + value + "\";" +
                "masteryPoints.style.webkitTextStroke = \"" + value + "\";");
        }

        public async Task SetDescriptionColor(string value)
        {
            await ExecuteScript(
                "achievementDescription.style.color = \"" + value + "\";" +
                "masteryAchievements.style.color = \"" + value + "\";" +
                "masteryPoints.style.color = \"" + value + "\";");
        }

        public async Task SetDescriptionFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
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

        public async Task SetTitleOutline(string value)
        {
            await ExecuteScript(
                 "achievementTitle.style.webkitTextStroke = \"" + value + "\";" +
                 "masteryTitle.style.webkitTextStroke = \"" + value + "\";");
        }

        public async Task SetTitleColor(string value)
        {
            await ExecuteScript(
                "achievementTitle.style.color = \"" + value + "\";" +
                "masteryTitle.style.color = \"" + value + "\";");
        }

        public async Task SetTitleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
                  "achievementTitle.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "achievementTitle.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(achievementTitle, { alignVert: true, alignHoriz: true });" +
                  "masteryTitle.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "masteryTitle.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(masteryTitle, { alignVert: true, alignHoriz: true });");
        }
        public async Task SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
                  "achievementPoints.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "achievementPoints.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(achievementPoints, { alignVert: true, alignHoriz: true });");
        }
        public async Task SetPointsColor(string value)
        {
            await ExecuteScript(
                 "achievementPoints.style.color = \"" + value + "\";" +
                 "masteryAchievements.style.color = \"" + value + "\";" +
                 "masteryPoints.style.color = \"" + value + "\";");
        }
        public async Task SetPointsOutline(string fontOutline)
        {
            await ExecuteScript(
                "achievementPoints.style.webkitTextStroke = \"" + fontOutline + "\";" +
                "masteryAchievements.style.webkitTextStroke = \"" + fontOutline + "\";" +
                "masteryPoints.style.webkitTextStroke = \"" + fontOutline + "\";");
        }
        public async Task SetLineColor(string value)
        {
            await ExecuteScript(
                 "achievementLine.style.color = \"" + value + "\";" +
                 "achievementLine.style.backgroundColor = \"" + value + "\";" +
                 "masteryLine.style.color = \"" + value + "\";" +
                 "masteryLine.style.backgroundColor = \"" + value + "\";");
        }

        public async Task SetLineOutline(string borderOutline)
        {
            await ExecuteScript(
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
        protected async Task ExecuteScript(string script)
        {
            if (chromiumWebBrowser != null)
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
