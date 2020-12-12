﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
