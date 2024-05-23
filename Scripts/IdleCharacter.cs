using Godot;
using System;

public partial class IdleCharacter : Control
{
    [Export]
    private String texturePath;
    private Sprite2D sprite;
    private AnimationPlayer animation;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// Initializes the sprite and animation player, sets the texture for the sprite, and plays the idle animation.
    /// </summary>
    public override void _Ready()
    {
        sprite = this.GetNode<Sprite2D>("./Sprite");
        animation = this.GetNode<AnimationPlayer>("./Animation");

        sprite.Texture = GD.Load<Texture2D>(texturePath);

        animation.Play("Idle");
    }
}