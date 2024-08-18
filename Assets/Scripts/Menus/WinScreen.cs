using Godot;
using System;

public class WinScreen : CanvasLayer
{
    public override void _Ready()
    {
        GameManager gameManager = GetNode<GameManager>("/root/GameManager");

        Button mainMenuButton = GetNode<Button>("VBoxContainer/HBoxContainer/VBoxContainer/MainMenuButton");
        mainMenuButton.Connect("pressed", gameManager, nameof(GameManager.GotoScene)
            , new Godot.Collections.Array { GameManager.MAIN_MENU, GameManager.Scenes.MainMenu });
        mainMenuButton.GrabFocus();

        Button exitButton = GetNode<Button>("VBoxContainer/HBoxContainer/VBoxContainer/ExitButton");
        exitButton.Connect("pressed", gameManager, nameof(GameManager.ExitGame));

        GetNode<BackgroundMusic>("/root/BackgroundMusic").PlayMenuBG();
    }
}
