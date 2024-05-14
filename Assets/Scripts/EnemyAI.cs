using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Enemy
{
    [SerializeField] private float lookRadius = 10f;  // Detection range
    [SerializeField] private float attackRadius = 5f; // Attack range
    [SerializeField] private float patrolTime = 5f;   // Time between patrols

    
    NavMeshAgent agent; // Navmesh agent
    bool isPatrolling = false;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
        StartCoroutine(Patrol());
    }

    void Update()
    {
        float distance = Vector3.Distance(targetPosition.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(targetPosition.position);
            if (distance <= attackRadius)
            {

                canAttack = true;
            }
        }
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            if (!isPatrolling)
            {
                Vector3 randomDirection = Random.insideUnitSphere * lookRadius;
                randomDirection += transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, lookRadius, 1);
                Vector3 finalPosition = hit.position;

                agent.SetDestination(finalPosition);
                isPatrolling = true;
            }

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                isPatrolling = false;

            yield return new WaitForSeconds(patrolTime);
        }
    }
}
