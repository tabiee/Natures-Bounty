using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData projectileData;

    public float bulletLife = 1f;
    public float rotation = 0f;

    public Vector3 direction;
    private void OnCollisionEnter(Collision collision)
    {
        //ashdajskdjaskdasdksa
    }

    private void Start()
    {
        Invoke("DestroyThis", 3f);
    }

    private void Update()
    {
        MoveProjectile();
    }
    void MoveProjectile()
    {
        transform.Translate(direction * projectileData.bulletType.projectileSpeed * Time.deltaTime);
    }
    void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
