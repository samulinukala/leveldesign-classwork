using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tramui : MonoBehaviour
{
    public bool moving=false;
   
    public Button chooseL;
    public Button chooseR;
    public Button chooseC;
    public TMP_Text textL;
    public TMP_Text textC;
    public TMP_Text textR;
    public Event thing;
    public string readyToStart;
    private void Start()
    {
        chooseL.gameObject.SetActive(false); 
        chooseR.gameObject.SetActive(false);
        chooseC.gameObject.SetActive(true);
   
        textL.text = string.Empty;
        textC.text = readyToStart;
        textR.text = string.Empty;
    }
   
    public void ClearText()
    {
        chooseL.gameObject.SetActive(false);
        chooseR.gameObject.SetActive(false);
        chooseC.gameObject.SetActive(false);
        textL.text=string.Empty;
        textC.text=string.Empty;
        textR.text=string.Empty;
    }
    public void setChoise(string mText,string lText,string rText)
    {
        moving = true;
        textC.text = mText;
        chooseC.gameObject.SetActive(true);
        textL.text = lText;
        chooseL.gameObject.SetActive(true);
        textR.text = rText;
        chooseR.gameObject.SetActive(true);
    }
    public void setChoise(string mText)
    {
        moving = true;
        textC.text=mText;
        chooseC.gameObject.SetActive(true);
    }
    public void setChoise( string lText, string rText)
    {
        moving = true;
        textC.text = lText;
        chooseC.gameObject.SetActive(true);
        textL.text = rText;
            chooseL.gameObject.SetActive(true);
    }
}
