using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    public class ObjectListController : MonoBehaviour
    {
        [Tooltip("Prefab for UI Object Element")]
        public GameObject UIElementPrefab;

        [Tooltip("Reference to the list of the spawnable object")]
        public SpawnableObjectList SpawnableObjectListReference;
        // Start is called before the first frame update
        void Start()
        {
            PopulateListOfObjects();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PopulateListOfObjects()
        {
            foreach(var obj in SpawnableObjectListReference.ListOfSpawnableObjects)
            {
                GameObject elemObj = Instantiate(UIElementPrefab, this.transform);
                elemObj.GetComponent<ObjectListElementController>().SetSpawnableObjectReference(obj);
            }
        }
    }
}

