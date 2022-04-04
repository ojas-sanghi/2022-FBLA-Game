using Godot;

public class HomeButton : Button
{
  void OnGoHomeButtonPressed()
  {
    SceneChanger.Instance.GoToScene("res://src/GUI/TitleScreen.tscn");
  }
}
