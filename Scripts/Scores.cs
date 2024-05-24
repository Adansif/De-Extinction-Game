using Godot;
using System;

public partial class Scores : Control
{
    private Label goldScore, silverScore, bronzeScore;
    private HttpRequest request;
    private Button play, exit;
    private AnimationPlayer animation;
    private Godot.Collections.Dictionary<string, Variant> topScores;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// Initializes references to UI elements and sets up the play and exit button signals.
    /// </summary>
    public override void _Ready()
    {
        request = this.GetNode<HttpRequest>("./HTTPRequest");

        var verticalContainer = this.GetNode<Panel>("./Panel").GetNode<VBoxContainer>("./VBoxContainer");

        goldScore = verticalContainer.GetNode<TextureRect>("Gold").GetNode<Label>("Score");
        silverScore = verticalContainer.GetNode<TextureRect>("Silver").GetNode<Label>("Score");
        bronzeScore = verticalContainer.GetNode<TextureRect>("Bronze").GetNode<Label>("Score");

        animation = this.GetNode<AnimationPlayer>("./Animation");
        animation.Play("Entry");

        var buttonContainer = verticalContainer.GetNode<HBoxContainer>("./HBoxContainer");
        play = buttonContainer.GetNode<Button>("./Play");
        exit = buttonContainer.GetNode<Button>("./Exit");

        play.Pressed += PlayNewGame;
        exit.Pressed += ExitGame;

        ScoresRequest();
    }

    /// <summary>
    /// Sends a request to get the top scores from the server.
    /// </summary>
    private void ScoresRequest()
    {
        request.Request(Data.apiUrls["scoreGet"], Data.apiHeader, HttpClient.Method.Get);
    }

    /// <summary>
    /// Handles the completion of the HTTP request for scores.
    /// Parses the response and updates the score labels with the top scores.
    /// </summary>
    /// <param name="result">The result of the HTTP request.</param>
    /// <param name="responseCode">The response code from the server.</param>
    /// <param name="headers">The headers from the server response.</param>
    /// <param name="body">The body of the server response.</param>
    private void _on_http_request_request_completed(long result, long responseCode, string[] headers, byte[] body)
    {
        var json = new Json();
        var parseResult = json.Parse(body.GetStringFromUtf8());
        if (parseResult != Error.Ok)
        {
            GD.Print($"API request error: {json.GetErrorMessage()} in {body.GetStringFromUtf8()} at line {json.GetErrorLine()}");
            return;
        }

        topScores = new Godot.Collections.Dictionary<string, Variant>((Godot.Collections.Dictionary)json.Data);

        var arrayData = (Godot.Collections.Array)json.Data;

        var goldDictionary = (Godot.Collections.Dictionary<string, Variant>)arrayData[0];
        goldScore.Text = "Name: " + goldDictionary["name"] + "\nScore: " + goldDictionary["score"];

        var silverDictionary = (Godot.Collections.Dictionary<string, Variant>)arrayData[1];
        silverScore.Text = "Name: " + silverDictionary["name"] + "\nScore: " + silverDictionary["score"];

        var bronzeDictionary = (Godot.Collections.Dictionary<string, Variant>)arrayData[2];
        bronzeScore.Text = "Name: " + bronzeDictionary["name"] + "\nScore: " + bronzeDictionary["score"];
    }

    /// <summary>
    /// Exits the game by quitting the application.
    /// </summary>
    private void ExitGame()
    {
        this.GetTree().Quit();
    }

    /// <summary>
    /// Starts a new game by playing the exit animation, loading the selection scene, and removing the current scene.
    /// </summary>
    private async void PlayNewGame()
    {
        animation.Play("Leave");

        var selectionScript = (Selection)GD.Load<PackedScene>(Data.scenesUrls["selection"]).Instantiate();
        selectionScript.Position = new Vector2(this.Position.X - 500, this.Position.Y - 300);
        this.GetTree().GetFirstNodeInGroup("Main").GetNode<Camera2D>("./Camera").AddChild(selectionScript);

        await ToSignal(animation, "animation_finished");
        this.GetParent().RemoveChild(this);
    }
}
