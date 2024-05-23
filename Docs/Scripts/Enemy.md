# Enemy

The Enemy class is designed to manage the behavior and positioning of enemy entities.

## Description

The Enemy class inherits from the StaticBody2D class provided by Godot Engine. Its primary purpose is to position the enemy relative to the player's position and remove the enemy from the scene when it disappear from the screen.

## Class Structure

- `Enemy` class:
  - Main method: `_Process(double delta)`
  - Class variables:
    - `height`: Stores the vertical position value for the enemy.
    - `player`: Stores the reference to the player's CharacterBody2D node.
    - `main`: Stores the reference to the parent node.
  - Methods:
    - `_Ready()`: Initializes the player and main variables by retrieving their respective nodes and sets the initial position of the enemy.
    - `_Process(double delta)`: Checks the enemy's position each frame and removes it from the scene if it moves too far behind the player.

## Main Logic

**Initialization (`_Ready()` method)**:
    - The `_Ready()` method is called when the node enters the scene tree for the first time.
    - It retrieves the parent node and assigns it to the `main` variable.
    - It retrieves the player node by accessing the parent node and then locating the `CharacterBody2D` node named "Player".
    - It sets the enemy's initial position to be 1600 units ahead of the player's `X` position and at the specified `height`.

**Frame Update (`_Process(double delta)` method)**:
    - The `_Process()` method is called every frame with `delta` being the elapsed time since the previous frame.
    - It checks if the enemy's `X` position is less than the player's `X` position minus 200 units.
    - If the condition is met, the enemy is removed from its parent node, effectively removing it from the scene.

## External Dependencies

- **Godot**: The class uses Godot's StaticBody2D, CharacterBody2D, Node, and various utility functions.
  - `using Godot;`: This namespace is required to access Godot-specific classes and methods.
