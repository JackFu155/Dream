using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool activated = false;
    public GameObject manager;
    public Vector3 pos,ext,sz;
    public Rect rBox;
    // Start is called before the first frame update
    void Start()
    {
        //activated = manager.GetComponent<bool>();
            pos = gameObject.transform.position; 
            sz = gameObject.GetComponent<BoxCollider>().size;
            float x = pos.x - (sz.x/2);
            float z = pos.z - (sz.z/2);
            rBox = new Rect(x,z,sz.x,sz.z);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision col)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (col.gameObject.tag == "Box")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            
            activated = rBox.Contains(new Vector2(col.transform.position.x,col.transform.position.z));
        }
    }
}
