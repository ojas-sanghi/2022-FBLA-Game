using System.Collections.Generic;
using Godot;

public class EndScreen : Control
{
  string name;

  Control saveScore;
  ScrollContainer leaderboard;
  Label resultLabel;

  public override void _Ready()
  {
    saveScore = GetNode<Control>("SaveScore");
    leaderboard = GetNode<ScrollContainer>("Leaderboard");
    resultLabel = GetNode<Label>("SaveScore/ResultLabel");
    resultLabel.Visible = false;
  }

  void OnSubmitButtonPressed()
  {
    name = GetNode<LineEdit>("SaveScore/NameEnter").Text;
    if (Globals.Instance.highScores.ContainsKey(name))
    {
      resultLabel.Visible = true;
      resultLabel.Text = "Error: duplicate names not allowed!";
      resultLabel.AddColorOverride("font_color", new Color(1, 0, 0));
      return;
    }
    else
    {
      resultLabel.Visible = true;
      resultLabel.Text = "Score submitted!";
      resultLabel.AddColorOverride("font_color", new Color(0, 1, 0));
      Globals.Instance.highScores.Add(name, PlayerInfo.score);
    }

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
