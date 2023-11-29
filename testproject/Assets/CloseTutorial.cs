using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTutorial : MonoBehaviour
{
    public Canvas PopupCanvas;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (PopupCanvas != null)
            {
                PopupCanvas.gameObject.SetActive(false);
                Time.timeScale = 1f;
            } 
        }
    }
}
