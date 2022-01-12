using System;
using Godot;

public class Events : Node
{
    public static event Action example;

    //////////////////////////

    public static void publishExample() => example?.Invoke();


    public override void _Ready()
    {
        // OS.WindowMaximised = true;
    }
}