using Godot;
using System;

public partial class Selection : Control
{
    private Button douxButton, mortButton, vitaButton, tardButton, startButton;
    private AnimationPlayer animation;
    private string texturePath = Data.defaultTexture;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// Initializes references to UI elements and sets up button signals.
    /// Plays the entry animation.
    /// </summary>
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

    /// <summary>
    /// Changes the texture path based on the button pressed.
    /// </summary>
    /// <param name="button">The button that was pressed.</param>
    private void ChangeTexture(Button button)
    {
        String buttonName = button.Name;
        texturePath = Data.texturePath + buttonName.Substring(0, 4) + ".png";
        GD.Print(texturePath);
    }

    /// <summary>
    /// Starts the game by playing the start animation, setting the player's texture,
    /// showing the player, starting the game timer, and setting the game state to playing.
    /// </summary>
    private async void StartGame()
    {
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
