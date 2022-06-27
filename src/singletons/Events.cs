using System;
using Godot;
using System.Threading.Tasks;

public class Events : Node
{
  public static event Action<BaseCoin, int> coinCollected;
  public static event Action<int> scoreChanged;
  public static event Action<int> levelPassed;
  public static event Action<int> playerDied;
  public static event Action timeOver;
  public static event Action mpNextLevel;

  public static event Action<int> instructionAreaHit;

  //////////////////////////

  public static void publishCoinCollected(BaseCoin coin, int playerId) => coinCollected?.Invoke(coin, playerId);
  public static void publishScoreChanged(int playerId) => scoreChanged?.Invoke(playerId);
  public static void publishLevelPassed(int playerId) => levelPassed?.Invoke(playerId);
  public static void publishPlayerDied(int playerId) => playerDied?.Invoke(playerId);
  public static void publishTimeOver() => timeOver?.Invoke();
  public static void publishMpNextLevel() => mpNextLevel?.Invoke();

  public static void publishInstructionAreahit(int areaNum) => instructionAreaHit?.Invoke(areaNum);

  public override void _Ready()
  {
    OS.WindowMaximized = true;
  }
}