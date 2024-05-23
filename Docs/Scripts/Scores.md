# Scores

The Scores class is designed to display the top scores and handle the transition to a new game or exit.

## Description

The Scores class inherits from the Control class provided by Godot. Its primary purpose is to retrieve and display the top scores from a server, and provide options to start a new game or exit the application. The class also handles animations for entering and leaving the scores screen.

## Class Structure

- `Scores` class:
  - Main method: `_Ready()`
  - Class variables:
    - `goldScore`: Stores the reference to the Label node for the gold score.
    - `silverScore`: Stores the reference to the Label node for the silver score.
    - `bronzeScore`: Stores the reference to the Label node for the bronze score.
    - `request`: Stores the reference to the HttpRequest node for sending HTTP requests.
    - `play`: Stores the reference to the Button node for starting a new game.
    - `exit`: Stores the reference to the Button node for exiting the game.
    - `animation`: Stores the reference to the AnimationPlayer node for playing animations.
    - `topScores`: Stores the top scores retrieved from the server.
  - Methods:
    - `_Ready()`: Initializes various nodes, sets up button signals, and starts the scores request.
    - `ScoresRequest()`: Sends a request to the server to retrieve the top scores.
    - `_on_http_request_request_completed(long result, long responseCode, string[] headers, byte[] body)`: Event that processes the API's response and updates the scores display.
    - `ExitGame()`: Exits the application.
    - `PlayNewGame()`: Handles the transition to a new game.

## Main Logic

**Initialization (`_Ready()` method)**:
    - The `_Ready()` method is called when the node enters the scene tree for the first time.
    - It retrieves various nodes for displaying scores, playing animations, and handling button presses.
    - It connects the `Pressed` signals of the `play` and `exit` buttons to their respective methods.
    - It starts the scores request to retrieve the top scores from the server.

**Scores Request (`ScoresRequest()` method)**:
    - This method sends an HTTP GET request to the server to retrieve the top scores.
    - The URL and headers for the request are defined in the `Data.apiUrls` and `Data.apiHeader` respectively.

**Handling HTTP Request Completion (`_on_http_request_request_completed(long result, long responseCode, string[] headers, byte[] body)` method)**:
    - This method handles the server's response to the scores request.
    - It parses the JSON response and extracts the top scores.
    - It updates the `goldScore`, `silverScore`, and `bronzeScore` labels with the retrieved scores.

**Exiting the Game (`ExitGame()` method)**:
    - This method quits the application by calling `GetTree().Quit()`.

**Playing a New Game (`PlayNewGame()` method)**:
    - This method plays the "Leave" animation and transitions to the game selection screen.
    - It loads the selection scene, positions it, and adds it as a child to the camera node.
    - After the animation finishes, it removes the scores node from the parent.

## External Dependencies

- **Godot**: The class uses Godot's Control, Label, HttpRequest, Button, AnimationPlayer, and various utility functions.
  - `using Godot;`: This namespace is required to access Godot-specific classes and methods.
- **System**: The class uses the `System` namespace for basic .NET functionalities.
  - `using System;`: This namespace is required for accessing system-level functions.
