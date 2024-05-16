using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    public static PlayerController2D instance;

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private AudioClip movementAudio;

    [HideInInspector] public Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);

            Debug.LogWarning("There was more than one PlayerController2D in the scene");
        }
        instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();

        AudioManager.instance.movementSource.clip = movementAudio;
        AudioManager.instance.movementSource.Play();
    }

    private void FixedUpdate()
    {
        SetVelocity();
    }
    private void SetVelocity()
    {
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, movementInput, ref movementInputSmoothVelocity, 0.1f);

        rb.velocity = smoothedMovementInput * movementSpeed;
        rb.angularVelocity = 0;

        if (rb.velocity == Vector2.zero)
        {
            AudioManager.instance.movementSource.Stop();
        }
    }
}