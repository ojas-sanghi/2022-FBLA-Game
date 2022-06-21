using System;
using Godot;

public class GoldCoin : BaseCoin
{
  public override void _Ready()
  {
    scoreValue = 1;
  }
}
