using System;
using Godot;

public class DeathBox : Area2D
{
  void OnDeathBoxBodyEntered(Node body)
  {
    if (body is Player)
    {
      Player p = (Player) body;
      Events.publishPlayerDied(p.id);
    }
  }
}
