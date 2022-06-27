using Godot;
using Godot.Collections;

public class PlayerInfo : Node
{
  public static float coinsScoreMultiplier = 2f;
  public static float timeScoreMultiplier = 1.2f;

  public static PlayerInfo Instance;

  public PlayerInfo()
  {
    Instance = this;
  }

  public override void _Ready()
  {
    Instance = this;
  }
}