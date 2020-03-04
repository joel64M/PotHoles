using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SpawnerScript : MonoBehaviour
{
    public static SpawnerScript instance;
    #region Variables
    [Header("Fence Properties")]
    public GameObject fencePrefab;
    public int fencesAmount = 20;
    [Header("Environment Props Properties")]
    public GameObject[] propPrefabs;
    public int propsAmount;

    List<GameObject> props = new List<GameObject>();
    List<GameObject> fences = new List<GameObject>();
    Vector3 currentFencePos = Vector3.zero;
    Vector3 currentPropPos =new Vector3(6f,0f,-5f);

    int fenceIndex = 0;
    int propIndex = 0;
    bool isLastRightSide = false;

    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        for (int i = 0; i < fencesAmount; i++)
        {
            GameObject go = Instantiate(fencePrefab, this.transform);
            go.transform.position = Vector3.zero;
            fences.Add(go);
        }
        for (int i = 0; i < propsAmount; i++)
        {
            GameObject go = Instantiate(propPrefabs[Random.Range(0, propPrefabs.Length)], this.transform);
            go.transform.position = Vector3.zero;
            props.Add(go);
        }
        for (int i = 0; i < fences.Count; i++)
        {
            SpawnNextFence();
        }
        for (int i = 0; i < props.Count; i++)
        {
            SpawnNextProp();
        }
    }


    #region Custom Methods
  public  void SpawnNextFence()
    {
        fences[fenceIndex].transform.position = currentFencePos;
        currentFencePos.z += 2.6643f;
        fenceIndex++;
        if (fenceIndex >= fences.Count)
        {
            fenceIndex = 0;
        }
    }
    public void SpawnNextProp()
    {
        int y = Random.Range(0, 11);
        float x;
        if (y >= 5)
        {
            isLastRightSide = true;
             x = Random.Range(5.5f, 9f);
        }
        else
        {
            isLastRightSide = false;
             x = Random.Range( -9f , -5.5f);

        }
        float z = Random.Range(0.9f, 2f);
        float scale = Random.Range(0.8f, 1.25f);
        float rotation =Random.Range(0f, 360f);

        currentPropPos.x = x;
        currentPropPos.z += z;
        props[propIndex].transform.localScale = Vector3.one * scale;
        props[propIndex].transform.eulerAngles  =Vector3.up*rotation;

        props[propIndex].transform.position = currentPropPos;

        propIndex++;
        if (propIndex >= props.Count)
        {
            propIndex = 0;
        }
    }
    #endregion
}
