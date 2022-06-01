using System.Collections.Generic;
using Godot;

public class LevelInfo : Node
{
  public static LevelInfo Instance;

  public int coinsRequired;
  public int parTimeSeconds;
  public Dictionary<int, int> coinsCollected = new();

  public LevelInfo()
  {
    Instance = this;
  }

  public override void _Ready()
  {
    Instance = this;

    resetAllCoinsCollected();
    Events.coinCollected += OnCoinCollected;
  }

  void OnCoinCollected(BaseCoin coin, int id)
  {
    //? treat green coins as non-required?
    coinsCollected[id]++;
  }

  public void resetCoinsCollected(int id)
  {
    GD.Print(id);
    // print the dictionary to console
    string output = "";
    foreach (KeyValuePair<int, int> kvp in coinsCollected)
    {
      output += string.Format("Player = {0}, Coins = {1}", kvp.Key, kvp.Value);
      output += "\n";
    }
    GD.Print(output);
    GD.Print(coinsCollected.Count);
    GD.Print("-----");

    coinsCollected[id] = 0;

    output = "";
    foreach (KeyValuePair<int, int> kvp in coinsCollected)
    {
      output += string.Format("Player = {0}, Coins = {1}", kvp.Key, kvp.Value);
      output += "\n";
    }
    GD.Print(output);
    GD.Print(coinsCollected.Count);
    GD.Print("function over-----");
  }

  public void resetAllCoinsCollected()
  {
    coinsCollected = new()
    {
      {0, 0},
      {1, 0},
      {2, 0}
    };
  }
}