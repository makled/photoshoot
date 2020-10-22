using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightObjectBehaviour : MonoBehaviour
{
    public Light LightSource;
    public Slider IntensitySlider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLightSourceIntensity()
    {
        LightSource.intensity = IntensitySlider.value;
    }

    public void SetUpFlat()
    {
        if (!SessionSetup.Instance.Subject)
            return;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        transform.position = SessionSetup.Instance.Subject.transform.position;
        transform.Translate(new Vector3(0f, 0f, 1f), Space.Self);
        transform.LookAt(SessionSetup.Instance.Subject.transform);
    }

    public void SetUpButterfly()
    {
        if (!SessionSetup.Instance.Subject)
            return;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);

        transform.position = SessionSetup.Instance.Subject.transform.position;
        transform.Rotate(SessionSetup.Instance.Subject.transform.right, -60f);
        transform.Translate(new Vector3(0f, 0f, 1f), Space.Self);

        transform.LookAt(SessionSetup.Instance.Subject.transform);

    }

    public void SetUpSide()
    {
        if (!SessionSetup.Instance.Subject)
            return;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);

        transform.position = SessionSetup.Instance.Subject.transform.position;
        //transform.Translate(new Vector3(0f, 0f, 1f), SessionSetup.Instance.Subject.transform);
        transform.Rotate(SessionSetup.Instance.Subject.transform.up, 90f);
        transform.Translate(new Vector3(0f, 0f, 1f), Space.Self);

        transform.LookAt(SessionSetup.Instance.Subject.transform);


    }

    public void SetUpLoop()
    {
        if (!SessionSetup.Instance.Subject)
            return;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);

        transform.position = SessionSetup.Instance.Subject.transform.position;
        //transform.Translate(new Vector3(0f, 0f, 1f), SessionSetup.Instance.Subject.transform);
        transform.Rotate(-60f, -30f, 0f);
        transform.Translate(new Vector3(0f, 0f, 1f), Space.Self);

        transform.LookAt(SessionSetup.Instance.Subject.transform);

    }
}
