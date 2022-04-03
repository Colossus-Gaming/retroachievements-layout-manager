using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class AchievementListController
    {
        private static AchievementListController instance = new AchievementListController();
        private static AchievementListWindow AchievementListWindow;
        public static bool IsOpen;
        private List<Achievement> CurrentUnlockedAchievements;
        private List<Achievement> CurrentLockedAchievements;

        private AchievementListController()
        {
            AchievementListWindow = new AchievementListWindow();

            CurrentUnlockedAchievements = new List<Achievement>();
            CurrentLockedAchievements = new List<Achievement>();

            IsOpen = false;
        }
        public static AchievementListController Instance
        {
            get
            {
                return instance;
            }
        }
        public void Close()
        {
            AchievementListWindow.Close();
        }
        public void Show()
        {
            if (!IsOpen)
            {
                AchievementListWindow = new AchievementListWindow();

                CurrentUnlockedAchievements = new List<Achievement>();
                CurrentLockedAchievements = new List<Achievement>();

                AchievementListWindow.Show();
            }
        }

        public void SetAllSettings()
        {
            AchievementListWindow.SetWindowBackgroundColor(WindowBackgroundColor);
        }

        public async void UpdateAchievementList(List<Achievement> unlockedAchievements, List<Achievement> lockedAchievements, bool newGame)
        {
            if (IsOpen)
            {
                int size = unlockedAchievements.Count + lockedAchievements.Count;

                unlockedAchievements.Sort();
                unlockedAchievements.Reverse();

                lockedAchievements.Sort();

                if (newGame)
                {
                    List<Achievement> ToClearList = new List<Achievement>();
                    ToClearList.AddRange(CurrentUnlockedAchievements);
                    ToClearList.AddRange(CurrentLockedAchievements);

                    CurrentUnlockedAchievements = new List<Achievement>();
                    CurrentLockedAchievements = new List<Achievement>();

                    Random rand = new Random();

                    int timeoutValue = 0;

                    Dictionary<int, int> idsToTimeouts = new Dictionary<int, int>();

                    while (ToClearList.Count > 0 && timeoutValue <= 1000)
                    {
                        Achievement achievement = ToClearList[rand.Next(ToClearList.Count - 1)];
                        idsToTimeouts.Add(achievement.Id, timeoutValue);

                        timeoutValue += 10;

                        ToClearList.RemoveAt(ToClearList.IndexOf(achievement));
                    }

                    while (ToClearList.Count > 0)
                    {
                        Achievement achievement = ToClearList[rand.Next(ToClearList.Count - 1)];

                        idsToTimeouts.Add(achievement.Id, 800 + rand.Next(200));
                        ToClearList.RemoveAt(ToClearList.IndexOf(achievement));
                    }

                    AchievementListWindow.ClearAchievements(idsToTimeouts);

                    await Task.Delay(1000);
                }

                for (int i = 0; i < unlockedAchievements.Count; i++)
                {
                    Achievement newAchievement = (Achievement)unlockedAchievements[i].Clone();
                    Achievement oldAchievement = CurrentLockedAchievements.Find(achievement1 => achievement1.Id == newAchievement.Id);

                    if (CurrentUnlockedAchievements.Find(achievement1 => achievement1.Id == newAchievement.Id) == null)
                    {
                        CurrentUnlockedAchievements.Add(newAchievement);

                        if (oldAchievement == null)
                        {
                            AchievementListWindow.AddAchievement(newAchievement, GetImageSize(unlockedAchievements.Count + lockedAchievements.Count), GetAchievementLocationX(i, size), GetAchievementLocationY(i, size) + 1048);
                        } else
                        {
                            AchievementListWindow.UnlockAchievement(oldAchievement);
                            CurrentLockedAchievements.Remove(oldAchievement);
                        }
                    }
                }

                for (int i = 0; i < lockedAchievements.Count; i++)
                {
                    if (CurrentLockedAchievements.Find(achievement1 => achievement1.Id == lockedAchievements[i].Id) == null)
                    {
                        Achievement newAchievement = (Achievement)lockedAchievements[i].Clone();

                        CurrentLockedAchievements.Add(newAchievement);

                        AchievementListWindow.AddAchievement(newAchievement, GetImageSize(unlockedAchievements.Count + lockedAchievements.Count), GetAchievementLocationX(unlockedAchievements.Count + i, size), GetAchievementLocationY(unlockedAchievements.Count + i, size) + 1048);
                    }
                }

                if (CurrentUnlockedAchievements.Count > 0 || CurrentLockedAchievements.Count > 0)
                {
                    AnimateAchievementList();
                }
            }
        }
        public void AnimateAchievementList()
        {
            if (IsOpen)
            {
                int size = CurrentUnlockedAchievements.Count + CurrentLockedAchievements.Count;
                int interval = 4000 / size;

                CurrentUnlockedAchievements.Sort();
                CurrentUnlockedAchievements.Reverse();

                Dictionary<Achievement, ValueTuple<int, int, int>> achievementAndCoordinates = new Dictionary<Achievement, (int, int, int)>();
                int timeoutValue = -20;
                int lastY = GetAchievementLocationY(0, size);

                for (int i = 0; i < CurrentUnlockedAchievements.Count; i++)
                {
                    timeoutValue += 20;

                    int xCoord = GetAchievementLocationX(i, size);
                    int yCoord = GetAchievementLocationY(i, size);

                    if (yCoord != lastY)
                    {
                        lastY = yCoord;
                        timeoutValue += 50;
                    }

                    achievementAndCoordinates.Add(CurrentUnlockedAchievements[i], ValueTuple.Create(xCoord, yCoord, timeoutValue));
                }

                CurrentLockedAchievements.Sort();

                for (int i = 0; i < CurrentLockedAchievements.Count; i++)
                {
                    timeoutValue += 20;

                    int xCoord = GetAchievementLocationX(CurrentUnlockedAchievements.Count + i, size);
                    int yCoord = GetAchievementLocationY(CurrentUnlockedAchievements.Count + i, size);

                    if (yCoord != lastY)
                    {
                        lastY = yCoord;
                        timeoutValue += 50;
                    }

                    achievementAndCoordinates.Add(CurrentLockedAchievements[i], ValueTuple.Create(xCoord, yCoord, timeoutValue));
                }

                AchievementListWindow.SetAchievementPositions(achievementAndCoordinates);
            }
        }
        private int GetAchievementLocationX(int achievementIndex, int size)
        {
            return 10 + (achievementIndex % Convert.ToInt32(Math.Sqrt(size))) * GetImageSize(size);
        }
        private int GetAchievementLocationY(int achievementIndex, int size)
        {
            return 10 + (achievementIndex / Convert.ToInt32(Math.Sqrt(size))) * GetImageSize(size);
        }
        public bool AutoLaunch
        {
            get
            {
                return Settings.Default.auto_achievement_list;
            }
            set
            {
                Settings.Default.auto_achievement_list = value;
                Settings.Default.Save();
            }
        }
        public string BorderBackgroundColor
        {
            get
            {
                return Settings.Default.achievement_list_border_color;
            }
            set
            {
                Settings.Default.achievement_list_border_color = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    AchievementListWindow.SetBorderBackgroundColor(value);
                }
            }
        }
        public string WindowBackgroundColor
        {
            get
            {
                return Settings.Default.achievement_list_window_background_color;
            }
            set
            {
                Settings.Default.achievement_list_window_background_color = value;
                Settings.Default.Save();
                if (IsOpen)
                {
                    AchievementListWindow.SetWindowBackgroundColor(value);
                }
            }
        }
        public bool ColumnEnabled
        {
            get
            {
                return Settings.Default.achievement_list_column_enabled;
            }
            set
            {
                Settings.Default.achievement_list_column_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    AnimateAchievementList();
                }
            }
        }
        public int ContainerCount
        {
            get
            {
                return Settings.Default.achievement_list_container_count;
            }
            set
            {
                Settings.Default.achievement_list_container_count = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    AnimateAchievementList();
                }
            }
        }
        public bool OptimizeEnabled
        {
            get
            {
                return Settings.Default.achievement_list_optimize_enabled;
            }
            set
            {
                Settings.Default.achievement_list_optimize_enabled = value;
                Settings.Default.Save();

                if (IsOpen)
                {
                    AnimateAchievementList();
                }
            }
        }
        public int ColumnCount
        {
            get
            {
                return Convert.ToInt32(Math.Sqrt(CurrentUnlockedAchievements.Count + CurrentLockedAchievements.Count));
            }
        }
        public int GetImageSize(int listSize)
        {
            return 760 / Convert.ToInt32(Math.Ceiling(Math.Sqrt(listSize)));
        }
    }
}
