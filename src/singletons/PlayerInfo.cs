using Godot;
using Godot.Collections;

public class PlayerInfo : Node
{
  public static int score = 0;

  public static int coinsScoreMultiplier = 2;
  public static int timeScoreMultiplier = 2;

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