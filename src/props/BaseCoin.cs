using Godot;
using System;

public class BaseCoin : Area2D
{
    public int goldValue = 0;
    public int scoreValue = 0;

    void OnCoinBodyEntered(Node n)
    {
        if (n is Player) 
        {
            Events.publishCoinCollected(this);
            QueueFree();
        }
    }
}
