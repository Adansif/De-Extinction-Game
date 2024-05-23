using Godot;
using System;

public partial class Selection : Control
{
	private Button douxButton, mortButton, vitaButton, tardButton, startButton;
	private AnimationPlayer animation;
	private string texturePath = Data.defaultTexture;
	// Called when the node enters the scene tree for the first time.
	public async override void _Ready()
	{
		startButton = this.GetNode<Panel>("./Panel").GetNode<Button>("./Start");

		var panel = this.GetNode<Panel>("./Panel");
		douxButton = panel.GetNode<Control>("./Doux").GetNode<Button>("./DouxButton");
		mortButton = panel.GetNode<Control>("./Mort").GetNode<Button>("./MortButton");
		tardButton = panel.GetNode<Control>("./Tard").GetNode<Button>("./TardButton");
		vitaButton = panel.GetNode<Control>("./Vita").GetNode<Button>("./VitaButton");

		animation = this.GetNode<AnimationPlayer>("./Animation");

		animation.Play("Entry");
		await ToSignal(animation, "animation_finished");

		douxButton.Pressed += () => ChangeTexture(douxButton);
		mortButton.Pressed += () => ChangeTexture(mortButton);
		tardButton.Pressed += () => ChangeTexture(tardButton);
		vitaButton.Pressed += () => ChangeTexture(vitaButton);

		startButton.Pressed += StartGame;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void ChangeTexture(Button button){
		String buttonName = button.Name;
		texturePath = Data.texturePath + buttonName.Substring(0,4) + ".png";
		GD.Print(texturePath);
	}

	private async void StartGame(){
		animation.Play("Start");

		var mainNode = this.GetTree().GetFirstNodeInGroup("Main");
		var mainScript = (Main)mainNode;
		var playerScript = (Player)this.GetTree().GetFirstNodeInGroup("Player");
		playerScript.spriteTexture = this.texturePath;
		playerScript.ChangeTexture();
		playerScript.Show();

		await ToSignal(animation, "animation_finished");
		mainScript.timer.Start();
		mainScript.isPlaying = true;

		this.GetParent().RemoveChild(this);
	}
}
