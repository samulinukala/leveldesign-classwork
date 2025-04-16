using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class areaActivity : MonoBehaviour
{
    public float areaTimer;
    public TMP_Text textMeshPro;
    public bool called0;
    // Update is called once per frame
    public shoot shoot;
    void Update()
    {
        if(areaTimer < 0)
        {
            FindObjectOfType<gameManager>().lose = true;
            
        }
        textMeshPro.text = "Time left: " +areaTimer;
        areaTimer -= Time.deltaTime;
        if (shoot.shot)
        {
            if (called0 == false)
            {
                Debug.Log("a gun!");
                var v = this.GetComponentsInChildren<AI>();
                foreach (var v2 in v)
                {
                    v2.triggerPath(0);
                }
                called0 = true;
            }
        }
    }
    public void KillFrenzy()
    {
        var v = this.GetComponentsInChildren<AI>();
        foreach (var v2 in v)
        {
            v2.triggerKillMode();
        }
    }
    public void triggerPathInAll(int _path)
    {

        var v = this.GetComponentsInChildren<AI>();
        foreach (var v2 in v) {if( v2.paths.Count>0) v2.triggerPath(_path); }
    }
    private void OnDisable()
    {
        FindObjectOfType<gameManager>().score += (int)areaTimer;
        textMeshPro.text = "";
    }
   
}
