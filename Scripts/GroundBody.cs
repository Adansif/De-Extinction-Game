using Godot;

public partial class GroundBody : StaticBody2D
{
    private CharacterBody2D player;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// Initializes the reference to the player by getting the first node in the "Main" group.
    /// </summary>
    public override void _Ready()
    {
        player = this.GetTree().GetFirstNodeInGroup("Main").GetNode<CharacterBody2D>("./Player");
    }

    /// <summary>
    /// Called every frame. 'delta' is the elapsed time since the previous frame.
    /// Updates the position of the ground body to match the player's X position.
    /// </summary>
    /// <param name="delta">Elapsed time since the previous frame.</param>
    public override void _Process(double delta)
    {
        this.Position = new Godot.Vector2(player.Position.X, this.Position.Y);
    }
}