using CurvedPathGenerator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackInfo : MonoBehaviour
{
   
    private void Update()
    {
        if(GetComponent<PathGenerator>().IsClosed != false) GetComponent<PathGenerator>().IsClosed = false;

    }
    public List<PathGenerator> nextPaths;
    public List<string> nextDescription;
}
