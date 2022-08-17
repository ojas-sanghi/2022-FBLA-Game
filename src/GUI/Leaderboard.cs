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

    font50 = GD.Load<DynamicFont>("res://assets/fonts/ArcadeFont35.tres");
    fontTheme = new Theme();
    fontTheme.DefaultFont = font50;

    constructList();
  }

  // update list whenever leaderboard is shown
  void OnLeaderboardVisibilityChanged()
  {
    constructList();
  }

  void constructList()
  {
    // get a list of all the existing entries and then delete them all
    // from there, we make a fresh list of scores from scratch 
    List<LeaderboardLabel> labelChildren = labels.GetChildren().Cast<LeaderboardLabel>().ToList<LeaderboardLabel>();
    labelChildren.ForEach(child => child.QueueFree());

    if (Globals.Instance.highScores.Count > 0)
    {
      // sort the current scores in the dictionary
      List<KeyValuePair<string, int>> sortedScores = Globals.Instance.highScores.OrderByDescending(x => x.Value).ToList();
      foreach (KeyValuePair<string, int> highScore in sortedScores)
      {
        // make a new object from each and add it to the container
        LeaderboardLabel label = new LeaderboardLabel(highScore.Key, highScore.Value);
        labels.AddChild(label);
      }
    }
  }
}