using Godot;
using System;

public partial class Enemy : StaticBody2D
{
	private CharacterBody2D player;
	private Node main;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		main = this.GetParent();
		player = main.GetNode<CharacterBody2D>("./Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (this.Position.X < player.Position.X - 200.0f){
			main.RemoveChild(this);
		}
	}
}
