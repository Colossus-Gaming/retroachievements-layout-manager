# Retro Achievements Tracker

Tracker for hunting [Retro Achievements](https://retroachievements.org) and enchancing live-streaming layouts with Retro Achievement data about your profile and the game you're currently playing. Provides windows to provide notifications when achievements unlock as well as other values (rank, ratio, awards, etc.) change.

## Main Window
![Default/Focus View](https://i.imgur.com/NT0q1ns.png)

The main window to control the Tracker.
- `Auto-Start` Will automatically start the tracking update timer when the app is started.
- `Username` Your Retro Achievements username.
- `Web API Key` The API key found on your [Retro Achievements Settings](https://retroachievements.org/controlpanel.php) page.
- `Start` Start the tracking update timer to poll the Retro Achievements API for user and game data.
- `Stop` Stop the tracking update timer.

## Focus Window
Window for focusing on a particular achievement.

`Focus Window`

![Focus Window](https://i.imgur.com/PFcoU9J.png)

`Focus Customization`

- `Window Background` Changes the background color of the window.
- `Border` Changes the background color as well as enable/disable of the border around the achievement.
- `Advanced` If checked, will allow for individual font/color selection for `title`, `description`, `points`, and the separator `line`.
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.

## Alerts Window
Window for showing animated alerts when a tracker timer update detects new achievement unlocks. Also includes a Mastery alert when all achievements are unlocked on an update. The custom video is played over the 

`Alerts Window` 
#### Chromium requires a user interact with a page before video elements will play. The video type should be `.webm` extention for best usage.
![Alerts Window](https://i.imgur.com/gcdeyWL.png)

`Alerts Window Achievement Pop`

![Alerts Window 2](https://i.imgur.com/WLWF61k.png)

`Alerts Window Customization`

- `Window Background` Changes the background color of the window.
- `Border` Changes the background color as well as enable/disable of the border around the achievement.
- `Advanced` If checked, will allow for individual font/color selection for `title`, `description`, `points`, and the separator `line`.
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.
- `Play` Replays the last achievement earned or a mastery alert respectively.
- `Custom` If enabled, will allow for a custom alert for achievement pop and set mastery.
- `File` Allows for updating the custom achievement `.webm` file.
- `Edit` If enabled, will show the custom alert file to make adjust position and scale easier.
- `X Position` Sets the `left` position for the alert video.
- `Y Position` Sets the `top` position for the alert video.
- `Scale` Sets the scale of the alert video.
- `Animate In Time` The time in milliseconds that the alert video at which the achievement/mastery information should begin to animate towards the center.
- `Animate In Duration` The amount of time in milliseconds that the achievement/mastery information should animate inward for.
- `Animate In Direction` The direction the achievement should animate in. If set to STATIC, AnimateInDuration has no effect.
- `Animate Out Time` The time in milliseconds that the alert video at which the achievement/mastery information should begin to animate away from the center.
- `Animate Out Duration` The amount of time in milliseconds that the achievement/mastery information should animate outward for.
- `Animate Out Direction` The direction the achievement should animate out. If set to STATIC, AnimateOutDuration has no effect.

## Recent Unlocks Window
Window for displaying the most recent achievements in your current game.

`Recent Unlocks Window`

![Recent Unlocks Window](https://i.imgur.com/7CII4ub.png)

`Recent Unlocks Customization`

![Recent Unlocks Window 2](https://i.imgur.com/vUfCdKT.png)

- `Window Background` Changes the background color of the window.
- `Border` Changes the background color as well as enable/disable of the border around the achievement.
- `Advanced` If checked, will allow for individual font/color selection for `title`, `description`, `points`, and the separator `line`.
- `Auto-Scroll` Enabled/Disable auto-scrolling when the list has more than five achievements in it.
- `Max List Size` The maximum number of achievements to add to the list. `Min: 5, Max: 20`
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.

## Achievement List Window
Window for displaying the achievement list of your current game as it appears on the Retro Achievements user profiles. Hovering over an achievement will give a similar tooltip.

`Achievement List Window`

![Achievement List Window](https://i.imgur.com/7nk6LeA.png)

`Achievement List Customization`

![Achievement List Window 2](https://i.imgur.com/IdQ4C4f.png)

- `Window Background` Changes the background color of the window.
- `Auto-Scroll` Enabled/Disable auto-scrolling when the list has more than 99 achievements in it.

## User Info Window
Window for displaying user information such as rank and total points earned.

`User Info Window`

![User Info Window](https://i.imgur.com/UfwvG9m.png)

`User Info Customization`

![User Info Window 2](https://i.imgur.com/680B5Q3.png)

- `Window Background` Changes the background color of the window.
- `Advanced` If checked, will allow for individual font/color selection for `name` and `value`.
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.
- `Display Text` Allows the user to override label names or disable them completely.

## Game Info Window
Window for displaying game information such as the developer, genre, and release date.

`Game Info Window`

![Game Info Window](https://i.imgur.com/19oHdx5.png)

`Game Info Customization`

![Game Info Window 2](https://i.imgur.com/IrREADv.png)

- `Window Background` Changes the background color of the window.
- `Advanced` If checked, will allow for individual font/color selection for `name` and `value`.
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.
- `Display Text` Allows the user to override label names or disable them completely.

## Game Progress Window
Window for displaying game stats as it pertains to your progress. This includes the number of achievements or points you've earned for that game.

`Game Progress Window`

![Game Progress Window](https://i.imgur.com/TtFmtcI.png)

`Game Progress Customization`

![Game Progress Window 2](https://i.imgur.com/hqvwejj.png)

- `Window Background` Changes the background color of the window.
- `Advanced` If checked, will allow for individual font/color selection for `name` and `value`.
- Font customization allows for changing `Font Family`, `Font Color`, `Font Outline`, `Font Outline Color`, and `Font Outline Size`.
- `Display Text` Allows the user to override label names or disable them completely.

# Browser-Sensitive Icons
- Profile pic: navigates to user's profile page on Retro Achievements.
- Game icon: navigates to the game's page on Retro Achievements.
- Focus icon: navigates to the achievement's page on Retro Achievements.

## Text Files
Text files are generated in the `stream-labels` folder. There are individual files for most values and a `data.json` file is generated with top-level information from the Retro Achievements API.

`Text File Generation`

![Generated Text Files](https://i.imgur.com/paXp1BX.png)

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
