using System;
using Godot;

public class PowerupShop : Control
{
  void OnScoreMultiplierBuyPressed()
  {
    Events.publishScoreMultiplierBought(2);
  }
}
