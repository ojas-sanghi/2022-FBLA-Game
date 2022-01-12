using Godot;
using Godot.Collections;

public class PlayerInfo : Node
{
    public static int gold = 2000;

    public static PlayerInfo Instance;

    public PlayerInfo()
    {
        Instance = this;

        var coins = GetTree().GetNodesInGroup("coins");
        foreach (Node c in coins)
        {
            c.Connect("coin_collected", this, nameof(OnCoinCollected));
        }
    }

    public override void _Ready()
    {
        Instance = this;
    }

    public void OnCoinCollected()
    {

    }
}