using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveVector = .005f;
    public float jumpVector = 400f;
    public Vector3 startPos;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody>();
        Vector3 pos = transform.position;
        startPos = new Vector3(pos.x,pos.y,pos.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move; 
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
           move = new Vector3(moveVector, 0.0f, 0.0f);
           transform.position += move;
           transform.forward = move.normalized;
           
        }
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {
           move = new Vector3(0.0f, 0.0f, moveVector);
           transform.position += move;
           transform.forward = move.normalized;
        }
        if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
        {
           move = new Vector3(moveVector, 0.0f, 0.0f);
           transform.position -= move;
           transform.forward = -move.normalized;
        }
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
           move = new Vector3(0.0f, 0.0f, moveVector);
           transform.position -= move;
           transform.forward = -move.normalized;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    
    }
    public void Jump()
    {
      if(rb.velocity.y==0){
        rb.AddForce(new Vector3(0.0f, jumpVector, 0.0f));
        
      }
    }
    public void restart(){
      transform.position = startPos;
    }
    void OnCollisionEnter(Collision col){
      if(col.gameObject.tag == "Enemy"){
        restart();
      }
    }
}
