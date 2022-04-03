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
                "focusElement = document.getElementById(\"focus\");" +
                "focusTitleElement = document.getElementById(\"title\");" +
                "focusDescriptionElement = document.getElementById(\"description\");" +
                "focusPointsElement = document.getElementById(\"points\");" +
                "focusBadgeElement = document.getElementById(\"badge\");" +
                "focusLineElement = document.getElementById(\"line\");");
        }
        public void SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
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

        public void SetSimpleFontOutline(string fontOutline, string borderOutline)
        {
            ExecuteScript(
                 "for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + fontOutline + "\"; }" +
                 "focusLineElement.style.border = \"" + borderOutline + "\";");
        }

        public void SetSimpleFontColor(string value)
        {
            ExecuteScript(
                "for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }" +
                "focusLineElement.style.color = \"" + value + "\";" +
                "focusLineElement.style.backgroundColor = \"" + value + "\";");
        }

        public void SetBorderBackgroundColor(string value)
        {
            ExecuteScript(
                "focusElement.style.backgroundColor = \"" + value + "\";");
        }
        public void SetWindowBackgroundColor(string value)
        {
            ExecuteScript(
                "container.style.backgroundColor = \"" + value + "\";");
        }

        public void SetDescriptionOutline(string value)
        {
            ExecuteScript(
                  "focusDescriptionElement.style.webkitTextStroke = \"" + value + "\";" +
                  "textFit(focusDescriptionElement, { alignVert: true, alignHoriz: true });");
        }

        public void SetDescriptionColor(string value)
        {
            ExecuteScript(
                "focusDescriptionElement.style.color = \"" + value + "\";");
        }

        public void SetDescriptionFontFamily(System.Drawing.FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                  "focusDescriptionElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "focusDescriptionElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(focusDescriptionElement, { alignVert: true, alignHoriz: true });");
        }

        public void SetTitleOutline(string value)
        {
            ExecuteScript(
                 "focusTitleElement.style.webkitTextStroke = \"" + value + "\";");
        }

        public void SetTitleColor(string value)
        {
            ExecuteScript(
                "focusTitleElement.style.color = \"" + value + "\";");
        }

        public void SetTitleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
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
                ExecuteScript("$(\"#focus\").fadeOut(\"fast\");");

                await Task.Delay(100);

                ExecuteScript("focusTitleElement.style.display = \"none\";");
                ExecuteScript("focusDescriptionElement.style.display = \"none\";");
                ExecuteScript("focusPointsElement.style.display = \"none\";");
                ExecuteScript("focusLineElement.style.display = \"none\";");
                ExecuteScript("focusBadgeElement.style.display = \"none\";");

                ExecuteScript("focusTitleElement.innerHTML = \"" + achievement.Title.Replace("\"", "\\\"") + "\";");
                ExecuteScript("focusDescriptionElement.innerHTML = \"" + actualDescription.Replace("\"", "\\\"") + "\";");
                ExecuteScript("$(\"#badge\").attr('src', \"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\");");
                ExecuteScript("focusPointsElement.innerHTML = \"" + achievement.Points + "\";");

                await Task.Delay(100);

                ExecuteScript("$(\"#focus\").fadeIn();");

                ExecuteScript("$(\"#badge\").fadeIn(); focusBadgeElement.animate([ { left: '3000px' }, { left: '10px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" });");
                ExecuteScript("setTimeout(function() { $(\"#line\").fadeIn(); focusLineElement.animate([ { right: '-1922px', top: '0px' }, { right: '10px', top: '0px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 200);");
                ExecuteScript("setTimeout(function() { $(\"#points\").fadeIn(); textFit(focusPointsElement); focusPointsElement.animate([ { left: '1922px', top: '90px' }, { left: '15px', top: '90px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 400);");
                ExecuteScript("setTimeout(function() { $(\"#title\").fadeIn(); textFit(focusTitleElement, { alignVert: true, alignHoriz: true }); focusTitleElement.animate([ { right: '-1922px', top: '0px' }, { right: '0px', top: '0px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 600);");
                ExecuteScript("setTimeout(function() { $(\"#description\").fadeIn(); textFit(focusDescriptionElement, { alignVert: true, alignHoriz: true }); focusDescriptionElement.animate([ { right: '-1922px', top: '0px' }, { right: '0px', top: '0px' } ], { interations: 1, duration: 700, fill: \"forwards\", easing: \"ease-out\" }); }, 800);");
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

        public void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecuteScript(
                  "focusPointsElement.style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                  "focusPointsElement.style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                  "textFit(focusPointsElement, { alignVert: true, alignHoriz: true });");
        }

        public void HideFocus()
        {
            ExecuteScript("$(\"#focus\").fadeOut();");
        }
        public void EnableBorder()
        {
            ExecuteScript("focusElement.style.backgroundImage = \"url('disk://background')\";");
        }
        public void DisableBorder()
        {
            ExecuteScript("focusElement.style.backgroundImage = \"\";");
        }
        public void SetPointsColor(string value)
        {
            ExecuteScript(
                 "focusPointsElement.style.color = \"" + value + "\";");
        }
        public void SetPointsOutline(string fontOutline)
        {
            ExecuteScript(
                "focusPointsElement.style.webkitTextStroke = \"" + fontOutline + "\";");
        }
        public void SetLineColor(string value)
        {
            ExecuteScript(
                 "focusLineElement.style.color = \"" + value + "\";" +
                 "focusLineElement.style.backgroundColor = \"" + value + "\";");
        }

        public void SetLineOutline(string borderOutline)
        {
            ExecuteScript(
                "focusLineElement.style.border = \"" + borderOutline + "\";");
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
                    ClientSize = new Size(700, 0);

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