using System.Collections.Generic;
using Godot;

public class EndScreen : Control
{
  string name;

  Control saveScore;
  ScrollContainer leaderboard;

  public override void _Ready()
  {
    saveScore = GetNode<Control>("SaveScore");
    leaderboard = GetNode<ScrollContainer>("Leaderboard");
  }

  void OnSubmitButtonPressed()
  {
    //TODO: ALLOW DUPLICATE NAMES!
    name = GetNode<LineEdit>("SaveScore/NameEnter").Text;
    Globals.Instance.highScores.Add(name, PlayerInfo.score);

	File scoresFile = new File();
	scoresFile.Open("user://highscores.save", File.ModeFlags.Write);
	scoresFile.StoreLine(JSON.Print(Globals.Instance.highScores));
	scoresFile.Close();

	GD.Print(Globals.Instance.highScores);
  }

  void OnToggleLeaderboardPressed()
  {
    saveScore.Visible = !saveScore.Visible;
    leaderboard.Visible = !leaderboard.Visible;
  }
}
