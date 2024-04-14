using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//concrete command
public class ShootAction : IAction
{
    private ProjectileData _projectileData;
    private Quaternion _targetRotation;
    private ProjectileSpawner _projectileSpawner;

    public ShootAction(ProjectileData projectileData, Quaternion targetRotation, ProjectileSpawner projectileSpawner)
    {
        _projectileData = projectileData;
        _targetRotation = targetRotation;
        _projectileSpawner = projectileSpawner;
    }

    public void Execute()
    {
        _projectileSpawner.StartShooting(_projectileData, _targetRotation);
        //Debug.Log("pew! I shot a bullet");
    }
}
