using System;
using Godot;

public class CoinsCounter : Label
{
  public override void _Ready()
  {
    Events.coinCollected += UpdateText;
    UpdateText();
  }

  public override void _ExitTree()
  {
    Events.coinCollected -= UpdateText;
  }

  void UpdateText(BaseCoin coin, int id)
  {
    UpdateText();
  }

  void UpdateText()
  {
    Text = $"Coins Collected: {LevelInfo.Instance.coinsCollected} / {LevelInfo.Instance.coinsRequired}";
  }
}
