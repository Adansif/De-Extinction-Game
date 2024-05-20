using Godot;
using System;

public partial class IdleCharacter : Control
{
	[Export]
	private String texturePath;
	private Sprite2D sprite;
	private AnimationPlayer animation;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = this.GetNode<Sprite2D>("./Sprite");
		animation = this.GetNode<AnimationPlayer>("./Animation");

		sprite.Texture = GD.Load<Texture2D>(texturePath);

		animation.Play("Idle");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
