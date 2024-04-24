using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGiveDamage : MonoBehaviour
{
    private bool isColliding = false; // Flag to track collision

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the player health script
        playerhealth player = collision.gameObject.GetComponent<playerhealth>();

        // If player is not null, apply damage
        if (player != null)
        {
            player.takeDamage(20);
            isColliding = true; // Set the flag to true when collision starts
            StartCoroutine(DamageOverTime(player)); // Start coroutine for damage over time
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Reset the flag when collision ends
        isColliding = false;
    }

    // Coroutine to deal damage over time
    IEnumerator DamageOverTime(playerhealth player)
    {
        while (isColliding) // Continue while the collision is ongoing
        {
            yield return new WaitForSeconds(2f); // Wait for 2 seconds
            player.takeDamage(20); // Apply damage
        }
    }
}
