using System.Collections.Generic;
using Godot;

public class LevelInfo : Node
{
  public static LevelInfo Instance;

  public int coinsRequired;
  // [id, coins/score collected]
  public Dictionary<int, int> coinsCollected = new();
  public Dictionary<int, int> scoreCollected = new();

  public Dictionary<Enums.Levels, int> levelTimeLimits;

  public LevelInfo()
  {
    Instance = this;
  }

  public override void _Ready()
  {
    Instance = this;

    resetAllCoinsCollected();
    resetAllScoreCollected();

    Events.coinCollected += OnCoinCollected;
    Events.levelPassed += resetCoinsCollected;

    levelTimeLimits = new() 
    {
      { Enums.Levels.Level1, 600 },
      { Enums.Levels.Level2, 300 },
      { Enums.Levels.Level3, 150 }
    };

  }

  void OnCoinCollected(BaseCoin coin, int id)
  {
    //? treat green coins as non-required?
    coinsCollected[id]++;
    scoreCollected[id] += (int) (coin.scoreValue * PlayerInfo.coinsScoreMultiplier);
    Events.publishScoreChanged(id);
  }

  public void resetCoinsCollected(int id)
  {
    coinsCollected[id] = 0;
  }

  public void resetScoreCollected(int id)
  {
    scoreCollected[id] = 0;
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

  public void resetAllScoreCollected()
  {
    scoreCollected = new()
    {
      {0, 0},
      {1, 0},
      {2, 0}
    };
  }
}