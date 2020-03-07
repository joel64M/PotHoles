using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace potholes
{
    public enum tags { props,fence,ground,road };

    public class SpawnerScript : MonoBehaviour
    {
        public static SpawnerScript instance;
        #region Variables
        [Header("Fence Properties")]
        public GameObject fencePrefab;
        public int fencesAmount = 20;
        [Header("Environment Props Properties")]
        public GameObject[] propPrefabs;
        public int propsAmount;
        [Header("Road Properties")]
        public GameObject roadPrefab;
        public int roadAmount = 10;
        [Header("Ground Properties")]
        public GameObject groundPrefab;
        public int groundAmount = 10;

        List<GameObject> props = new List<GameObject>();
        List<GameObject> fences = new List<GameObject>();
        List<GameObject> roads = new List<GameObject>();
        List<GameObject> grounds = new List<GameObject>();

        Vector3 currentFencePos = Vector3.zero;
        Vector3 currentPropPos = new Vector3(6f, 0f, -5f);
        Vector3 currentRoadPos = Vector3.zero;
        Vector3 currentGroundPos = Vector3.zero;

        int fenceIndex = 0;
        int propIndex = 0;
        int roadIndex = 0;
        int groundIndex = 0;
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
            for (int i = 0; i < roadAmount; i++)
            {
                GameObject go = Instantiate(roadPrefab, this.transform);
                go.transform.position = Vector3.zero;
                roads.Add(go);
            }
            for (int i = 0; i < groundAmount; i++)
            {
                GameObject go = Instantiate(groundPrefab, this.transform);
                go.transform.position = Vector3.zero;
                grounds.Add(go);
            }
            for (int i = 0; i < fences.Count; i++)
            {
                SpawnNextFence();
            }
            for (int i = 0; i < props.Count; i++)
            {
                SpawnNextProp();
            }
            for (int i = 0; i < roads.Count; i++)
            {
                SpawnNextRoad();
            }
            for (int i = 0; i < grounds.Count; i++)
            {
                SpawnNextGround();
            }
        }


        #region Custom Methods
        public void SpawnNext(tags tag)
        {
            switch (tag)
            {
                case tags.fence:
                    SpawnNextFence();
                    break;
                case tags.ground:
                    SpawnNextGround();
                    break;
                case tags.props:
                    SpawnNextProp();
                    break;
                case tags.road:
                    SpawnNextRoad();
                    break;
                default:
                    break;
            }
        }
         void SpawnNextFence()
        {
            fences[fenceIndex].transform.position = currentFencePos;
            currentFencePos.z += 2.6643f;
            fenceIndex++;
            if (fenceIndex >= fences.Count)
            {
                fenceIndex = 0;
            }
        }
         void SpawnNextProp()
        {
            int y = Random.Range(0, 11);
            float x;
            if (y >= 5)
            {
                x = Random.Range(5.5f, 9f);
            }
            else
            {
                x = Random.Range(-9f, -5.5f);

            }
            float z = Random.Range(1.2f, 2f);
            float scale = Random.Range(0.8f, 1.25f);
            float rotation = Random.Range(0f, 360f);

            currentPropPos.x = x;
            currentPropPos.z += z;
            props[propIndex].transform.localScale = Vector3.one * scale;
            props[propIndex].transform.eulerAngles = Vector3.up * rotation;

            props[propIndex].transform.position = currentPropPos;

            propIndex++;
            if (propIndex >= props.Count)
            {
                propIndex = 0;
            }
        }
        void SpawnNextRoad()
        {
            roads[roadIndex].transform.position = currentRoadPos;
            currentRoadPos.z += 8.96f;
            currentRoadPos.x = Random.Range(-3f, 3f);
            roadIndex++;
            if (roadIndex >= roads.Count)
            {
                roadIndex = 0;
            }
        }

        void SpawnNextGround()
        {
            grounds[groundIndex].transform.position = currentGroundPos;
            currentGroundPos.z += 117.59f;
            groundIndex++;
            if (groundIndex >= grounds.Count)
            {
                groundIndex = 0;
            }
        }
        #endregion
    }
}