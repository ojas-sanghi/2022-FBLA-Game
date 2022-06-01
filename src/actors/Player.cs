using Godot;
using System.Threading.Tasks;

public class Player : Actor
{
  // what id player is; input is read differently accordingly
  [Export] public int id = 1;

  AnimatedSprite sprite;

  int timesJumped = 0;
  // used to keep track of current animation to be played
  string _anim = "";

  public override void _Ready()
  {
    base._Ready();
    sprite = GetNode<AnimatedSprite>("AnimatedSprite");
    // Events.playerDied += OnPlayerDied;

    if (!Globals.Instance.isMultiplayer)
    {
      // set id to 0 if singleplayer; will respond to both wasd and arrow keys
      id = 0;
      // and also enable the child camera
      GetNode<Camera2D>("Camera2D").Current = true;
    }
  }

  public override void _ExitTree()
  {
    // Events.playerDied -= OnPlayerDied;
  }

  public override void _PhysicsProcess(float delta)
  {
    bool isJumpInterrupted = Input.IsActionJustReleased($"jump_{id}") && velocity.y < 0.0;

    // get direction and velocity, move, and then animate player
    Vector2 direction = GetDirection();
    velocity = CalculateMoveVelocity(velocity, direction, speed, isJumpInterrupted);

    MoveAndSlide(velocity, FLOOR_NORMAL);

    AnimatePlayer(velocity);
  }

  Vector2 GetDirection()
  {
    return new Vector2(
      Input.GetActionStrength($"right_{id}") - Input.GetActionStrength($"left_{id}"),
      CanJump() ? -1.0f : 1.0f
    );
  }

  Vector2 CalculateMoveVelocity(Vector2 linearVelocity, Vector2 direction, Vector2 speed, bool isJumpInterrupted)
  {
    Vector2 newVel = linearVelocity;

    newVel.x = speed.x * direction.x;

    newVel.y += gravity * GetPhysicsProcessDeltaTime();

    // cap downward speed ot gravity limit
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
    if (Input.IsActionJustPressed($"jump_{id}"))
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

    // Play the new animation if it's different
    if (newAnim != _anim)
    {
      _anim = newAnim;
      sprite.Play(newAnim);
    }
  }

  public async Task OnPlayerDied(int id)
  {
    if (id != this.id) return;

    // stop movement
    SetPhysicsProcess(false);

    // reset coins collected
    LevelInfo.Instance.resetCoinsCollected();

    // play death anim
    sprite.Playing = false;
    sprite.Stop();

    // blink the sprite in and out
    sprite.Visible = false;
    await ToSignal(GetTree().CreateTimer(0.3f), "timeout");
    sprite.Visible = true;
    await ToSignal(GetTree().CreateTimer(0.3f), "timeout");
    sprite.Visible = false;
    await ToSignal(GetTree().CreateTimer(0.3f), "timeout");
    sprite.Visible = true;
    await ToSignal(GetTree().CreateTimer(0.3f), "timeout");

    if (!Globals.Instance.isMultiplayer)
    {
      // wait and then reload scene ONLY IF singleplayer
      await ToSignal(GetTree().CreateTimer(0.25f), "timeout");
      GetTree().ReloadCurrentScene();
    }
    // if MP, then MPBase.cs will reload the level
  }
}
