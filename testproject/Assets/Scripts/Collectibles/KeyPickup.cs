using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
 
            // Play a sound on pickup
            audioSource.Play();

            // Add key to player's inventory
            other.GetComponent<PlayerInventory>().AddKey();

            // Destroy key game object from scene
            Destroy(gameObject);
        }
    }
}
