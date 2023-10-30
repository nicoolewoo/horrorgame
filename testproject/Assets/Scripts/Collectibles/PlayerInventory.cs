using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    //keys
    public bool hasKey = false;
    public static int keyCount = 0;
    public TextMeshProUGUI keyDisplay;
    public int internalKey;

    //batteries
    public bool hasBattery = false;
    public static int batteryCount = 0;

    void Update() {
        internalKey = keyCount;
        keyDisplay.text = "" + keyCount;
    }

    public void AddKey()
    {
        keyCount++;
        Debug.Log("Key added! Total keys: " + keyCount);
        if (keyCount == 5)
        {
            hasKey = true;
        }
        
    }
    public void AddBattery()
    {
        batteryCount++;
        Debug.Log("Battery added! Total batteries: " + batteryCount);
        hasBattery = true;
        
    }
}
