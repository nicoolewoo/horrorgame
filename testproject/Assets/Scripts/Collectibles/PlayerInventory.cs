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
    public static int batteryCount = 0;
    public TextMeshProUGUI BatteryNumber;


    void Update() {
        internalKey = keyCount;
        keyDisplay.text = "" + keyCount;
        BatteryNumber.text = "" + batteryCount;
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
        Debug.Log("total batteries" + batteryCount);
    }
    public void RemoveBattery() {
        batteryCount--;
        Debug.Log("total batteries" + batteryCount);
    }
}
