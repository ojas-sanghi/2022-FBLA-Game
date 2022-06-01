using System;
using Godot;

public class ScoreCounter : Label
{
  [Export] int playerId = 1;

  public override void _Ready()
  {
    Events.scoreChanged += UpdateText;
    UpdateText(playerId);
  }

  public override void _ExitTree()
  {
    Events.scoreChanged -= UpdateText;
  }

  void UpdateText(int id)
  {
    if (id == playerId)
      Text = $"Score: {PlayerInfo.score}";
  }
}
