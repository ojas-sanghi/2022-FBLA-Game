using System.Collections.Generic;
using System.Linq;
using Godot;

public class LevelEndArea : Area2D
{
  void OnLevelEndAreaBodyEntered(Node body)
  {
    if (!(body is Player)) return;

    // add gold earned this level to global count, and reset level-specific counter
    PlayerInfo.gold += PlayerInfo.goldThisLevel;
    PlayerInfo.goldThisLevel = 0;

    PlayerInfo.score += PlayerInfo.scoreThisLevel;
    PlayerInfo.scoreThisLevel = 0;

    // get a list of all the levels in the enum
    // and then get the index of the current level and increment
    List<Enums.Levels> levelsList = Enums.Levels.GetValues(typeof(Enums.Levels)).Cast<Enums.Levels>().ToList();
    int currentLevelIndex = levelsList.IndexOf(Globals.Instance.currentLevel);
    int nextLevelIndex = currentLevelIndex + 1;

    if (nextLevelIndex >= levelsList.Count)
    {
      SceneChanger.Instance.GoToScene("res://src/GUI/EndScreen.tscn");
    }
    else
    {
      Globals.Instance.currentLevel = (Enums.Levels)nextLevelIndex;
      SceneChanger.Instance.GoToScene("res://src/GUI/PowerupShop.tscn");
    }
  }
}
