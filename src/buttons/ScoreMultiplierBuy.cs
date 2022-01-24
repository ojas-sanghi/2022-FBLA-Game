using System;
using Godot;

public class ScoreMultiplierBuy : Button
{
  void OnScoreMultiplierBuyPressed()
  {
    int cost = ShopInfo.Instance.shopItems["x2 Score Multiplier"];
    if (PlayerInfo.gold >= cost)
    {
      PlayerInfo.gold -= cost;
      Events.publishScoreMultiplierBought(2);
    }
  }
}
