using System;
using Godot;

public class Events : Node
{
    public static event Action example;
    public static event Action<BaseCoin> coinCollected;

    //////////////////////////

    public static void publishExample() => example?.Invoke();
    public static void publishCoinCollected(BaseCoin coin) => coinCollected?.Invoke(coin);


    public override void _Ready()
    {
        // OS.WindowMaximised = true;
    }
}