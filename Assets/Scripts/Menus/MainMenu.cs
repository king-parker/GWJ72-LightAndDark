using Godot;
using System;

public class MainMenu : CanvasLayer
{
    //private Button _startButton;
    //private Button _exitButton;
    //private GameManager _gameManager;

    public override void _Ready()
    {
        GameManager gameManager = GetNode<GameManager>("/root/GameManager");

        Button startButton = GetNode<Button>("VBoxContainer/HBoxContainer/VBoxContainer/StartButton");
        startButton.Connect("pressed", gameManager, nameof(GameManager.GotoScene)
            , new Godot.Collections.Array { GameManager.LEVEL_CASTLE_TUTORIAL, GameManager.Scenes.CastleTutorial });
        startButton.GrabFocus();

        Button exitButton = GetNode<Button>("VBoxContainer/HBoxContainer/VBoxContainer/ExitButton");
        exitButton.Connect("pressed", gameManager, nameof(GameManager.ExitGame));

        GetNode<BackgroundMusic>("/root/BackgroundMusic").PlayMenuBG();
    }
}
