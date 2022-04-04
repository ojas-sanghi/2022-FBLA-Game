using System.Collections.Generic;
using System.Linq;
using Godot;

public class LevelEndArea : Area2D
{
  void OnLevelEndAreaBodyEntered(Node body)
  {
    if (!(body is Player)) return;

    PlayerInfo.gold += PlayerInfo.goldThisLevel;

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
