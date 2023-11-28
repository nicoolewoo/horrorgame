using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryButton : MonoBehaviour
{
        public void OnButtonClick() {
        Debug.Log("clicky");
        if (PlayerInventory.batteryCount > 0) {
            // Find references to objects and scripts
            GameObject player = GameObject.Find("The Adventurer Blake");
            FlashlightController flashlightController = player.GetComponentInChildren<FlashlightController>();
            PlayerInventory inventory = player.GetComponent<PlayerInventory>();

            // Recharge battery and remove a battery from inventory
            flashlightController.RechargeBattery();
            inventory.RemoveBattery();
        }
    }
}
