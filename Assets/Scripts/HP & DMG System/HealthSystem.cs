using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private int currentHealth;
    private int currentMaxHealth;
    //private bool canBeDamaged = true;
    private float invincibilityTimer = 0.0f;
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

    public void DealDamage(int amount, float invincibilityFrames)
    {
        //Debug.Log("1 DealDamage called with: " + invincibilityFrames);

        if (CanBeDamaged())
        {
            invincibilityTimer = Time.time + invincibilityFrames;

            currentHealth -= amount;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            else if (currentHealth > currentMaxHealth)
            {
                currentHealth = currentMaxHealth;
            }

            //Debug.Log("2 DealDamage called");
        }
    }
    public void HealDamage(int amount)
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

    public bool IsDead()
    {
        if (currentHealth == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CanBeDamaged()
    {
        return Time.time > invincibilityTimer;
    }
}
