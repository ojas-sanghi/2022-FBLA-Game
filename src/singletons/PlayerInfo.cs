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

        Events.coinCollected += OnCoinCollected;
    }

    public override void _ExitTree()
    {
        Events.coinCollected -= OnCoinCollected;
    }

    public void OnCoinCollected(BaseCoin coin)
    {
        gold += coin.goldValue;
        score += coin.scoreValue;
    }
}