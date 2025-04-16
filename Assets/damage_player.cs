using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_player : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<facingPanelScript>() != null)
        {
            other.GetComponent<facingPanelScript>().health -= other.GetComponent<facingPanelScript>().damage*3 * Time.deltaTime;
        }
    }
}
