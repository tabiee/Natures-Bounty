using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : ScriptableObject
{
    public AudioClip pickupSFX;
    public abstract void PickupUsed();
}
