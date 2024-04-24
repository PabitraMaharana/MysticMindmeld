using System.Collections;
using System.Collections.Generic;
using ASD;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson.PunDemos;

public class playerhealth : MonoBehaviour
{
    public int playerHP = 200; 
    private int HP;
    public Animator animator;
    private static int damageCounter = 0;
    private int hitsBeforeDamageAnimation = 5; // Adjust as needed

    public Image healthbar;
    
    void Start(){
        HP = playerHP;
    }

    void Update(){

    }

    public void Attack()
    {
        // Add attack logic here if needed
    }

    public void takeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
        healthbar.fillAmount = playerHP / 100f;
        damageCounter++;



        if (playerHP <= 0)
        {
            animator.SetBool("Dead", true);
            GetComponent<ThirdPersonController>().enabled = false;
            GetComponent<FootControllerIK>().enabled = false;
        }
        else
        {
            // Check if it's time to trigger the damage animation
            if (damageCounter >= hitsBeforeDamageAnimation)
            {
                animator.SetTrigger("damage");
                damageCounter = 0; // Reset the counter after triggering the animation
            }
        }
    }
}
