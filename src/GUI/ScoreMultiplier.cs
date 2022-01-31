using System;
using Godot;

public class ScoreMultiplier : Label
{
  public override void _Ready()
  {
    Events.scoreMultiplierBought += UpdateText;
    UpdateText(PlayerInfo.scoreMultiplier);
  }

  public override void _ExitTree()
  {
    Events.scoreMultiplierBought -= UpdateText;
  }

  void UpdateText(int _multiplier)
  {
    Text = $"Multiplier: {PlayerInfo.scoreMultiplier}x";
  }
}
