using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    [SerializeField] private int maxPlayerHealth;
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
        playerHealth.ModifyHealth(-amount, canBeDamaged);
        if (playerHealth.IsDead())
        {
            PlayerDied();
        }
    }
    public void HealPlayer(int amount)
    {
        playerHealth.ModifyHealth(amount, canBeDamaged);
    }

    void PlayerDied()
    {
        //Debug.Log("u are DED. knot big soup rice,,");
    }
}
