using Godot;

public class IndividualLevelInfo : Node2D
{
  [Export] public int coinsRequired;
  [Export] public int parTimeSeconds;

  public int id = 0;

  public override void _EnterTree()
  {
    base._EnterTree();
    LevelInfo.Instance.coinsRequired = coinsRequired;
    LevelInfo.Instance.resetCoinsCollected(id);
    LevelInfo.Instance.parTimeSeconds = parTimeSeconds;
  }
}