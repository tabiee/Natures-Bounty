using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health Pickup", menuName = "Pickups/Create Health Pickup")]
public class HealthPickup : Pickup
{
    int amountToHeal;
    public override void CollectPickup()
    {
        PlayerHealth.instance.HealPlayer(amountToHeal);
    }
}
