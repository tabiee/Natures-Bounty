using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject defaultBulletPrefab;
    [SerializeField] private Projectile projectile;
    private float cooldownWaitTime = 0.0f;


    //the shooter needs a prefab to modify. default bullet
    //the shooter should have WPattern and BType (that can be changed)
    //shooter uses that data to modify default data of the prefab
    //shooter shoots the shooty mc shoot thing
    private void Start()
    {
        projectile = defaultBulletPrefab.GetComponent<Projectile>();
    }


    protected void Shoot(ProjectileData projData)
    {
        Debug.Log($"{ this} says that bulletsPerShot is: {projData.weaponPattern.bulletsPerShot}");

        projectile.projectileData = projData;
        //defaultBulletPrefab.gameObject.transform.rotation = transform.rotation;
        GameObject bullet = Instantiate(defaultBulletPrefab,transform.position, Quaternion.identity);
        bullet.transform.rotation = transform.rotation;

        //if (CooldownOver())
        //{
        //    cooldownWaitTime = Time.time + projData.weaponPattern.rateOfFire;
        //    StartCoroutine(SpawnBullets(projData.weaponPattern.bulletsPerShot, projData.weaponPattern.timeBetweenShots));
        //}
    }

    //IEnumerator SpawnBullets(int amount, float timeBetween)
    //{
    //    for (int i = 0; i < amount; i++)
    //    {
    //        Instantiate(defaultBulletPrefab, transform.position, Quaternion.identity);

    //        yield return new WaitForSeconds(timeBetween);
    //    }
    //}
    private bool CooldownOver()
    {
        return Time.time > cooldownWaitTime;
    }

    //protected void FireBullet(Vector3 position, Vector3 direction, float speed)
    //{
    //    // Example implementation: Instantiate a bullet GameObject
    //    GameObject bullet = InstantiateBullet(position);
    //}

    //// Helper method to instantiate a bullet GameObject
    //private GameObject InstantiateBullet(Vector3 position)
    //{
    //    // Example: Instantiate a bullet prefab at the specified position
    //    GameObject bulletPrefab = GetBulletPrefab(); // Implement this method in subclasses
    //    GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
    //    return bullet;
    //}

    ////Abstract method to be implemented by subclasses to provide the bullet prefab
    //protected abstract GameObject GetBulletPrefab();
}
