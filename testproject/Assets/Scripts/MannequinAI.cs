using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MannequinAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    Vector3 dest;

    public Camera playerCam;

    public float speed = 2;


    //The distance in which the AI can catch the player from
    public float sightRange = 10;
    public bool playerInSightRange;
    public float minDist = 3;

    void Start()
    {
        player = GameObject.Find("The Adventurer Blake");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    //The Update() void, stuff occurs every frame in this void
    void Update()
    {

        //Get the AI's distance from the player
        float distance = Vector3.Distance(transform.position, player.transform.position);


        if (isInPlayerView() || distance > sightRange || distance <= minDist)
        {
            agent.speed = 0;
            agent.SetDestination(transform.position);
        }

        else
        {
            NavMeshPath navMeshPath = new NavMeshPath();
            //create path and check if it can be done
            // and check if navMeshAgent can reach its target
            if (agent.CalculatePath(player.transform.position, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                //move to target
                agent.speed = speed;
                agent.SetPath(navMeshPath);
            }
            
        }

    }

    private bool isInPlayerView()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playerCam);

        return GeometryUtility.TestPlanesAABB(planes, this.gameObject.GetComponent<Renderer>().bounds);

    }


    private void OnDrawGizmosSelected() {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);


    }
}