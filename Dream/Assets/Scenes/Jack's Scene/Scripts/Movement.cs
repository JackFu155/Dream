using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveVector;
    public float jumpVector;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.position -= new Vector3(0.0f, 0.0f, moveVector);
        }
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.AddForce(new Vector3(0.0f, jumpVector, 0.0f));
    }
}
