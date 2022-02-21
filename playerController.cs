using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    private float moveFwd;
    private float moveSide;

    void Start()
    {
        
    }

  
    void Update()
    {
        moveFwd = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        moveSide = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(0, 0, moveFwd);
        transform.Rotate(0, moveSide * rotateSpeed, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
