using System;
using Godot;

public class PowerupShop : Control
{
  public override void _Ready()
  {
    base._Ready();
    Label costLabel = GetNode<Label>("CostLabel");

    costLabel.Text = $"Cost: {ShopInfo.Instance.shopItems["x2 Score Multiplier"]}";
  }

  void OnScoreMultiplierBuyPressed()
  {
    Events.publishScoreMultiplierBought(2);
  }
}
