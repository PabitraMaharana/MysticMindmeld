using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gemcount : MonoBehaviour
{
    public static int gems = 0;
    public TMP_Text gemcountertext; // Reference to the TextMeshPro text component

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the reference to the TextMeshPro text component is assigned
        if(gemcountertext == null)
            gemcountertext = GetComponent<TMP_Text>();
        
        // Update the text with the initial kill count
        UpdateKillCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment(int val)
    {
        gems += val;
        UpdateKillCountText(); 
    }
    public string Decrement(int val)
    {
        if(gems>0){
            gems -= val;
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
        if(gemcountertext != null)
        {
            // Set the text value as the kill counter
            gemcountertext.text = gems.ToString();
        }
    }
}
