using Godot;
using System;

public partial class Login : Control
{
    private HttpRequest request;
    private LineEdit username, password;
    private Button loginButton;
    private Timer timer;
    private Label errorLabel;
    private AnimationPlayer animation;

    private CharacterBody2D player;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// Initializes references to UI elements and sets up the login button's pressed signal.
    /// </summary>
    public override void _Ready()
    {
        player = (CharacterBody2D)this.GetTree().GetFirstNodeInGroup("Player");

        username = this.GetNode<Panel>("./Panel").GetNode<VBoxContainer>("./VBoxContainer").GetNode<LineEdit>("./Username");
        password = this.GetNode<Panel>("./Panel").GetNode<VBoxContainer>("./VBoxContainer").GetNode<LineEdit>("./Password");
        loginButton = this.GetNode<Panel>("./Panel").GetNode<VBoxContainer>("./VBoxContainer").GetNode<Button>("./LoginButton");

        animation = this.GetNode<AnimationPlayer>("./Animations");
        timer = this.GetNode<Timer>("./Timer");
        errorLabel = this.GetNode<Label>("./ErrorLabel");

        request = this.GetNode<HttpRequest>("./HTTPRequest");

        loginButton.Pressed += LoginRequest;
    }

    /// <summary>
    /// Initiates the login request with the username and password entered by the user.
    /// Sends the data to the specified API endpoint.
    /// </summary>
    private void LoginRequest()
    {
        var body = Json.Stringify(new Godot.Collections.Dictionary
        {
            { "name", username.Text },
            { "password", PasswordHasher.HashPassword(password.Text)}
        });

        request.Request(Data.apiUrls["login"], Data.apiHeader, HttpClient.Method.Post, body);
    }

    /// <summary>
    /// Handles the completion of the HTTP request.
    /// Processes the response from the API and handles successful or failed login attempts.
    /// </summary>
    /// <param name="result">The result of the HTTP request.</param>
    /// <param name="responseCode">The response code from the server.</param>
    /// <param name="headers">The headers from the server response.</param>
    /// <param name="body">The body of the server response.</param>
    private async void _on_http_request_request_completed(long result, long responseCode, string[] headers, byte[] body)
    {
        var json = new Json();
        var parseResult = json.Parse(body.GetStringFromUtf8());

        if (parseResult != Error.Ok)
        {
            GD.Print($"API request error: {json.GetErrorMessage()} in {body.GetStringFromUtf8()} at line {json.GetErrorLine()}");
            CredentialErrors();
            return;
        }

        var apiReturnedData = new Godot.Collections.Dictionary<string, Variant>((Godot.Collections.Dictionary)json.Data);

        if ((String)apiReturnedData["name"] != username.Text || !(Boolean)apiReturnedData["password"] || !(Boolean)apiReturnedData["player"])
        {
            GD.Print("Invalid credentials");
            CredentialErrors();
        }
        else
        {
            animation.Play("Login");
            var selectionScript = (Selection)GD.Load<PackedScene>(Data.scenesUrls["selection"]).Instantiate();
            selectionScript.Position = new Vector2(this.Position.X - 500, this.Position.Y - 300);
            this.GetParent().AddChild(selectionScript);

            var mainNode = this.GetTree().GetFirstNodeInGroup("Main");
            var mainScript = (Main)mainNode;

            mainScript.name = this.username.Text;
            mainScript.password = this.password.Text;

            await ToSignal(animation, "animation_finished");
            this.GetParent().RemoveChild(this);
        }
    }

    /// <summary>
    /// Displays an error message when login credentials are incorrect.
    /// </summary>
    private void CredentialErrors()
    {
        errorLabel.Show();
        timer.Start();
    }

    /// <summary>
    /// Hides the error message when the timer times out.
    /// </summary>
    private void _on_timer_timeout()
    {
        errorLabel.Hide();
    }
}
