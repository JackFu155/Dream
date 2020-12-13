using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs2Script : MonoBehaviour
{
    public Level4GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col){
      if(col.gameObject.tag == "Player"){
        gM.nextLevel();
      }
    }
}
