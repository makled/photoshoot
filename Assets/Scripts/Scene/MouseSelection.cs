using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    public class MouseSelection : MonoBehaviour
    {
        private GameObject selectedObject;

        [Tooltip("This material will be used to identify selected object")]
        public Material SelectionMaterial;
        public static MouseSelection Instance;
        private GameObject outlineObject;
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

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectObject(Input.mousePosition);
            }
        }

        public GameObject GetSelectedObject()
        {
            return selectedObject;
        }

        void SelectObject(Vector3 mousePosition)
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition), out hitInfo);

            if (hit)
            {
                if (hitInfo.transform.gameObject.GetComponent<SelectableObject>())
                {
                    RemoveSelection();

                    selectedObject = hitInfo.transform.gameObject;
                    selectedObject.GetComponent<SelectableObject>().SelectObject();


                    // GameObject obj = Instantiate(selectedObject, selectedObject.transform);
                    // Destroy(obj.GetComponent<Collider>());
                    // Destroy(obj.GetComponent<SelectableObject>());

                    // obj.tag = "Untagged";
                    // obj.transform.position = selectedObject.transform.position;
                    // obj.transform.rotation = selectedObject.transform.rotation;

                    // outlineObject = obj;

                    // Renderer[] renderers = outlineObject.GetComponentsInChildren<Renderer>();
                    // SetSelectionMaterial(renderers);

                    //selectedObject.GetComponentInChildren<RotationUIController>(true).gameObject.SetActive(true);
                    //ROTATION UI CONTROLLER ADJUSTMENT
                    TransformationManager.Instance.ShowRotationUI(true);
                    TransformationManager.Instance.ShowYTranslationUI(true);

                    //TransformationManager.Instance.SetTranslation(true);
                    // RotationUIController.Instance.SetUIController(selectedObject.transform.position);
                }

                if (hitInfo.transform.gameObject.GetComponent<RotationUIController>())
                {
                    hitInfo.transform.gameObject.GetComponent<RotationUIController>().SetInteraction(true);
                }

                if (hitInfo.transform.gameObject.GetComponent<YTranslationUIController>())
                {
                    hitInfo.transform.gameObject.GetComponent<YTranslationUIController>().SetInteraction(true);
                }
            }
            else
            {
                RemoveSelection();
            }
        }

        void RemoveSelection()
        {
            if (selectedObject != null)
            {
                selectedObject.GetComponent<SelectableObject>().DeselectObject();
                TransformationManager.Instance.ShowRotationUI(false);
                TransformationManager.Instance.ShowYTranslationUI(false);

            }

            selectedObject = null;
            //Destroy(outlineObject);

            // foreach (var child in GetComponentsInChildren<Transform>())
            // {
            //     if (child.gameObject.CompareTag("SelectionManager"))
            //     {
            //         continue;
            //     }
            //     else
            //     {
            //     }
            // }
        }

    }
}