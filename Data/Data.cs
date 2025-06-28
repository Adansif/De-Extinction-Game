using Godot;
using System;

public partial class Data : Node2D
{
	public static Godot.Collections.Dictionary<String, String> apiUrls = new Godot.Collections.Dictionary<String, String>{
		{ "login", "de-extinction-api-production.up.railway.app/api/v1/players/login" },
		{ "scoreUpdate", "de-extinction-api-production.up.railway.app/api/v1/players/" },
		{ "scoreGet", "de-extinction-api-production.up.railway.app/api/v1/players/topscores" },
	};
	public static Godot.Collections.Dictionary<String, String> scenesUrls = new Godot.Collections.Dictionary<String, String>{
		{ "selection", "res://Scenes/Selection.tscn" },
		{ "scores", "res://Scenes/Scores.tscn" },
		{ "enemy", "res://Scenes/Enemy.tscn" },
	};
	
	public static string[] apiHeader = new string[] { "Content-Type: application/json" };
	public static String texturePath = "res://Assets/Sprites/Character/";
	public static String defaultTexture = "res://Assets/Sprites/Character/Doux.png";
}
