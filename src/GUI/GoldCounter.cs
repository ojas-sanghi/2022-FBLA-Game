using Godot;
using System;

public class GoldCounter : Label
{
    public override void _Ready()
    {
      Events.scoreMultiplierBought += UpdateText;
      UpdateText(1);
    }

    public override void _ExitTree()
    {
      Events.scoreMultiplierBought -= UpdateText;
    }

    void UpdateText(int a)
    {
        Text = $"Gold: {PlayerInfo.goldThisLevel}";
    }
}
