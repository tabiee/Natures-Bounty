using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //movement itself aka move forward in direction it is facing
    //time it takes to disappear
    //effects on hit

    public float knockbackForce;
    public bool doCollisions = true;
    public GameObject particles;
    [HideInInspector] public float projectileSpeed;
    /*[HideInInspector] */public Vector3 direction;
    //[HideInInspector] public EffectOnHit effectOnHit;
    [SerializeField] private Rigidbody2D rb;
    private Coroutine launchCoroutine;
    private ProjectileData projectileData;
    private bool isShotByPlayer = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (doCollisions)
        {
            if (collision.gameObject.CompareTag("Environment"))
            {
                ReturnToPool();
            }

            if (!isShotByPlayer)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    PlayerHealth.instance.DamagePlayer(projectileData.damageDealt);

                    ReturnToPool();
                }
            }
            else
            {
                if (collision.gameObject.CompareTag("Enemy"))
                {
                    UnitHealth enemyHP = collision.gameObject.GetComponent<UnitHealth>();
                    enemyHP.DamageEnemy(projectileData.damageDealt);

                    ReturnToPool();
                }
            }
        }
    }
    public void Launch(float lifetime, Quaternion targetRotation, bool isPlayerBullet, ProjectileData projData)
    {
        if (launchCoroutine != null)
        {
            StopCoroutine(launchCoroutine);
        }

        SetLayer(isPlayerBullet);

        projectileData = projData;
        isShotByPlayer = isPlayerBullet;
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
    void SetLayer(bool isPlayerBullet)
    {
        int newLayerIndex;

        if (isPlayerBullet)
        {
            newLayerIndex = LayerMask.NameToLayer("PlayerProjectile");
            gameObject.layer = newLayerIndex;
        }
        else
        {
            newLayerIndex = LayerMask.NameToLayer("EnemyProjectile");
            gameObject.layer = newLayerIndex;
        }
    }
    private void ReturnToPool()
    {
        Instantiate(particles, transform.position, transform.rotation);

        gameObject.SetActive(false);
        ObjectPool.instance.ReturnObject(gameObject);
    }
}