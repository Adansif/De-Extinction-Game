# IdleCharacter

The IdleCharacter class is designed to manage the display and animation of a character in an idle state.

## Description

The IdleCharacter class inherits from the Control class provided by Godot. Its primary purpose is to load a texture for the character, apply it to a sprite, and play an idle animation when the node enters the scene tree.

## Class Structure

- `IdleCharacter` class:
  - Main method: `_Ready()`
  - Class variables:
    - `texturePath`: Stores the path to the character's texture, which is exported for easy configuration in the Godot editor.
    - `sprite`: Stores the reference to the Sprite2D node for the character.
    - `animation`: Stores the reference to the AnimationPlayer node for the character's animations.
  - Methods:
    - `_Ready()`: Initializes the sprite and animation variables, loads the texture, and starts the idle animation.

## Main Logic

**Initialization (`_Ready()` method)**:
    - The `_Ready()` method is called when the node enters the scene tree for the first time.
    - It retrieves the sprite node and assigns it to the `sprite` variable.
    - It retrieves the animation player node and assigns it to the `animation` variable.
    - It loads the texture from the specified `texturePath` and assigns it to the sprite's texture.
    - It plays the "Idle" animation using the animation player.

## External Dependencies

- **Godot**: The class uses Godot's Control, Sprite2D, AnimationPlayer, and various utility functions. Godot is a game engine used for creating 2D and 3D games.
  - `using Godot;`: This namespace is required to access Godot-specific classes and methods.
- **System**: The class uses the `System` namespace for basic .NET functionalities.
  - `using System;`: This namespace is required for accessing system-level functions.
