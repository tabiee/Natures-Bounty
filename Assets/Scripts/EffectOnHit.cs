using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectOnHit : ScriptableObject
{
    public abstract void ApplyEffect(GameObject target);
}
