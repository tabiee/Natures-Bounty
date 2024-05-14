using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//client
public class Player : MonoBehaviour
{
    public static Player instance;
    public ProjectileData currentProjectile;
    public ProjectileData[] projectileDataPack;

    [SerializeField] private ProjectileSpawner projectileSpawner;
    [SerializeField] private Dash dash;
    [SerializeField] private Transform shooterPosition;

    private ActionWheel _actionWheel;
    private bool isShootHeld;
    private bool isDashHeld;
    private int currentIndex;

    private PlayerInput input;
    private InputAction swapInput;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);

            Debug.LogWarning("There was more than one Player in the scene");
        }
        instance = this;

        projectileDataPack[0] = currentProjectile;
    }
    private void Start()
    {
        shooterPosition = this.transform;
        input = GetComponent<PlayerInput>();
        swapInput = input.actions["Swap"];
    }
    private void Update()
    {
        Shoot();
        Dash();
        SwapWeapon();
    }
    void OnShoot(InputValue inputValue)
    {
        isShootHeld = inputValue.isPressed;
    }
    void OnDash(InputValue inputValue)
    {
        isDashHeld = inputValue.isPressed;
    }
    void Shoot()
    {
        if (isShootHeld)
        {
            IAction shootAction = new ShootAction(currentProjectile, transform.rotation, shooterPosition, true, false, projectileSpawner);
            _actionWheel = new ActionWheel(shootAction);
            _actionWheel.UseAction();
            //Debug.Log("Pew!");
        }
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
    void SwapWeapon()
    {
        if (swapInput.triggered)
        {
            Debug.Log("swapped");
            currentIndex = (currentIndex + 1) % projectileDataPack.Length;

            //if that slot is empty, go to the next one
            if (projectileDataPack[currentIndex] != null)
            {
                currentProjectile = projectileDataPack[currentIndex];
            }
            else
            {
                SwapWeapon();
            }
        }
    }
}