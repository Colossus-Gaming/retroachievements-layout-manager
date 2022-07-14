using CefSharp;
using CefSharp.JavascriptBinding;
using CefSharp.Web;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class AlertsWindow : Form
    {
        private TaskController TaskController;
        public AlertsWindow()
        {
            ClientSize = new Size(0, 0);

            Name = "RA Tracker - Alerts";
            Text = "RA Tracker - Alerts";

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));

            Shown += AlertsWindow_Shown;
            FormClosed += AlertsWindow_FormClosed;

            TaskController = new TaskController();

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
        public async void AssignJavaScriptVariables()
        {
            await TaskController.Enqueue(() => ExecuteScript(
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
                "masteryVideoElement = document.getElementById(\"mastery-video\");"));
        }
        public async void StartAchievementAlert(Achievement achievement)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementTitle.innerHTML = \"" + achievement.Title.Replace("\"", "\\\"") + "\";" +
                "achievementDescription.innerHTML = \"" + achievement.Description.Replace("\"", "\\\"") + "\";" +
                "achievementPoints.innerHTML = \"" + achievement.Points + "\";" +
                "$(\"#achievement-badge\").attr(\"src\", \"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\");" +
                "document.getElementById(\"achievement-video\").currentTime = 0;" +
                "$(\"#achievement-video\").attr(\"src\", \"disk://achievement-notification\");" +
                "$(\"#achievement-video\").show();"));

            await TaskController.Enqueue(() => ExecuteScript(
                "textFit(achievementTitle, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                "textFit(achievementDescription, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                "textFit(achievementPoints, { reProcess: true });"));
        }
        public async void StartMasteryAlert(GameInfo gameInfo)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                    "masteryTitle.innerHTML = \"" + gameInfo.Title.Replace("\"", "\\\"") + "\";" +
                    "masteryAchievements.innerHTML = \"Cheevos:<br/>" + gameInfo.Achievements.Count + "\";" +
                    "masteryPoints.innerHTML = \"Points:<br/>" + gameInfo.GamePointsPossible + "\";" +
                    "$(\"#mastery-badge\").attr('src', \"https://retroachievements.org" + gameInfo.ImageIcon + "\");" +
                    "document.getElementById(\"mastery-video\").currentTime = 0;" +
                    "$(\"#mastery-video\").attr('src', \"disk://mastery-notification\");" +
                    "$(\"#mastery-video\").show();"));

            await TaskController.Enqueue(() => ExecuteScript(
                    "textFit(masteryTitle, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                    "textFit(masteryPoints, { alignVert: true, alignHoriz: true, reProcess: true });" +
                    "textFit(masteryAchievements, { alignVert: true, alignHoriz: true, reProcess: true });"));
        }

        public async void PromptUserInput()
        {
            await TaskController.Enqueue(() => ExecuteScript("$(\"#user-prompt\").show();"));
        }
        public async void EnableBorder()
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementElement.style.backgroundImage = \"url('disk://background')\"; " +
                "masteryElement.style.backgroundImage = \"url('disk://background')\";"));
        }

        public async void DisableBorder()
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementElement.style.backgroundImage = \"\"; " +
                "masteryElement.style.backgroundImage = \"\";"));
        }
        public async void EnableAchievementEdit()
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementVideoElement.controls = true;"));

            SetAchievementIn(0, AnimationDirection.STATIC);
        }

        public async void DisableAchievementEdit()
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementVideoElement.controls = false; " +
                "achievementVideoElement.style.border = \"\";  " +
                "$(\"#achievement-video\").hide();"));

            SetAchievementOut(0, AnimationDirection.STATIC);
        }

        public async void EnableMasteryEdit()
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "masteryVideoElement.controls = true;"));

            SetMasteryIn(0, AnimationDirection.STATIC);
        }

        public async void DisableMasteryEdit()
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "masteryVideoElement.controls = false; " +
                "masteryVideoElement.style.border = \"\"; " +
                "$(\"#mastery-video\").hide(); "));

            SetMasteryOut(0, AnimationDirection.STATIC);
        }

        public async void SetAchievementLeft(int value)
        {
            await TaskController.Enqueue(() => ExecuteScript("achievementVideoElement.style.left = \"" + value + "px\";"));
        }

        public async void SetAchievementTop(int value)
        {
            await TaskController.Enqueue(() => ExecuteScript("achievementVideoElement.style.top = \"" + value + "px\";"));
        }

        public async void SetMasteryLeft(int value)
        {
            await TaskController.Enqueue(() => ExecuteScript("masteryVideoElement.style.left = \"" + value + "px\";"));
        }

        public async void SetMasteryTop(int value)
        {
            await TaskController.Enqueue(() => ExecuteScript("masteryVideoElement.style.top = \"" + value + "px\";"));
        }

        public async void SetAchievementWidth(int value)
        {
            await TaskController.Enqueue(() => ExecuteScript("achievementVideoElement.style.width = \"" + value + "px\";"));
        }

        public async void SetMasteryWidth(int value)
        {
            await TaskController.Enqueue(() => ExecuteScript("masteryVideoElement.style.width = \"" + value + "px\";"));
        }

        public async void SetAchievementIn(int value, AnimationDirection animationDirection)
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
                    animationScript = "achievementElement.animate([ { left: '-300px', top: '-310px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: 10, fill: \"forwards\", easing: \"ease-out\" });";
                    break;
            }

            await TaskController.Enqueue(() => ExecuteScript(animationScript));
        }

        public async void SetAchievementOut(int value, AnimationDirection animationDirection)
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
                    animationScript = "achievementElement.animate([ { left: '-300px', top: '-310px' }, { left: '-300px', top: '-310px' } ], { interations: 1, duration: 10, fill: \"forwards\", easing: \"ease-out\" });";
                    break;
            }

            await TaskController.Enqueue(() => ExecuteScript(animationScript));
        }

        public async void SetMasteryIn(int value, AnimationDirection animationDirection)
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
                    animationScript = "masteryElement.animate([ { left: '-300px', top: '-310px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: 10, fill: \"forwards\", easing: \"ease-out\" });";
                    break;
            }

            await TaskController.Enqueue(() => ExecuteScript(animationScript));
        }

        public async void SetMasteryOut(int value, AnimationDirection animationDirection)
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
                    animationScript = "masteryElement.animate([ { left: '-300px', top: '-310px' }, { left: '-300px', top: '-310px' } ], { interations: 1, duration: 0, fill: \"forwards\", easing: \"ease-out\" });";
                    break;
            }

            await TaskController.Enqueue(() => ExecuteScript(animationScript));
        }

        public async void HideNotifications()
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "$(\"#achievement-video\").hide();" +
                "$(\"#mastery-video\").hide();"));

            await TaskController.Enqueue(() => ExecuteScript(
                "achievementVideoElement.currentTime = 0;" +
                "masteryVideoElement.currentTime = 0;"));
        }

        public async void SetSimpleFontColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementLine.style.color = \"" + value + "\";" +
                "masteryLine.style.color = \"" + value + "\";" +
                "achievementLine.style.backgroundColor = \"" + value + "\";" +
                "masteryLine.style.backgroundColor = \"" + value + "\";" +
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }"));
        }

        public async void SetSimpleFontFamily(FontFamily value)
        {

            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            if (lineSpacing == 0)
            {
                lineSpacing = 1;
            }

            string fontFamily = value.Name.Replace(":", "\\:");

            await TaskController.Enqueue(() => ExecuteScript(
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
                "achievementPoints.style.fontFamily = \"" + fontFamily + "\";"));

            await TaskController.Enqueue(() => ExecuteScript(
                "setTimeout(function() { textFit(achievementDescription, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }, 100);" +
                "setTimeout(function() { textFit(masteryAchievements, { alignVert: true, alignHoriz: true, reProcess: true }); }, 200);" +
                "setTimeout(function() { textFit(masteryPoints, { alignVert: true, alignHoriz: true, reProcess: true }); }, 300);" +
                "setTimeout(function() { textFit(achievementTitle, { alignVert: true, alignHoriz: true, reProcess: true }); }, 400);" +
                "setTimeout(function() { textFit(masteryTitle, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true }); }, 500);" +
                "setTimeout(function() { textFit(achievementPoints, { reProcess: true }); }, 600);"));
        }

        public async void SetSimpleFontOutline(string fontOutline, string borderOutline)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementLine.style.border = \"" + borderOutline + "\";" +
                "masteryLine.style.border = \"" + borderOutline + "\";" +
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; }"));
        }
        public async void SetBorderBackgroundColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementElement.style.backgroundColor = \"" + value + "\";" +
                "masteryElement.style.backgroundColor = \"" + value + "\";"));
        }
        public async void SetWindowBackgroundColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";"));
        }

        public async void SetDescriptionOutline(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementDescription.style.webkitTextStroke = \"" + value + "\";" +
                "masteryAchievements.style.webkitTextStroke = \"" + value + "\";" +
                "masteryPoints.style.webkitTextStroke = \"" + value + "\";"));
        }

        public async void SetDescriptionColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementDescription.style.color = \"" + value + "\";" +
                "masteryAchievements.style.color = \"" + value + "\";" +
                "masteryPoints.style.color = \"" + value + "\";"));
        }

        public async void SetDescriptionFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            if (lineSpacing == 0)
            {
                lineSpacing = 1;
            }

            string fontFamily = value.Name.Replace(":", "\\:");

            await TaskController.Enqueue(() => ExecuteScript(
                 "achievementDescription.style.lineHeight = " + lineSpacing + ";" +
                 "achievementDescription.style.fontFamily = \"" + fontFamily + "\";" +
                 "masteryAchievements.style.lineHeight = " + lineSpacing + ";" +
                 "masteryAchievements.style.fontFamily = \"" + fontFamily + "\";" +
                 "masteryPoints.style.lineHeight = " + lineSpacing + ";" +
                 "masteryPoints.style.fontFamily = \"" + fontFamily + "\";"));

            await TaskController.Enqueue(() => ExecuteScript(
                "textFit(achievementDescription, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });" +
                 "textFit(masteryAchievements, { alignVert: true, alignHoriz: true, reProcess: true });" +
                 "textFit(masteryPoints, { alignVert: true, alignHoriz: true, reProcess: true });"));
        }

        public async void SetTitleOutline(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                 "achievementTitle.style.webkitTextStroke = \"" + value + "\";" +
                 "masteryTitle.style.webkitTextStroke = \"" + value + "\";"));
        }

        public async void SetTitleColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementTitle.style.color = \"" + value + "\";" +
                "masteryTitle.style.color = \"" + value + "\";"));
        }

        public async void SetTitleFontFamily(FontFamily value)
        {

            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            if (lineSpacing == 0)
            {
                lineSpacing = 1;
            }

            string fontFamily = value.Name.Replace(":", "\\:");

            await TaskController.Enqueue(() => ExecuteScript(
                "achievementTitle.style.lineHeight = " + lineSpacing + ";" +
                "achievementTitle.style.fontFamily = \"" + fontFamily + "\";" +
                "masteryTitle.style.lineHeight = " + lineSpacing + ";" +
                "masteryTitle.style.fontFamily = \"" + fontFamily + "\";"));

            await TaskController.Enqueue(() => ExecuteScript(
                "textFit(achievementTitle, { alignVert: true, alignHoriz: true, reProcess: true });" +
                "textFit(masteryTitle, { alignVert: true, alignHoriz: true, multiLine: true, reProcess: true });"));
        }
        public async void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await TaskController.Enqueue(() => ExecuteScript(
                  "achievementPoints.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "achievementPoints.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(achievementPoints);"));
        }
        public async void SetPointsColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                 "achievementPoints.style.color = \"" + value + "\";" +
                 "masteryAchievements.style.color = \"" + value + "\";" +
                 "masteryPoints.style.color = \"" + value + "\";"));
        }
        public async void SetPointsOutline(string fontOutline)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementPoints.style.webkitTextStroke = \"" + fontOutline + "\";" +
                "masteryAchievements.style.webkitTextStroke = \"" + fontOutline + "\";" +
                "masteryPoints.style.webkitTextStroke = \"" + fontOutline + "\";"));
        }
        public async void SetLineColor(string value)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                 "achievementLine.style.color = \"" + value + "\";" +
                 "achievementLine.style.backgroundColor = \"" + value + "\";" +
                 "masteryLine.style.color = \"" + value + "\";" +
                 "masteryLine.style.backgroundColor = \"" + value + "\";"));
        }

        public async void SetLineOutline(string borderOutline)
        {
            await TaskController.Enqueue(() => ExecuteScript(
                "achievementLine.style.border = \"" + borderOutline + "\";" +
                "masteryLine.style.border = \"" + borderOutline + "\";"));
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
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
