using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Rigidbody Controlito;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (Input.GetKeyDown(KeyCode.D))
        {
            Controlito.AddForce(new Vector3(5, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Controlito.AddForce(new Vector3(-5, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Controlito.AddForce(new Vector3(0, 500, 0));
        }
    }
}