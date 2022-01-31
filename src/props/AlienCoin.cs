using Godot;
using System;

public class AlienCoin : BaseCoin
{
    public override void _Ready()
    {
        goldValue = 10;
        scoreValue = 20;       
    }
}
