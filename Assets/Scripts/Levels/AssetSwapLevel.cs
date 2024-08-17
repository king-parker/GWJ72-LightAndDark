using Godot;
using System;

public class AssetSwapLevel : Node2D
{
    private LeverManager _leverManager;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _leverManager = GetNode<LeverManager>("/root/LeverManager");

        // Connect Lever1 and Platform 1
        Lever lever = GetNode<Lever>("Levers/Lever1");
        AnimationPlayer platformAnimation = GetNode<AnimationPlayer>("LightBlockingPlatforms/Platform1/AnimationPlayer");
        _leverManager.ConnectLeverToPlatform(lever, platformAnimation);
    }
}
