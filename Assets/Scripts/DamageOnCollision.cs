using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour, IInteractable
{
    [SerializeField] private int collisionDamage = 1;
    private bool playerNearby;
    public void EnterInteraction()
    {
        playerNearby = true;
    }
    public void ExitInteraction()
    {
        playerNearby = false;
    }
    private void Update()
    {
        if (playerNearby)
        {
            PlayerHealth.instance.DamagePlayer(collisionDamage);
        }
    }
}
