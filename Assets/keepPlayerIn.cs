using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CurvedPathGenerator;

public class keepPlayerIn : MonoBehaviour
{
    FirstPersonController FirstPersonController=>FindObjectOfType<FirstPersonController>();
   PathFollower pathFollower=>GetComponentInParent<PathFollower>();
    bool notactive;
    public void disable()
    {
        notactive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() == FirstPersonController&&pathFollower.IsMove==true&&!notactive)
        {
            FirstPersonController.transform.position=transform.position;
        }
    }
}
