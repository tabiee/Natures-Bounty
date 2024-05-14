using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//concrete command
public class ShootAction : IAction
{
    private ProjectileData[] _projectileData;
    private Quaternion _targetRotation;
    private Transform _shooterPosition;
    private bool _isShooterPlayer;
    private bool _isRandom;
    private ProjectileSpawner _projectileSpawner;

    public ShootAction(ProjectileData[] projectileData, Quaternion targetRotation, Transform shooterPosition, bool isShooterPlayer, bool isRandom, ProjectileSpawner projectileSpawner)
    {
        _projectileData = projectileData;
        _targetRotation = targetRotation;
        _shooterPosition = shooterPosition;
        _projectileSpawner = projectileSpawner;
        _isShooterPlayer = isShooterPlayer;
        _isRandom = isRandom;
    }

    public void Execute()
    {
        _projectileSpawner.StartShooting(_projectileData, _targetRotation, _shooterPosition, _isShooterPlayer, _isRandom);
        //Debug.Log("pew! I shot a bullet");
    }
}
