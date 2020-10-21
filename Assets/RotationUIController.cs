using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    public class RotationUIController : MonoBehaviour
    {
        [Tooltip("Reference to the GameObject Indicator")]
        public GameObject Indicator;

        public float RotationSensitivity = 0.25f;
        public string MouseHorizontalAxisName = "Mouse X";
        public bool isInteracting;

        public static RotationUIController Instance;

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
        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0) && isInteracting)
            {
                Rotate(Input.GetAxis(MouseHorizontalAxisName) * RotationSensitivity);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) && isInteracting)
            {
                isInteracting = false;
            }
        }

        public void SetUIController(Vector3 pos)
        {
            transform.position = new Vector3(pos.x, 0f, pos.z);
        }

        public void SetInteraction(bool value)
        {
            isInteracting = value;
        }

        public void Rotate(float rotateY)
        {
            if (!isInteracting)
                return;

            Indicator.transform.Rotate(new Vector3(0f, rotateY, 0f));
            TransformationManager.Instance.RotateSelectedObject(rotateY);
        }

    }
}

