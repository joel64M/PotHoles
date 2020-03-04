using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        SpawnerScript.instance.SpawnNextFence();
    }
}
