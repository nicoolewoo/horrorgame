using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderKey : MonoBehaviour
{

    private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    public GameObject key;

    public LayerMask whatIsGround, whatIsPlayer, whatIsObstruction;

    private Vector3 eyePosition, targetPositionRaised;

    //Patrolling
    public Vector3 walkpoint;
    bool walkPointSet = false;

    //Waypoints for patrolling
    public GameObject[] waypoints;
    private int currWaypoint = 0;
    private int prevWaypoint = 3;

    //States
    public float sightRange;

    [Range(0,360)]
    public float fov = 100;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        eyePosition = new Vector3(transform.position.x, transform.position.y+1f, transform.position.z);
        targetPositionRaised = new Vector3(player.transform.position.x, player.transform.position.y+1f, player.transform.position.z);
        transform.LookAt(waypoints[3].transform);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("vely",agent.velocity.magnitude / agent.speed);

        eyePosition = new Vector3(transform.position.x, transform.position.y+1f, transform.position.z);
        targetPositionRaised = new Vector3(player.transform.position.x, player.transform.position.y+1f, player.transform.position.z);

        if(key==null)
        {
            anim.SetTrigger("death");
            Destroy(gameObject,5);
        }
        
        if(walkPointSet)
        {
            Vector3 distanceToWalkPoint = transform.position - walkpoint;

            if (distanceToWalkPoint.magnitude < 2f)
            {
                

                prevWaypoint = currWaypoint - 1;
                if(prevWaypoint<0){
                    prevWaypoint = waypoints.Length-1;
                }

                transform.LookAt(waypoints[prevWaypoint].transform);

                Debug.Log(prevWaypoint);
                walkPointSet = false;
            }           
        }

        if(isInView(sightRange))
        {
            fleeToNextCorner();
        }

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
                    return true;
                }
                return false;
            }
            else{return false;}
        }

        return false;
    }

    private void fleeToNextCorner()
    {
        anim.SetTrigger("move");
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkpoint);

    }

    private void SearchWalkPoint()
    {
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

    private void OnDrawGizmosSelected() {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.DrawWireSphere(waypoints[prevWaypoint].transform.position, 3);

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


    }
}
