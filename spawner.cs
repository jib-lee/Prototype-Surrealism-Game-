using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject block;

    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 pos = new Vector3(Random.Range(minX, maxX), 10f, Random.Range(minZ,maxZ));
            Instantiate(block, pos, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
