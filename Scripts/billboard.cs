using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{
    Vector3 cameradir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameradir = Camera.main.transform.forward;
        cameradir.y = 0;
        transform.rotation=Quaternion.LookRotation(cameradir);
        
    }
}
