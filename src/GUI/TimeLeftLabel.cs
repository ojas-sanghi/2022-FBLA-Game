using System;
using Godot;

public class TimeLeftLabel : Label
{
  Timer timer;
  public override void _Ready()
  {
    timer = GetNode<Timer>("Timer");

    // TODO: figure out why the timer restarts before the level does
    timer.Start(LevelInfo.Instance.levelTimeLimits[Globals.Instance.currentLevel]);

    timer.Connect("timeout", this, nameof(OnTimerTimeout));
  }

  public override void _Process(float delta)
  {
    base._Process(delta);

    string time_str = TimeSpan.FromSeconds(timer.TimeLeft).ToString(@"m\:ss");
    this.Text = "Time Left: " + time_str;
  }

  void OnTimerTimeout()
  {
    Events.publishTimeOver();
  }
}
