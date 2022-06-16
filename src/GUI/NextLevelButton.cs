using Godot;

public class NextLevelButton : Button
{
  // TODO: check if both players have finished to unlock the btn
  void OnNextLevelButtonPressed()
  {
    if (Globals.Instance.isMultiplayer)
      Events.publishMpNextLevel();
    else
      SceneChanger.Instance.GoToPackedScene(Globals.Instance.levels[Globals.Instance.currentLevel]);
  }
}
