using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Portal_ControlScript : MonoBehaviour
{
    public Transform endPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Platform")
        {
            other.transform.position = endPoint.position;
        }
    }
}
