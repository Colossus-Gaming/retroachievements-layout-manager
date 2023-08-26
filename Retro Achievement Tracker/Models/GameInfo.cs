using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Retro_Achievement_Tracker.Models
{
    [JsonConverter(typeof(GameInfoConverter))]
    public partial class GameInfo : IComparable<GameInfo>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        private long _consoleId;
        public long ConsoleId
        {
            get { return _consoleId; }
            set
            {
                switch (value)
                {
                    case 1:
                        ConsoleName = "Sega Genesis";
                        break;
                    case 2:
                        ConsoleName = "Nintendo 64";
                        break;
                    case 3:
                        ConsoleName = "Super Nintendo Entertainment System";
                        break;
                    case 4:
                        ConsoleName = "Nintendo Game Boy";
                        break;
                    case 5:
                        ConsoleName = "Nintendo Game Boy Advance";
                        break;
                    case 6:
                        ConsoleName = "Nintendo Game Boy Color";
                        break;
                    case 7:
                        ConsoleName = "Nintendo Entertainment System";
                        break;
                    case 8:
                        ConsoleName = "NEC TurboGrafx-16";
                        break;
                    case 9:
                        ConsoleName = "Sega CD";
                        break;
                    case 10:
                        ConsoleName = "Sega 32X";
                        break;
                    case 11:
                        ConsoleName = "Sega Master System";
                        break;
                    case 12:
                        ConsoleName = "Sony Playstation";
                        break;
                    case 13:
                        ConsoleName = "Atari Lynx";
                        break;
                    case 14:
                        ConsoleName = "SNK Neo Geo Pocket";
                        break;
                    case 15:
                        ConsoleName = "Sega Game Gear";
                        break;
                    case 16:
                        ConsoleName = "Nintendo GameCube";
                        break;
                    case 17:
                        ConsoleName = "Atari Jaguar";
                        break;
                    case 18:
                        ConsoleName = "Nintendo DS";
                        break;
                    case 19:
                        ConsoleName = "Nintendo Wii";
                        break;
                    case 20:
                        ConsoleName = "Nintendo Wii U";
                        break;
                    case 21:
                        ConsoleName = "Sony Playstation 2";
                        break;
                    case 22:
                        ConsoleName = "Microsoft Xbox";
                        break;
                    case 23:
                        ConsoleName = "Magnavox Odyssey 2";
                        break;
                    case 24:
                        ConsoleName = "Nintendo Pokemon Mini";
                        break;
                    case 25:
                        ConsoleName = "Atari 2600";
                        break;
                    case 26:
                        ConsoleName = "MS-DOS";
                        break;
                    case 27:
                        ConsoleName = "Arcade";
                        break;
                    case 28:
                        ConsoleName = "Nintendo Virtual Boy";
                        break;
                    case 29:
                        ConsoleName = "Microsoft MSX";
                        break;
                    case 30:
                        ConsoleName = "Commodore 64";
                        break;
                    case 31:
                        ConsoleName = "Spectrum ZX81";
                        break;
                    case 32:
                        ConsoleName = "Tangerine Oric";
                        break;
                    case 33:
                        ConsoleName = "Sega SG-1000";
                        break;
                    case 37:
                        ConsoleName = "Amstrad CPC";
                        break;
                    case 38:
                        ConsoleName = "Apple II";
                        break;
                    case 39:
                        ConsoleName = "Sega Saturn";
                        break;
                    case 40:
                        ConsoleName = "Sega Dreamcast";
                        break;
                    case 41:
                        ConsoleName = "Sony PSP";
                        break;
                    case 43:
                        ConsoleName = "3DO Interactive Multiplayer";
                        break;
                    case 44:
                        ConsoleName = "ColecoVision";
                        break;
                    case 45:
                        ConsoleName = "Mattel Intellivision";
                        break;
                    case 46:
                        ConsoleName = "GCE Vectrex";
                        break;
                    case 47:
                        ConsoleName = "PC-8000/8800";
                        break;
                    case 49:
                        ConsoleName = "NEC PC-FX";
                        break;
                    case 51:
                        ConsoleName = "Atari 7800";
                        break;
                    case 53:
                        ConsoleName = "WonderSwan";
                        break;
                    case 57:
                        ConsoleName = "Fairchild Channel F";
                        break;
                    case 63:
                        ConsoleName = "Watara Supervision";
                        break;
                    case 69:
                        ConsoleName = "Mega Duck";
                        break;
                    case 71:
                        ConsoleName = "Arduboy";
                        break;
                    case 72:
                        ConsoleName = "WASM-4";
                        break;
                    case 76:
                        ConsoleName = "NEC TurboGrafx-CD";
                        break;
                }

                _consoleId = value;
            }
        }
        public string BadgeUri { get; set; }
        public string ImageTitle { get; set; }
        public string ImageIngame { get; set; }
        public string ImageBoxArt { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string Genre { get; set; }
        public string Released { get; set; }
        public string ConsoleName { get; set; }
        public readonly List<Claim> Claims = new List<Claim>();
        public List<Achievement> Achievements { get; set; }
        public int AchievementsEarned
        {
            get
            {
                if (Achievements != null)
                {
                    return Achievements.FindAll(x => x.DateEarned.HasValue).Count;
                }
                return 0;
            }
        }
        public int AchievementsPossible
        {
            get
            {
                if (Achievements != null)
                {
                    return Achievements.Count;
                }
                return 0;
            }
        }
        public int GameTruePointsPossible
        {
            get
            {
                if (Achievements != null)
                {
                    return Achievements.Sum(x => x.TrueRatio);
                }
                return 0;
            }
        }
        public int GameTruePointsEarned
        {
            get
            {
                if (Achievements != null)
                {
                    return Achievements.FindAll(x => x.DateEarned.HasValue).Sum(x => x.TrueRatio);
                }
                return 0;
            }
        }
        public int GamePointsPossible
        {
            get
            {
                if (Achievements != null)
                {
                    return Achievements.Sum(x => x.Points);
                }
                return 0;
            }
        }
        public int GamePointsEarned
        {
            get
            {
                if (Achievements != null)
                {
                    return Achievements.FindAll(x => x.DateEarned.HasValue).Sum(x => x.Points);
                }
                return 0;
            }
        }
        public string PercentComplete
        {
            get
            {
                return (AchievementsEarned / (float)AchievementsPossible * 100f).ToString("0.00");
            }
        }
        public DateTime? LastPlayed { get; set; }

        public int CompareTo(GameInfo other)
        {
            if (other == null || !other.LastPlayed.HasValue)
            {
                return 1;
            }
            else if (!LastPlayed.HasValue)
            {
                return -1;
            }
            return other.LastPlayed.Value.CompareTo(LastPlayed.Value);
        }
    }
    public class Claim
    {
        public string User { get; set; }
        public int SetType { get; set; }
        public int ClaimType { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
    }
}
