using Godot;

public class IndividualLevelInfo : Node2D
{
  [Export] public int coinsRequired;

  public int id = 0;

  public override void _EnterTree()
  {
    base._EnterTree();
    Globals.Instance.playersCompleted = new();
    LevelInfo.Instance.coinsRequired = coinsRequired;
    LevelInfo.Instance.resetCoinsCollected(id);
  }
}