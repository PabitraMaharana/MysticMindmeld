using UnityEngine;
using System.Collections.Generic;

public class chesscontrol : MonoBehaviour
{
    public List<GameObject> objectsToCheck; // List of GameObjects to check for Animator parameter "move"
    public GameObject objectToSetMoveParameter; // GameObject to set Animator parameter "move" to true

    void Update()
    {
        foreach (GameObject obj in objectsToCheck)
        {
            CheckAndSetAnimatorParameter(obj);
        }
    }

    void CheckAndSetAnimatorParameter(GameObject obj)
    {
        Animator animator = obj.GetComponent<Animator>();

        if (animator != null && animator.GetBool("move"))
        {
            SetMoveParameter(objectToSetMoveParameter);
        }
    }

    void SetMoveParameter(GameObject obj)
    {
        Animator animator = obj.GetComponent<Animator>();

        if (animator != null)
        {
            animator.SetBool("move", true);
        }
    }
}
