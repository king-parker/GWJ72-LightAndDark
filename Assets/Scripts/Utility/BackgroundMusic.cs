using Godot;
using System;

public class BackgroundMusic : Node
{
    private enum TrackPlaying
    {
        None,
        Menu,
        Castle
    }

    private AudioStreamPlayer _menuBG;
    private AudioStreamPlayer _castleBG;
    private AudioStreamPlayer[] _players;
    private TrackPlaying _playing;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _playing = TrackPlaying.None;

        _menuBG = GetNode<AudioStreamPlayer>("MenuBG");
        _castleBG = GetNode<AudioStreamPlayer>("CastleBG");

        _players = new AudioStreamPlayer[2] {_menuBG, _castleBG};
    }

    public void PlayMenuBG()
    {
        //if (_playing == TrackPlaying.Menu)
        //{
        //    return;
        //}

        //StopAllStreams();
        //_playing = TrackPlaying.Menu;
        //_menuBG.Play(); 
        PlayCastleBG();
    }

    public void PlayCastleBG()
    {
        if (_playing == TrackPlaying.Castle)
        {
            return;
        }

        StopAllStreams();
        _playing = TrackPlaying.Castle;
        _castleBG.Play();
    }

    private void StopAllStreams()
    {
        foreach (AudioStreamPlayer player in _players)
        {
            player.Stop();
        }
        _playing = TrackPlaying.None;
    }
}
