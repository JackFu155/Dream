using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowShoot : MonoBehaviour
{
    public float shootForce=10f;
    public GameObject player;
    public float shootDist=5f;
    public float startRadius=.5f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
      rb=GetComponent<Rigidbody>();
      transform.forward=player.transform.forward;
      transform.position = player.transform.position + (player.transform.forward*startRadius); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward*shootForce);
        if((player.transform.position-transform.position).magnitude>=shootDist){
          Destroy(gameObject);
          Debug.Log(player.transform.position -transform.position);
        }
        
    }
    void OnCollisionEnter(Collision col){
      if(col.gameObject.tag!="Target"&&col.gameObject.tag!="Player"){
      Destroy(gameObject);
      Debug.Log("This");
    }
}
}
