using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellOpen : MonoBehaviour
{
    
	public float distance;
	public Transform player; 
	public Transform target;
	public GameObject ActionDisplay;
    public GameObject TheDoor;
	public GameObject parentDoor;
	void Update()
	{

		distance = Vector3.Distance(player.position, target.position);
		if (distance < 3.5)
		{
			ActionDisplay.SetActive(true);

			if (Input.GetButtonDown("Action"))
			{
				Debug.Log("test");
				BoxCollider boxCollider = parentDoor.GetComponent<BoxCollider>();
				boxCollider.enabled = false;
				ActionDisplay.SetActive(false);

				TheDoor.GetComponent<Animation>().Play("FirstDoorOpenAnim");

			}
		}
		else
        {
			ActionDisplay.SetActive(false);
        }
		
	}


}
