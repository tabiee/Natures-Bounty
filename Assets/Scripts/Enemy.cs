using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//client
public class Enemy : MonoBehaviour
{
    [SerializeField] private ProjectileData projectileData;
    [SerializeField] private ProjectileSpawner projectileSpawner;

    private ActionWheel _actionWheel; 
    private Transform targetPosition;
    private void Start()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Shoot(GetTargetPosition());
    }
    void Shoot(Quaternion targetRotation)
    {
        IAction shootAction = new Shoot(projectileData, targetRotation, projectileSpawner);
        _actionWheel = new ActionWheel(shootAction);
        _actionWheel.UseAction();
        Debug.Log("Pew!");
    }
    private Quaternion GetTargetPosition()
    {
        Quaternion targetRotation;

        Vector3 dir = (targetPosition.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //Debug.Log("tarRot: " + targetRotation);
        return targetRotation;
    }
}
