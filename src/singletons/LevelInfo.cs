using System.Collections.Generic;
using Godot;

public class LevelInfo : Node
{
  public static LevelInfo Instance;

  public int coinsRequired;
  public Dictionary<int, int> coinsCollected = new();

  public Dictionary<Enums.Levels, int> levelTimeLimits;

  public LevelInfo()
  {
    Instance = this;
  }

  public override void _Ready()
  {
    Instance = this;

    resetAllCoinsCollected();
    Events.coinCollected += OnCoinCollected;
    Events.levelPassed += resetCoinsCollected;

    levelTimeLimits = new() 
    {
      { Enums.Levels.Level1, 6 },
      { Enums.Levels.Level2, 30 },
      { Enums.Levels.Level3, 15 }
    };

  }

  void OnCoinCollected(BaseCoin coin, int id)
  {
    //? treat green coins as non-required?
    coinsCollected[id]++;
  }

  public void resetCoinsCollected(int id)
  {
    coinsCollected[id] = 0;
  }

  public void resetAllCoinsCollected()
  {
    coinsCollected = new()
    {
      {0, 0},
      {1, 0},
      {2, 0}
    };
  }
}