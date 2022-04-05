using System;
using Godot;

public class MusicPlayer : Node2D
{
  public AudioStreamPlayer audioPlayer;

  public static MusicPlayer Instance;

  public MusicPlayer()
  {
    Instance = this;
  }

  public override void _Ready()
  {
    audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
    Instance = this;
  }


  public void playMusic(AudioStream stream)
  {
    audioPlayer.Stream = stream;
    audioPlayer.Play();
  }
}
