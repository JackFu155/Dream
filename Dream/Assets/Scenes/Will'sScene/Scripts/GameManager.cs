using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject[] enemies;
  public GameObject player;
  public GameObject PillowPrefab;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
