using Godot;
using System;

public class TestLevel : Node2D
{
    private Lever _lever1;
    private AnimationPlayer _lightBlocker2Animation;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Set up lever/block movement
        _lightBlocker2Animation = GetNode<AnimationPlayer>("World/LightBlockers/LightBlocker2/AnimationPlayer");
        _lever1 = GetNode<Lever>("Levers/Lever1");
        _lever1.Connect(nameof(Lever.SwitchedOn), this, "LightBlockMove", new Godot.Collections.Array { true, _lightBlocker2Animation });
        _lever1.Connect(nameof(Lever.SwitchedOff), this, "LightBlockMove", new Godot.Collections.Array { false, _lightBlocker2Animation });
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    private void LightBlockMove(bool isSwitchedOn, AnimationPlayer blockAnimation)
    {
        string animationName;

        if (isSwitchedOn)
        {
            animationName = "Off to On";
        }
        else
        {
            animationName = "On to Off";
        }

        blockAnimation.Play(animationName);
    }
}
