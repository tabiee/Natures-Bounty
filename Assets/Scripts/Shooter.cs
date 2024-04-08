using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    //get ProjData and keep a var for WeaponPattern here
    //then pass in BulletType to the Projectile of my default bullet

    [SerializeField] private GameObject defaultBulletPrefab;
    [SerializeField] private Projectile projectile;
    private float cooldownWaitTime = 0.0f;

    //

    [SerializeField] private int projectilesPerBurst;
    [SerializeField][Range(0,359)] private float angleSpread;
    [SerializeField] private float startingDistance = 0.1f;
    [SerializeField] private int burstCount;
    [SerializeField] private float timeBetweenBursts;
    [SerializeField] private float restTime = 1f;
    [SerializeField] private bool stagger;
    [SerializeField] private bool oscillate;

    private void Start()
    {
        projectile = defaultBulletPrefab.GetComponent<Projectile>();
    }
    protected void Shoot(ProjectileData projData)
    {
        projectile.projectileData = projData;
        //GameObject bullet = Instantiate(defaultBulletPrefab, transform.position, Quaternion.identity);
        //bullet.transform.rotation = transform.rotation;


        if (CooldownOver())
        {
            StartCoroutine(ShootRoutine(projData));
        }
    }
    private IEnumerator ShootRoutine(ProjectileData projData)
    {
        cooldownWaitTime = Time.time + projData.weaponPattern.rateOfFire;

        float startAngle, currentAngle, angleStep, endAngle;
        float timeBetweenProjectiles = 0f;

        GetBulletAngle(out startAngle, out currentAngle, out angleStep, out endAngle);

        if (stagger) { 
            timeBetweenProjectiles = timeBetweenBursts / projectilesPerBurst; 
        }

        for (int i = 0; i < burstCount; i++)
        {
            if (oscillate)
            {
                currentAngle = endAngle;
                endAngle = startAngle;
                startAngle = currentAngle;
                angleStep *= -1;
            }
            for (int j = 0; j < projectilesPerBurst; j++)
            {

                Vector2 pos = FindBulletSpawnPos(currentAngle);

                GameObject bullet = Instantiate(defaultBulletPrefab, pos, Quaternion.identity);
                bullet.transform.rotation = transform.rotation;

                //Projectile proj = bullet.GetComponent<Projectile>();

                if (bullet.TryGetComponent(out Projectile proj)) {
                    proj.direction = bullet.transform.position - transform.position;
                }

                currentAngle += angleStep;

                if (stagger) { 
                    yield return new WaitForSeconds(timeBetweenProjectiles); 
                }
            }

            currentAngle = startAngle;

            if (!stagger) {
                yield return new WaitForSeconds(timeBetweenBursts);
            }
        }
        yield return new WaitForSeconds(restTime);
    }

    private void GetBulletAngle(out float startAngle, out float currentAngle, out float angleStep, out float endAngle)
    {
        float targetAngle = Mathf.Atan2(projectile.direction.y, projectile.direction.x) * Mathf.Rad2Deg;
        startAngle = targetAngle;
        endAngle = targetAngle;
        currentAngle = targetAngle;
        float halfAngleSpread = 0f;
        angleStep = 0f;
        if (angleSpread != 0)
        {
            angleStep = angleSpread / (projectilesPerBurst - 1);
            halfAngleSpread = angleSpread / 2f;
            startAngle = targetAngle - halfAngleSpread;
            endAngle = targetAngle + halfAngleSpread;
            currentAngle = startAngle;
        }
    }

    private Vector2 FindBulletSpawnPos(float currentAngle)
    {
        float x = transform.position.x + startingDistance * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = transform.position.y + startingDistance * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        Vector2 pos = new Vector2(x, y);

        return pos;
    }
    private bool CooldownOver()
    {
        return Time.time > cooldownWaitTime;
    }
}
