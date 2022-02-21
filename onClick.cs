using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour
{
    Color oriColor;

    public bool addLeg;

    public GameObject leg;

    int count;

    Rigidbody rb;

    public GameObject particle;


    void Start()
    {
        oriColor = gameObject.GetComponent<Renderer>().material.color;
        addLeg = false;

        count = 0;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (addLeg)
        {
            //add leg
            GameObject newLeg = Instantiate(leg, transform.position, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
            newLeg.transform.parent = gameObject.transform;
            count += 1;
            addLeg = false;
        }

        if (count >= 5)
        {
            rb.AddForce(new Vector3(Random.Range(1f,15f), 0, Random.Range(1f, 15f)));
        }

        if (count >= 15)
        {
            StartCoroutine(die());
        }
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = oriColor;
    }

    void OnMouseDown()
    {
        addLeg = !addLeg;
    }

    IEnumerator die()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.75f);
        Destroy(gameObject);
    }
}
