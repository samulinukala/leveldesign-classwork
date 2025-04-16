using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyTransform : MonoBehaviour
{
    private Transform player=>FindObjectOfType<FirstPersonController>().transform;
   

    // Update is called once per frame
    void Update()
    {
       transform.position = player.transform.position;
    transform.rotation= player.transform.rotation;
        
    }
}
