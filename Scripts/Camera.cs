using Godot;
using System;

public partial class Camera : Camera2D
{
	private CharacterBody2D player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = this.GetParent().GetNode<CharacterBody2D>("./Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Position = new Vector2(player.Position.X + 700, this.Position.Y);
	}
}
