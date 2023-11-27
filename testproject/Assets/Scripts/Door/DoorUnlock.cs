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
    public GameObject ActionDisplay2;
    public GameObject TheDoor;
	public GameObject parentDoor;
    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, target.position);
        if (distance < 2.5)
        {
            if (PlayerInventory.keyCount < 5) {
                ActionDisplay.SetActive(true);
            }
            else {
                ActionDisplay2.SetActive(true);
                if (Input.GetButtonDown("Action"))
                {
                    BoxCollider boxCollider = parentDoor.GetComponent<BoxCollider>();
                    boxCollider.enabled = false;
                    ActionDisplay.SetActive(false);

                    TheDoor.GetComponent<Animation>().Play("FirstDoorOpenAnim");

                }
            }
        }
        else
        {
            ActionDisplay.SetActive(false);
            ActionDisplay2.SetActive(false);
        }
    }
}
