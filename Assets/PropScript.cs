using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropScript : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        SpawnerScript.instance.SpawnNextProp();
    }
}
