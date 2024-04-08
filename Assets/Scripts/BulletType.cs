using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Type", menuName = "Projectile Assets/Create Bullet Type")]
public class BulletType : ScriptableObject
{
    public float projectileSpeed;
    //inside Projectile
    public float angleSpread;
    //inside Projectile
    public float bulletShape;
    //inside Projectile
    public Color bulletColor;
    //inside Projectile
    public int damageDealt;
    //inside Projectile

    //public EffectOnHit effectOnHit;
    //inside Projectile
}
