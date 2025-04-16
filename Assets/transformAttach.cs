using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformAttach : MonoBehaviour
{
    public AI aI;
    private FirstPersonController FirstPersonController;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.position = aI.transform.position; 
        transform.rotation=aI.transform.rotation;
        if (FirstPersonController != null)
        {
            transform.LookAt(FirstPersonController.transform.position);
            RaycastHit hit;

        
            if (Physics.Raycast(transform.position + offset,transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.GetComponent<FirstPersonController>() != null)
                {
                    Debug.Log("player detected");
                    aI.triggerKillMode();
                    Destroy(this.gameObject);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<FirstPersonController>() != null)
        {
           FirstPersonController=other.GetComponent<FirstPersonController>();
        }

    }
    private Vector3 offset = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonController>()) 
        {
            FirstPersonController = null;
        } 
    }
}

