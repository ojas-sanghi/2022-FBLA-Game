using Godot;
using Godot.Collections;

public class PlayerStats : Node
{
    public static int gold = 2000;

    public static PlayerStats Instance;

    public PlayerStats()
    {
        Instance = this;
    }

    public override void _Ready()
    {
        Instance = this;
    }
}