using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
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
