using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //movement itself aka move forward in direction it is facing
    //time it takes to disappear
    //effects on hit

    public bool doCollisions = true;
    public GameObject particles;
    [HideInInspector] public float projectileSpeed;
    /*[HideInInspector] */public Vector3 direction;
    //[HideInInspector] public EffectOnHit effectOnHit;
    [SerializeField] private Rigidbody2D rb;
    private Coroutine launchCoroutine;
    private ProjectileData projectileData;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (doCollisions)
        {
            //apply damage and effects here
            if (!collision.gameObject.CompareTag("Projectile"))
            {
                Debug.Log("boom collision!");

                Instantiate(particles, transform.position, transform.rotation);
                ReturnToPool();
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                //deal dmg
                PlayerHealth.instance.DamagePlayer(projectileData.damageDealt);
            }
        }
    }
    public void Launch(float lifetime, Quaternion targetRotation, ProjectileData projData)
    {
        if (launchCoroutine != null)
        {
            StopCoroutine(launchCoroutine);
        }
        projectileData = projData;
        launchCoroutine = StartCoroutine(LaunchAndDisableAfterDelay(lifetime, targetRotation));
    }
    public IEnumerator LaunchAndDisableAfterDelay(float lifetime, Quaternion targetRotation)
    {
        rb.velocity = Vector2.zero;
        transform.rotation = targetRotation;

        yield return null;

        rb.AddRelativeForce(direction.normalized * projectileSpeed, ForceMode2D.Impulse);

        yield return new WaitForSeconds(lifetime);

        ReturnToPool();
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
        ObjectPool.instance.ReturnObject(gameObject);
    }
}