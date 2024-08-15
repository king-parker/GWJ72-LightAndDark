using Godot;
using System;

public class MovableBox : RigidBody2D
{
    [Export] private float _maxSpeed = 10f;

    public override void _IntegrateForces(Physics2DDirectBodyState state)
    {
        AngularVelocity = 0;
        RotationDegrees = 0;

        if (Mathf.Abs(LinearVelocity.x) > _maxSpeed)
        {
            if (LinearVelocity.x > 0)
            {
                LinearVelocity = new Vector2(_maxSpeed, LinearVelocity.y);
            }
            else
            {
                LinearVelocity = new Vector2(-_maxSpeed, LinearVelocity.y);
            }
        }

        if (AppliedForce.x == 0 && LinearVelocity.x != 0)
        {
            LinearVelocity = new Vector2(LinearVelocity.x / 2, LinearVelocity.y);
        }
    }
}
