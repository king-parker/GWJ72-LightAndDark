using Godot;
using System;

public  class LeverManager : Node
{
    public void ConnectLeverToPlatform(Lever lever, AnimationPlayer platformAnimation, string onAnimationName = "Off to On", string offAnimationName = "On to Off")
    {
        lever.Connect(nameof(Lever.SwitchedOn), this, "LightBlockMove", new Godot.Collections.Array { true, platformAnimation, onAnimationName, offAnimationName });
        lever.Connect(nameof(Lever.SwitchedOff), this, "LightBlockMove", new Godot.Collections.Array { false, platformAnimation, onAnimationName, offAnimationName });
    }

    private void LightBlockMove(bool isSwitchedOn, AnimationPlayer blockAnimation, string onAnimationName, string offAnimationName)
    {
        string animationName;

        if (isSwitchedOn)
        {
            animationName = onAnimationName;
        }
        else
        {
            animationName = offAnimationName;
        }

        blockAnimation.Play(animationName);
    }
}
