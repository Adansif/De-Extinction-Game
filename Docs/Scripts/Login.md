# Login

The Login class is designed to handle the login functionality, including user input validation, sending login requests to a server, and handlinga response.

## Description

The Login class inherits from the Control class provided by Godot. Its primary purpose is to manage user authentication by capturing username and password inputs, sending these credentials to an API, and processing the API's response. If the login is successful, it triggers an animation and transitions to a new scene. If the login fails, it displays an error message.

## Class Structure

- `Login` class:
  - Main method: `_Ready()`
  - Class variables:
    - `request`: Stores the HttpRequest node for sending HTTP requests.
    - `username`: Stores the reference to the LineEdit node for the username input.
    - `password`: Stores the reference to the LineEdit node for the password input.
    - `loginButton`: Stores the reference to the Button node for triggering the login request.
    - `timer`: Stores the reference to the Timer node for timing error message display.
    - `errorLabel`: Stores the reference to the Label node for displaying error messages.
    - `animation`: Stores the reference to the AnimationPlayer node for playing animations.
    - `player`: Stores the reference to the CharacterBody2D node representing the player.
  - Methods:
    - `_Ready()`: Initializes various nodes and connects the login button to the login request method.
    - `LoginRequest()`: Gathers user input, formats it into a JSON body, and sends a login request to the API.
    - `_on_http_request_request_completed(long result, long responseCode, string[] headers, byte[] body)`: Event that processes the server's response to the login request.
    - `CredentialErrors()`: Displays an error message when login credentials are incorrect.
    - `_on_timer_timeout()`: Event that hides the error message after a timeout.

## Main Logic

**Initialization (`_Ready()` method)**:
    - The `_Ready()` method is called when the node enters the scene tree for the first time.
    - It retrieves various nodes: player, username, password, loginButton, animation, timer, errorLabel, and request.
    - It connects the `Pressed` signal of the `loginButton` to the `LoginRequest()` method.

**Login Request (`LoginRequest()` method)**:
    - Gathers the username and password from the respective input fields.
    - Formats the credentials into a JSON string.
    - Sends an HTTP POST request to the server's login endpoint with the credentials.

**Request Completion Handling (`_on_http_request_request_completed(long result, long responseCode, string[] headers, byte[] body)`)**:
    - Parses the server's response.
    - If the response indicates an error or invalid credentials, it calls `CredentialErrors()`.
    - If the login is successful, it plays the "Login" animation and transitions to the selection scene.
    - Updates the main script with the user's credentials and removes the login node from the scene.

**Credential Errors (`CredentialErrors()` method)**:
    - Displays the error message label.
    - Starts the timer to hide the error message after a set period.

**Timer Timeout (`_on_timer_timeout()` method)**:
    - Hides the error message label when the timer times out.

## External Dependencies

- **Godot**: The class uses Godot's Control, HttpRequest, LineEdit, Button, Timer, Label, AnimationPlayer, CharacterBody2D, and various utility functions.
  - `using Godot;`: This namespace is required to access Godot-specific classes and methods.
- **System**: The class uses the `System` namespace for basic .NET functionalities.
  - `using System;`: This namespace is required for accessing system-level functions.
