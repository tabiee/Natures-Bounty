using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    [SerializeField] private int maxPlayerHealth;
    [SerializeField] private float invincibilityFrames = 0.5f;

    public Image healthBar;
    public HealthSystem playerHealth;
    public bool canBeDamaged = true;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);

            Debug.LogWarning("There was more than one PlayerHealth in the scene");
        }
        instance = this;

        playerHealth = new HealthSystem(maxPlayerHealth, maxPlayerHealth);
    }
    private void Update()
    {
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        healthBar.fillAmount = playerHealth.GetHealthPercentage();
    }
    public void DamagePlayer(int amount)
    {
        playerHealth.DealDamage(amount, invincibilityFrames);
        canBeDamaged = false;
        StartCoroutine(DamagedInvincibility());
        if (playerHealth.IsDead())
        {
            PlayerDied();
        }
    }
    public void HealPlayer(int amount)
    {
        playerHealth.HealDamage(amount);
    }

    void PlayerDied()
    {
        //Debug.Log("u are DED. knot big soup rice,,");
    }
    IEnumerator DamagedInvincibility()
    {
        //wait between damage
        yield return new WaitForSeconds(invincibilityFrames);
        canBeDamaged = true;
    }
}
