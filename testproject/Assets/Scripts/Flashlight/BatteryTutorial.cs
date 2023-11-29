using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTutorial : MonoBehaviour
{

    public Canvas PopupCanvas;
    public bool hasRun = false; //only need the tutorial to show up once 
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && hasRun == false) {
            ShowPopUp();
            hasRun = true;
        }
    }
    void Start()
    {
        PopupCanvas.gameObject.SetActive(false);
    }

 
    void ShowPopUp() {
        if (PopupCanvas != null)
        {
            PopupCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
        } 
    }

}

