using Godot;
using System;

public class MPCamera : Camera2D
{
  public Node2D target;

  public override void _PhysicsProcess(float delta)
  {
    base._PhysicsProcess(delta);

    if (target != null)
    {
      // Position = target.Position;
    }
  }
}
