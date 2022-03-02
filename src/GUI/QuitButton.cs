using Godot;
using System;

public class QuitButton : Button
{
    void OnQuitButtonPressed()
    {
        GetTree().Quit();
    }
}
