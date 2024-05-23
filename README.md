# De-Extinction game

In this project, we will develop an "Infinite Runner" genre game based on the famous game provided by microsoft on Chrome Bbrowser.

## Project Description

The goal of this project is to develop a game where the user must avoid hitting the entities and survive for as long as he can. Upon starting the program, the user must login into his account to verify if he owns the game. Then choose a sprite for the character and start running.

This project utilizes Godot Engine classes and interfaces to achieve a flexible and extensible implementation.

## Project Objectives

- Implement a login logic for the user.
- Implement an automatic elimination strategy for the enemies.
- Implement HTTP request for updating the score.
- Infinite game where the player loose if the character hits a target.

## Project Structure

The project is organized into the following classes:

- `Data`: Class that store usable data for the game.
- `Camera`: Class in charge of the game camera logic and the score system.
- `GroundBody`: Class in charge of the body where the player's character move.
- `IdleCharacter`: Control class in charge of the selectable sprite for the character .
- `Login`: Class in charge of handling the login request to the API.
- `Main`: Main class in chargee of spawning enemies.
- `Player`: Class in charge of controlling the character and update the score on the database through the API.
- `Scores`: Class in charge of handling the score request from the API and show the 3 top scores.
- `Selection`: Class in charge of selecting the sprite after login and everytime the player play.

## Documentation

[Data](./Docs/Data/Data.md)
[Camera](./Docs/Scripts/Camera.md)
[Enemy](./Docs/Scripts/Enemy.md)
[GroundBody](./Docs/Scripts/GroundBody.md)
[IdleCharacter](./Docs/Scripts/IdleCharacter.md)
[Login](./Docs/Scripts/Login.md)
[Main](./Docs/Scripts/Main.md)
[Player](./Docs/Scripts/Player.md)
[Scores](./Docs/Scripts/Scores.md)
[Selection](./Docs/Scripts/Selection.md)
