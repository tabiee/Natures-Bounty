using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private int currentHealth;
    private int currentMaxHealth;
    public int Health
    {
        get 
        { 
            return currentHealth;
        }

        set 
        {
            currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return currentMaxHealth;
        }

        set
        {
            currentMaxHealth = value;
        }
    }

    public float GetHealthPercentage()
    {
        return (float)currentHealth / currentMaxHealth;
    }

    public HealthSystem(int health, int maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        else if (currentHealth > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }
    }
}
