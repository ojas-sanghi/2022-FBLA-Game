using Godot;
using System;

public class ReturnHomeButton : Button
{
  void onReturnHomeButtonPressed()
  {
    GetTree().Paused = false;
    Globals.Instance.currentLevel = Enums.Levels.Level1;
    Globals.Instance.isMultiplayer = false;
    LevelInfo.Instance.resetAllScoreCollected();
    SceneChanger.Instance.GoToScene("res://src/GUI/TitleScreen.tscn");
  }
}
