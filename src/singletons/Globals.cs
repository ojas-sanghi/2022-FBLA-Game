using Godot;
using System;

public class Globals : Node
{
    public static Globals Instance;

    public Globals()
    {
        Instance = this;
    }

    public override void _Ready()
    {
        Instance = this;
    }
}
