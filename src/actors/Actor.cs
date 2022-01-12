using Godot;
using System;

public class Actor : KinematicBody2D
{
    protected Vector2 FLOOR_NORMAL = Vector2.Up;
    
    [Export] protected Vector2 speed = new Vector2(300, 1000);
    [Export] protected int gravity = 2500;
    [Export] protected int gravityLimit = 800;

    protected Vector2 velocity = Vector2.Zero;
}
