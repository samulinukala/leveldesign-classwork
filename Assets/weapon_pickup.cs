using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_pickup : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject playersGun;
    public shoot shoot;
    private void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FirstPersonController>())
        {
            shoot.ai = false;
            playersGun.SetActive(true);
            Destroy(gameObject);
        }
    }
}
