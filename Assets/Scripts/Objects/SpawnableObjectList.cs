using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    [CreateAssetMenu(fileName="New Spawnable Objects List", menuName = "PhotoShoot/Spawnable Objects List", order = 1)]
    public class SpawnableObjectList : ScriptableObject
    {
        [Tooltip("List of all possible Spawnable Objects")]
        public List<SpawnableObject> ListOfSpawnableObjects;
    }
}

