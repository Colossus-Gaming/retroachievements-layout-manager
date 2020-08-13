using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class SupportPage : Form
    {
        public SupportPage()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;

            System.Diagnostics.Process.Start("https://streamelements.com/retros3xual/tip");
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel2.LinkVisited = true;

            System.Diagnostics.Process.Start("https://twitch.tv/RetroS3xual");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel3.LinkVisited = true;

            System.Diagnostics.Process.Start("https://twitter.com/RS3xual");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel4.LinkVisited = true;

            System.Diagnostics.Process.Start("http://retroachievements.org/user/RetroS3xual");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel7.LinkVisited = true;

            System.Diagnostics.Process.Start("https://twitch.tv/Adultery77");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel6.LinkVisited = true;

            System.Diagnostics.Process.Start("https://twitter.com/adultery77");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel8.LinkVisited = true;

            System.Diagnostics.Process.Start("https://streamlabs.com/adultery77/tip");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel5.LinkVisited = true;

            System.Diagnostics.Process.Start("http://retroachievements.org/user/adultery");
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel11.LinkVisited = true;

            System.Diagnostics.Process.Start("https://twitch.tv/Dancarnate");
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel10.LinkVisited = true;

            System.Diagnostics.Process.Start("https://twitter.com/dancarnate");
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel12.LinkVisited = true;

            System.Diagnostics.Process.Start("https://streamelements.com/dancarnate/tip");
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel9.LinkVisited = true;

            System.Diagnostics.Process.Start("http://retroachievements.org/user/dancarnate");
        }
    }
}
