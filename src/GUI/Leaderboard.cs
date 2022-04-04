using System.Collections.Generic;
using System.Linq;
using Godot;

public class Leaderboard : ScrollContainer
{
  VBoxContainer labels;
  Font font50;
  Theme fontTheme;

  public override void _Ready()
  {
    labels = GetNode<VBoxContainer>("LeaderboardLabels");

    font50 = GD.Load<DynamicFont>("res://assets/fonts/Font50.tres");
    fontTheme = new Theme();
    fontTheme.DefaultFont = font50;

    constructList();
  }

  void OnLeaderboardVisibilityChanged()
  {
    constructList();
  }

  void constructList()
  {
    List<LeaderboardLabel> labelChildren = labels.GetChildren().Cast<LeaderboardLabel>().ToList<LeaderboardLabel>();
    labelChildren.ForEach(child => child.QueueFree());

    if (Globals.Instance.highScores.Count > 0)
    {
      List<KeyValuePair<string, int>> sortedScores = Globals.Instance.highScores.OrderByDescending(x => x.Value).ToList();
      foreach (KeyValuePair<string, int> highScore in sortedScores)
      {
        LeaderboardLabel label = new LeaderboardLabel(highScore.Key, highScore.Value);
        labels.AddChild(label);
      }
    }

  }
}