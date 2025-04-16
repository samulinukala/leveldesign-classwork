using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar_AI : MonoBehaviour
{
    public TMP_Text TMP_Text;
    public Slider Slider;
    private AI Al;


    // Update is called once per frame
    void Update()
    {
        if (Al != null)
        {
            Slider.gameObject.SetActive(true);
            TMP_Text.text = "enemyHealth";
            Slider.value = Al.health / Al.maxHealth;
        }
        else
        {
            TMP_Text.text = " ";
            Slider.gameObject.SetActive(false);

        }
    }
    public void resetAl()
    {
        Al = null;
    }
    public void setAl(AI _alToBeSet)
    {
        Al = _alToBeSet;
    }
}
