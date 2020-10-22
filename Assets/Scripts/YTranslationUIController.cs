using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    public class YTranslationUIController : MonoBehaviour
    {
        public float translationSensitivity = 0.25f;
        public string MouseAxisName = "Mouse Y";
        public bool isInteracting;
        public Transform XRotationUIGameObject;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void SetInteraction(bool value)
        {
            isInteracting = value;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = XRotationUIGameObject.position;
            transform.LookAt(CameraMouseController.Instance.transform);
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);

            if (Input.GetKey(KeyCode.Mouse0) && isInteracting)
            {
                Translate(Input.GetAxis(MouseAxisName) * translationSensitivity);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) && isInteracting)
            {
                isInteracting = false;
            }
        }

        public void Translate(float translateY)
        {
            TransformationManager.Instance.TranslateSelectedObject(new Vector3(0f, translateY, 0f));
        }
    }
}

