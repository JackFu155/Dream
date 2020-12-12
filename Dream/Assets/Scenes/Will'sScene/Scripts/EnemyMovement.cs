using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Path movementPath;
    public List<List<Vector3>> moveList;
    public float velocity = 5f;
    // Start is called before the first frame update
    void Start()
    {
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
        float dt = Time.deltaTime;
        Vector3 move=movementPath.move(velocity*dt);
    transform.forward=((move-transform.position).normalized);
        transform.position = move;
    }
}
