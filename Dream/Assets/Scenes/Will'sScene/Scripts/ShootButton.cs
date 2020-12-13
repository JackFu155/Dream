using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButton : MonoBehaviour
{
    public Material purp;
    public Material green;
    public bool activate=false;
    private Renderer ren;
    // Start is called before the first frame update
    void Start()
    {
      ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void toggle(){
      activate =!activate;
      if(activate){
        ren.material = green;
      }else{
        ren.material = purp;
      }
    }
    void OnCollisionEnter(Collision col){
      if(col.gameObject.tag == "Pillow"){
        toggle();
      }
    }
    
}
