using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//client
public class Enemy : MonoBehaviour
{
    [SerializeField] private ProjectileData[] projectileData;
    [SerializeField] private ProjectileSpawner projectileSpawner;
    [SerializeField] private Transform shooterPosition;
    [SerializeField] private bool cycleProjectiles;

    private ActionWheel _actionWheel; 
    [HideInInspector] public Transform targetPosition;
    public bool canAttack;

    private void Start()
    {
        targetPosition = Player.instance.gameObject.transform;
        shooterPosition = this.transform;
    }
    private void Update()
    {
        Shoot(GetTargetPosition());
    }
    void Shoot(Quaternion targetRotation)
    {
        if (canAttack)
        {
            IAction shootAction = new ShootAction(projectileData, targetRotation, shooterPosition, false, cycleProjectiles, projectileSpawner);
            _actionWheel = new ActionWheel(shootAction);
            _actionWheel.UseAction();
            //Debug.Log("Pew!");
        }
    }
    private Quaternion GetTargetPosition()
    {
        Quaternion targetRotation;

        Vector3 dir = (targetPosition.position - shooterPosition.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        return targetRotation;
    }
}
