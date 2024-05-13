using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Pickup", menuName = "Pickups/Create Weapon Pickup")]
public class WeaponPickup : Pickup
{
    [SerializeField] private ProjectileData weapon;
    public override void PickupUsed()
    {
        Player.instance.projectileData = weapon;
    }
}
