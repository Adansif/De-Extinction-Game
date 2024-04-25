using Godot;
using System;
using System.Numerics;

public partial class GroundBody : StaticBody2D
{
	private CharacterBody2D player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = this.GetTree().GetFirstNodeInGroup("Main").GetNode<CharacterBody2D>("./Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Position = new Godot.Vector2(player.Position.X, this.Position.Y);
	}
}
