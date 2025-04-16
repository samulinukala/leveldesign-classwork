using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsScript : MonoBehaviour
{
    float timeout = 15f;
   
    // Update is called once per frame
    void Update()
    {
        timeout -= Time.deltaTime;
        if(timeout < 0)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);   
    }

}
