using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shoot : MonoBehaviour
{
    public float velocity;
    public GameObject bullet;
    public GameObject spawnpoint;
    public bool ai;
    public bool shot=false;

    // Update is called once per frame
    public void shootAway()
    {
        shot = true;
        var tmp = Instantiate(bullet, spawnpoint.transform);
        if (ai)
        {var v= GetComponentInParent<areaActivity>();
            if (v != null)
            {
                v.shoot.shot = true;
            }

        }
        tmp.transform.SetParent(null);
        tmp.GetComponent<Rigidbody>().AddRelativeForce(0, 0, velocity);
    }
    void Update()
    {
        shot = false;
        if (Input.GetMouseButtonDown(0)&&!ai)
        {
            shootAway();
            
        }
    }
}
