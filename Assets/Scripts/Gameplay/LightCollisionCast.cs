using Godot;
using System;

public class LightCollisionCast : CollisionShape2D
{
    private RayCast2D _rayCast;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _rayCast = GetNode<RayCast2D>("RayCast2D");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (!Disabled && _rayCast.IsColliding())
        {
            GD.Print("Colliding, now disabling");
            SetDeferred("disabled", true);
        }
        else if (Disabled && !_rayCast.IsColliding())
        {
            GD.Print("No more colliding, now enabling");
            SetDeferred("disabled", false);
        }
    }
}
