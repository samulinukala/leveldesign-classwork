using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmoDrawing : MonoBehaviour
{
    public Color color;
    [Range(0,10)]
    public float size;
    private void OnDrawGizmos()
    {
       


        Gizmos.color = color;





        Gizmos.DrawCube(transform.position, Vector3.one * size);
        Gizmos.DrawSphere(transform.position, size);


    }
}
