using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tramlock : MonoBehaviour
{
    public bool barriersActive;
    public List<GameObject> barriers;
    // Update is called once per frame
    void Update()
    {
        if (barriersActive)
        {
            foreach (GameObject go in barriers)
            {
                go.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject go in barriers)
            {
                go.SetActive(false);
            }
        }
       
    }
}
