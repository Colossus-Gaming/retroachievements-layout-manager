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
    public partial class NotificationLayoutWindow : Form
    {
        private bool isReady = false;

        public NotificationLayoutWindow()
        {
            this.ClientSize = new Size(0, 0);

            this.Name = "RA Tracker - Notifications";
            this.Text = "RA Tracker - Notifications";

            this.Location = new Point(0, 0);
            this.Show();
        }

        public async void StartAchievementNotification(Achievement achievement)
        {
            await ExecuteScript(
                "$(\"#achievement-name\").text(\"" + achievement.Title.Replace("\"", "\\\"") + "\");" +
                "$(\"#achievement-description\").text(\"" + achievement.Description.Replace("\"", "\\\"") + "\");" +
                "$(\"#achievement-points\").text(\"" + achievement.Points + "\");" +
                "$(\"#achievement-badge\").attr(\"src\", \"https:retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\");" +
                "$(\"#achievement-video\").attr(\"src\", \"disk://achievement-notification\");" +
                "achievementVideoElement.style.display = \"block\";" +
                "achievementElement.style.display = \"block\";" +
                 "for (var i = 0; i < allAchievements.length; i++) { applyFont(allAchievements[i]); }");
        }

        public async void StartMasteryNotification(GameSummary gameSummary, GameAchievementSummary gameAchievementSummary)
        {
            await ExecuteScript(
                "$(\"#mastery-name\").text(\"" + gameSummary.Title.Replace("\"", "\\\"") + "\");" +
                "$(\"#mastery-achievements\").text(\"Cheevos: " + gameAchievementSummary.NumPossibleAchievements + "\");" +
                "$(\"#mastery-points\").text(\"Points: " + gameAchievementSummary.PossibleScore + "\");" +
                "$(\"#mastery-badge\").attr(\"src\", \"https:retroachievements.org" + gameSummary.ImageIcon + "\");" +
                "$(\"#mastery-video\").attr(\"src\", \"disk://mastery-notification\");" +
                "masteryVideoElement.style.display = \"block\";" +
                "masteryElement.style.display = \"block\";" +
                "for (var i = 0; i < allMastery.length; i++) { applyFont(allMastery[i]); }");
        }

        public async void PromptUserInput()
        {
            await ExecuteScript(
                "$(\"#user-prompt\").fadeIn();" +
                "document.getElementById(\"ready-message\").style.fontSize = \"42px\";" +
                "document.getElementById(\"confirm-button\").style.fontSize = \"42px\";");
        }
        public async void AssignJavaScriptVariables()
        {
            await ExecuteScript(
                "allElements = document.getElementsByClassName(\"has-font\");" +
                "allAchievements = document.getElementsByClassName(\"achievement\");" +
                "allMastery = document.getElementsByClassName(\"mastery\");" +
                "achievementElement = document.getElementById(\"achievement\");" +
                "masteryElement = document.getElementById(\"mastery\");" +
                "achievementLine = document.getElementById(\"achievement-line\");" +
                "masteryLine = document.getElementById(\"mastery-line\");" +
                "achievementVideoElement = document.getElementById(\"achievement-video\");" +
                "masteryVideoElement = document.getElementById(\"mastery-video\");");
        }

        public async void EnableBorder()
        {
            await ExecuteScript(
                "achievementElement.style.backgroundImage = \"url('disk://background')\"; " +
                "masteryElement.style.backgroundImage = \"url('disk://background')\";");
        }

        public async void DisableBorder()
        {
            await ExecuteScript(
                "achievementElement.style.backgroundImage = \"\"; " +
                "masteryElement.style.backgroundImage = \"\";");
        }

        public async void ShowPoints()
        {
            await ExecuteScript("$(\"#achievement-points\").fadeIn();");
        }

        public async void HidePoints()
        {
            await ExecuteScript("$(\"#achievement-points\").fadeOut();");
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
                "$(\"#achievement-video\").fadeOut();");
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
                "$(\"#mastery-video\").fadeOut(); ");
            SetMasteryOut(0, AnimationDirection.STATIC);
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
                    animationScript = "achievementElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
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
                    animationScript = "masteryElement.animate([ { left: '165px', top: '220px' }, { left: '165px', top: '220px' } ], { interations: 1, duration: " + value + ", fill: \"forwards\", easing: \"ease-out\" });";
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

        public async void HideNotifications()
        {
            await ExecuteScript(
                "achievementElement.style.display = \"none\";" +
                "masteryElement.style.display = \"none\";" +
                "achievementVideoElement.style.display = \"none\";" +
                "masteryVideoElement.style.display = \"none\";");
        }

        public async void SetFontColor(string value)
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

        public async void SetFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
                "fontValue = \"36px \\\"" + value.Name.Replace(":", "\\:") + "\\\"\";" +
                "lineSpacing = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "for (var i = 0; i < allElements.length; i++) { applyFont(allElements[i]); }");
        }

        public async void SetFontOutline(string fontOutline, string borderOutline)
        {
            await ExecuteScript(
                "achievementLine.style.border = \"" + borderOutline + "\";" +
                "masteryLine.style.border = \"" + borderOutline + "\";" +
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; adjustFont(allElements[i]); }");
        }
        public async void SetBackgroundColor(string value)
        {
            await ExecuteScript(
                "achievementElement.style.backgroundColor = \"" + value + "\";" +
                "masteryElement.style.backgroundColor = \"" + value + "\";");
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
            if (this.Visible && this.isReady)
            {
                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script);
                }
                catch (Exception)
                {
                }
            }
        }

        public void SetupBrowser()
        {
            this.Controls.Remove(chromiumWebBrowser);

            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.NotificationWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(1034, 778),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
                {
                    customAchievementEnabled = AlertController.Instance.CustomAchievementEnabled,
                    customMasteryEnabled = AlertController.Instance.CustomMasteryEnabled
                }
            };

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    this.ClientSize = new Size(1024, 768);
                    this.isReady = true;

                    AlertController.Instance.SetAllSettings();
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
                    repo.Register("alertControllerAsync", AlertController.Instance, isAsync: true, options: bindingOptions);
                }
            };

            this.Controls.Add(this.chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        public class NotificationRequest
        {
            public Achievement Achievement { get; set; }
            public GameSummary GameSummary { get; set; }
            public GameAchievementSummary GameAchievementSummary { get; set; }
        }

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationLayoutWindow));
            this.SuspendLayout();
            this.ClientSize = new Size(284, 261);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Notifications";
            this.ResumeLayout(false);
        }
    }
}
