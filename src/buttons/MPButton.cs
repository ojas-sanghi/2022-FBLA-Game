using System;
using Godot;

public class MPButton : Button
{
  void OnMPButtonPressed()
  {
    Globals.Instance.isMultiplayer = true;
    SceneChanger.Instance.GoToScene("res://src/levels/MPBase.tscn");
  }
}
