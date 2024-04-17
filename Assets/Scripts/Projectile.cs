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
    [HideInInspector] public Vector3 direction;
    //[HideInInspector] public EffectOnHit effectOnHit;
    [SerializeField] private Rigidbody2D rb;
    private Coroutine launchCoroutine;
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
        }
    }
    public void Launch(float delay, Quaternion rotation)
    {
        if (launchCoroutine != null)
        {
            StopCoroutine(launchCoroutine);
        }
        launchCoroutine = StartCoroutine(LaunchAndDisableAfterDelay(delay, rotation));
    }
    public IEnumerator LaunchAndDisableAfterDelay(float delay, Quaternion rotation)
    {
        rb.velocity = Vector2.zero;
        transform.rotation = rotation;

        yield return null;

        rb.AddRelativeForce(direction.normalized * projectileSpeed, ForceMode2D.Impulse);

        yield return new WaitForSeconds(delay);

        ReturnToPool();
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
        ObjectPool.instance.ReturnObject(gameObject);
    }
}