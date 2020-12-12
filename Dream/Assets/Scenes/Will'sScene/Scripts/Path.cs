using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
  private List<List<Vector3>> pathList;
  private float t;
  private float pathDist;
  public float T{
    get {
      return t;
    }
    set{
      t=value;
    }
  }
  private int index;
  private bool reverse;
  public int Index{
    get{
      return index;
    }
    set{
      index=value;
    }
  }
  private bool circle;
  public bool Circle{
    get{
      return circle;
    }
    set{
      circle = value;
    }
  }
  public Path(){
    pathList = new List<List<Vector3>>();
    circle = false;
    pathDist=1;
    index=0;
    reverse=false;
    t=0;
  }
  public Path(Vector3 start, Vector3 end, bool circle){
    List<Vector3> temp = new List<Vector3>();
    pathList = new List<List<Vector3>>();
    temp.Add(start);
    temp.Add(end);
    pathList.Add(temp);
    this.circle = circle;
    pathDist = (end-start).magnitude;
    this.reverse=false;
    index=0;
    t=0;
    Debug.Log("Path Created");

  }

  public Path(List<List<Vector3>> list, bool circle){
    this.pathList = list;
    this.circle = circle;
    this.reverse=false;
    pathDist = (list[0][1]-list[0][0]).magnitude;
    this.reverse=false;
    index=0;
    t=0;
  }
  public void  addPath(Vector3 start,Vector3 end){

    List<Vector3> temp = new List<Vector3>();
    temp.Add(start);
    temp.Add(end);
    pathList.Add(temp);
    if(pathList.Count == 1){
      pathDist = (pathList[0][1]-pathList[0][0]).magnitude;
    }
  }
  public void shiftPath(){
    if(!reverse){
      index+=1;
      if(index>=pathList.Count){
        if(circle){
          index=0;
        }
        else{
          index-=1;
          reverse=true;
        }
      }
      if(!reverse){
        t=0;
      }
      pathDist=(pathList[index][1]-pathList[index][0]).magnitude;
    }
    else{
      index-=1;
      if(index<0){
        index=0;
        reverse=false;
        t=0;
      }
      if(reverse){
        t=1;
      }
      pathDist=(pathList[index][1]-pathList[index][0]).magnitude;

    }
  }
  public Vector3 move(float displace){
    Vector3 retVec=Vector3.zero;
    if(reverse){
      t-=displace/pathDist;
      retVec = Vector3.Lerp(pathList[index][0],pathList[index][1],t);
      if(t<=0){
        shiftPath();
      }
    }
    else{
      t+= displace/pathDist; 
      retVec = Vector3.Lerp(pathList[index][0],pathList[index][1],t);
      if(t>=1){
        shiftPath();
      }
    }
    return retVec;
  }
  public Vector3 foot(Vector3 r){
    Vector3 q = Vector3.zero;
    q = pathList[index][0] + ((Vector3.Dot((pathList[index][1]-pathList[index][0]),(r-pathList[index][0]))/(pathDist*pathDist))*(pathList[index][1]-pathList[index][0]));
    return q;
  } 

}
