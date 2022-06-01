using System;
using Godot;
using System.Threading.Tasks;

public class Events : Node
{
  public static event Action<BaseCoin, int> coinCollected;
  public static event Action<int> scoreChanged;
  public static event Action<int> levelEnded;
  public static event Action<int> playerDied;

  //////////////////////////

  public static void publishCoinCollected(BaseCoin coin, int playerId) => coinCollected?.Invoke(coin, playerId);
  public static void publishScoreChanged(int playerId) => scoreChanged?.Invoke(playerId);
  public static void publishLevelEnded(int playerId) => levelEnded?.Invoke(playerId);
  public static void publishPlayerDied(int playerId) => playerDied?.Invoke(playerId);


  public override void _Ready()
  {
    OS.WindowMaximized = true;
  }
}