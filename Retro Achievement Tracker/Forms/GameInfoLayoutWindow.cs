using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker
{
    public partial class GameInfoLayoutWindow : Form
    {
        private bool isReady = false;

        private string title;
        private string genre;
        private string console;
        private string developer;
        private string publisher;
        private string released;

        public GameInfoLayoutWindow()
        {
            this.ClientSize = new Size(0, 0);
            FontFamily[] familyArray = FontFamily.Families.ToArray();
            FontFamily[] gameInfoFontFamily = familyArray.Where(fontFamily => fontFamily.Name.Equals(Settings.Default.game_info_font_family_name)).ToArray();
            FontFamily = gameInfoFontFamily[0];

            SetupBrowser();

            this.Name = "RA Tracker - Game Info";
            this.Text = "RA Tracker - Game Info";

            if (AutoLaunch)
            {
                Show();
            }
        }
        public FontFamily FontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.game_info_font_family_name))
                    {
                        return font;
                    }
                }
                Settings.Default.game_info_font_family_name = familyArray[0].Name;
                Settings.Default.Save();

                return familyArray[0];
            }
            set
            {
                Settings.Default.game_info_font_family_name = value.Name;
                Settings.Default.Save();

                SetFontFamily();
            }
        }
        public string FontColor
        {
            get
            {
                return Settings.Default.game_info_font_color_hex_code;
            }
            set
            {
                Settings.Default.game_info_font_color_hex_code = value;
                Settings.Default.Save();

                SetFontColor();
            }
        }
        public string FontOutlineColor
        {
            get
            {
                return Settings.Default.game_info_font_outline_color_hex;
            }
            set
            {
                Settings.Default.game_info_font_outline_color_hex = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public int FontOutlineSize
        {
            get
            {
                return Settings.Default.game_info_font_outline_size;
            }
            set
            {
                Settings.Default.game_info_font_outline_size = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public bool FontOutlineEnable
        {
            get
            {
                return Settings.Default.game_info_font_outline_enabled;
            }
            set
            {
                Settings.Default.game_info_font_outline_enabled = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public bool TitleEnable
        {
            get
            {
                return Settings.Default.game_info_title_enable;
            }
            set
            {
                Settings.Default.game_info_title_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowTitle();
                }
                else
                {
                    HideTitle();
                }
            }
        }
        public bool ConsoleEnable
        {
            get
            {
                return Settings.Default.game_info_console_enable;
            }
            set
            {
                Settings.Default.game_info_console_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowConsole();
                }
                else
                {
                    HideConsole();
                }
            }
        }
        public bool DeveloperEnable
        {
            get
            {
                return Settings.Default.game_info_developer_enable;
            }
            set
            {
                Settings.Default.game_info_developer_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowDeveloper();
                }
                else
                {
                    HideDeveloper();
                }
            }
        }
        public bool PublisherEnable
        {
            get
            {
                return Settings.Default.game_info_publisher_enable;
            }
            set
            {
                Settings.Default.game_info_publisher_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowPublisher();
                }
                else
                {
                    HidePublisher();
                }
            }
        }
        public bool GenreEnable
        {
            get
            {
                return Settings.Default.game_info_genre_enable;
            }
            set
            {
                Settings.Default.game_info_genre_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowGenre();
                }
                else
                {
                    HideGenre();
                }
            }
        }
        public bool ReleaseDateEnable
        {
            get
            {
                return Settings.Default.game_info_release_date_enable;
            }
            set
            {
                Settings.Default.game_info_release_date_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowReleaseDate();
                }
                else
                {
                    HideReleaseDate();
                }
            }
        }

        public string TitleName
        {
            get
            {
                return Settings.Default.game_info_title_name;
            }
            set
            {
                Settings.Default.game_info_title_name = value;
                Settings.Default.Save();

                SetTitleName();
            }
        }
        public string ConsoleName
        {
            get
            {
                return Settings.Default.game_info_console_name;
            }
            set
            {
                Settings.Default.game_info_console_name = value;
                Settings.Default.Save();

                SetConsoleName();
            }
        }
        public string DeveloperName
        {
            get
            {
                return Settings.Default.game_info_developer_name;
            }
            set
            {
                Settings.Default.game_info_developer_name = value;
                Settings.Default.Save();

                SetDeveloperName();
            }
        }
        public string PublisherName
        {
            get
            {
                return Settings.Default.game_info_publisher_name;
            }
            set
            {
                Settings.Default.game_info_publisher_name = value;
                Settings.Default.Save();

                SetPublisherName();
            }
        }
        public string GenreName
        {
            get
            {
                return Settings.Default.game_info_genre_name;
            }
            set
            {
                Settings.Default.game_info_genre_name = value;
                Settings.Default.Save();

                SetGenreName();
            }
        }
        public string ReleaseDateName
        {
            get
            {
                return Settings.Default.game_info_release_date_name;
            }
            set
            {
                Settings.Default.game_info_release_date_name = value;
                Settings.Default.Save();

                SetReleaseDateName();
            }
        }
        public bool AutoLaunch
        {
            get
            {
                return Settings.Default.auto_game_info;
            }
            set
            {
                Settings.Default.auto_game_info = value;
            }
        }
        //Title
        public async void SetTitleName()
        {
            await ExecuteScript("$(\"#title-name\").text(\"" + TitleName + ":\");");
        }
        public async void SetTitleValue(string titleValue)
        {
            if (titleValue != null)
            {

                if (titleValue.Contains(", The"))
                {
                    titleValue = "The " + titleValue.Substring(0, titleValue.IndexOf(", The")) + titleValue.Substring(titleValue.IndexOf(", The") + 5, titleValue.Length - titleValue.IndexOf(", The") - 5);
                }

                title = titleValue;
                await ExecuteScript("$(\"#title-value\").text(\"" + title + "\");");

                if (TitleEnable)
                {
                    ShowTitle();
                }
                else
                {
                    HideTitle();
                }
            }
        }
        public async void ShowTitle()
        {
            await ExecuteScript("$(\"#title\").fadeIn();");
        }
        public async void HideTitle()
        {
            await ExecuteScript("$(\"#title\").fadeOut();");
        }

        //Console
        public async void SetConsoleName()
        {
            await ExecuteScript("$(\"#console-name\").text(\"" + ConsoleName + ":\");");
        }
        public async void SetConsoleValue(string consoleValue)
        {
            if (consoleValue != null)
            {
                console = consoleValue;
                await ExecuteScript("$(\"#console-value\").text(\"" + console + "\");");
                if (ConsoleEnable)
                {
                    ShowConsole();
                }
                else
                {
                    HideConsole();
                }
            }
        }
        public async void ShowConsole()
        {
            await ExecuteScript("$(\"#console\").fadeIn();");
        }
        public async void HideConsole()
        {
            await ExecuteScript("$(\"#console\").fadeOut();");
        }

        //Developer
        public async void SetDeveloperName()
        {
            await ExecuteScript("$(\"#developer-name\").text(\"" + DeveloperName + ":\");");
        }
        public async void SetDeveloperValue(string developerValue)
        {
            if (developerValue != null)
            {
                developer = developerValue;
                await ExecuteScript("$(\"#developer-value\").text(\"" + developer + "\");");
                if (DeveloperEnable)
                {
                    ShowDeveloper();
                }
                else
                {
                    HideDeveloper();
                }
            }
        }
        public async void ShowDeveloper()
        {
            await ExecuteScript("$(\"#developer\").fadeIn();");
        }
        public async void HideDeveloper()
        {
            await ExecuteScript("$(\"#developer\").fadeOut();");
        }

        //Publisher
        public async void SetPublisherName()
        {
            await ExecuteScript("$(\"#publisher-name\").text(\"" + PublisherName + ":\");");
        }
        public async void SetPublisherValue(string publisherValue)
        {
            if (publisherValue != null)
            {
                publisher = publisherValue;
                await ExecuteScript("$(\"#publisher-value\").text(\"" + publisher + "\");");
                if (PublisherEnable)
                {
                    ShowPublisher();
                }
                else
                {
                    HidePublisher();
                }
            }
        }
        public async void ShowPublisher()
        {
            await ExecuteScript("$(\"#publisher\").fadeIn();");
        }
        public async void HidePublisher()
        {
            await ExecuteScript("$(\"#publisher\").fadeOut();");
        }

        //Genre
        public async void SetGenreName()
        {
            await ExecuteScript("$(\"#genre-name\").text(\"" + GenreName + ":\");");
        }
        public async void SetGenreValue(string genreValue)
        {
            if (genreValue != null)
            {
                genre = genreValue;
                await ExecuteScript("$(\"#genre-value\").text(\"" + genre + "\");");
                if (GenreEnable)
                {
                    ShowGenre();
                }
                else
                {
                    HideGenre();
                }
            }
        }
        public async void ShowGenre()
        {
            await ExecuteScript("$(\"#genre\").fadeIn();");
        }
        public async void HideGenre()
        {
            await ExecuteScript("$(\"#genre\").fadeOut();");
        }

        //Release Date
        public async void SetReleaseDateName()
        {
            await ExecuteScript("$(\"#release-date-name\").text(\"" + ReleaseDateName + ":\");");
        }
        public async void SetReleaseDateValue(string releaseDateValue)
        {
            if (releaseDateValue != null)
            {
                released = releaseDateValue;
                await ExecuteScript("$(\"#release-date-value\").text(\"" + released + "\");");
                if (ReleaseDateEnable)
                {
                    ShowReleaseDate();
                }
                else
                {
                    HideReleaseDate();
                }
            }
        }
        public async void ShowReleaseDate()
        {
            await ExecuteScript("$(\"#release-date\").fadeIn();");
        }
        public async void HideReleaseDate()
        {
            await ExecuteScript("$(\"#release-date\").fadeOut();");
        }

        //Fonts
        public async void SetFontFamily()
        {
            await ExecuteScript(string.Format("setFont(\"{0}\", \"{1}px\");", FontFamily.Name.Replace(":", "\\\\:"), FontFamily.GetLineSpacing(FontStyle.Regular) / FontFamily.GetEmHeight(FontStyle.Regular)));
        }
        public async void SetFontColor()
        {
            await ExecuteScript("setFontColor(\"" + FontColor + "\");");
        }
        public async void SetFontOutline()
        {
            if (FontOutlineEnable)
            {
                await ExecuteScript("setFontOutline(\"" + FontOutlineColor + " " + FontOutlineSize + "px\");");
            }
            else
            {
                await ExecuteScript("setFontOutline(\"0px\");");
            }
        }
        protected async Task ExecuteScript(string script)
        {
            if (this.Visible && this.isReady)
            {
                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                    await chromiumWebBrowser.EvaluateScriptAsync("adjustsWidths();", TimeSpan.FromSeconds(5));

                }
                catch (Exception)
                {
                }
            }
        }

        protected void SetupBrowser()
        {
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.GameInfo))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(1366, 768),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.LoadHtml(Resources.GameInfo);
            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    this.isReady = true;
                    this.ClientSize = new Size(685, 320);
                });

                SetFontFamily();
                SetFontColor();
                SetFontOutline();

                SetTitleName();
                SetTitleValue(title);

                SetConsoleName();
                SetConsoleValue(console);

                SetDeveloperName();
                SetDeveloperValue(developer);

                SetPublisherName();
                SetPublisherValue(publisher);

                SetGenreName();
                SetGenreValue(genre);

                SetReleaseDateName();
                SetReleaseDateValue(released);
            });
            this.Controls.Add(this.chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameInfoLayoutWindow));
            this.SuspendLayout();
            // 
            // GameInfoLayoutWindow
            // 
            this.ClientSize = new Size(284, 261);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameInfoLayoutWindow";
            this.ResumeLayout(false);
        }
    }
}