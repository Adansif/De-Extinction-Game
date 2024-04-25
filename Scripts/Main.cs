using Godot;
using System;
using System.Numerics;

public partial class Main : Node2D
{
	private Random random = new();
	private CharacterBody2D player;
	private Timer timer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = this.GetNode<Timer>("./Timer");
		player = this.GetNode<CharacterBody2D>("./Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	private void _on_timer_timeout(){
		SpawnEnemy();
		
		var playerScript = (Player)player;
		if(playerScript.Speed < 6000){
			playerScript.Speed += 10;
		}

		timer.WaitTime = random.Next(1, 4);
	}

	private void SpawnEnemy(){
		var enemy = GD.Load<PackedScene>("res://Scenes/Enemy.tscn").Instantiate();
		var enemyScript = (Enemy)enemy;
		enemyScript.height = random.Next(100, 451);
		enemyScript.Scale = new Godot.Vector2(3, 3);
		this.AddChild(enemy);
		Timer timer = new();
	}
}
