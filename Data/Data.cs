using Godot;
using System;

public partial class Data : Node2D
{
	public static Godot.Collections.Dictionary<String, String> apiUrls = new Godot.Collections.Dictionary<String, String>{
		{ "login", "http://localhost:8082/api/v1/players/login" },
		{ "scoreUpdate", "http://localhost:8082/api/v1/players/" },
		{ "scoreGet", "http://localhost:8082/api/v1/players/topscores" },
	};
	public static Godot.Collections.Dictionary<String, String> scenesUrls = new Godot.Collections.Dictionary<String, String>{
		{ "selection", "res://Scenes/Selection.tscn" },
		{ "scores", "res://Scenes/Scores.tscn" },
		{ "enemy", "res://Scenes/Enemy.tscn" },
	};
	
	public static string[] apiHeader = new string[] { "Content-Type: application/json" };
	public static String texturePath = "res://Sprites/Character/";
	public static String defaultTexture = "res://Sprites/Character/Doux.png";
}
