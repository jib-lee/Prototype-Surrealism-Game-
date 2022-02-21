using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class reload_Hallway : MonoBehaviour
{
    public Light pointLight;
    bool lightFade;

    public GameObject wall1;
    public GameObject wall2;
    public GameObject ceiling;
    public GameObject trigger;
    bool moveWalls;

    private Camera cam;
    public bool flipCam;

    void Start()
    {
        lightFade = false;
        moveWalls = false;
        cam = gameObject.GetComponentInChildren<Camera>();
        flipCam = false;
    }

  
    void Update()
    {
      if (lightFade)
        {
            StartCoroutine(lightFadeIn());
            lightFade = false;
        }

      if (moveWalls)
        {
            StartCoroutine(wallTranslate());
            moveWalls = false;
        }

      if (flipCam)
        {
            StartCoroutine(changeCameraAngle());
            flipCam = false;
        }
      
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("trig"))
        {
            transform.position = new Vector3(0.77f, 3.62f, -40f);
            Debug.Log("change pos");

            pointLight.intensity = 0;
            lightFade = true;

            moveWalls = true;

            flipCam = true;
        }
    }

    IEnumerator lightFadeIn()
    {
   
        while (pointLight.intensity < 0.2f)
        {
            pointLight.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Random.Range(1.5f, -11.5f));
            pointLight.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
            yield return new WaitForSeconds(.25f);
            pointLight.intensity += 0.02f;
        }
    }

    IEnumerator wallTranslate()
    {
        yield return null;
        wall1.transform.position = new Vector3(Random.Range(-2, -18), 8.1f, -7.97f);
        wall2.transform.position = new Vector3(Random.Range(4.5f, 19.5f),8.1f, -6.25f);
        ceiling.transform.position = new Vector3(0.52f, Random.Range(4, 30), -6.81f);
        trigger.transform.position = new Vector3(0, 9.1f, Random.Range(4, 15));
    }

    IEnumerator changeCameraAngle()
    {
        yield return null;
        cam.transform.Rotate(0, 0, Random.Range(0, 360), Space.Self);
    }
    
    
}
