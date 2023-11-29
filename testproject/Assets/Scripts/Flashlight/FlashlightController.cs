using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightController : MonoBehaviour
{
    public float maxBatteryLevel = 120f;
    public float currentBatteryLevel = 120f;
    public float batteryConsumptionRate = 0.20f;

    public Image FlashlightBatteryLevel;
    private Light flashlight;

    void Start()
    {
        flashlight = GetComponent<Light>();
    }

    void FixedUpdate()
    {
        if (currentBatteryLevel > 0f)
        {
            // Decrease battery level over time
            DecreaseBatteryLevel(Time.fixedDeltaTime * batteryConsumptionRate);

            // Update light intensity based on battery level
            UpdateLightIntensity();

            // Update HUD image
            FlashlightBatteryLevel.fillAmount = currentBatteryLevel / maxBatteryLevel;
        }
    }

    void DecreaseBatteryLevel(float amount)
    {
        currentBatteryLevel -= amount;

        // Ensure battery level does not go below zero
        if (currentBatteryLevel <= 0f)
        {
            currentBatteryLevel = 0f;
        }
    }
    public void RechargeBattery()
    {
        // Recharge the battery to full
        currentBatteryLevel = maxBatteryLevel;

        // Update light intensity based on battery level
        UpdateLightIntensity();
    }

    void UpdateLightIntensity()
    {
        // Update light intensity based on battery level
        float normalizedBatteryLevel = currentBatteryLevel / maxBatteryLevel;
        flashlight.intensity = normalizedBatteryLevel;
    }
}
