using System;
using Godot;

public class CoinsCounter : Panel
{
  [Export] int playerId = 1;

  Label label;
  public override void _Ready()
  {
    label = FindNode("Label") as Label;
    // TODO: figure out how to make the coins required part actually show at levle start
    UpdateText();

    Events.coinCollected += UpdateText;
    Events.playerDied += UpdateText;
  }

  public override void _ExitTree()
  {
    Events.coinCollected -= UpdateText;
    Events.playerDied -= UpdateText;
  }

  void UpdateText(BaseCoin coin, int id)
  {
    UpdateText(id);
  }

  void UpdateText(int id)
  {
    if (id == playerId)
      UpdateText();
  }

  void UpdateText()
  {
    GD.Print(playerId);
    label.Text = $": {LevelInfo.Instance.coinsCollected[playerId]}/{LevelInfo.Instance.coinsRequired}";
  }
}
