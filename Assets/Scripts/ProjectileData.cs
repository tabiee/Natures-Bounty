using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Projectile Assets/Create Projectile Data")]
public class ProjectileData : ScriptableObject
{
    [Tooltip("Which prefab will be instantiated inside ProjectileSpawner.")]
    public GameObject projectilePrefab;

    [Tooltip("The projectile class of each instance of the prefab.")]
    public Projectile projectile;

    [Tooltip("Time between each projectile/all coroutine loops.")]
    public float rateOfFire = 1f;

    //===========================

    [Header("If there's more than 1 projectile, \n either increase angleSpread or turn on stagger")]
    [Tooltip("How many projectiles get instantiated in a coroutine loop.")]
    public int projectilesPerBurst = 1;

    [Tooltip("How big the cone of projectile spread is.")]
    [Range(0, 360)] public float angleSpread;

    //===========================

    [Header("Bursts prefered to be only on enemies \n If burstCount is 1, keep timeBetweenBursts at 0")]
    [Tooltip("How many times the coroutine loops per rateOfFire shot.")]
    public int burstCount = 1;

    [Tooltip("Cooldown between each coroutine loop.")]
    public float timeBetweenBursts = 0f;

    [Tooltip("Delay between each projectile in a loop.")]
    public bool stagger;

    [Tooltip("Back and forth motion affected by angleSpread.")]
    public bool oscillate;

    //===========================

    [Tooltip("How fast the projectile moves.")]
    public float projectileSpeed = 1f;

    [Tooltip("How long until the projectile is destroyed.")]
    public float projectileLifetime = 1f;

    [Tooltip("How far the entity is pushed when hit by the projectile.")]
    public float projectileKnockback = 1f;

    [Tooltip("How big and/or what shape the bullet is.")]
    public Vector3 projectileShape = new Vector3(1f, 1f, 1f);

    [Tooltip("How much damage it does on hit.")]
    public int damageDealt = 1;

    [Tooltip("What it does when colliding with entity/object.")]
    public EffectOnHit effectOnHit;
}
