using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//receiver
public class Dash : MonoBehaviour
{
    [SerializeField] private GameObject dashParticle;
    public float dashForce = 2f;
    public float dashDuration = 1f;
    public float dashCooldown = 3f;

    private bool isDashing;
    private bool isOnCooldown;
    private void FixedUpdate()
    {
        if (isDashing)
        {
            Vector2 direction = transform.right;
            PlayerController2D.instance.rb.AddForce(direction * dashForce, ForceMode2D.Force);
        }
    }
    public void UseDash()
    {
        if (!isDashing && !isOnCooldown)
        {
            StartDashing();
        }
    }
    void StartDashing()
    {
        isDashing = true;
        dashParticle.SetActive(true);

        StartCoroutine(DashTimer());
        StartCoroutine(StartCooldown());
    }
    IEnumerator DashTimer()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        dashParticle.SetActive(false);
    }

    IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(dashCooldown);
        isOnCooldown = false;
    }
}
