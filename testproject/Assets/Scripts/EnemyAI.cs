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

    private Vector3 eyePosition, targetPositionRaised;

    //Patrolling
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkpointRange;

    //Waypoints for patrolling
    public GameObject[] waypoints;
    public int currWaypoint = -1;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    [Range(0,360)]
    public float fov = 100;


    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("The Adventurer Blake");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        eyePosition = new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z);
        targetPositionRaised = new Vector3(player.transform.position.x, player.transform.position.y+1.5f, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("vely",agent.velocity.magnitude / agent.speed);
        // playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        // playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        eyePosition = new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z);
        targetPositionRaised = new Vector3(player.transform.position.x, player.transform.position.y+1.5f, player.transform.position.z);

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
            Vector3 directionToTarget = (targetPositionRaised - eyePosition).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < fov/2)
            {
                float distanceToTarget = Vector3.Distance(eyePosition, targetPositionRaised);

                if(!Physics.Raycast(eyePosition, directionToTarget, distanceToTarget, whatIsObstruction))
                {
                    walkpoint = target.position;
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

        if (distanceToWalkPoint.magnitude < 2f)
            walkPointSet = false;

    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        // float randz = Random.Range(-walkpointRange, walkpointRange);
        // float randx = Random.Range(-walkpointRange, walkpointRange);

        // walkpoint = new Vector3(transform.position.x + randx, transform.position.y, transform.position.z + randz);

        setNextWalkpoint();

        walkpoint = waypoints[currWaypoint].transform.position;

        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }

    private void setNextWalkpoint()
    {
        if(waypoints.Length == 0)
        {
            return;
        }
        if(currWaypoint<0  || currWaypoint>= waypoints.Length-1)
        {
            currWaypoint = 0;
        }
        else
        {
            currWaypoint++;
        } 
    }

    private void Chase()
    {
        agent.SetDestination(player.transform.position);
    }

    private void Attack()
    {

        agent.SetDestination(transform.position);
        agent.isStopped = true;
        transform.LookAt(player.transform);
        anim.SetTrigger("attack");

    }


    private void OnDrawGizmosSelected() {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        float halfFOV = fov / 2.0f;
        Quaternion leftRayRotation = Quaternion.AngleAxis( -halfFOV, Vector3.up );
        Quaternion rightRayRotation = Quaternion.AngleAxis( halfFOV, Vector3.up );
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay( eyePosition, leftRayDirection * sightRange );
        Gizmos.DrawRay( eyePosition, rightRayDirection * sightRange );

        Gizmos.color = Color.red;
        Gizmos.DrawCube(eyePosition,new Vector3(.1f,.1f,.1f));

        
        if(Physics.CheckSphere(transform.position, sightRange, whatIsPlayer))
        {
            Transform target = player.transform;
            Vector3 directionToTarget = (targetPositionRaised - eyePosition).normalized;

            Gizmos.DrawRay( eyePosition, (targetPositionRaised - eyePosition));

            float distanceToTarget = Vector3.Distance(eyePosition, targetPositionRaised);

            RaycastHit hit;
            if (Physics.Raycast(eyePosition, directionToTarget, out hit, distanceToTarget, whatIsObstruction))
            {
                Gizmos.DrawSphere(hit.point, 0.1f);
            }
        }

        if (walkPointSet)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, walkpoint);
        }


    }

}
