using CefSharp;
using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public abstract partial class DisplayForm : Form
    {
        protected CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
        private Timer ScriptExecutionTimer;
        protected readonly ConcurrentQueue<string> ExecutionScripts = new ConcurrentQueue<string>();
        public DisplayForm()
        {
            InitializeComponent();

            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainWindow));
            Icon = (Icon)resources.GetObject("$this.Icon");

            ClientSize = new Size(0, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            ScriptExecutionTimer = new Timer();
            ScriptExecutionTimer.Tick += ExecuteNextScript;
            ScriptExecutionTimer.Interval = 10;

            ScriptExecutionTimer.Start();
        }
        public abstract void SetupBrowser();
        public abstract void AssignJavaScriptVariables();
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        public void SetWindowBackgroundColor(string value)
        {
            ExecutionScripts.Enqueue("document.body.style.backgroundColor = \"" + value + "\";");
        }
        private async void ExecuteNextScript(object sender, EventArgs e)
        {
            if (ExecutionScripts.TryDequeue(out string script))
            {
                await Task.Run(() => ExecuteScript(script));
            }
        }
        protected async Task ExecuteScript(string script)
        {
            if (chromiumWebBrowser != null)
            {
                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
