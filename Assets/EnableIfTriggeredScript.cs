using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableIfTriggeredScript : MonoBehaviour
{
    MeshRenderer mr;
    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mr.enabled = true;
        }
    }
    private void OnBecameInvisible()
    {
        mr.enabled = false;
    }
}
