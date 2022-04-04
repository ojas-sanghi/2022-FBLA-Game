using System;
using Godot;

public class GoldCounter : Label
{
  public override void _Ready()
  {
    Events.coinCollected += UpdateText;
    Events.goldChanged += UpdateText;
    UpdateText();
  }

  public override void _ExitTree()
  {
    Events.coinCollected -= UpdateText;
    Events.goldChanged -= UpdateText;
  }

  void UpdateText(BaseCoin coin)
  {
    UpdateText();
  }

  void UpdateText()
  {
    Text = $"Gold: {PlayerInfo.gold + PlayerInfo.goldThisLevel}";
  }
}
