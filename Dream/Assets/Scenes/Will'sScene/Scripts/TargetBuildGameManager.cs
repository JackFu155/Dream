using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBuildGameManager : MonoBehaviour
{
  public GameObject[] buttons;
  public GameObject[] enemies;
  public GameObject player;
  public GameObject PillowPrefab;
  public List<ShootButton> sBs;
  public GameObject cylinder;
    // Start is called before the first frame update
    void Start()
    {
        PillowPrefab.GetComponent<PillowShoot>().player = player;
        sBs = new List<ShootButton>();
        foreach(GameObject b in buttons){
          sBs.Add(b.GetComponent<ShootButton>());
        }
        
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
      bool allactive = true;
      foreach(ShootButton sb in sBs){
        if(!sb.activate){
          allactive=false;
        } 
      }
      if(allactive){
        cylinder.SetActive(true);
      }
    }
    public void nextLevel(){
      Debug.Log("You Win!");
    }
}
