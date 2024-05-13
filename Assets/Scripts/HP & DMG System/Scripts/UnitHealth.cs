using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private int maxUnitHealth;
    [SerializeField] private Image healthBar;
    public HealthSystem unitHealth;
    private void Awake()
    {
        unitHealth = new HealthSystem(maxUnitHealth, maxUnitHealth);
    }
    private void Update()
    {
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        healthBar.fillAmount = unitHealth.GetHealthPercentage();
    }
    public void DamageEnemy(int amount)
    {
        unitHealth.ModifyHealth(-amount);
    }
    public void HealEnemy(int amount)
    {
        unitHealth.ModifyHealth(amount);
    }
}
