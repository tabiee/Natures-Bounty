using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private int maxUnitHealth;
    [SerializeField] private float invincibilityFrames = 0.5f;
    [SerializeField] private Image healthBar;
    [SerializeField] private ObjectGenerator itemDrops;

    [SerializeField] private AudioSource unitAudioSource;
    [SerializeField] private AudioClip unitHurtAudio;

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
        unitAudioSource.Play();

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
        if (itemDrops != null)
        {
            itemDrops.SpawnPrefab();
        }

        ReturnToPool();
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
        ObjectPool.instance.ReturnObject(gameObject);
    }
}
