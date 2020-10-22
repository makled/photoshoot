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
        public string MouseAxisName = "Mouse X";
        public bool isInteracting;

        // public static mkld.Photoshoot.RotationUIController Instance;

        // void Awake()
        // {
        //     if (Instance == null)
        //     {
        //         Instance = this;
        //     }
        //     else
        //     {
        //         Destroy(this.gameObject);
        //     }
        // }
        private void OnEnable()
        {
            Indicator.transform.LookAt(CameraMouseController.Instance.transform);
            switch (MouseAxisName)
            {
                case "Mouse X":
                    Indicator.transform.localEulerAngles = new Vector3(0f, Indicator.transform.localEulerAngles.y, 0f);
                    break;
                case "Mouse Y":
                    Indicator.transform.localEulerAngles = new Vector3(Indicator.transform.localEulerAngles.x, 0f, 90f);
                    break;
                default:
                    break;
            }

        }
        private void Update()
        {
            if (MouseAxisName == "Mouse Y")
                transform.eulerAngles = new Vector3(0f, MouseSelection.Instance.GetSelectedObject().transform.eulerAngles.y, 0f);
            //transform.LookAt(CameraMouseController.Instance.transform);

            if (Input.GetKey(KeyCode.Mouse0) && isInteracting)
            {
                switch (MouseAxisName)
                {
                    case "Mouse X":
                        Rotate(new Vector3(0f, -Input.GetAxis(MouseAxisName) * RotationSensitivity, 0f));
                        break;
                    case "Mouse Y":
                        Rotate(new Vector3(Input.GetAxis(MouseAxisName) * RotationSensitivity, 0f, 0f));
                        break;
                    default:
                        break;
                }
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) && isInteracting)
            {
                Indicator.transform.LookAt(CameraMouseController.Instance.transform);
                switch (MouseAxisName)
                {
                    case "Mouse X":
                        Indicator.transform.localEulerAngles = new Vector3(0f, Indicator.transform.localEulerAngles.y, 0f);
                        break;
                    case "Mouse Y":
                        Indicator.transform.localEulerAngles = new Vector3(Indicator.transform.localEulerAngles.x, 0f, 90f);
                        break;
                    default:
                        break;
                }
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

        public void Rotate(Vector3 rotation)
        {
            if (!isInteracting)
                return;

            Indicator.transform.Rotate(rotation, Space.Self);
            switch (MouseAxisName)
            {
                case "Mouse X":
                    TransformationManager.Instance.RotateSelectedObject(rotation, Space.World);
                    break;
                case "Mouse Y":
                    TransformationManager.Instance.RotateSelectedObject(rotation, Space.Self);
                    break;
                default:
                    break;
            }
        }

    }
}

