using System;
using Godot;

public class TimeCounter : Label
{
  float time = 0;

  public override void _Process(float delta)
  {
    base._Process(delta);

    time += delta;

    if (time > LevelInfo.Instance.parTimeSeconds)
    {
      this.AddColorOverride("font_color", new Color("a61e1e"));
    }

    string time_str = TimeSpan.FromSeconds(time).ToString(@"m\:ss");
    this.Text = "Time Spent: " + time_str;
  }
}