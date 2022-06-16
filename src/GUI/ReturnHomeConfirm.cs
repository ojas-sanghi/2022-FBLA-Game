using System;
using Godot;

public class ReturnHomeConfirm : Control
{

  // flag to differentiate the overlay that is in SP, and the overlay that is in MP
  [Export] bool isMPReturnHome = false;

  public override void _Ready()
  {
    this.Visible = false;
  }

  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("ui_cancel"))
    {
      toggleSelf();
    }
  }

  public void toggleSelf()
  {
    if (Globals.Instance.isMultiplayer)
    {
      if (isMPReturnHome)
      {
        GetTree().Paused = !GetTree().Paused;
        this.Visible = !this.Visible;
      }
    }
    else
    {
      if (!isMPReturnHome)
      {
        GetTree().Paused = !GetTree().Paused;
        this.Visible = !this.Visible;
      }
    }
  }
}
