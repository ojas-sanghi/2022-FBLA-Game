using System;
using Godot;

public class BaseCoin : Area2D
{
  public int goldValue = 0;
  public int scoreValue = 0;

  async void OnCoinBodyEntered(Node n)
  {
    if (n is Player)
    {
      Events.publishCoinCollected(this);

      CollisionShape2D collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
      collisionShape.SetDeferred("disabled", true);

      Sprite sprite = GetNode<Sprite>("Sprite");
      Tween tween = GetNode<Tween>("Tween");

      float transTime = 0.5f;
      tween.InterpolateProperty(sprite, "scale", sprite.Scale, new Vector2(sprite.Scale * 2), transTime, Tween.TransitionType.Cubic, Tween.EaseType.Out);
      tween.InterpolateProperty(sprite, "modulate", new Color(1, 1, 1, 1), new Color(0, 0, 0, 0), transTime, Tween.TransitionType.Linear, Tween.EaseType.Out);
      tween.Start();

      await ToSignal(tween, "tween_completed");
      QueueFree();
    }
  }
}
