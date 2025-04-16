using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    private Slider Slider=>GetComponent<Slider>();
    private facingPanelScript facingPanelScript =>FindObjectOfType<facingPanelScript>();


    // Update is called once per frame
    void Update()
    {
        Slider.value =  facingPanelScript.health/facingPanelScript.maxHealth ;
    }
}
