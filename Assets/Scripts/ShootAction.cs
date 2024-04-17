using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//concrete command
public class ShootAction : IAction
{
    private ProjectileData _projectileData;
    private Quaternion _targetRotation;
    private Transform _shooterPosition;
    private ProjectileSpawner _projectileSpawner;

    public ShootAction(ProjectileData projectileData, Quaternion targetRotation, Transform shooterPosition, ProjectileSpawner projectileSpawner)
    {
        _projectileData = projectileData;
        _targetRotation = targetRotation;
        _shooterPosition = shooterPosition;
        _projectileSpawner = projectileSpawner;
    }

    public void Execute()
    {
        _projectileSpawner.StartShooting(_projectileData, _targetRotation, _shooterPosition);
        //Debug.Log("pew! I shot a bullet");
    }
}
