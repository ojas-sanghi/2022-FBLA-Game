using System;
using Godot;

public class ParTimeLabel : Label
{
  public override void _Ready()
  {
    string time_str = TimeSpan.FromSeconds(LevelInfo.Instance.parTimeSeconds).ToString(@"m\:ss");
    this.Text = "Par Time: " + time_str;
  }
}
