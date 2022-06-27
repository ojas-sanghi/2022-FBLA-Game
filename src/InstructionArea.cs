using System;
using Godot;

public class InstructionArea : Area2D
{
  [Export] int areaNum = 1;

  void OnInstructionAreaBodyEntered(Node body)
  {
    if (body is Player)
    {
      Events.publishInstructionAreahit(areaNum);
    }
  }
}
