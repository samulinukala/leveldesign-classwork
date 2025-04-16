using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyStealth : MonoBehaviour
{
    AI AI => GetComponentInParent<AI>();
    private void Update()
    {
        if (AI.alrb.velocity !=Vector3.zero)
        {
            Destroy(this.gameObject);
        }
    }
    public void assisinate()
    {
        FindObjectOfType<FirstPersonController>().gameObject.GetComponentInChildren<facingPanelScript>().facingApanel = false;
        AI.health = -1;
       
    }
}
