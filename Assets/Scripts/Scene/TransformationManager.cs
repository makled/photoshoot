using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace mkld.Photoshoot
{
    public class TransformationManager : MonoBehaviour
    {
        public static TransformationManager Instance;
        public float translationSensitivity = 2;
        public string mouseHorizontalAxisName = "Mouse X";
        public string mouseVerticalAxisName = "Mouse Y";
        public GameObject Space;

        public GameObject RotationUIControllerObjectX;
        public GameObject RotationUIControllerObjectY;
        public GameObject YTranslationObject;

        private bool isTranslating;


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
            if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Move(Input.GetAxis(mouseHorizontalAxisName) * translationSensitivity,
                Input.GetAxis(mouseVerticalAxisName) * translationSensitivity);
            }

        }

        public void SetTranslation(bool value)
        {
            isTranslating = value;
        }

        public void TranslateSelectedObject(Vector3 translation)
        {
            MouseSelection.Instance.GetSelectedObject().transform.Translate(translation, UnityEngine.Space.World);
        }
        public void Move(float translateX, float translateY)
        {
            if (MouseSelection.Instance.GetSelectedObject() == null 
            || RotationUIControllerObjectX.GetComponent<RotationUIController>().isInteracting
            || RotationUIControllerObjectY.GetComponent<RotationUIController>().isInteracting
            || YTranslationObject.GetComponent<YTranslationUIController>().isInteracting)
                return;

            Space.transform.position = CameraMouseController.Instance.transform.position;
            Space.transform.localEulerAngles = new Vector3(0f, CameraMouseController.Instance.transform.localEulerAngles.y, 0f);
            MouseSelection.Instance.GetSelectedObject().transform.Translate(translateX, 0f, translateY, Space.transform);
            RotationUIControllerObjectX.transform.position = MouseSelection.Instance.GetSelectedObject().transform.position;
            RotationUIControllerObjectY.transform.position = MouseSelection.Instance.GetSelectedObject().transform.position;

        }

        public void RotateSelectedObject(Vector3 rotation, Space space)
        {
            if (MouseSelection.Instance.GetSelectedObject() == null)
                return;

            MouseSelection.Instance.GetSelectedObject().transform.Rotate(rotation, space);
        }

        public void ShowRotationUI(bool value)
        {
            RotationUIControllerObjectX.transform.position = MouseSelection.Instance.GetSelectedObject().transform.position;
            RotationUIControllerObjectX.SetActive(value);
            RotationUIControllerObjectY.transform.position = MouseSelection.Instance.GetSelectedObject().transform.position;
            RotationUIControllerObjectY.SetActive(value);
        }

        public void ShowYTranslationUI(bool value)
        {
            YTranslationObject.SetActive(value);
        }
    }
}

