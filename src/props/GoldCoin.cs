using Godot;
using System;

public class GoldCoin : BaseCoin
{
    public override void _Ready()
    {
        goldValue = 1;
        scoreValue = 5;       
    }
}
