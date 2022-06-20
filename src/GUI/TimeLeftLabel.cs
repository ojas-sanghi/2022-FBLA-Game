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
    GD.Print(GetParent().Name);
    Events.publishTimeOver();
  }

  void OnLevelPassed()
  {
    // TODO
    // accept the id parameter
    // figure out how the sngletons deal with the different ids
    // how to deal with different player's different scores and coins?
    // where are those currently tracked?
    PlayerInfo.score += LevelInfo.Instance.coinsCollected[(int)Globals.Instance.currentLevel] * PlayerInfo.coinsScoreMultiplier;
  }
}
