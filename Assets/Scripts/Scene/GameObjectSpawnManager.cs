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
            if(Input.GetKeyUp(KeyCode.Delete))
            {
                RemoveObject();
            }
        }

        public void AddObject(SpawnableObject obj)
        {
            GameObject spawnedObj = Instantiate(obj.ObjectPrefabAssetReference);
            SpawnedObjects.Add(spawnedObj);
            spawnedObj.tag = "SelectableObject";
            spawnedObj.GetComponent<SelectableObject>().SetObject(obj);
        }

        public void RemoveObject()
        {
            if(MouseSelection.Instance.GetSelectedObject())
            {
                GameObject removeObject = MouseSelection.Instance.GetSelectedObject();
                SpawnedObjects.Remove(removeObject);
                Destroy(removeObject);
            }
        }

    }
}

