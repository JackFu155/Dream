using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool fallingDown;
    public bool asleep;
    public float angleSpeed =45f;
    public float moveSpeed= 2f;
    public float tRot,tMov;
    public Vector3 proneMove; 
    public float bodyRadius=.5f;
    public Vector3 fallVector;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        fallingDown = false;
        asleep =false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
       float dt=Time.deltaTime;
       if(fallingDown){
        tRot+= angleSpeed*dt;
        tMov+= moveSpeed*dt;
        transform.up = Vector3.Slerp(Vector3.up,fallVector,tRot);
        transform.position = Vector3.Lerp(startPos,proneMove,tMov);
        if(tRot>=1&&tMov>=1){
          fallingDown = false;
          asleep=true;
        }
       }
       
    }
    
    void OnCollisionEnter(Collision col){
      if(col.gameObject.tag=="Pillow"){
        Destroy(col.gameObject);
        fallingDown=true;
        proneMove=new Vector3(transform.position.x,bodyRadius,transform.position.z);
        fallVector = new Vector3((transform.position-col.transform.position).x,0,(transform.position-col.transform.position).z);
        Vector3 pos = transform.position;
        startPos= new Vector3(pos.x,pos.y,pos.z);
      }
    } 
}
