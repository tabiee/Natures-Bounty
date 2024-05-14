using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health Pickup", menuName = "Pickups/Create Health Pickup")]
public class HealthPickup : Pickup
{
    [SerializeField] private int amountToHeal;
    public override void PickupUsed()
    {
        PlayerHealth.instance.HealPlayer(amountToHeal);
    }
}
