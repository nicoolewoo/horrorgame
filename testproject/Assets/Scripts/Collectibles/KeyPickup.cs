using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add key to player's inventory
            other.GetComponent<PlayerInventory>().AddKey();

            // Destroy key game object from scene
            Destroy(gameObject);
        }
    }
}
