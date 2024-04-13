using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect On Hit", menuName = "Effects/Create Explosion Effect")]
public class ExplosionEffect : EffectOnHit
{
    public float test;
    public override void ApplyEffect(GameObject target)
    {
        Debug.Log("bwaaahhh explosions! " + test);
    }
}
