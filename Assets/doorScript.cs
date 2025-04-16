using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class doorScript : MonoBehaviour
{
    public bool opening;
    public bool closing;
    public float timer;
    public Vector3 moveAmmount;
    public UnityEvent onOpen;
    public UnityEvent onClose;
    public Transform targetToMoveTo;
    public float closingSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void open()
    {
        opening = true;
    }
    public void close()
    {
        closing = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                transform.position = transform.position + moveAmmount * Time.deltaTime;
            }
            else
            {
                onOpen.Invoke();
                opening = false;
            }
        }
        if (closing)
        {
            var v=(targetToMoveTo.position- transform.position ).normalized;
            transform.position+=(v*closingSpeed*Time.deltaTime);
            if((transform.position - targetToMoveTo.position).magnitude < 1)
            {
                closing=false;
            }
        }
        
    }
}
