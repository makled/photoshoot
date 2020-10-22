using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mkld.Photoshoot
{
    public class CameraRendererManager : MonoBehaviour
    {
        private Camera selectedCamera;
        [Tooltip("Reference to the render texture for the camera")]
        public RenderTexture RendTextureRef;
        public Animator AnimatorController;
        private bool isExpand;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExpandWindow();
                isExpand = !isExpand;
            }
        }

        public void ExpandWindow()
        {
            if (isExpand)
            {
                AnimatorController.SetTrigger("Minimize");
            }
            else
            {
                AnimatorController.SetTrigger("Expand");
            }
        }

        // public void SetSelectedCamera(Camera cam)
        // {
        //     if(selectedCamera != null)
        //     {
        //         selectedCamera.targetTexture = null;
        //     }

        //     selectedCamera = cam;
        //     selectedCamera.targetTexture = RendTextureRef;
        // }
    }
}

