using Godot;

public class LevelInfo : Node
{
  public static LevelInfo Instance;

  public int coinsRequired;
  public int coinsCollected;
  public int parTimeSeconds;

  public LevelInfo()
  {
    Instance = this;
  }

  public override void _Ready()
  {
    Instance = this;

    Events.coinCollected += OnCoinCollected;
  }

  void OnCoinCollected(BaseCoin coin)
  {
    //? treat green coins as non-required?
    coinsCollected++;
  }
}