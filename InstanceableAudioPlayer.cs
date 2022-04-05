using System;
using Godot;

public class InstanceableAudioPlayer : Node2D
{
  [Export] AudioStream song;

  public override void _Ready()
  {
    if (MusicPlayer.Instance.audioPlayer.Stream != song)
    {
      MusicPlayer.Instance.playMusic(song);
    }
  }

}
