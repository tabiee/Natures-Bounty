using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private Pickup pickup;
    public void EnterInteraction()
    {
        pickup.PickupUsed();
        ReturnToPool();
    }
    private void ReturnToPool()
    {
        gameObject.SetActive(false);
        ObjectPool.instance.ReturnObject(gameObject);
    }
}
