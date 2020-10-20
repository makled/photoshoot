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
        // Start is called before the first frame update
        void Awake()
        {
            if(Instance == null)
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

                GameObject obj = Instantiate(selectedObject, this.transform);
                obj.transform.position = selectedObject.transform.position;
                obj.transform.rotation = selectedObject.transform.rotation;

                SetSelectionMaterial(obj.GetComponent<Renderer>());
            }
            else
            {
                RemoveSelection();
            }
        }


        void RemoveSelection()
        {
            selectedObject = null;
            foreach (var child in GetComponentsInChildren<Transform>())
            {
                if (child.gameObject.CompareTag("SelectionManager"))
                {
                    continue;
                }
                else
                {
                    Destroy(child.gameObject);
                }
            }
        }

        void SetSelectionMaterial(Renderer renderer)
        {
            renderer.material = SelectionMaterial;
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            for (int i = 0; i < renderer.materials.Length; i++)
            {
                renderer.materials[i] = SelectionMaterial;
            }
        }
    }
}