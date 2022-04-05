using Godot;
using System;

public class CancelReturnHomeButton : Button
{
  void onCancelReturnHomeButtonPressed()
  {
    ((ReturnHomeConfirm)GetParent()).toggleSelf();
  }
}
