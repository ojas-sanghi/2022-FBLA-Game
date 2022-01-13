using Godot;
using Godot.Collections;

public class PlayerInfo : Node
{
    public static int gold = 0;
    public static int score = 0;

    public static PlayerInfo Instance;

    public PlayerInfo()
    {
        Instance = this;
    }

    public override void _Ready()
    {
        Instance = this;

        var coins = GetTree().GetNodesInGroup("coins");
        foreach (Node c in coins)
        {
            c.Connect("coin_collected", this, nameof(OnCoinCollected));
        }
    }

    public void OnCoinCollected()
    {
        
    }
}