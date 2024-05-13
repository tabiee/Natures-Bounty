using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//receiver
public class ProjectileSpawner : MonoBehaviour
{
    private ProjectileData projectileData;
    private Quaternion targetRotation;
    private Transform shooterPosition;
    private float startingDistance = 0.1f;
    private bool isShooting;
    private bool isShooterPlayer;
    public void StartShooting(ProjectileData projData, Quaternion targetRot, Transform shooterPos, bool isShooterPlayer)
    {
        if (!isShooting)
        {
            projectileData = projData;
            targetRotation = targetRot;
            shooterPosition = shooterPos;
            this.isShooterPlayer = isShooterPlayer;

            StartCoroutine(SpawnProjectiles());
        }
    }
    private IEnumerator SpawnProjectiles()
    {
        isShooting = true;

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
                bullet = ObjectPool.instance.GetObject(projectileData.projectilePrefab);
                bullet.transform.position = pos;

                if (bullet.TryGetComponent(out Projectile proj))
                {
                    proj.projectileSpeed = projectileData.projectileSpeed;
                    proj.direction = bullet.transform.position - shooterPosition.position;
                    proj.Launch(projectileData.projectileLifetime, targetRotation, isShooterPlayer, projectileData);
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
        float targetAngle = Mathf.Atan2(projectileData.projectile.direction.y, projectileData.projectile.direction.x) * Mathf.Rad2Deg;
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
        float x = shooterPosition.position.x + startingDistance * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = shooterPosition.position.y + startingDistance * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        Vector2 pos = new Vector2(x, y);

        return pos;
    }
}