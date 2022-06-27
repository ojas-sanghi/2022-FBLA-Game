using System;
using System.Threading.Tasks;
using Godot;

public class SceneChanger : Control
{
  public static SceneChanger Instance;

  AnimationPlayer player;
  Label roundLabel;

  public SceneChanger()
  {
    Instance = this;
  }

  public override void _Ready()
  {
    Instance = this;

    player = GetNode<AnimationPlayer>("CanvasLayer/AnimationPlayer");
    roundLabel = GetNode<Label>("CanvasLayer/RoundLabel");

    roundLabel.Show();
    roundLabel.SelfModulate = new Color(1, 1, 1, 0);
  }


  // Fades to black
  async public Task FadeOut()
  {
    player.Play("fade_out");
    await ToSignal(player, "animation_finished");
  }

  async public Task FadeIn()
  {
    player.Play("fade_in");
    await ToSignal(player, "animation_finished");
  }

  public void GoToPackedScene(PackedScene packedScene)
  {
    GoToScene(packedScene.ResourcePath);
  }

  async public void GoToScene(string scenePath)
  {
    await FadeOut();

    GetTree().ChangeScene(scenePath);

    await FadeIn();
  }
}