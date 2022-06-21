using Godot;

public class NextLevelButton : Button
{
  // TODO: check if both players have finished to unlock the btn
  void OnNextLevelButtonPressed()
  {
    LevelInfo.Instance.resetAllScoreCollected();

    if (Globals.Instance.isMultiplayer)
      Events.publishMpNextLevel();
    else
      SceneChanger.Instance.GoToPackedScene(Globals.Instance.levels[Globals.Instance.currentLevel]);
  }
}
