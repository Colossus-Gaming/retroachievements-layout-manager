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
        private bool IsAnimating;

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

        }

        public async void UpdateAchievementList(List<Achievement> unlockedAchievements, List<Achievement> lockedAchievements, bool newGame)
        {

            if (IsOpen)
            {
                if (newGame)
                {
                    List<Achievement> ToClearList = new List<Achievement>();
                    ToClearList.AddRange(CurrentUnlockedAchievements);
                    ToClearList.AddRange(CurrentLockedAchievements);

                    CurrentUnlockedAchievements = new List<Achievement>();
                    CurrentLockedAchievements = new List<Achievement>();

                    Random rand = new Random();

                    while (ToClearList.Count > 0)
                    {
                        Achievement achievement = ToClearList[rand.Next(ToClearList.Count - 1)];
                        AchievementListWindow.ClearAchievement(achievement.Id);

                        ToClearList.RemoveAt(ToClearList.IndexOf(achievement));

                        await Task.Delay(20);
                    }

                    await Task.Delay(500);

                    AchievementListWindow.ClearList();
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
                            AchievementListWindow.AddAchievement(newAchievement, GetImageSize(unlockedAchievements.Count + lockedAchievements.Count));
                        }
                    }
                    else
                    {
                        AchievementListWindow.UnlockAchievement(newAchievement);
                    }

                    if (oldAchievement != null)
                    {
                        CurrentLockedAchievements.Remove(oldAchievement);
                    }
                }

                for (int i = 0; i < lockedAchievements.Count; i++)
                {
                    if (CurrentLockedAchievements.Find(achievement1 => achievement1.Id == lockedAchievements[i].Id) == null)
                    {
                        Achievement newAchievement = (Achievement)lockedAchievements[i].Clone();

                        CurrentLockedAchievements.Add(newAchievement);

                        AchievementListWindow.AddAchievement(newAchievement, GetImageSize(unlockedAchievements.Count + lockedAchievements.Count));
                    }
                }

                if (CurrentUnlockedAchievements.Count > 0 || CurrentLockedAchievements.Count > 0)
                {
                    AnimateAchievementList();
                }
            }
        }
        public async void AnimateAchievementList()
        {
            if (IsOpen && !IsAnimating)
            {
                IsAnimating = true;

                CurrentUnlockedAchievements.Sort();
                CurrentUnlockedAchievements.Reverse();

                for (int i = 0; i < CurrentUnlockedAchievements.Count; i++)
                {
                    AchievementListWindow.UnlockAchievement(CurrentUnlockedAchievements[i]);
                    AchievementListWindow.SetAchievementPosition(CurrentUnlockedAchievements[i].Id, GetAchievementLocationX(i), GetAchievementLocationY(i));
                    await Task.Delay(30);
                }

                CurrentLockedAchievements.Sort();

                for (int i = 0; i < CurrentLockedAchievements.Count; i++)
                {
                    AchievementListWindow.SetAchievementPosition(CurrentLockedAchievements[i].Id, GetAchievementLocationX(i + CurrentUnlockedAchievements.Count), GetAchievementLocationY(i + CurrentUnlockedAchievements.Count));
                    await Task.Delay(30);
                }

                IsAnimating = false;
            }
        }
        private int GetAchievementLocationX(int achievementIndex)
        {
            return 10 + (achievementIndex % Convert.ToInt32(Math.Sqrt(CurrentUnlockedAchievements.Count + CurrentLockedAchievements.Count))) * GetImageSize(CurrentUnlockedAchievements.Count + CurrentLockedAchievements.Count);
        }
        private int GetAchievementLocationY(int achievementIndex)
        {
            return 10 + (achievementIndex / Convert.ToInt32(Math.Sqrt(CurrentUnlockedAchievements.Count + CurrentLockedAchievements.Count))) * GetImageSize(CurrentUnlockedAchievements.Count + CurrentLockedAchievements.Count);
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
