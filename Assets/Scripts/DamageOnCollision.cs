using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour, IInteractable
{
    [SerializeField] private int collisionDamage = 1;
    public void EnterInteraction()
    {
        PlayerHealth.instance.DamagePlayer(collisionDamage);
    }
}
