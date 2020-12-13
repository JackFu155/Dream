using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public bool connected = false;
    public bool rise = false;
    public GameObject next;
    public float startheight;
    public float endheight;
    public float raiseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rise == true)
        {
            Rise();
            if (connected == true)
            {
                if(transform.position.y >= startheight)
                {
                    next.GetComponent<Bridge>().rise = true;
                }
            }

        }
    }

    public void Rise()
    {
        if(transform.position.y < endheight)
        {
            transform.position += new Vector3(0.0f, raiseSpeed, 0.0f);
        }
    }
}
