using System.Collections.Generic;
using Godot;

public class LevelInfo : Node
{
  public static LevelInfo Instance;

  public int coinsRequired;
  // [id, coins/score collected]
  public Dictionary<int, int> coinsCollected = new();
  public Dictionary<int, int> scoreCollected = new();

  public Dictionary<int, int> scoreThisRound = new();

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
      { Enums.Levels.Level0, 60 },
      { Enums.Levels.Level1, 60 },
      { Enums.Levels.Level2, 45 },
      { Enums.Levels.Level3, 40 }
    };

  }

  void OnCoinCollected(BaseCoin coin, int id)
  {
    // only count coin as contributing towards required # if it's normal coin 
    // ie, not aliencoin
    if (coin is GoldCoin)
      coinsCollected[id]++;
    scoreCollected[id] += (int) (coin.scoreValue * PlayerInfo.coinsScoreMultiplier);
    scoreThisRound[id] += (int) (coin.scoreValue * PlayerInfo.coinsScoreMultiplier);
    Events.publishScoreChanged(id);
  }

  public void resetCoinsCollected(int id)
  {
    coinsCollected[id] = 0;
  }

  public void resetScoreCollectedAfterDeath(int id)
  {
    scoreCollected[id] -= scoreThisRound[id];
    scoreThisRound[id] = 0;
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
    scoreThisRound = new()
    {
      {0, 0},
      {1, 0},
      {2, 0}
    };
    
    scoreCollected = new()
    {
      {0, 0},
      {1, 0},
      {2, 0}
    };
  }
}