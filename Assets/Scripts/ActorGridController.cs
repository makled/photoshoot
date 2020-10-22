using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    public class ActorGridController : MonoBehaviour
    {
        public GameObject ElementPrefab;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PopulatePoses(ActorPoses poses)
        {
            foreach(var elem in GetComponentsInChildren<PoseElementBehaviour>())
            {
                Destroy(elem.gameObject);
            }
            foreach(var pose in poses.Poses)
            {
                GameObject postElement = Instantiate(ElementPrefab, transform);
                postElement.GetComponent<PoseElementBehaviour>().SetUpElement(pose);
            }
        }
    }

}
