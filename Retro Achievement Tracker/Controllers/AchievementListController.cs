using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class AchievementListController
    {
        private static readonly AchievementListController instance = new AchievementListController();
        private static AchievementListWindow AchievementListWindow;

        private readonly int AchievementsPerRow = 11;

        public bool IsOpen;

        private List<Achievement> CurrentUnlockedAchievements;
        private List<Achievement> CurrentLockedAchievements;

        private AchievementListController()
        {
            AchievementListWindow = new AchievementListWindow();

            CurrentUnlockedAchievements = new List<Achievement>();
            CurrentLockedAchievements = new List<Achievement>();
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
            IsOpen = false;
        }
        public void Show()
        {
            if (!IsOpen)
            {
                if (AchievementListWindow == null || AchievementListWindow.IsDisposed)
                {
                    AchievementListWindow = new AchievementListWindow();
                }
                AchievementListWindow.Show();
            }
        }

        public void SetAllSettings()
        {
            AchievementListWindow.SetWindowBackgroundColor(WindowBackgroundColor);
            AchievementListWindow.SetClientSize();
        }

        public void UpdateAchievementList()
        {
            UpdateAchievementList(CurrentUnlockedAchievements, CurrentLockedAchievements, true);

        }

        public async void UpdateAchievementList(List<Achievement> unlockedAchievements, List<Achievement> lockedAchievements, bool newGame)
        {
            unlockedAchievements.Sort();
            unlockedAchievements.Reverse();

            lockedAchievements.Sort();
            lockedAchievements.Reverse();

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

                while (ToClearList.Count > 0 && timeoutValue <= 1600)
                {
                    Achievement achievement = ToClearList[rand.Next(ToClearList.Count - 1)];
                    idsToTimeouts.Add(achievement.Id, timeoutValue);

                    timeoutValue += 10;

                    ToClearList.RemoveAt(ToClearList.IndexOf(achievement));
                }

                while (ToClearList.Count > 0)
                {
                    Achievement achievement = ToClearList[rand.Next(ToClearList.Count - 1)];

                    idsToTimeouts.Add(achievement.Id, 1000 + rand.Next(600));
                    ToClearList.RemoveAt(ToClearList.IndexOf(achievement));
                }

                if (IsOpen)
                {
                    AchievementListWindow.StopScrolling();

                    await Task.Delay(200);

                    AchievementListWindow.ClearAchievements(idsToTimeouts);

                    await Task.Delay(timeoutValue + 800);

                    AchievementListWindow.WipeOldAchievements();
                }
            }

            int achievementRowIndex = 0;
            int xCoord = 0;
            int yCoord = 0;

            for (int i = 0; i < unlockedAchievements.Count; i++)
            {
                Achievement newAchievement = (Achievement)unlockedAchievements[i].Clone();
                Achievement oldAchievement = CurrentLockedAchievements.Find(achievement1 => achievement1.Id == newAchievement.Id);

                if (CurrentUnlockedAchievements.Find(achievement1 => achievement1.Id == newAchievement.Id) == null)
                {
                    CurrentUnlockedAchievements.Add(newAchievement);

                    if (oldAchievement == null)
                    {
                        if (IsOpen)
                        {
                            AchievementListWindow.AddAchievement(newAchievement, xCoord, yCoord);

                            xCoord += 68;
                            achievementRowIndex++;

                            if (achievementRowIndex > AchievementsPerRow - 1)
                            {
                                xCoord = 0;
                                yCoord += 68;
                                achievementRowIndex = 0;
                            }
                        }
                    }
                    else
                    {
                        if (IsOpen)
                        {
                            AchievementListWindow.UnlockAchievement(newAchievement);
                        }
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
                    if (IsOpen)
                    {
                        AchievementListWindow.AddAchievement(newAchievement, xCoord, yCoord);

                        xCoord += 68;
                        achievementRowIndex++;

                        if (achievementRowIndex > AchievementsPerRow - 1)
                        {
                            xCoord = 0;
                            yCoord += 68;
                            achievementRowIndex = 0;
                        }
                    }
                }
            }

            if (IsOpen && (CurrentUnlockedAchievements.Count > 0 || CurrentLockedAchievements.Count > 0))
            {
                AnimateAchievementList();
            }
        }
        public async void AnimateAchievementList()
        {
            int achievementRowIndex = 0;
            int yCoord = 0;
            int xCoord = 0;

            CurrentUnlockedAchievements.Sort();
            CurrentUnlockedAchievements.Reverse();

            CurrentLockedAchievements.Sort();
            CurrentLockedAchievements.Reverse();

            for (int i = 0; i < CurrentUnlockedAchievements.Count; i++)
            {
                AchievementListWindow.SetAchievementPosition(CurrentUnlockedAchievements[i], xCoord, yCoord);

                xCoord += 68;
                achievementRowIndex++;

                if (achievementRowIndex > AchievementsPerRow - 1)
                {
                    xCoord = 0;
                    yCoord += 68;
                    achievementRowIndex = 0;
                }

                if(yCoord <= 612)
                {
                    await Task.Delay(50);
                }
            }

            for (int i = 0; i < CurrentLockedAchievements.Count; i++)
            {
                AchievementListWindow.SetAchievementPosition(CurrentLockedAchievements[i], xCoord, yCoord);

                xCoord += 68;
                achievementRowIndex++;

                if (achievementRowIndex > AchievementsPerRow - 1)
                {
                    xCoord = 0;
                    yCoord += 68;
                    achievementRowIndex = 0;
                }

                if (yCoord <= 612)
                {
                    await Task.Delay(50);
                }
            }

            if (AutoScroll)
            {
                await Task.Delay(1000);
                AchievementListWindow.StartScrolling();

                AchievementListWindow.AssignJavaScriptVariables();
            }
        }
        public bool AutoScroll
        {
            get
            {
                return Settings.Default.achievement_list_auto_scroll;
            }
            set
            {
                Settings.Default.achievement_list_auto_scroll = value;
                Settings.Default.Save();

                if (value)
                {
                    AchievementListWindow.StartScrolling();
                }
                else
                {
                    AchievementListWindow.StopScrolling();
                }
            }
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

                SetAllSettings();
            }
        }
    }
}
