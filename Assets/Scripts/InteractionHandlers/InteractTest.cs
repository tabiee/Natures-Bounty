using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTest : MonoBehaviour, IInteractable
{
    public void UseInteraction()
    {
        Debug.Log(gameObject.name + ": I've been interacted with by pressing E!");
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
