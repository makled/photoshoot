using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    public class ActorBehaviour : MonoBehaviour
    {
        public GameObject UICanvas;
        public ActorPoses ActorPosesAsset;
        public ActorGridController PoseGridGameObject;
        public GameObject Head;
        // Start is called before the first frame update
        void Start()
        {
           PoseGridGameObject.PopulatePoses(ActorPosesAsset);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShowActorUI(bool value)
        {
            UICanvas.SetActive(value);
        }

        public void SetSelfSubject()
        {
            SessionSetup.Instance.AssignSubject(Head);
        }
    }
}

