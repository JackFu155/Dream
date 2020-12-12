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
        moveList = new List<List<Vector3>>();
        List<Vector3> tempList = new List<Vector3>();
        tempList.Add(new Vector3(-2,0,0));
        tempList.Add(new Vector3(2,0,0));
        moveList.Add(tempList);
        tempList = new List<Vector3>();
        tempList.Add(new Vector3(2,0,0));
        tempList.Add(new Vector3(2,0,2));
        moveList.Add(tempList);  
        tempList = new List<Vector3>();
        tempList.Add(new Vector3(2,0,2));
        tempList.Add(new Vector3(2,0,-2));
        moveList.Add(tempList);

        tempList = new List<Vector3>();
        tempList.Add(new Vector3(2,0,-2));
        tempList.Add(new Vector3(-2,0,-2));
        moveList.Add(tempList);
        tempList = new List<Vector3>();
        tempList.Add(new Vector3(-2,0,-2));
        tempList.Add(new Vector3(-2,0,0));
        moveList.Add(tempList);
        movementPath=new Path(moveList,true);
        Debug.Log(movementPath.Index);

    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        transform.position=movementPath.move(velocity*dt);
    }
}
