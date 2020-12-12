using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) == true)
        {
            transform.position += new Vector3(moveVector, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.position += new Vector3(0.0f, 0.0f, moveVector);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            transform.position -= new Vector3(moveVector, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.position -= new Vector3(0.0f, 0.0f, moveVector);
        }
    }
}
