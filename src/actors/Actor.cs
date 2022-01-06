using Godot;
using System;

public class Actor : KinematicBody2D
{
    const Vector2 FLOOR_NORMAL = Vector2.UP;
    
    [Export] Vector2 speed = new Vector2(300, 1000);
    [Export] int gravity = 2500;
    [Export] int gravityLimit = 800;

    Vector2 velocity = Vector2.ZERO;
}
