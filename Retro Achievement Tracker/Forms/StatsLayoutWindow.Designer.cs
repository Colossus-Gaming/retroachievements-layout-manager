using CefSharp.Web;
using CefSharp.WinForms;
using Retro_Achievement_Tracker.Properties;

namespace Retro_Achievement_Tracker
{
    partial class StatsLayoutWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsLayoutWindow));
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.SuspendLayout();
            // 
            // StatsLayoutWindow
            // 
            // 
            // chromiumWebBrowser
            // 
            this.chromiumWebBrowser.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.chromiumWebBrowser.Name = "chromiumWebBrowser";
            this.chromiumWebBrowser.Size = new System.Drawing.Size(1920, 1080);
            this.chromiumWebBrowser.Dock = System.Windows.Forms.DockStyle.None;

            this.ClientSize = new System.Drawing.Size(400, 367);
            this.Controls.Add(this.chromiumWebBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatsLayoutWindow";
            this.Text = "Retro Achievement - Layout - Stats";
            this.ResumeLayout(false);
        }
        #endregion

        public ChromiumWebBrowser chromiumWebBrowser;
    }
}