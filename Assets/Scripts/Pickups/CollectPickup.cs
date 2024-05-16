using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private Pickup pickup;
    public void EnterInteraction()
    {
        pickup.PickupUsed();
        AudioManager.instance.sfxSource.clip = pickup.pickupSFX;
        AudioManager.instance.sfxSource.Play();
        ReturnToPool();
    }
    private void ReturnToPool()
    {
        gameObject.SetActive(false);
        ObjectPool.instance.ReturnObject(gameObject);
    }
}
