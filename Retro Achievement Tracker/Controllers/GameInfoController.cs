using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.Linq;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class GameInfoController
    {
        private static GameInfoController instance = new GameInfoController();
        private static GameInfoWindow GameInfoWindow;
        public static bool IsOpen;

        private string title;
        private string genre;
        private string console;
        private string developer;
        private string publisher;
        private string released;

        private GameInfoController()
        {
            GameInfoWindow = new GameInfoWindow();
            IsOpen = false;
        }
        public static GameInfoController Instance
        {
            get
            {
                return instance;
            }
        }

        public void Close()
        {
            GameInfoWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                GameInfoWindow = new GameInfoWindow();
                GameInfoWindow.Show();
            }
        }
        public void SetConsoleValue(string value)
        {
            console = value;
            if (IsOpen)
            {
                GameInfoWindow.SetConsoleValue(value);
            }
        }

        public void SetTitleValue(string value)
        {
            title = value;
            if (IsOpen)
            {
                GameInfoWindow.SetTitleValue(title);
            }
        }

        public void SetPublisherValue(string value)
        {
            publisher = value;
            if (IsOpen)
            {
                GameInfoWindow.SetPublisherValue(value);
            }
        }

        public void SetDeveloperValue(string value)
        {
            developer = value;
            if (IsOpen)
            {
                GameInfoWindow.SetDeveloperValue(value);
            }
        }

        public void SetGenreValue(string value)
        {
            genre = value;
            if (IsOpen)
            {
                GameInfoWindow.SetGenreValue(value);
            }
        }

        public void SetReleaseDateValue(string value)
        {
            released = value;
            if (IsOpen)
            {
                GameInfoWindow.SetReleaseDateValue(value);
            }
        }
        public void SetAllSettings()
        {
            if (IsOpen)
            {
                GameInfoWindow.AssignJavaScriptVariables();
                if (AdvancedSettingsEnabled)
                {
                    SetAdvancedSettings();
                }
                else
                {
                    SetSimpleSettings();
                }

                GameInfoWindow.SetWindowBackgroundColor(WindowBackgroundColor);

                GameInfoWindow.SetTitleName(TitleName);
                GameInfoWindow.SetDeveloperName(DeveloperName);
                GameInfoWindow.SetPublisherName(PublisherName);
                GameInfoWindow.SetGenreName(GenreName);
                GameInfoWindow.SetConsoleName(ConsoleName);
                GameInfoWindow.SetReleaseDateName(ReleasedDateName);

                if (!string.IsNullOrEmpty(title))
                {
                    GameInfoWindow.SetTitleValue(title);
                    GameInfoWindow.SetDeveloperValue(developer);
                    GameInfoWindow.SetPublisherValue(publisher);
                    GameInfoWindow.SetGenreValue(genre);
                    GameInfoWindow.SetConsoleValue(console);
                    GameInfoWindow.SetReleaseDateValue(released);
                }
            }
        }
        public void SetSimpleSettings()
        {
            GameInfoWindow.SetSimpleFontFamily(SimpleFontFamily);
            GameInfoWindow.SetSimpleFontColor(SimpleFontColor);
            GameInfoWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
        }
        public void SetAdvancedSettings()
        {
            GameInfoWindow.SetNameFontFamily(NameFontFamily);
            GameInfoWindow.SetNameColor(NameColor);
            GameInfoWindow.SetNameOutline(NameOutlineEnabled ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");

            GameInfoWindow.SetValueFontFamily(ValueFontFamily);
            GameInfoWindow.SetValueColor(ValueColor);
            GameInfoWindow.SetValueOutline(ValueOutlineEnabled ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
        }
        /**
         * Variables
         */
        public string WindowBackgroundColor
        {
            get
            {
                return Settings.Default.game_info_window_background_color;
            }
            set
            {
                Settings.Default.game_info_window_background_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetWindowBackgroundColor(value);
                }
            }
        }
        public bool AdvancedSettingsEnabled
        {
            get
            {
                return Settings.Default.game_info_advanced_options_enabled;
            }
            set
            {
                Settings.Default.game_info_advanced_options_enabled = value;
                Settings.Default.Save();

                SetAllSettings();
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

                if (IsOpen)
                {
                    GameInfoWindow.SetTitleName(value);
                }
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

                if (IsOpen)
                {
                    GameInfoWindow.SetConsoleName(value);
                }
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

                if (IsOpen)
                {
                    GameInfoWindow.SetDeveloperName(value);
                }
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

                if (IsOpen)
                {
                    GameInfoWindow.SetPublisherName(value);
                }
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

                if (IsOpen)
                {
                    GameInfoWindow.SetGenreName(value);
                }
            }
        }
        public string ReleasedDateName
        {
            get
            {
                return Settings.Default.game_info_release_date_name;
            }
            set
            {
                Settings.Default.game_info_release_date_name = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetReleaseDateName(value);
                }
            }
        }
        public bool TitleEnabled
        {
            get
            {
                return Settings.Default.game_info_title_enabled;
            }
            set
            {
                Settings.Default.game_info_title_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetTitleVisibility(value);
                }
            }
        }
        public bool ConsoleEnabled
        {
            get
            {
                return Settings.Default.game_info_console_enabled;
            }
            set
            {
                Settings.Default.game_info_console_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetConsoleVisibility(value);
                }
            }
        }
        public bool DeveloperEnabled
        {
            get
            {
                return Settings.Default.game_info_developer_enabled;
            }
            set
            {
                Settings.Default.game_info_developer_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetDeveloperVisibility(value);
                }
            }
        }
        public bool PublisherEnabled
        {
            get
            {
                return Settings.Default.game_info_publisher_enabled;
            }
            set
            {
                Settings.Default.game_info_publisher_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetPublisherVisibility(value);
                }
            }
        }
        public bool GenreEnabled
        {
            get
            {
                return Settings.Default.game_info_genre_enabled;
            }
            set
            {
                Settings.Default.game_info_genre_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetGenreVisibility(value);
                }
            }
        }
        public bool ReleasedDateEnabled
        {
            get
            {
                return Settings.Default.game_info_release_date_enabled;
            }
            set
            {
                Settings.Default.game_info_release_date_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetReleaseDateVisibility(value);
                }
            }
        }
        public FontFamily SimpleFontFamily
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

                return familyArray[0];
            }
            set
            {
                Settings.Default.game_info_font_family_name = value.Name;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetSimpleFontFamily(SimpleFontFamily);
                }
            }
        }
        public string SimpleFontColor
        {
            get
            {
                return Settings.Default.game_info_font_color_hex_code;
            }
            set
            {
                Settings.Default.game_info_font_color_hex_code = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetSimpleFontColor(value);
                }
            }
        }
        public string SimpleFontOutlineColor
        {
            get
            {
                return Settings.Default.game_info_font_outline_color_hex;
            }
            set
            {
                Settings.Default.game_info_font_outline_color_hex = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    GameInfoWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
                }
            }
        }
        public int SimpleFontOutlineSize
        {
            get
            {
                return Settings.Default.game_info_font_outline_size;
            }
            set
            {
                Settings.Default.game_info_font_outline_size = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
                }
            }
        }
        public bool SimpleFontOutlineEnabled
        {
            get
            {
                return Settings.Default.game_info_font_outline_enabled;
            }
            set
            {
                Settings.Default.game_info_font_outline_enabled = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    GameInfoWindow.SetSimpleFontOutline(SimpleFontOutlineEnabled ? SimpleFontOutlineColor + " " + SimpleFontOutlineSize + "px" : "0px");
                }
            }
        }
        public FontFamily NameFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.game_info_name_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.game_info_name_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.game_info_name_font_family = value.Name;
                Settings.Default.Save();
                if (IsOpen)
                {
                    GameInfoWindow.SetNameFontFamily(NameFontFamily);
                }
            }
        }
        public FontFamily ValueFontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.game_info_value_font_family))
                    {
                        return font;
                    }
                }
                Settings.Default.game_info_value_font_family = familyArray[0].Name;

                return familyArray[0];
            }
            set
            {
                Settings.Default.game_info_value_font_family = value.Name;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetValueFontFamily(ValueFontFamily);
                }
            }
        }

        public string NameColor
        {
            get
            {
                return Settings.Default.game_info_name_color;
            }
            set
            {
                Settings.Default.game_info_name_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetNameColor(value);
                }
            }
        }
        public string ValueColor
        {
            get
            {
                return Settings.Default.game_info_value_color;
            }
            set
            {
                Settings.Default.game_info_value_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetValueColor(value);
                }
            }
        }
        public bool NameOutlineEnabled
        {
            get
            {
                return Settings.Default.game_info_name_outline_enabled;
            }
            set
            {
                Settings.Default.game_info_name_outline_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetNameOutline(value ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");
                }
            }
        }
        public bool ValueOutlineEnabled
        {
            get
            {
                return Settings.Default.game_info_value_outline_enabled;
            }
            set
            {
                Settings.Default.game_info_value_outline_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetValueOutline(value ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
                }
            }
        }
        public string NameOutlineColor
        {
            get
            {
                return Settings.Default.game_info_name_outline_color;
            }
            set
            {
                Settings.Default.game_info_name_outline_color = value;
                Settings.Default.Save();


                if (IsOpen)
                {
                    GameInfoWindow.SetNameOutline(NameOutlineEnabled ? NameOutlineColor + " " + NameOutlineSize + "px" : "0px");
                }
            }
        }
        public string ValueOutlineColor
        {
            get
            {
                return Settings.Default.game_info_value_outline_color;
            }
            set
            {
                Settings.Default.game_info_value_outline_color = value;
                Settings.Default.Save();


                if (IsOpen)
                {
                    GameInfoWindow.SetValueOutline(ValueOutlineEnabled ? ValueOutlineColor + " " + ValueOutlineSize + "px" : "0px");
                }
            }
        }
        public int NameOutlineSize
        {
            get
            {
                return Settings.Default.game_info_name_outline_size;
            }
            set
            {
                Settings.Default.game_info_name_outline_size = value;
                Settings.Default.Save();


                if (IsOpen)
                {
                    GameInfoWindow.SetNameOutline(NameOutlineColor + " " + NameOutlineSize + "px");
                }
            }
        }
        public int ValueOutlineSize
        {
            get
            {
                return Settings.Default.game_info_value_outline_size;
            }
            set
            {
                Settings.Default.game_info_value_outline_size = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    GameInfoWindow.SetValueOutline(ValueOutlineColor + " " + ValueOutlineSize + "px");
                }
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
                Settings.Default.Save();
            }
        }
    }
}
