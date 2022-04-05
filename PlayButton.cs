using System;
using Godot;

public class PlayButton : Button
{
  void OnPlayButtonPressed()
  {
    SceneChanger.Instance.GoToScene("res://src/levels/Level1.tscn");
  }
}
