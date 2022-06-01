using System;
using Godot;

public class InfoHUD : Control
{
  public override void _Ready()
  {
    if (Globals.Instance.isMultiplayer)
    {
      GetNode<Control>("SPHUDs").Hide();
      GetNode<Control>("MPHUDs").Show();
    }
    else
    {
      GetNode<Control>("SPHUDs").Show();
      GetNode<Control>("MPHUDs").Hide();
    }
  }
}
