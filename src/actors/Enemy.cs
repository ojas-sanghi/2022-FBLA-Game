using Godot;

public class Enemy : Area2D
{
  [Export] int speed = 200;
  [Export] int moveDist = 100;

  bool hitRightExtreme = false;
  bool hitLeftExtreme = true;

  float rightEnd;
  float leftEnd;

  AnimatedSprite sprite;

  public override void _Ready()
  {
    sprite = GetNode<AnimatedSprite>("AnimatedSprite");

    rightEnd = Position.x + moveDist;
    leftEnd = Position.x - moveDist;
  }

  public override void _Process(float delta)
  // Go all the way right until the extreme is hit; then go to the left
  // Once left extreme is hit, go to the right. Then repeat.
  {
    if (Position.x >= rightEnd)
    {
      hitRightExtreme = true;
      hitLeftExtreme = false;
    }
    else if (Position.x <= leftEnd)
    {
      hitRightExtreme = false;
      hitLeftExtreme = true;
    }

    if (hitRightExtreme)
    {
      Position = new Vector2(Position.x - speed * delta, Position.y);
      sprite.FlipH = true;
    }
    else if (hitLeftExtreme)
    {
      Position = new Vector2(Position.x + speed * delta, Position.y);
      sprite.FlipH = false;
    }
  }

  void OnEnemyBodyEntered(Node body)
  {
    if (!(body is Player))
      return;
    var player = (Player)body;

    Events.publishPlayerDied(player.id);
  }

}
