using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public AudioSource audioSource;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            // Play a sound on pickup
            audioSource.time = 0.3f;
            audioSource.Play();

            // Add key to player's inventory

            other.GetComponent<PlayerInventory>().AddKey();
            // Destroy key game object from scene
            Destroy(gameObject);
        }
    }
}
