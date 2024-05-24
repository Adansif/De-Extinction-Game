# Camera

The Camera class is designed to manage the camera's position and display the player's points.

## Description

The Camera class inherits from the Camera2D class provided by Godot. Its primary purpose is to follow the player's character and update the displayed points in real-time. This class ensures that the camera remains focused on the player and the points label reflects the current score.

## Class Structure

- `Camera` class:
  - Main method: `_Process(double delta)`
  - Class variables:
    - `player`: Stores the reference to the player's CharacterBody2D node.
    - `points`: Stores the reference to the Label node displaying the player's points.
  - Methods:
    - `_Ready()`: Initializes the player and points variables by retrieving their respective nodes.
    - `_Process(double delta)`: Updates the camera's position and the points label every frame.

## Main Logic

**Initialization (`_Ready()` method)**:
    - The `_Ready()` method is called when the node enters the scene tree for the first time.
    - It retrieves the player node by accessing its parent node and then locating the `CharacterBody2D` node named "Player".
    - It retrieves the points label node named "Points".

**Frame Update (`_Process(double delta)` method)**:
    - The `_Process()` method is called every frame with `delta` being the elapsed time since the previous frame.
    - The camera's `Position` is updated to follow the player's `X` position, offset by 700 units, while maintaining its current `Y` position.
    - The points label's text is updated to display the player's current points, which are converted to a string and floored to an integer.

## External Dependencies

- **Godot**: The class uses Godot's Camera2D, CharacterBody2D, Label, and various utility functions.
  - `using Godot;`: This namespace is required to access Godot-specific classes and methods.
- **System**: The class uses the `System` namespace for basic .NET functionalities, including mathematical operations.
  - `using System;`: This namespace is required for accessing system-level functions like `Math.Floor`.
