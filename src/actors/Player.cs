using System;
using Godot;

public class Player : Actor
{
  [Export] AnimatedSprite sprite;

  int timesJumped = 0;
  // used to keep track of current animation to be played
  string _anim = "";

  public override void _Ready()
  {
    base._Ready();
    sprite = GetNode<AnimatedSprite>("AnimatedSprite");
    Events.playerDied += OnPlayerDied;
  }

  public override void _PhysicsProcess(float delta)
  {
    bool isJumpInterrupted = Input.IsActionJustReleased("jump") && velocity.y < 0.0;

    Vector2 direction = GetDirection();
    velocity = CalculateMoveVelocity(velocity, direction, speed, isJumpInterrupted);

    MoveAndSlide(velocity, FLOOR_NORMAL);

    AnimatePlayer(velocity);
  }

  Vector2 GetDirection()
  {
    return new Vector2(
      Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left"),
      CanJump() ? -1.0f : 1.0f
    );
  }

  Vector2 CalculateMoveVelocity(Vector2 linearVelocity, Vector2 direction, Vector2 speed, bool isJumpInterrupted)
  {
    Vector2 newVel = linearVelocity;

    newVel.x = speed.x * direction.x;

    newVel.y += gravity * GetPhysicsProcessDeltaTime();

    if (newVel.y > gravityLimit)
    {
      newVel.y = gravityLimit;
    }

    if (direction.y == -1.0f)
    {
      newVel.y = speed.y * direction.y;
    }

    if (isJumpInterrupted)
    {
      newVel.y = 0.0f;
    }

    return newVel;
  }

  bool CanJump()
  {
    if (Input.IsActionJustPressed("jump"))
    {
      if (IsOnFloor())
      {
        timesJumped = 1;
        return true;
      }
      if (timesJumped == 1)
      {
        timesJumped++;
        return true;
      }
    }
    return false;
  }

  void AnimatePlayer(Vector2 linearVel)
  {
    // default new anim
    string newAnim = "idle";

    // Flip the sprite horizontally if they're moving left
    if (linearVel.x < 0)
    {
      sprite.FlipH = true;
      newAnim = "walk";
    }
    else if (linearVel.x > 0)
    {
      // Undo any existing flip if they're moving to the right
      sprite.FlipH = false;
      newAnim = "walk";
    }
    else
    {
      newAnim = "idle";
    }
    
    // If they're going up, set the jumping animation
    // Otherwise, set the fall animation
    if (linearVel.y < 0)
    {
      newAnim = "jump";
    }
    else if (linearVel.y > 0 && !IsOnFloor())
    {
      newAnim = "fall";
    }
    
    GD.Print(linearVel);

    // Play the new animation if it's different
    if (newAnim != _anim)
    {
      _anim = newAnim;
      sprite.Play(newAnim);
    }
  }

  async void OnPlayerDied()
  {
    // stop movement
    SetPhysicsProcess(false);

    // reset gold earned
    PlayerInfo.Instance.resetGoldEarned();

    // play death anim
    sprite.Playing = false;
    sprite.Stop();

    sprite.Visible = false;
    await ToSignal(GetTree().CreateTimer(0.3f), "timeout");
    sprite.Visible = true;
    await ToSignal(GetTree().CreateTimer(0.3f), "timeout");
    sprite.Visible = false;
    await ToSignal(GetTree().CreateTimer(0.3f), "timeout");
    sprite.Visible = true;
    await ToSignal(GetTree().CreateTimer(0.3f), "timeout");
    
    // wait and then reload scene
    await ToSignal(GetTree().CreateTimer(0.25f), "timeout");
    SceneChanger.Instance.GoToScene("res://src/GUI/LoseScreen.tscn");
  }
}
