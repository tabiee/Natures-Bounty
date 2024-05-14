using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private Enemy enemyScript;
    public float lookRadius = 10f;  // Detection range
    public float attackRadius = 5f; // Attack range
    public float patrolTime = 5f;   // Time between patrols
    public float speed = 2f;        // Enemy speed
    private Rigidbody2D rb;

    bool isAttacking = false;
    [SerializeField] private bool canMoveWhenShoot;
    private void Awake()
    {
        enemyScript = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        enemyScript.canAttack = false;
    }

    void Update()
    {
        float distance = Vector2.Distance(enemyScript.targetPosition.position, transform.position);
        
        if (distance <= lookRadius && isAttacking == false)
        {
            ChasePlayer();
            
            if (distance <= attackRadius)
            {
                AttackPlayer();

            }
        }

        else
        {
            isAttacking = false;
            enemyScript.canAttack = false;
            rb.velocity = Vector2.zero;
        }

    }

    

    private void AttackPlayer()
    {
       
        isAttacking = true;
        enemyScript.canAttack = true;

        if (canMoveWhenShoot)
        {

        }

        else
            rb.velocity = Vector2.zero;



    }

    private void ChasePlayer()
    {

        isAttacking = false;
        enemyScript.canAttack = false;
        Vector2 direction = (enemyScript.targetPosition.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    public static Vector3 RandomNavSphere(Vector2 origin, float dist, int layermask)
    {
        Vector2 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
