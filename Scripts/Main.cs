using Godot;
using System;
using System.Numerics;

public partial class Main : Node2D
{
	private Random random = new();
	public Timer timer;
	public Boolean isPlaying = false;

	public String name, password, score;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = this.GetNode<Timer>("./Timer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	private void _on_timer_timeout(){
		SpawnEnemy();
		
		var playerScript = (Player)this.GetTree().GetFirstNodeInGroup("Player");
		if(playerScript.Speed < 6000){
			playerScript.Speed += 30;
		}

		timer.WaitTime = random.Next(1, 4);
	}

	private void SpawnEnemy(){
		var enemy = GD.Load<PackedScene>(Data.scenesUrls["enemy"]).Instantiate();
		var enemyScript = (Enemy)enemy;
		enemyScript.height = random.Next(100, 451);
		enemyScript.Scale = new Godot.Vector2(3, 3);
		this.AddChild(enemy);
		Timer timer = new();
	}
}
