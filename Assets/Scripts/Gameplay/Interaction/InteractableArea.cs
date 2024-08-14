using Godot;
using System;

public class InteractableArea : Area2D
{
    [Signal] public delegate void Interacted();

    [Export] private string _action = "DO SOMETHING";
}
