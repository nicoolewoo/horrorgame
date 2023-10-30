using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUnlock : MonoBehaviour
{
    public float distance;
    public Transform player;
    public Transform target;
    public GameObject ActionDisplay;
    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, target.position);
        if (distance < 2.5)
        {
            Debug.Log("Testing");
            ActionDisplay.SetActive(true);
        }
        else
        {
            ActionDisplay.SetActive(false);
        }
    }
}
