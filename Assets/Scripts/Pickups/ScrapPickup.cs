using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scrap Pickup", menuName = "Pickups/Create Scrap Pickup")]
public class ScrapPickup : Pickup
{
    [SerializeField] private int scrapAmount;
    public override void PickupUsed()
    {
        //increase money amount or whatever
        ScoreManager.instance.UpdateScrapCount(scrapAmount);
        Debug.Log("wew money! " + scrapAmount);
    }
}
