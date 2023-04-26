namespace Retro_Achievement_Tracker.Models
{
    public class Constants
    {
        public static readonly string GITHUB_AUTO_UPDATE_URL = "https://github.com/Colossus-Gaming/retroachievements-layout-manager/releases/download/release-management/ra-layout-manager-release.xml";
        public static readonly string RETRO_ACHIEVEMENTS_URL = "https://retroachievements.org";
        public static readonly string RETRO_ACHIEVEMENTS_MEDIA_URL = "http://media.retroachievements.org";
        public static readonly string RETRO_ACHIEVEMENTS_PROFILE_PIC_URL = "https://retroachievements.org/UserPic/{0}.png";

        public static readonly string RETRO_ACHIEVEMENTS_API_GET_USER = "/API/API_GetUserSummary.php?z={0}&y={1}&u={2}&g=1&a=1";
        public static readonly string RETRO_ACHIEVEMENTS_API_GET_RECENTLY_PLAYED = "/API/API_GetUserRecentlyPlayedGames.php?z={0}&y={1}&u={2}&c=1";
        public static readonly string RETRO_ACHIEVEMENTS_API_GET_GAME = "/API/API_GetGameInfoAndUserProgress.php?z={0}&y={1}&u={2}&g={3}";
        public static readonly string RETRO_ACHIEVEMENTS_API_GET_RANK_AND_SCORE = "/API/API_GetUserRankAndScore.php?z={0}&y={1}&u={2}";

        public static readonly string RETRO_ACHIEVEMENTS_RSS_NEWS_URI = "/rss-news";
        public static readonly string RETRO_ACHIEVEMENTS_RSS_CHEEVO_URI = "/rss-newachievements";
        public static readonly string RETRO_ACHIEVEMENTS_RSS_FORUM_URI = "/rss-forum";
        public static readonly string RETRO_ACHIEVEMENTS_RSS_FRIEND_URI = "/rss-activity?u={0}";

        public static readonly string RETRO_ACHIEVEMENTS_LABEL_MSG_CHEEVO_POP = "CHEEVOS POP!";
        public static readonly string RETRO_ACHIEVEMENTS_LABEL_MSG_CHANGING_TITLE = "Changing game to [{0}]";
        public static readonly string RETRO_ACHIEVEMENTS_LABEL_MSG_COUNTDOWN = "Updating in {0}...";
        public static readonly string RETRO_ACHIEVEMENTS_LABEL_MSG_UPDATING_USER_INFO = "Updating user info";
        public static readonly string RETRO_ACHIEVEMENTS_LABEL_MSG_UPDATING_GAME_INFO = "Updating game info";
        public static readonly string RETRO_ACHIEVEMENTS_LABEL_MSG_UPDATING_RSS_FEED = "Updating game info";

        public static readonly string RETRO_ACHIEVEMENTS_RSS_NEWS_HTML = "<!DOCTYPE html><html><style> html {{ color: #ffffff; font-family: \"Lucida Console Bold\", \"Courier New\", monospace; font-size: 14px; background-color: #272727; }} a:link {{ color: #ffa200; }} </style><body>{0}</body></html>";
        private Constants() { }
    }
}
