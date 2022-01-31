using System;
using Godot;

public class LevelEndArea : Area2D
{
  void OnLevelEndAreaBodyEntered(Node body)
  {
    if (body is Player)
    {
      SceneChanger.Instance.GoToScene("res://src/GUI/PowerupShop.tscn");
    }
  }
}
