using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveVector = .005f;
    public float jumpVector = 400f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(moveVector, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(0.0f, 0.0f, moveVector);
        }
        if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(moveVector, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            transform.position -= new Vector3(0.0f, 0.0f, moveVector);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    
    }
    public void Jump()
    {
        rb.AddForce(new Vector3(0.0f, jumpVector, 0.0f));
    }
}
