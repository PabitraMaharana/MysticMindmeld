using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyattack : MonoBehaviour
{
    public int enemyHP = 200; 
    private int health;
    public Animator animator;
    private static int damageCounter = 0;
    private int hitsBeforeDamageAnimation = 5; // Adjust as needed

    public enemycountholder counter;

    public Image healthbar;
    
    void Start(){
        health = enemyHP;
    }

    void Update(){

    }

    public void Attack()
    {
        // Add attack logic here if needed
    }
    public void destroy(){
        counter.Increment(1);
        Object.Destroy(this.gameObject);
    }

    public void takeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        healthbar.fillAmount = enemyHP / 100f;
        damageCounter++;



        if (enemyHP <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Remove the Rigidbody component
                Destroy(rb);
            }
           
        }
        else
        {
            // Check if it's time to trigger the damage animation
            // if (damageCounter >= hitsBeforeDamageAnimation)
            // {
                animator.SetTrigger("damage");
                damageCounter = 0; // Reset the counter after triggering the animation
            // }
        }
    }
}
