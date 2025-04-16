using CurvedPathGenerator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tramFunc : MonoBehaviour
{
    public PathFollower attachement;
    public void attachtotransform(Transform _transform)
    {
        transform.parent = _transform;
        transform.localPosition = Vector3.zero;
    }
}
