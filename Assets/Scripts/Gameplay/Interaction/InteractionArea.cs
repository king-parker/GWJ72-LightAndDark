using Godot;
using System;

public class InteractionArea : Area2D
{
    // Useful for a UI element to display interaction prompt
    [Signal] public delegate void NearestInteractableChanged(InteractableArea interactable);

    private InteractableArea _nearestInteractable;

    public override void _Process(float delta)
    {
        var areas = GetOverlappingAreas();
        float shortestDistance = float.PositiveInfinity;
        InteractableArea nextNearestInteractable = null;

        foreach (Area2D area in areas)
        {
            if (area is InteractableArea interactableArea)
            {
                float distance = interactableArea.GlobalPosition.DistanceTo(GlobalPosition);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nextNearestInteractable = interactableArea;
                }
            }
        }

        if (nextNearestInteractable != _nearestInteractable)
        {
            _nearestInteractable = nextNearestInteractable;
            EmitSignal(nameof(NearestInteractableChanged), _nearestInteractable);
        }
    }

    public void AttemptInteraction()
    {
        if (IsInstanceValid(_nearestInteractable))
        {
            _nearestInteractable.EmitSignal(nameof(InteractableArea.Interacted));
        }
    }
}
