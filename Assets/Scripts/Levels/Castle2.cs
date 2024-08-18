using Godot;
using System;

public class Castle2 : Node2D
{
    private LeverManager _leverManager;
    private BackgroundMusic _backgroundMusic;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _leverManager = GetNode<LeverManager>("/root/LeverManager");

        // Connect Lever1 and Platform1
        Lever lever = GetNode<Lever>("Levers/Lever1");
        AnimationPlayer platformAnimation = GetNode<AnimationPlayer>("TriggeredPlatforms/Platform1/AnimationPlayer");
        _leverManager.ConnectLeverToPlatform(lever, platformAnimation);

        // Connect Lever2 and Platform2
        lever = GetNode<Lever>("Levers/Lever2");
        platformAnimation = GetNode<AnimationPlayer>("TriggeredPlatforms/Platform2/AnimationPlayer");
        _leverManager.ConnectLeverToPlatform(lever, platformAnimation);

        // Connect Lever3 and Platform3
        lever = GetNode<Lever>("Levers/Lever3");
        platformAnimation = GetNode<AnimationPlayer>("TriggeredPlatforms/Platform3/AnimationPlayer");
        _leverManager.ConnectLeverToPlatform(lever, platformAnimation);

        // Connect Lever4 and Platform4
        lever = GetNode<Lever>("Levers/Lever4");
        platformAnimation = GetNode<AnimationPlayer>("TriggeredPlatforms/Platform4/AnimationPlayer");
        _leverManager.ConnectLeverToPlatform(lever, platformAnimation);

        // Connect Lever5 and Platform5
        lever = GetNode<Lever>("Levers/Lever5");
        platformAnimation = GetNode<AnimationPlayer>("TriggeredPlatforms/Platform5/AnimationPlayer");
        _leverManager.ConnectLeverToPlatform(lever, platformAnimation);

        // Connect Lever6 and Platform6
        lever = GetNode<Lever>("Levers/Lever6");
        platformAnimation = GetNode<AnimationPlayer>("TriggeredPlatforms/Platform6/AnimationPlayer");
        _leverManager.ConnectLeverToPlatform(lever, platformAnimation);

        _backgroundMusic = GetNode<BackgroundMusic>("/root/BackgroundMusic");
        _backgroundMusic.PlayCastleBG();
    }
}
