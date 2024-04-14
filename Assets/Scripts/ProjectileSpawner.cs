using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//receiver
public class ProjectileSpawner : MonoBehaviour
{
    private ObjectPool projectilePool;
    private ProjectileData projectileData;
    private Projectile projectile;
    private Quaternion targetRotation;
    private float startingDistance = 0.1f;
    private bool isShooting;
    private void Awake()
    {
        projectilePool = GetComponent<ObjectPool>();
    }
    public void StartShooting(ProjectileData projData, Quaternion targetRot)
    {
        if (!isShooting)
        {
            StartCoroutine(SpawnProjectiles(projData, targetRot));
        }
    }
    private IEnumerator SpawnProjectiles(ProjectileData projData, Quaternion targetRot)
    {
        isShooting = true;

        projectileData = projData;
        targetRotation = targetRot;
        projectilePool.prefab = projData.projectilePrefab;
        projectile = projData.projectile;
        projectile.projectilePool = projectilePool;

        float startAngle, currentAngle, angleStep, endAngle;
        float timeBetweenProjectiles = 0f;
        GameObject bullet;

        GetProjectileAngle(out startAngle, out currentAngle, out angleStep, out endAngle);

        if (projectileData.stagger)
        {
            timeBetweenProjectiles = projectileData.timeBetweenBursts / projectileData.projectilesPerBurst;
        }

        for (int i = 0; i < projectileData.burstCount; i++)
        {
            if (projectileData.oscillate)
            {
                currentAngle = endAngle;
                endAngle = startAngle;
                startAngle = currentAngle;
                angleStep *= -1;
            }

            for (int j = 0; j < projectileData.projectilesPerBurst; j++)
            {
                Vector2 pos = FindProjectileSpawnLoc(currentAngle);
                bullet = projectilePool.GetObject();
                bullet.transform.position = pos;
                //bullet.transform.rotation = targetRotation;

                if (bullet.TryGetComponent(out Projectile proj))
                {
                    proj.projectileSpeed = projectileData.projectileSpeed;
                    proj.direction = bullet.transform.position - transform.position;
                    StartCoroutine(proj.LaunchAndDisableAfterDelay(projectileData.projectileLifetime, targetRotation));
                }

                currentAngle += angleStep;

                if (projectileData.stagger)
                {
                    yield return new WaitForSeconds(timeBetweenProjectiles);
                }
            }

            currentAngle = startAngle;

            if (!projectileData.stagger)
            {
                yield return new WaitForSeconds(projectileData.timeBetweenBursts);
            }
        }
        yield return new WaitForSeconds(projectileData.rateOfFire);
        isShooting = false;
    }

    private void GetProjectileAngle(out float startAngle, out float currentAngle, out float angleStep, out float endAngle)
    {
        float targetAngle = Mathf.Atan2(projectile.direction.y, projectile.direction.x) * Mathf.Rad2Deg;
        startAngle = targetAngle;
        endAngle = targetAngle;
        currentAngle = targetAngle;
        float halfAngleSpread = 0f;
        angleStep = 0f;
        if (projectileData.angleSpread != 0)
        {
            angleStep = projectileData.angleSpread / (projectileData.projectilesPerBurst - 1);
            halfAngleSpread = projectileData.angleSpread / 2f;
            startAngle = targetAngle - halfAngleSpread;
            endAngle = targetAngle + halfAngleSpread;
            currentAngle = startAngle;
        }
    }
    private Vector2 FindProjectileSpawnLoc(float currentAngle)
    {
        float x = transform.position.x + startingDistance * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = transform.position.y + startingDistance * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        Vector2 pos = new Vector2(x, y);

        return pos;
    }
}