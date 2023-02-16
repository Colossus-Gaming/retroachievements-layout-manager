using CefSharp;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class UserInfoWindow : DisplayForm
    {
        public UserInfoWindow() : base()
        {
            Name = "RA Tracker - User Info";
            Text = "RA Tracker - User Info";
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            SetupBrowser();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            UserInfoController.Instance.IsOpen = false;
        }
        public override async void AssignJavaScriptVariables()
        {
            await ExecuteScript(
                "rankName = document.getElementById(\"rank-name\");" +
                "rankValue = document.getElementById(\"rank-value\");" +
                "ratioName = document.getElementById(\"ratio-name\");" +
                "ratioValue = document.getElementById(\"ratio-value\");" +
                "pointsName = document.getElementById(\"points-name\");" +
                "pointsValue = document.getElementById(\"points-value\");" +
                "truePointsName = document.getElementById(\"true-points-name\");" +
                "truePointsValue = document.getElementById(\"true-points-value\");" +
                "allElements = document.getElementsByClassName(\"has-font\");" +
                "allNames = document.getElementsByClassName(\"name\");" +
                "allValues = document.getElementsByClassName(\"value\");");
        }
        public void SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allElements.length; i++) { " +
                "   allElements[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allElements[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "}");
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allNames.length; i++) { " +
                "   textFit(allNames[i], { alignVert: true, reProcess: true });" +
                "}");
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   textFit(allValues[i], { alignVert: true, reProcess: true });" +
                "}");
        }
        public void SetSimpleFontColor(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allElements.length; i++) { allElements[i].style.color = \"" + value + "\"; }");
        }

        public void SetSimpleFontOutline(string value)
        {
            ExecutionScripts.Enqueue("for (var i = 0; i < allElements.length; i++) { allElements[i].style.webkitTextStroke = \"" + value + "\"; }");
        }

        public void SetNameFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allNames.length; i++) { " +
                "   allNames[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allNames[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allNames[i], { alignVert: true, reProcess: true });" +
                "}");
        }

        public void SetValueFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);
            ExecutionScripts.Enqueue(
                "for (var i = 0; i < allValues.length; i++) { " +
                "   allValues[i].style.lineHeight = " + (lineSpacing == 0 ? 1 : lineSpacing) + ";" +
                "   allValues[i].style.fontFamily = \"" + value.Name.Replace(":", "\\:") + "\";" +
                "   textFit(allValues[i], { alignVert: true, reProcess: true });" +
                "}");
        }

        public void SetNameColor(string value)
        {
            ExecutionScripts.Enqueue(
                 "for (var i = 0; i < allNames.length; i++) { allNames[i].style.color = \"" + value + "\"; }");
        }

        public void SetValueColor(string value)
        {
            ExecutionScripts.Enqueue(
                 "for (var i = 0; i < allValues.length; i++) { allValues[i].style.color = \"" + value + "\"; }");
        }

        public void SetNameOutline(string value)
        {
            ExecutionScripts.Enqueue(
                  "for (var i = 0; i < allNames.length; i++) { allNames[i].style.webkitTextStroke = \"" + value + "\"; }");
        }

        public void SetValueOutline(string value)
        {
            ExecutionScripts.Enqueue(
                  "for (var i = 0; i < allValues.length; i++) { allValues[i].style.webkitTextStroke = \"" + value + "\"; }");
        }
        public void SetRankName(string value)
        {
            ExecutionScripts.Enqueue("rankName.innerHTML = \"" + value + ":\";" +
                "textFit(rankName, { alignVert: true, reProcess: true });");
        }
        public void SetRankValue(string value)
        {
            ExecutionScripts.Enqueue("rankValue.innerHTML = \"" + value + "\";" +
                "textFit(rankValue, { alignVert: true, reProcess: true });");
        }
        public void SetRankVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#rank\").fadeIn();" : "$(\"#rank\").fadeOut();");
        }
        //Points
        public void SetPointsName(string value)
        {
            ExecutionScripts.Enqueue("pointsName.innerHTML = \"" + value + ":\";" +
                "textFit(pointsName, { alignVert: true, reProcess: true });");
        }
        public void SetPointsValue(string value)
        {
            ExecutionScripts.Enqueue("pointsValue.innerHTML = \"" + value + "\";" +
                "textFit(pointsValue, { alignVert: true, reProcess: true });");
        }
        public void SetPointsVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#points\").fadeIn();" : "$(\"#points\").fadeOut();");
        }
        //True Points
        public void SetTruePointsName(string value)
        {
            ExecutionScripts.Enqueue("truePointsName.innerHTML = \"" + value + ":\";" +
                "textFit(truePointsName, { alignVert: true, reProcess: true });");
        }
        public void SetTruePointsValue(string value)
        {
            ExecutionScripts.Enqueue("truePointsValue.innerHTML = \"" + value + "\";" +
                "textFit(truePointsValue, { alignVert: true, reProcess: true });");
        }
        public void SetTruePointsVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#true-points\").fadeIn();" : "$(\"#true-points\").fadeOut();");
        }
        //Ratio
        public void SetRatioName(string value)
        {
            ExecutionScripts.Enqueue("ratioName.innerHTML = \"" + value + ":\";" +
                "textFit(ratioName, { alignVert: true, reProcess: true });");
        }
        public void SetRatioValue(string value)
        {
            ExecutionScripts.Enqueue("ratioValue.innerHTML = \"" + value + "\";" +
                "textFit(ratioValue, { alignVert: true, reProcess: true });");
        }
        public void SetRatioVisibility(bool isVisible)
        {
            ExecutionScripts.Enqueue(isVisible ? "$(\"#ratio\").fadeIn();" : "$(\"#ratio\").fadeOut();");
        }
        public void SetClientSize()
        {
            Invoke(new Action(() => {
                ClientSize = new Size(805, 290);
            }));
        }
        public override void SetupBrowser()
        {
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser()
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "userInfoBrowser",
                Size = new Size(805, 290),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.LoadingStateChanged += new EventHandler<LoadingStateChangedEventArgs>((sender, loadingStateChangedEventArgs) =>
            {
                if (!loadingStateChangedEventArgs.IsLoading)
                {
                    UserInfoController.Instance.IsOpen = true;

                    UserInfoController.Instance.UpdateUserInfo();
                }
            });

            chromiumWebBrowser.LoadHtml(Resources.user_info_window);

            Controls.Add(chromiumWebBrowser);
        }
    }
}