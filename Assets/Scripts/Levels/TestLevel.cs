using Godot;
using System;

public class TestLevel : Node2D
{
    private AnimationPlayer _lightBlocker2Animation;
    private CollisionShape2D _light2CollisionShape;
    private Lever _lever1;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _lightBlocker2Animation = GetNode<AnimationPlayer>("World/LightBlockers/LightBlocker2/AnimationPlayer");

        _light2CollisionShape = GetNode<CollisionShape2D>("Lights/Light2/CollisionShape2D");

        _lever1 = GetNode<Lever>("Levers/Lever1");
        _lever1.Connect(nameof(Lever.SwitchedOn), this, "LightBlockMove", new Godot.Collections.Array { true, _lightBlocker2Animation, _light2CollisionShape });
        _lever1.Connect(nameof(Lever.SwitchedOff), this, "LightBlockMove", new Godot.Collections.Array { false, _lightBlocker2Animation, _light2CollisionShape });
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    private void LightBlockMove(bool isSwitchedOn, AnimationPlayer blockAnimation, CollisionShape2D lightCollision)
    {
        string animationName;
        bool collisionDisabled = false;

        if (isSwitchedOn)
        {
            animationName = "Off to On";
            collisionDisabled = true;
        }
        else
        {
            animationName = "On to Off";
            collisionDisabled = false;
        }

        blockAnimation.Play(animationName);
        //lightCollision.Disabled = collisionDisabled;
        lightCollision.SetDeferred("disabled", collisionDisabled);
    }
}
