using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace mkld.Photoshoot
{
    public class ObjectListElementController : MonoBehaviour
    {
        [Tooltip("Text Object reference")]
        public TextMeshProUGUI TextObjectReference;

        [Tooltip("Image Object Reference")]
        public Image imageObject;

        [Tooltip("Reference To Spawnable Object")]
        public SpawnableObject ObjectReference;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetSpawnableObjectReference(SpawnableObject referenceObj)
        {
            ObjectReference = referenceObj;
            imageObject.sprite = ObjectReference.UIImage;
            TextObjectReference.text = ObjectReference.name;
        }

        public void OnElementClick()
        {
            if (ObjectReference == null)
                return;
                
            GameObjectSpawnManager.Instance.AddObject(ObjectReference.ObjectPrefabAssetReference);
            
        }
    }
}

