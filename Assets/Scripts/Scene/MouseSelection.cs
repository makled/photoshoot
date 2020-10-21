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
                RemoveSelection();

                selectedObject = hitInfo.transform.gameObject;

                GameObject obj = Instantiate(selectedObject, selectedObject.transform);
                obj.transform.position = selectedObject.transform.position;
                obj.transform.rotation = selectedObject.transform.rotation;

                obj.GetComponent<Collider>().enabled = false;

                outlineObject = obj;
                Renderer[] renderers = outlineObject.GetComponentsInChildren<Renderer>();
                SetSelectionMaterial(renderers);
            }
            else
            {
                RemoveSelection();
            }
        }


        void RemoveSelection()
        {
            selectedObject = null;
            Destroy(outlineObject);

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

        void SetSelectionMaterial(Renderer[] renderers)
        {
            foreach (var renderer in renderers)
            {
                renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

                Material[] mats = new Material[renderer.materials.Length];

                for (int i = 0; i < mats.Length; i++)
                {
                    mats[i] = SelectionMaterial;
                }

                renderer.materials = mats;
            }
        }
    }
}