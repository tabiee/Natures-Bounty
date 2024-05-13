using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//client
public class Player : MonoBehaviour
{
    public static Player instance;
    public ProjectileData projectileData;
    [SerializeField] private ProjectileSpawner projectileSpawner;
    [SerializeField] private Dash dash;
    [SerializeField] private Transform shooterPosition;

    private ActionWheel _actionWheel;
    private bool isShootHeld;
    private bool isDashHeld;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);

            Debug.LogWarning("There was more than one Player in the scene");
        }
        instance = this;
    }
    private void Start()
    {
        shooterPosition = this.transform;
    }
    private void Update()
    {
        Shoot();
        Dash();
    }
    void OnShoot(InputValue inputValue)
    {
        isShootHeld = inputValue.isPressed;
    }
    void Shoot()
    {
        if (isShootHeld)
        {
            IAction shootAction = new ShootAction(projectileData, transform.rotation, shooterPosition, true, projectileSpawner);
            _actionWheel = new ActionWheel(shootAction);
            _actionWheel.UseAction();
            //Debug.Log("Pew!");
        }
    }
    void OnDash(InputValue inputValue)
    {
        isDashHeld = inputValue.isPressed;
    }
    void Dash()
    {
        if (isDashHeld)
        {
            IAction action = new DashAction(dash);
            _actionWheel = new ActionWheel(action);
            _actionWheel.UseAction();
            //Debug.Log("Dashed!");
        }
    }
}