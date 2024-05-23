# Selection

The Selection class is designed to manage the character selection process allowing players to choose their character and start the game.

## Description

The Selection class inherits from the Control class provided by Godot. Its primary purpose is to handle the user interface for character selection, allowing players to choose from different character options, and initiate the game start process with the selected character.

## Class Structure

- `Selection` class:
  - Main method: `_Ready()`
  - Class variables:
    - `douxButton`: Stores the reference to the Button node for selecting the "Doux" character.
    - `mortButton`: Stores the reference to the Button node for selecting the "Mort" character.
    - `vitaButton`: Stores the reference to the Button node for selecting the "Vita" character.
    - `tardButton`: Stores the reference to the Button node for selecting the "Tard" character.
    - `startButton`: Stores the reference to the Button node for starting the game.
    - `animation`: Stores the reference to the AnimationPlayer node for playing animations.
    - `texturePath`: Stores the path to the selected character's texture, initialized to the default texture.
  - Methods:
    - `_Ready()`: Initializes various nodes, sets up button signals, and plays the entry animation.
    - `ChangeTexture(Button button)`: Changes the texture path based on the selected character button.
    - `StartGame()`: Handles the transition to the game start, including playing the start animation and setting up the player character.

## Main Logic

**Initialization (`_Ready()` method)**:
    - The `_Ready()` method is called when the node enters the scene tree for the first time.
    - It retrieves various nodes for character selection buttons, start button, and animation player.
    - It connects the `Pressed` signals of the character selection buttons to the `ChangeTexture` method.
    - It connects the `Pressed` signal of the start button to the `StartGame` method.
    - It plays the "Entry" animation and waits for its completion.

**Changing Texture (`ChangeTexture(Button button)` method)**:
    - This method is called when a character selection button is pressed.
    - It updates the `texturePath` based on the pressed button's name.
    - The texture path is constructed using the base path from `Data.texturePath` and the button's name.

**Starting the Game (`StartGame()` method)**:
    - This method is called when the start button is pressed.
    - It plays the "Start" animation and waits for its completion.
    - It retrieves the main script and player script from the scene tree.
    - It sets the player's sprite texture to the selected `texturePath` and updates the player's texture.
    - It starts the game's timer, sets the game state to playing, and removes the selection UI from the scene.

## External Dependencies

- **Godot**: The class uses Godot's Control, Button, AnimationPlayer, and various utility functions.
  - `using Godot;`: This namespace is required to access Godot-specific classes and methods.
- **System**: The class uses the `System` namespace for basic .NET functionalities.
  - `using System;`: This namespace is required for accessing system-level functions.
