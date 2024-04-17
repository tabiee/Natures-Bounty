using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//client
public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] private ProjectileData projectileData;
    [SerializeField] private ProjectileSpawner projectileSpawner;
    [SerializeField] private DodgeRoll dodgeRoll;
    [SerializeField] private Transform shooterPosition;

    private ActionWheel _actionWheel;
    private bool isShootHeld;
    private bool isDodgeHeld;
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
        Dodge();
    }
    void OnShoot(InputValue inputValue)
    {
        isShootHeld = inputValue.isPressed;
    }
    void Shoot()
    {
        if (isShootHeld)
        {
            IAction shootAction = new ShootAction(projectileData, transform.rotation, shooterPosition, projectileSpawner);
            _actionWheel = new ActionWheel(shootAction);
            _actionWheel.UseAction();
            //Debug.Log("Pew!");
        }
    }
    void OnDodge(InputValue inputValue)
    {
        isDodgeHeld = inputValue.isPressed;
    }
    void Dodge()
    {
        if (isDodgeHeld)
        {
            IAction action = new DodgeAction(dodgeRoll);
            _actionWheel = new ActionWheel(action);
            _actionWheel.UseAction();
            //Debug.Log("Dodge!");
        }
    }
}