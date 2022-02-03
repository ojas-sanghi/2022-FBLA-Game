using System.Collections.Generic;
using Godot;

public class EndScreen : Control
{
  string name;

  public override void _Ready()
  {
  }

  void OnSubmitButtonPressed()
  {
	name = GetNode<LineEdit>("NameEnter").Text;
	Globals.Instance.highScores.Add(name, PlayerInfo.score);

	File scoresFile = new File();
	scoresFile.Open("user://highscores.save", File.ModeFlags.Write);
	scoresFile.StoreLine(JSON.Print(Globals.Instance.highScores));
	scoresFile.Close();

	GD.Print(Globals.Instance.highScores);
  }
}
