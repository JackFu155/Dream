using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Path movementPath;
    public List<List<Vector3>> moveList;
    public float velocity = 2f;
    public float returnVel;
    public float chaseMag = 300f;
    public bool wasChase=false;
    public Vector3 q;
    public float t;
    public float newT;
    public Vector3 p;
    public float dist;
    public GameObject player;
    public Rigidbody rb;
    public float sightAngle = 20f;
    public float sightDist=3f;
    public enum Ai{
      path,
      chase
    }
    public Ai ai = Ai.path;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      if(moveList ==null){
        moveList = new List<List<Vector3>>();
        List<Vector3> tempList = new List<Vector3>();
        tempList.Add(new Vector3(-2,1,0));
        tempList.Add(new Vector3(2,1,0));
        moveList.Add(tempList);
        tempList = new List<Vector3>();
        tempList.Add(new Vector3(2,1,0));
        tempList.Add(new Vector3(2,1,2));
        moveList.Add(tempList);  
        tempList = new List<Vector3>();
        tempList.Add(new Vector3(2,1,2));
        tempList.Add(new Vector3(2,1,-2));
        moveList.Add(tempList);

        tempList = new List<Vector3>();
        tempList.Add(new Vector3(2,1,-2));
        tempList.Add(new Vector3(-2,1,-2));
        moveList.Add(tempList);
        tempList = new List<Vector3>();
        tempList.Add(new Vector3(-2,1,-2));
        tempList.Add(new Vector3(-2,1,0));
        moveList.Add(tempList);
      }
      if(moveList.Count>1 && moveList[0][0].Equals(moveList[moveList.Count-1][1])){
        movementPath=new Path(moveList,true);
      }
      else{
      movementPath=new Path(moveList,false);
      }
      
    }

    // Update is called once per frame
    void Update()
    {
    
     Vector3 chaseVec= player.transform.position - transform.position;
     if(ai==Ai.path){
      float dt = Time.deltaTime;
      if(Vector3.Angle(player.transform.position-transform.position,transform.forward)<sightAngle&&chaseVec.magnitude<sightDist ){

        ai = Ai.chase;
      }
       if(wasChase){
          t+=dt*returnVel;
          transform.position = Vector3.Lerp(p,q,t);
          if(t>=1){
            movementPath.T=newT;
            wasChase=false;
          }
       }else{
        Vector3 move=movementPath.move(velocity*dt);
    transform.forward=((move-transform.position).normalized);
        transform.position = move;
        
        
    }
     }

     if(ai==Ai.chase){
      if(chaseVec.magnitude>sightDist){
        aiSwap();
      }
      else{
        chaseVec=chaseVec.normalized;
        transform.forward=chaseVec;
        chaseVec=chaseVec*chaseMag;
        rb.velocity = new Vector3(chaseVec.x,0,chaseVec.z);
        
     }
    
    }
    }
    public void aiSwap(){
      if(ai == Ai.path){
        ai= Ai.chase;
      }
      else if(ai== Ai.chase){
        ai=Ai.path;
        wasChase=true;
        q=movementPath.foot(transform.position);
        dist= (q-transform.position).magnitude; 
        newT=movementPath.footT(transform.position); 
        t=0;
        returnVel=velocity/dist;
        p=new Vector3(transform.position.x,transform.position.y,transform.position.z);
      }
    }
    public void setVars(List<List<Vector3>>  mL, float vel, float mag){
      moveList =mL; 
      movementPath=new Path(mL,false);
      velocity = vel;
      chaseMag=mag;
    }
}
