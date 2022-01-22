using CefSharp;
using CefSharp.JavascriptBinding;
using CefSharp.Web;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class LastFiveLayoutWindow : Form
    {
        private bool isReady = false;

        public LastFiveLayoutWindow()
        {
            this.ClientSize = new Size(0, 0);

            this.Name = "RA Tracker - Last Five Achievements";
            this.Text = "RA Tracker - Last Five Achievements";

            this.Location = new Point(0, 0);
            this.Show();
        }
        public async void AssignJavaScriptVariables()
        {
            await ExecuteScript(
                "container = document.getElementById(\"container\");" +
                "allElements = document.getElementsByClassName(\"has-font\");" +
                "allLines = document.getElementsByClassName(\"focus-achievement-line\");" +
                "allAchievements = document.getElementsByClassName(\"focus-achievement\");" +
                "allPoints = document.getElementsByClassName(\"focus-achievement-points\");");
        }
        public async void SetFontColor(string value)
        {
            await ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }" +
                "for (var i = 0; i < allLines.length; i++) { allLines[i].style.color = \"" + value + "\"; }" +
                "for (var i = 0; i < allLines.length; i++) { allLines[i].style.backgroundColor = \"" + value + "\"; }");
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
                 "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; adjustFont(allElements[i]); }" +
                 "for (var i = 0; i < allLines.length; i++) { allLines[i].style.border = \"" + borderOutline + "\"; }");
        }

        public async void SetBackgroundColor(string value)
        {
            await ExecuteScript(
                "for (var i = 0; i < allAchievements.length; i++) { allAchievements[i].style.backgroundColor = \"" + value + "\"; }");
        }
        public async void EnableBorder()
        {
            await ExecuteScript("for (var i = 0; i < allAchievements.length; i++) { allAchievements[i].style.backgroundImage = \"url('disk://background')\"; }");
        }
        public async void DisableBorder()
        {
            await ExecuteScript("for (var i = 0; i < allAchievements.length; i++) { allAchievements[i].style.backgroundImage = \"\"; }");
        }
        public async void ShowPoints()
        {
            await ExecuteScript("for (var i = 0; i < allPoints.length; i++) { allPoints[i].style.display = \"block\"; }");
        }
        public async void HidePoints()
        {
            await ExecuteScript("for (var i = 0; i < allPoints.length; i++) { allPoints[i].style.display = \"none\"; }");
        }
        public async void CleanupList()
        {
            await ExecuteScript("allAchievements = document.getElementsByClassName(\"focus-achievement\");" +
                "while (allAchievements.length > 5) { allAchievements[allAchievements.length - 1].remove(); allAchievements = document.getElementsByClassName(\"focus-achievement\"); }");
        }
        public async void ClearList()
        {
            await ExecuteScript("allAchievements = document.getElementsByClassName(\"focus-achievement\");" +
                "while (allAchievements.length > 0) { allAchievements[allAchievements.length - 1].remove(); allAchievements = document.getElementsByClassName(\"focus-achievement\"); }");
        }

        public async void AddAchievement(Achievement achievement)
        {
            await ExecuteScript("addToList(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                                       "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\"," +
                                       "\"" + achievement.Description.Replace("\"", "\\\"") + "\"," +
                                       "\"" + achievement.Points + "\"," +
                                       "\"" + achievement.DateEarned.ToString() + "\", " +
                                       "\"" + achievement.Id + "\");");

        }
        public async Task<int> GetAchievementPosition(int id)
        {
            if (this.Visible && this.isReady)
            {
                try
                {
                    JavascriptResponse javascriptResponse = await chromiumWebBrowser.EvaluateScriptAsync("document.getElementById(\"achievement-" + id + "\").offsetTop");
                    return int.Parse(javascriptResponse.Result.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return 800;
        }

        public async Task SetAchievementPosition(int id, int position)
        {
            int oldOffset = await GetAchievementPosition(id);
            int newOffset;
            switch (position)
            {
                case 0:
                    newOffset = 5;
                    break;
                case 1:
                    newOffset = 150;
                    break;
                case 2:
                    newOffset = 295;
                    break;
                case 3:
                    newOffset = 440;
                    break;
                case 4:
                    newOffset = 585;
                    break;
                default:
                    newOffset = 800;
                    break;
            }

            await ExecuteScript("document.getElementById(\"achievement-" + id + "\")" +
                ".animate([ { left: '5px', top: '" + oldOffset + "px' }, { left: '5px', top: '" + newOffset + "px' } ], { interations: 1, duration: 200, fill: \"forwards\", easing: \"ease-out\" });");
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

            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.LastFive))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(700, 772),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    this.isReady = true;
                    this.ClientSize = new Size(616, 725);
                    LastFiveController.Instance.SetAllSettings();
                });
            });

            chromiumWebBrowser.JavascriptObjectRepository.ResolveObject += (sender, e) =>
            {
                var repo = e.ObjectRepository;
                if (e.ObjectName == "lastFiveControllerAsync")
                {
                    BindingOptions bindingOptions = null; //Binding options is an optional param, defaults to null
                    bindingOptions = BindingOptions.DefaultBinder; //Use the default binder to serialize values into complex objects
                    repo.NameConverter = new CamelCaseJavascriptNameConverter();
                    repo.Register("lastFiveControllerAsync", LastFiveController.Instance, isAsync: true, options: bindingOptions);
                }
            };

            this.Controls.Add(this.chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LastFiveLayoutWindow));
            this.SuspendLayout();
            // 
            // LastFiveLayoutWindow
            // 
            this.ClientSize = new Size(300, 280);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LastFiveLayoutWindow";
            this.ResumeLayout(false);
        }
    }
}