using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooting : MonoBehaviour
{
    public shoot shoot;
    public List<GameObject> objectsInViewCone;
   public GameObject player;

    public rotationforGun rotationforGun;
    public float firerate = 0.25f;
    public float firerateTimer = 0;


    private void OnTriggerEnter(Collider other)
    {
        objectsInViewCone.Add(other.gameObject);
        if (other.tag == "Player")
        {
            Debug.Log("player came in");
            player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        objectsInViewCone.Remove(other.gameObject);
        if (other.tag == "Player")
        {
            Debug.Log("playerleft");
            player = null;
        }
    }
    private void Update()
    {
      
        if (player != null)
        {
            rotationforGun.targetPlayer();
            RaycastHit hit;
            if (Physics.Raycast(rotationforGun.transform.position, rotationforGun.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                
              


                if (hit.collider.tag == "Player")
                {
                    if (firerateTimer < 0)
                    {
                        firerateTimer = firerate;
                  
                        shoot.shootAway();
                    }
                    else
                    {
                        firerateTimer-=Time.deltaTime;
                    }
                }
                
            }
        }


    }
}