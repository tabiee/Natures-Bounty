using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //movement itself aka move forward in direction it is facing
    //time it takes to disappear
    //effects on hit

    [HideInInspector] public ProjectileData projectileData;
    [HideInInspector] public Vector3 direction;
    [HideInInspector] public ObjectPool projectilePool;
    private void OnCollisionEnter(Collision collision)
    {
        //ashdajskdjaskdasdksa
    }

    private void Start()
    {
        float projectileLifetime = projectileData.projectileRange;
        Invoke("DestroyThis", projectileLifetime);
    }
    private void Update()
    {
        MoveProjectile();
    }
    void MoveProjectile()
    {
        transform.Translate(direction.normalized * projectileData.projectileSpeed * Time.deltaTime);
    }
    void DestroyThis()
    {
        gameObject.SetActive(false);
        projectilePool.ReturnObject(gameObject);
        //Destroy(this.gameObject);
    }
}
