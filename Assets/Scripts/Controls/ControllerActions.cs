using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerActions : MonoBehaviour
{



    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.leftTrigger.wasPressedThisFrame)
        {
            // Call your method
            //Dash();
        }

        if (Gamepad.current.rightTrigger.wasPressedThisFrame)
        {
            //Shoot();
        }

    }

}
