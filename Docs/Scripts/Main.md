# Main

The Main class is designed to manage the main gameplay loop, including spawning enemies and adjusting the player's speed.

## Description

The Main class inherits from the Node2D class provided by Godot. Its primary purpose is to handle the game's main logic, such as spawning enemies at random intervals and increasing the player's speed. It also manages game state variables like the player's name, password, and score.

## Class Structure

- `Main` class:
  - Main method: `_on_timer_timeout()`
  - Class variables:
    - `random`: An instance of the Random class for generating random numbers.
    - `timer`: Stores the reference to the Timer node for controlling enemy spawn intervals.
    - `isPlaying`: A boolean flag indicating whether the game is currently being played.
    - `name`: Stores the player's name.
    - `password`: Stores the player's password.
    - `score`: Stores the player's score.
  - Methods:
    - `_Ready()`: Initializes the timer variable by retrieving the Timer node.
    - `_on_timer_timeout()`: Called when the timer times out, responsible for spawning enemies and increasing the player's speed.
    - `SpawnEnemy()`: Instantiates and configures an enemy node, then adds it to the scene.

## Main Logic

**Initialization (`_Ready()` method)**:
    - The `_Ready()` method is called when the node enters the scene tree for the first time.
    - It retrieves the Timer node and assigns it to the `timer` variable.

**Timer Timeout (`_on_timer_timeout()` method)**:
    - The `_on_timer_timeout()` method is called when the timer times out.
    - It calls the `SpawnEnemy()` method to create and add a new enemy to the scene.
    - It retrieves the player script and increases the player's speed if it is below 6000.
    - It sets a new random wait time for the timer between 1 and 4 seconds.

**Spawning Enemies (`SpawnEnemy()` method)**:
    - Loads the enemy scene from the resource path defined in `Data.scenesUrls`.
    - Instantiates the enemy and sets its height to a random value between 100 and 451.
    - Scales the enemy by a factor of 3.
    - Adds the enemy to the current scene as a child node.

## External Dependencies

- **Godot**: The class uses Godot's Node2D, Timer, Random, and various utility functions.
  - `using Godot;`: This namespace is required to access Godot-specific classes and methods.
- **System**: The class uses the `System` namespace for basic .NET functionalities, including the Random class.
  - `using System;`: This namespace is required for accessing system-level functions.
