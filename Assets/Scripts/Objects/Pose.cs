using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    [CreateAssetMenu(fileName = "New Actor Pose", menuName = "PhotoShoot/Actor Pose", order = 1)]
    public class Pose: ScriptableObject
    {
        public string PoseName;
        public Sprite PoseImage;
        public AnimatorOverrideController PoseAnimation;

        public string GetPoseName()
        {
            return PoseName;
        }

        public Sprite GetPoseImage()
        {
            return PoseImage;
        }

        public AnimatorOverrideController GetPoseAnimation()
        {
            return PoseAnimation;
        }
    }
}