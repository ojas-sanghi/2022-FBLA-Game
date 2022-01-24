using Godot;
using System;

public class ScoreCounter : Label
{
    public override void _Ready()
    {
      Events.scoreChanged += UpdateText;
      UpdateText();
    }

    public override void _ExitTree()
    {
      Events.scoreChanged -= UpdateText;
    }

    void UpdateText()
    {
        Text = $"Score: {PlayerInfo.score}";
    }
}
