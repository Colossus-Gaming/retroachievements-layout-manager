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
                "focusElement = document.getElementById(\"focus\");" +
                "focusTitleElement = document.getElementById(\"title\");" +
                "focusDescriptionElement = document.getElementById(\"description\");" +
                "focusPointsElement = document.getElementById(\"points\");" +
                "focusBadgeElement = document.getElementById(\"badge\");" +
                "focusLineElement = document.getElementById(\"line\");");
        }
        public async Task SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
                  "focusTitleElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "focusTitleElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(focusTitleElement, { alignVert: true, alignHoriz: true });" +
                  "focusDescriptionElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "focusDescriptionElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(focusDescriptionElement, { alignVert: true, alignHoriz: true });" +
                  "focusPointsElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "focusPointsElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(focusPointsElement);");
        }

        public async Task SetSimpleFontOutline(string fontOutline, string borderOutline)
        {
            await ExecuteScript(
                 "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; }" +
                 "focusLineElement.style.border = \"" + borderOutline + "\";");
        }

        public async Task SetSimpleFontColor(string value)
        {
            await ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }" +
                "focusLineElement.style.color = \"" + value + "\";" +
                "focusLineElement.style.backgroundColor = \"" + value + "\";");
        }

        public async Task SetBorderBackgroundColor(string value)
        {
            await ExecuteScript(
                "focusElement.style.backgroundColor = \"" + value + "\";");
        }
        public async Task SetWindowBackgroundColor(string value)
        {
            await ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }

        public async Task SetDescriptionOutline(string value)
        {
            await ExecuteScript(
                  "focusDescriptionElement.style.webkitTextStroke = \"" + value + "\";" +
                  "textFit(focusDescriptionElement, { alignVert: true, alignHoriz: true });");
        }

        public async Task SetDescriptionColor(string value)
        {
            await ExecuteScript(
                "focusDescriptionElement.style.color = \"" + value + "\";");
        }

        public async Task SetDescriptionFontFamily(System.Drawing.FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
                  "focusDescriptionElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "focusDescriptionElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(focusDescriptionElement, { alignVert: true, alignHoriz: true });");
        }

        public async Task SetTitleOutline(string value)
        {
            await ExecuteScript(
                 "focusTitleElement.style.webkitTextStroke = \"" + value + "\";");
        }

        public async Task SetTitleColor(string value)
        {
            await ExecuteScript(
                "focusTitleElement.style.color = \"" + value + "\";");
        }

        public async Task SetTitleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
                  "focusTitleElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "focusTitleElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(focusTitleElement, { alignVert: true, alignHoriz: true });");
        }

        public async void SetFocus(Achievement achievement)
        {
            if (achievement != null)
            {
                StringBuilder actualDescription = BreakString(achievement.Description.Length, achievement.Description.Split(new string[] { " " }, StringSplitOptions.None));

                Invoke((MethodInvoker)delegate
                {
                    ClientSize = new Size(700, 165);
                });
                await ExecuteScript("$(\"#focus\").fadeOut(\"fast\");");

                await Task.Delay(500);

                await ExecuteScript("focusTitleElement.style.display = \"none\";");
                await ExecuteScript("focusDescriptionElement.style.display = \"none\";");
                await ExecuteScript("focusPointsElement.style.display = \"none\";");
                await ExecuteScript("focusLineElement.style.display = \"none\";");
                await ExecuteScript("focusBadgeElement.style.display = \"none\";");

                await ExecuteScript("focusTitleElement.innerHTML = \"" + achievement.Title.Replace("\"", "\\\"") + "\";");
                await ExecuteScript("focusDescriptionElement.innerHTML = \"" + actualDescription.Replace("\"", "\\\"") + "\";");
                await ExecuteScript("$(\"#badge\").attr('src', \"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\");");
                await ExecuteScript("focusPointsElement.innerHTML = \"" + achievement.Points + "\";");

                await Task.Delay(500);

                await ExecuteScript("$(\"#focus\").fadeIn();");

                await ExecuteScript("$(\"#badge\").fadeIn(); focusBadgeElement.animate([ { left: '3000px' }, { left: '10px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" });");
                await ExecuteScript("setTimeout(function() { $(\"#line\").fadeIn(); focusLineElement.animate([ { right: '-1922px', top: '0px' }, { right: '10px', top: '0px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 200);");
                await ExecuteScript("setTimeout(function() { $(\"#points\").fadeIn(); textFit(focusPointsElement); focusPointsElement.animate([ { left: '1922px', top: '90px' }, { left: '15px', top: '90px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 400);");
                await ExecuteScript("setTimeout(function() { $(\"#title\").fadeIn(); textFit(focusTitleElement, { alignVert: true, alignHoriz: true }); focusTitleElement.animate([ { right: '-1922px', top: '0px' }, { right: '0px', top: '0px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 600);");
                await ExecuteScript("setTimeout(function() { $(\"#description\").fadeIn(); textFit(focusDescriptionElement, { alignVert: true, alignHoriz: true }); focusDescriptionElement.animate([ { right: '-1922px', top: '0px' }, { right: '0px', top: '0px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 800);");
            }
            else
            {
                HideFocus();
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

        public async Task SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            await ExecuteScript(
                  "focusPointsElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "focusPointsElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(focusPointsElement, { alignVert: true, alignHoriz: true });");
        }

        public async void HideFocus()
        {
            Invoke((MethodInvoker)delegate
            {
                ClientSize = new Size(0, 0);
            });

            await ExecuteScript("$(\"#focus\").fadeOut();");
        }
        public async Task EnableBorder()
        {
            await ExecuteScript("focusElement.style.backgroundImage = \"url('disk://background')\";");
        }
        public async Task DisableBorder()
        {
            await ExecuteScript("focusElement.style.backgroundImage = \"\";");
        }
        public async Task SetPointsColor(string value)
        {
            await ExecuteScript(
                 "focusPointsElement.style.color = \"" + value + "\";");
        }
        public async Task SetPointsOutline(string fontOutline)
        {
            await ExecuteScript(
                "focusPointsElement.style.webkitTextStroke = \"" + fontOutline + "\";");
        }
        public async Task SetLineColor(string value)
        {
            await ExecuteScript(
                 "focusLineElement.style.color = \"" + value + "\";" +
                 "focusLineElement.style.backgroundColor = \"" + value + "\";");
        }

        public async Task SetLineOutline(string borderOutline)
        {
            await ExecuteScript(
                "focusLineElement.style.border = \"" + borderOutline + "\";");
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
                    ClientSize = new Size(700, 0);

                    FocusController.Instance.SetAllSettings();
                    FocusController.Instance.UpdateFocus();
                });
            });
            chromiumWebBrowser.LoadHtml(Resources.FocusWindow);

            Controls.Add(chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FocusWindow));
            this.SuspendLayout();
            // 
            // FocusWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FocusWindow";
            this.ResumeLayout(false);

        }
    }
}