using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHP : MonoBehaviour
{
    [SerializeField] private int testPlayerDMG;
    [SerializeField] private int testPlayerHealing;
    [SerializeField] private int testEnemyDMG;
    [SerializeField] private int testEnemyHealing;

    [SerializeField] private Transform enemies;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerHealth.instance.DamagePlayer(testPlayerDMG);
            Debug.Log($"Player Damaged for: {testPlayerDMG}, now Current HP is: {PlayerHealth.instance.playerHealth.Health} and Max HP is: {PlayerHealth.instance.playerHealth.MaxHealth}");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHealth.instance.HealPlayer(testPlayerHealing);
            Debug.Log($"Player Healed for: {testPlayerHealing}, now Current HP is: {PlayerHealth.instance.playerHealth.Health} and Max HP is: {PlayerHealth.instance.playerHealth.MaxHealth}");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            foreach (Transform child in enemies)
            {
                UnitHealth enemyHP = child.GetComponent<UnitHealth>();
                enemyHP. DamageEnemy(testEnemyDMG);
                Debug.Log($"Enemy {this.name} Damaged for: {testEnemyDMG}, now Current HP is: {enemyHP.unitHealth.Health}");
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            foreach (Transform child in enemies)
            {
                UnitHealth unitHealth = child.GetComponent<UnitHealth>();
                unitHealth.HealEnemy(testEnemyHealing);
                Debug.Log($"Enemy {this.name} Healed for: {testEnemyHealing}, now Current HP is: {unitHealth.unitHealth.Health}");
            }
        }
    }
}
