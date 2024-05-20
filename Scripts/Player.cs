using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private AnimationPlayer animation;
	private Sprite2D sprite;
	public String spriteTexture;
	public float Speed = 400.0f;
	public float points = 0;
	public const float JumpVelocity = -800.0f;
	private bool IsDead {get; set;} = false;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready(){
		animation = GetNode<AnimationPlayer>("./PlayerAnimation");
		sprite = this.GetNode<Sprite2D>("./PlayerSprite");
	}

	public override async void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (IsDead){
				await ToSignal(animation, "animation_finished");
				IsDead = false;
		}

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		
		Vector2 direction = new Vector2(1, 0);

		animation.Play("Walk");
		
		velocity.X = direction.X * Speed;

		if(((Main)this.GetTree().GetFirstNodeInGroup("Main")).isPlaying){
			points += (float)delta;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private void _on_player_area_body_entered(Node2D body){
		if( body is Enemy){
			Die();
		}
	}

	private void Die(){
		IsDead = true;
		animation.Play("Hit");
	}

	public void ChangeTexture(){
		sprite.Texture = GD.Load<Texture2D>(spriteTexture);
	}
}
