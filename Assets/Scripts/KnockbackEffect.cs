using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect On Hit", menuName = "Effects/Create Knockback Effect")]
public class KnockbackEffect : EffectOnHit
{
    public override void ApplyEffect(GameObject target)
    {
        Debug.Log("wowie it's a knockback effect! kewl!!!");
    }
}
