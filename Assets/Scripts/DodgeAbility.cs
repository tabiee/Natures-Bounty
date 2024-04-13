using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//receiver
public class DodgeAbility : MonoBehaviour
{
    public float rollForce = 2f;
    public float rollDuration = 1f;
    public float rollCooldown = 3f;

    private bool isDodging;
    private bool isOnCooldown;
    private void FixedUpdate()
    {
        if (isDodging)
        {
            Vector2 direction = transform.right;
            PlayerController2D.instance.rb.AddForce(direction * rollForce, ForceMode2D.Force);
        }
    }
    public void DodgeRoll()
    {
        if (!isDodging && !isOnCooldown)
        {
            StartDodging();
        }
    }
    void StartDodging()
    {
        isDodging = true;
        StartCoroutine(DodgingTimer());
        StartCoroutine(StartCooldown());
    }
    IEnumerator DodgingTimer()
    {
        yield return new WaitForSeconds(rollDuration);
        isDodging = false;
    }

    IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(rollCooldown);
        isOnCooldown = false;
    }
}
