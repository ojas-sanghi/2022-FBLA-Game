using Godot;

public class Enemy : Area2D
{

  [Export] int speed = 200;
  [Export] int moveDist = 100;

  bool hitRightExtreme = false;
  bool hitLeftExtreme = true;

  float rightEnd;
  float leftEnd;

  public override void _Ready()
  {
    rightEnd = Position.x + moveDist;
    leftEnd = Position.x - moveDist;
  }

  public override void _Process(float delta)
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
      Position = new Vector2(Position.x - speed * delta, Position.y);
    else if (hitLeftExtreme)
      Position = new Vector2(Position.x + speed * delta, Position.y);
  }

}
