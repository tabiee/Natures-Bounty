using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Pickup", menuName = "Pickups/Create Weapon Pickup")]
public class WeaponPickup : Pickup
{
    ProjectileData weapon;
    public override void CollectPickup()
    {
        Player.instance.projectileData = weapon;
    }
}
