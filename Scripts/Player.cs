using Godot;
using System;
using System.ComponentModel;

public partial class Player : CharacterBody2D
{
	private AnimationPlayer animation;
	private Sprite2D sprite;
	public String spriteTexture;
	private HttpRequest request;
	private float defaultSpeed= 400.0f;
	public float Speed;
	public float points = 0;
	public const float JumpVelocity = -800.0f;
	private bool IsDead {get; set;} = false;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready(){
		request = this.GetNode<HttpRequest>("./HTTPRequest");
		animation = GetNode<AnimationPlayer>("./PlayerAnimation");
		sprite = this.GetNode<Sprite2D>("./PlayerSprite");

		Speed = defaultSpeed;
	}

	public override async void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (IsDead){
				await ToSignal(animation, "animation_finished");
				Speed = defaultSpeed;
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
			ScoreUpdateRequest();
		}
	}

	public void ChangeTexture(){
		sprite.Texture = GD.Load<Texture2D>(spriteTexture);
	}

	private void ScoreUpdateRequest(){
		request.Request((Data.apiUrls["scoreUpdate"] + ((Main)this.GetParent()).name + "/" + (int)Math.Floor(this.points)), Data.apiHeader, HttpClient.Method.Put);
	}

	private async void _on_http_request_request_completed(long result, long responseCode, string[] headers, byte[] body){
		IsDead = true;

		((Main)this.GetTree().GetFirstNodeInGroup("Main")).isPlaying = false;
		this.points = 0;

		animation.Play("Hit");
		await ToSignal(animation, "animation_finished");

		var mainScript = (Main)this.GetParent();
		mainScript.GetNode<Camera2D>("./Camera").AddChild(GD.Load<PackedScene>(Data.scenesUrls["scores"]).Instantiate());

		mainScript.timer.Stop();
		var enemies = this.GetTree().GetNodesInGroup("Enemy");

		foreach (var enemy in enemies)
		{
			mainScript.RemoveChild(enemy);
		}

		this.Hide();

	}
}
