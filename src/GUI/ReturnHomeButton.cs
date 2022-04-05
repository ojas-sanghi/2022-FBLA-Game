using Godot;
using System;

public class ReturnHomeButton : Button
{
  void onReturnHomeButtonPressed()
  {
    GetTree().Paused = false;
    SceneChanger.Instance.GoToScene("res://src/GUI/TitleScreen.tscn");
  }
}
