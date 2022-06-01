using System;
using Godot;

public class ScoreCounter : Label
{
  public override void _Ready()
  {
    Events.scoreChanged += UpdateText;
    UpdateText(0);
  }

  public override void _ExitTree()
  {
    Events.scoreChanged -= UpdateText;
  }

  void UpdateText(int id)
  {
    Text = $"Score: {PlayerInfo.score}";
  }
}
