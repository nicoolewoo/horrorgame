using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{

    private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;

    public LayerMask whatIsGround, whatIsPlayer, whatIsObstruction;


    //Patrolling
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkpointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    [Range(0,360)]
    public float fov = 100;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("AI_Minion");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("vely",agent.velocity.magnitude / agent.speed);
        // playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        // playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        playerInSightRange = isInView(sightRange);
        playerInAttackRange = isInView(attackRange);

        if (!playerInSightRange && !playerInAttackRange) Patrol();
        if (playerInSightRange && !playerInAttackRange) Chase();
        if (playerInAttackRange && playerInSightRange) Attack();
        
    }

    //check if player is within range and line of sight
    private bool isInView(float range)
    {
        if(Physics.CheckSphere(transform.position, range, whatIsPlayer))
        {
            Transform target = player.transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < fov/2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, whatIsObstruction))
                {
                    return true;
                }
                return false;
            }
            else{return false;}
        }

        return false;
    }

    private void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkpoint);
        
        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randz = Random.Range(-walkpointRange, walkpointRange);
        float randx = Random.Range(-walkpointRange, walkpointRange);

        walkpoint = new Vector3(transform.position.x + randx, transform.position.y, transform.position.z + randz);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }

    private void Chase()
    {
        agent.SetDestination(player.transform.position);
    }

    private void Attack()
    {

        agent.SetDestination(transform.position);
        transform.LookAt(player.transform);

    }


    private void OnDrawGizmosSelected() {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
