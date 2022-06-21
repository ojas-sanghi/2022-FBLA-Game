using System;
using Godot;

public class ScoreCounter : Label
{
  [Export] int playerId = 1;

  public override void _Ready()
  {
    if (!Globals.Instance.isMultiplayer)
    {
      playerId = 0;
      // TODO: set playerID in multilpayer when we make the new post-level pipeline
    }

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
      Text = $"Score: {LevelInfo.Instance.scoreCollected[playerId]}";
  }
}
