using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;
    public int keyCount = 0;
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
