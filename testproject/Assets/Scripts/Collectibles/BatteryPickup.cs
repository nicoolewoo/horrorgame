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
            FlashlightController flashlightController = other.GetComponentInChildren<FlashlightController>();

            if (flashlightController != null)
            {
                // Destroy battery object and play pickup sound
                audioSource.Play();

                // Add battery to inventory
                other.GetComponent<PlayerInventory>().AddBattery();
                Destroy(gameObject);
            }
            else {
                Debug.Log("no light found");
                
            }
            
            
            // Light pointLight = pointLightTransform.GetComponent<Light>();
            // pointLight.intensity = 2.0f; 
        }
    }
}
