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

        public void SelectObject()
        {
            OnSelected.Invoke();
        }

        public void DeselectObject()
        {
            OnDeselected.Invoke();
        }
    }

}

