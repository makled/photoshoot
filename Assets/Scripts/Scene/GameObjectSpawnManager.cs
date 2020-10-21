using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    public class GameObjectSpawnManager : MonoBehaviour
    {
        private List<GameObject> SpawnedObjects;
        public static GameObjectSpawnManager Instance;
        // Start is called before the first frame update
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        void Start()
        {
            SpawnedObjects = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddObject(GameObject obj)
        {
            GameObject spawnedObj = Instantiate(obj);
            SpawnedObjects.Add(spawnedObj);
        }

    }
}

