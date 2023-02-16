using CefSharp;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class RelatedMediaWindow : DisplayForm 
    { 
        public RelatedMediaWindow() : base()
        {
            Name = "RA Tracker - Related Media";
            Text = "RA Tracker - Related Media";
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            SetupBrowser();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            RelatedMediaController.Instance.IsOpen = false;
        }

        public override void AssignJavaScriptVariables()
        {
            ExecutionScripts.Enqueue(
                "container = document.getElementById(\"container\");" + 
                "imageAsset = document.getElementById(\"image-asset\");");
        }
        public void SetImage(string imageUri)
        {
            ExecutionScripts.Enqueue("imageAsset.src = \"" + imageUri +"\";");
        }
        public void HideImage()
        {
            ExecutionScripts.Enqueue("container.animate([ { left: '5px' }, { left: '650px' } ], { interations: 1, duration: 500, fill: \"forwards\", easing: \"ease-out\" });");
        }
        public void ShowImage()
        {
            ExecutionScripts.Enqueue("container.animate([ { left: '650px' }, { left: '5px' } ], { interations: 1, duration: 500, fill: \"forwards\", easing: \"ease-out\" });");
        }
        public void SetClientSize()
        {
            Invoke(new Action(() => {
                ClientSize = new Size(640, 480);
            }));
        }

        public override void SetupBrowser()
        {
            Controls.Remove(chromiumWebBrowser);

            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser()
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "relatedMediaBrowser",
                Size = new Size(650, 490),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.LoadingStateChanged += new EventHandler<LoadingStateChangedEventArgs>((sender, loadingStateChangedEventArgs) =>
            {
                if (!loadingStateChangedEventArgs.IsLoading)
                {
                    RelatedMediaController.Instance.IsOpen = true;
                    RelatedMediaController.Instance.SetAllSettings();
                }
            });
            
            chromiumWebBrowser.LoadHtml(Resources.related_media_window);

            Controls.Add(chromiumWebBrowser);
        }
    }
}
