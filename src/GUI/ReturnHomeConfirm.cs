using System;
using Godot;

public class ReturnHomeConfirm : Control
{

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
    GetTree().Paused = !GetTree().Paused;
    this.Visible = !this.Visible;
  }
}
