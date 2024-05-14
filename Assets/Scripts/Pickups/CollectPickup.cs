using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private Pickup pickup;
    public void EnterInteraction()
    {
        pickup.PickupUsed();
        Destroy(this.gameObject);
    }
}
