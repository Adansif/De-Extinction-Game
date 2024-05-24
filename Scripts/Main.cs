using Godot;
using System;

public partial class Main : Node2D
{
    private Random random = new();
    public Timer timer;
    public Boolean isPlaying = false;

    public String name, password, score;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// Initializes the timer by getting the Timer node.
    /// </summary>
    public override void _Ready()
    {
        timer = this.GetNode<Timer>("./Timer");
    }

    /// <summary>
    /// Handles the timeout signal from the timer.
    /// Spawns a new enemy, increases the player's speed, and sets a new random wait time for the timer.
    /// </summary>
    private void _on_timer_timeout()
    {
        SpawnEnemy();
        
        var playerScript = (Player)this.GetTree().GetFirstNodeInGroup("Player");
        if (playerScript.Speed < 6000)
        {
            playerScript.Speed += 30;
        }

        timer.WaitTime = random.Next(1, 3);
    }

    /// <summary>
    /// Spawns a new enemy at a random height and adds it to the scene.
    /// </summary>
    private void SpawnEnemy()
    {
        var enemy = GD.Load<PackedScene>(Data.scenesUrls["enemy"]).Instantiate();
        var enemyScript = (Enemy)enemy;
        enemyScript.height = random.Next(100, 451);
        enemyScript.Scale = new Godot.Vector2(3, 3);
        this.AddChild(enemy);
    }
}
