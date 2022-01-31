using Godot;
using System;

public class PowerupShop : Control
{
    public override void _Ready()
    {
        
    }

    void OnScoreMultiplierBuyPressed()
    {
        Events.publishScoreMultiplierBought(2);
    }
}
