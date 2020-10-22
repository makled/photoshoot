using System.Collections;
using System.IO;
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

        public void SaveTexture()
        {
            byte[] bytes = toTexture2D(RendTextureRef).EncodeToPNG();
            System.IO.File.WriteAllBytes(Path.Combine(Application.dataPath, Time.time.ToString() + ".png"), bytes);
        }
        Texture2D toTexture2D(RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(1920, 1080, TextureFormat.RGB24, false);
            RenderTexture.active = rTex;
            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();
            return tex;
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

