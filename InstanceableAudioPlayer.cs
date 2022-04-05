using System;
using Godot;

public class InstanceableAudioPlayer : Node2D
{

  [Export] AudioStream song;

  public override void _Ready()
  {
    MusicPlayer.Instance.playMusic(song);
  }

}
