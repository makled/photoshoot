using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace mkld.Photoshoot
{
    public class SelectableObject : MonoBehaviour
    {
        public UnityEvent OnSelected;
        public UnityEvent OnDeselected;

        public bool isOutline;
        public SpawnableObject ObjectRef;
        public GameObject OutlineObj;

        public void Start()
        {
            SetOutline();
        }
        public void SelectObject()
        {
            OnSelected.Invoke();
            OutlineObj.SetActive(true);
        }

        public void DeselectObject()
        {
            //Destroy(OutlineObj);
            OutlineObj.SetActive(false);
            OnDeselected.Invoke();
        }
        public void SetOutline()
        {
            Renderer[] renderers = OutlineObj.GetComponentsInChildren<Renderer>();
            SetSelectionMaterial(renderers);
            isOutline = true;
        }

        public GameObject GetOutlineObject()
        {
            return OutlineObj;
        }

        public void SetObject(SpawnableObject objectRef)
        {
            ObjectRef = objectRef;
        }

        void SetSelectionMaterial(Renderer[] renderers)
        {
            foreach (var renderer in renderers)
            {
                renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

                Material[] mats = new Material[renderer.materials.Length];

                for (int i = 0; i < mats.Length; i++)
                {
                    mats[i] = MouseSelection.Instance.SelectionMaterial;
                }

                renderer.materials = mats;
            }
        }
    }

}