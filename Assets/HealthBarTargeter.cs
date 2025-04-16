using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTargeter : MonoBehaviour
{
    private Healthbar_AI Healthbar_AI=>FindObjectOfType<Healthbar_AI>();
    public List<AI> aIs;
    private Vector3 offset=new Vector3(0,1,0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position+offset, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.GetComponent<AI>()!=null)
            {
                if (aIs.Contains(hit.collider.gameObject.GetComponent<AI>()))
                {
                    Healthbar_AI.setAl(hit.collider.gameObject.GetComponent<AI>());
                }
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AI>())
        {
            aIs.Add(other.GetComponent<AI>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<AI>())
        {
            if (aIs.Contains(other.GetComponent<AI>()))
            {
                Healthbar_AI.resetAl();
            }
            aIs.Remove(other.GetComponent<AI>());
        }
    }
}
