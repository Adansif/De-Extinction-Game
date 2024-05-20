using Godot;
using System;

public partial class Login : Control
{
	private HttpRequest request;
	private LineEdit username, password;
	private Button loginButton;
	private String apiUrl = "http://localhost:8082/api/v1/players/login";
	private Timer timer;
	private Label errorLabel;
	private AnimationPlayer animation;
	public override void _Ready()
	{
		username = this.GetNode<Panel>("./Panel").GetNode<VBoxContainer>("./VBoxContainer").GetNode<LineEdit>("./Username");
		password = this.GetNode<Panel>("./Panel").GetNode<VBoxContainer>("./VBoxContainer").GetNode<LineEdit>("./Password");
		loginButton = this.GetNode<Panel>("./Panel").GetNode<VBoxContainer>("./VBoxContainer").GetNode<Button>("./LoginButton");

		animation = this.GetNode<AnimationPlayer>("./Animations");
		timer = this.GetNode<Timer>("./Timer");
		errorLabel = this.GetNode<Label>("./ErrorLabel");

		request = this.GetNode<HttpRequest>("HTTPRequest");

		loginButton.Pressed += LoginRequest;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	private void LoginRequest(){

		var body = Json.Stringify(new Godot.Collections.Dictionary{
        	{ "name", username.Text },
        	{ "password", password.Text }
    	});

		string[] headers = new string[] { "Content-Type: application/json" };

		request.Request(apiUrl, headers, HttpClient.Method.Post, body);
	}

	private async void _on_http_request_request_completed(long result, long responseCode, string[] headers, byte[] body){
		var json = new Json();
		var parseResult = json.Parse(body.GetStringFromUtf8());
		if (parseResult != Error.Ok)
		{
			GD.Print($"Api request error: {json.GetErrorMessage()} in {body.GetStringFromUtf8()} at line {json.GetErrorLine()}");
			CredentialErrors();
			return;
		}

		var apiData = new Godot.Collections.Dictionary<string, Variant>((Godot.Collections.Dictionary)json.Data);

		if((String)apiData["name"] != username.Text || !(Boolean)apiData["password"] || !(Boolean)apiData["player"]){
			GD.Print("Nada de nada");
			CredentialErrors();
		}else{
			animation.Play("Login");
			//TODO: Add selection panel
			
		}
	}

	private void CredentialErrors(){
		errorLabel.Show();
		timer.Start();
	}

	private void _on_timer_timeout(){
		errorLabel.Hide();
	}
}