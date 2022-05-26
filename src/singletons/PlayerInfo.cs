using Godot;
using Godot.Collections;

public class PlayerInfo : Node
{
  public static int score = 0;

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