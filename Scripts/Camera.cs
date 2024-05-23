using Godot;
using System;

public partial class Camera : Camera2D
{
    private CharacterBody2D player;
    private Label points;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// Initializes references to the player and the points label.
    /// </summary>
    public override void _Ready()
    {
        player = this.GetParent().GetNode<CharacterBody2D>("./Player");
        points = this.GetNode<Label>("./Points");
    }

    /// <summary>
    /// Called every frame. 'delta' is the elapsed time since the previous frame.
    /// Updates the camera's position based on the player's position 
    /// and updates the points text in the label.
    /// </summary>
    /// <param name="delta">Elapsed time since the previous frame.</param>
    public override void _Process(double delta)
    {
        this.Position = new Vector2(player.Position.X + 700, this.Position.Y);
        this.points.Text = Math.Floor(((Player)player).points).ToString();
    }
}