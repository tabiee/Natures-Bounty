using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectionFix : MonoBehaviour
{
    private EventSystem eventsystem;
    private GameObject firstObject;

    private void Awake()
    {
        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        firstObject = GameObject.Find("Char1");
        eventsystem.firstSelectedGameObject = firstObject;
    }
}
