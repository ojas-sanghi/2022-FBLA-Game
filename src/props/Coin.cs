using Godot;
using System;

public class Coin : Area2D
{
    public override void _Ready()
    {
        // base collectable class in gdscript
    // grups and on_area_entered stuff
    // in subclass coin, define area2d and add coins stuff to an on_coin_entered signal
    // subclasses of coins with diff value numbers? like worth 1 or 5 points/gold

    // c#: receive the on_coin_entered signal and add points        
    }
}
