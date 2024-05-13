using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour, IInteractable
{
    public void EnterInteraction()
    {
        Debug.Log(gameObject.name + ": I've been interacted with by Entering a trigger!");
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
