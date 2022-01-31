using Godot;
using System.Collections.Generic;
using System.Linq;

public class NextLevelButton : Button
{
  void OnNextLevelButtonPressed()
  {
    List<Enums.Levels> levelsList = Enums.Levels.GetValues(typeof(Enums.Levels)).Cast<Enums.Levels>().ToList();
    int currentLevelIndex = levelsList.IndexOf(Globals.Instance.currentLevel);
    int nextLevelIndex = currentLevelIndex + 1;

    if (nextLevelIndex >= levelsList.Count)
    {
      SceneChanger.Instance.GoToScene("res://src/GUI/EndScreen.tscn");
      return;
    }

    Globals.Instance.currentLevel = (Enums.Levels) nextLevelIndex;
    SceneChanger.Instance.GoToPackedScene(Globals.Instance.levels[Globals.Instance.currentLevel]);
  }
}
