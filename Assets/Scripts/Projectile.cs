using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData projectileData;

    public float bulletLife = 1f;
    public float rotation = 0f;

    private Vector2 startPosition;
    private float timer = 0f;
    private void OnCollisionEnter(Collision collision)
    {
        //ashdajskdjaskdasdksa
    }

    private void Start()
    {
        Invoke("DestroyThis", 3f);

        startPosition = transform.position;
    }

    private void Update()
    {
        MoveProjectile();

        //if (timer > bulletLife) Destroy(this.gameObject);
        //timer += Time.deltaTime;
        //transform.position = Movement(timer);
    }

    //private Vector2 Movement(float timer)
    //{
    //    float x = timer * projectileData.weaponPattern.projectileSpeed * transform.right.x;
    //    float y = timer * projectileData.weaponPattern.projectileSpeed * transform.right.y;
    //    return new Vector2(x + startPosition.x, y + startPosition.y);
    //}
    void MoveProjectile()
    {
        Vector3 direction = new Vector3(
            Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad),
            Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad),
            0f
        );

        transform.position += direction.normalized * projectileData.weaponPattern.projectileSpeed * Time.deltaTime;
    }
    void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
