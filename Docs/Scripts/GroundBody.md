# GroundBody

The GroundBody class is designed to manage the ground's behavior and positioning in relation to the player's position.

## Description

The GroundBody class inherits from the StaticBody2D class. Its primary purpose is to update the ground's position based on the player's horizontal position, ensuring that the ground moves consistently under the player.

## Class Structure

- `GroundBody` class:
  - Main method: `_Process(double delta)`
  - Class variables:
    - `player`: Stores the reference to the player's CharacterBody2D node.
  - Methods:
    - `_Ready()`: Initializes the player variable by retrieving the player's node from the scene tree.
    - `_Process(double delta)`: Updates the ground's position every frame to follow the player's horizontal movement.

## Main Logic

**Initialization (`_Ready()` method)**:
    - The `_Ready()` method is called when the node enters the scene tree for the first time.
    - It retrieves the player node by accessing the first node in the "Main" group and then locating the `CharacterBody2D` node named "Player".
    - This ensures the ground has a reference to the player's node for position updates.

**Frame Update (`_Process(double delta)` method)**:
    - The `_Process()` method is called every frame with `delta` being the elapsed time since the previous frame.
    - It updates the ground's `Position` to match the player's `X` position while maintaining its current `Y` position.
    - This keeps the ground horizontally aligned with the player, creating the effect of the ground moving with the player.

## External Dependencies

- **Godot**: The class uses Godot's StaticBody2D, CharacterBody2D, and various utility functions. Godot is a game engine used for creating 2D and 3D games.
  - `using Godot;`: This namespace is required to access Godot-specific classes and methods.
