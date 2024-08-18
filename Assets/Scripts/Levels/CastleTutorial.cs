using Godot;
using System;

public class CastleTutorial : Node2D
{
    private GameManager _gameManager;
    private LeverManager _leverManager;
    private BackgroundMusic _backgroundMusic;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _gameManager = GetNode<GameManager>("/root/GameManager");

        _leverManager = GetNode<LeverManager>("/root/LeverManager");

        // Connect Lever1 and Platform2
        Lever lever = GetNode<Lever>("Levers/Lever1");
        AnimationPlayer platformAnimation = GetNode<AnimationPlayer>("Platforms/Platform2/AnimationPlayer");
        _leverManager.ConnectLeverToPlatform(lever, platformAnimation);

        _backgroundMusic = GetNode<BackgroundMusic>("/root/BackgroundMusic");
        _backgroundMusic.PlayCastleBG();
    }
}
