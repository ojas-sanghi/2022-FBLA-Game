using System;
using Godot;

public class Events : Node
{
    public static event Action example;
    public static event Action<BaseCoin> coinCollected;
    public static event Action<int> scoreMultiplierBought;
    public static event Action scoreChanged;
    public static event Action levelEnded;

    //////////////////////////

    public static void publishExample() => example?.Invoke();
    public static void publishCoinCollected(BaseCoin coin) => coinCollected?.Invoke(coin);
    public static void publishScoreMultiplierBought(int multiplier) => scoreMultiplierBought?.Invoke(multiplier);
    public static void publishScoreChanged() => scoreChanged?.Invoke();
    public static void publishLevelEnded() => levelEnded?.Invoke();


    public override void _Ready()
    {
      OS.WindowMaximized = true;
    }
}