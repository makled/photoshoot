using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    [CreateAssetMenu(fileName="New Spawnable Object", menuName = "PhotoShoot/Spawnable Object", order = 1)]
    public class SpawnableObject : ScriptableObject
    {
        [Tooltip("The name of the object that will be displayed in the UI")]
        public string Name;

        [Tooltip("Description of the object")]
        [TextArea]
        public string Description;

        [Tooltip("Prefab reference of the object itself")]
        public GameObject ObjectPrefabAssetReference;
        [Tooltip("Image that will be displayed in the UI")]
        public Sprite UIImage;
        public ObjectType ObjectType;
        public GameObject OutlineObject;
    }

    public enum ObjectType
    {
        Actor,
        Light,
        Camera
    }
}

