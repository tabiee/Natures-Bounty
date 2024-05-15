using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private int maxUnitHealth;
    [SerializeField] private float invincibilityFrames = 0.5f;
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
        unitHealth.DealDamage(amount, invincibilityFrames);
        if (unitHealth.IsDead())
        {
            UnitKilled();
        }
    }
    public void HealEnemy(int amount)
    {
        unitHealth.HealDamage(amount);
    }
    void UnitKilled()
    {
        Destroy(this.gameObject);
        //can be changed to use objectpool later when the generators are made.
        //np it easy
    }
}
