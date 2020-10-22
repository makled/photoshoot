using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CameraUICanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCameraUI(bool value)
    {
        CameraUICanvas.SetActive(value);
    }
}
