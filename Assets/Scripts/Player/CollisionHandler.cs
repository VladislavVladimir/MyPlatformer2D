using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> Interacted;

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.TryGetComponent(out IInteractable interactable))
        {
            Interacted?.Invoke(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.TryGetComponent(out IInteractable _))
        {
            Interacted?.Invoke(null);
        }
    }
}