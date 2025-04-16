using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facingPanelScript : MonoBehaviour
{
    public bool facingApanel;
    
    FirstPersonController firstPersonController=>FindObjectOfType<FirstPersonController>();
    shoot shoot=>firstPersonController.GetComponentInChildren<shoot>();
    public string tagToLookFor = "UI";
    // Update is called once per frame
    public float health;
    public float maxHealth=400;
    public float damage=10;
    public float regen=0.75f;
    private void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        if (health < 0)
        {
            firstPersonController.enabled = false;
            FindObjectOfType<gameManager>().lose = true;
           var v= FindObjectsOfType<areaActivity>();
            for(int i = v.Length-1; i >= 0; i--)
            {
                v[i].gameObject.SetActive(false);
            }
        }
        else if(health < maxHealth)
        {
            health += regen * Time.deltaTime;
        }
        if (facingApanel)
        {
           
            firstPersonController.lockCursor = false;
            firstPersonController.cameraCanMove = false;
            shoot.enabled=false;
            
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            firstPersonController.lockCursor = true;
            firstPersonController.cameraCanMove = true;
            shoot.enabled = true;
         
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag==tagToLookFor)
        {
            facingApanel = true;
        }
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {
            health -= damage;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == tagToLookFor)
        {
            facingApanel = false;
        }
    }
}
