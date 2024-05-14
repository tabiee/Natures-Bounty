using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Pickup", menuName = "Pickups/Create Weapon Pickup")]
public class WeaponPickup : Pickup
{
    [SerializeField] private ProjectileData weapon;
    public override void PickupUsed()
    {
        int itemCount = 0;

        //count the weapons
        for (int i = 0; i < Player.instance.projectileData.Length; i++)
        {
            if (Player.instance.projectileData[i] != null)
            {
                itemCount++;
            }
        }

        //add to any empty array slot
        if (itemCount < 3)
        {
            for (int i = 0; i < Player.instance.projectileData.Length; i++)
            {
                if (Player.instance.projectileData[i] = null)
                {
                    Player.instance.projectileData[i] = weapon;
                    break;
                }
            }
        }
        //else override the 1st one
        else
        {
            Player.instance.projectileData[0] = weapon;
        }
    }
}
