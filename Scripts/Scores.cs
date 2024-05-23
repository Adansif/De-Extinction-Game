using Godot;
using System;

public partial class Scores : Control
{
	private Label goldScore, silverScore, bronzeScore;
	private HttpRequest request;
	private Button play, exit;
	private AnimationPlayer animation;
	private Godot.Collections.Dictionary<string, Variant> topScores;
	// Called when the node enters the scene tree for the first time.
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

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void ScoresRequest(){
		request.Request(Data.apiUrls["scoreGet"], Data.apiHeader, HttpClient.Method.Get);
	}

	private void _on_http_request_request_completed(long result, long responseCode, string[] headers, byte[] body){
		var json = new Json();
		var parseResult = json.Parse(body.GetStringFromUtf8());
		if (parseResult != Error.Ok)
		{
			GD.Print($"Api request error: {json.GetErrorMessage()} in {body.GetStringFromUtf8()} at line {json.GetErrorLine()}");
			return;
		}

		topScores = new Godot.Collections.Dictionary<string, Variant>((Godot.Collections.Dictionary)json.Data);

		var arrayData = (Godot.Collections.Array)json.Data;

		var goldDitionary = (Godot.Collections.Dictionary<string, Variant>)arrayData[0];
		goldScore.Text = "Name: " + goldDitionary["name"] + "     Score: " + goldDitionary["score"];

		var silverDitionary = (Godot.Collections.Dictionary<string, Variant>)arrayData[1];
		silverScore.Text = "Name: " + silverDitionary["name"] + "     Score: " + silverDitionary["score"];

		var bronzeDitionary = (Godot.Collections.Dictionary<string, Variant>)arrayData[2];
		bronzeScore.Text = "Name: " + bronzeDitionary["name"] + "     Score: " + bronzeDitionary["score"];

	}

	private void ExitGame(){
		this.GetTree().Quit();
	}

	private async void PlayNewGame(){
		animation.Play("Leave");

		var selectionScript = (Selection)GD.Load<PackedScene>(Data.scenesUrls["selection"]).Instantiate();
		selectionScript.Position = new Vector2(this.Position.X - 500, this.Position.Y - 300);
		this.GetTree().GetFirstNodeInGroup("Main").GetNode<Camera2D>("./Camera").AddChild(selectionScript);

		await ToSignal(animation, "animation_finished");
		this.GetParent().RemoveChild(this);
	}
}
