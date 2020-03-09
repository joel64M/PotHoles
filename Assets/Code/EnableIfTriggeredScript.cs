using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableIfTriggeredScript : MonoBehaviour
{
    MeshRenderer mr;
    public GameObject one;

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
            GameManagerScript.instance.IncrementScore();
            Instantiate(one,  this.transform.position, Quaternion.identity);
        }
    }
    private void OnBecameInvisible()
    {
        mr.enabled = false;
    }
}
