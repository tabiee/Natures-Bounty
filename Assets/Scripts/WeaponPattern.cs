using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Pattern", menuName = "Projectile Assets/Create Weapon Pattern")]
public class WeaponPattern : ScriptableObject
{
    public int bulletsPerShot;
    //IEnumerator inside Shooter?
    public float rateOfFire;
    //cooldown inside Shooter
}
