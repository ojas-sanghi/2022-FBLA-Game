using Godot;
using Godot.Collections;

public class PlayerInfo : Node
{
  public static float coinsScoreMultiplier = 1.5f;
  public static float timeScoreMultiplier = 1.75f;

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