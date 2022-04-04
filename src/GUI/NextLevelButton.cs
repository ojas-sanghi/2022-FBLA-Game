using Godot;

public class NextLevelButton : Button
{
  void OnNextLevelButtonPressed()
  {
    SceneChanger.Instance.GoToPackedScene(Globals.Instance.levels[Globals.Instance.currentLevel]);
  }
}
