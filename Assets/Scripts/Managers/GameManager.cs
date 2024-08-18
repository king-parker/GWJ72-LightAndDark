using Godot;
using System;

public class GameManager : Node
{
    public static string MAIN_MENU = "res://Assets/Scenes/Menus/MainMenu.tscn";
    public static string LEVEL_CASTLE_TUTORIAL = "res://Assets/Scenes/Levels/CastleTutorial.tscn";
    public static string LEVEL_CASTLE_1 = "res://Assets/Scenes/Levels/Castle1.tscn";
    public static string LEVEL_CASTLE_2 = "res://Assets/Scenes/Levels/Castle2.tscn";
    public static string WIN_SCREEN = "res://Assets/Scenes/Menus/WinScreen.tscn";

    public enum Scenes
    {
        MainMenu,
        CastleTutorial,
        Castle2,
        WinScreen
    }

    private Node _currentScene;
    private Scenes _currentSceneEnum;

    public override void _Ready()
    {
        Viewport root = GetTree().Root;
        _currentScene = root.GetChild(root.GetChildCount() - 1); // Current scene is the last child in the root node
        _currentSceneEnum = Scenes.MainMenu;
    }

    public void GotoNextLevel()
    {
        switch (_currentSceneEnum)
        {
            case Scenes.MainMenu:
                GotoScene(LEVEL_CASTLE_TUTORIAL, Scenes.CastleTutorial);
                break;
            case Scenes.CastleTutorial:
                GotoScene(LEVEL_CASTLE_2, Scenes.Castle2);
                break;
            case Scenes.Castle2:
                GotoScene(WIN_SCREEN, Scenes.WinScreen);
                break;
            case Scenes.WinScreen:
                GotoScene(MAIN_MENU, Scenes.MainMenu);
                break;
        }
    }

    public void GotoScene(string path, Scenes newScene)
    {
        _currentSceneEnum = newScene;
        CallDeferred(nameof(DeferredGotoScene), path);
    }

    public void ExitGame()
    {
        GetTree().Quit();
    }

    private void DeferredGotoScene(string path)
    {
        _currentScene.Free();

        var nextScene = GD.Load<PackedScene>(path);

        _currentScene = nextScene.Instance();

        GetTree().Root.AddChild(_currentScene);

        GetTree().CurrentScene = _currentScene;
    }
}
