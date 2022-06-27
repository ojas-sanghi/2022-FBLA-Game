using System;
using Godot;

public class SPCamera : Camera2D
{
  public override void _Process(float delta)
  {
    if (Globals.Instance.currentLevel == Enums.Levels.Level3)
    {
      var v = GetViewport();
      float middleXCoord = -316.0987f;
      Vector2 middleOrigin = new Vector2(middleXCoord, v.CanvasTransform.origin.y);
      v.CanvasTransform = new Transform2D(new Vector2(1.333333f, 0), new Vector2(0, 1.333333f), middleOrigin);
    }
  }
}