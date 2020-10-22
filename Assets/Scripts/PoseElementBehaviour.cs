using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace mkld.Photoshoot
{
    public class PoseElementBehaviour : MonoBehaviour
    {
        public TextMeshProUGUI TextObjectReference;
        public Image ImageObjectReference;
        public AnimatorOverrideController Animator;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetUpElement(Pose pose)
        {
            TextObjectReference.text = pose.PoseName;
            ImageObjectReference.sprite = pose.PoseImage;
            Animator = pose.PoseAnimation;
        }

        public void PlayAnimation()
        {
            transform.root.GetComponentInChildren<ActorBehaviour>().GetComponent<Animator>().runtimeAnimatorController = Animator;
            //transform.root.GetComponentInChildren<ActorBehaviour>().GetComponent<Animator>().Play();
        }
    }
}

