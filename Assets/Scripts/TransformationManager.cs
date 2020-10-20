using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    public class TransformationManager : MonoBehaviour
    {
        public static TransformationManager Instance;
        public float translationSensitivity = 2;
        public string mouseHorizontalAxisName = "Mouse X";
        public string mouseVerticalAxisName = "Mouse Y";

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
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Move(Input.GetAxis(mouseHorizontalAxisName) * translationSensitivity,
                Input.GetAxis(mouseVerticalAxisName) * translationSensitivity);
            }

        }

        public void Move(float translateX, float translateY)
        {
            if (MouseSelection.Instance.GetSelectedObject() == null)
                return;
            
            MouseSelection.Instance.GetSelectedObject().transform.Translate(translateX, 0f, translateY);
        }
    }
}

