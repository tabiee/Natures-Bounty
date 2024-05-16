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
        for (int i = 0; i < Player.instance.projectileDataPack.Length; i++)
        {
            if (Player.instance.projectileDataPack[i] != null)
            {
                itemCount++;
            }
        }

        Debug.Log("itemCount is: " + itemCount);

        //add to any empty array slot
        if (itemCount < 3)
        {
            for (int i = 0; i < Player.instance.projectileDataPack.Length; i++)
            {
                if (Player.instance.projectileDataPack[i] == null)
                {
                    //Debug.Log("add to any empty array slot ran with this item: " + Player.instance.projectileData[i]);
                    Player.instance.projectileDataPack[i] = weapon;
                    WeaponDisplay.instance.weaponSprites[i].sprite = weapon.weaponSprite;
                    break;
                }
            }
        }
        //else override the 1st one
        else
        {
            Debug.Log("override 1st one ran");

            Player.instance.projectileDataPack[0] = weapon;
            WeaponDisplay.instance.weaponSprites[0].sprite = weapon.weaponSprite;
        }
    }
}
