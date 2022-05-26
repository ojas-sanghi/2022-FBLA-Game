using Godot;

public class IndividualLevelInfo : Node2D
{
  [Export] public int coinsRequired;
  [Export] public int parTimeSeconds;

  public override void _EnterTree()
  {
    base._EnterTree();
    LevelInfo.Instance.coinsRequired = coinsRequired;
    LevelInfo.Instance.coinsCollected = 0;
    LevelInfo.Instance.parTimeSeconds = parTimeSeconds;
  }
}