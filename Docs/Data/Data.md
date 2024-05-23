# Data

The Data class is designed to manage URLs for API endpoints and scene paths, as well as other static configuration data for the game.

## Description

The Data class inherits from the Node2D. Its primary purpose is to store and provide access to various configuration settings such as API URLs, scene URLs, API headers, and texture paths. This class centralizes these configurations to simplify management and updates.

## Class Structure

- `Data` class:
  - Class variables:
    - `apiUrls`: A dictionary containing API endpoint URLs for login, score updates, and retrieving top scores.
    - `scenesUrls`: A dictionary containing paths to different scene resources used in the game.
    - `apiHeader`: An array containing the default API header for HTTP requests.
    - `texturePath`: A string representing the path to the character texture directory.
    - `defaultTexture`: A string representing the path to the default character texture.

## Class Variables

- **`apiUrls`**:
  - Type: `Godot.Collections.Dictionary<String, String>`
  - Contains:
    - `login`: URL for the login endpoint.
    - `scoreUpdate`: Base URL for updating the player's score.
    - `scoreGet`: URL for retrieving the top scores.

- **`scenesUrls`**:
  - Type: `Godot.Collections.Dictionary<String, String>`
  - Contains:
    - `selection`: Path to the scene for character selection.
    - `scores`: Path to the scene displaying scores.
    - `enemy`: Path to the scene for enemy interactions.

- **`apiHeader`**:
  - Type: `string[]`
  - Contains:
    - A single string specifying the content type for API requests: `"Content-Type: application/json"`.

- **`texturePath`**:
  - Type: `String`
  - Contains:
    - Path to the directory containing character textures: `"res://Sprites/Character/"`.

- **`defaultTexture`**:
  - Type: `String`
  - Contains:
    - Path to the default character texture: `"res://Sprites/Character/Doux.png"`.

## External Dependencies

- **Godot**: The class uses Godot's Node2D and collections for dictionaries.
  - `using Godot;`: This namespace is required to access Godot-specific classes and methods.
- **System**: The class uses the `System` namespace for basic .NET functionalities, including string operations.
  - `using System;`: This namespace is required for accessing system-level functions and data types.
