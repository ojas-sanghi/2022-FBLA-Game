using System;
using Godot;

public class Events : Node
{
  public static event Action<BaseCoin> coinCollected;
  public static event Action scoreChanged;
  public static event Action levelEnded;
  public static event Action playerDied;

  //////////////////////////

  public static void publishCoinCollected(BaseCoin coin) => coinCollected?.Invoke(coin);
  public static void publishScoreChanged() => scoreChanged?.Invoke();
  public static void publishLevelEnded() => levelEnded?.Invoke();
  public static void publishPlayerDied() => playerDied?.Invoke();


  public override void _Ready()
  {
    OS.WindowMaximized = true;
  }
}