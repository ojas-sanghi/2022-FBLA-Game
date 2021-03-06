using System;
using Godot;

public class TimeLeftLabel : Label
{
  Timer timer;
  
  // set by parent InfoHUD
  [Export] public bool disabled = false;

  public override void _Ready()
  {
    if (disabled) return;

    timer = GetNode<Timer>("Timer");
    timer.Connect("timeout", this, nameof(OnTimerTimeout));

    resetAndStartTimer();

    Events.levelPassed += OnLevelPassed;
  }

  public override void _ExitTree()
  {
    Events.levelPassed -= OnLevelPassed;
  }

  public void resetAndStartTimer()
  {
    if (disabled) return;
    timer.Start(LevelInfo.Instance.levelTimeLimits[Globals.Instance.currentLevel]);
  }

  public override void _Process(float delta)
  {
    if (disabled) return;
    string time_str = TimeSpan.FromSeconds(timer.TimeLeft).ToString(@"m\:ss");
    this.Text = "Time Left: " + time_str;
  }

  void OnTimerTimeout()
  {
    if (disabled) return;
    Events.publishTimeOver();
  }

  void OnLevelPassed(int id)
  {
    LevelInfo.Instance.scoreCollected[id] += (int) (timer.TimeLeft * PlayerInfo.timeScoreMultiplier);
    Events.publishScoreChanged(id);
  }
}
