using System;
using Godot;

public class QuitButton : Button
{
  void OnQuitButtonPressed()
  {
    GetTree().Quit();
  }
}
