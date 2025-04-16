using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class triggerScript : MonoBehaviour
{
    public UnityEvent Event;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FirstPersonController>())
        {
            Event.Invoke();
        }
    }
}
