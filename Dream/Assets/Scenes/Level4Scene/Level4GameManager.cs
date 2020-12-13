using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4GameManager : MonoBehaviour
{
  public GameObject[] enemies;
  public GameObject player;
  public GameObject PillowPrefab;
  public GameObject Enemy;
  public GameObject[] buttons;
  public GameObject door;
  public GameObject door2;
  public float raiseSpeed = 1f;
  public List<ShootButton> sBs;
  public bool isActivated;
  public bool isActivated2;
  // Start is called before the first frame update
  void Start()
  {
    PillowPrefab.GetComponent<PillowShoot>().player=player;
    enemies = new GameObject[2];
    List<Vector3> mLI = new List<Vector3>();
    List<List<Vector3>> mL = new List<List<Vector3>>();
    mLI.Add(new Vector3(0f,1f,0f));
    mLI.Add(new Vector3(-20f,1f,0f));
    mL.Add(mLI); 
    enemies[0]=Instantiate(Enemy);

    EnemyMovement eM = enemies[0].GetComponent<EnemyMovement>();
    eM.setVars(mL,1,3);
    eM.sightDist=5;
    eM.sightAngle=20f;
    eM.player=player;

    mLI = new List<Vector3>();
    mL = new List<List<Vector3>>();
    mLI.Add(new Vector3(19.5f,1f,9f));
    mLI.Add(new Vector3(19.5f,1f,24.5f));
    mL.Add(mLI); 
    enemies[1]=Instantiate(Enemy);

    eM = enemies[1].GetComponent<EnemyMovement>();
    eM.setVars(mL,1,3);
    eM.sightDist=5;
    eM.sightAngle=20f;
    eM.player=player;

    foreach(GameObject b in buttons){
        sBs.Add(b.GetComponent<ShootButton>());
    }
  }

  // Update is called once per frame
  void Update()
  {


    if(Input.GetKeyDown(KeyCode.Z)){
      Instantiate(PillowPrefab);
    }
    
    if(sBs[0].activate && sBs[1].activate){
      isActivated=true;
    }
    else{
      isActivated=false;
    }

    if(isActivated)
    {
      if (door.transform.position.y < 6.0f)
      {
        door.transform.position += new Vector3(0.0f, raiseSpeed, 0.0f);
      }
    }
    else
    {
      if(door.transform.position.y > 2.0f)
      {
        door.transform.position -= new Vector3(0.0f, raiseSpeed, 0.0f);
      }
    }
    isActivated2=true;
    foreach(ShootButton sb in sBs){
        if(!sb.activate){
          isActivated2=false;
        } 
      }
    if(isActivated2)
    {
      if (door2.transform.position.y < 6.0f)
      {
        door2.transform.position += new Vector3(0.0f, raiseSpeed, 0.0f);
      }
    }
    else
    {
      if(door2.transform.position.y > 2.0f)
      {
        door2.transform.position -= new Vector3(0.0f, raiseSpeed, 0.0f);
      }
    }
    

  }

    public void nextLevel(){
      Debug.Log("You Win!");
    }
}
