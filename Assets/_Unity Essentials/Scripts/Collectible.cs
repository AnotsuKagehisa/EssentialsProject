using UnityEngine;
using System;

public class Collectible : MonoBehaviour
{
    public int rotationSpeed = 2;

    public GameObject onCollectEffect;
    public AudioSource onCollectSoundEffect;
    public GameObject onAllCollibleCollectedEffect;

    private static int totalCollectibles = 0; // Shared among all instances

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (totalCollectibles == 0) // Initialize only once
        {
            Type collectibleType = Type.GetType("Collectible");
            if (collectibleType != null)
            {
                totalCollectibles = UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
            }
            Debug.Log($"Total Collectibles Initialized: {totalCollectibles}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Decrement the shared totalCollectibles
            totalCollectibles--;
            Debug.Log($"Collectible Collected. Remaining: {totalCollectibles}");

            // Check if it's the last collectible
            if (totalCollectibles == 0)
            {
                if (onAllCollibleCollectedEffect != null)
                {
                    Instantiate(onAllCollibleCollectedEffect,transform.position, transform.rotation);
                    Debug.Log("All collectibles collected!");
                }
            }

            // Instantiate the Collect effect
            if (onCollectEffect != null)
            {
                Instantiate(onCollectEffect, transform.position, transform.rotation);
            }

            if (onCollectSoundEffect != null)
            {
                onCollectSoundEffect.Play();
            }

            // Destroy this collectible
            Destroy(gameObject);
        }
    }
}
