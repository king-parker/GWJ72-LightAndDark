using Godot;
using System;

public class Lever : Node2D
{
    [Signal] public delegate void SwitchedOn();
    [Signal] public delegate void SwitchedOff();

    public bool isOn = false;

    private InteractableArea _interactableArea;
    private AnimatedSprite _animatedSprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        isOn = false;

        _interactableArea = GetNode<InteractableArea>("InteractableArea");
        _interactableArea.Connect(nameof(InteractableArea.Interacted), this, "SwitchLever");

        _animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
        _animatedSprite.Play("default");
    }

    public bool SwitchLever()
    {
        isOn = !isOn;

        if (isOn)
        {
            _animatedSprite.Play("on");
            EmitSignal(nameof(SwitchedOn));
        }
        else
        {
            _animatedSprite.Play("off");
            EmitSignal(nameof(SwitchedOff));
        }

        return isOn;
    }
}
