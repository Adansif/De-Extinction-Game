using Godot;
using System;

public partial class Scores : Control
{
	private Label goldScore, silverScore, bronzeScore;
	private HttpRequest request;
	private Button start, close;
	private string apiUrl = "http://localhost:8082/api/v1/players/topscores";

	private Godot.Collections.Dictionary<string, Variant> topScores;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		request = this.GetNode<HttpRequest>("./HTTPRequest");
		goldScore = this.GetNode<Panel>("./Panel").GetNode<VBoxContainer>("./VBoxContainer").GetNode<TextureRect>("Gold").GetNode<Label>("Score");
		silverScore = this.GetNode<Panel>("./Panel").GetNode<VBoxContainer>("./VBoxContainer").GetNode<TextureRect>("Silver").GetNode<Label>("Score");
		bronzeScore = this.GetNode<Panel>("./Panel").GetNode<VBoxContainer>("./VBoxContainer").GetNode<TextureRect>("Bronze").GetNode<Label>("Score");

		ScoresRequest();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void ScoresRequest(){

		string[] headers = new string[] { "Content-Type: application/json" };

		request.Request(apiUrl, headers, HttpClient.Method.Get);
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
}
