using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlesolvecheck : MonoBehaviour
{
    public GameObject gameObjects; // List of game objects to check

    public Canvas canvasToShow; // Canvas to activate if animator parameter is true

    public gemcount gem;

    public GameObject cam;
    public GameObject altar;
    public GameObject rubble;


    private void Start()
    {
        
    }
    private void Update(){

         Animator animator = gameObjects.GetComponent<Animator>();
            if (animator != null)
            {
                // Check if the 'move' parameter is set to true
                if (animator.GetBool("move"))
                {
                    StartCoroutine(CheckAnimatorParameters());
                    
                    animator.SetBool("move",false);
                }}
    }

    IEnumerator CheckAnimatorParameters()
    {

           
            // Activate canvasToShow for 3 seconds
            canvasToShow.gameObject.SetActive(true);
            cam.SetActive(false);
            altar.SetActive(false);
            rubble.SetActive(false);
            yield return new WaitForSeconds(3f);
            // Deactivate canvasToShow after 3 seconds
            gem.Increment(1);
            canvasToShow.gameObject.SetActive(false);
            Destroy(canvasToShow);
    }
}
