using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellOpen : MonoBehaviour
{

    public float distance;
    public Transform player;
    public Transform target;
    public GameObject openActionDisplay;
    public GameObject closeActionDisplay;
    public GameObject gotoOtherDoor;
    public GameObject TheDoor;
    public GameObject parentDoor;
    private Animator doorAnimator;
    public AudioSource CreakSound;
    private bool isDoorClosed = true;
    private bool playerCloseEnough = false;
    private float timeDelay = 1.9f;
    private static float lastActionTime = 0f;

    void Start()
    {
        doorAnimator = TheDoor.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Action") & Time.time - lastActionTime > timeDelay & playerCloseEnough & isDoorClosed & FindObjectOfType<DoorUnlock>().instructionsRead)
        {
            Debug.Log("button pressed open");
            BoxCollider boxCollider = parentDoor.GetComponent<BoxCollider>();
            boxCollider.enabled = false;
            openActionDisplay.SetActive(false);

            doorAnimator.SetTrigger("Open");
            CreakSound.Play();
            isDoorClosed = false;
            lastActionTime = Time.time;

        }
        else if (Input.GetButtonDown("Action") & Time.time - lastActionTime > timeDelay & playerCloseEnough & !isDoorClosed & FindObjectOfType<DoorUnlock>().instructionsRead)
        {
            Debug.Log("button pressed close");
            BoxCollider boxCollider = parentDoor.GetComponent<BoxCollider>();
            boxCollider.enabled = true;
            closeActionDisplay.SetActive(false);

            doorAnimator.SetTrigger("Close");
            CreakSound.Play();
            isDoorClosed = true;
            lastActionTime = Time.time;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCloseEnough = true;
            if (!FindObjectOfType<DoorUnlock>().instructionsRead)
            {
                gotoOtherDoor.SetActive(true);
            }
            else
            {
                gotoOtherDoor.SetActive(false);
                if (isDoorClosed)
                {
                    openActionDisplay.SetActive(true);
                }
                else
                {
                    closeActionDisplay.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openActionDisplay.SetActive(false);
            closeActionDisplay.SetActive(false);
            gotoOtherDoor.SetActive(false);
        }
    }
}
   