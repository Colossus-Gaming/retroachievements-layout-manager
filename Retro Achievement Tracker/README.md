# Retro Achievements Tracker

Tracker for hunting [Retro Achievements](https://retroachievements.org) and enchancing live-streaming layouts with Retro Achievement data about your profile and the game you're currently playing. Provides pre-rendered and animated windows to provide notifications when achievements unlock and other values (rank, ratio, awards, etc.) change.

## Control Window
![Default View](https://i.imgur.com/NDmt0ps.png)

The main window to control the Tracker.
- `Auto-Start` Will automatically start the tracking update timer when the app is started.
- `Username` Your Retro Achievements username.
- `API Key` The API key found on your [Retro Achievements Settings](https://retroachievements.org/controlpanel.php) page.
- `Start` Start the tracking update timer to poll the Retro Achievements API for user and game data.
- `Stop` Stop the tracking update timer.
- `NEWS` If checked, will populate RSS feed with RA News.
- `FORUM` If checked, will populate RSS feed with RA Forum activity.
- `CHEEVO` If checked, will populate RSS feed with new achievement activity.
- `FRIENDS` If checked, will populate RSS feed with friend activity.
- `Auto-Open` Will automatically open the associated window when the app is started.
- `Open` Opens the respective window.
- `Custom` Opens the customization panel for the associated window.

## Focus Window
Window for focusing on a particular achievement.

`Focus Window`

![Focus Window](https://i.imgur.com/lH4I2iO.png)

`Focus Customization`

![Focus Customization](https://i.imgur.com/FXzYV1b.png)

- `Back Set` Changes the background color of the window.
- `Border Set` Changes the background color of the border around the achievement.
- `Simple` If not checked, will allow for individual font/color selection for `title`, `description`, `points`, and the separator `line`.
- `Border` Enabled/Disable the achievement border. Otherwise, applies settings to all elements.
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.

## Alerts Window
Window for showing animated alerts when a tracker timer update detects new achievement unlocks. Also includes a Mastery alert when all achievements are unlocked on an update. The custom video is played over the 

`Alerts Window Prompt` 
#### Chromium requires a user interact with a page before video elements will play. The video type should be `.webm` extention for best usage.
![Alerts Window](https://i.imgur.com/eZGSB8m.png)

`Alerts Window Achievement Pop`

![Alerts Window 2](https://i.imgur.com/gT5w6hV.png)

`Alerts Window Customization`

![Alerts Customization](https://i.imgur.com/1qv26eK.png)

- `Back Set` Changes the background color of the window.
- `Border Set` Changes the background color of the border around the achievement.
- `Simple` If not checked, will allow for individual font/color selection for `title`, `description`, `points`, and the separator `line`.
- `Border` Enabled/Disable the achievement border. Otherwise, applies settings to all elements.
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.
- `Replay` Replays the last achievement earned or a mastery alert respectively.
- `Custom` If enabled, will allow for a custom alert for achievement pop and set mastery.
- `File` Allows for updating the custom achievement `.webm` file.
- `Edit` If enabled, will show the custom alert file to make adjust position and scale easier.
- `Position X` Sets the `left` position for the alert video.
- `Position Y` Sets the `top` position for the alert video.
- `Scale` Sets the scale of the alert video.
- `In & Out Animation` Controls the time marks, animation speed, and animation direction that the achievement/mastery will move into and out of the screen respectively from the start of the alert.

## Recent Achievements Window
Window for displaying the most recent achievements in your current game.

`Recent Achievements Window`

![Recent Achievements Window](https://i.imgur.com/O6XLUtm.png)

`Recent Achievements Customization`

![Recent Achievements Window 2](https://i.imgur.com/gf5Sojl.png)

- `Back Set` Changes the background color of the window.
- `Border Set` Changes the background color of the border around the achievement.
- `Simple` If not checked, will allow for individual font/color selection for `title`, `description`, `points`, and the separator `line`.
- `Border` Enabled/Disable the achievement border. Otherwise, applies settings to all elements.
- `Auto-Scroll` Enabled/Disable auto-scrolling when the list has more than five achievements in it.
- `Max List Size` The maximum number of achievements to add to the list. `Min: 5, Max: 20`
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.

## Achievement List Window
Window for displaying the achievement list of your current game as it appears on the Retro Achievements user profiles. Hovering over an achievement will give a similar tooltip.

`Achievement List Window`

![Achievement List Window](https://i.imgur.com/TvkIgaz.png)

`Achievement List Customization`

![Achievement List Window 2](https://i.imgur.com/8EqL7ZQ.png)

- `Back Set` Changes the background color of the window.
- `Auto-Scroll` Enabled/Disable auto-scrolling when the list has more than 99 achievements in it.

## User Info Window
Window for displaying user information such as rank and total points earned.

`User Info Window`

![User Info Window](https://i.imgur.com/VdyLBsK.png)

`User Info Customization`

![User Info Window 2](https://i.imgur.com/Zsa4DGb.png)

- `Back Set` Changes the background color of the window.
- `Border Set` Toggles the border around the achievement.
- `Simple` If not checked, will allow for individual font/color selection for `name` and `value`.
- `Border` Enabled/Disable the achievement border.
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.
- `Label Text` Allows the user to override label names or disable them completely.

## Game Info Window
Window for displaying game information such as the developer, genre, and release date.

`Game Info Window`

![Game Info Window](https://i.imgur.com/WvY5Orx.png)

`Game Info Customization`

![Game Info Window 2](https://i.imgur.com/nGAMg95.png)

- `Back Set` Changes the background color of the window.
- `Border Set` Toggles the border around the achievement.
- `Simple` If not checked, will allow for individual font/color selection for `name` and `value`.
- `Border` Enabled/Disable the achievement border.
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.
- `Label Text` Allows the user to override label names or disable them completely.

## Game Stats Window
Window for displaying game stats as it pertains to your progress. This includes the number of achievements or points you've earned for that game.

`Game Stats Window`

![Game Stats Window](https://i.imgur.com/R8RMDj7.png)

`Game Stats Customization`

![Game Stats Window 2](https://i.imgur.com/OHYMlLO.png)

- `Back Set` Changes the background color of the window.
- `Border Set` Toggles the border around the achievement.
- `Simple` If not checked, will allow for individual font/color selection for `name` and `value`.
- `Border` Enabled/Disable the achievement border.
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.
- `Label Text` Allows the user to override label names or disable them completely.

## Browser/RSS Feed
Built-In browser and RSS feed reader. The browser can be opened manually by clicking the `Open` button or by clicking on a browser-sensitive icon.

`Built-In Browser`

![Retro Achievements Site](https://i.imgur.com/JygDq3L.png)

`RSS News Preview`

![RSS Feed News Preview](https://i.imgur.com/sge3drR.png)

# Browser-Sensitive Icons
- Profile pic: navigates to user's profile page on Retro Achievements.
- Game icon: navigates to the game's page on Retro Achievements.
- Focus icon: navigates to the achievement's page on Retro Achievements.
- RSS Feed `NEWS` renders a preview of content. All other types go directy to the activity on Retro Achievements.

## Text Files
Text files are generated in the `stream-labels` folder. There are individual files for most values and a `data.json` file is generated with top-level information from the Retro Achievements API.


`Text File Generation`

![Retro Achievements Site](https://i.imgur.com/paXp1BX.png)

### data.json File Examples
`alerts`
```javascript
{
   "id":1929,
   "gameId":236,
   "gameTitle":"Super Metroid",
   "title":"Professional Escape",
   "description":"Escape planet Zebes with at least 2 minutes remaining",
   "points":50,
   "trueRatio":338,
   "badgeNumber":"02322",
   "hardcoreAchieved":false,
   "displayOrder":43
}
```
`focus`
```javascript
{
   "id":1929,
   "gameId":236,
   "gameTitle":"Super Metroid",
   "title":"Professional Escape",
   "description":"Escape planet Zebes with at least 2 minutes remaining",
   "points":50,
   "trueRatio":338,
   "badgeNumber":"02322",
   "hardcoreAchieved":false,
   "displayOrder":43
}
```
`game-info`
```javascript
{
   "id":236,
   "title":"Super Metroid",
   "consoleId":3,
   "imageIcon":"/Images/042861.png",
   "imageTitle":"/Images/000159.png",
   "imageIngame":"/Images/000031.png",
   "imageBoxArt":"/Images/014410.png",
   "publisher":"Nintendo",
   "developer":"Nintendo R&D1, Intelligent Systems",
   "genre":"Action-adventure, Platform-adventure",
   "released":"March 19, 1994",
   "consoleName":"SNES",
   "achievementsEarned":49,
   "achievementsPossible":52,
   "gameTruePointsPossible":1380,
   "gameTruePointsEarned":678,
   "gamePointsPossible":487,
   "gamePointsEarned":362,
   "percentComplete":"94.23"
}
```
`last-five`
```javascript
{
   "id":1929,
   "gameId":236,
   "gameTitle":"Super Metroid",
   "title":"Professional Escape",
   "description":"Escape planet Zebes with at least 2 minutes remaining",
   "points":50,
   "trueRatio":338,
   "badgeNumber":"02322",
   "hardcoreAchieved":false,
   "displayOrder":43
}
```
`user-info`
```javascript
{
   "lastGameID":236,
   "totalPoints":24682,
   "totalTruePoints":80704,
   "rank":1864,
   "awards":16,
   "userPic":"/UserPic/RetroS3xual.png",
   "retroRatio":"3.27%"
}
```