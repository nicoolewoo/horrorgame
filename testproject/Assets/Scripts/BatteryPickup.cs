using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInventory>().AddBattery();
            Destroy(gameObject);
            Recharge light = other.GetComponent<Recharge>();

            if (light != null) {
                light.Charge();
            } else {
                Debug.Log("no light found");
                
            }
            
            
            // Light pointLight = pointLightTransform.GetComponent<Light>();
            // pointLight.intensity = 2.0f; 
        }
    }
}
