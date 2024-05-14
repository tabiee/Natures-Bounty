using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteraction2D : MonoBehaviour
{
    [SerializeField] private LayerMask interactionLayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("trigger entered");

        if (IsInteractable(other.gameObject.layer))
        {
            Component[] interactedObjects = other.transform.GetComponents(typeof(IInteractable));
            foreach (IInteractable interactableScripts in interactedObjects)
            {
                if (interactableScripts != null)
                {
                    interactableScripts.EnterInteraction();
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsInteractable(other.gameObject.layer))
        {
            Component[] interactedObjects = other.transform.GetComponents(typeof(IInteractable));
            foreach (IInteractable interactableScripts in interactedObjects)
            {
                if (interactableScripts != null)
                {
                    interactableScripts.ExitInteraction();
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsInteractable(other.gameObject.layer))
        {
            Component[] interactedObjects = other.transform.GetComponents(typeof(IInteractable));
            foreach (IInteractable interactableScripts in interactedObjects)
            {
                if (interactableScripts != null)
                {
                    interactableScripts.StayInteraction();
                }
            }
        }
    }
    private bool IsInteractable(int layer)
    {
        return (interactionLayer.value & (1 << layer)) != 0;
    }
}
