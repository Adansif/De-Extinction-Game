using Godot;

public partial class Enemy : StaticBody2D
{
    public float height;
    private CharacterBody2D player;
    private Node main;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// Initializes references to the main node and the player, and sets the initial position of the enemy.
    /// </summary>
    public override void _Ready()
    {
        main = this.GetParent();
        player = main.GetNode<CharacterBody2D>("./Player");
        this.Position = new Vector2(player.Position.X + 1600, height);
    }

    /// <summary>
    /// Called every frame. 'delta' is the elapsed time since the previous frame.
    /// Removes the enemy from the scene if it has moved a certain distance behind the player.
    /// </summary>
    /// <param name="delta">Elapsed time since the previous frame.</param>
    public override void _Process(double delta)
    {
        if (this.Position.X < player.Position.X - 200.0f)
        {
            main.RemoveChild(this);
        }
    }
}