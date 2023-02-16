using CefSharp;
using CefSharp.JavascriptBinding;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class AlertsWindow : DisplayForm
    {
        public AlertsWindow() : base()
        {
            Name = "RA Tracker - Alerts";
            Text = "RA Tracker - Alerts";
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            SetupBrowser();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            AlertsController.Instance.CanPlay = false;
            AlertsController.Instance.IsOpen = false;
        }
        public override async void AssignJavaScriptVariables()
        {
            await ExecuteScript(
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
        public async void StartAchievementAlert(Achievement achievement)
        {
            await ExecuteScript(
                "achievementTitle.innerHTML = \"" + achievement.Title.Replace("\"", "\\\"") + "\";" +
                "achievementDescription.innerHTML = \"" + achievement.Description.Replace("\"", "\\\"") + "\";" +
                "achievementPoints.innerHTML = \"" + achievement.Points + "\";" +
                "$(\"#achievement-badge\").attr(\"src\", \"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\");" +
                "document.getElementById(\"achievement-video\").currentTime = 0;" +
                "$(\"#achievement-video\").attr(\"src\", \"disk://achievement-notification\");" +
                "$(\"#achievement-video\").show();");

            await ExecuteScript(
                "textFit(achievementTitle, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                "textFit(achievementDescription, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                "textFit(achievementPoints, { reProcess: true });");
        }
        public async void StartMasteryAlert(GameInfo gameInfo)
        {
            await ExecuteScript(
                    "masteryTitle.innerHTML = \"" + gameInfo.Title.Replace("\"", "\\\"") + "\";" +
                    "masteryAchievements.innerHTML = \"Cheevos:<br/>" + gameInfo.Achievements.Count + "\";" +
                    "masteryPoints.innerHTML = \"Points:<br/>" + gameInfo.GamePointsPossible + "\";" +
                    "$(\"#mastery-badge\").attr('src', \"https://retroachievements.org" + gameInfo.ImageIcon + "\");" +
                    "document.getElementById(\"mastery-video\").currentTime = 0;" +
                    "$(\"#mastery-video\").attr('src', \"disk://mastery-notification\");" +
                    "$(\"#mastery-video\").show();");

            await ExecuteScript(
                    "textFit(masteryTitle, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                    "textFit(masteryPoints, { alignVert: true, alignHoriz: true, reProcess: true });" +
                    "textFit(masteryAchievements, { alignVert: true, alignHoriz: true, reProcess: true });");
        }

        public async void PromptUserInput()
        {
            await ExecuteScript("$(\"#user-prompt\").show();");
        }
        public void EnableBorder()
        {
            ExecutionScripts.Enqueue(
                "achievementElement.style.backgroundImage = \"url('disk://background')\"; " +
                "masteryElement.style.backgroundImage = \"url('disk://background')\";");
        }

        public void DisableBorder()
        {
            ExecutionScripts.Enqueue(
                "achievementElement.style.backgroundImage = \"\"; " +
                "masteryElement.style.backgroundImage = \"\";");
        }
        public async void EnableAchievementEdit()
        {
            await ExecuteScript(
                "achievementVideoElement.controls = true;");

            SetAchievementIn(0, AnimationDirection.STATIC);
        }

        public async void DisableAchievementEdit()
        {
            await ExecuteScript(
                 "achievementVideoElement.controls = false; " +
                "achievementVideoElement.style.border = \"\";  " +
                "$(\"#achievement-video\").hide();");

            SetAchievementOut(0, AnimationDirection.STATIC);
        }

        public async void EnableMasteryEdit()
        {
            await ExecuteScript(
                "masteryVideoElement.controls = true;");

            SetMasteryIn(0, AnimationDirection.STATIC);
        }

        public async void DisableMasteryEdit()
        {
            await ExecuteScript(
                "masteryVideoElement.controls = false; " +
                "masteryVideoElement.style.border = \"\"; " +
                "$(\"#mastery-video\").hide(); ");

            SetMasteryOut(0, AnimationDirection.STATIC);
        }

        public void SetAchievementLeft(int value)
        {
            ExecutionScripts.Enqueue("achievementVideoElement.style.left = \"" + value + "px\";");
        }

        public void SetAchievementTop(int value)
        {
            ExecutionScripts.Enqueue("achievementVideoElement.style.top = \"" + value + "px\";");
        }

        public void SetMasteryLeft(int value)
        {
            ExecutionScripts.Enqueue("masteryVideoElement.style.left = \"" + value + "px\";");
        }

        public void SetMasteryTop(int value)
        {
            ExecutionScripts.Enqueue("masteryVideoElement.style.top = \"" + value + "px\";");
        }

        public void SetAchievementWidth(int value)
        {
            ExecutionScripts.Enqueue("achievementVideoElement.style.width = \"" + value + "px\";");
        }

        public void SetMasteryWidth(int value)
        {
            ExecutionScripts.Enqueue("masteryVideoElement.style.width = \"" + value + "px\";");
        }

        public async void SetAchievementIn(int value, AnimationDirection animationDirection)
        {
            string animationScript;
            switch (animationDirection)
            {
                case AnimationDirection.UP:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '-310px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.DOWN:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '600px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.LEFT:
                    animationScript = "achievementElement.animate([ { left: '-300px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.RIGHT:
                    animationScript = "achievementElement.animate([ { left: '1034px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                default:
                    animationScript = "achievementElement.animate([ { left: '-300px', top: '-310px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: 10, fill: \"forwards\" });";
                    break;
            }

            await ExecuteScript(animationScript);
        }

        public async void SetAchievementOut(int value, AnimationDirection animationDirection)
        {
            string animationScript;
            switch (animationDirection)
            {
                case AnimationDirection.UP:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '-310px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.DOWN:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '600px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.LEFT:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '220px' }, { left: '-300px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.RIGHT:
                    animationScript = "achievementElement.animate([ { left: '165px', top: '220px' }, { left: '1034px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                default:
                    animationScript = "achievementElement.animate([ { left: '-300px', top: '-310px' }, { left: '-300px', top: '-310px' } ], { interations: 1, duration: 10, fill: \"forwards\" });";
                    break;
            }

            await ExecuteScript(animationScript);
        }

        public async void SetMasteryIn(int value, AnimationDirection animationDirection)
        {
            string animationScript;
            switch (animationDirection)
            {
                case AnimationDirection.UP:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '-310px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.DOWN:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '600px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.LEFT:
                    animationScript = "masteryElement.animate([ { left: '-300px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.RIGHT:
                    animationScript = "masteryElement.animate([ { left: '1034px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                default:
                    animationScript = "masteryElement.animate([ { left: '-300px', top: '-310px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: 10, fill: \"forwards\" });";
                    break;
            }

            await ExecuteScript(animationScript);
        }

        public async void SetMasteryOut(int value, AnimationDirection animationDirection)
        {
            string animationScript;
            switch (animationDirection)
            {
                case AnimationDirection.UP:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '-310px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.DOWN:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '600px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.LEFT:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '220px' }, { left: '-300px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                case AnimationDirection.RIGHT:
                    animationScript = "masteryElement.animate([ { left: '165px', top: '220px' }, { left: '1034px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\" });";
                    break;
                default:
                    animationScript = "masteryElement.animate([ { left: '-300px', top: '-310px' }, { left: '-300px', top: '-310px' } ], { interations: 1, duration: 0, fill: \"forwards\" });";
                    break;
            }

            await ExecuteScript(animationScript);
        }

        public async void HideNotifications()
        {
            await ExecuteScript(
                "$(\"#achievement-video\").hide();" +
                "$(\"#mastery-video\").hide();");

            await ExecuteScript(
                "achievementVideoElement.currentTime = 0;" +
                "masteryVideoElement.currentTime = 0;");
        }

        public void SetSimpleFontColor(string value)
        {
            ExecutionScripts.Enqueue(
                "achievementLine.style.color = \"" + value + "\";" +
                "masteryLine.style.color = \"" + value + "\";" +
                "achievementLine.style.backgroundColor = \"" + value + "\";" +
                "masteryLine.style.backgroundColor = \"" + value + "\";" +
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }");
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
                "achievementTitle.style.lineHeight = " + lineSpacing + ";" +
                "achievementTitle.style.fontFamily = \"" + fontFamily + "\";" +
                "masteryTitle.style.lineHeight = " + lineSpacing + ";" +
                "masteryTitle.style.fontFamily = \"" + fontFamily + "\";" +
                "achievementDescription.style.lineHeight = " + lineSpacing + ";" +
                "achievementDescription.style.fontFamily = \"" + fontFamily + "\";" +
                "masteryAchievements.style.lineHeight = " + lineSpacing + ";" +
                "masteryAchievements.style.fontFamily = \"" + fontFamily + "\";" +
                "masteryPoints.style.lineHeight = " + lineSpacing + ";" +
                "masteryPoints.style.fontFamily = \"" + fontFamily + "\";" +
                "achievementPoints.style.lineHeight = " + lineSpacing + ";" +
                "achievementPoints.style.fontFamily = \"" + fontFamily + "\";");

            ExecutionScripts.Enqueue(
                "setTimeout(function() { textFit(achievementDescription, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }, 100);" +
                "setTimeout(function() { textFit(masteryAchievements, { alignVert: true, alignHoriz: true, reProcess: true }); }, 200);" +
                "setTimeout(function() { textFit(masteryPoints, { alignVert: true, alignHoriz: true, reProcess: true }); }, 300);" +
                "setTimeout(function() { textFit(achievementTitle, { alignVert: true, alignHoriz: true, reProcess: true }); }, 400);" +
                "setTimeout(function() { textFit(masteryTitle, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }, 500);" +
                "setTimeout(function() { textFit(achievementPoints, { reProcess: true }); }, 600);");
        }

        public void SetSimpleFontOutline(string fontOutline, string borderOutline)
        {
            ExecutionScripts.Enqueue(
                "achievementLine.style.border = \"" + borderOutline + "\";" +
                "masteryLine.style.border = \"" + borderOutline + "\";" +
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; }");
        }
        public void SetBorderBackgroundColor(string value)
        {
            ExecutionScripts.Enqueue(
                "achievementElement.style.backgroundColor = \"" + value + "\";" +
                "masteryElement.style.backgroundColor = \"" + value + "\";");
        }

        public void SetDescriptionOutline(string value)
        {
            ExecutionScripts.Enqueue(
                "achievementDescription.style.webkitTextStroke = \"" + value + "\";" +
                "masteryAchievements.style.webkitTextStroke = \"" + value + "\";" +
                "masteryPoints.style.webkitTextStroke = \"" + value + "\";");
        }

        public void SetDescriptionColor(string value)
        {
            ExecutionScripts.Enqueue(
                "achievementDescription.style.color = \"" + value + "\";" +
                "masteryAchievements.style.color = \"" + value + "\";" +
                "masteryPoints.style.color = \"" + value + "\";");
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
                 "achievementDescription.style.lineHeight = " + lineSpacing + ";" +
                 "achievementDescription.style.fontFamily = \"" + fontFamily + "\";" +
                 "masteryAchievements.style.lineHeight = " + lineSpacing + ";" +
                 "masteryAchievements.style.fontFamily = \"" + fontFamily + "\";" +
                 "masteryPoints.style.lineHeight = " + lineSpacing + ";" +
                 "masteryPoints.style.fontFamily = \"" + fontFamily + "\";");

            ExecutionScripts.Enqueue(
                "textFit(achievementDescription, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                 "textFit(masteryAchievements, { alignVert: true, alignHoriz: true, reProcess: true });" +
                 "textFit(masteryPoints, { alignVert: true, alignHoriz: true, reProcess: true });");
        }

        public void SetTitleOutline(string value)
        {
            ExecutionScripts.Enqueue(
                 "achievementTitle.style.webkitTextStroke = \"" + value + "\";" +
                 "masteryTitle.style.webkitTextStroke = \"" + value + "\";");
        }

        public void SetTitleColor(string value)
        {
            ExecutionScripts.Enqueue(
                "achievementTitle.style.color = \"" + value + "\";" +
                "masteryTitle.style.color = \"" + value + "\";");
        }

        public void SetTitleFontFamily(FontFamily value)
        {

            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            if (lineSpacing == 0)
            {
                lineSpacing = 1;
            }

            string fontFamily = value.Name.Replace(":", "\\:");

            ExecutionScripts.Enqueue(
                "achievementTitle.style.lineHeight = " + lineSpacing + ";" +
                "achievementTitle.style.fontFamily = \"" + fontFamily + "\";" +
                "masteryTitle.style.lineHeight = " + lineSpacing + ";" +
                "masteryTitle.style.fontFamily = \"" + fontFamily + "\";");

            ExecutionScripts.Enqueue(
                "textFit(achievementTitle, { alignVert: true, alignHoriz: true, reProcess: true });" +
                "textFit(masteryTitle, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });");
        }
        public void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecutionScripts.Enqueue(
                  "achievementPoints.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "achievementPoints.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(achievementPoints);");
        }
        public void SetPointsColor(string value)
        {
            ExecutionScripts.Enqueue(
                 "achievementPoints.style.color = \"" + value + "\";" +
                 "masteryAchievements.style.color = \"" + value + "\";" +
                 "masteryPoints.style.color = \"" + value + "\";");
        }
        public void SetPointsOutline(string fontOutline)
        {
            ExecutionScripts.Enqueue(
                "achievementPoints.style.webkitTextStroke = \"" + fontOutline + "\";" +
                "masteryAchievements.style.webkitTextStroke = \"" + fontOutline + "\";" +
                "masteryPoints.style.webkitTextStroke = \"" + fontOutline + "\";");
        }
        public void SetLineColor(string value)
        {
            ExecutionScripts.Enqueue(
                 "achievementLine.style.color = \"" + value + "\";" +
                 "achievementLine.style.backgroundColor = \"" + value + "\";" +
                 "masteryLine.style.color = \"" + value + "\";" +
                 "masteryLine.style.backgroundColor = \"" + value + "\";");
        }

        public void SetLineOutline(string borderOutline)
        {
            ExecutionScripts.Enqueue(
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
        public void SetClientSize()
        {
            Invoke(new Action(() => {
                ClientSize = new Size(1024, 768);
            }));
        }
        public override void SetupBrowser()
        {
            Controls.Remove(chromiumWebBrowser);

            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser()
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "alertsBrowser",
                Size = new Size(1024, 768),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.LoadingStateChanged += new EventHandler<LoadingStateChangedEventArgs>((sender, loadingStateChangedEventArgs) =>
            {
                if (!loadingStateChangedEventArgs.IsLoading)
                {

                    AlertsController.Instance.IsOpen = true;
                    AlertsController.Instance.SetAllSettings();
                }
            });

            chromiumWebBrowser.LoadHtml(Resources.alerts_window);

            chromiumWebBrowser.JavascriptObjectRepository.ResolveObject += (sender1, e) =>
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
    }
}
