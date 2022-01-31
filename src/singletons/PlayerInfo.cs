using Godot;
using Godot.Collections;

public class PlayerInfo : Node
{
  public static int gold = 50;
  public static int score = 0;

  public static int scoreMultiplier = 1;

  public static PlayerInfo Instance;

  public PlayerInfo()
  {
    Instance = this;
  }

  public override void _Ready()
  {
    Instance = this;

    Events.coinCollected += OnCoinCollected;
    Events.scoreMultiplierBought += OnScoreMultiplierBought;
  }

  public override void _ExitTree()
  {
    Events.coinCollected -= OnCoinCollected;
    Events.scoreMultiplierBought -= OnScoreMultiplierBought;
  }

  void OnCoinCollected(BaseCoin coin)
  {
    gold += coin.goldValue;
    score += coin.scoreValue * scoreMultiplier;
    Events.publishScoreChanged();
  }

  void OnScoreMultiplierBought(int multiplier)
  {
    scoreMultiplier = multiplier;
  }
}