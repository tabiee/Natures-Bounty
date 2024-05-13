using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scrap Pickup", menuName = "Pickups/Create Scrap Pickup")]
public class ScrapPickup : Pickup
{
    public override void PickupUsed()
    {
        //increase money amount or whatever
        Debug.Log("wew money!");
    }
}
