using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    [CreateAssetMenu(fileName = "New Actor Pose List", menuName = "PhotoShoot/Actor Pose List", order = 1)]
    public class ActorPoses : ScriptableObject
    {
        public List<Pose> Poses;

    }

}

