using Godot;
using System;

public class Player : Actor
{
    int timesJumped = 0;
    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(float delta)
    {
        bool isJumpInterrupted = Input.IsActionJustReleased("jump") && velocity.y < 0.0;

        Vector2 direction = GetDirection();
        velocity = CalculateMoveVelocity(velocity, direction, speed, isJumpInterrupted);

        MoveAndSlide(velocity, FLOOR_NORMAL);
    }

    // func get_direction() -> Vector2:
	// return Vector2(
	// 	Input.get_action_strength("move_right") - Input.get_action_strength("move_left"),
	// 	-1.0 if can_jump() else 1.0
	// )

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
            return true;
            if (IsOnFloor())
            {
                timesJumped = 1;
                return true;
            }
            // if (Globals.hasPowerup("double_jump")) && timesJumped == 1)
            // {
            //     timesJumped++;
            //     return true;
            // }
        }
        return false;
    }
}
