using UnityEngine;

public class EnemyGiveDamage : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the enemyattack script
        enemyattack enemy = collision.gameObject.GetComponent<enemyattack>();
        
        // If enemy is not null, apply damage
        if (enemy != null)
        {
            enemy.takeDamage(20);
        }
    }
}
