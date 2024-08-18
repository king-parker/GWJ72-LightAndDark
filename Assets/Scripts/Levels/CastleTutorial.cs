using Godot;
using System;

public class CastleTutorial : Node2D
{
    private GameManager _gameManager;
    private BackgroundMusic _backgroundMusic;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _gameManager = GetNode<GameManager>("/root/GameManager");

        _backgroundMusic = GetNode<BackgroundMusic>("/root/BackgroundMusic");
        _backgroundMusic.PlayCastleBG();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
