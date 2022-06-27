using System;
using Godot;

public class InstructionLabel : Label
{
  [Export] int appearanceOrder = 0;

  public override void _Ready()
  {
    if (appearanceOrder != 0)
      this.SelfModulate = new Color(1, 1, 1, 0);
      // Hide();
    
    Events.instructionAreaHit += OnInstructionAreaHit;
  }

  public override void _ExitTree()
  {
    Events.instructionAreaHit -= OnInstructionAreaHit;
  }

  void OnInstructionAreaHit(int areaNum)
  {
    if (areaNum == this.appearanceOrder)
    {
      // Show();
      ShowSelf();
    }
  }

  void ShowSelf()
  {
    if (this.SelfModulate == new Color(1, 1, 1, 1)) return;

    Tween tween = new Tween();
    this.AddChild(tween);
    tween.InterpolateProperty(this, "self_modulate", new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), 0.35f);
    tween.Start();
  }

}
