using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;
    public static int keyCount = 0;
    public TextMeshProUGUI keyDisplay;
    public int internalKey;
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
}
