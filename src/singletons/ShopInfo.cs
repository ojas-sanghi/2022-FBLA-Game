using System.Collections.Generic;
using Godot;

public class ShopInfo : Node
{
  public Dictionary<string, int> shopItems = new Dictionary<string, int>()
  {
    { "x2 Score Multiplier", 50 },
    { "x3 Score Multiplier", 250 },
  };

  public static ShopInfo Instance;

  public ShopInfo()
  {
    Instance = this;
  }

  public override void _Ready()
  {
    Instance = this;
  }
}