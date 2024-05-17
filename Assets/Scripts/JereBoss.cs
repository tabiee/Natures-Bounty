using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JereBoss : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody2D rb;
    private Enemy enemyScript;
    private void Awake()
    {
        enemyScript = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        enemyScript.canAttack = true;
        Vector2 direction = (enemyScript.targetPosition.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
}
