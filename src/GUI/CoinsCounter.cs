using System;
using Godot;

public class CoinsCounter : HBoxContainer
{
  [Export] int playerId = 1;

  Label label;
  public override void _Ready()
  {
    label = GetNode<Label>("Label");
    UpdateText();

    Events.coinCollected += UpdateText;
    Events.playerDied += UpdateText;
  }

  public override void _ExitTree()
  {
    Events.coinCollected -= UpdateText;
    Events.playerDied -= UpdateText;
  }



  public override void _Process(float delta)
  {
    if (Globals.Instance.isMultiplayer)
    {
      UpdateText();
    }
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
    label.Text = $": {LevelInfo.Instance.coinsCollected[playerId]}/{LevelInfo.Instance.coinsRequired}";
  }
}
