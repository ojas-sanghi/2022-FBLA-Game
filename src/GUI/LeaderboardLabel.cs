using System;
using Godot;

public class LeaderboardLabel : HBoxContainer
{
  string name = "";
  int score = 0;

  Font font50;
  Theme fontTheme;

  public LeaderboardLabel()
  { }

  public LeaderboardLabel(string name, int score)
  {
    this.name = name;
    this.score = score;
  }

  public override void _Ready()
  {
    font50 = GD.Load<DynamicFont>("res://assets/fonts/ArcadeFont35.tres");
    fontTheme = new Theme();
    fontTheme.DefaultFont = font50;

    Label nameLabel = new Label();
    nameLabel.Autowrap = true;
    nameLabel.SizeFlagsHorizontal = (int)SizeFlags.ExpandFill;
    // <font color>
    nameLabel.Theme = fontTheme;
    nameLabel.Text = name;

    Label scoreLabel = new Label();
    scoreLabel.SizeFlagsHorizontal = (int)SizeFlags.ShrinkEnd;
    scoreLabel.Theme = fontTheme;
    scoreLabel.Text = score.ToString();

    AddChild(nameLabel);
    AddChild(scoreLabel);
  }
}
