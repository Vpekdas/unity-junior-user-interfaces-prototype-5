# unity-junior-user-interfaces-prototype-5

## Screenshots

https://github.com/user-attachments/assets/8d31cd72-c651-43f0-bde8-66cc16106b22

## Table of Contents
1. [Description](#description)
2. [Installation](#installation)
3. [Run](#run)
4. [Credits](#credits)
5. [Contributing](#contributing)
6. [License](#license)

## Description

This prototype is part of the Junior Programmer Pathway from Unity Learn. Its purpose is to teach the fundamentals of gameplay mechanics through scripting in C#.
Each prototype includes:
- A Learning section that guides you through building core features step by step.
- A Challenge section where you're given a broken or incomplete project to fix and extend, testing your understanding and problem-solving skills.

### Purpose

The objective of this prototype is to create two simple games:

- **Crates Ninja** : Slash crates with your mouse as they fly across the screen—but watch out for the skulls! Hitting one will cost you.
- **Whack-a-Food** : Click on the food items as quickly as possible as they pop up! The faster you are, the higher your score.

#### Bonus Features (Crates Ninja) :

- Create a "Lives" UI element that counts down by 1 when an object leaves the bottom of the screen and triggers Game Over when Lives reaches 0.
- Add background music and a UI Slider element to adjust the volume.
- During gameplay, allow the user to press a key to toggle between pausing and resuming the game, where a pause screen comes up while the game is paused. 
- Program click-and-swipe functionality instead of clicking, generating a trail where the mouse has been dragged. This does make the game easier, so you might also want to increase the gameplay difficulty on all levels if you implement this.

#### Fixing problems (Whack-a-Food) : 

- The difficulty buttons look messy -> Center the text on the buttons horizontally and vertically.
- The food is being destroyed too soon -> The food should only be destroyed when the player clicks on it, not when the mouse touches it.
- The Score is being replaced by the word “score” -> It should always say, “Score: __“ with the value displayed after “Score:”.
- When you lose, there’s no way to Restart -> Make the Restart button appear on the game over screen.
- The difficulty buttons don’t change the difficulty -> The spawnRate is always way too fast. When you click Easy, the spawnRate should be slower - if you click Hard, the spawnRate should be faster.
- The game can go on forever -> Add a “Time: __” display that counts down from 60 in whole numbers (i.e. 59, 58, 57, etc) and triggers the game over sequence when it reaches 0.

## Controls

**Crates Ninja**
| **Key** | **Action**    |
|:-------:|---------------|
| `Escape`| Pause the Game|
| `Q`     |Quit the game  |

Click and drag your mouse to slash through the crates.

**Whack-a-Food**
| **Key** | **Action**    |
|:-------:|---------------|
| `Q`     |Quit the game  |

Simply click on the food items as they appear.

### Technologies used

- **Unity** – Version 6000.0.47f1
- **C#** – Used for gameplay scripting
  
### Challenges and Future Features

One of the biggest challenges in this project was implementing the slashing trail effect in Crates Ninja. I discovered Unity's Trail Renderer, which was a great help. The next step was figuring out how to accurately track the mouse's start and end positions in order to draw the trail effectively.

Another key step was converting the screen position of the mouse to world coordinates.

## Installation

You can download pre-built releases for your supported operating system from the GitHub Releases page. Available builds include:
- macOS
- Windows
- Linux

## Run

To run the program, simply double-click the executable file for your operating system.

### MacOS

Unzip and open the .app file.

### Windows

Unzip and double-click the .exe file.

### Linux

```bash
chmod +x Prototype_5_Linux.x86_64
./Prototype_5_Linux.x86_64
```

### Web

Play on [browser](https://vpekdas.github.io/unity-junior-user-interfaces-prototype-5)

## Credits

This project is based on the Unity **Junior Programmer Pathway** by Unity Learn.
Many thanks to the instructors for their excellent step-by-step video tutorials and guidance.

## Contributing

To report issues, please create an issue here:  [issue tracker](https://github.com/Vpekdas/unity-junior-user-interfaces-prototype-5/issues).

If you'd like to contribute, please follow the steps outlined in [CONTRIBUTING.md](CONTRIBUTING.md).

## License

This project is licensed under the [MIT License](LICENSE).
