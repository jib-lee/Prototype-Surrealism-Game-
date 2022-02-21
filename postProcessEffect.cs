using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class postProcessEffect : MonoBehaviour
{
    public PostProcessProfile ppPro;

   PostProcessVolume v;

    LensDistortion lensD;


    void Start()
    {
        v = GetComponent<PostProcessVolume>();
        v.profile.TryGetSettings<LensDistortion>(out lensD);
        lensD.intensity.value = 0;

    }

    
    void Update()
    {
        Debug.Log(lensD.intensity.value);

        
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("do sth");

            lensD.intensity.value += 3;

            lensD.scale.value -= 0.01f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("do sth");

            lensD.intensity.value -= 3;

            lensD.scale.value += 0.1f;
        }

    }

}
