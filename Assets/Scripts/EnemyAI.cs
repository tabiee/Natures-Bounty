using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [Header("EnemyInfo")]
    [SerializeField] private float lookRadius = 10f;  // Detection range
    [SerializeField] private float attackRadius = 5f; // Attack range
    [SerializeField] private float meleeAttackRadius = 0.5f; // Attack range
    [SerializeField] private float speed = 2f;        // Enemy speed
    [SerializeField] private float dodgeCooldown = 2f;
    [SerializeField] private float maxDodgeDistance = 10f;


    private Rigidbody2D rb;
    private Enemy enemyScript;
    public bool isAttacking = false;
    public bool isChasing = false;
    private Vector2 randomMovetargetPosition;
    private Animator anim;


    [Header("EnemyType")]
    [SerializeField] private bool canMoveWhenShoot;
    [SerializeField] private bool isRanged;

    private void Awake()
    {
        enemyScript = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        if (!isRanged)
        {
            attackRadius = 0;
        }
        enemyScript.canAttack = false;

    }

    void Update()
    {
        float distance = Vector2.Distance(enemyScript.targetPosition.position, transform.position);

        if (distance <= lookRadius)
        {

            ChasePlayer();

            if (distance <= attackRadius)
            {
                AttackPlayer();
        
            }

            if(distance <= meleeAttackRadius && !isRanged)
            {
                anim.SetTrigger("Attack");
            }


        }
        

        if (distance > lookRadius && isChasing)
        {
            isChasing = false;
            isAttacking = false;
            enemyScript.canAttack = false;
            rb.velocity = Vector2.zero;
        }

        if(distance > attackRadius)
        {
            anim.ResetTrigger("Attack");

        }

        if(distance > meleeAttackRadius && !isRanged)
        {
            anim.ResetTrigger("Attack");

        }

    }

    

    private void AttackPlayer()
    {
        anim.SetTrigger("Attack");
        isChasing = false;
        isAttacking = true;
        if (isRanged)
        {
            
            enemyScript.canAttack = true;

            if (canMoveWhenShoot)
            {
                if ((Vector2)transform.position != randomMovetargetPosition)
                {
                    MoveObject();
                }
                else
                {
                    StartCoroutine(WaitAndMove());
                }
            }

            if (!canMoveWhenShoot)
            {
                rb.velocity = Vector2.zero;


            }
        }

    }

    void MoveObject()
    {
        float step = 5 * Time.deltaTime; // Calculate distance to move
        transform.position = Vector2.MoveTowards(transform.position, randomMovetargetPosition, step);
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(dodgeCooldown);
       
       Vector2 targetPosition = new Vector2(Random.Range(-maxDodgeDistance, maxDodgeDistance), Random.Range(-maxDodgeDistance, maxDodgeDistance));
    }

    private void ChasePlayer()
    {
        isChasing = true;
        isAttacking = false;
        enemyScript.canAttack = false;
        Vector2 direction = (enemyScript.targetPosition.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
