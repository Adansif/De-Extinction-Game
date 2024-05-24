# Player

The Player class is designed to manage the player's character, including movement, animation, and interactions with enemies.

## Description

The Player class inherits from the CharacterBody2D class. Its primary purpose is to handle the player's movement, manage animations, update the score, and respond to collisions with enemies. The class also communicates with a server to update the player's score upon collisions.

## Class Structure

- `Player` class:
  - Main method: `_PhysicsProcess(double delta)`
  - Class variables:
    - `animation`: Stores the reference to the AnimationPlayer node for managing animations.
    - `sprite`: Stores the reference to the Sprite2D node for displaying the player's sprite.
    - `spriteTexture`: Stores the path to the player's sprite texture.
    - `request`: Stores the reference to the HttpRequest node for sending HTTP requests.
    - `defaultSpeed`: The default speed of the player.
    - `Speed`: The current speed of the player.
    - `points`: The player's score, incremented over time.
    - `JumpVelocity`: The velocity applied when the player jumps.
    - `IsDead`: A boolean flag indicating whether the player is dead.
    - `gravity`: The gravity applied to the player, synced with project settings.
  - Methods:
    - `_Ready()`: Initializes various nodes and sets the player's speed.
    - `_PhysicsProcess(double delta)`: Handles the player's movement and updates the score.
    - `_on_player_area_body_entered(Node2D body)`: Event that triggers when the player collides with an enemy.
    - `ChangeTexture()`: Changes the player's sprite texture.
    - `ScoreUpdateRequest()`: Event that sends a score update request to the API.
    - `_on_http_request_request_completed(long result, long responseCode, string[] headers, byte[] body)`: Handles the API's response to the score update request and manages post-death logic.

## Main Logic

**Initialization (`_Ready()` method)**:
    - The `_Ready()` method is called when the node enters the scene tree for the first time.
    - It retrieves the HttpRequest, AnimationPlayer, and Sprite2D nodes.
    - It sets the player's speed to the default speed.

**Physics Process (`_PhysicsProcess(double delta)` method)**:
    - The `_PhysicsProcess()` method is called every physics frame with `delta` being the elapsed time since the previous frame.
    - It updates the player's velocity based on gravity and user input.
    - If the player is dead, it waits for the animation to finish and resets the player's speed and death status.
    - If the player is not on the floor, gravity is applied to the vertical velocity.
    - If the jump action is pressed and the player is on the floor, the jump velocity is applied.
    - The player's horizontal velocity is set based on the speed and a constant direction.
    - The walking animation is played.
    - If the game is in play mode, the player's points are incremented over time.
    - The player's velocity is applied, and the character is moved and slides based on collisions.

**Collision Handling (`_on_player_area_body_entered(Node2D body)` method)**:
    - This method is triggered when the player collides with another body.
    - If the body is an enemy, the score update request is sent to the server.

**Changing Texture (`ChangeTexture()` method)**:
    - This method changes the player's sprite texture based on the `spriteTexture` path.

**Score Update Request (`ScoreUpdateRequest()` method)**:
    - This method sends an HTTP PUT request to the server to update the player's score.

**Handling HTTP Request Completion (`_on_http_request_request_completed(long result, long responseCode, string[] headers, byte[] body)` method)**:
    - This method handles the server's response to the score update request.
    - If the player is dead, it stops the game, resets the score, plays the hit animation, and transitions to the score display scene.
    - It also stops the enemy spawn timer, removes all enemies, and hides the player.

## External Dependencies

- **Godot**: The class uses Godot's CharacterBody2D, AnimationPlayer, Sprite2D, HttpRequest, Timer, and various utility functions.
  - `using Godot;`: This namespace is required to access Godot-specific classes and methods.
- **System**: The class uses the `System` namespace for basic .NET functionalities.
  - `using System;`: This namespace is required for accessing system-level functions.
