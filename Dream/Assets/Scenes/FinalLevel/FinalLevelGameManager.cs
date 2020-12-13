using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelGameManager : MonoBehaviour
{
  public GameObject[] enemies;
  public GameObject player;
  public GameObject PillowPrefab;
  public GameObject Enemy;
  public GameObject[] buttons;
  public GameObject target;
  public Target t;
  public GameObject door;
  public float raiseSpeed = 1f;
  public List<ShootButton> sBs;
  public bool isActivated;
  void Start()
  {
    t=target.GetComponent<Target>();
    PillowPrefab.GetComponent<PillowShoot>().player=player;
    enemies = new GameObject[2];
    List<Vector3> mLI = new List<Vector3>();
    List<List<Vector3>> mL = new List<List<Vector3>>();
    mLI.Add(new Vector3(1.5f,1f,21.72f));
    mLI.Add(new Vector3(-16f,1f,21.72f));
    mL.Add(mLI); 
    mLI = new List<Vector3>();
    mLI.Add(new Vector3(-16f,1f,21.72f));
    mLI.Add(new Vector3(-16f,1f,-15.75f));
    mL.Add(mLI); 
    mLI = new List<Vector3>();
    mLI.Add(new Vector3(-16f,1f,-15.75f));
    mLI.Add(new Vector3(1.5f,1f,-15.75f));
    mL.Add(mLI); 
    mLI = new List<Vector3>();
    mLI.Add(new Vector3(1.5f,1f,-15.75f));
    mLI.Add(new Vector3(1.5f,1f,21.72f));
    mL.Add(mLI); 
    enemies[0]=Instantiate(Enemy);
    EnemyMovement eM = enemies[0].GetComponent<EnemyMovement>();
    eM.setVars(mL,2.5f,3f);
    eM.sightDist=7;
    eM.sightAngle=90f;
    eM.player=player;
    mL = new List<List<Vector3>>(); 
    mLI = new List<Vector3>();
    mLI.Add(new Vector3(-16f,1f,-15.75f));
    mLI.Add(new Vector3(1.5f,1f,-15.75f));
    mL.Add(mLI); 
    mLI = new List<Vector3>();
    mLI.Add(new Vector3(1.5f,1f,-15.75f));
    mLI.Add(new Vector3(1.5f,1f,21.72f));
    mL.Add(mLI); 
    mLI = new List<Vector3>();
    mLI.Add(new Vector3(1.5f,1f,21.72f));
    mLI.Add(new Vector3(-16f,1f,21.72f));
    mL.Add(mLI); 
    mLI = new List<Vector3>();
    mLI.Add(new Vector3(-16f,1f,21.72f));
    mLI.Add(new Vector3(-16f,1f,-15.75f));
    mL.Add(mLI); 
    enemies[1]=Instantiate(Enemy);
    eM = enemies[1].GetComponent<EnemyMovement>();
    eM.setVars(mL,2.5f,3f);
    eM.sightDist=7;
    eM.sightAngle=90f;
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
    isActivated=true;
    foreach(ShootButton sb in sBs){
      if(!sb.activate){
        isActivated=false;
      } 
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
    if(t.asleep){
      winLevel();
    }

  }

  public void winLevel(){
    Debug.Log("Target is asleep You Win!");
  }

  void OnGUI(){ 
    if(t.asleep){
      GUI.color = Color.white;    //text color 
      GUI.skin.label.fontSize = 50; //font size
      GUI.Label(new Rect(((Screen.width/2)-200),((Screen.height/2)-100),500,200),"Target Asleep\n Mission Accomplished."); 

    }
  }
}

