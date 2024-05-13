using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float smoothTime = 0.3f;

    private Vector2 moveDirection;
    private Vector2 velocity;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the direction of the left stick
        moveDirection = Gamepad.current.leftStick.ReadValue();
    }

    private void FixedUpdate()
    {
        // Smoothly move the player in the direction of the stick
        Vector2 targetVelocity = moveDirection * speed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, smoothTime);
    }
}


