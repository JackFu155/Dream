using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] enemies;
    public GameObject player;
    public GameObject PillowPrefab;
    public GameObject Enemy;
    
    public GameObject button;
    public GameObject door;
    public float raiseSpeed;
    public bool isActivated = false;
    // Start is called before the first frame update
    void Start()
    { 
      enemies = new GameObject[2];
      List<Vector3> mLI = new List<Vector3>();
      List<List<Vector3>> mL = new List<List<Vector3>>();
      mLI.Add(new Vector3(-4.7f,1f,10.4f));
      mLI.Add(new Vector3(0f,1f,10.4f));
      mL.Add(mLI); 
      enemies[0]=Instantiate(Enemy);
      enemies[0].GetComponent<EnemyMovement>().setVars(mL,1,3);
      enemies[0].GetComponent<EnemyMovement>().player=player;
      mL = new List<List<Vector3>>();
      mLI = new List<Vector3>();
      mLI.Add(new Vector3(-22.5f,1f,-22.5f));
      mLI.Add(new Vector3(-22.5f,1,22.5f));
      mL.Add(mLI); 
      mLI = new List<Vector3>();
      mLI.Add(new Vector3(-22.5f,1f,22.5f));
      mLI.Add(new Vector3(22.5f,1,22.5f));
      mL.Add(mLI); 
      mLI = new List<Vector3>();
      mLI.Add(new Vector3(22.5f,1f,22.5f));
      mLI.Add(new Vector3(22.5f,1,-22.5f));
      mL.Add(mLI);

      mLI = new List<Vector3>();
      mLI.Add(new Vector3(22.5f,1f,-22.5f));
      mLI.Add(new Vector3(-22.5f,1,-22.5f));
      mL.Add(mLI); 
           
      enemies[1]=Instantiate(Enemy);
      EnemyMovement eM = enemies[1].GetComponent<EnemyMovement>();
      eM.setVars(mL,10,10);
      eM.sightDist=10;
      eM.sightAngle=90f;
      eM.player=player;
      
      PillowPrefab.GetComponent<PillowShoot>().player = player;


    }

    // Update is called once per frame
    void Update()
    {
        
      EnemyMovement eM;
      if(Input.GetKeyDown(KeyCode.C)){
        foreach(GameObject e in enemies){
          eM=e.GetComponent<EnemyMovement>();
          eM.aiSwap();
        }
      }
      if(Input.GetKeyDown(KeyCode.Z)){
        Instantiate(PillowPrefab);
      }
      
      isActivated = button.GetComponent<Button>().activated; 
        if(isActivated == true)
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

    }
    public void nextLevel(){
      Debug.Log("You Win!");
    }
}
