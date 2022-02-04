using System.Collections.Generic;
using System.Linq;
using Godot;

public class Leaderboard : ScrollContainer
{
  GridContainer grid;
  Font font50;
  Theme fontTheme;

  public override void _Ready()
  {
    grid = GetNode<GridContainer>("GridContainer");

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
    // TODO: SORT BY HIGHEST SCORE
    List<Node> gridChildren = grid.GetChildren().Cast<Node>().ToList<Node>();
    gridChildren.ForEach(child => child.QueueFree());

    foreach (KeyValuePair<string, int> highScore in Globals.Instance.highScores)
    {
      Label nameLabel = new Label();
      nameLabel.Autowrap = true;
      nameLabel.SizeFlagsHorizontal = (int)SizeFlags.ExpandFill;
      // font color
      nameLabel.Theme = fontTheme;
      nameLabel.Text = highScore.Key;

      Label scoreLabel = new Label();
      scoreLabel.SizeFlagsHorizontal = (int)SizeFlags.ShrinkEnd;
      scoreLabel.Theme = fontTheme;
      scoreLabel.Text = highScore.Value.ToString();

      grid.AddChild(nameLabel);
      grid.AddChild(scoreLabel);
    }
  }
}