using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class animCloth : MonoBehaviour
{
    public GameObject SourceObject;
	// Use this for initialization
	void Start ()
    {
        Copy();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Copy()
    {
        if (SourceObject == null) return;

        var sourceRenderer = SourceObject.GetComponent <SkinnedMeshRenderer>();
        var targetRenderer = GetComponent<SkinnedMeshRenderer>();

        if (sourceRenderer == null) return;
        if (targetRenderer == null) return;

        targetRenderer.bones =
            sourceRenderer.bones.Where(b => targetRenderer.bones.Any(t => t.name.Split(new[]{' '}, 2)[0] == b.name.Split(new[]{' '}, 2)[0])).ToArray();
    }
}
