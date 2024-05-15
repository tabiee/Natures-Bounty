using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerAim : MonoBehaviour
{
    private Vector2 aimDirection;
    private ControllerHandler controllerHandler;

    private void Awake()
    {
        controllerHandler = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ControllerHandler>();
    }



    // Update is called once per frame
    void Update()
    {
        if (controllerHandler.controllerIsConnected)
        {
            // Get the direction of the right stick
            aimDirection = Gamepad.current.rightStick.ReadValue();

            // If the right stick is moved, rotate the player to face the direction of the stick
            if (aimDirection != Vector2.zero)
            {
                float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        
    }
}
