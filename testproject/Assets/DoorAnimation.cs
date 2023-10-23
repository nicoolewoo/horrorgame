using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public bool isLocked = true;
    public Animator door = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerInventory>().hasKey) 
        {
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {
        if (isLocked)
        {
            isLocked = false;
            door.SetTrigger("DoorOpen");
        }
    }

}
