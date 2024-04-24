using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemycountholder : MonoBehaviour
{
    public static int killCount = 0;
    public TMP_Text killCountText; // Reference to the TextMeshPro text component

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the reference to the TextMeshPro text component is assigned
        if(killCountText == null)
            killCountText = GetComponent<TMP_Text>();
        
        // Update the text with the initial kill count
        UpdateKillCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment(int val)
    {
        killCount += val;
        UpdateKillCountText(); 
    }
    public string Decrement(int val)
    {
        if(killCount>0){
            killCount -= val;
            UpdateKillCountText();
            return "Respawn ";
        } 
        else{
            return "Cannot Respawn";
        }
        
    }

    void UpdateKillCountText()
    {
        // Ensure the TextMeshPro text component exists
        if(killCountText != null)
        {
            // Set the text value as the kill counter
            killCountText.text = killCount.ToString();
        }
    }
}
