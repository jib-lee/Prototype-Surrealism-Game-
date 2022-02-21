using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLook : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        float lookUp = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.left * lookUp * 2);
    }
}
