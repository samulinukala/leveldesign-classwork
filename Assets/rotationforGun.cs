using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationforGun : MonoBehaviour
{
    public Transform player=>FindObjectOfType<FirstPersonController>().gameObject.transform;

    // Update is called once per frame
    public void targetPlayer()
    {
        transform.LookAt(player.position);
    }
}
